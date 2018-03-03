namespace THUOCBAC.FormCaiDat {
  partial class frmOptionForQuocTuan {
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
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXSave = new DevComponents.DotNetBar.ButtonX();
	  this.btnxCancel = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
	  this.rdoXemBanInCach2 = new System.Windows.Forms.RadioButton();
	  this.rdoXemBanInCach1 = new System.Windows.Forms.RadioButton();
	  this.panelEx1.SuspendLayout();
	  this.tlpMain.SuspendLayout();
	  this.groupBox1.SuspendLayout();
	  this.tableLayoutPanel1.SuspendLayout();
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
	  this.panelEx1.Size = new System.Drawing.Size(1045, 514);
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
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.Controls.Add(this.btnXSave, 2, 3);
	  this.tlpMain.Controls.Add(this.btnxCancel, 4, 3);
	  this.tlpMain.Controls.Add(this.groupBox1, 1, 1);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 5;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(1045, 514);
	  this.tlpMain.TabIndex = 0;
	  // 
	  // btnXSave
	  // 
	  this.btnXSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXSave.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXSave.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXSave.Location = new System.Drawing.Point(364, 456);
	  this.btnXSave.Name = "btnXSave";
	  this.btnXSave.Size = new System.Drawing.Size(150, 35);
	  this.btnXSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXSave.TabIndex = 2;
	  this.btnXSave.Text = "Save";
	  this.btnXSave.Click += new System.EventHandler(this.btnXSave_Click);
	  // 
	  // btnxCancel
	  // 
	  this.btnxCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnxCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnxCancel.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnxCancel.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnxCancel.Location = new System.Drawing.Point(530, 456);
	  this.btnxCancel.Name = "btnxCancel";
	  this.btnxCancel.Size = new System.Drawing.Size(150, 35);
	  this.btnxCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnxCancel.TabIndex = 3;
	  this.btnxCancel.Text = "Cancel";
	  this.btnxCancel.Click += new System.EventHandler(this.btnxCancel_Click);
	  // 
	  // groupBox1
	  // 
	  this.tlpMain.SetColumnSpan(this.groupBox1, 2);
	  this.groupBox1.Controls.Add(this.tableLayoutPanel1);
	  this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox1.Location = new System.Drawing.Point(33, 23);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(481, 69);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Tùy chọn cách xem bản in";
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 2;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.Controls.Add(this.richTextBoxEx1, 1, 0);
	  this.tableLayoutPanel1.Controls.Add(this.rdoXemBanInCach2, 0, 1);
	  this.tableLayoutPanel1.Controls.Add(this.rdoXemBanInCach1, 0, 0);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 2;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 50);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // richTextBoxEx1
	  // 
	  // 
	  // 
	  // 
	  this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
	  this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.richTextBoxEx1.Location = new System.Drawing.Point(203, 3);
	  this.richTextBoxEx1.Name = "richTextBoxEx1";
	  this.tableLayoutPanel1.SetRowSpan(this.richTextBoxEx1, 2);
	  this.richTextBoxEx1.Size = new System.Drawing.Size(269, 44);
	  this.richTextBoxEx1.TabIndex = 1;
	  // 
	  // rdoXemBanInCach2
	  // 
	  this.rdoXemBanInCach2.AutoSize = true;
	  this.rdoXemBanInCach2.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.rdoXemBanInCach2.Location = new System.Drawing.Point(3, 28);
	  this.rdoXemBanInCach2.Name = "rdoXemBanInCach2";
	  this.rdoXemBanInCach2.Size = new System.Drawing.Size(194, 19);
	  this.rdoXemBanInCach2.TabIndex = 1;
	  this.rdoXemBanInCach2.TabStop = true;
	  this.rdoXemBanInCach2.Text = "2018030323h33XemBanInCach2";
	  this.rdoXemBanInCach2.UseVisualStyleBackColor = true;
	  // 
	  // rdoXemBanInCach1
	  // 
	  this.rdoXemBanInCach1.AutoSize = true;
	  this.rdoXemBanInCach1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.rdoXemBanInCach1.Location = new System.Drawing.Point(3, 3);
	  this.rdoXemBanInCach1.Name = "rdoXemBanInCach1";
	  this.rdoXemBanInCach1.Size = new System.Drawing.Size(194, 19);
	  this.rdoXemBanInCach1.TabIndex = 0;
	  this.rdoXemBanInCach1.TabStop = true;
	  this.rdoXemBanInCach1.Text = "Cách 1";
	  this.rdoXemBanInCach1.UseVisualStyleBackColor = true;
	  // 
	  // frmOptionForQuocTuan
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1045, 514);
	  this.Controls.Add(this.panelEx1);
	  this.Name = "frmOptionForQuocTuan";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "Main option - Power by Pham Quoc Tuan - 01667 002 325";
	  this.Load += new System.EventHandler(this.frmOptionForQuocTuan_Load);
	  this.Shown += new System.EventHandler(this.frmOptionForQuocTuan_Shown);
	  this.panelEx1.ResumeLayout(false);
	  this.tlpMain.ResumeLayout(false);
	  this.groupBox1.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.tableLayoutPanel1.PerformLayout();
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.TableLayoutPanel tlpMain;
	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
	private System.Windows.Forms.RadioButton rdoXemBanInCach2;
	private System.Windows.Forms.RadioButton rdoXemBanInCach1;
	private DevComponents.DotNetBar.ButtonX btnXSave;
	private DevComponents.DotNetBar.ButtonX btnxCancel;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}