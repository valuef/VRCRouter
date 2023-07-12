namespace ValueFactoryVRCRouterConfig {
  partial class Main {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.wait_for_vrc_to_start = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.osc_receive_port_input = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.osc_receive_address_input = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.disable_start_with_steamvr = new System.Windows.Forms.Button();
      this.enable_start_with_steamvr = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.create_new_route_button = new System.Windows.Forms.Button();
      this.configure_group_box = new System.Windows.Forms.GroupBox();
      this.remove_route_button = new System.Windows.Forms.Button();
      this.groupBox8 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.route_autoclose_app_executable_name = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.rename_route = new System.Windows.Forms.Button();
      this.route_enabled = new System.Windows.Forms.CheckBox();
      this.route_name = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox7 = new System.Windows.Forms.GroupBox();
      this.route_autostart_launch = new System.Windows.Forms.Button();
      this.route_browse_autostart_path = new System.Windows.Forms.Button();
      this.route_autostart_args = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.route_autostart_path = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.route_port_addr_in_use = new System.Windows.Forms.Label();
      this.route_osc_receive_port = new System.Windows.Forms.NumericUpDown();
      this.label10 = new System.Windows.Forms.Label();
      this.route_osc_enabled = new System.Windows.Forms.CheckBox();
      this.route_osc_receive_address = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.route_list = new System.Windows.Forms.ListBox();
      this.notification_label = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.osc_receive_port_input)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.configure_group_box.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.route_osc_receive_port)).BeginInit();
      this.groupBox4.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.wait_for_vrc_to_start);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.osc_receive_port_input);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.osc_receive_address_input);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(12, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(515, 97);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "OSC Input";
      // 
      // wait_for_vrc_to_start
      // 
      this.wait_for_vrc_to_start.AutoSize = true;
      this.wait_for_vrc_to_start.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.wait_for_vrc_to_start.Location = new System.Drawing.Point(368, 77);
      this.wait_for_vrc_to_start.Name = "wait_for_vrc_to_start";
      this.wait_for_vrc_to_start.Size = new System.Drawing.Size(15, 14);
      this.wait_for_vrc_to_start.TabIndex = 6;
      this.wait_for_vrc_to_start.UseVisualStyleBackColor = true;
      this.wait_for_vrc_to_start.CheckedChanged += new System.EventHandler(this.wait_for_vrc_to_start_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(6, 76);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(356, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "Wait for VRChat to start before running autostart apps and routing";
      // 
      // osc_receive_port_input
      // 
      this.osc_receive_port_input.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.osc_receive_port_input.Location = new System.Drawing.Point(124, 48);
      this.osc_receive_port_input.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.osc_receive_port_input.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
      this.osc_receive_port_input.Name = "osc_receive_port_input";
      this.osc_receive_port_input.Size = new System.Drawing.Size(385, 23);
      this.osc_receive_port_input.TabIndex = 4;
      this.osc_receive_port_input.Value = new decimal(new int[] {
            1025,
            0,
            0,
            0});
      this.osc_receive_port_input.ValueChanged += new System.EventHandler(this.osc_receive_port_input_ValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(6, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "Receive Port";
      // 
      // osc_receive_address_input
      // 
      this.osc_receive_address_input.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.osc_receive_address_input.Location = new System.Drawing.Point(124, 19);
      this.osc_receive_address_input.Name = "osc_receive_address_input";
      this.osc_receive_address_input.Size = new System.Drawing.Size(385, 23);
      this.osc_receive_address_input.TabIndex = 1;
      this.osc_receive_address_input.TextChanged += new System.EventHandler(this.osc_receive_address_input_TextChanged);
      this.osc_receive_address_input.Validating += new System.ComponentModel.CancelEventHandler(this.osc_receive_address_input_Validating);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Receive Address";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.disable_start_with_steamvr);
      this.groupBox2.Controls.Add(this.enable_start_with_steamvr);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(533, 27);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(180, 79);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "SteamVR";
      // 
      // disable_start_with_steamvr
      // 
      this.disable_start_with_steamvr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.disable_start_with_steamvr.Location = new System.Drawing.Point(6, 48);
      this.disable_start_with_steamvr.Name = "disable_start_with_steamvr";
      this.disable_start_with_steamvr.Size = new System.Drawing.Size(168, 23);
      this.disable_start_with_steamvr.TabIndex = 1;
      this.disable_start_with_steamvr.Text = "Disable Start with SteamVR";
      this.disable_start_with_steamvr.UseVisualStyleBackColor = true;
      this.disable_start_with_steamvr.Click += new System.EventHandler(this.disable_start_with_steamvr_Click);
      // 
      // enable_start_with_steamvr
      // 
      this.enable_start_with_steamvr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.enable_start_with_steamvr.Location = new System.Drawing.Point(6, 19);
      this.enable_start_with_steamvr.Name = "enable_start_with_steamvr";
      this.enable_start_with_steamvr.Size = new System.Drawing.Size(168, 23);
      this.enable_start_with_steamvr.TabIndex = 0;
      this.enable_start_with_steamvr.Text = "Enable Start with SteamVR";
      this.enable_start_with_steamvr.UseVisualStyleBackColor = true;
      this.enable_start_with_steamvr.Click += new System.EventHandler(this.enable_start_with_steamvr_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.create_new_route_button);
      this.groupBox3.Controls.Add(this.configure_group_box);
      this.groupBox3.Controls.Add(this.groupBox4);
      this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox3.Location = new System.Drawing.Point(12, 130);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(701, 460);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "OSC Output / Autostart / Autoclose";
      // 
      // create_new_route_button
      // 
      this.create_new_route_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.create_new_route_button.Location = new System.Drawing.Point(12, 431);
      this.create_new_route_button.Name = "create_new_route_button";
      this.create_new_route_button.Size = new System.Drawing.Size(214, 23);
      this.create_new_route_button.TabIndex = 2;
      this.create_new_route_button.Text = "New Route";
      this.create_new_route_button.UseVisualStyleBackColor = true;
      this.create_new_route_button.Click += new System.EventHandler(this.create_new_route_button_Click);
      // 
      // configure_group_box
      // 
      this.configure_group_box.Controls.Add(this.remove_route_button);
      this.configure_group_box.Controls.Add(this.groupBox8);
      this.configure_group_box.Controls.Add(this.rename_route);
      this.configure_group_box.Controls.Add(this.route_enabled);
      this.configure_group_box.Controls.Add(this.route_name);
      this.configure_group_box.Controls.Add(this.label8);
      this.configure_group_box.Controls.Add(this.label6);
      this.configure_group_box.Controls.Add(this.groupBox7);
      this.configure_group_box.Controls.Add(this.groupBox6);
      this.configure_group_box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.configure_group_box.Location = new System.Drawing.Point(232, 19);
      this.configure_group_box.Name = "configure_group_box";
      this.configure_group_box.Size = new System.Drawing.Size(463, 441);
      this.configure_group_box.TabIndex = 1;
      this.configure_group_box.TabStop = false;
      this.configure_group_box.Text = "Route Configuration";
      this.configure_group_box.Enter += new System.EventHandler(this.groupBox5_Enter);
      // 
      // remove_route_button
      // 
      this.remove_route_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.remove_route_button.Location = new System.Drawing.Point(6, 412);
      this.remove_route_button.Name = "remove_route_button";
      this.remove_route_button.Size = new System.Drawing.Size(451, 23);
      this.remove_route_button.TabIndex = 20;
      this.remove_route_button.Text = "Remove Route";
      this.remove_route_button.UseVisualStyleBackColor = true;
      this.remove_route_button.Click += new System.EventHandler(this.remove_route_button_Click);
      // 
      // groupBox8
      // 
      this.groupBox8.Controls.Add(this.button2);
      this.groupBox8.Controls.Add(this.button1);
      this.groupBox8.Controls.Add(this.route_autoclose_app_executable_name);
      this.groupBox8.Controls.Add(this.label15);
      this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox8.Location = new System.Drawing.Point(6, 326);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new System.Drawing.Size(451, 80);
      this.groupBox8.TabIndex = 2;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Autoclose App (for manual closing of apps on exit)";
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(426, 21);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(19, 23);
      this.button2.TabIndex = 18;
      this.button2.Text = "?";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(120, 51);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(325, 23);
      this.button1.TabIndex = 18;
      this.button1.Text = "Test Close";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // route_autoclose_app_executable_name
      // 
      this.route_autoclose_app_executable_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_autoclose_app_executable_name.Location = new System.Drawing.Point(123, 22);
      this.route_autoclose_app_executable_name.Name = "route_autoclose_app_executable_name";
      this.route_autoclose_app_executable_name.Size = new System.Drawing.Size(297, 23);
      this.route_autoclose_app_executable_name.TabIndex = 19;
      this.route_autoclose_app_executable_name.TextChanged += new System.EventHandler(this.route_autoclose_app_executable_name_TextChanged);
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(11, 25);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(99, 15);
      this.label15.TabIndex = 18;
      this.label15.Text = "Executable Name";
      // 
      // rename_route
      // 
      this.rename_route.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.rename_route.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.rename_route.Location = new System.Drawing.Point(382, 20);
      this.rename_route.Name = "rename_route";
      this.rename_route.Size = new System.Drawing.Size(75, 23);
      this.rename_route.TabIndex = 9;
      this.rename_route.Text = "Rename";
      this.rename_route.UseVisualStyleBackColor = true;
      this.rename_route.Click += new System.EventHandler(this.rename_route_Click);
      // 
      // route_enabled
      // 
      this.route_enabled.AutoSize = true;
      this.route_enabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_enabled.Location = new System.Drawing.Point(129, 43);
      this.route_enabled.Name = "route_enabled";
      this.route_enabled.Size = new System.Drawing.Size(15, 14);
      this.route_enabled.TabIndex = 8;
      this.route_enabled.UseVisualStyleBackColor = true;
      this.route_enabled.CheckedChanged += new System.EventHandler(this.route_enabled_CheckedChanged);
      // 
      // route_name
      // 
      this.route_name.AutoSize = true;
      this.route_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_name.Location = new System.Drawing.Point(126, 26);
      this.route_name.Name = "route_name";
      this.route_name.Size = new System.Drawing.Size(81, 15);
      this.route_name.TabIndex = 3;
      this.route_name.Text = "Boop Counter";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(6, 43);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(49, 15);
      this.label8.TabIndex = 7;
      this.label8.Text = "Enabled";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(6, 26);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(39, 15);
      this.label6.TabIndex = 2;
      this.label6.Text = "Name";
      // 
      // groupBox7
      // 
      this.groupBox7.Controls.Add(this.route_autostart_launch);
      this.groupBox7.Controls.Add(this.route_browse_autostart_path);
      this.groupBox7.Controls.Add(this.route_autostart_args);
      this.groupBox7.Controls.Add(this.label14);
      this.groupBox7.Controls.Add(this.route_autostart_path);
      this.groupBox7.Controls.Add(this.label13);
      this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox7.Location = new System.Drawing.Point(9, 208);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(448, 111);
      this.groupBox7.TabIndex = 1;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Autostart App (starts on launch, closes automatically on exit)";
      // 
      // route_autostart_launch
      // 
      this.route_autostart_launch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_autostart_launch.Location = new System.Drawing.Point(120, 80);
      this.route_autostart_launch.Name = "route_autostart_launch";
      this.route_autostart_launch.Size = new System.Drawing.Size(322, 23);
      this.route_autostart_launch.TabIndex = 17;
      this.route_autostart_launch.Text = "Launch";
      this.route_autostart_launch.UseVisualStyleBackColor = true;
      this.route_autostart_launch.Click += new System.EventHandler(this.route_autostart_launch_Click);
      // 
      // route_browse_autostart_path
      // 
      this.route_browse_autostart_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.route_browse_autostart_path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_browse_autostart_path.Location = new System.Drawing.Point(367, 21);
      this.route_browse_autostart_path.Name = "route_browse_autostart_path";
      this.route_browse_autostart_path.Size = new System.Drawing.Size(75, 23);
      this.route_browse_autostart_path.TabIndex = 10;
      this.route_browse_autostart_path.Text = "Browse";
      this.route_browse_autostart_path.UseVisualStyleBackColor = true;
      this.route_browse_autostart_path.Click += new System.EventHandler(this.route_browse_autostart_path_Click);
      // 
      // route_autostart_args
      // 
      this.route_autostart_args.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_autostart_args.Location = new System.Drawing.Point(120, 51);
      this.route_autostart_args.Name = "route_autostart_args";
      this.route_autostart_args.Size = new System.Drawing.Size(322, 23);
      this.route_autostart_args.TabIndex = 16;
      this.route_autostart_args.TextChanged += new System.EventHandler(this.route_autostart_args_TextChanged);
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(6, 54);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(108, 15);
      this.label14.TabIndex = 15;
      this.label14.Text = "Launch Arguments";
      // 
      // route_autostart_path
      // 
      this.route_autostart_path.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_autostart_path.Location = new System.Drawing.Point(120, 22);
      this.route_autostart_path.Name = "route_autostart_path";
      this.route_autostart_path.Size = new System.Drawing.Size(241, 23);
      this.route_autostart_path.TabIndex = 14;
      this.route_autostart_path.TextChanged += new System.EventHandler(this.route_autostart_path_TextChanged);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(6, 25);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(91, 15);
      this.label13.TabIndex = 13;
      this.label13.Text = "Executable Path";
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.route_port_addr_in_use);
      this.groupBox6.Controls.Add(this.route_osc_receive_port);
      this.groupBox6.Controls.Add(this.label10);
      this.groupBox6.Controls.Add(this.route_osc_enabled);
      this.groupBox6.Controls.Add(this.route_osc_receive_address);
      this.groupBox6.Controls.Add(this.label9);
      this.groupBox6.Controls.Add(this.label11);
      this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox6.Location = new System.Drawing.Point(9, 64);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(448, 138);
      this.groupBox6.TabIndex = 0;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "OSC";
      // 
      // route_port_addr_in_use
      // 
      this.route_port_addr_in_use.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_port_addr_in_use.ForeColor = System.Drawing.Color.DarkRed;
      this.route_port_addr_in_use.Location = new System.Drawing.Point(6, 97);
      this.route_port_addr_in_use.Name = "route_port_addr_in_use";
      this.route_port_addr_in_use.Size = new System.Drawing.Size(436, 35);
      this.route_port_addr_in_use.TabIndex = 12;
      this.route_port_addr_in_use.Text = "This address and port is already in use by route \'Boop Boop\' Please change the po" +
    "rt or address or else these programs may not work.";
      // 
      // route_osc_receive_port
      // 
      this.route_osc_receive_port.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_osc_receive_port.Location = new System.Drawing.Point(120, 71);
      this.route_osc_receive_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.route_osc_receive_port.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
      this.route_osc_receive_port.Name = "route_osc_receive_port";
      this.route_osc_receive_port.Size = new System.Drawing.Size(322, 23);
      this.route_osc_receive_port.TabIndex = 10;
      this.route_osc_receive_port.Value = new decimal(new int[] {
            1025,
            0,
            0,
            0});
      this.route_osc_receive_port.ValueChanged += new System.EventHandler(this.route_osc_receive_port_ValueChanged);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(6, 73);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(70, 15);
      this.label10.TabIndex = 9;
      this.label10.Text = "Output Port";
      // 
      // route_osc_enabled
      // 
      this.route_osc_enabled.AutoSize = true;
      this.route_osc_enabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_osc_enabled.Location = new System.Drawing.Point(120, 22);
      this.route_osc_enabled.Name = "route_osc_enabled";
      this.route_osc_enabled.Size = new System.Drawing.Size(15, 14);
      this.route_osc_enabled.TabIndex = 11;
      this.route_osc_enabled.UseVisualStyleBackColor = true;
      this.route_osc_enabled.CheckedChanged += new System.EventHandler(this.route_osc_enabled_CheckedChanged);
      // 
      // route_osc_receive_address
      // 
      this.route_osc_receive_address.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_osc_receive_address.Location = new System.Drawing.Point(120, 42);
      this.route_osc_receive_address.Name = "route_osc_receive_address";
      this.route_osc_receive_address.Size = new System.Drawing.Size(322, 23);
      this.route_osc_receive_address.TabIndex = 8;
      this.route_osc_receive_address.TextChanged += new System.EventHandler(this.route_osc_receive_address_TextChanged);
      this.route_osc_receive_address.Validating += new System.ComponentModel.CancelEventHandler(this.route_osc_receive_address_Validating);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(6, 22);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(93, 15);
      this.label9.TabIndex = 10;
      this.label9.Text = "Do OSC Routing";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(6, 45);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(90, 15);
      this.label11.TabIndex = 7;
      this.label11.Text = "Output Address";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.route_list);
      this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox4.Location = new System.Drawing.Point(9, 19);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(217, 406);
      this.groupBox4.TabIndex = 0;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Routes";
      // 
      // route_list
      // 
      this.route_list.Dock = System.Windows.Forms.DockStyle.Fill;
      this.route_list.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.route_list.FormattingEnabled = true;
      this.route_list.ItemHeight = 15;
      this.route_list.Location = new System.Drawing.Point(3, 19);
      this.route_list.Name = "route_list";
      this.route_list.Size = new System.Drawing.Size(211, 384);
      this.route_list.TabIndex = 0;
      this.route_list.SelectedIndexChanged += new System.EventHandler(this.route_list_SelectedIndexChanged);
      // 
      // notification_label
      // 
      this.notification_label.AutoSize = true;
      this.notification_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.notification_label.ForeColor = System.Drawing.Color.DarkGreen;
      this.notification_label.Location = new System.Drawing.Point(9, 593);
      this.notification_label.Name = "notification_label";
      this.notification_label.Size = new System.Drawing.Size(61, 15);
      this.notification_label.TabIndex = 4;
      this.notification_label.Text = "asdasdasd";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(443, 593);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(270, 15);
      this.label5.TabIndex = 5;
      this.label5.Text = "VRCRouter must be restarted for changes to apply";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(719, 24);
      this.menuStrip1.TabIndex = 6;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(719, 615);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.notification_label);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "Main";
      this.Text = "VRCRouter Configuration";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.osc_receive_port_input)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.configure_group_box.ResumeLayout(false);
      this.configure_group_box.PerformLayout();
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.route_osc_receive_port)).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.GroupBox groupBox1;
    public System.Windows.Forms.Label label1;
    public System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox osc_receive_address_input;
    public System.Windows.Forms.NumericUpDown osc_receive_port_input;
    public System.Windows.Forms.Label label3;
    public System.Windows.Forms.CheckBox wait_for_vrc_to_start;
    public System.Windows.Forms.GroupBox groupBox2;
    public System.Windows.Forms.GroupBox groupBox3;
    public System.Windows.Forms.Button enable_start_with_steamvr;
    public System.Windows.Forms.Button disable_start_with_steamvr;
    public System.Windows.Forms.Label notification_label;
    public System.Windows.Forms.Label label5;
    public System.Windows.Forms.GroupBox groupBox4;
    public System.Windows.Forms.Button create_new_route_button;
    public System.Windows.Forms.GroupBox configure_group_box;
    public System.Windows.Forms.ListBox route_list;
    public System.Windows.Forms.GroupBox groupBox7;
    public System.Windows.Forms.GroupBox groupBox8;
    public System.Windows.Forms.GroupBox groupBox6;
    public System.Windows.Forms.CheckBox route_enabled;
    public System.Windows.Forms.Label route_name;
    public System.Windows.Forms.Label label8;
    public System.Windows.Forms.Label label6;
    public System.Windows.Forms.Button rename_route;
    public System.Windows.Forms.NumericUpDown route_osc_receive_port;
    public System.Windows.Forms.Label label10;
    public System.Windows.Forms.CheckBox route_osc_enabled;
    public System.Windows.Forms.TextBox route_osc_receive_address;
    public System.Windows.Forms.Label label9;
    public System.Windows.Forms.Label label11;
    public System.Windows.Forms.Label route_port_addr_in_use;
    public System.Windows.Forms.Button route_browse_autostart_path;
    public System.Windows.Forms.TextBox route_autostart_args;
    public System.Windows.Forms.Label label14;
    public System.Windows.Forms.TextBox route_autostart_path;
    public System.Windows.Forms.Label label13;
    public System.Windows.Forms.Button remove_route_button;
    public System.Windows.Forms.Button button2;
    public System.Windows.Forms.Button button1;
    public System.Windows.Forms.TextBox route_autoclose_app_executable_name;
    public System.Windows.Forms.Label label15;
    public System.Windows.Forms.Button route_autostart_launch;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
  }
}