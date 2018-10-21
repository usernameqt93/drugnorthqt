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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXHienThiTatCaDH = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.btnXTimKiemTheoNgay = new DevComponents.DotNetBar.ButtonX();
	  this.dateTimeInputThoiGian = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.btnXTimKiemTheoTenKH = new DevComponents.DotNetBar.ButtonX();
	  this.comboBoxExTenKhachHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.btnXXoaDH = new DevComponents.DotNetBar.ButtonX();
	  this.btnXXemChiTietDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThemDonHang = new DevComponents.DotNetBar.ButtonX();
	  this.groupBoxDanhSachDH = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXCacDonHang = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputThoiGian)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBoxDanhSachDH.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXCacDonHang)).BeginInit();
	  this.groupBox4.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXHienThiTatCaDH);
	  this.groupBox1.Controls.Add(this.btnXXoaDH);
	  this.groupBox1.Controls.Add(this.btnXXemChiTietDonHang);
	  this.groupBox1.Controls.Add(this.btnXThemDonHang);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
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
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.btnXTimKiemTheoNgay);
	  this.groupBox2.Controls.Add(this.dateTimeInputThoiGian);
	  this.groupBox2.Location = new System.Drawing.Point(7, 115);
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
	  this.groupBox3.Controls.Add(this.btnXTimKiemTheoTenKH);
	  this.groupBox3.Controls.Add(this.comboBoxExTenKhachHang);
	  this.groupBox3.Location = new System.Drawing.Point(7, 19);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(183, 90);
	  this.groupBox3.TabIndex = 2;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Tìm kiếm theo tên khách hàng";
	  // 
	  // btnXTimKiemTheoTenKH
	  // 
	  this.btnXTimKiemTheoTenKH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXTimKiemTheoTenKH.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXTimKiemTheoTenKH.Enabled = false;
	  this.btnXTimKiemTheoTenKH.Image = global::THUOCBAC.Properties.Resources.find;
	  this.btnXTimKiemTheoTenKH.Location = new System.Drawing.Point(7, 47);
	  this.btnXTimKiemTheoTenKH.Name = "btnXTimKiemTheoTenKH";
	  this.btnXTimKiemTheoTenKH.Size = new System.Drawing.Size(170, 34);
	  this.btnXTimKiemTheoTenKH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXTimKiemTheoTenKH.TabIndex = 1;
	  this.btnXTimKiemTheoTenKH.Text = "Tìm tên khách hàng này";
	  this.btnXTimKiemTheoTenKH.Click += new System.EventHandler(this.btnXTimKiemTheoTenKH_Click);
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
	  // groupBoxDanhSachDH
	  // 
	  this.groupBoxDanhSachDH.Controls.Add(this.dataGridViewXCacDonHang);
	  this.groupBoxDanhSachDH.Location = new System.Drawing.Point(214, 12);
	  this.groupBoxDanhSachDH.Name = "groupBoxDanhSachDH";
	  this.groupBoxDanhSachDH.Size = new System.Drawing.Size(1123, 514);
	  this.groupBoxDanhSachDH.TabIndex = 2;
	  this.groupBoxDanhSachDH.TabStop = false;
	  this.groupBoxDanhSachDH.Text = "Danh sách";
	  // 
	  // dataGridViewXCacDonHang
	  // 
	  this.dataGridViewXCacDonHang.AllowUserToAddRows = false;
	  this.dataGridViewXCacDonHang.AllowUserToDeleteRows = false;
	  this.dataGridViewXCacDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
	  dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	  this.dataGridViewXCacDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
	  this.dataGridViewXCacDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXCacDonHang.DefaultCellStyle = dataGridViewCellStyle5;
	  this.dataGridViewXCacDonHang.EnableHeadersVisualStyles = false;
	  this.dataGridViewXCacDonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXCacDonHang.Location = new System.Drawing.Point(6, 19);
	  this.dataGridViewXCacDonHang.Name = "dataGridViewXCacDonHang";
	  this.dataGridViewXCacDonHang.ReadOnly = true;
	  dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
	  dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
	  dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	  this.dataGridViewXCacDonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
	  this.dataGridViewXCacDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXCacDonHang.Size = new System.Drawing.Size(1111, 489);
	  this.dataGridViewXCacDonHang.TabIndex = 0;
	  this.dataGridViewXCacDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXCacDonHang_CellClick);
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.groupBox2);
	  this.groupBox4.Controls.Add(this.groupBox3);
	  this.groupBox4.Location = new System.Drawing.Point(12, 241);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(196, 285);
	  this.groupBox4.TabIndex = 3;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Tìm kiếm";
	  // 
	  // FormDanhSachDonHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.groupBox4);
	  this.Controls.Add(this.groupBoxDanhSachDH);
	  this.Controls.Add(this.groupBox1);
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
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenKhachHang;
	private DevComponents.DotNetBar.ButtonX btnXTimKiemTheoTenKH;
	private DevComponents.DotNetBar.ButtonX btnXHienThiTatCaDH;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputThoiGian;
	private DevComponents.DotNetBar.ButtonX btnXTimKiemTheoNgay;
	private System.Windows.Forms.GroupBox groupBox4;
  }
}