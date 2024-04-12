namespace ValueFactoryVRCRouter {
  public partial class RouteControl {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label9 = new System.Windows.Forms.Label();
      this.button5 = new System.Windows.Forms.Button();
      this.groupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.label2);
      this.groupBox6.Controls.Add(this.label1);
      this.groupBox6.Controls.Add(this.pictureBox1);
      this.groupBox6.Controls.Add(this.label9);
      this.groupBox6.Controls.Add(this.button5);
      this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox6.Location = new System.Drawing.Point(0, 0);
      this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox6.Size = new System.Drawing.Size(262, 78);
      this.groupBox6.TabIndex = 5;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "VRC Face Tracking";
      this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(113, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 15);
      this.label2.TabIndex = 5;
      this.label2.Text = "127.0.0.1:9023";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Address and Port:";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(10, 21);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(28, 28);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(113, 28);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(35, 15);
      this.label9.TabIndex = 3;
      this.label9.Text = "Idle...";
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(44, 21);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(63, 28);
      this.button5.TabIndex = 0;
      this.button5.Text = "Launch";
      this.button5.UseVisualStyleBackColor = true;
      // 
      // RouteControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox6);
      this.Name = "RouteControl";
      this.Size = new System.Drawing.Size(262, 78);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button button5;
  }
}
