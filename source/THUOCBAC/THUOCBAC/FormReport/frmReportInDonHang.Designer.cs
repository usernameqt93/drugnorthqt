namespace THUOCBAC.FormReport {
  partial class frmReportInDonHang {
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
	  this.components = new System.ComponentModel.Container();
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportInDonHang));
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXPrint = new DevComponents.DotNetBar.ButtonX();
	  this.reportViewerChiTietDonHang = new Microsoft.Reporting.WinForms.ReportViewer();
	  this.timer1 = new System.Windows.Forms.Timer(this.components);
	  this.panelEx1.SuspendLayout();
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
	  this.panelEx1.Size = new System.Drawing.Size(964, 697);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 0;
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 5;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.btnXPrint, 2, 2);
	  this.tableLayoutPanel1.Controls.Add(this.reportViewerChiTietDonHang, 0, 0);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 3;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 697);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // btnXPrint
	  // 
	  this.btnXPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXPrint.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXPrint.Image = global::THUOCBAC.Properties.Resources.print;
	  this.btnXPrint.Location = new System.Drawing.Point(392, 659);
	  this.btnXPrint.Name = "btnXPrint";
	  this.btnXPrint.Size = new System.Drawing.Size(180, 35);
	  this.btnXPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXPrint.TabIndex = 0;
	  this.btnXPrint.Text = "Bắt đầu in";
	  this.btnXPrint.Click += new System.EventHandler(this.btnXPrint_Click);
	  // 
	  // reportViewerChiTietDonHang
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.reportViewerChiTietDonHang, 5);
	  this.reportViewerChiTietDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.reportViewerChiTietDonHang.Location = new System.Drawing.Point(3, 3);
	  this.reportViewerChiTietDonHang.Name = "reportViewerChiTietDonHang";
	  this.tableLayoutPanel1.SetRowSpan(this.reportViewerChiTietDonHang, 2);
	  this.reportViewerChiTietDonHang.Size = new System.Drawing.Size(958, 650);
	  this.reportViewerChiTietDonHang.TabIndex = 1;
	  // 
	  // timer1
	  // 
	  this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
	  // 
	  // frmReportInDonHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(964, 697);
	  this.Controls.Add(this.panelEx1);
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.MinimumSize = new System.Drawing.Size(980, 736);
	  this.Name = "frmReportInDonHang";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "In đơn hàng";
	  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
	  this.Load += new System.EventHandler(this.frmReportInDonHang_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.ButtonX btnXPrint;
	private Microsoft.Reporting.WinForms.ReportViewer reportViewerChiTietDonHang;
	private System.Windows.Forms.Timer timer1;
  }
}