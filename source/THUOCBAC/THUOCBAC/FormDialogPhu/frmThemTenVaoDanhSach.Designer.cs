namespace THUOCBAC.FormDialogPhu {
  partial class frmThemTenVaoDanhSach {
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
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemTenVaoDanhSach));
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.txtXValue = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.btnXAccept = new DevComponents.DotNetBar.ButtonX();
	  this.btnXCancel = new DevComponents.DotNetBar.ButtonX();
	  this.tableLayoutPanel1.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 7;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.txtXValue, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.btnXAccept, 2, 3);
	  this.tableLayoutPanel1.Controls.Add(this.btnXCancel, 4, 3);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 6;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 118);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // txtXValue
	  // 
	  // 
	  // 
	  // 
	  this.txtXValue.Border.Class = "TextBoxBorder";
	  this.txtXValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.tableLayoutPanel1.SetColumnSpan(this.txtXValue, 5);
	  this.txtXValue.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.txtXValue.Location = new System.Drawing.Point(33, 23);
	  this.txtXValue.Name = "txtXValue";
	  this.txtXValue.Size = new System.Drawing.Size(408, 20);
	  this.txtXValue.TabIndex = 0;
	  this.txtXValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
	  // 
	  // btnXAccept
	  // 
	  this.btnXAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXAccept.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXAccept.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXAccept.Location = new System.Drawing.Point(80, 63);
	  this.btnXAccept.Name = "btnXAccept";
	  this.btnXAccept.Size = new System.Drawing.Size(144, 29);
	  this.btnXAccept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXAccept.TabIndex = 1;
	  this.btnXAccept.Text = "Xác nhận";
	  this.btnXAccept.Click += new System.EventHandler(this.btnXAccept_Click);
	  // 
	  // btnXCancel
	  // 
	  this.btnXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXCancel.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXCancel.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXCancel.Location = new System.Drawing.Point(250, 63);
	  this.btnXCancel.Name = "btnXCancel";
	  this.btnXCancel.Size = new System.Drawing.Size(144, 29);
	  this.btnXCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXCancel.TabIndex = 2;
	  this.btnXCancel.Text = "Hủy";
	  this.btnXCancel.Click += new System.EventHandler(this.btnXCancel_Click);
	  // 
	  // frmThemTenVaoDanhSach
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(475, 118);
	  this.Controls.Add(this.tableLayoutPanel1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmThemTenVaoDanhSach";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "frmThemTenVaoDanhSach";
	  this.Load += new System.EventHandler(this.frmThemTenVaoDanhSach_Load);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXValue;
	private DevComponents.DotNetBar.ButtonX btnXAccept;
	private DevComponents.DotNetBar.ButtonX btnXCancel;
  }
}