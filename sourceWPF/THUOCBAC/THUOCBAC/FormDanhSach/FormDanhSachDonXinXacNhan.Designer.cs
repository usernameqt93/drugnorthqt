namespace THUOCBAC.FormDanhSach {
  partial class FormDanhSachDonXinXacNhan {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXXemChiTietDonXacNhan = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThemDonXacNhan = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXDSDonXacNhan = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDSDonXacNhan)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXXemChiTietDonXacNhan);
	  this.groupBox1.Controls.Add(this.btnXThemDonXacNhan);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(196, 308);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Chức năng";
	  // 
	  // btnXXemChiTietDonXacNhan
	  // 
	  this.btnXXemChiTietDonXacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemChiTietDonXacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemChiTietDonXacNhan.Enabled = false;
	  this.btnXXemChiTietDonXacNhan.Location = new System.Drawing.Point(7, 49);
	  this.btnXXemChiTietDonXacNhan.Name = "btnXXemChiTietDonXacNhan";
	  this.btnXXemChiTietDonXacNhan.Size = new System.Drawing.Size(183, 23);
	  this.btnXXemChiTietDonXacNhan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemChiTietDonXacNhan.TabIndex = 0;
	  this.btnXXemChiTietDonXacNhan.Text = "Xem chi tiết đơn xác nhận này";
	  this.btnXXemChiTietDonXacNhan.Click += new System.EventHandler(this.btnXXemChiTietDonXacNhan_Click);
	  // 
	  // btnXThemDonXacNhan
	  // 
	  this.btnXThemDonXacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThemDonXacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThemDonXacNhan.Location = new System.Drawing.Point(7, 20);
	  this.btnXThemDonXacNhan.Name = "btnXThemDonXacNhan";
	  this.btnXThemDonXacNhan.Size = new System.Drawing.Size(183, 23);
	  this.btnXThemDonXacNhan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThemDonXacNhan.TabIndex = 0;
	  this.btnXThemDonXacNhan.Text = "Thêm đơn xác nhận mới";
	  this.btnXThemDonXacNhan.Click += new System.EventHandler(this.btnXThemDonXacNhan_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.dataGridViewXDSDonXacNhan);
	  this.groupBox2.Location = new System.Drawing.Point(214, 12);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(1123, 514);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Danh sách";
	  // 
	  // dataGridViewXDSDonXacNhan
	  // 
	  this.dataGridViewXDSDonXacNhan.AllowUserToAddRows = false;
	  this.dataGridViewXDSDonXacNhan.AllowUserToDeleteRows = false;
	  this.dataGridViewXDSDonXacNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXDSDonXacNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXDSDonXacNhan.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXDSDonXacNhan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXDSDonXacNhan.Location = new System.Drawing.Point(6, 19);
	  this.dataGridViewXDSDonXacNhan.Name = "dataGridViewXDSDonXacNhan";
	  this.dataGridViewXDSDonXacNhan.ReadOnly = true;
	  this.dataGridViewXDSDonXacNhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXDSDonXacNhan.Size = new System.Drawing.Size(1111, 489);
	  this.dataGridViewXDSDonXacNhan.TabIndex = 0;
	  this.dataGridViewXDSDonXacNhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXDSDonXacNhan_CellClick);
	  // 
	  // FormDanhSachDonXinXacNhan
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormDanhSachDonXinXacNhan";
	  this.Text = "FormDanhSachDonXinXacNhan";
	  this.Load += new System.EventHandler(this.FormDanhSachDonXinXacNhan_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDSDonXacNhan)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.ButtonX btnXXemChiTietDonXacNhan;
	private DevComponents.DotNetBar.ButtonX btnXThemDonXacNhan;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXDSDonXacNhan;
  }
}