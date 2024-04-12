namespace ValueFactoryVRCRouterConfig {
  partial class NewRouteForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRouteForm));
      this.label1 = new System.Windows.Forms.Label();
      this.new_route_name = new System.Windows.Forms.TextBox();
      this.create_route = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(39, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // new_route_name
      // 
      this.new_route_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.new_route_name.Location = new System.Drawing.Point(57, 12);
      this.new_route_name.Name = "new_route_name";
      this.new_route_name.Size = new System.Drawing.Size(279, 23);
      this.new_route_name.TabIndex = 1;
      this.new_route_name.TextChanged += new System.EventHandler(this.new_route_name_TextChanged);
      // 
      // create_route
      // 
      this.create_route.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.create_route.Location = new System.Drawing.Point(12, 41);
      this.create_route.Name = "create_route";
      this.create_route.Size = new System.Drawing.Size(324, 23);
      this.create_route.TabIndex = 2;
      this.create_route.Text = "Create";
      this.create_route.UseVisualStyleBackColor = true;
      this.create_route.Click += new System.EventHandler(this.create_route_Click);
      // 
      // NewRouteForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(348, 75);
      this.Controls.Add(this.create_route);
      this.Controls.Add(this.new_route_name);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "NewRouteForm";
      this.Text = "Create New Route";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox new_route_name;
    private System.Windows.Forms.Button create_route;
  }
}