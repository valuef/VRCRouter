using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValueFactoryVRCRouterConfig {
  public partial class RenameRouteForm : Form {
    public RenameRouteForm() {
      InitializeComponent();
    }

    private void new_name_TextChanged(object sender, EventArgs e) {
      var old_name = old_route_name.Text.Trim();
      var new_name_text = new_name.Text.Trim();

      var is_empty = string.IsNullOrWhiteSpace(new_name_text);
      var is_the_same = new_name_text.Equals(old_name, StringComparison.InvariantCultureIgnoreCase);
      if (is_empty || is_the_same) {
        rename_button.Enabled = false;
      }
      else {
        rename_button.Enabled = true;
      }
    }

    private void rename_button_Click(object sender, EventArgs e) {
      var new_name_text = new_name.Text.Trim();

      if (Program.try_rename_route(new_name_text, out var ex, out var error)) {
        Program.show_confirm_notif($"Renamed '{old_route_name.Text}' to '{new_name_text}'");
        Close();
      }
      else {
        MessageBox.Show(error, Program.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    private void label3_Click(object sender, EventArgs e) {

    }

    private void old_route_name_Click(object sender, EventArgs e) {

    }

    private void label1_Click(object sender, EventArgs e) {

    }
  }
}
