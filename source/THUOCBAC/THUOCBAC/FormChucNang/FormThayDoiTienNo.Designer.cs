namespace THUOCBAC.FormChucNang {
  partial class FormThayDoiTienNo {
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
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.line1 = new DevComponents.DotNetBar.Controls.Line();
	  this.btnXHuyBo = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.comboBoxExTuyChon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.comboItem2 = new DevComponents.Editors.ComboItem();
	  this.comboItem1 = new DevComponents.Editors.ComboItem();
	  this.groupBoxSoTienCuThe = new System.Windows.Forms.GroupBox();
	  this.numericUpDownTienSuaThanh = new System.Windows.Forms.NumericUpDown();
	  this.btnXSuaTienNoHienTai = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.labelXTenKhachHang = new DevComponents.DotNetBar.LabelX();
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.labelXSauKhiThayDoi = new DevComponents.DotNetBar.LabelX();
	  this.groupBoxChiTietThayDoi = new System.Windows.Forms.GroupBox();
	  this.labelXChiTietThayDoi = new DevComponents.DotNetBar.LabelX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.labelXTienNoHienTai = new DevComponents.DotNetBar.LabelX();
	  this.comboItem3 = new DevComponents.Editors.ComboItem();
	  this.panelEx1.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  this.groupBoxSoTienCuThe.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTienSuaThanh)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBox6.SuspendLayout();
	  this.groupBoxChiTietThayDoi.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.line1);
	  this.panelEx1.Controls.Add(this.btnXHuyBo);
	  this.panelEx1.Controls.Add(this.groupBox4);
	  this.panelEx1.Controls.Add(this.groupBoxSoTienCuThe);
	  this.panelEx1.Controls.Add(this.btnXSuaTienNoHienTai);
	  this.panelEx1.Controls.Add(this.groupBox3);
	  this.panelEx1.Controls.Add(this.groupBox6);
	  this.panelEx1.Controls.Add(this.groupBoxChiTietThayDoi);
	  this.panelEx1.Controls.Add(this.groupBox2);
	  this.panelEx1.Location = new System.Drawing.Point(0, 0);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(559, 379);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 0;
	  // 
	  // line1
	  // 
	  this.line1.Location = new System.Drawing.Point(12, 141);
	  this.line1.Name = "line1";
	  this.line1.Size = new System.Drawing.Size(532, 56);
	  this.line1.TabIndex = 8;
	  this.line1.Text = "line1";
	  // 
	  // btnXHuyBo
	  // 
	  this.btnXHuyBo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXHuyBo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXHuyBo.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXHuyBo.Location = new System.Drawing.Point(286, 322);
	  this.btnXHuyBo.Name = "btnXHuyBo";
	  this.btnXHuyBo.Size = new System.Drawing.Size(181, 44);
	  this.btnXHuyBo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXHuyBo.TabIndex = 7;
	  this.btnXHuyBo.Text = "Hủy bỏ";
	  this.btnXHuyBo.Click += new System.EventHandler(this.btnXHuyBo_Click);
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.comboBoxExTuyChon);
	  this.groupBox4.Location = new System.Drawing.Point(12, 70);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(245, 65);
	  this.groupBox4.TabIndex = 6;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Tùy chọn";
	  // 
	  // comboBoxExTuyChon
	  // 
	  this.comboBoxExTuyChon.DisplayMember = "Text";
	  this.comboBoxExTuyChon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxExTuyChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	  this.comboBoxExTuyChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.comboBoxExTuyChon.FormattingEnabled = true;
	  this.comboBoxExTuyChon.ItemHeight = 20;
	  this.comboBoxExTuyChon.Items.AddRange(new object[] {
            this.comboItem2,
            this.comboItem3,
            this.comboItem1});
	  this.comboBoxExTuyChon.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxExTuyChon.Name = "comboBoxExTuyChon";
	  this.comboBoxExTuyChon.Size = new System.Drawing.Size(232, 26);
	  this.comboBoxExTuyChon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxExTuyChon.TabIndex = 0;
	  this.comboBoxExTuyChon.DropDownClosed += new System.EventHandler(this.comboBoxExTuyChon_DropDownClosed);
	  // 
	  // comboItem2
	  // 
	  this.comboItem2.Text = "Đã trả";
	  this.comboItem2.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // comboItem1
	  // 
	  this.comboItem1.Text = "Sửa thành";
	  this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // groupBoxSoTienCuThe
	  // 
	  this.groupBoxSoTienCuThe.Controls.Add(this.numericUpDownTienSuaThanh);
	  this.groupBoxSoTienCuThe.Location = new System.Drawing.Point(263, 70);
	  this.groupBoxSoTienCuThe.Name = "groupBoxSoTienCuThe";
	  this.groupBoxSoTienCuThe.Size = new System.Drawing.Size(281, 65);
	  this.groupBoxSoTienCuThe.TabIndex = 5;
	  this.groupBoxSoTienCuThe.TabStop = false;
	  this.groupBoxSoTienCuThe.Text = "Số tiền khách hàng trả";
	  // 
	  // numericUpDownTienSuaThanh
	  // 
	  this.numericUpDownTienSuaThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.numericUpDownTienSuaThanh.ForeColor = System.Drawing.Color.Red;
	  this.numericUpDownTienSuaThanh.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
	  this.numericUpDownTienSuaThanh.Location = new System.Drawing.Point(7, 20);
	  this.numericUpDownTienSuaThanh.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
	  this.numericUpDownTienSuaThanh.Name = "numericUpDownTienSuaThanh";
	  this.numericUpDownTienSuaThanh.Size = new System.Drawing.Size(232, 26);
	  this.numericUpDownTienSuaThanh.TabIndex = 0;
	  this.numericUpDownTienSuaThanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.numericUpDownTienSuaThanh.ThousandsSeparator = true;
	  this.numericUpDownTienSuaThanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownTienSuaThanh_KeyDown);
	  // 
	  // btnXSuaTienNoHienTai
	  // 
	  this.btnXSuaTienNoHienTai.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXSuaTienNoHienTai.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXSuaTienNoHienTai.Enabled = false;
	  this.btnXSuaTienNoHienTai.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXSuaTienNoHienTai.Location = new System.Drawing.Point(86, 322);
	  this.btnXSuaTienNoHienTai.Name = "btnXSuaTienNoHienTai";
	  this.btnXSuaTienNoHienTai.Size = new System.Drawing.Size(181, 44);
	  this.btnXSuaTienNoHienTai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXSuaTienNoHienTai.TabIndex = 4;
	  this.btnXSuaTienNoHienTai.Text = "Xác nhận thay đổi";
	  this.btnXSuaTienNoHienTai.Click += new System.EventHandler(this.btnXSuaTienNoHienTai_Click);
	  this.btnXSuaTienNoHienTai.MouseHover += new System.EventHandler(this.btnXSuaTienNoHienTai_MouseHover);
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.labelXTenKhachHang);
	  this.groupBox3.Location = new System.Drawing.Point(12, 12);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(245, 52);
	  this.groupBox3.TabIndex = 2;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Tên khách hàng";
	  // 
	  // labelXTenKhachHang
	  // 
	  // 
	  // 
	  // 
	  this.labelXTenKhachHang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXTenKhachHang.Location = new System.Drawing.Point(7, 20);
	  this.labelXTenKhachHang.Name = "labelXTenKhachHang";
	  this.labelXTenKhachHang.Size = new System.Drawing.Size(232, 23);
	  this.labelXTenKhachHang.TabIndex = 0;
	  this.labelXTenKhachHang.Text = "Nguyễn Văn A";
	  // 
	  // groupBox6
	  // 
	  this.groupBox6.Controls.Add(this.labelXSauKhiThayDoi);
	  this.groupBox6.Location = new System.Drawing.Point(12, 261);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(532, 52);
	  this.groupBox6.TabIndex = 3;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Tiền nợ sau khi thay đổi";
	  // 
	  // labelXSauKhiThayDoi
	  // 
	  // 
	  // 
	  // 
	  this.labelXSauKhiThayDoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXSauKhiThayDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXSauKhiThayDoi.Location = new System.Drawing.Point(7, 20);
	  this.labelXSauKhiThayDoi.Name = "labelXSauKhiThayDoi";
	  this.labelXSauKhiThayDoi.Size = new System.Drawing.Size(519, 35);
	  this.labelXSauKhiThayDoi.TabIndex = 0;
	  this.labelXSauKhiThayDoi.Text = "100.000.000 đ   +   200.000.000 đ   =   300.000.000 đ";
	  // 
	  // groupBoxChiTietThayDoi
	  // 
	  this.groupBoxChiTietThayDoi.Controls.Add(this.labelXChiTietThayDoi);
	  this.groupBoxChiTietThayDoi.Location = new System.Drawing.Point(12, 203);
	  this.groupBoxChiTietThayDoi.Name = "groupBoxChiTietThayDoi";
	  this.groupBoxChiTietThayDoi.Size = new System.Drawing.Size(532, 52);
	  this.groupBoxChiTietThayDoi.TabIndex = 3;
	  this.groupBoxChiTietThayDoi.TabStop = false;
	  this.groupBoxChiTietThayDoi.Text = "Chi tiết thay đổi (Di chuột vào đây để hiển thị chi tiết)";
	  this.groupBoxChiTietThayDoi.MouseHover += new System.EventHandler(this.groupBoxChiTietThayDoi_MouseHover);
	  // 
	  // labelXChiTietThayDoi
	  // 
	  // 
	  // 
	  // 
	  this.labelXChiTietThayDoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXChiTietThayDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXChiTietThayDoi.Location = new System.Drawing.Point(7, 20);
	  this.labelXChiTietThayDoi.Name = "labelXChiTietThayDoi";
	  this.labelXChiTietThayDoi.Size = new System.Drawing.Size(519, 23);
	  this.labelXChiTietThayDoi.TabIndex = 0;
	  this.labelXChiTietThayDoi.Text = "Khách hàng đã trả 100.000.000 đ";
	  this.labelXChiTietThayDoi.MouseHover += new System.EventHandler(this.labelXChiTietThayDoi_MouseHover);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.labelXTienNoHienTai);
	  this.groupBox2.Location = new System.Drawing.Point(263, 12);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(281, 52);
	  this.groupBox2.TabIndex = 3;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Tiền nợ hiện tại";
	  // 
	  // labelXTienNoHienTai
	  // 
	  // 
	  // 
	  // 
	  this.labelXTienNoHienTai.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTienNoHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXTienNoHienTai.Location = new System.Drawing.Point(7, 20);
	  this.labelXTienNoHienTai.Name = "labelXTienNoHienTai";
	  this.labelXTienNoHienTai.Size = new System.Drawing.Size(232, 23);
	  this.labelXTienNoHienTai.TabIndex = 0;
	  this.labelXTienNoHienTai.Text = "100.000.000 đ";
	  // 
	  // comboItem3
	  // 
	  this.comboItem3.Text = "Vay thêm";
	  this.comboItem3.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // FormThayDoiTienNo
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(559, 379);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "FormThayDoiTienNo";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Thay đổi tiền nợ";
	  this.Load += new System.EventHandler(this.FormThayDoiTienNo_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  this.groupBoxSoTienCuThe.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTienSuaThanh)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox6.ResumeLayout(false);
	  this.groupBoxChiTietThayDoi.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.LabelX labelXTenKhachHang;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.LabelX labelXTienNoHienTai;
	private DevComponents.DotNetBar.ButtonX btnXSuaTienNoHienTai;
	private System.Windows.Forms.GroupBox groupBoxSoTienCuThe;
	private System.Windows.Forms.NumericUpDown numericUpDownTienSuaThanh;
	private System.Windows.Forms.GroupBox groupBox4;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExTuyChon;
	private DevComponents.Editors.ComboItem comboItem1;
	private System.Windows.Forms.GroupBox groupBoxChiTietThayDoi;
	private DevComponents.DotNetBar.LabelX labelXChiTietThayDoi;
	private System.Windows.Forms.GroupBox groupBox6;
	private DevComponents.DotNetBar.LabelX labelXSauKhiThayDoi;
	private DevComponents.Editors.ComboItem comboItem2;
	private DevComponents.DotNetBar.ButtonX btnXHuyBo;
	private DevComponents.DotNetBar.Controls.Line line1;
	private DevComponents.Editors.ComboItem comboItem3;
  }
}