namespace THUOCBAC.FormDanhSach {
  partial class FormDanhSachViThuoc {
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
	  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.btnXXoaViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.btnXSuaGiaViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.buttonXThemViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.dataGridViewXDanhSachViThuoc = new DevComponents.DotNetBar.Controls.DataGridViewX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachViThuoc)).BeginInit();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.btnXXoaViThuoc);
	  this.groupBox1.Controls.Add(this.btnXSuaGiaViThuoc);
	  this.groupBox1.Controls.Add(this.buttonXThemViThuoc);
	  this.groupBox1.Location = new System.Drawing.Point(12, 12);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(196, 514);
	  this.groupBox1.TabIndex = 1;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Chức năng";
	  // 
	  // btnXXoaViThuoc
	  // 
	  this.btnXXoaViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXXoaViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXXoaViThuoc.Enabled = false;
	  this.btnXXoaViThuoc.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXXoaViThuoc.Location = new System.Drawing.Point(7, 120);
	  this.btnXXoaViThuoc.Name = "btnXXoaViThuoc";
	  this.btnXXoaViThuoc.Size = new System.Drawing.Size(181, 44);
	  this.btnXXoaViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXXoaViThuoc.TabIndex = 1;
	  this.btnXXoaViThuoc.Text = "Xóa vị thuốc này";
	  this.btnXXoaViThuoc.Click += new System.EventHandler(this.btnXXoaViThuoc_Click);
	  // 
	  // btnXSuaGiaViThuoc
	  // 
	  this.btnXSuaGiaViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXSuaGiaViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXSuaGiaViThuoc.Enabled = false;
	  this.btnXSuaGiaViThuoc.Image = global::THUOCBAC.Properties.Resources.update;
	  this.btnXSuaGiaViThuoc.Location = new System.Drawing.Point(7, 70);
	  this.btnXSuaGiaViThuoc.Name = "btnXSuaGiaViThuoc";
	  this.btnXSuaGiaViThuoc.Size = new System.Drawing.Size(181, 44);
	  this.btnXSuaGiaViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXSuaGiaViThuoc.TabIndex = 0;
	  this.btnXSuaGiaViThuoc.Text = "Sửa thông tin vị thuốc này";
	  this.btnXSuaGiaViThuoc.Click += new System.EventHandler(this.btnXSuaGiaViThuoc_Click);
	  // 
	  // buttonXThemViThuoc
	  // 
	  this.buttonXThemViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonXThemViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonXThemViThuoc.Enabled = false;
	  this.buttonXThemViThuoc.Image = global::THUOCBAC.Properties.Resources.add;
	  this.buttonXThemViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.buttonXThemViThuoc.Name = "buttonXThemViThuoc";
	  this.buttonXThemViThuoc.Size = new System.Drawing.Size(181, 44);
	  this.buttonXThemViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonXThemViThuoc.TabIndex = 0;
	  this.buttonXThemViThuoc.Text = "Thêm vị thuốc";
	  this.buttonXThemViThuoc.Click += new System.EventHandler(this.buttonXThemViThuoc_Click);
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.dataGridViewXDanhSachViThuoc);
	  this.groupBox2.Location = new System.Drawing.Point(214, 12);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(1123, 514);
	  this.groupBox2.TabIndex = 2;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Danh sách";
	  // 
	  // dataGridViewXDanhSachViThuoc
	  // 
	  this.dataGridViewXDanhSachViThuoc.AllowUserToAddRows = false;
	  this.dataGridViewXDanhSachViThuoc.AllowUserToDeleteRows = false;
	  this.dataGridViewXDanhSachViThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
	  this.dataGridViewXDanhSachViThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	  dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
	  dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
	  dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	  dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
	  dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
	  this.dataGridViewXDanhSachViThuoc.DefaultCellStyle = dataGridViewCellStyle4;
	  this.dataGridViewXDanhSachViThuoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
	  this.dataGridViewXDanhSachViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.dataGridViewXDanhSachViThuoc.Name = "dataGridViewXDanhSachViThuoc";
	  this.dataGridViewXDanhSachViThuoc.ReadOnly = true;
	  this.dataGridViewXDanhSachViThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	  this.dataGridViewXDanhSachViThuoc.Size = new System.Drawing.Size(1110, 459);
	  this.dataGridViewXDanhSachViThuoc.TabIndex = 0;
	  this.dataGridViewXDanhSachViThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXDanhSachViThuoc_CellClick);
	  // 
	  // FormDanhSachViThuoc
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(1349, 538);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormDanhSachViThuoc";
	  this.Text = "FormDanhSachViThuoc";
	  this.Load += new System.EventHandler(this.FormDanhSachViThuoc_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXDanhSachViThuoc)).EndInit();
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.ButtonX buttonXThemViThuoc;
	private DevComponents.DotNetBar.ButtonX btnXSuaGiaViThuoc;
	private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewXDanhSachViThuoc;
	private DevComponents.DotNetBar.ButtonX btnXXoaViThuoc;
  }
}