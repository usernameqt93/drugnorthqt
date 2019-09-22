namespace THUOCBAC.FormChucNang {
  partial class FormSuaGiaViThuoc {
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
	  this.groupBox1 = new System.Windows.Forms.GroupBox();
	  this.txtXTenViThuoc = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.numericGiaViThuoc = new System.Windows.Forms.NumericUpDown();
	  this.labelX1 = new DevComponents.DotNetBar.LabelX();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.comboBoxEDonViTinh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.comboItem1 = new DevComponents.Editors.ComboItem();
	  this.comboItem2 = new DevComponents.Editors.ComboItem();
	  this.comboItem3 = new DevComponents.Editors.ComboItem();
	  this.comboItem4 = new DevComponents.Editors.ComboItem();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.btnXHuyBo = new DevComponents.DotNetBar.ButtonX();
	  this.btnXLuuGiaViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericGiaViThuoc)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.txtXTenViThuoc);
	  this.groupBox1.Location = new System.Drawing.Point(13, 13);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(504, 53);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Tên vị thuốc";
	  // 
	  // txtXTenViThuoc
	  // 
	  // 
	  // 
	  // 
	  this.txtXTenViThuoc.Border.Class = "TextBoxBorder";
	  this.txtXTenViThuoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXTenViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.txtXTenViThuoc.Name = "txtXTenViThuoc";
	  this.txtXTenViThuoc.Size = new System.Drawing.Size(491, 20);
	  this.txtXTenViThuoc.TabIndex = 0;
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.numericGiaViThuoc);
	  this.groupBox2.Location = new System.Drawing.Point(13, 73);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(273, 52);
	  this.groupBox2.TabIndex = 1;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Nhập giá cho vị thuốc này (ví dụ : 12000, 99000, ... )";
	  // 
	  // numericGiaViThuoc
	  // 
	  this.numericGiaViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.numericGiaViThuoc.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
	  this.numericGiaViThuoc.Name = "numericGiaViThuoc";
	  this.numericGiaViThuoc.Size = new System.Drawing.Size(236, 20);
	  this.numericGiaViThuoc.TabIndex = 0;
	  this.numericGiaViThuoc.ThousandsSeparator = true;
	  this.numericGiaViThuoc.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
	  // 
	  // labelX1
	  // 
	  // 
	  // 
	  // 
	  this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelX1.Location = new System.Drawing.Point(292, 90);
	  this.labelX1.Name = "labelX1";
	  this.labelX1.Size = new System.Drawing.Size(34, 23);
	  this.labelX1.TabIndex = 2;
	  this.labelX1.Text = "/ 1";
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.comboBoxEDonViTinh);
	  this.groupBox3.Location = new System.Drawing.Point(332, 73);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(185, 52);
	  this.groupBox3.TabIndex = 3;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Đơn vị tính (cân, chiếc, lạng, ... )";
	  // 
	  // comboBoxEDonViTinh
	  // 
	  this.comboBoxEDonViTinh.DisplayMember = "Text";
	  this.comboBoxEDonViTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
	  this.comboBoxEDonViTinh.FormattingEnabled = true;
	  this.comboBoxEDonViTinh.ItemHeight = 14;
	  this.comboBoxEDonViTinh.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
	  this.comboBoxEDonViTinh.Location = new System.Drawing.Point(7, 20);
	  this.comboBoxEDonViTinh.Name = "comboBoxEDonViTinh";
	  this.comboBoxEDonViTinh.Size = new System.Drawing.Size(172, 20);
	  this.comboBoxEDonViTinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxEDonViTinh.TabIndex = 0;
	  // 
	  // comboItem1
	  // 
	  this.comboItem1.Text = "Cân";
	  // 
	  // comboItem2
	  // 
	  this.comboItem2.Text = "Lạng";
	  // 
	  // comboItem3
	  // 
	  this.comboItem3.Text = "Chiếc";
	  // 
	  // comboItem4
	  // 
	  this.comboItem4.Text = "Kg";
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.btnXHuyBo);
	  this.groupBox4.Controls.Add(this.btnXLuuGiaViThuoc);
	  this.groupBox4.Location = new System.Drawing.Point(13, 132);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(504, 100);
	  this.groupBox4.TabIndex = 4;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Chức năng";
	  // 
	  // btnXHuyBo
	  // 
	  this.btnXHuyBo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXHuyBo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXHuyBo.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.btnXHuyBo.Location = new System.Drawing.Point(262, 20);
	  this.btnXHuyBo.Name = "btnXHuyBo";
	  this.btnXHuyBo.Size = new System.Drawing.Size(236, 23);
	  this.btnXHuyBo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXHuyBo.TabIndex = 0;
	  this.btnXHuyBo.Text = "Hủy";
	  this.btnXHuyBo.Click += new System.EventHandler(this.btnXHuyBo_Click);
	  // 
	  // btnXLuuGiaViThuoc
	  // 
	  this.btnXLuuGiaViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.btnXLuuGiaViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.btnXLuuGiaViThuoc.Image = global::THUOCBAC.Properties.Resources.ok;
	  this.btnXLuuGiaViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.btnXLuuGiaViThuoc.Name = "btnXLuuGiaViThuoc";
	  this.btnXLuuGiaViThuoc.Size = new System.Drawing.Size(236, 23);
	  this.btnXLuuGiaViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.btnXLuuGiaViThuoc.TabIndex = 0;
	  this.btnXLuuGiaViThuoc.Text = "Lưu giá vị thuốc như trên";
	  this.btnXLuuGiaViThuoc.Click += new System.EventHandler(this.btnXLuuGiaViThuoc_Click);
	  // 
	  // FormSuaGiaViThuoc
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(531, 280);
	  this.Controls.Add(this.groupBox4);
	  this.Controls.Add(this.groupBox3);
	  this.Controls.Add(this.labelX1);
	  this.Controls.Add(this.groupBox2);
	  this.Controls.Add(this.groupBox1);
	  this.Name = "FormSuaGiaViThuoc";
	  this.Text = "FormSuaGiaViThuoc";
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericGiaViThuoc)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXTenViThuoc;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.NumericUpDown numericGiaViThuoc;
	private DevComponents.DotNetBar.LabelX labelX1;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEDonViTinh;
	private DevComponents.Editors.ComboItem comboItem1;
	private DevComponents.Editors.ComboItem comboItem2;
	private DevComponents.Editors.ComboItem comboItem3;
	private System.Windows.Forms.GroupBox groupBox4;
	private DevComponents.DotNetBar.ButtonX btnXLuuGiaViThuoc;
	private DevComponents.DotNetBar.ButtonX btnXHuyBo;
	private DevComponents.Editors.ComboItem comboItem4;
  }
}