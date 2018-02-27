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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXemThongTinTienNo));
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.btnXXacNhanTienNo = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.labelXTenKhachHang = new DevComponents.DotNetBar.LabelX();
	  this.grpTienNoHienTai = new System.Windows.Forms.GroupBox();
	  this.labelXTienNoHienTai = new DevComponents.DotNetBar.LabelX();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXLichSuTienNo = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.panelEx1.SuspendLayout();
	  this.groupBox3.SuspendLayout();
	  this.grpTienNoHienTai.SuspendLayout();
	  this.groupBox1.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuTienNo)).BeginInit();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.tableLayoutPanel1);
	  this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.panelEx1.Location = new System.Drawing.Point(0, 0);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(1205, 493);
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
	  this.btnXXacNhanTienNo.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXXacNhanTienNo.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXXacNhanTienNo.Location = new System.Drawing.Point(527, 435);
	  this.btnXXacNhanTienNo.Name = "btnXXacNhanTienNo";
	  this.btnXXacNhanTienNo.Size = new System.Drawing.Size(150, 35);
	  this.btnXXacNhanTienNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXacNhanTienNo.TabIndex = 2;
	  this.btnXXacNhanTienNo.Text = "Xác nhận";
	  this.btnXXacNhanTienNo.Click += new System.EventHandler(this.btnXXacNhanTienNo_Click);
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.labelXTenKhachHang);
	  this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox3.Location = new System.Drawing.Point(33, 23);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(468, 46);
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
	  this.labelXTenKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.labelXTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXTenKhachHang.Location = new System.Drawing.Point(3, 16);
	  this.labelXTenKhachHang.Name = "labelXTenKhachHang";
	  this.labelXTenKhachHang.Size = new System.Drawing.Size(462, 27);
	  this.labelXTenKhachHang.TabIndex = 0;
	  this.labelXTenKhachHang.Text = "Nguyễn Văn A";
	  // 
	  // grpTienNoHienTai
	  // 
	  this.grpTienNoHienTai.Controls.Add(this.labelXTienNoHienTai);
	  this.grpTienNoHienTai.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpTienNoHienTai.Location = new System.Drawing.Point(703, 23);
	  this.grpTienNoHienTai.Name = "grpTienNoHienTai";
	  this.grpTienNoHienTai.Size = new System.Drawing.Size(468, 46);
	  this.grpTienNoHienTai.TabIndex = 1;
	  this.grpTienNoHienTai.TabStop = false;
	  this.grpTienNoHienTai.Text = "Tiền nợ hiện tại";
	  // 
	  // labelXTienNoHienTai
	  // 
	  // 
	  // 
	  // 
	  this.labelXTienNoHienTai.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXTienNoHienTai.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.labelXTienNoHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXTienNoHienTai.Location = new System.Drawing.Point(3, 16);
	  this.labelXTienNoHienTai.Name = "labelXTienNoHienTai";
	  this.labelXTienNoHienTai.Size = new System.Drawing.Size(462, 27);
	  this.labelXTienNoHienTai.TabIndex = 0;
	  this.labelXTienNoHienTai.Text = "100.000.000 đ";
	  // 
	  // groupBox1
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 5);
	  this.groupBox1.Controls.Add(this.dataGridViewXLichSuTienNo);
	  this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox1.Location = new System.Drawing.Point(33, 75);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(1138, 344);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Thông tin chi tiết";
	  // 
	  // dataGridViewXLichSuTienNo
	  // 
	  this.dataGridViewXLichSuTienNo.AllowUserToAddRows = false;
	  this.dataGridViewXLichSuTienNo.AllowUserToDeleteRows = false;
	  this.dataGridViewXLichSuTienNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXLichSuTienNo.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXLichSuTienNo.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dataGridViewXLichSuTienNo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXLichSuTienNo.Location = new System.Drawing.Point(3, 16);
	  this.dataGridViewXLichSuTienNo.Name = "dataGridViewXLichSuTienNo";
	  this.dataGridViewXLichSuTienNo.ReadOnly = true;
	  this.dataGridViewXLichSuTienNo.Size = new System.Drawing.Size(1132, 325);
	  this.dataGridViewXLichSuTienNo.TabIndex = 0;
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 7;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.btnXXacNhanTienNo, 3, 4);
	  this.tableLayoutPanel1.Controls.Add(this.grpTienNoHienTai, 5, 1);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 6;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(1205, 493);
	  this.tableLayoutPanel1.TabIndex = 3;
	  // 
	  // FormXemThongTinTienNo
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1205, 493);
	  this.Controls.Add(this.panelEx1);
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.MinimumSize = new System.Drawing.Size(1221, 532);
	  this.Name = "FormXemThongTinTienNo";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Thông tin chi tiết";
	  this.Load += new System.EventHandler(this.FormXemThongTinTienNo_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.groupBox3.ResumeLayout(false);
	  this.grpTienNoHienTai.ResumeLayout(false);
	  this.groupBox1.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXLichSuTienNo)).EndInit();
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXLichSuTienNo;
	private System.Windows.Forms.GroupBox grpTienNoHienTai;
	private DevComponents.DotNetBar.LabelX labelXTienNoHienTai;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.LabelX labelXTenKhachHang;
	private DevComponents.DotNetBar.ButtonX btnXXacNhanTienNo;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}