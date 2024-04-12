using System.Runtime.InteropServices;
using System.Text;

namespace ValueFactoryVRCRouterCommon {
  public static class Native {

    [StructLayout(LayoutKind.Sequential)]
    public struct Autostart_App_Result {
      public uint id;
      public uint error;
      public bool success;
    };

    [DllImport("vrcrouter_native.dll", EntryPoint = "terminate_app", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool terminate_app(uint process_id);

    [DllImport("vrcrouter_native.dll", EntryPoint = "wait_for_vrchat_to_start", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool wait_for_vrchat_to_start();

	  [DllImport("vrcrouter_native.dll", EntryPoint = "launch_autostart_app", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    // NOTE(valuef): The underlying win32 apis that launch_autostart_app uses may modify the strings, so we pass in mutable buffers.
    // Also .NET framework seems to have an issue with returning native structs, so we pass an out argument.
    // 2023-06-26
	  public static extern void launch_autostart_app(StringBuilder path, StringBuilder args, StringBuilder working_dir, ref Autostart_App_Result ret);

    [DllImport("vrcrouter_native.dll", EntryPoint = "terminate_app_by_name", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool terminate_app_by_name([MarshalAs(UnmanagedType.LPWStr)] string name);
  }
}
