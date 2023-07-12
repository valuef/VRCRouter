using System.Text;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ValueFactoryVRCRouterCommon {


  public class Common {
    public struct Autostart_Data {
      public string full_path;
      public string args;
      public string working_dir;
    };

    public static Autostart_Data prep_autostart_data(Route.V1 route, out string error) {
      var ret = new Autostart_Data();
      ret.full_path = Path.GetFullPath(route.autostart_path);
      ret.working_dir = Path.GetDirectoryName(ret.full_path);

      ret.args = Route.format_args(route, out error);
      var module_name = Path.GetFileName(route.autostart_path);
      ret.args = $"{module_name} {ret.args}";

      return ret;
    }
  }

  public class Config {
    public const int LATEST_VERSION = 1;
    public const string FILE = "vrcrouter.json";

    public class V1 {
      public int version { get; set; } = 1;
      public string receive_address { get; set; } = "127.0.0.1";
      public int receive_port { get; set;  } = 9001;
      public bool wait_for_vrchat { get; set; } = true;
      public bool config_first_launch { get; set; } = true;
    }

    public static Config.V1 try_load_config(string path, out Exception out_ex, out string out_error) {
      string contents = null;
      try {
        contents = File.ReadAllText(path);
      }
      catch(Exception ex) {
        out_ex = ex;
        out_error = $"Failed to read the contents of the config at path '{path}'. Does the file exist and do we have permission to open it?";
        return null;
      }

      JObject root = null;
      try {
        root = JObject.Parse(contents);
      }
      catch(Exception ex) {
        out_ex = ex;
        out_error = $"Failed to parse config file contents at path '{path}'.";
        return null;
      }

      if(root == null) {
        out_error = $"Parsed the config file at '{path}' but it ended up being empty.";
        out_ex = null;
        return null;
      }

      var version = root["version"];
      if(version == null) {
        out_error = $"The config file at '{path}' does not have a 'version' property on it. It may be corrupted!";
        out_ex = null;
        return null;
      }

      bool deserialize<T>(out T config, out Exception out_out_ex, out string out_out_error) where T : class {
        config = null;
        try {
          config = root.ToObject<T>();
        }
        catch(Exception ex) {
          out_out_ex = ex;
          out_out_error = $"Failed to deserialize the config file at '{path}'.";
          return false;
        }

        if(config == null) {
          out_out_error = $"The deserialized config file at '{path}' turned out to be empty!";
          out_out_ex = null;
          return false;
        }

        out_out_error = null;
        out_out_ex = null;
        return true;
      }

      if((int?)version == 1) {
        if(deserialize<Config.V1>(out var cfg, out out_ex, out out_error)) {
          return cfg;
        }
      }

      out_error = $"The config file at '{path}' is an unsupprted version {version}. The maximum supported version right now is 1.";
      out_ex = null;
      return null;
    }
  }

  public class Route {
    public const int LATEST_VERSION = 1;
    public const string FOLDER = "routes";


    public static bool ensure_route_directory_exists(out Exception out_ex, out string error) {
      try {
        Directory.CreateDirectory(Route.FOLDER);
        out_ex = null;
        error = null;
        return true;
      }
      catch(Exception ex) {
        out_ex = ex;
        error = $"An error occured while trying to create the routes folder at '{Route.FOLDER}'";
        return false;
      }
    }

    public static string[] get_routes_folder_contents(out string err) {
      string[] files;
      try {
        if(!ensure_route_directory_exists(out var ex, out err)) {
          if(ex != null) {
            err = $"{err}\r\n\r\nException info: {ex}";
          }
          return new string[] { };
        }
        files = Directory.GetFiles(Route.FOLDER, "*.json");
      }
      catch(Exception ex) {
        err = $"Failed to get the contents of the {Route.FOLDER} folder. No autostarting or routing will be done! Exception: {ex}";
        return new string[] { };
      }

      err = null;
      return files;
    }

    public static string make_path_to_route(string name) {
      return Path.Combine(Route.FOLDER, name + ".json");
    }

    public class V1 {
      public int version { get; set; } = 1;

      [JsonIgnore]
      public string name { get; set; } = "";
      public bool enabled { get; set; } = true;

      public bool routing_enabled { get; set; } = true;

      [JsonProperty("output-address")]
      public string output_address { get; set; } = "127.0.0.1";

      [JsonProperty("output-port")]
      public int output_port { get; set; } = 9002;

      [JsonProperty("autostart-path")]
      public string autostart_path { get; set; } = "";

      [JsonProperty("autostart-args")]
      public string autostart_args { get; set; } = "";

      [JsonProperty("autoclose-executable-name")]
      public string autoclose_executable_name { get; set; } = "";
    }

    public static bool try_save(Route.V1 route, out Exception out_ex, out string error) {
      route.version = Route.LATEST_VERSION;

      var path = Route.make_path_to_route(route.name);

      try {
        var text = JsonConvert.SerializeObject(route, Formatting.Indented);

        if(!ensure_route_directory_exists(out out_ex, out error)) {
          return false;
        }
        
        File.WriteAllText(path, text);
        out_ex = null;
        error = null;
        return true;
      }
      catch(Exception e) {
        out_ex = e;
        error = $"Failed to save the route to '{path}'.";
        return false;
      }
    }

    public static string format_args(Route.V1 route, out string error) {
      // "--osc_receive={output-address}:{output-port}"
      error = null;
      
      var parsing_format = false;

      var parse_start = 0;
      var parse_length = 0;

      var sb = new StringBuilder();
      var has_parsed_formats = false;

      for(var char_index = 0; char_index < route.autostart_args.Length; char_index++) {
        var c = route.autostart_args[char_index];

        if(parsing_format) {
          if(c == '}') {
            parsing_format = false;

            var format_parsed_string = route.autostart_args.Substring(parse_start, parse_length);

            if(format_parsed_string.Equals("output-address")) {
              sb.Append(route.output_address);
              has_parsed_formats = true;
            }
            else if(format_parsed_string.Equals("output-port")) {
              sb.Append(route.output_port);
              has_parsed_formats = true;
            }
            else {
              error = $"Unknown format string {format_parsed_string}. Available format strings: {{output-address}} and {{output-port}}";
              return route.autostart_args;
            }
          }
          else {
            parse_length += 1;
          }
        }
        else {
          if(c == '{') {
            parse_start = char_index + 1;
            parse_length = 0;
            parsing_format = true;
          }
          else {
            sb.Append(c);
          }
        }
      }

      if(parsing_format) {
        error = "There is a format string that is missing a '}'!";
        return route.autostart_args;
      }

      if(has_parsed_formats) {
        return sb.ToString();
      }
      return route.autostart_args;
    }

  

    public static Route.V1 try_load_route(string path, out Exception out_ex, out string out_error) {
      string contents = null;
      try {
        contents = File.ReadAllText(path);
      }
      catch(Exception ex) {
        out_ex = ex;
        out_error = $"Failed to read the contents of the route at path '{path}'. Does the file exist and do we have permission to open it?";
        return null;
      }

      JObject root = null;
      try {
        root = JObject.Parse(contents);
      }
      catch(Exception ex) {
        out_ex = ex;
        out_error = $"Failed to load route! Failed to parse the route file's contents at path '{path}'.";
        return null;
      }

      if(root == null) {
        out_error = $"Failed to load route! Parsed the route file at '{path}' but it ended up being empty.";
        out_ex = null;
        return null;
      }

      var version = root["version"];
      if(version == null) {
        out_error = $"Failed to load route! The route file at '{path}' does not have a 'version' property on it. It may be corrupted!";
        out_ex = null;
        return null;
      }

      bool deserialize<T>(out T route, out Exception out_out_ex, out string out_out_error) where T : class {
        route = null;
        try {
          route = root.ToObject<T>();
        }
        catch(Exception ex) {
          out_out_ex = ex;
          out_out_error = $"Failed to load route! Failed to deserialize the route file at '{path}'.";
          return false;
        }

        if(route == null) {
          out_out_error = $"Failed to load route! The deserialized route file at '{path}' turned out to be empty!";
          out_out_ex = null;
          return false;
        }

        out_out_ex = null;
        out_out_error = null;
        return true;
      }

      var route_name = Path.GetFileNameWithoutExtension(path);

      if((int?)version == 1) {
        if(deserialize<Route.V1>(out var route, out out_ex, out out_error)) {
          route.name = route_name;
          return route;
        }
      }

      out_error = $"The route file at '{path}' is an unsupprted version {version}. The maximum supported version right now is 1.";
      out_ex = null;
      return null;
    }
  }
}