namespace ValueFactoryVRCRouterCommon {
  public static class Build {
    #if DEBUG
      public static string build_version = "DEBUG";
      public static string build_date = "DEBUG";
    #else
      public static string build_version = "1.0.1";
      public static string build_date = "2023-07-12 09:46:51";
    #endif
  }
}