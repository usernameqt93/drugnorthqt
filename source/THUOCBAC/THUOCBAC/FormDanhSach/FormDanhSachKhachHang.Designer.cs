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
	  this.grpChucNang = new System.Windows.Forms.GroupBox();
	  this.btnXXemChiTiet = new DevComponents.DotNetBar.ButtonX();
	  this.btnXThayDoiTienNo = new DevComponents.DotNetBar.ButtonX();
	  this.grpDanhSach = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXDanhSachKH = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
	  this.grpChucNang.SuspendLayout();
	  this.grpDanhSach.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachKH)).BeginInit();
	  this.tlpMain.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // grpChucNang
	  // 
	  this.grpChucNang.Controls.Add(this.btnXXemChiTiet);
	  this.grpChucNang.Controls.Add(this.btnXThayDoiTienNo);
	  this.grpChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpChucNang.Location = new System.Drawing.Point(3, 3);
	  this.grpChucNang.Name = "grpChucNang";
	  this.grpChucNang.Size = new System.Drawing.Size(190, 532);
	  this.grpChucNang.TabIndex = 0;
	  this.grpChucNang.TabStop = false;
	  this.grpChucNang.Text = "Chức năng";
	  // 
	  // btnXXemChiTiet
	  // 
	  this.btnXXemChiTiet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXemChiTiet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXemChiTiet.Enabled = false;
	  this.btnXXemChiTiet.Image = global::THUOCBAC.Properties.Resources._goto;
	  this.btnXXemChiTiet.Location = new System.Drawing.Point(6, 70);
	  this.btnXXemChiTiet.Name = "btnXXemChiTiet";
	  this.btnXXemChiTiet.Size = new System.Drawing.Size(178, 44);
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
	  this.btnXThayDoiTienNo.Size = new System.Drawing.Size(178, 44);
	  this.btnXThayDoiTienNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXThayDoiTienNo.TabIndex = 0;
	  this.btnXThayDoiTienNo.Text = "Thay đổi tiền nợ";
	  this.btnXThayDoiTienNo.Click += new System.EventHandler(this.btnXThayDoiTienNo_Click);
	  // 
	  // grpDanhSach
	  // 
	  this.grpDanhSach.Controls.Add(this.dataGridViewXDanhSachKH);
	  this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.grpDanhSach.Location = new System.Drawing.Point(199, 3);
	  this.grpDanhSach.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
	  this.grpDanhSach.Name = "grpDanhSach";
	  this.grpDanhSach.Padding = new System.Windows.Forms.Padding(6);
	  this.grpDanhSach.Size = new System.Drawing.Size(1141, 532);
	  this.grpDanhSach.TabIndex = 1;
	  this.grpDanhSach.TabStop = false;
	  this.grpDanhSach.Text = "Danh sách";
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
	  this.dataGridViewXDanhSachKH.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.dataGridViewXDanhSachKH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXDanhSachKH.Location = new System.Drawing.Point(6, 19);
	  this.dataGridViewXDanhSachKH.Name = "dataGridViewXDanhSachKH";
	  this.dataGridViewXDanhSachKH.ReadOnly = true;
	  this.dataGridViewXDanhSachKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXDanhSachKH.Size = new System.Drawing.Size(1129, 507);
	  this.dataGridViewXDanhSachKH.TabIndex = 0;
	  this.dataGridViewXDanhSachKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXDanhSachKH_CellClick);
	  // 
	  // tlpMain
	  // 
	  this.tlpMain.ColumnCount = 2;
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
	  this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.Controls.Add(this.grpDanhSach, 1, 0);
	  this.tlpMain.Controls.Add(this.grpChucNang, 0, 0);
	  this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
	  this.tlpMain.Location = new System.Drawing.Point(0, 0);
	  this.tlpMain.Name = "tlpMain";
	  this.tlpMain.RowCount = 1;
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	  this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	  this.tlpMain.Size = new System.Drawing.Size(1349, 538);
	  this.tlpMain.TabIndex = 2;
	  // 
	  // FormDanhSachKhachHang
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.tlpMain);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.MinimumSize = new System.Drawing.Size(1349, 538);
	  this.Name = "FormDanhSachKhachHang";
	  this.Text = "FormDanhSachKhachHang";
	  this.Load += new System.EventHandler(this.FormDanhSachKhachHang_Load);
	  this.grpChucNang.ResumeLayout(false);
	  this.grpDanhSach.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachKH)).EndInit();
	  this.tlpMain.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox grpChucNang;
	private System.Windows.Forms.GroupBox grpDanhSach;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXDanhSachKH;
	private DevComponents.DotNetBar.ButtonX btnXThayDoiTienNo;
	private DevComponents.DotNetBar.ButtonX btnXXemChiTiet;
	private System.Windows.Forms.TableLayoutPanel tlpMain;
  }
}