using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Valve.VR;
using System.Runtime.InteropServices;
using ValueFactoryVRCRouterCommon;
using System.Threading;
using System.Text;
using System.IO;

namespace ValueFactoryVRCRouterCommon {
  internal static class Program {

    enum Log_Type {
      normal,
      warning,
      error
    }

    static void logt(string type, string message, Log_Type log_type = Log_Type.normal) {
      if(log_type == Log_Type.warning) {
        var col = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"[{type}] ");
        Console.ForegroundColor = col;
      }
      else if(log_type == Log_Type.error) {
        var col = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"[{type}] ");
        Console.ForegroundColor = col;
      }
      else {
        Console.Write($"[{type}] ");
      }
      Console.WriteLine(message);
    }

    static CVRSystem vr_system;

    public static List<string> autoclose_exes = new List<string>();

    public static void terminate_autostart_apps() {
      logt("autostart", "Closing autostarted apps...");

      foreach(var exe in autoclose_exes) {
        Native.terminate_app_by_name(exe);
      }

      foreach(var process_id in child_processes) {
        Native.terminate_app(process_id);
      }
    }

    public static void on_exit() {
      terminate_autostart_apps();
    }

    readonly static uint VREvent_T_Size = (uint)Marshal.SizeOf(typeof(VREvent_t));

    public static void vr_thread() {
      logt("vr thread", "Started!");

      VREvent_t ev = new VREvent_t();
      while(true) {
	      if(vr_system.PollNextEvent(ref ev, VREvent_T_Size)) {
          if(ev.eventType == (uint)EVREventType.VREvent_Quit) {
            logt("vr thread", "Got VREvent_Quit event, stopping.");

            // NOTE(valuef): terminate_autostart_apps uses resources created on the main thread, but
            // we're not going to be writing to them in any way that would cause threading issues, so
            // this is okay!
            // 2023-05-08
            terminate_autostart_apps();
            logt("vr thread", "Exiting VR Thread\n");
            return;
          }
        }
        else {
          Thread.Sleep(1000);
        }
      }
    }


    public static Config.V1 config = new Config.V1();
    public static List<uint> child_processes = new List<uint>();

    public struct Route_Endpoint {
      public EndPoint endpoint;
      public string address;
      public int port;
    }

    public static List<Route_Endpoint> route_endpoints= new List<Route_Endpoint>();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    const uint MB_ABORTRETRYIGNORE = 0x00000002;
    const uint MB_CANCELTRYCONTINUE = 0x00000006;
    const uint MB_HELP = 0x00004000;
    const uint MB_OK = 0x00000000;
    const uint MB_OKCANCEL = 0x00000001;
    const uint MB_RETRYCANCEL = 0x00000005;
    const uint MB_YESNO = 0x00000004;
    const uint MB_YESNOCANCEL = 0x00000003;

    const uint MB_ICONEXCLAMATION = 0x00000030;
    const uint MB_ICONWARNING = 0x00000030;
    const uint MB_ICONINFORMATION = 0x00000040;
    const uint MB_ICONASTERISK = 0x00000040;
    const uint MB_ICONQUESTION = 0x00000020;
    const uint MB_ICONSTOP = 0x00000010;
    const uint MB_ICONERROR = 0x00000010;
    const uint MB_ICONHAND = 0x00000010;

    static void msg_box(string text, uint type = MB_OK | MB_ICONWARNING) {
      MessageBox(new IntPtr(0), text, "VRCRouter", type);
    }

    static void loud_crash(string text) {
      msg_box(text, MB_OK | MB_ICONERROR);
      Environment.Exit(1);
    }

    [DllImport("Kernel32")]
    static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

    delegate bool EventHandler(CtrlType sig);
    static EventHandler exit_handler;

    enum CtrlType {
      CTRL_C_EVENT = 0,
      CTRL_BREAK_EVENT = 1,
      CTRL_CLOSE_EVENT = 2,
      CTRL_LOGOFF_EVENT = 5,
      CTRL_SHUTDOWN_EVENT = 6
    }


    [STAThread]
    static void Main(string[] args) {
      try {
        wrapped_main(args);
      }
      catch(Exception ex) {
        msg_box($"Uh oh! We've encountered an unhandled error. Please let us know about this at discord.shader.gay\r\n\r\n\r\n{ex}\r\n\r\nThe router will now exit.", MB_OK | MB_ICONERROR);
        Process.Start(new ProcessStartInfo() { FileName = "https://discord.shader.gay", UseShellExecute = true });
      }
    }

    static void wrapped_main(string[] args) {
      exit_handler += (s) => { on_exit(); return true; };
      SetConsoleCtrlHandler(exit_handler, true);
      Console.CancelKeyPress += (s, e) => { on_exit(); };
      AppDomain.CurrentDomain.ProcessExit += (s, e) => { on_exit(); };

      Console.WriteLine("");
      Console.WriteLine($"--> Starting VRCRouter build {Build.build_version}, date {Build.build_date}");
      Console.WriteLine($"--> ValueFactory https://shader.gay");
      Console.WriteLine("------------------------------------");
      Console.WriteLine("");

      do {

        var vr_err = EVRInitError.None;
        try {
          vr_system = OpenVR.Init(ref vr_err, EVRApplicationType.VRApplication_Background);
        }
        catch(Exception ex) {
          logt("vr", $"VR_Init failed due to an exception: {ex}. SteamVR initialization stopped. The router will still function.", Log_Type.error);
          break;
        }

        if(vr_system == null) {
          var err_desc = OpenVR.GetStringForHmdError(vr_err);
          logt("vr", $"VR_Init failed: {err_desc}. SteamVR initialization stopped. The router will still function.", Log_Type.warning);
          break;
        }

        logt("vr", "SteamVR setup done!");
      } while(false);

      if(File.Exists(Config.FILE)) {
        var new_config = Config.try_load_config(Config.FILE, out var load_ex, out var load_error);
        if(new_config == null) {
          logt("config", $"Failed to load config. Using defaults. Error message: {load_error}", Log_Type.warning);
          if(load_ex != null) {
            logt("config", $"Exception: {load_ex}", Log_Type.warning);
          }
        }
        else {
          config = new_config;
        }
      }
      else {
        logt("config", $"Config file not found ({Config.FILE}). Using defaults.", Log_Type.warning);
      }

      if(config.wait_for_vrchat) {
        logt("vrchat", "Wait for VRChat is enabled. Waiting for VRChat to start before launching autostart apps and routing...", Log_Type.warning);
        var result = Native.wait_for_vrchat_to_start();
        if(result) {
          logt("vrchat", "VRChat executable found! Continuing.");
        }
        else {
          logt("vrchat", "An error occurred while waiting for VRChat to start. Stopping waiting and continuing.", Log_Type.error);
        }
      }

      do {

        var files = Route.get_routes_folder_contents(out var routes_folder_err);
        if(routes_folder_err != null) {
          logt("route", routes_folder_err, Log_Type.error);
          break;
        }

        foreach(var file in files) {
          logt("route", $"Loading route {file}");

          var route = Route.try_load_route(file, out var load_ex, out var load_error);

          if(route == null) {
            logt("route", load_error, Log_Type.error);
            if(load_ex != null) {
              logt("route", $"Exception: {load_ex}", Log_Type.error);
            }
            continue;
          }

          if(!route.enabled) {
            logt("route", "Route disabled, skipping.", Log_Type.warning);
            continue;
          }

          if(string.IsNullOrWhiteSpace(route.autostart_path)) {
            logt("route", "Doesn't specify autostart-path, no app will be started.", Log_Type.warning);
          }
          else {
            var data = Common.prep_autostart_data(route, out var error);
            if(error != null) {
              logt("route", error, Log_Type.warning);
              // NOTE(valuef): We still continue even if we errored as that function should give us valid autostart data all the time
              // 2023-06-21
            }

            var result = new Native.Autostart_App_Result();
            Native.launch_autostart_app(new StringBuilder(data.full_path), new StringBuilder(data.args), new StringBuilder(data.working_dir), ref result);

            if(result.success) {
              child_processes.Add(result.id);
              logt("route", $"Started app {route.autostart_path} {data.args}");
            }
            else {
              logt("route", $"Failed to start the autostart app at path {data.full_path} with args {data.args} and working directory {data.working_dir}. Error code: {result.error}");
            }
          }

          if(!string.IsNullOrWhiteSpace(route.autoclose_executable_name)) {
            autoclose_exes.Add(route.autoclose_executable_name);
            logt("route", $"Registered an executable to autoclose: {route.autoclose_executable_name}");
          }

          if(!route.routing_enabled) {
            logt("route", "OSC Routing has been explicitly disabled on this route.", Log_Type.warning);
          }
          else if(string.IsNullOrWhiteSpace(route.output_address)) {
            logt("route", "Doesn't specify output-address, no routing will be done.", Log_Type.warning);
          }
          else if(route.output_port <= 0) {
            logt("route", "Doesn't specify a valid output-port, no routing will be done.", Log_Type.warning);
          }
          else {
            IPAddress ip;
            if (!IPAddress.TryParse(route.output_address, out ip)) {
              logt("route", $"The address '{route.output_address}' is invalid! No routing will be done for this route.", Log_Type.error);
            }
            else {
              EndPoint endpoint = null;
              try {
                endpoint = new IPEndPoint(ip, route.output_port);
              }
              catch(ArgumentOutOfRangeException ex) {
                logt("route", $"Looks like the port '{route.output_port}' is not a valid port! No routing will be done for this route.", Log_Type.error);
              }

              if(endpoint != null) {
                var end = new Route_Endpoint();
                end.endpoint = endpoint;
                end.address = route.output_address;
                end.port = route.output_port;
                route_endpoints.Add(end);
                logt("route", $"Registered route output to {route.output_address}:{route.output_port}");
              }
            }
          }
        }

      } while(false);

      var do_routing = true;

      var receive_socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
      receive_socket.ReceiveTimeout = 0;
      var send_socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

      EndPoint receive_endpoint = null;
      do {
        IPAddress receive_ip = null;
        if(!IPAddress.TryParse(config.receive_address, out receive_ip)) {
          logt("router", $"Looks like the receive IP Address '{config.receive_address}' is not a valid IP address! No routing will be done.", Log_Type.error);
          do_routing = false;
          break;
        }
        
        try {
          receive_endpoint = new IPEndPoint(receive_ip, config.receive_port);
        }
        catch(ArgumentOutOfRangeException ex) {
          logt("router", $"Looks like the receive port '{config.receive_port}' is not a valid port! No routing will be done.", Log_Type.error);
          do_routing = false;
          break;
        }

        while(true) {
          try {
            receive_socket.Bind(receive_endpoint);
            break;
          }
          catch(Exception e) {
            logt("router", $"Failed to bind the receive socket to {config.receive_address}:{config.receive_port}.\r\nThat port may already be in use by another OSC program, please double-check.\r\n\r\nException info:{e}\r\n\r\nPress any key to retry binding...", Log_Type.error);
            Console.Read();
          }
        }
      } while(false);

      if(vr_system != null) {
        logt("vr", "Startig SteamVR background thread.");
        var thread = new Thread(vr_thread);
        thread.Start();
      }

      if(do_routing) {
        logt("router", "Startig OSC routing.");
        var buffer_size = 1024 * 4;
        var buffer = new byte[buffer_size];

        while(true) {

          int num_bytes_received = 0;
          try {
            num_bytes_received = receive_socket.ReceiveFrom(buffer, 0, buffer_size, SocketFlags.None, ref receive_endpoint);
          }
          catch(Exception ex) {
            loud_crash($"Router malfunction! Failed to receive data from {config.receive_address}:{config.receive_port}.\r\n\r\nException info: {ex}\r\n\r\n\r\nThe router will now exit.");
          }

          foreach(var end in route_endpoints) {
            try {
              send_socket.SendTo(buffer, 0, num_bytes_received, SocketFlags.None, end.endpoint);
            }
            catch(Exception ex) {
              loud_crash($"Router malfunction! Failed to send data to {end.address}:{end.port}.\r\n\r\nException info: {ex}\r\n\r\n\r\nThe router will now exit.");
            }
          }
        }
      }
      else {
        msg_box("Failed to start OSC Routing. Please check the console for more information.", MB_OK | MB_ICONWARNING);
      }
    }
  }
}
