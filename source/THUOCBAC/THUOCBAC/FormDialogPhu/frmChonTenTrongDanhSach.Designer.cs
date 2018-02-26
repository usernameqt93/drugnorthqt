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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonTenTrongDanhSach));
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXChoose = new DevComponents.DotNetBar.ButtonX();
	  this.dgvXMain = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.tlpMain.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // tlpMain
	  // 
	  this.tlpMain.ColumnCount = 5;
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Controls.Add(this.btnXChoose, 2, 3);
	  this.tlpMain.Controls.Add(this.dgvXMain, 1, 1);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 5;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(1004, 467);
	  this.tlpMain.TabIndex = 0;
	  // 
	  // btnXChoose
	  // 
	  this.btnXChoose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXChoose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXChoose.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXChoose.Enabled = false;
	  this.btnXChoose.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXChoose.Location = new System.Drawing.Point(427, 409);
	  this.btnXChoose.Name = "btnXChoose";
	  this.btnXChoose.Size = new System.Drawing.Size(150, 35);
	  this.btnXChoose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXChoose.TabIndex = 0;
	  this.btnXChoose.Text = "Xác nhận";
	  this.btnXChoose.Click += new System.EventHandler(this.btnXChoose_Click);
	  // 
	  // dgvXMain
	  // 
	  this.dgvXMain.AllowUserToAddRows = false;
	  this.dgvXMain.AllowUserToDeleteRows = false;
	  this.dgvXMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  this.tlpMain.SetColumnSpan(this.dgvXMain, 3);
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
	  this.dgvXMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dgvXMain.Size = new System.Drawing.Size(938, 370);
	  this.dgvXMain.TabIndex = 2;
	  this.dgvXMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXMain_CellClick);
	  // 
	  // frmChonTenTrongDanhSach
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1004, 467);
	  this.Controls.Add(this.tlpMain);
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmChonTenTrongDanhSach";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "frmChonTenKhachHang";
	  this.Load += new System.EventHandler(this.frmChonTenTrongDanhSach_Load);
	  this.tlpMain.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel tlpMain;
	private DevComponents.DotNetBar.ButtonX btnXChoose;
	private DevComponents.DotNetBar.Controls.DataGridViewX dgvXMain;
  }
}