namespace ValueFactoryVRCRouter {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label3 = new System.Windows.Forms.Label();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.vrcrouter_version = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.routeControl1 = new ValueFactoryVRCRouter.RouteControl();
      this.routeControl2 = new ValueFactoryVRCRouter.RouteControl();
      this.routeControl3 = new ValueFactoryVRCRouter.RouteControl();
      this.groupBox1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Size = new System.Drawing.Size(258, 47);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Status";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(157, 15);
      this.label3.TabIndex = 6;
      this.label3.Text = "Waiting for VRChat to start...";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel1.Controls.Add(this.routeControl1);
      this.flowLayoutPanel1.Controls.Add(this.routeControl2);
      this.flowLayoutPanel1.Controls.Add(this.routeControl3);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 55);
      this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(540, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(540, 236);
      this.flowLayoutPanel1.TabIndex = 3;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(278, 12);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox2.Size = new System.Drawing.Size(258, 47);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Info";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(128, 19);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(79, 15);
      this.label5.TabIndex = 7;
      this.label5.Text = "127.0.0.1:9000";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 19);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(115, 15);
      this.label4.TabIndex = 6;
      this.label4.Text = "Receiving OSC From";
      // 
      // vrcrouter_version
      // 
      this.vrcrouter_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.vrcrouter_version.AutoSize = true;
      this.vrcrouter_version.Location = new System.Drawing.Point(9, 294);
      this.vrcrouter_version.Name = "vrcrouter_version";
      this.vrcrouter_version.Size = new System.Drawing.Size(105, 15);
      this.vrcrouter_version.TabIndex = 8;
      this.vrcrouter_version.Text = "VRCRouter Version";
      // 
      // linkLabel1
      // 
      this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(467, 294);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(64, 15);
      this.linkLabel1.TabIndex = 9;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "shader.gay";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // routeControl1
      // 
      this.routeControl1.Location = new System.Drawing.Point(4, 3);
      this.routeControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.routeControl1.Name = "routeControl1";
      this.routeControl1.Size = new System.Drawing.Size(262, 78);
      this.routeControl1.TabIndex = 10;
      // 
      // routeControl2
      // 
      this.routeControl2.Location = new System.Drawing.Point(275, 3);
      this.routeControl2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
      this.routeControl2.Name = "routeControl2";
      this.routeControl2.Size = new System.Drawing.Size(255, 90);
      this.routeControl2.TabIndex = 11;
      // 
      // routeControl3
      // 
      this.routeControl3.Location = new System.Drawing.Point(6, 99);
      this.routeControl3.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
      this.routeControl3.Name = "routeControl3";
      this.routeControl3.Size = new System.Drawing.Size(260, 104);
      this.routeControl3.TabIndex = 12;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(543, 318);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.vrcrouter_version);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "VRCRouter";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label vrcrouter_version;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private RouteControl routeControl1;
    private RouteControl routeControl2;
    private RouteControl routeControl3;
  }
}

