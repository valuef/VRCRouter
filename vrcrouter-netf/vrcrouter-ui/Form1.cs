using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ValueFactoryVRCRouterCommon;

namespace ValueFactoryVRCRouter {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      vrcrouter_version.Text = $"VRCRouter Version {Build.build_version} Date {Build.build_date}";
      flowLayoutPanel1.AutoSize = true;
      //pictureBox1.Image = Icon.ExtractAssociatedIcon("C:\\stuff\\VRCFaceTracking.exe").ToBitmap();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(new ProcessStartInfo() { FileName = "https://shader.gay", UseShellExecute = true });
    }
  }
}
