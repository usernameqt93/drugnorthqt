namespace THUOCBAC.FormDialogPhu {
  partial class frmSuaTenTrongDanhSach {
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
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.grpOldValue = new System.Windows.Forms.GroupBox();
	  this.grpNewValue = new System.Windows.Forms.GroupBox();
	  this.btnXAccept = new DevComponents.DotNetBar.ButtonX();
	  this.btnXCancel = new DevComponents.DotNetBar.ButtonX();
	  this.txtXOldValue = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.txtXNewValue = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.grpOldValue.SuspendLayout();
	  this.grpNewValue.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 7;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.grpOldValue, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.grpNewValue, 1, 3);
	  this.tableLayoutPanel1.Controls.Add(this.btnXAccept, 2, 5);
	  this.tableLayoutPanel1.Controls.Add(this.btnXCancel, 4, 5);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 8;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 196);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // grpOldValue
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.grpOldValue, 5);
	  this.grpOldValue.Controls.Add(this.txtXOldValue);
	  this.grpOldValue.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpOldValue.Location = new System.Drawing.Point(33, 23);
	  this.grpOldValue.Name = "grpOldValue";
	  this.grpOldValue.Size = new System.Drawing.Size(766, 39);
	  this.grpOldValue.TabIndex = 0;
	  this.grpOldValue.TabStop = false;
	  this.grpOldValue.Text = "Tên khách hàng cũ";
	  // 
	  // grpNewValue
	  // 
	  this.tableLayoutPanel1.SetColumnSpan(this.grpNewValue, 5);
	  this.grpNewValue.Controls.Add(this.txtXNewValue);
	  this.grpNewValue.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpNewValue.Location = new System.Drawing.Point(33, 78);
	  this.grpNewValue.Name = "grpNewValue";
	  this.grpNewValue.Size = new System.Drawing.Size(766, 39);
	  this.grpNewValue.TabIndex = 1;
	  this.grpNewValue.TabStop = false;
	  this.grpNewValue.Text = "Tên khách hàng mới";
	  // 
	  // btnXAccept
	  // 
	  this.btnXAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXAccept.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXAccept.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXAccept.Location = new System.Drawing.Point(258, 133);
	  this.btnXAccept.Name = "btnXAccept";
	  this.btnXAccept.Size = new System.Drawing.Size(150, 35);
	  this.btnXAccept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXAccept.TabIndex = 2;
	  this.btnXAccept.Text = "Xác nhận";
	  this.btnXAccept.Click += new System.EventHandler(this.btnXAccept_Click);
	  // 
	  // btnXCancel
	  // 
	  this.btnXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXCancel.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXCancel.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXCancel.Location = new System.Drawing.Point(424, 133);
	  this.btnXCancel.Name = "btnXCancel";
	  this.btnXCancel.Size = new System.Drawing.Size(150, 35);
	  this.btnXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXCancel.TabIndex = 3;
	  this.btnXCancel.Text = "Hủy bỏ";
	  this.btnXCancel.Click += new System.EventHandler(this.btnXCancel_Click);
	  // 
	  // txtXOldValue
	  // 
	  // 
	  // 
	  // 
	  this.txtXOldValue.Border.Class = "TextBoxBorder";
	  this.txtXOldValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXOldValue.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.txtXOldValue.Enabled = false;
	  this.txtXOldValue.Location = new System.Drawing.Point(3, 16);
	  this.txtXOldValue.Name = "txtXOldValue";
	  this.txtXOldValue.Size = new System.Drawing.Size(760, 20);
	  this.txtXOldValue.TabIndex = 0;
	  this.txtXOldValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  // 
	  // txtXNewValue
	  // 
	  // 
	  // 
	  // 
	  this.txtXNewValue.Border.Class = "TextBoxBorder";
	  this.txtXNewValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXNewValue.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.txtXNewValue.Location = new System.Drawing.Point(3, 16);
	  this.txtXNewValue.Name = "txtXNewValue";
	  this.txtXNewValue.Size = new System.Drawing.Size(760, 20);
	  this.txtXNewValue.TabIndex = 0;
	  this.txtXNewValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  // 
	  // frmSuaTenTrongDanhSach
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(833, 196);
	  this.Controls.Add(this.tableLayoutPanel1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Name = "frmSuaTenTrongDanhSach";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "frmSuaTenTrongDanhSach";
	  this.Load += new System.EventHandler(this.frmSuaTenTrongDanhSach_Load);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.grpOldValue.ResumeLayout(false);
	  this.grpNewValue.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private System.Windows.Forms.GroupBox grpOldValue;
	private System.Windows.Forms.GroupBox grpNewValue;
	private DevComponents.DotNetBar.ButtonX btnXAccept;
	private DevComponents.DotNetBar.ButtonX btnXCancel;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXOldValue;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXNewValue;
  }
}