using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueFactoryVRCRouterCommon;

namespace ValueFactoryVRCRouterConfig {
  public partial class About : Form {
    public About() {
      InitializeComponent();
    }

    private void About_Load(object sender, EventArgs e) {
      version.Text = $"Version {Build.build_version}";
      built.Text = $"Built {Build.build_date}";
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(new ProcessStartInfo() { FileName = "https://shader.gay", UseShellExecute = true });
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(new ProcessStartInfo() { FileName = "https://github.com/valuef/VRCRouter", UseShellExecute = true });
    }
  }
}
