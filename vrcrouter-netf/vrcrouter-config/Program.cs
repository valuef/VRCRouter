using System.Diagnostics;
using System.IO;
using System.Text;
using Valve.VR;
using System;
using ValueFactoryVRCRouterCommon;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using ValueFactoryVRCRouterConfig;
using Newtonsoft.Json;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ValueFactoryVRCRouterConfig {
  internal static class Program {

    static DeferDisposable Defer(Action action) => new DeferDisposable(action);

    internal readonly struct DeferDisposable : IDisposable {
      readonly Action _action;
      public DeferDisposable(Action action) => _action = action;
      public void Dispose() => _action();
    }

    public static Config.V1 config = new Config.V1();
    static Main main;
    public static bool is_loading = true;

    public static List<Route.V1> routes = new List<Route.V1>();
    public static int selected_route_index = -1;

    public static Route.V1 get_edited_route() => routes[selected_route_index];

    public static void save_route(Route.V1 route) {
      if(Route.try_save(route, out var ex, out var err)) {
        show_confirm_notif("Route saved!");
      }
      else {
        if(ex == null) {
          MessageBox.Show(err, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else {
          MessageBox.Show($"{err}.\r\n\r\nException info {ex}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    public static bool try_rename_route(string new_name, out Exception out_ex, out string out_error) {
      var route = get_edited_route();

      foreach(var existing_route in routes) {
        if(existing_route.name.Equals(new_name, StringComparison.InvariantCultureIgnoreCase)) {
          out_ex = null;
          out_error = "A route with that name already exists.";
          return false;
        }
      }

      var old_path = Route.make_path_to_route(route.name);
      var new_path = Route.make_path_to_route(new_name);

      if(File.Exists(new_path)) {
        out_ex = null;
        out_error = $"A file already exists at path '{new_path}'";
        return false;
      }

      var old_name = route.name;
      route.name = new_name;

      if(!Route.try_save(route, out out_ex, out out_error)) {
        route.name = old_name;
        out_error = $"Failed to save route file to new path '{new_path}'. Error: {out_error}";
        return false;
      }

      {
        is_loading = true;
        main.route_list.Items[selected_route_index] = new_name;
        is_loading = false;
      }

      main.route_name.Text = new_name;

      try {
        File.Delete(old_path);
      }
      catch(Exception ex) {
        Console.WriteLine($"An exception occured while trying to remove {old_path}. Exception {ex}");
      }

      out_error = null;
      out_ex = null;
      return true;
    }

    public static void populate_route_configuration() {
      is_loading = true;

      var route = get_edited_route();
      main.route_name.Text = route.name;
      main.route_enabled.Checked = route.enabled;

      main.route_osc_receive_address.Text = route.output_address;
      main.route_osc_receive_port.Value = route.output_port;

      main.route_autostart_path.Text = route.autostart_path;
      main.route_autostart_args.Text = route.autostart_args;

      main.route_autoclose_app_executable_name.Text = route.autoclose_executable_name;

      main.route_osc_enabled.Checked = route.routing_enabled;

      if(route.routing_enabled) {
        main.route_osc_receive_address.Enabled = true;
        main.route_osc_receive_port.Enabled = true;
      }
      else {
        main.route_osc_receive_address.Enabled = false;
        main.route_osc_receive_port.Enabled = false;
      }

      is_loading = false;
    }

    public static void launch_autostart_app(Route.V1 route) {
      var data = Common.prep_autostart_data(route, out var error);

      if(error != null) {
        MessageBox.Show(error, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        // NOTE(valuef): We still continue even if we errored as that function should give us valid autostart data all the time
        // 2023-06-21
      }

      var result = new Native.Autostart_App_Result();
      Native.launch_autostart_app(new StringBuilder(data.full_path), new StringBuilder(data.args), new StringBuilder(data.working_dir), ref result);

      if(result.success) {
        show_confirm_notif($"Started app {Path.GetFileNameWithoutExtension(route.autostart_path)}");
      }
      else {
        MessageBox.Show($"Failed to start the autostart app at path {data.full_path} with args {data.args} and working directory {data.working_dir}.\r\nError code: {result.error}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static bool try_create_new_route(string name, out Exception out_ex, out string error) {
      if(!is_valid_new_route_name(name, out error)) {
        out_ex = null;
        return false;
      }

      var route = new Route.V1();
      route.version = Route.LATEST_VERSION;
      route.name = name;

      {
        var empty_port = 9002;
        while(true) {
          var found_port = true;
          foreach(var other_route in routes) {
            if(other_route.output_port == empty_port) {
              empty_port += 1;
              found_port = false;
              break;
            }
          }

          if(found_port) {
            break;
          }
        }
        route.output_port = empty_port;
      }

      if(!Route.try_save(route, out out_ex, out error)) {
        return false;
      }

      is_loading = true;

      routes.Add(route);
      main.route_list.Items.Add(route.name);
      
      is_loading = false;

      main.route_list.SelectedIndex = main.route_list.Items.Count - 1;

      return true;
    }

    public static void try_remove_route(Route.V1 route) {
      var result = MessageBox.Show("Are you sure you want to remove this route?\nThis cannot be undone.", TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if(result == DialogResult.Yes) {
        var path = Route.make_path_to_route(route.name);
        if(File.Exists(path)) {
          try {
            File.Delete(path);
          }
          catch(Exception ex) {
            MessageBox.Show($"Failed to remove the path at '{path}'. Exception info: {ex}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
        }
        else {
          MessageBox.Show($"The route file at '{path}' does not exist or we don't have the permissions to access it :(", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }

        try {
          is_loading = true;

          main.route_list.Items.RemoveAt(selected_route_index);
          routes.RemoveAt(selected_route_index);
          if(selected_route_index >= main.route_list.Items.Count) {
            selected_route_index = main.route_list.Items.Count - 1;
          }

          main.route_list.SelectedIndex = selected_route_index;
          is_loading = false;

          if(main.route_list.Items.Count <= 0) {
            main.configure_group_box.Hide();
          }
          else {
            populate_route_configuration();
          }
        }
        catch(Exception ex) {
          MessageBox.Show($"An error occured while removing the route: {ex}\r\n\r\nThe route file has been removed. You may need to restart the app.", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    public static void wrapped_main() {

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Console.WriteLine("test");

      main = new Main();

      if(File.Exists(Config.FILE)) {
        var new_config = Config.try_load_config(Config.FILE, out var load_ex, out var load_error);
        if(new_config == null) {
          

          if(load_ex == null) {
            MessageBox.Show($"Failed to load the VRCRouter config. Using defaults.\r\nError message: {load_error}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else {
            MessageBox.Show($"Failed to load the VRCRouter config. Using defaults.\r\nError message: {load_error}\r\n\r\nException: {load_ex}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else {
          config = new_config;
        }
      }

      if(config.config_first_launch) {
        config.config_first_launch = false;

        if(OpenVR.IsRuntimeInstalled()) {
          var result = MessageBox.Show("Do you want to set up VRCRouter to automatically start up when SteamVR starts?\r\nThis can be disabled later on.", TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

          if(result == DialogResult.Yes) {
            if(steamvr_enable_autostart()) {
              MessageBox.Show("SteamVR autostart enabled!", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }

        save_config();
      }

      {
        var files = Route.get_routes_folder_contents(out var routes_folder_err);
        if(routes_folder_err != null) {
          MessageBox.Show(routes_folder_err, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        foreach(var file in files) {

          Route.V1 route;
          while(true) {
            route = Route.try_load_route(file, out var load_ex, out var load_error);

            if(route == null) {
              DialogResult result;
              if(load_ex == null) {
                result = MessageBox.Show($"{load_error}\r\n\r\nRetry loading?", TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
              }
              else {
                result = MessageBox.Show($"{load_error}\r\n\r\nException info {load_ex}\r\n\r\nRetry loading?", TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
              }
              
              if(result != DialogResult.Retry) {
                break;
              }
            }
            else {
              break;
            }
          }

          routes.Add(route);
          var name = route.name;
          if(!route.enabled) {
            name = $"{route.name} (disabled)";
          }
          main.route_list.Items.Add(name);
        }
      }

      main.configure_group_box.Hide();
      main.osc_receive_address_input.Text = config.receive_address;
      main.osc_receive_port_input.Value = config.receive_port;
      main.wait_for_vrc_to_start.Checked = config.wait_for_vrchat;
      main.notification_label.Text = "";
      main.route_port_addr_in_use.Hide();

      // NOTE(valuef): Start this on a new thread so that the manifest moving doesn't impact startup
      // times.
      // 2023-05-15
      {
        var thread = new Thread(() => {
          try_update_steamvr_autostart_manifest();
        });
        thread.Start();
      }

      is_loading = false;
      Application.Run(main);
    }

    [STAThread]
    static void Main() {
      try {
        wrapped_main();
      }
      catch(Exception ex) {
        MessageBox.Show($"Uh oh! We've encountered an unhandled error! Please let us know about this at discord.shader.gay\r\n\r\n\r\n{ex}\r\n\r\nThe boop counter will now exit.", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Process.Start(new ProcessStartInfo() { FileName = "https://discord.shader.gay", UseShellExecute = true });
      }
    }

    public struct SteamVR_Remove_Manifest_Result {
      public enum Status {
        successfully_removed,
        was_not_installed,
        error
      };

      public Status status;
      public string error;
      public string removed_manifest_path;
    };

    public const string STEAMVR_APP_NAME = "valuefactory.lvrcoscr";
    public const string VR_MANIFEST_FILE_NAME = "manifest.vrmanifest";
    public const string TITLE = "VRCRouter Configuration";

    public static CVRSystem init_vr(EVRApplicationType type, out string out_err) {
      CVRSystem vr_system;

      var vr_err = EVRInitError.None;
      try {
        vr_system = OpenVR.Init(ref vr_err, EVRApplicationType.VRApplication_Utility);
      }
      catch(Exception ex) {
        out_err = $"SteamVR init failed due to an exception:\r\n\r\nException info: {ex}";
        return null;
      }

      if(vr_system == null) {
        var err_desc = OpenVR.GetStringForHmdError(vr_err);
        out_err = $"SteamVR init failed: {err_desc}";
        return null;
      }

      out_err = null;
      return vr_system;
    }

    public static void try_update_steamvr_autostart_manifest() {
      if(!OpenVR.IsRuntimeInstalled()) {
        return;
      }

      var vr_system = init_vr(EVRApplicationType.VRApplication_Utility, out var init_err);
      if(vr_system == null) {
        return;
      }

      using(var _ = Defer(() => OpenVR.Shutdown())) {
        var apps = OpenVR.Applications;

        var was_installed = apps.IsApplicationInstalled(STEAMVR_APP_NAME);
        var will_autolaunch = apps.GetApplicationAutoLaunch(STEAMVR_APP_NAME);

        var remove_result = steamvr_remove_manifest();
        if(remove_result.status != SteamVR_Remove_Manifest_Result.Status.successfully_removed) {
          return;
        }

        if(!apps.IsApplicationInstalled(STEAMVR_APP_NAME)) {
          var manifest_location = get_full_manifest_path();


          var did_change_path = false;
          if(!manifest_location.Equals(remove_result.removed_manifest_path)) {
            did_change_path = true;
          }

          var set_to_autolaunch = false;

          if(was_installed) {
            set_to_autolaunch = will_autolaunch;
          }
          else {
            set_to_autolaunch = true;
          }

          var err = apps.AddApplicationManifest(manifest_location, false);

          if(err != EVRApplicationError.None) {
            return;
          }

          if(did_change_path) {
            show_confirm_notif("Updated SteamVR autolaunch path");
          }

          err = apps.SetApplicationAutoLaunch(STEAMVR_APP_NAME, set_to_autolaunch);

          if(err != EVRApplicationError.None) {
            return;
          }
        }
      }
    }

    public static void change_route_enabled_status(bool enabled) {
      var route = get_edited_route();
      route.enabled = enabled;

      is_loading = true;
      if(route.enabled) {
        main.route_list.Items[selected_route_index] = route.name;
      }
      else {
        main.route_list.Items[selected_route_index] = $"{route.name} (disabled)";
      }
      is_loading = false;

      save_route(route);
    }

    public static string get_full_manifest_path() {
      var base_path = AppDomain.CurrentDomain.BaseDirectory;
      return Path.Combine(base_path, VR_MANIFEST_FILE_NAME);
    }

    public static bool steamvr_enable_autostart() {
      var has_not_been_enabled = "\n\nSteamVR autostart has not been enabled.";

      var vr_system = init_vr(EVRApplicationType.VRApplication_Utility, out var init_err);
      if(vr_system == null) {
        MessageBox.Show(init_err, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      using(var _ = Defer(() => OpenVR.Shutdown())) {
        var remove_result = steamvr_remove_manifest();
        switch(remove_result.status) {
          case SteamVR_Remove_Manifest_Result.Status.successfully_removed: break;
          case SteamVR_Remove_Manifest_Result.Status.was_not_installed: break;
          case SteamVR_Remove_Manifest_Result.Status.error: {
            MessageBox.Show(remove_result.error, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
          }
        }

        var apps = OpenVR.Applications;

        if(!apps.IsApplicationInstalled(STEAMVR_APP_NAME)) {
          var manifest_location = get_full_manifest_path();

          var err = apps.AddApplicationManifest(manifest_location, false);

          if(err != EVRApplicationError.None) {
            MessageBox.Show($"Failed to add VRCRouter manifest to SteamVR (AddApplicationManifest failed, location {manifest_location}). Error code: {err}.{has_not_been_enabled}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }

          err = apps.SetApplicationAutoLaunch(STEAMVR_APP_NAME, true);

          if(err != EVRApplicationError.None) {
            MessageBox.Show($"Failed to make the VRCRouter manifest auto-launch with SteamVR (SetApplicationAutoLaunch failed, app name: {STEAMVR_APP_NAME}). Error code: {err}.{has_not_been_enabled}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
          }
        }
        else {
          MessageBox.Show("VRCRouter was already installed!", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return true;
      }
    }

    public static bool steamvr_disable_autostart() {
      var vr_system = init_vr(EVRApplicationType.VRApplication_Utility, out var init_err);
      if(vr_system == null) {
        MessageBox.Show(init_err, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      

      using(var _ = Defer(() => OpenVR.Shutdown())) {
        var remove_result = steamvr_remove_manifest();
        switch(remove_result.status) {
          case SteamVR_Remove_Manifest_Result.Status.successfully_removed: return true;
          case SteamVR_Remove_Manifest_Result.Status.was_not_installed: return true;
          case SteamVR_Remove_Manifest_Result.Status.error: {
            MessageBox.Show($"{remove_result.error}\r\n\r\nSteamVR autostart has not been disabled.", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
          }
        }

        Debug.Assert(false);
        return false;
      }
    }

    public static void show_confirm_notif(string text) {
      text = $"[{DateTime.Now.ToShortTimeString()}] {text}";

      if(main.InvokeRequired) {
        main.Invoke(new Action(() => {
          main.notification_label.Text = text;
        }));
      }
      else {
        main.notification_label.Text = text;
      }
    }

    public static SteamVR_Remove_Manifest_Result steamvr_remove_manifest() {
      var ret = new SteamVR_Remove_Manifest_Result();
      var apps = OpenVR.Applications;

      var num_vr_apps = apps.GetApplicationCount();

      if(!apps.IsApplicationInstalled(STEAMVR_APP_NAME)) {
        ret.status = SteamVR_Remove_Manifest_Result.Status.was_not_installed;
        return ret;
      }

      var app_key_buf = new StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength * 4);

      for(var app_index = 0; app_index < num_vr_apps; app_index += 1) {
        var err = apps.GetApplicationKeyByIndex((uint)app_index, app_key_buf, (uint)app_key_buf.Capacity);

        if(err != EVRApplicationError.None) {
          ret.error = $"Call to GetApplicationKeyByIndex failed for SteamVR appplication index {app_index}";
          ret.status = SteamVR_Remove_Manifest_Result.Status.error;
          return ret;
        }

        var got_app_key = app_key_buf.ToString();
        if(got_app_key.Equals(STEAMVR_APP_NAME)) {
          // vr::VRApplicationProperty_WorkingDirectory_String
          // 22: 'valuefactory.lvor', 'C:\sync\win-projects\light-vr-osc-router'
          //
        
          var len = apps.GetApplicationPropertyString(got_app_key, EVRApplicationProperty.WorkingDirectory_String, null, 0, ref err);
          if(err != EVRApplicationError.None) {
            ret.error = $"Size call to GetApplicationPropertyString failed for SteamVR application {got_app_key}";
            ret.status = SteamVR_Remove_Manifest_Result.Status.error;
            return ret;
          }
        
          var buf = new StringBuilder((int)len);

          apps.GetApplicationPropertyString(got_app_key, EVRApplicationProperty.WorkingDirectory_String, buf, (uint)buf.Capacity, ref err);
          if(err != EVRApplicationError.None) {
            ret.error = $"Value call to GetApplicationPropertyString failed for SteamVR application {got_app_key}";
            ret.status = SteamVR_Remove_Manifest_Result.Status.error;
            return ret;
          }

          var working_dir = buf.ToString();
          var manifest_path = Path.Combine(working_dir, "manifest.vrmanifest");
          
          err = apps.RemoveApplicationManifest(manifest_path);

          if(err != EVRApplicationError.None) {
            ret.error = $"RemoveApplicationManifest failed for SteamVR application {got_app_key} with path {manifest_path}.";
            ret.status = SteamVR_Remove_Manifest_Result.Status.error;
            return ret;
          }

          ret.removed_manifest_path = manifest_path;
          ret.status = SteamVR_Remove_Manifest_Result.Status.successfully_removed;
          return ret;
        }
      }

      ret.status = SteamVR_Remove_Manifest_Result.Status.was_not_installed;
      return ret;
    }

    public static readonly char[] ILLEGAL_PATH_CHARS = new char[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };
    public static readonly string[] ILLEGAL_NAMES = new string[]{ "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

    public static bool is_valid_new_route_name(string route_name, out string err) {
      if(string.IsNullOrWhiteSpace(route_name)) {
        err = "Name cannot be empty!";
        return false;
      }

      foreach(var c in route_name) {
        foreach(var illegal_c in ILLEGAL_PATH_CHARS) {
          if(c == illegal_c) {
            err = $"Name cannot contain illegal character {illegal_c}";
            return false;
          }
        }
      }

      foreach(var illegal_name in ILLEGAL_NAMES) {
        if(route_name.Equals(illegal_name, StringComparison.InvariantCultureIgnoreCase)) {
          err = $"Name cannot be {route_name}";
          return false;
        }
      }

      {
        var files = Route.get_routes_folder_contents(out var routes_folder_err);
        if(routes_folder_err != null) {
          // NOTE(valuef): NOP
        }
        else {
          foreach(var file in files) {
            var filename = Path.GetFileNameWithoutExtension(file);
            if(route_name.Equals(filename, StringComparison.InvariantCultureIgnoreCase)) {
              err = "A route file with that name already exists!";
              return false;
            }
          }
        }
      }

      err = "";
      return true;
    }

    public static void save_config() {
      config.version = Config.LATEST_VERSION;
      try {
        var text = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(Config.FILE, text);

        show_confirm_notif("Changes saved!");
      }
      catch(Exception ex) {
        MessageBox.Show($"Failed to save config to '{Config.FILE}'.\r\n\r\nException info: {ex}", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
  }
}
