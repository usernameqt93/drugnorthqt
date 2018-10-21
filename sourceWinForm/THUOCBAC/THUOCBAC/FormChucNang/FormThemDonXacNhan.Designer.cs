namespace THUOCBAC.FormChucNang {
  partial class FormThemDonXacNhan {
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
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXThemThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.comboBoxExTenThuoc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.txtXHoKhauThuongTru = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox5 = new System.Windows.Forms.GroupBox();
	  this.txtXSoCMTND = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.dateTimeInputNgaySinh = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.txtXHoTen = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox7 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXDSThuocXacNhan = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.btnXXemBanIn = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.groupBox6.SuspendLayout();
	  this.groupBox5.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputNgaySinh)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBox7.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDSThuocXacNhan)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXThemThuoc);
	  this.groupBox1.Controls.Add(this.comboBoxExTenThuoc);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(329, 100);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Thêm vị thuốc";
	  // 
	  // btnXThemThuoc
	  // 
	  this.btnXThemThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThemThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThemThuoc.Enabled = false;
	  this.btnXThemThuoc.Image = global::THUOCBAC.Properties.Resources.add;
	  this.btnXThemThuoc.Location = new System.Drawing.Point(7, 47);
	  this.btnXThemThuoc.Name = "btnXThemThuoc";
	  this.btnXThemThuoc.Size = new System.Drawing.Size(207, 30);
	  this.btnXThemThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThemThuoc.TabIndex = 1;
	  this.btnXThemThuoc.Text = "Thêm vị thuốc này";
	  this.btnXThemThuoc.Click += new System.EventHandler(this.btnXThemThuoc_Click);
	  // 
	  // comboBoxExTenThuoc
	  // 
	  this.comboBoxExTenThuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
	  this.comboBoxExTenThuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	  this.comboBoxExTenThuoc.DisplayMember = "Text";
	  this.comboBoxExTenThuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTenThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	  this.comboBoxExTenThuoc.FormattingEnabled = true;
	  this.comboBoxExTenThuoc.ItemHeight = 14;
	  this.comboBoxExTenThuoc.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxExTenThuoc.Name = "comboBoxExTenThuoc";
	  this.comboBoxExTenThuoc.Size = new System.Drawing.Size(207, 20);
	  this.comboBoxExTenThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTenThuoc.TabIndex = 0;
	  this.comboBoxExTenThuoc.TextUpdate += new System.EventHandler(this.comboBoxExTenThuoc_TextUpdate);
	  this.comboBoxExTenThuoc.DropDownClosed += new System.EventHandler(this.comboBoxExTenThuoc_DropDownClosed);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.groupBox6);
	  this.groupBox2.Controls.Add(this.groupBox5);
	  this.groupBox2.Controls.Add(this.groupBox4);
	  this.groupBox2.Controls.Add(this.groupBox3);
	  this.groupBox2.Location = new System.Drawing.Point(12, 118);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(329, 356);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Thông tin cá nhân";
	  // 
	  // groupBox6
	  // 
	  this.groupBox6.Controls.Add(this.txtXHoKhauThuongTru);
	  this.groupBox6.Location = new System.Drawing.Point(7, 193);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(316, 52);
	  this.groupBox6.TabIndex = 3;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Hộ khẩu thường trú";
	  // 
	  // txtXHoKhauThuongTru
	  // 
	  // 
	  // 
	  // 
	  this.txtXHoKhauThuongTru.Border.Class = "TextBoxBorder";
	  this.txtXHoKhauThuongTru.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXHoKhauThuongTru.Location = new System.Drawing.Point(7, 20);
	  this.txtXHoKhauThuongTru.Name = "txtXHoKhauThuongTru";
	  this.txtXHoKhauThuongTru.Size = new System.Drawing.Size(294, 20);
	  this.txtXHoKhauThuongTru.TabIndex = 0;
	  this.txtXHoKhauThuongTru.Text = "Thôn Thiết Trụ - Xã Bình Minh - Khoái Châu - Hưng Yên";
	  // 
	  // groupBox5
	  // 
	  this.groupBox5.Controls.Add(this.txtXSoCMTND);
	  this.groupBox5.Location = new System.Drawing.Point(7, 135);
	  this.groupBox5.Name = "groupBox5";
	  this.groupBox5.Size = new System.Drawing.Size(316, 51);
	  this.groupBox5.TabIndex = 2;
	  this.groupBox5.TabStop = false;
	  this.groupBox5.Text = "Số chứng minh thư nhân dân";
	  // 
	  // txtXSoCMTND
	  // 
	  // 
	  // 
	  // 
	  this.txtXSoCMTND.Border.Class = "TextBoxBorder";
	  this.txtXSoCMTND.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXSoCMTND.Location = new System.Drawing.Point(7, 20);
	  this.txtXSoCMTND.Name = "txtXSoCMTND";
	  this.txtXSoCMTND.Size = new System.Drawing.Size(200, 20);
	  this.txtXSoCMTND.TabIndex = 0;
	  this.txtXSoCMTND.Text = "033175000460";
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.dateTimeInputNgaySinh);
	  this.groupBox4.Location = new System.Drawing.Point(7, 76);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(316, 53);
	  this.groupBox4.TabIndex = 1;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Ngày sinh";
	  // 
	  // dateTimeInputNgaySinh
	  // 
	  // 
	  // 
	  // 
	  this.dateTimeInputNgaySinh.BackgroundStyle.Class = "DateTimeInputBackground";
	  this.dateTimeInputNgaySinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputNgaySinh.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
	  this.dateTimeInputNgaySinh.ButtonDropDown.Visible = true;
	  this.dateTimeInputNgaySinh.IsPopupCalendarOpen = false;
	  this.dateTimeInputNgaySinh.Location = new System.Drawing.Point(7, 20);
	  // 
	  // 
	  // 
	  this.dateTimeInputNgaySinh.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
	  // 
	  // 
	  // 
	  this.dateTimeInputNgaySinh.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputNgaySinh.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
	  this.dateTimeInputNgaySinh.MonthCalendar.ClearButtonVisible = true;
	  // 
	  // 
	  // 
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
	  this.dateTimeInputNgaySinh.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputNgaySinh.MonthCalendar.DisplayMonth = new System.DateTime(2017, 4, 1, 0, 0, 0, 0);
	  this.dateTimeInputNgaySinh.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
	  this.dateTimeInputNgaySinh.MonthCalendar.MarkedDates = new System.DateTime[0];
	  this.dateTimeInputNgaySinh.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
	  // 
	  // 
	  // 
	  this.dateTimeInputNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.dateTimeInputNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
	  this.dateTimeInputNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.dateTimeInputNgaySinh.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.dateTimeInputNgaySinh.MonthCalendar.TodayButtonVisible = true;
	  this.dateTimeInputNgaySinh.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
	  this.dateTimeInputNgaySinh.Name = "dateTimeInputNgaySinh";
	  this.dateTimeInputNgaySinh.Size = new System.Drawing.Size(200, 20);
	  this.dateTimeInputNgaySinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.dateTimeInputNgaySinh.TabIndex = 0;
	  this.dateTimeInputNgaySinh.Value = new System.DateTime(1974, 10, 27, 0, 0, 0, 0);
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.txtXHoTen);
	  this.groupBox3.Location = new System.Drawing.Point(7, 19);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(316, 50);
	  this.groupBox3.TabIndex = 0;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Họ và tên";
	  // 
	  // txtXHoTen
	  // 
	  // 
	  // 
	  // 
	  this.txtXHoTen.Border.Class = "TextBoxBorder";
	  this.txtXHoTen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXHoTen.Location = new System.Drawing.Point(7, 20);
	  this.txtXHoTen.Name = "txtXHoTen";
	  this.txtXHoTen.Size = new System.Drawing.Size(200, 20);
	  this.txtXHoTen.TabIndex = 0;
	  this.txtXHoTen.Text = "Nguyễn Thị Tám";
	  // 
	  // groupBox7
	  // 
	  this.groupBox7.Controls.Add(this.dataGridViewXDSThuocXacNhan);
	  this.groupBox7.Location = new System.Drawing.Point(347, 12);
	  this.groupBox7.Name = "groupBox7";
	  this.groupBox7.Size = new System.Drawing.Size(925, 592);
	  this.groupBox7.TabIndex = 2;
	  this.groupBox7.TabStop = false;
	  this.groupBox7.Text = "Danh sách";
	  // 
	  // dataGridViewXDSThuocXacNhan
	  // 
	  this.dataGridViewXDSThuocXacNhan.AllowUserToAddRows = false;
	  this.dataGridViewXDSThuocXacNhan.AllowUserToDeleteRows = false;
	  this.dataGridViewXDSThuocXacNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXDSThuocXacNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXDSThuocXacNhan.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXDSThuocXacNhan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXDSThuocXacNhan.Location = new System.Drawing.Point(6, 19);
	  this.dataGridViewXDSThuocXacNhan.Name = "dataGridViewXDSThuocXacNhan";
	  this.dataGridViewXDSThuocXacNhan.ReadOnly = true;
	  this.dataGridViewXDSThuocXacNhan.Size = new System.Drawing.Size(913, 567);
	  this.dataGridViewXDSThuocXacNhan.TabIndex = 0;
	  // 
	  // btnXXemBanIn
	  // 
	  this.btnXXemBanIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemBanIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemBanIn.Location = new System.Drawing.Point(12, 513);
	  this.btnXXemBanIn.Name = "btnXXemBanIn";
	  this.btnXXemBanIn.Size = new System.Drawing.Size(158, 23);
	  this.btnXXemBanIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemBanIn.TabIndex = 3;
	  this.btnXXemBanIn.Text = "Xem bản in";
	  this.btnXXemBanIn.Click += new System.EventHandler(this.btnXXemBanIn_Click);
	  // 
	  // FormThemDonXacNhan
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1284, 616);
	  this.Controls.Add(this.btnXXemBanIn);
	  this.Controls.Add(this.groupBox7);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.Name = "FormThemDonXacNhan";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "FormThemDonXacNhan";
	  this.Load += new System.EventHandler(this.FormThemDonXacNhan_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.groupBox6.ResumeLayout(false);
	  this.groupBox5.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputNgaySinh)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox7.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDSThuocXacNhan)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.ButtonX btnXThemThuoc;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTenThuoc;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXHoTen;
	private System.Windows.Forms.GroupBox groupBox4;
	private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputNgaySinh;
	private System.Windows.Forms.GroupBox groupBox5;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXSoCMTND;
	private System.Windows.Forms.GroupBox groupBox6;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXHoKhauThuongTru;
	private System.Windows.Forms.GroupBox groupBox7;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXDSThuocXacNhan;
	private DevComponents.DotNetBar.ButtonX btnXXemBanIn;
  }
}