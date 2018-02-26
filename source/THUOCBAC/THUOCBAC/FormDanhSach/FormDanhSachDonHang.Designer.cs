namespace THUOCBAC.FormDanhSach {
  partial class FormDanhSachDonHang {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXHienThiTatCaDH = new DevComponents.DotNetBar.ButtonX();
	  this.btnXXoaDH = new DevComponents.DotNetBar.ButtonX();
	  this.btnXXemChiTietDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThemDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.btnXTimKiemTheoNgay = new DevComponents.DotNetBar.ButtonX();
	  this.dateTimeInputThoiGian = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.btnXChonTenKhachHang = new DevComponents.DotNetBar.ButtonX();
	  this.txtXNameCustomer = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.btnXTimKiemTheoTenKH = new DevComponents.DotNetBar.ButtonX();
	  this.groupBoxDanhSachDH = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXCacDonHang = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputThoiGian)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBoxDanhSachDH.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXCacDonHang)).BeginInit();
	  this.groupBox4.SuspendLayout();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXHienThiTatCaDH);
	  this.groupBox1.Controls.Add(this.btnXXoaDH);
	  this.groupBox1.Controls.Add(this.btnXXemChiTietDonHang);
	  this.groupBox1.Controls.Add(this.btnXThemDonHang);
	  this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox1.Location = new System.Drawing.Point(0, 0);
	  this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(196, 223);
	  this.groupBox1.TabIndex = 1;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Chức năng";
	  // 
	  // btnXHienThiTatCaDH
	  // 
	  this.btnXHienThiTatCaDH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXHienThiTatCaDH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXHienThiTatCaDH.Image = global::THUOCBAC.Properties.Resources.clear2;
	  this.btnXHienThiTatCaDH.Location = new System.Drawing.Point(7, 170);
	  this.btnXHienThiTatCaDH.Name = "btnXHienThiTatCaDH";
	  this.btnXHienThiTatCaDH.Size = new System.Drawing.Size(183, 44);
	  this.btnXHienThiTatCaDH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXHienThiTatCaDH.TabIndex = 1;
	  this.btnXHienThiTatCaDH.Text = "Hiển thị tất cả đơn hàng";
	  this.btnXHienThiTatCaDH.Click += new System.EventHandler(this.btnXHienThiTatCaDH_Click);
	  // 
	  // btnXXoaDH
	  // 
	  this.btnXXoaDH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXoaDH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXoaDH.Enabled = false;
	  this.btnXXoaDH.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXXoaDH.Location = new System.Drawing.Point(7, 120);
	  this.btnXXoaDH.Name = "btnXXoaDH";
	  this.btnXXoaDH.Size = new System.Drawing.Size(183, 44);
	  this.btnXXoaDH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXoaDH.TabIndex = 1;
	  this.btnXXoaDH.Text = "Xóa đơn hàng trống này";
	  this.btnXXoaDH.Click += new System.EventHandler(this.btnXXoaDH_Click);
	  // 
	  // btnXXemChiTietDonHang
	  // 
	  this.btnXXemChiTietDonHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemChiTietDonHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemChiTietDonHang.Enabled = false;
	  this.btnXXemChiTietDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.btnXXemChiTietDonHang.Image = global::THUOCBAC.Properties.Resources._goto;
	  this.btnXXemChiTietDonHang.Location = new System.Drawing.Point(7, 70);
	  this.btnXXemChiTietDonHang.Name = "btnXXemChiTietDonHang";
	  this.btnXXemChiTietDonHang.Size = new System.Drawing.Size(183, 44);
	  this.btnXXemChiTietDonHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemChiTietDonHang.TabIndex = 1;
	  this.btnXXemChiTietDonHang.Text = "Xem chi tiết đơn hàng này";
	  this.btnXXemChiTietDonHang.Click += new System.EventHandler(this.btnXXemChiTietDonHang_Click);
	  // 
	  // btnXThemDonHang
	  // 
	  this.btnXThemDonHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThemDonHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThemDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.btnXThemDonHang.Image = global::THUOCBAC.Properties.Resources.add;
	  this.btnXThemDonHang.Location = new System.Drawing.Point(7, 20);
	  this.btnXThemDonHang.Name = "btnXThemDonHang";
	  this.btnXThemDonHang.Size = new System.Drawing.Size(183, 44);
	  this.btnXThemDonHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThemDonHang.TabIndex = 0;
	  this.btnXThemDonHang.Text = "Thêm đơn hàng mới";
	  this.btnXThemDonHang.Click += new System.EventHandler(this.btnXThemDonHang_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.btnXTimKiemTheoNgay);
	  this.groupBox2.Controls.Add(this.dateTimeInputThoiGian);
	  this.groupBox2.Location = new System.Drawing.Point(7, 113);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(183, 89);
	  this.groupBox2.TabIndex = 3;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Tìm kiếm đơn hàng theo ngày";
	  // 
	  // btnXTimKiemTheoNgay
	  // 
	  this.btnXTimKiemTheoNgay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXTimKiemTheoNgay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXTimKiemTheoNgay.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXTimKiemTheoNgay.Location = new System.Drawing.Point(7, 46);
	  this.btnXTimKiemTheoNgay.Name = "btnXTimKiemTheoNgay";
	  this.btnXTimKiemTheoNgay.Size = new System.Drawing.Size(170, 34);
	  this.btnXTimKiemTheoNgay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXTimKiemTheoNgay.TabIndex = 1;
	  this.btnXTimKiemTheoNgay.Text = "Tìm trong ngày này";
	  this.btnXTimKiemTheoNgay.Click += new System.EventHandler(this.btnXTimKiemTheoNgay_Click);
	  // 
	  // dateTimeInputThoiGian
	  // 
	  // 
	  // 
	  // 
	  this.dateTimeInputThoiGian.BackgroundStyle.Class = "DateTimeInputBackground";
	  this.dateTimeInputThoiGian.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputThoiGian.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
	  this.dateTimeInputThoiGian.ButtonDropDown.Visible = true;
	  this.dateTimeInputThoiGian.CustomFormat = "dd/MM/yyyy";
	  this.dateTimeInputThoiGian.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
	  this.dateTimeInputThoiGian.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
	  this.dateTimeInputThoiGian.IsPopupCalendarOpen = false;
	  this.dateTimeInputThoiGian.Location = new System.Drawing.Point(7, 20);
	  // 
	  // 
	  // 
	  this.dateTimeInputThoiGian.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
	  // 
	  // 
	  // 
	  this.dateTimeInputThoiGian.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputThoiGian.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
	  this.dateTimeInputThoiGian.MonthCalendar.ClearButtonVisible = true;
	  // 
	  // 
	  // 
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
	  this.dateTimeInputThoiGian.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputThoiGian.MonthCalendar.DisplayMonth = new System.DateTime(2017, 5, 1, 0, 0, 0, 0);
	  this.dateTimeInputThoiGian.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
	  this.dateTimeInputThoiGian.MonthCalendar.MarkedDates = new System.DateTime[0];
	  this.dateTimeInputThoiGian.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
	  // 
	  // 
	  // 
	  this.dateTimeInputThoiGian.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.dateTimeInputThoiGian.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
	  this.dateTimeInputThoiGian.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.dateTimeInputThoiGian.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputThoiGian.MonthCalendar.TodayButtonVisible = true;
	  this.dateTimeInputThoiGian.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
	  this.dateTimeInputThoiGian.Name = "dateTimeInputThoiGian";
	  this.dateTimeInputThoiGian.Size = new System.Drawing.Size(170, 20);
	  this.dateTimeInputThoiGian.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.dateTimeInputThoiGian.TabIndex = 0;
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.btnXChonTenKhachHang);
	  this.groupBox3.Controls.Add(this.txtXNameCustomer);
	  this.groupBox3.Controls.Add(this.btnXTimKiemTheoTenKH);
	  this.groupBox3.Location = new System.Drawing.Point(7, 19);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(183, 88);
	  this.groupBox3.TabIndex = 2;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Tìm kiếm theo tên khách hàng";
	  // 
	  // btnXChonTenKhachHang
	  // 
	  this.btnXChonTenKhachHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXChonTenKhachHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXChonTenKhachHang.Location = new System.Drawing.Point(114, 19);
	  this.btnXChonTenKhachHang.Name = "btnXChonTenKhachHang";
	  this.btnXChonTenKhachHang.Size = new System.Drawing.Size(63, 20);
	  this.btnXChonTenKhachHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXChonTenKhachHang.TabIndex = 3;
	  this.btnXChonTenKhachHang.Text = "Chọn...";
	  this.btnXChonTenKhachHang.Click += new System.EventHandler(this.btnXChonTenKhachHang_Click);
	  // 
	  // txtXNameCustomer
	  // 
	  // 
	  // 
	  // 
	  this.txtXNameCustomer.Border.Class = "TextBoxBorder";
	  this.txtXNameCustomer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXNameCustomer.Enabled = false;
	  this.txtXNameCustomer.Location = new System.Drawing.Point(6, 19);
	  this.txtXNameCustomer.Name = "txtXNameCustomer";
	  this.txtXNameCustomer.Size = new System.Drawing.Size(102, 20);
	  this.txtXNameCustomer.TabIndex = 2;
	  // 
	  // btnXTimKiemTheoTenKH
	  // 
	  this.btnXTimKiemTheoTenKH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXTimKiemTheoTenKH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXTimKiemTheoTenKH.Enabled = false;
	  this.btnXTimKiemTheoTenKH.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXTimKiemTheoTenKH.Location = new System.Drawing.Point(7, 45);
	  this.btnXTimKiemTheoTenKH.Name = "btnXTimKiemTheoTenKH";
	  this.btnXTimKiemTheoTenKH.Size = new System.Drawing.Size(170, 34);
	  this.btnXTimKiemTheoTenKH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXTimKiemTheoTenKH.TabIndex = 1;
	  this.btnXTimKiemTheoTenKH.Text = "Tìm tên khách hàng này";
	  this.btnXTimKiemTheoTenKH.Click += new System.EventHandler(this.btnXTimKiemTheoTenKH_Click);
	  // 
	  // groupBoxDanhSachDH
	  // 
	  this.groupBoxDanhSachDH.Controls.Add(this.dataGridViewXCacDonHang);
	  this.groupBoxDanhSachDH.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBoxDanhSachDH.Location = new System.Drawing.Point(199, 0);
	  this.groupBoxDanhSachDH.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
	  this.groupBoxDanhSachDH.Name = "groupBoxDanhSachDH";
	  this.groupBoxDanhSachDH.Padding = new System.Windows.Forms.Padding(6);
	  this.tableLayoutPanel1.SetRowSpan(this.groupBoxDanhSachDH, 2);
	  this.groupBoxDanhSachDH.Size = new System.Drawing.Size(1147, 538);
	  this.groupBoxDanhSachDH.TabIndex = 2;
	  this.groupBoxDanhSachDH.TabStop = false;
	  this.groupBoxDanhSachDH.Text = "Danh sách";
	  // 
	  // dataGridViewXCacDonHang
	  // 
	  this.dataGridViewXCacDonHang.AllowUserToAddRows = false;
	  this.dataGridViewXCacDonHang.AllowUserToDeleteRows = false;
	  this.dataGridViewXCacDonHang.AllowUserToResizeColumns = false;
	  dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
	  dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	  this.dataGridViewXCacDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
	  this.dataGridViewXCacDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXCacDonHang.DefaultCellStyle = dataGridViewCellStyle20;
	  this.dataGridViewXCacDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dataGridViewXCacDonHang.EnableHeadersVisualStyles = false;
	  this.dataGridViewXCacDonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXCacDonHang.Location = new System.Drawing.Point(6, 19);
	  this.dataGridViewXCacDonHang.Name = "dataGridViewXCacDonHang";
	  this.dataGridViewXCacDonHang.ReadOnly = true;
	  dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
	  dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	  this.dataGridViewXCacDonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
	  this.dataGridViewXCacDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXCacDonHang.Size = new System.Drawing.Size(1135, 513);
	  this.dataGridViewXCacDonHang.TabIndex = 0;
	  this.dataGridViewXCacDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXCacDonHang_CellClick);
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.groupBox2);
	  this.groupBox4.Controls.Add(this.groupBox3);
	  this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox4.Location = new System.Drawing.Point(0, 223);
	  this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(196, 315);
	  this.groupBox4.TabIndex = 3;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Tìm kiếm";
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 2;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
	  this.tableLayoutPanel1.Controls.Add(this.groupBoxDanhSachDH, 1, 0);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 2;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 223F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(1349, 538);
	  this.tableLayoutPanel1.TabIndex = 4;
	  // 
	  // FormDanhSachDonHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.tableLayoutPanel1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormDanhSachDonHang";
	  this.Text = "FormDanhSachDonHang";
	  this.Load += new System.EventHandler(this.FormDanhSachDonHang_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputThoiGian)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBoxDanhSachDH.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXCacDonHang)).EndInit();
	  this.groupBox4.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBoxDanhSachDH;
	private DevComponents.DotNetBar.ButtonX btnXThemDonHang;
	private DevComponents.DotNetBar.ButtonX btnXXemChiTietDonHang;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXCacDonHang;
	private DevComponents.DotNetBar.ButtonX btnXXoaDH;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.ButtonX btnXTimKiemTheoTenKH;
	private DevComponents.DotNetBar.ButtonX btnXHienThiTatCaDH;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputThoiGian;
	private DevComponents.DotNetBar.ButtonX btnXTimKiemTheoNgay;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXNameCustomer;
	private DevComponents.DotNetBar.ButtonX btnXChonTenKhachHang;
  }
}