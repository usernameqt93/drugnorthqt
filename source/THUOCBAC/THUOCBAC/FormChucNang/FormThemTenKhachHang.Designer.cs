namespace THUOCBAC.FormChucNang {
  partial class FormThemTenKhachHang {
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
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.comboBoxExTenKhachHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.btnXThoat = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThemTenKH = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.groupBox2);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(502, 86);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Nếu trong danh sách chưa có tên khách hàng bạn muốn chọn, nhập vào dưới đây để th" +
    "êm :";
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.comboBoxExTenKhachHang);
	  this.groupBox2.Location = new System.Drawing.Point(6, 19);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(275, 55);
	  this.groupBox2.TabIndex = 0;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Tên khách hàng";
	  // 
	  // comboBoxExTenKhachHang
	  // 
	  this.comboBoxExTenKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
	  this.comboBoxExTenKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	  this.comboBoxExTenKhachHang.DisplayMember = "Text";
	  this.comboBoxExTenKhachHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTenKhachHang.FormattingEnabled = true;
	  this.comboBoxExTenKhachHang.ItemHeight = 14;
	  this.comboBoxExTenKhachHang.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxExTenKhachHang.Name = "comboBoxExTenKhachHang";
	  this.comboBoxExTenKhachHang.Size = new System.Drawing.Size(250, 20);
	  this.comboBoxExTenKhachHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTenKhachHang.TabIndex = 0;
	  // 
	  // btnXThoat
	  // 
	  this.btnXThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.btnXThoat.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXThoat.Location = new System.Drawing.Point(284, 105);
	  this.btnXThoat.Name = "btnXThoat";
	  this.btnXThoat.Size = new System.Drawing.Size(135, 37);
	  this.btnXThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThoat.TabIndex = 1;
	  this.btnXThoat.Text = "Thoát";
	  this.btnXThoat.Click += new System.EventHandler(this.btnXThoat_Click);
	  // 
	  // btnXThemTenKH
	  // 
	  this.btnXThemTenKH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThemTenKH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThemTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.btnXThemTenKH.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXThemTenKH.Location = new System.Drawing.Point(100, 105);
	  this.btnXThemTenKH.Name = "btnXThemTenKH";
	  this.btnXThemTenKH.Size = new System.Drawing.Size(135, 37);
	  this.btnXThemTenKH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThemTenKH.TabIndex = 1;
	  this.btnXThemTenKH.Text = "Thêm";
	  this.btnXThemTenKH.Click += new System.EventHandler(this.btnXThemTenKH_Click);
	  // 
	  // FormThemTenKhachHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(527, 163);
	  this.Controls.Add(this.btnXThemTenKH);
	  this.Controls.Add(this.btnXThoat);
	  this.Controls.Add(this.groupBox1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "FormThemTenKhachHang";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Thêm tên khách hàng";
	  this.Load += new System.EventHandler(this.FormThemTenKhachHang_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenKhachHang;
	private DevComponents.DotNetBar.ButtonX btnXThoat;
	private DevComponents.DotNetBar.ButtonX btnXThemTenKH;
  }
}