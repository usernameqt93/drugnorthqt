namespace THUOCBAC.FormCaiDat {
  partial class frmLoginOption {
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
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginOption));
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.txtXPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.btnXExit = new DevComponents.DotNetBar.ButtonX();
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
	  this.panelEx1.Size = new System.Drawing.Size(710, 135);
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
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.txtXPassword, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.btnXExit, 2, 3);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 6;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 135);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // txtXPassword
	  // 
	  // 
	  // 
	  // 
	  this.txtXPassword.Border.Class = "TextBoxBorder";
	  this.txtXPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.tableLayoutPanel1.SetColumnSpan(this.txtXPassword, 3);
	  this.txtXPassword.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.txtXPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.txtXPassword.Location = new System.Drawing.Point(33, 23);
	  this.txtXPassword.Name = "txtXPassword";
	  this.txtXPassword.Size = new System.Drawing.Size(644, 29);
	  this.txtXPassword.TabIndex = 0;
	  this.txtXPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  this.txtXPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXPassword_KeyDown);
	  // 
	  // btnXExit
	  // 
	  this.btnXExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXExit.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXExit.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXExit.Location = new System.Drawing.Point(280, 74);
	  this.btnXExit.Name = "btnXExit";
	  this.btnXExit.Size = new System.Drawing.Size(150, 35);
	  this.btnXExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXExit.TabIndex = 1;
	  this.btnXExit.Text = "Close";
	  this.btnXExit.Click += new System.EventHandler(this.btnXExit_Click);
	  // 
	  // frmLoginOption
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(710, 135);
	  this.Controls.Add(this.panelEx1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmLoginOption";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Support";
	  this.Load += new System.EventHandler(this.frmLoginOption_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXPassword;
	private DevComponents.DotNetBar.ButtonX btnXExit;
  }
}