namespace THUOCBAC.FormChucNang {
  partial class FormXemThongTinTienNo {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.btnXXacNhanTienNo = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.labelXTenKhachHang = new DevComponents.DotNetBar.LabelX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.labelXTienNoHienTai = new DevComponents.DotNetBar.LabelX();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXLichSuTienNo = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.panelEx1.SuspendLayout();
	  this.groupBox3.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.groupBox1.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuTienNo)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.btnXXacNhanTienNo);
	  this.panelEx1.Controls.Add(this.groupBox3);
	  this.panelEx1.Controls.Add(this.groupBox2);
	  this.panelEx1.Controls.Add(this.groupBox1);
	  this.panelEx1.Location = new System.Drawing.Point(0, 0);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(1206, 494);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 0;
	  // 
	  // btnXXacNhanTienNo
	  // 
	  this.btnXXacNhanTienNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXacNhanTienNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXacNhanTienNo.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXXacNhanTienNo.Location = new System.Drawing.Point(535, 422);
	  this.btnXXacNhanTienNo.Name = "btnXXacNhanTienNo";
	  this.btnXXacNhanTienNo.Size = new System.Drawing.Size(128, 33);
	  this.btnXXacNhanTienNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXacNhanTienNo.TabIndex = 2;
	  this.btnXXacNhanTienNo.Text = "Xác nhận";
	  this.btnXXacNhanTienNo.Click += new System.EventHandler(this.btnXXacNhanTienNo_Click);
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.labelXTenKhachHang);
	  this.groupBox3.Location = new System.Drawing.Point(12, 12);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(444, 52);
	  this.groupBox3.TabIndex = 1;
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
	  this.labelXTenKhachHang.Size = new System.Drawing.Size(412, 23);
	  this.labelXTenKhachHang.TabIndex = 0;
	  this.labelXTenKhachHang.Text = "Nguyễn Văn A";
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.labelXTienNoHienTai);
	  this.groupBox2.Location = new System.Drawing.Point(749, 12);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(444, 52);
	  this.groupBox2.TabIndex = 1;
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
	  this.labelXTienNoHienTai.Size = new System.Drawing.Size(412, 23);
	  this.labelXTienNoHienTai.TabIndex = 0;
	  this.labelXTienNoHienTai.Text = "100.000.000 đ";
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.dataGridViewXLichSuTienNo);
	  this.groupBox1.Location = new System.Drawing.Point(12, 70);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(1181, 353);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Thông tin chi tiết";
	  // 
	  // dataGridViewXLichSuTienNo
	  // 
	  this.dataGridViewXLichSuTienNo.AllowUserToAddRows = false;
	  this.dataGridViewXLichSuTienNo.AllowUserToDeleteRows = false;
	  this.dataGridViewXLichSuTienNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXLichSuTienNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXLichSuTienNo.DefaultCellStyle = dataGridViewCellStyle2;
	  this.dataGridViewXLichSuTienNo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
	  this.dataGridViewXLichSuTienNo.Location = new System.Drawing.Point(7, 19);
	  this.dataGridViewXLichSuTienNo.Name = "dataGridViewXLichSuTienNo";
	  this.dataGridViewXLichSuTienNo.ReadOnly = true;
	  this.dataGridViewXLichSuTienNo.Size = new System.Drawing.Size(1168, 327);
	  this.dataGridViewXLichSuTienNo.TabIndex = 0;
	  // 
	  // FormXemThongTinTienNo
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1205, 493);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "FormXemThongTinTienNo";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Thông tin chi tiết";
	  this.Load += new System.EventHandler(this.FormXemThongTinTienNo_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.groupBox1.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuTienNo)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXLichSuTienNo;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.LabelX labelXTienNoHienTai;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.LabelX labelXTenKhachHang;
	private DevComponents.DotNetBar.ButtonX btnXXacNhanTienNo;
  }
}