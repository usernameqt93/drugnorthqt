namespace THUOCBAC.FormThongBao {
  partial class FormThongBaoHetHan {
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
	  this.labelXThongBao = new DevComponents.DotNetBar.LabelX();
	  this.btnXThoatChuongTrinh = new DevComponents.DotNetBar.ButtonX();
	  this.panelEx1.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // panelEx1
	  // 
	  this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
	  this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.panelEx1.Controls.Add(this.btnXThoatChuongTrinh);
	  this.panelEx1.Controls.Add(this.labelXThongBao);
	  this.panelEx1.Location = new System.Drawing.Point(1, 1);
	  this.panelEx1.Name = "panelEx1";
	  this.panelEx1.Size = new System.Drawing.Size(906, 287);
	  this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
	  this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
	  this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
	  this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
	  this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
	  this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
	  this.panelEx1.Style.GradientAngle = 90;
	  this.panelEx1.TabIndex = 0;
	  // 
	  // labelXThongBao
	  // 
	  // 
	  // 
	  // 
	  this.labelXThongBao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelXThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelXThongBao.Image = global::THUOCBAC.Properties.Resources.notification_icon128x128;
	  this.labelXThongBao.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
	  this.labelXThongBao.Location = new System.Drawing.Point(11, 11);
	  this.labelXThongBao.Name = "labelXThongBao";
	  this.labelXThongBao.Size = new System.Drawing.Size(884, 209);
	  this.labelXThongBao.TabIndex = 0;
	  this.labelXThongBao.Text = "labelX1";
	  this.labelXThongBao.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // btnXThoatChuongTrinh
	  // 
	  this.btnXThoatChuongTrinh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThoatChuongTrinh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThoatChuongTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.btnXThoatChuongTrinh.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXThoatChuongTrinh.Location = new System.Drawing.Point(359, 226);
	  this.btnXThoatChuongTrinh.Name = "btnXThoatChuongTrinh";
	  this.btnXThoatChuongTrinh.Size = new System.Drawing.Size(190, 39);
	  this.btnXThoatChuongTrinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThoatChuongTrinh.TabIndex = 1;
	  this.btnXThoatChuongTrinh.Text = "Thoát chương trình";
	  this.btnXThoatChuongTrinh.Click += new System.EventHandler(this.btnXThoatChuongTrinh_Click);
	  // 
	  // FormThongBaoHetHan
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(908, 290);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormThongBaoHetHan";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Thông báo hết hạn";
	  this.Load += new System.EventHandler(this.FormThongBaoHetHan_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private DevComponents.DotNetBar.LabelX labelXThongBao;
	private DevComponents.DotNetBar.ButtonX btnXThoatChuongTrinh;
  }
}