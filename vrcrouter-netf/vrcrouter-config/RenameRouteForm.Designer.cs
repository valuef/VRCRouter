namespace ValueFactoryVRCRouterConfig {
  partial class RenameRouteForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameRouteForm));
      this.label1 = new System.Windows.Forms.Label();
      this.old_route_name = new System.Windows.Forms.Label();
      this.new_name = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.rename_button = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Old Name:";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // old_route_name
      // 
      this.old_route_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.old_route_name.Location = new System.Drawing.Point(84, 9);
      this.old_route_name.Name = "old_route_name";
      this.old_route_name.Size = new System.Drawing.Size(235, 15);
      this.old_route_name.TabIndex = 1;
      this.old_route_name.Text = "OLD ROUTE NAME";
      this.old_route_name.Click += new System.EventHandler(this.old_route_name_Click);
      // 
      // new_name
      // 
      this.new_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.new_name.Location = new System.Drawing.Point(87, 27);
      this.new_name.Name = "new_name";
      this.new_name.Size = new System.Drawing.Size(232, 23);
      this.new_name.TabIndex = 2;
      this.new_name.TextChanged += new System.EventHandler(this.new_name_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 30);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 15);
      this.label3.TabIndex = 3;
      this.label3.Text = "New Name:";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // rename_button
      // 
      this.rename_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.rename_button.Location = new System.Drawing.Point(15, 56);
      this.rename_button.Name = "rename_button";
      this.rename_button.Size = new System.Drawing.Size(304, 23);
      this.rename_button.TabIndex = 4;
      this.rename_button.Text = "Rename";
      this.rename_button.UseVisualStyleBackColor = true;
      this.rename_button.Click += new System.EventHandler(this.rename_button_Click);
      // 
      // RenameRouteForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(331, 92);
      this.Controls.Add(this.rename_button);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.new_name);
      this.Controls.Add(this.old_route_name);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "RenameRouteForm";
      this.Text = "Rename Route";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.Label label1;
    public System.Windows.Forms.Label old_route_name;
    public System.Windows.Forms.TextBox new_name;
    public System.Windows.Forms.Label label3;
    public System.Windows.Forms.Button rename_button;
  }
}