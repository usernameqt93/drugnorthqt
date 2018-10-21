namespace THUOCBAC.FormDanhSach {
  partial class FormDanhSachKhachHang {
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
	  this.btnXXemChiTiet = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThayDoiTienNo = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXDanhSachKH = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachKH)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXXemChiTiet);
	  this.groupBox1.Controls.Add(this.btnXThayDoiTienNo);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(196, 514);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Chức năng";
	  // 
	  // btnXXemChiTiet
	  // 
	  this.btnXXemChiTiet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemChiTiet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemChiTiet.Enabled = false;
	  this.btnXXemChiTiet.Image = global::THUOCBAC.Properties.Resources._goto;
	  this.btnXXemChiTiet.Location = new System.Drawing.Point(6, 70);
	  this.btnXXemChiTiet.Name = "btnXXemChiTiet";
	  this.btnXXemChiTiet.Size = new System.Drawing.Size(181, 44);
	  this.btnXXemChiTiet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXemChiTiet.TabIndex = 0;
	  this.btnXXemChiTiet.Text = "Xem chi tiết khách hàng";
	  this.btnXXemChiTiet.Click += new System.EventHandler(this.btnXXemChiTiet_Click);
	  // 
	  // btnXThayDoiTienNo
	  // 
	  this.btnXThayDoiTienNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXThayDoiTienNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXThayDoiTienNo.Enabled = false;
	  this.btnXThayDoiTienNo.Image = global::THUOCBAC.Properties.Resources.clear2;
	  this.btnXThayDoiTienNo.Location = new System.Drawing.Point(6, 20);
	  this.btnXThayDoiTienNo.Name = "btnXThayDoiTienNo";
	  this.btnXThayDoiTienNo.Size = new System.Drawing.Size(181, 44);
	  this.btnXThayDoiTienNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThayDoiTienNo.TabIndex = 0;
	  this.btnXThayDoiTienNo.Text = "Thay đổi tiền nợ";
	  this.btnXThayDoiTienNo.Click += new System.EventHandler(this.btnXThayDoiTienNo_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.dataGridViewXDanhSachKH);
	  this.groupBox2.Location = new System.Drawing.Point(214, 12);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(1123, 514);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Danh sách";
	  // 
	  // dataGridViewXDanhSachKH
	  // 
	  this.dataGridViewXDanhSachKH.AllowUserToAddRows = false;
	  this.dataGridViewXDanhSachKH.AllowUserToDeleteRows = false;
	  this.dataGridViewXDanhSachKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXDanhSachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXDanhSachKH.DefaultCellStyle = dataGridViewCellStyle1;
	  this.dataGridViewXDanhSachKH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
	  this.dataGridViewXDanhSachKH.Location = new System.Drawing.Point(7, 20);
	  this.dataGridViewXDanhSachKH.Name = "dataGridViewXDanhSachKH";
	  this.dataGridViewXDanhSachKH.ReadOnly = true;
	  this.dataGridViewXDanhSachKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXDanhSachKH.Size = new System.Drawing.Size(1110, 488);
	  this.dataGridViewXDanhSachKH.TabIndex = 0;
	  this.dataGridViewXDanhSachKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXDanhSachKH_CellClick);
	  // 
	  // FormDanhSachKhachHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormDanhSachKhachHang";
	  this.Text = "FormDanhSachKhachHang";
	  this.Load += new System.EventHandler(this.FormDanhSachKhachHang_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachKH)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXDanhSachKH;
	private DevComponents.DotNetBar.ButtonX btnXThayDoiTienNo;
	private DevComponents.DotNetBar.ButtonX btnXXemChiTiet;
  }
}