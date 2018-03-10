namespace THUOCBAC.FormChucNang {
  partial class frmAddInfoCustomerToOrder {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

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
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddInfoCustomerToOrder));
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXDisplayLayout = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXChooseCustomer = new DevComponents.DotNetBar.ButtonX();
	  this.txtXNameCustomer = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.btnXShowDetailDebt = new DevComponents.DotNetBar.ButtonX();
	  this.numericUpDownTienNo = new System.Windows.Forms.NumericUpDown();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.chkDisplayPhone = new DevComponents.DotNetBar.Controls.CheckBoxX();
	  this.txtPhone = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.btnXUpdateDebt = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.cboKhoGiay = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.groupBox5 = new System.Windows.Forms.GroupBox();
	  this.dateTimeInputThoiGian = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.nudCopyNumber = new System.Windows.Forms.NumericUpDown();
	  this.lblDuongKeNgang = new System.Windows.Forms.Label();
	  this.panelEx1.SuspendLayout();
	  this.tlpMain.SuspendLayout();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTienNo)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  this.groupBox5.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputThoiGian)).BeginInit();
	  this.groupBox6.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.nudCopyNumber)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.tlpMain);
	  this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.panelEx1.Location = new System.Drawing.Point(0, 0);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(412, 461);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 0;
	  // 
	  // tlpMain
	  // 
	  this.tlpMain.ColumnCount = 7;
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.Controls.Add(this.btnXDisplayLayout, 2, 2);
	  this.tlpMain.Controls.Add(this.groupBox1, 2, 5);
	  this.tlpMain.Controls.Add(this.groupBox2, 2, 6);
	  this.tlpMain.Controls.Add(this.groupBox3, 2, 7);
	  this.tlpMain.Controls.Add(this.btnXUpdateDebt, 2, 8);
	  this.tlpMain.Controls.Add(this.groupBox4, 2, 1);
	  this.tlpMain.Controls.Add(this.groupBox5, 3, 1);
	  this.tlpMain.Controls.Add(this.groupBox6, 4, 1);
	  this.tlpMain.Controls.Add(this.lblDuongKeNgang, 0, 4);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 11;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(412, 461);
	  this.tlpMain.TabIndex = 0;
	  // 
	  // btnXDisplayLayout
	  // 
	  this.btnXDisplayLayout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXDisplayLayout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.tlpMain.SetColumnSpan(this.btnXDisplayLayout, 3);
	  this.btnXDisplayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXDisplayLayout.Image = global::THUOCBAC.Properties.Resources.print;
	  this.btnXDisplayLayout.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
	  this.btnXDisplayLayout.Location = new System.Drawing.Point(36, 83);
	  this.btnXDisplayLayout.Name = "btnXDisplayLayout";
	  this.btnXDisplayLayout.Size = new System.Drawing.Size(340, 63);
	  this.btnXDisplayLayout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXDisplayLayout.TabIndex = 0;
	  this.btnXDisplayLayout.Text = "Hiển thị bản in xem trước";
	  this.btnXDisplayLayout.Click += new System.EventHandler(this.btnXDisplayLayout_Click);
	  // 
	  // groupBox1
	  // 
	  this.tlpMain.SetColumnSpan(this.groupBox1, 3);
	  this.groupBox1.Controls.Add(this.btnXChooseCustomer);
	  this.groupBox1.Controls.Add(this.txtXNameCustomer);
	  this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox1.Location = new System.Drawing.Point(36, 184);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(340, 54);
	  this.groupBox1.TabIndex = 1;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Tên khách hàng (Chọn dưới đây)";
	  // 
	  // btnXChooseCustomer
	  // 
	  this.btnXChooseCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXChooseCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXChooseCustomer.Image = global::THUOCBAC.Properties.Resources.get;
	  this.btnXChooseCustomer.Location = new System.Drawing.Point(216, 20);
	  this.btnXChooseCustomer.Name = "btnXChooseCustomer";
	  this.btnXChooseCustomer.Size = new System.Drawing.Size(118, 26);
	  this.btnXChooseCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXChooseCustomer.TabIndex = 1;
	  this.btnXChooseCustomer.Text = "Chọn...";
	  this.btnXChooseCustomer.Click += new System.EventHandler(this.btnXChooseCustomer_Click);
	  // 
	  // txtXNameCustomer
	  // 
	  // 
	  // 
	  // 
	  this.txtXNameCustomer.Border.Class = "TextBoxBorder";
	  this.txtXNameCustomer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXNameCustomer.Enabled = false;
	  this.txtXNameCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.txtXNameCustomer.Location = new System.Drawing.Point(7, 20);
	  this.txtXNameCustomer.Name = "txtXNameCustomer";
	  this.txtXNameCustomer.Size = new System.Drawing.Size(203, 26);
	  this.txtXNameCustomer.TabIndex = 0;
	  this.txtXNameCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  // 
	  // groupBox2
	  // 
	  this.tlpMain.SetColumnSpan(this.groupBox2, 3);
	  this.groupBox2.Controls.Add(this.btnXShowDetailDebt);
	  this.groupBox2.Controls.Add(this.numericUpDownTienNo);
	  this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox2.Location = new System.Drawing.Point(36, 244);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(340, 54);
	  this.groupBox2.TabIndex = 2;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Số nợ cũ";
	  // 
	  // btnXShowDetailDebt
	  // 
	  this.btnXShowDetailDebt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXShowDetailDebt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXShowDetailDebt.Enabled = false;
	  this.btnXShowDetailDebt.Location = new System.Drawing.Point(216, 20);
	  this.btnXShowDetailDebt.Name = "btnXShowDetailDebt";
	  this.btnXShowDetailDebt.Size = new System.Drawing.Size(118, 26);
	  this.btnXShowDetailDebt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXShowDetailDebt.TabIndex = 1;
	  this.btnXShowDetailDebt.Text = "Xem chi tiết";
	  this.btnXShowDetailDebt.Click += new System.EventHandler(this.btnXShowDetailDebt_Click);
	  // 
	  // numericUpDownTienNo
	  // 
	  this.numericUpDownTienNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.numericUpDownTienNo.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
	  this.numericUpDownTienNo.Location = new System.Drawing.Point(7, 20);
	  this.numericUpDownTienNo.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
	  this.numericUpDownTienNo.Name = "numericUpDownTienNo";
	  this.numericUpDownTienNo.Size = new System.Drawing.Size(203, 26);
	  this.numericUpDownTienNo.TabIndex = 0;
	  this.numericUpDownTienNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.numericUpDownTienNo.ThousandsSeparator = true;
	  // 
	  // groupBox3
	  // 
	  this.tlpMain.SetColumnSpan(this.groupBox3, 3);
	  this.groupBox3.Controls.Add(this.chkDisplayPhone);
	  this.groupBox3.Controls.Add(this.txtPhone);
	  this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox3.Location = new System.Drawing.Point(36, 304);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(340, 84);
	  this.groupBox3.TabIndex = 3;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Số điện thoại khách hàng";
	  // 
	  // chkDisplayPhone
	  // 
	  // 
	  // 
	  // 
	  this.chkDisplayPhone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.chkDisplayPhone.Location = new System.Drawing.Point(7, 53);
	  this.chkDisplayPhone.Name = "chkDisplayPhone";
	  this.chkDisplayPhone.Size = new System.Drawing.Size(242, 23);
	  this.chkDisplayPhone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.chkDisplayPhone.TabIndex = 1;
	  this.chkDisplayPhone.Text = "Hiển thị số điện thoại in trên đơn hàng";
	  // 
	  // txtPhone
	  // 
	  // 
	  // 
	  // 
	  this.txtPhone.Border.Class = "TextBoxBorder";
	  this.txtPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.txtPhone.Location = new System.Drawing.Point(7, 20);
	  this.txtPhone.Name = "txtPhone";
	  this.txtPhone.Size = new System.Drawing.Size(203, 26);
	  this.txtPhone.TabIndex = 0;
	  this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  // 
	  // btnXUpdateDebt
	  // 
	  this.btnXUpdateDebt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXUpdateDebt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.tlpMain.SetColumnSpan(this.btnXUpdateDebt, 3);
	  this.btnXUpdateDebt.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXUpdateDebt.Enabled = false;
	  this.btnXUpdateDebt.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXUpdateDebt.Location = new System.Drawing.Point(36, 394);
	  this.btnXUpdateDebt.Name = "btnXUpdateDebt";
	  this.btnXUpdateDebt.Size = new System.Drawing.Size(340, 41);
	  this.btnXUpdateDebt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXUpdateDebt.TabIndex = 4;
	  this.btnXUpdateDebt.Text = "Cộng tiền đơn hàng này vào sổ";
	  this.btnXUpdateDebt.Click += new System.EventHandler(this.btnXUpdateDebt_Click);
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.cboKhoGiay);
	  this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox4.Location = new System.Drawing.Point(36, 23);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(120, 54);
	  this.groupBox4.TabIndex = 5;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Tùy chọn khổ giấy";
	  // 
	  // cboKhoGiay
	  // 
	  this.cboKhoGiay.DisplayMember = "Text";
	  this.cboKhoGiay.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.cboKhoGiay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.cboKhoGiay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	  this.cboKhoGiay.FormattingEnabled = true;
	  this.cboKhoGiay.ItemHeight = 14;
	  this.cboKhoGiay.Location = new System.Drawing.Point(3, 16);
	  this.cboKhoGiay.Name = "cboKhoGiay";
	  this.cboKhoGiay.Size = new System.Drawing.Size(114, 20);
	  this.cboKhoGiay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.cboKhoGiay.TabIndex = 0;
	  // 
	  // groupBox5
	  // 
	  this.groupBox5.Controls.Add(this.dateTimeInputThoiGian);
	  this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox5.Location = new System.Drawing.Point(162, 23);
	  this.groupBox5.Name = "groupBox5";
	  this.groupBox5.Size = new System.Drawing.Size(104, 54);
	  this.groupBox5.TabIndex = 6;
	  this.groupBox5.TabStop = false;
	  this.groupBox5.Text = "Thời gian";
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
	  this.dateTimeInputThoiGian.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dateTimeInputThoiGian.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
	  this.dateTimeInputThoiGian.IsPopupCalendarOpen = false;
	  this.dateTimeInputThoiGian.Location = new System.Drawing.Point(3, 16);
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
	  this.dateTimeInputThoiGian.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
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
	  this.dateTimeInputThoiGian.Size = new System.Drawing.Size(98, 20);
	  this.dateTimeInputThoiGian.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.dateTimeInputThoiGian.TabIndex = 0;
	  this.dateTimeInputThoiGian.Value = new System.DateTime(2017, 5, 22, 0, 0, 0, 0);
	  // 
	  // groupBox6
	  // 
	  this.groupBox6.Controls.Add(this.nudCopyNumber);
	  this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox6.Location = new System.Drawing.Point(272, 23);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(104, 54);
	  this.groupBox6.TabIndex = 7;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Số bản muốn in";
	  // 
	  // nudCopyNumber
	  // 
	  this.nudCopyNumber.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.nudCopyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.nudCopyNumber.Location = new System.Drawing.Point(3, 16);
	  this.nudCopyNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
	  this.nudCopyNumber.Name = "nudCopyNumber";
	  this.nudCopyNumber.Size = new System.Drawing.Size(98, 20);
	  this.nudCopyNumber.TabIndex = 0;
	  this.nudCopyNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.nudCopyNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
	  // 
	  // lblDuongKeNgang
	  // 
	  this.lblDuongKeNgang.AutoSize = true;
	  this.tlpMain.SetColumnSpan(this.lblDuongKeNgang, 7);
	  this.lblDuongKeNgang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.lblDuongKeNgang.Location = new System.Drawing.Point(3, 179);
	  this.lblDuongKeNgang.Name = "lblDuongKeNgang";
	  this.lblDuongKeNgang.Size = new System.Drawing.Size(406, 2);
	  this.lblDuongKeNgang.TabIndex = 8;
	  this.lblDuongKeNgang.Text = "label1";
	  // 
	  // frmAddInfoCustomerToOrder
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(412, 461);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmAddInfoCustomerToOrder";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Tùy chỉnh đơn hàng";
	  this.Load += new System.EventHandler(this.frmAddInfoCustomerToOrder_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.tlpMain.ResumeLayout(false);
	  this.tlpMain.PerformLayout();
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTienNo)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  this.groupBox5.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputThoiGian)).EndInit();
	  this.groupBox6.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.nudCopyNumber)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.TableLayoutPanel tlpMain;
	private DevComponents.DotNetBar.ButtonX btnXDisplayLayout;
	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXNameCustomer;
	private DevComponents.DotNetBar.ButtonX btnXChooseCustomer;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.NumericUpDown numericUpDownTienNo;
	private DevComponents.DotNetBar.ButtonX btnXShowDetailDebt;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.Controls.TextBoxX txtPhone;
	private DevComponents.DotNetBar.ButtonX btnXUpdateDebt;
	private DevComponents.DotNetBar.Controls.CheckBoxX chkDisplayPhone;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.GroupBox groupBox6;
	private System.Windows.Forms.NumericUpDown nudCopyNumber;
	private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputThoiGian;
	private DevComponents.DotNetBar.Controls.ComboBoxEx cboKhoGiay;
	private System.Windows.Forms.Label lblDuongKeNgang;
  }
}