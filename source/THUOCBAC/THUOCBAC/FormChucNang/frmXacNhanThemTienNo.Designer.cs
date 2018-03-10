namespace THUOCBAC.FormChucNang {
  partial class frmXacNhanThemTienNo {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXacNhanThemTienNo));
	  this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXAccept = new DevComponents.DotNetBar.ButtonX();
	  this.btnXCancel = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.rtbNote = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.lblXName = new DevComponents.DotNetBar.LabelX();
	  this.dgvXMain = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.lblXDebtCurrent = new DevComponents.DotNetBar.LabelX();
	  this.groupBox5 = new System.Windows.Forms.GroupBox();
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.lblDetailDebt = new DevComponents.DotNetBar.LabelX();
	  this.lblXTongTienDH = new DevComponents.DotNetBar.LabelX();
	  this.lblXDebtUpdate = new DevComponents.DotNetBar.LabelX();
	  this.lblXMessage = new DevComponents.DotNetBar.LabelX();
	  this.panelEx1.SuspendLayout();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.groupBox3.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).BeginInit();
	  this.groupBox4.SuspendLayout();
	  this.groupBox5.SuspendLayout();
	  this.groupBox6.SuspendLayout();
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
	  this.tableLayoutPanel1.ColumnCount = 7;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.btnXAccept, 2, 7);
	  this.tableLayoutPanel1.Controls.Add(this.btnXCancel, 4, 7);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 4);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 3);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 2);
	  this.tableLayoutPanel1.Controls.Add(this.dgvXMain, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox4, 4, 2);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox5, 4, 3);
	  this.tableLayoutPanel1.Controls.Add(this.groupBox6, 4, 4);
	  this.tableLayoutPanel1.Controls.Add(this.lblXMessage, 1, 6);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 9;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 697);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // btnXAccept
	  // 
	  this.btnXAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXAccept.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXAccept.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXAccept.Location = new System.Drawing.Point(319, 639);
	  this.btnXAccept.Name = "btnXAccept";
	  this.btnXAccept.Size = new System.Drawing.Size(150, 35);
	  this.btnXAccept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXAccept.TabIndex = 0;
	  this.btnXAccept.Text = "Xác nhận";
	  this.btnXAccept.Click += new System.EventHandler(this.btnXAccept_Click);
	  // 
	  // btnXCancel
	  // 
	  this.btnXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXCancel.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXCancel.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXCancel.Location = new System.Drawing.Point(495, 639);
	  this.btnXCancel.Name = "btnXCancel";
	  this.btnXCancel.Size = new System.Drawing.Size(150, 35);
	  this.btnXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXCancel.TabIndex = 1;
	  this.btnXCancel.Text = "Hủy";
	  this.btnXCancel.Click += new System.EventHandler(this.btnXCancel_Click);
	  // 
	  // groupBox1
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
	  this.groupBox1.Controls.Add(this.rtbNote);
	  this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox1.Location = new System.Drawing.Point(33, 509);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(436, 74);
	  this.groupBox1.TabIndex = 2;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Ghi chú thêm khi cộng tiền đơn hàng này";
	  // 
	  // rtbNote
	  // 
	  // 
	  // 
	  // 
	  this.rtbNote.BackgroundStyle.Class = "RichTextBoxBorder";
	  this.rtbNote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.rtbNote.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.rtbNote.Location = new System.Drawing.Point(3, 16);
	  this.rtbNote.Name = "rtbNote";
	  this.rtbNote.Size = new System.Drawing.Size(430, 55);
	  this.rtbNote.TabIndex = 0;
	  // 
	  // groupBox2
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
	  this.groupBox2.Controls.Add(this.lblDetailDebt);
	  this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox2.Location = new System.Drawing.Point(33, 459);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(436, 44);
	  this.groupBox2.TabIndex = 3;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Chi tiết";
	  // 
	  // groupBox3
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
	  this.groupBox3.Controls.Add(this.lblXName);
	  this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox3.Location = new System.Drawing.Point(33, 409);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(436, 44);
	  this.groupBox3.TabIndex = 4;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Tên khách hàng";
	  // 
	  // lblXName
	  // 
	  // 
	  // 
	  // 
	  this.lblXName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.lblXName.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.lblXName.Location = new System.Drawing.Point(3, 16);
	  this.lblXName.Name = "lblXName";
	  this.lblXName.Size = new System.Drawing.Size(430, 25);
	  this.lblXName.TabIndex = 0;
	  this.lblXName.Text = "labelX1";
	  // 
	  // dgvXMain
	  // 
	  this.dgvXMain.AllowUserToAddRows = false;
	  this.dgvXMain.AllowUserToDeleteRows = false;
	  this.dgvXMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  this.tableLayoutPanel1.SetColumnSpan(this.dgvXMain, 5);
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dgvXMain.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dgvXMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dgvXMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dgvXMain.Location = new System.Drawing.Point(33, 23);
	  this.dgvXMain.Name = "dgvXMain";
	  this.dgvXMain.ReadOnly = true;
	  this.dgvXMain.Size = new System.Drawing.Size(898, 380);
	  this.dgvXMain.TabIndex = 8;
	  // 
	  // groupBox4
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox4, 2);
	  this.groupBox4.Controls.Add(this.lblXDebtCurrent);
	  this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox4.Location = new System.Drawing.Point(495, 409);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(436, 44);
	  this.groupBox4.TabIndex = 5;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Số nợ cũ";
	  // 
	  // lblXDebtCurrent
	  // 
	  // 
	  // 
	  // 
	  this.lblXDebtCurrent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.lblXDebtCurrent.Location = new System.Drawing.Point(3, 16);
	  this.lblXDebtCurrent.Name = "lblXDebtCurrent";
	  this.lblXDebtCurrent.Size = new System.Drawing.Size(147, 25);
	  this.lblXDebtCurrent.TabIndex = 0;
	  this.lblXDebtCurrent.Text = "labelX2";
	  this.lblXDebtCurrent.TextAlignment = System.Drawing.StringAlignment.Far;
	  // 
	  // groupBox5
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox5, 2);
	  this.groupBox5.Controls.Add(this.lblXTongTienDH);
	  this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox5.Location = new System.Drawing.Point(495, 459);
	  this.groupBox5.Name = "groupBox5";
	  this.groupBox5.Size = new System.Drawing.Size(436, 44);
	  this.groupBox5.TabIndex = 6;
	  this.groupBox5.TabStop = false;
	  this.groupBox5.Text = "Tổng tiền đơn hàng này";
	  // 
	  // groupBox6
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.groupBox6, 2);
	  this.groupBox6.Controls.Add(this.lblXDebtUpdate);
	  this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.groupBox6.Location = new System.Drawing.Point(495, 509);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(436, 74);
	  this.groupBox6.TabIndex = 7;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Số nợ sau khi cộng tiền đơn hàng này";
	  // 
	  // lblDetailDebt
	  // 
	  // 
	  // 
	  // 
	  this.lblDetailDebt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.lblDetailDebt.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.lblDetailDebt.Location = new System.Drawing.Point(3, 16);
	  this.lblDetailDebt.Name = "lblDetailDebt";
	  this.lblDetailDebt.Size = new System.Drawing.Size(430, 25);
	  this.lblDetailDebt.TabIndex = 0;
	  this.lblDetailDebt.Text = "labelX1";
	  // 
	  // lblXTongTienDH
	  // 
	  // 
	  // 
	  // 
	  this.lblXTongTienDH.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.lblXTongTienDH.Location = new System.Drawing.Point(7, 20);
	  this.lblXTongTienDH.Name = "lblXTongTienDH";
	  this.lblXTongTienDH.Size = new System.Drawing.Size(143, 23);
	  this.lblXTongTienDH.TabIndex = 0;
	  this.lblXTongTienDH.Text = "labelX1";
	  this.lblXTongTienDH.TextAlignment = System.Drawing.StringAlignment.Far;
	  // 
	  // lblXDebtUpdate
	  // 
	  // 
	  // 
	  // 
	  this.lblXDebtUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.lblXDebtUpdate.Location = new System.Drawing.Point(7, 20);
	  this.lblXDebtUpdate.Name = "lblXDebtUpdate";
	  this.lblXDebtUpdate.Size = new System.Drawing.Size(143, 23);
	  this.lblXDebtUpdate.TabIndex = 0;
	  this.lblXDebtUpdate.Text = "labelX1";
	  this.lblXDebtUpdate.TextAlignment = System.Drawing.StringAlignment.Far;
	  // 
	  // lblXMessage
	  // 
	  // 
	  // 
	  // 
	  this.lblXMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.tableLayoutPanel1.SetColumnSpan(this.lblXMessage, 5);
	  this.lblXMessage.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.lblXMessage.Location = new System.Drawing.Point(33, 609);
	  this.lblXMessage.Name = "lblXMessage";
	  this.lblXMessage.Size = new System.Drawing.Size(898, 24);
	  this.lblXMessage.TabIndex = 9;
	  this.lblXMessage.Text = "labelX1";
	  this.lblXMessage.TextAlignment = System.Drawing.StringAlignment.Center;
	  // 
	  // frmXacNhanThemTienNo
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(964, 697);
	  this.Controls.Add(this.panelEx1);
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmXacNhanThemTienNo";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "frmXacNhanThemTienNo";
	  this.Load += new System.EventHandler(this.frmXacNhanThemTienNo_Load);
	  this.panelEx1.ResumeLayout(false);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.groupBox3.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).EndInit();
	  this.groupBox4.ResumeLayout(false);
	  this.groupBox5.ResumeLayout(false);
	  this.groupBox6.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.PanelEx panelEx1;
	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.ButtonX btnXAccept;
	private DevComponents.DotNetBar.ButtonX btnXCancel;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.GroupBox groupBox6;
	private DevComponents.DotNetBar.Controls.DataGridViewX dgvXMain;
	private DevComponents.DotNetBar.Controls.RichTextBoxEx rtbNote;
	private DevComponents.DotNetBar.LabelX lblXName;
	private DevComponents.DotNetBar.LabelX lblXDebtCurrent;
	private DevComponents.DotNetBar.LabelX lblDetailDebt;
	private DevComponents.DotNetBar.LabelX lblXTongTienDH;
	private DevComponents.DotNetBar.LabelX lblXDebtUpdate;
	private DevComponents.DotNetBar.LabelX lblXMessage;
  }
}