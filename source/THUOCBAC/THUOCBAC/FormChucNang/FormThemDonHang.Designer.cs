namespace THUOCBAC.FormChucNang {
  partial class FormThemDonHang {
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
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemDonHang));
	  this.labelXDonViTinh = new DevComponents.DotNetBar.LabelX();
	  this.groupBoxChiTietDonHang = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXChiTietDonHang = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBoxTongGiaDonHang = new System.Windows.Forms.GroupBox();
	  this.btnXXemReportCTHD = new DevComponents.DotNetBar.ButtonX();
	  this.labelXTongTienDonHang = new DevComponents.DotNetBar.LabelX();
	  this.btnXXoaViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.groupBoxThemViThuoc = new System.Windows.Forms.GroupBox();
	  this.btnXThemViThuocVaoDH = new DevComponents.DotNetBar.ButtonX();
	  this.groupBoxThanhTien = new System.Windows.Forms.GroupBox();
	  this.labelXTinhThanhTien = new DevComponents.DotNetBar.LabelX();
	  this.groupBox11 = new System.Windows.Forms.GroupBox();
	  this.numericSoLuongVT = new System.Windows.Forms.NumericUpDown();
	  this.groupBox10 = new System.Windows.Forms.GroupBox();
	  this.labelX1 = new DevComponents.DotNetBar.LabelX();
	  this.numericDonGiaVT = new System.Windows.Forms.NumericUpDown();
	  this.groupBoxTenViThuoc = new System.Windows.Forms.GroupBox();
	  this.comboBoxExDanhSachCacViThuoc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.grpTrangThaiHoatDong = new System.Windows.Forms.GroupBox();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.labelXTrangThaiTruocDo = new DevComponents.DotNetBar.LabelX();
	  this.labelXTrangThaiGanNhat = new DevComponents.DotNetBar.LabelX();
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.groupBoxChiTietDonHang.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXChiTietDonHang)).BeginInit();
	  this.groupBoxTongGiaDonHang.SuspendLayout();
	  this.groupBoxThemViThuoc.SuspendLayout();
	  this.groupBoxThanhTien.SuspendLayout();
	  this.groupBox11.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericSoLuongVT)).BeginInit();
	  this.groupBox10.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericDonGiaVT)).BeginInit();
	  this.groupBoxTenViThuoc.SuspendLayout();
	  this.grpTrangThaiHoatDong.SuspendLayout();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.tlpMain.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // labelXDonViTinh
	  // 
	  // 
	  // 
	  // 
	  this.labelXDonViTinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXDonViTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelXDonViTinh.Location = new System.Drawing.Point(191, 14);
	  this.labelXDonViTinh.Name = "labelXDonViTinh";
	  this.labelXDonViTinh.Size = new System.Drawing.Size(58, 31);
	  this.labelXDonViTinh.TabIndex = 1;
	  this.labelXDonViTinh.Text = "(Cân)";
	  // 
	  // groupBoxChiTietDonHang
	  // 
	  this.groupBoxChiTietDonHang.Controls.Add(this.dataGridViewXChiTietDonHang);
	  this.groupBoxChiTietDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBoxChiTietDonHang.Location = new System.Drawing.Point(308, 95);
	  this.groupBoxChiTietDonHang.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
	  this.groupBoxChiTietDonHang.Name = "groupBoxChiTietDonHang";
	  this.tlpMain.SetRowSpan(this.groupBoxChiTietDonHang, 4);
	  this.groupBoxChiTietDonHang.Size = new System.Drawing.Size(943, 501);
	  this.groupBoxChiTietDonHang.TabIndex = 2;
	  this.groupBoxChiTietDonHang.TabStop = false;
	  this.groupBoxChiTietDonHang.Text = "Chi tiết đơn hàng";
	  // 
	  // dataGridViewXChiTietDonHang
	  // 
	  this.dataGridViewXChiTietDonHang.AllowUserToAddRows = false;
	  this.dataGridViewXChiTietDonHang.AllowUserToDeleteRows = false;
	  this.dataGridViewXChiTietDonHang.AllowUserToResizeColumns = false;
	  this.dataGridViewXChiTietDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXChiTietDonHang.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXChiTietDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dataGridViewXChiTietDonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXChiTietDonHang.Location = new System.Drawing.Point(3, 16);
	  this.dataGridViewXChiTietDonHang.Name = "dataGridViewXChiTietDonHang";
	  this.dataGridViewXChiTietDonHang.ReadOnly = true;
	  this.dataGridViewXChiTietDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXChiTietDonHang.Size = new System.Drawing.Size(937, 482);
	  this.dataGridViewXChiTietDonHang.TabIndex = 0;
	  this.dataGridViewXChiTietDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXChiTietDonHang_CellClick);
	  // 
	  // groupBoxTongGiaDonHang
	  // 
	  this.groupBoxTongGiaDonHang.Controls.Add(this.btnXXemReportCTHD);
	  this.groupBoxTongGiaDonHang.Controls.Add(this.labelXTongTienDonHang);
	  this.groupBoxTongGiaDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBoxTongGiaDonHang.Location = new System.Drawing.Point(33, 443);
	  this.groupBoxTongGiaDonHang.Name = "groupBoxTongGiaDonHang";
	  this.groupBoxTongGiaDonHang.Size = new System.Drawing.Size(269, 154);
	  this.groupBoxTongGiaDonHang.TabIndex = 3;
	  this.groupBoxTongGiaDonHang.TabStop = false;
	  this.groupBoxTongGiaDonHang.Text = "Tổng giá đơn hàng hiện tại";
	  // 
	  // btnXXemReportCTHD
	  // 
	  this.btnXXemReportCTHD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemReportCTHD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemReportCTHD.Image = global::THUOCBAC.Properties.Resources.print;
	  this.btnXXemReportCTHD.Location = new System.Drawing.Point(6, 72);
	  this.btnXXemReportCTHD.Name = "btnXXemReportCTHD";
	  this.btnXXemReportCTHD.Size = new System.Drawing.Size(255, 47);
	  this.btnXXemReportCTHD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemReportCTHD.TabIndex = 0;
	  this.btnXXemReportCTHD.Text = "Xem bản in hóa đơn này";
	  this.btnXXemReportCTHD.Click += new System.EventHandler(this.btnXXemReportCTHD_Click);
	  // 
	  // labelXTongTienDonHang
	  // 
	  // 
	  // 
	  // 
	  this.labelXTongTienDonHang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTongTienDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelXTongTienDonHang.Location = new System.Drawing.Point(6, 19);
	  this.labelXTongTienDonHang.Name = "labelXTongTienDonHang";
	  this.labelXTongTienDonHang.Size = new System.Drawing.Size(255, 47);
	  this.labelXTongTienDonHang.TabIndex = 0;
	  this.labelXTongTienDonHang.Text = "0 đ";
	  this.labelXTongTienDonHang.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // btnXXoaViThuoc
	  // 
	  this.btnXXoaViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXoaViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXoaViThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXXoaViThuoc.Enabled = false;
	  this.btnXXoaViThuoc.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXXoaViThuoc.Location = new System.Drawing.Point(33, 402);
	  this.btnXXoaViThuoc.Name = "btnXXoaViThuoc";
	  this.btnXXoaViThuoc.Size = new System.Drawing.Size(269, 35);
	  this.btnXXoaViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXoaViThuoc.TabIndex = 5;
	  this.btnXXoaViThuoc.Text = "Xóa vị thuốc đang chọn ra khỏi đơn hàng";
	  this.btnXXoaViThuoc.Click += new System.EventHandler(this.btnXXoaViThuoc_Click);
	  // 
	  // groupBoxThemViThuoc
	  // 
	  this.groupBoxThemViThuoc.Controls.Add(this.btnXThemViThuocVaoDH);
	  this.groupBoxThemViThuoc.Controls.Add(this.groupBoxThanhTien);
	  this.groupBoxThemViThuoc.Controls.Add(this.groupBox11);
	  this.groupBoxThemViThuoc.Controls.Add(this.groupBox10);
	  this.groupBoxThemViThuoc.Controls.Add(this.groupBoxTenViThuoc);
	  this.groupBoxThemViThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBoxThemViThuoc.Location = new System.Drawing.Point(33, 23);
	  this.groupBoxThemViThuoc.Name = "groupBoxThemViThuoc";
	  this.tlpMain.SetRowSpan(this.groupBoxThemViThuoc, 2);
	  this.groupBoxThemViThuoc.Size = new System.Drawing.Size(269, 373);
	  this.groupBoxThemViThuoc.TabIndex = 6;
	  this.groupBoxThemViThuoc.TabStop = false;
	  this.groupBoxThemViThuoc.Text = "Thêm vị thuốc";
	  // 
	  // btnXThemViThuocVaoDH
	  // 
	  this.btnXThemViThuocVaoDH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThemViThuocVaoDH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThemViThuocVaoDH.Image = global::THUOCBAC.Properties.Resources.add;
	  this.btnXThemViThuocVaoDH.Location = new System.Drawing.Point(6, 280);
	  this.btnXThemViThuocVaoDH.Name = "btnXThemViThuocVaoDH";
	  this.btnXThemViThuocVaoDH.Size = new System.Drawing.Size(255, 41);
	  this.btnXThemViThuocVaoDH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThemViThuocVaoDH.TabIndex = 4;
	  this.btnXThemViThuocVaoDH.Text = "Thêm số lượng vị thuốc trên vào đơn hàng";
	  this.btnXThemViThuocVaoDH.Click += new System.EventHandler(this.btnXThemViThuocVaoDH_Click);
	  this.btnXThemViThuocVaoDH.MouseHover += new System.EventHandler(this.btnXThemViThuocVaoDH_MouseHover);
	  // 
	  // groupBoxThanhTien
	  // 
	  this.groupBoxThanhTien.Controls.Add(this.labelXTinhThanhTien);
	  this.groupBoxThanhTien.Location = new System.Drawing.Point(6, 209);
	  this.groupBoxThanhTien.Name = "groupBoxThanhTien";
	  this.groupBoxThanhTien.Size = new System.Drawing.Size(255, 65);
	  this.groupBoxThanhTien.TabIndex = 3;
	  this.groupBoxThanhTien.TabStop = false;
	  this.groupBoxThanhTien.Text = "Thành tiền (Di chuột vào đây để tính đúng giá)";
	  this.groupBoxThanhTien.MouseHover += new System.EventHandler(this.groupBoxThanhTien_MouseHover);
	  // 
	  // labelXTinhThanhTien
	  // 
	  // 
	  // 
	  // 
	  this.labelXTinhThanhTien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTinhThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelXTinhThanhTien.Location = new System.Drawing.Point(6, 17);
	  this.labelXTinhThanhTien.Name = "labelXTinhThanhTien";
	  this.labelXTinhThanhTien.Size = new System.Drawing.Size(243, 36);
	  this.labelXTinhThanhTien.TabIndex = 0;
	  this.labelXTinhThanhTien.Text = "= đ";
	  this.labelXTinhThanhTien.MouseHover += new System.EventHandler(this.labelXTinhThanhTien_MouseHover);
	  // 
	  // groupBox11
	  // 
	  this.groupBox11.Controls.Add(this.labelXDonViTinh);
	  this.groupBox11.Controls.Add(this.numericSoLuongVT);
	  this.groupBox11.Location = new System.Drawing.Point(6, 79);
	  this.groupBox11.Name = "groupBox11";
	  this.groupBox11.Size = new System.Drawing.Size(255, 65);
	  this.groupBox11.TabIndex = 1;
	  this.groupBox11.TabStop = false;
	  this.groupBox11.Text = "Số lượng muốn thêm vào đơn hàng (F6)";
	  // 
	  // numericSoLuongVT
	  // 
	  this.numericSoLuongVT.DecimalPlaces = 2;
	  this.numericSoLuongVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.numericSoLuongVT.ForeColor = System.Drawing.Color.OrangeRed;
	  this.numericSoLuongVT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
	  this.numericSoLuongVT.Location = new System.Drawing.Point(6, 19);
	  this.numericSoLuongVT.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
	  this.numericSoLuongVT.Name = "numericSoLuongVT";
	  this.numericSoLuongVT.Size = new System.Drawing.Size(179, 26);
	  this.numericSoLuongVT.TabIndex = 0;
	  this.numericSoLuongVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.numericSoLuongVT.ThousandsSeparator = true;
	  this.numericSoLuongVT.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
	  this.numericSoLuongVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericSoLuongVT_KeyDown);
	  // 
	  // groupBox10
	  // 
	  this.groupBox10.Controls.Add(this.labelX1);
	  this.groupBox10.Controls.Add(this.numericDonGiaVT);
	  this.groupBox10.Location = new System.Drawing.Point(6, 151);
	  this.groupBox10.Name = "groupBox10";
	  this.groupBox10.Size = new System.Drawing.Size(255, 52);
	  this.groupBox10.TabIndex = 2;
	  this.groupBox10.TabStop = false;
	  this.groupBox10.Text = "Đơn giá (F7) (nhấn \'N\' để thêm 3 số 0)";
	  // 
	  // labelX1
	  // 
	  // 
	  // 
	  // 
	  this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelX1.Location = new System.Drawing.Point(191, 14);
	  this.labelX1.Name = "labelX1";
	  this.labelX1.Size = new System.Drawing.Size(58, 31);
	  this.labelX1.TabIndex = 1;
	  this.labelX1.Text = "vnđ";
	  // 
	  // numericDonGiaVT
	  // 
	  this.numericDonGiaVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.numericDonGiaVT.ForeColor = System.Drawing.Color.OrangeRed;
	  this.numericDonGiaVT.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
	  this.numericDonGiaVT.Location = new System.Drawing.Point(6, 19);
	  this.numericDonGiaVT.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
	  this.numericDonGiaVT.Name = "numericDonGiaVT";
	  this.numericDonGiaVT.Size = new System.Drawing.Size(179, 26);
	  this.numericDonGiaVT.TabIndex = 0;
	  this.numericDonGiaVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.numericDonGiaVT.ThousandsSeparator = true;
	  this.numericDonGiaVT.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
	  this.numericDonGiaVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericDonGiaVT_KeyDown);
	  // 
	  // groupBoxTenViThuoc
	  // 
	  this.groupBoxTenViThuoc.Controls.Add(this.comboBoxExDanhSachCacViThuoc);
	  this.groupBoxTenViThuoc.Location = new System.Drawing.Point(6, 19);
	  this.groupBoxTenViThuoc.Name = "groupBoxTenViThuoc";
	  this.groupBoxTenViThuoc.Size = new System.Drawing.Size(255, 53);
	  this.groupBoxTenViThuoc.TabIndex = 0;
	  this.groupBoxTenViThuoc.TabStop = false;
	  this.groupBoxTenViThuoc.Text = "Tên vị thuốc (F5)";
	  this.groupBoxTenViThuoc.MouseHover += new System.EventHandler(this.groupBoxTenViThuoc_MouseHover);
	  // 
	  // comboBoxExDanhSachCacViThuoc
	  // 
	  this.comboBoxExDanhSachCacViThuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
	  this.comboBoxExDanhSachCacViThuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	  this.comboBoxExDanhSachCacViThuoc.DisplayMember = "Text";
	  this.comboBoxExDanhSachCacViThuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExDanhSachCacViThuoc.FormattingEnabled = true;
	  this.comboBoxExDanhSachCacViThuoc.ItemHeight = 14;
	  this.comboBoxExDanhSachCacViThuoc.Location = new System.Drawing.Point(6, 19);
	  this.comboBoxExDanhSachCacViThuoc.Name = "comboBoxExDanhSachCacViThuoc";
	  this.comboBoxExDanhSachCacViThuoc.Size = new System.Drawing.Size(201, 20);
	  this.comboBoxExDanhSachCacViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExDanhSachCacViThuoc.TabIndex = 0;
	  this.comboBoxExDanhSachCacViThuoc.TextUpdate += new System.EventHandler(this.comboBoxExDanhSachCacViThuoc_TextUpdate);
	  this.comboBoxExDanhSachCacViThuoc.DropDownClosed += new System.EventHandler(this.comboBoxExDanhSachCacViThuoc_DropDownClosed);
	  this.comboBoxExDanhSachCacViThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxExDanhSachCacViThuoc_KeyDown);
	  // 
	  // grpTrangThaiHoatDong
	  // 
	  this.grpTrangThaiHoatDong.Controls.Add(this.tableLayoutPanel1);
	  this.grpTrangThaiHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpTrangThaiHoatDong.Location = new System.Drawing.Point(308, 23);
	  this.grpTrangThaiHoatDong.Name = "grpTrangThaiHoatDong";
	  this.grpTrangThaiHoatDong.Size = new System.Drawing.Size(943, 66);
	  this.grpTrangThaiHoatDong.TabIndex = 7;
	  this.grpTrangThaiHoatDong.TabStop = false;
	  this.grpTrangThaiHoatDong.Text = "Trạng thái hoạt động gần nhất của bạn";
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 1;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Controls.Add(this.labelXTrangThaiTruocDo, 0, 0);
	  this.tableLayoutPanel1.Controls.Add(this.labelXTrangThaiGanNhat, 0, 1);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 2;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(937, 47);
	  this.tableLayoutPanel1.TabIndex = 1;
	  // 
	  // labelXTrangThaiTruocDo
	  // 
	  // 
	  // 
	  // 
	  this.labelXTrangThaiTruocDo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTrangThaiTruocDo.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.labelXTrangThaiTruocDo.Location = new System.Drawing.Point(3, 3);
	  this.labelXTrangThaiTruocDo.Name = "labelXTrangThaiTruocDo";
	  this.labelXTrangThaiTruocDo.Size = new System.Drawing.Size(931, 17);
	  this.labelXTrangThaiTruocDo.TabIndex = 0;
	  // 
	  // labelXTrangThaiGanNhat
	  // 
	  // 
	  // 
	  // 
	  this.labelXTrangThaiGanNhat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTrangThaiGanNhat.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.labelXTrangThaiGanNhat.Location = new System.Drawing.Point(3, 26);
	  this.labelXTrangThaiGanNhat.Name = "labelXTrangThaiGanNhat";
	  this.labelXTrangThaiGanNhat.Size = new System.Drawing.Size(931, 18);
	  this.labelXTrangThaiGanNhat.TabIndex = 0;
	  // 
	  // tlpMain
	  // 
	  this.tlpMain.ColumnCount = 4;
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.Controls.Add(this.grpTrangThaiHoatDong, 2, 1);
	  this.tlpMain.Controls.Add(this.groupBoxTongGiaDonHang, 1, 4);
	  this.tlpMain.Controls.Add(this.btnXXoaViThuoc, 1, 3);
	  this.tlpMain.Controls.Add(this.groupBoxThemViThuoc, 1, 1);
	  this.tlpMain.Controls.Add(this.groupBoxChiTietDonHang, 2, 2);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 7;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 307F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(1284, 616);
	  this.tlpMain.TabIndex = 8;
	  // 
	  // FormThemDonHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1284, 616);
	  this.Controls.Add(this.tlpMain);
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.KeyPreview = true;
	  this.MinimumSize = new System.Drawing.Size(1300, 655);
	  this.Name = "FormThemDonHang";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Đơn hàng";
	  this.Load += new System.EventHandler(this.FormThemDonHang_Load);
	  this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormThemDonHang_KeyDown);
	  this.groupBoxChiTietDonHang.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXChiTietDonHang)).EndInit();
	  this.groupBoxTongGiaDonHang.ResumeLayout(false);
	  this.groupBoxThemViThuoc.ResumeLayout(false);
	  this.groupBoxThanhTien.ResumeLayout(false);
	  this.groupBox11.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericSoLuongVT)).EndInit();
	  this.groupBox10.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericDonGiaVT)).EndInit();
	  this.groupBoxTenViThuoc.ResumeLayout(false);
	  this.grpTrangThaiHoatDong.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.tlpMain.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.LabelX labelXDonViTinh;
	private System.Windows.Forms.GroupBox groupBoxChiTietDonHang;
	private System.Windows.Forms.GroupBox groupBoxTongGiaDonHang;
	private DevComponents.DotNetBar.LabelX labelXTongTienDonHang;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXChiTietDonHang;
	private DevComponents.DotNetBar.ButtonX btnXXemReportCTHD;
	private DevComponents.DotNetBar.ButtonX btnXXoaViThuoc;
	private System.Windows.Forms.GroupBox groupBoxThemViThuoc;
	private System.Windows.Forms.GroupBox groupBoxTenViThuoc;
	private System.Windows.Forms.GroupBox groupBox10;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExDanhSachCacViThuoc;
	private System.Windows.Forms.GroupBox groupBox11;
	private System.Windows.Forms.GroupBox groupBoxThanhTien;
	private DevComponents.DotNetBar.ButtonX btnXThemViThuocVaoDH;
	private System.Windows.Forms.NumericUpDown numericSoLuongVT;
	private System.Windows.Forms.NumericUpDown numericDonGiaVT;
	private DevComponents.DotNetBar.LabelX labelXTinhThanhTien;
	private DevComponents.DotNetBar.LabelX labelX1;
	private System.Windows.Forms.GroupBox grpTrangThaiHoatDong;
	private DevComponents.DotNetBar.LabelX labelXTrangThaiTruocDo;
	private DevComponents.DotNetBar.LabelX labelXTrangThaiGanNhat;
	private System.Windows.Forms.TableLayoutPanel tlpMain;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}