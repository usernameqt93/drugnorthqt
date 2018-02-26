namespace THUOCBAC.FormDialogPhu {
  partial class frmChonTenTrongDanhSach {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
	  this.btnXClose = new DevComponents.DotNetBar.ButtonX();
	  this.dgvXMain = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.tlpMain.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // tlpMain
	  // 
	  this.tlpMain.ColumnCount = 7;
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.Controls.Add(this.buttonX1, 2, 3);
	  this.tlpMain.Controls.Add(this.btnXClose, 4, 3);
	  this.tlpMain.Controls.Add(this.dgvXMain, 1, 1);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 5;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(1004, 467);
	  this.tlpMain.TabIndex = 0;
	  // 
	  // buttonX1
	  // 
	  this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonX1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.buttonX1.Enabled = false;
	  this.buttonX1.Location = new System.Drawing.Point(350, 415);
	  this.buttonX1.Name = "buttonX1";
	  this.buttonX1.Size = new System.Drawing.Size(144, 29);
	  this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonX1.TabIndex = 0;
	  this.buttonX1.Text = "Chọn tên khách hàng này";
	  // 
	  // btnXClose
	  // 
	  this.btnXClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXClose.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXClose.Location = new System.Drawing.Point(510, 415);
	  this.btnXClose.Name = "btnXClose";
	  this.btnXClose.Size = new System.Drawing.Size(144, 29);
	  this.btnXClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXClose.TabIndex = 1;
	  this.btnXClose.Text = "Hủy bỏ";
	  this.btnXClose.Click += new System.EventHandler(this.btnXClose_Click);
	  // 
	  // dgvXMain
	  // 
	  this.dgvXMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  this.tlpMain.SetColumnSpan(this.dgvXMain, 5);
	  dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dgvXMain.DefaultCellStyle = dataGridViewCellStyle3;
	  this.dgvXMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dgvXMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dgvXMain.Location = new System.Drawing.Point(33, 23);
	  this.dgvXMain.Name = "dgvXMain";
	  this.dgvXMain.Size = new System.Drawing.Size(938, 376);
	  this.dgvXMain.TabIndex = 2;
	  // 
	  // frmChonTenTrongDanhSach
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1004, 467);
	  this.Controls.Add(this.tlpMain);
	  this.Name = "frmChonTenTrongDanhSach";
	  this.ShowInTaskbar = false;
	  this.Text = "frmChonTenKhachHang";
	  this.Load += new System.EventHandler(this.frmChonTenTrongDanhSach_Load);
	  this.tlpMain.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel tlpMain;
	private DevComponents.DotNetBar.ButtonX buttonX1;
	private DevComponents.DotNetBar.ButtonX btnXClose;
	private DevComponents.DotNetBar.Controls.DataGridViewX dgvXMain;
  }
}