namespace THUOCBAC {
  partial class FormChinh {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components=null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
	  if(disposing&&(components!=null)) {
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
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.buttonXDSDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.buttonXDSViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.tabControlChinh = new System.Windows.Forms.TabControl();
	  this.tabPage1 = new System.Windows.Forms.TabPage();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.tabControlChinh.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.buttonXDSDonHang);
	  this.groupBox1.Controls.Add(this.buttonXDSViThuoc);
	  this.groupBox1.Location = new System.Drawing.Point(13, 13);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(178, 656);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Danh sách menu";
	  // 
	  // buttonXDSDonHang
	  // 
	  this.buttonXDSDonHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonXDSDonHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonXDSDonHang.Location = new System.Drawing.Point(7, 49);
	  this.buttonXDSDonHang.Name = "buttonXDSDonHang";
	  this.buttonXDSDonHang.Size = new System.Drawing.Size(165, 23);
	  this.buttonXDSDonHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonXDSDonHang.TabIndex = 0;
	  this.buttonXDSDonHang.Text = "Danh sách các đơn hàng";
	  this.buttonXDSDonHang.Click += new System.EventHandler(this.buttonXDSDonHang_Click);
	  // 
	  // buttonXDSViThuoc
	  // 
	  this.buttonXDSViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonXDSViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonXDSViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.buttonXDSViThuoc.Name = "buttonXDSViThuoc";
	  this.buttonXDSViThuoc.Size = new System.Drawing.Size(165, 23);
	  this.buttonXDSViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonXDSViThuoc.TabIndex = 0;
	  this.buttonXDSViThuoc.Text = "Danh sách các vị thuốc";
	  this.buttonXDSViThuoc.Click += new System.EventHandler(this.buttonXDSViThuoc_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.tabControlChinh);
	  this.groupBox2.Location = new System.Drawing.Point(197, 13);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(1132, 656);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Thông tin";
	  // 
	  // tabControlChinh
	  // 
	  this.tabControlChinh.Controls.Add(this.tabPage1);
	  this.tabControlChinh.Location = new System.Drawing.Point(7, 20);
	  this.tabControlChinh.Name = "tabControlChinh";
	  this.tabControlChinh.SelectedIndex = 0;
	  this.tabControlChinh.Size = new System.Drawing.Size(1119, 630);
	  this.tabControlChinh.TabIndex = 0;
	  // 
	  // tabPage1
	  // 
	  this.tabPage1.Location = new System.Drawing.Point(4, 22);
	  this.tabPage1.Name = "tabPage1";
	  this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
	  this.tabPage1.Size = new System.Drawing.Size(1111, 604);
	  this.tabPage1.TabIndex = 0;
	  this.tabPage1.Text = "Giới thiệu";
	  this.tabPage1.UseVisualStyleBackColor = true;
	  // 
	  // FormChinh
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1341, 681);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "FormChinh";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "FormChinh";
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.tabControlChinh.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.ButtonX buttonXDSViThuoc;
	private DevComponents.DotNetBar.ButtonX buttonXDSDonHang;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.TabControl tabControlChinh;
	private System.Windows.Forms.TabPage tabPage1;
  }
}