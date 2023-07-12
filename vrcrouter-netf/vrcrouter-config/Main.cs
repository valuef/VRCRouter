using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using ValueFactoryVRCRouterCommon;
using ValueFactoryVRCRouterConfig;

namespace ValueFactoryVRCRouterConfig {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
    }

    private void groupBox5_Enter(object sender, EventArgs e) {

    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    
    private void enable_start_with_steamvr_Click(object sender, EventArgs e) {
      if (Program.steamvr_enable_autostart()) {
        MessageBox.Show("VRCRouter will now start with SteamVR!", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void disable_start_with_steamvr_Click(object sender, EventArgs e) {
      if (Program.steamvr_disable_autostart()) {
        MessageBox.Show("VRCRouter will no longer start with SteamVR.", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void wait_for_vrc_to_start_CheckedChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      Program.config.wait_for_vrchat = wait_for_vrc_to_start.Checked;
      Program.save_config();
    }

    private void osc_receive_port_input_ValueChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      Program.config.receive_port = (int)osc_receive_port_input.Value;
      Program.save_config();
    }

    private void Main_FormClosed(object sender, FormClosedEventArgs e) {
      Program.save_config();
    }

    public static void validate_address(TextBox textbox, CancelEventArgs e) {
      var is_valid = IPAddress.TryParse(textbox.Text, out var _);
      if (is_valid) {
        return;
      }

      e.Cancel = true;
      textbox.SelectAll();

      MessageBox.Show($"'{textbox.Text}' is not a valid IP Address!", "Boop Counter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    private void osc_receive_address_input_Validating(object sender, CancelEventArgs e) {
      if (Program.is_loading) return;

      validate_address((TextBox)sender, e);
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      ValidateChildren();
    }

    private void osc_receive_address_input_TextChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      Program.config.receive_address = osc_receive_address_input.Text.Trim();
      Program.save_config();

    }

    private void route_list_SelectedIndexChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;
      if (route_list.SelectedIndex < 0) return;

      Program.selected_route_index = route_list.SelectedIndex;
      configure_group_box.Show();
      Program.populate_route_configuration();

      check_for_duplicate_port_addr();
    }

    private void route_enabled_CheckedChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      Program.change_route_enabled_status(route_enabled.Checked);

    }

    private void route_osc_receive_address_Validating(object sender, CancelEventArgs e) {
      if (Program.is_loading) return;
      if (Program.selected_route_index < 0) return;

      var textbox = (TextBox)sender;
      validate_address(textbox, e);
    }
    public void check_for_duplicate_port_addr() {
      var addr = route_osc_receive_address.Text.Trim();
      var port = (int)route_osc_receive_port.Value;
      var current_route = Program.get_edited_route();

      if(current_route.output_port == 9000) {
        route_port_addr_in_use.Show();
        route_port_addr_in_use.Text = $"Port 9000 is the default port that VRChat uses to receive data. Please don't use this port unless you've overriden the VRChat default port!";
        return;
      }
      else if(current_route.output_port == 9001) {
        route_port_addr_in_use.Show();
        route_port_addr_in_use.Text = $"Port 9001 is the default port that VRChat uses to send data. Please don't use this port unless you've overriden the VRChat default port!";
        return;
      }

      foreach (var route in Program.routes) {
        if (route == current_route) continue;

        var addr_match = route.output_address.Equals(addr, StringComparison.InvariantCultureIgnoreCase);
        var port_match = route.output_port == port;

        if (addr_match && port_match && route.enabled) {
          route_port_addr_in_use.Show();
          route_port_addr_in_use.Text = $"This address and port is already in use by route \"{route.name}\" Please change the port or address or else these routes may not work properly!";
          return;
        }
      }

      route_port_addr_in_use.Hide();
    }

    private void route_osc_receive_address_TextChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.output_address = route_osc_receive_address.Text;
      Program.save_route(route);

      check_for_duplicate_port_addr();
    }

    private void route_osc_receive_port_ValueChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.output_port = (int)route_osc_receive_port.Value;
      Program.save_route(route);

      check_for_duplicate_port_addr();
    }

    private void route_autostart_path_TextChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.autostart_path = route_autostart_path.Text;
      Program.save_route(route);
    }

    private void route_autostart_args_TextChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.autostart_args = route_autostart_args.Text;
      Program.save_route(route);
    }

    OpenFileDialog ofd = new OpenFileDialog();

    private void route_browse_autostart_path_Click(object sender, EventArgs e) {
      var result = ofd.ShowDialog();
      if (result == DialogResult.OK) {
        var file = ofd.FileName;
        var base_path = AppDomain.CurrentDomain.BaseDirectory;

        if (file.StartsWith(base_path, StringComparison.InvariantCultureIgnoreCase)) {
          file = file.Substring(base_path.Length);
        }

        var route = Program.get_edited_route();
        route.autostart_path = file;
        route_autostart_path.Text = file;

        Program.save_route(route);
      }
    }

    private void route_autostart_launch_Click(object sender, EventArgs e) {
      Program.launch_autostart_app(Program.get_edited_route());
    }

    private void remove_route_button_Click(object sender, EventArgs e) {
      Program.try_remove_route(Program.get_edited_route());
    }

    public NewRouteForm new_route_form = new NewRouteForm();

    private void create_new_route_button_Click(object sender, EventArgs e) {
      new_route_form.ShowDialog();
    }

    RenameRouteForm rename_route_form = new RenameRouteForm();

    private void rename_route_Click(object sender, EventArgs e) {
      var route = Program.get_edited_route();

      rename_route_form.old_route_name.Text = route.name;
      rename_route_form.new_name.Text = route.name;

      rename_route_form.ShowDialog();
    }

    private void route_autoclose_app_executable_name_TextChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.autoclose_executable_name = route_autoclose_app_executable_name.Text.Trim();

      Program.save_route(route);
    }

    private void button1_Click(object sender, EventArgs e) {

      var route = Program.get_edited_route();

      var exe_name = route.autoclose_executable_name;
      var result = Native.terminate_app_by_name(exe_name);
      if (result) {
        MessageBox.Show($"Closed '{exe_name}'!", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else {
        MessageBox.Show($"Failed to close '{exe_name}'. Is the program running?", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    private void button2_Click(object sender, EventArgs e) {
      MessageBox.Show("This should just be the executable name (including the .exe) of the app you want to close.\r\n\r\nFor example, if I want to close VRCFaceTracking, I'd put VRCFaceTracking.exe into this field.", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void route_osc_enabled_CheckedChanged(object sender, EventArgs e) {
      if (Program.is_loading) return;

      var route = Program.get_edited_route();
      route.routing_enabled = route_osc_enabled.Checked;

      Program.save_route(route);
      Program.populate_route_configuration();
    }

    About about;

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      if(about == null) {
        about = new About();
      }
      about.ShowDialog();
    }
  }
}
