namespace THUOCBAC.FormDialogPhu {
  partial class frmChonTenHoacThemMoi {
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
	  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonTenHoacThemMoi));
	  this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	  this.btnXAddNew = new DevComponents.DotNetBar.ButtonX();
	  this.btnXAccept = new DevComponents.DotNetBar.ButtonX();
	  this.dgvXMain = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.tableLayoutPanel1.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // tableLayoutPanel1
	  // 
	  this.tableLayoutPanel1.ColumnCount = 5;
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	  this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	  this.tableLayoutPanel1.Controls.Add(this.btnXAddNew, 1, 1);
	  this.tableLayoutPanel1.Controls.Add(this.btnXAccept, 2, 4);
	  this.tableLayoutPanel1.Controls.Add(this.dgvXMain, 1, 3);
	  this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	  this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	  this.tableLayoutPanel1.RowCount = 6;
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
	  this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 475);
	  this.tableLayoutPanel1.TabIndex = 0;
	  // 
	  // btnXAddNew
	  // 
	  this.btnXAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.tableLayoutPanel1.SetColumnSpan(this.btnXAddNew, 3);
	  this.btnXAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXAddNew.Image = global::THUOCBAC.Properties.Resources.add;
	  this.btnXAddNew.Location = new System.Drawing.Point(33, 23);
	  this.btnXAddNew.Name = "btnXAddNew";
	  this.btnXAddNew.Size = new System.Drawing.Size(722, 35);
	  this.btnXAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXAddNew.TabIndex = 0;
	  this.btnXAddNew.Text = "buttonX1";
	  this.btnXAddNew.Click += new System.EventHandler(this.btnXAddNew_Click);
	  // 
	  // btnXAccept
	  // 
	  this.btnXAccept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXAccept.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXAccept.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.btnXAccept.Enabled = false;
	  this.btnXAccept.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXAccept.Location = new System.Drawing.Point(319, 417);
	  this.btnXAccept.Name = "btnXAccept";
	  this.btnXAccept.Size = new System.Drawing.Size(150, 35);
	  this.btnXAccept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXAccept.TabIndex = 1;
	  this.btnXAccept.Text = "Xác nhận";
	  this.btnXAccept.Click += new System.EventHandler(this.btnXAccept_Click);
	  // 
	  // dgvXMain
	  // 
	  this.dgvXMain.AllowUserToAddRows = false;
	  this.dgvXMain.AllowUserToDeleteRows = false;
	  this.dgvXMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  this.tableLayoutPanel1.SetColumnSpan(this.dgvXMain, 3);
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
	  this.dgvXMain.Location = new System.Drawing.Point(33, 84);
	  this.dgvXMain.Name = "dgvXMain";
	  this.dgvXMain.ReadOnly = true;
	  this.dgvXMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dgvXMain.Size = new System.Drawing.Size(722, 327);
	  this.dgvXMain.TabIndex = 2;
	  this.dgvXMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXMain_CellClick);
	  // 
	  // frmChonTenHoacThemMoi
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(788, 475);
	  this.Controls.Add(this.tableLayoutPanel1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
	  this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	  this.Name = "frmChonTenHoacThemMoi";
	  this.ShowInTaskbar = false;
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "frmChonTenHoacThemMoi";
	  this.Load += new System.EventHandler(this.frmChonTenHoacThemMoi_Load);
	  this.tableLayoutPanel1.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dgvXMain)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	private DevComponents.DotNetBar.ButtonX btnXAddNew;
	private DevComponents.DotNetBar.ButtonX btnXAccept;
	private DevComponents.DotNetBar.Controls.DataGridViewX dgvXMain;
  }
}