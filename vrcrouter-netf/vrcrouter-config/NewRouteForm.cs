using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueFactoryVRCRouterConfig;

namespace ValueFactoryVRCRouterConfig {
  public partial class NewRouteForm : Form {
    public NewRouteForm() {
      InitializeComponent();
    }

    private void new_route_name_TextChanged(object sender, EventArgs e) {
      if (string.IsNullOrWhiteSpace(new_route_name.Text)) {
        create_route.Enabled = false;
      }
      else {
        create_route.Enabled = true;
      }
    }

    private void create_route_Click(object sender, EventArgs e) {
      var name = new_route_name.Text;

      if (Program.try_create_new_route(name, out var ex, out var error)) {
        Program.show_confirm_notif($"Created route '{name}'");
        Close();
      }
      else {
        if(ex == null) {
          MessageBox.Show(error, Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else {
          MessageBox.Show($"{error}\r\n\r\nException info: {ex}", Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

  }
}
