namespace THUOCBAC.FormChucNang {
  partial class FormXemGiaThuoc {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.groupBoxTimTheoTenChinhXac = new System.Windows.Forms.GroupBox();
	  this.groupBox5 = new System.Windows.Forms.GroupBox();
	  this.comboBoxExTenViThuoc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.btnXHienThi = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXLichSuGDVT = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.btnXXemChiTietDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.btnXHienThiTheoTenKH = new DevComponents.DotNetBar.ButtonX();
	  this.groupBoxTenVTTheoTenKH = new System.Windows.Forms.GroupBox();
	  this.comboBoxExTenVTCuaKH = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.comboBoxExTenKhachHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.btnXTimTheoKiTu = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox7 = new System.Windows.Forms.GroupBox();
	  this.txtXKiTuCanTim = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.groupBoxTimTheoTenChinhXac.SuspendLayout();
	  this.groupBox5.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuGDVT)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBoxTenVTTheoTenKH.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  this.groupBox6.SuspendLayout();
	  this.groupBox7.SuspendLayout();
	  this.panelEx1.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBoxTimTheoTenChinhXac
	  // 
	  this.groupBoxTimTheoTenChinhXac.Controls.Add(this.groupBox5);
	  this.groupBoxTimTheoTenChinhXac.Controls.Add(this.btnXHienThi);
	  this.groupBoxTimTheoTenChinhXac.Location = new System.Drawing.Point(569, 12);
	  this.groupBoxTimTheoTenChinhXac.Name = "groupBoxTimTheoTenChinhXac";
	  this.groupBoxTimTheoTenChinhXac.Size = new System.Drawing.Size(357, 81);
	  this.groupBoxTimTheoTenChinhXac.TabIndex = 0;
	  this.groupBoxTimTheoTenChinhXac.TabStop = false;
	  this.groupBoxTimTheoTenChinhXac.Text = "Xem vị thuốc B đang có ở những đơn hàng nào ?";
	  // 
	  // groupBox5
	  // 
	  this.groupBox5.Controls.Add(this.comboBoxExTenViThuoc);
	  this.groupBox5.Location = new System.Drawing.Point(6, 20);
	  this.groupBox5.Name = "groupBox5";
	  this.groupBox5.Size = new System.Drawing.Size(200, 52);
	  this.groupBox5.TabIndex = 2;
	  this.groupBox5.TabStop = false;
	  this.groupBox5.Text = "Tên vị thuốc";
	  // 
	  // comboBoxExTenViThuoc
	  // 
	  this.comboBoxExTenViThuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
	  this.comboBoxExTenViThuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	  this.comboBoxExTenViThuoc.DisplayMember = "Text";
	  this.comboBoxExTenViThuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTenViThuoc.FormattingEnabled = true;
	  this.comboBoxExTenViThuoc.ItemHeight = 14;
	  this.comboBoxExTenViThuoc.Location = new System.Drawing.Point(6, 19);
	  this.comboBoxExTenViThuoc.Name = "comboBoxExTenViThuoc";
	  this.comboBoxExTenViThuoc.Size = new System.Drawing.Size(188, 20);
	  this.comboBoxExTenViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTenViThuoc.TabIndex = 0;
	  // 
	  // btnXHienThi
	  // 
	  this.btnXHienThi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXHienThi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXHienThi.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXHienThi.Location = new System.Drawing.Point(212, 20);
	  this.btnXHienThi.Name = "btnXHienThi";
	  this.btnXHienThi.Size = new System.Drawing.Size(136, 52);
	  this.btnXHienThi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXHienThi.TabIndex = 1;
	  this.btnXHienThi.Text = "Hiển thị danh sách";
	  this.btnXHienThi.Click += new System.EventHandler(this.btnXHienThi_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.dataGridViewXLichSuGDVT);
	  this.groupBox2.Location = new System.Drawing.Point(13, 99);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(1316, 512);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Danh sách";
	  // 
	  // dataGridViewXLichSuGDVT
	  // 
	  this.dataGridViewXLichSuGDVT.AllowUserToAddRows = false;
	  this.dataGridViewXLichSuGDVT.AllowUserToDeleteRows = false;
	  this.dataGridViewXLichSuGDVT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXLichSuGDVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXLichSuGDVT.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXLichSuGDVT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXLichSuGDVT.Location = new System.Drawing.Point(7, 20);
	  this.dataGridViewXLichSuGDVT.Name = "dataGridViewXLichSuGDVT";
	  this.dataGridViewXLichSuGDVT.ReadOnly = true;
	  this.dataGridViewXLichSuGDVT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXLichSuGDVT.Size = new System.Drawing.Size(1303, 486);
	  this.dataGridViewXLichSuGDVT.TabIndex = 0;
	  this.dataGridViewXLichSuGDVT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXLichSuGDVT_CellClick);
	  // 
	  // btnXXemChiTietDonHang
	  // 
	  this.btnXXemChiTietDonHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemChiTietDonHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemChiTietDonHang.Enabled = false;
	  this.btnXXemChiTietDonHang.Image = global::THUOCBAC.Properties.Resources._goto;
	  this.btnXXemChiTietDonHang.Location = new System.Drawing.Point(547, 617);
	  this.btnXXemChiTietDonHang.Name = "btnXXemChiTietDonHang";
	  this.btnXXemChiTietDonHang.Size = new System.Drawing.Size(247, 44);
	  this.btnXXemChiTietDonHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemChiTietDonHang.TabIndex = 2;
	  this.btnXXemChiTietDonHang.Text = "Xem chi tiết đơn hàng";
	  this.btnXXemChiTietDonHang.Click += new System.EventHandler(this.btnXXemChiTietDonHang_Click);
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.btnXHienThiTheoTenKH);
	  this.groupBox3.Controls.Add(this.groupBoxTenVTTheoTenKH);
	  this.groupBox3.Controls.Add(this.groupBox4);
	  this.groupBox3.Location = new System.Drawing.Point(13, 12);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(550, 81);
	  this.groupBox3.TabIndex = 3;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Xem người A mua vị thuốc B những lần nào ?";
	  // 
	  // btnXHienThiTheoTenKH
	  // 
	  this.btnXHienThiTheoTenKH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXHienThiTheoTenKH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXHienThiTheoTenKH.Enabled = false;
	  this.btnXHienThiTheoTenKH.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXHienThiTheoTenKH.Location = new System.Drawing.Point(402, 20);
	  this.btnXHienThiTheoTenKH.Name = "btnXHienThiTheoTenKH";
	  this.btnXHienThiTheoTenKH.Size = new System.Drawing.Size(136, 52);
	  this.btnXHienThiTheoTenKH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXHienThiTheoTenKH.TabIndex = 2;
	  this.btnXHienThiTheoTenKH.Text = "Hiển thị danh sách";
	  this.btnXHienThiTheoTenKH.Click += new System.EventHandler(this.btnXHienThiTheoTenKH_Click);
	  // 
	  // groupBoxTenVTTheoTenKH
	  // 
	  this.groupBoxTenVTTheoTenKH.Controls.Add(this.comboBoxExTenVTCuaKH);
	  this.groupBoxTenVTTheoTenKH.Enabled = false;
	  this.groupBoxTenVTTheoTenKH.Location = new System.Drawing.Point(196, 19);
	  this.groupBoxTenVTTheoTenKH.Name = "groupBoxTenVTTheoTenKH";
	  this.groupBoxTenVTTheoTenKH.Size = new System.Drawing.Size(200, 53);
	  this.groupBoxTenVTTheoTenKH.TabIndex = 1;
	  this.groupBoxTenVTTheoTenKH.TabStop = false;
	  this.groupBoxTenVTTheoTenKH.Text = "Tên vị thuốc";
	  // 
	  // comboBoxExTenVTCuaKH
	  // 
	  this.comboBoxExTenVTCuaKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
	  this.comboBoxExTenVTCuaKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	  this.comboBoxExTenVTCuaKH.DisplayMember = "Text";
	  this.comboBoxExTenVTCuaKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTenVTCuaKH.FormattingEnabled = true;
	  this.comboBoxExTenVTCuaKH.ItemHeight = 14;
	  this.comboBoxExTenVTCuaKH.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxExTenVTCuaKH.Name = "comboBoxExTenVTCuaKH";
	  this.comboBoxExTenVTCuaKH.Size = new System.Drawing.Size(187, 20);
	  this.comboBoxExTenVTCuaKH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTenVTCuaKH.TabIndex = 0;
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.comboBoxExTenKhachHang);
	  this.groupBox4.Location = new System.Drawing.Point(7, 19);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(183, 53);
	  this.groupBox4.TabIndex = 0;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Tên khách hàng";
	  // 
	  // comboBoxExTenKhachHang
	  // 
	  this.comboBoxExTenKhachHang.DisplayMember = "Text";
	  this.comboBoxExTenKhachHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTenKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	  this.comboBoxExTenKhachHang.FormattingEnabled = true;
	  this.comboBoxExTenKhachHang.ItemHeight = 14;
	  this.comboBoxExTenKhachHang.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxExTenKhachHang.Name = "comboBoxExTenKhachHang";
	  this.comboBoxExTenKhachHang.Size = new System.Drawing.Size(170, 20);
	  this.comboBoxExTenKhachHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTenKhachHang.TabIndex = 0;
	  this.comboBoxExTenKhachHang.DropDownClosed += new System.EventHandler(this.comboBoxExTenKhachHang_DropDownClosed);
	  // 
	  // groupBox6
	  // 
	  this.groupBox6.Controls.Add(this.btnXTimTheoKiTu);
	  this.groupBox6.Controls.Add(this.groupBox7);
	  this.groupBox6.Location = new System.Drawing.Point(932, 12);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(397, 81);
	  this.groupBox6.TabIndex = 4;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Xem những vị thuốc mà tên có các chữ như ở dưới";
	  // 
	  // btnXTimTheoKiTu
	  // 
	  this.btnXTimTheoKiTu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXTimTheoKiTu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXTimTheoKiTu.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXTimTheoKiTu.Location = new System.Drawing.Point(213, 18);
	  this.btnXTimTheoKiTu.Name = "btnXTimTheoKiTu";
	  this.btnXTimTheoKiTu.Size = new System.Drawing.Size(136, 52);
	  this.btnXTimTheoKiTu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXTimTheoKiTu.TabIndex = 1;
	  this.btnXTimTheoKiTu.Text = "Hiển thị danh sách";
	  this.btnXTimTheoKiTu.Click += new System.EventHandler(this.btnXTimTheoKiTu_Click);
	  // 
	  // groupBox7
	  // 
	  this.groupBox7.Controls.Add(this.txtXKiTuCanTim);
	  this.groupBox7.Location = new System.Drawing.Point(6, 20);
	  this.groupBox7.Name = "groupBox7";
	  this.groupBox7.Size = new System.Drawing.Size(200, 51);
	  this.groupBox7.TabIndex = 0;
	  this.groupBox7.TabStop = false;
	  this.groupBox7.Text = "Chữ cái (Dài từ 2 đến 8 kí tự)";
	  // 
	  // txtXKiTuCanTim
	  // 
	  // 
	  // 
	  // 
	  this.txtXKiTuCanTim.Border.Class = "TextBoxBorder";
	  this.txtXKiTuCanTim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXKiTuCanTim.Location = new System.Drawing.Point(7, 20);
	  this.txtXKiTuCanTim.Name = "txtXKiTuCanTim";
	  this.txtXKiTuCanTim.Size = new System.Drawing.Size(180, 20);
	  this.txtXKiTuCanTim.TabIndex = 0;
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.groupBox3);
	  this.panelEx1.Controls.Add(this.btnXXemChiTietDonHang);
	  this.panelEx1.Controls.Add(this.groupBox6);
	  this.panelEx1.Controls.Add(this.groupBox2);
	  this.panelEx1.Controls.Add(this.groupBoxTimTheoTenChinhXac);
	  this.panelEx1.Location = new System.Drawing.Point(-1, 0);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(1345, 674);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 5;
	  this.panelEx1.Text = "panelEx1";
	  // 
	  // FormXemGiaThuoc
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1341, 673);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "FormXemGiaThuoc";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Xem giá thuốc";
	  this.Load += new System.EventHandler(this.FormXemGiaThuoc_Load);
	  this.groupBoxTimTheoTenChinhXac.ResumeLayout(false);
	  this.groupBox5.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuGDVT)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBoxTenVTTheoTenKH.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  this.groupBox6.ResumeLayout(false);
	  this.groupBox7.ResumeLayout(false);
	  this.panelEx1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBoxTimTheoTenChinhXac;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenViThuoc;
	private DevComponents.DotNetBar.ButtonX btnXHienThi;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXLichSuGDVT;
	private DevComponents.DotNetBar.ButtonX btnXXemChiTietDonHang;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.GroupBox groupBox4;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenKhachHang;
	private System.Windows.Forms.GroupBox groupBoxTenVTTheoTenKH;
	private DevComponents.DotNetBar.ButtonX btnXHienThiTheoTenKH;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenVTCuaKH;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.GroupBox groupBox6;
	private System.Windows.Forms.GroupBox groupBox7;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXKiTuCanTim;
	private DevComponents.DotNetBar.ButtonX btnXTimTheoKiTu;
	private DevComponents.DotNetBar.PanelEx panelEx1;
  }
}