namespace THUOCBAC.FormChucNang {
  partial class FormThemViThuoc {
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
	  this.groupBox6 = new System.Windows.Forms.GroupBox();
	  this.comboBoxEDonViTinh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
	  this.comboItem1 = new DevComponents.Editors.ComboItem();
	  this.comboItem2 = new DevComponents.Editors.ComboItem();
	  this.comboItem3 = new DevComponents.Editors.ComboItem();
	  this.comboItem4 = new DevComponents.Editors.ComboItem();
	  this.labelX1 = new DevComponents.DotNetBar.LabelX();
	  this.groupBox5 = new System.Windows.Forms.GroupBox();
	  this.numericGiaViThuoc = new System.Windows.Forms.NumericUpDown();
	  this.groupBox3 = new System.Windows.Forms.GroupBox();
	  this.txtXGhiChuViThuoc = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox2 = new System.Windows.Forms.GroupBox();
	  this.txtXTenViThuoc = new DevComponents.DotNetBar.Controls.TextBoxX();
	  this.groupBox4 = new System.Windows.Forms.GroupBox();
	  this.buttonXHuyThemViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.buttonXThemViThuoc = new DevComponents.DotNetBar.ButtonX();
	  this.groupBox1.SuspendLayout();
	  this.groupBox6.SuspendLayout();
	  this.groupBox5.SuspendLayout();
	  ((System.ComponentModel.ISupportInitialize)(this.numericGiaViThuoc)).BeginInit();
	  this.groupBox3.SuspendLayout();
	  this.groupBox2.SuspendLayout();
	  this.groupBox4.SuspendLayout();
	  this.SuspendLayout();
	  // 
	  // groupBox1
	  // 
	  this.groupBox1.Controls.Add(this.groupBox6);
	  this.groupBox1.Controls.Add(this.labelX1);
	  this.groupBox1.Controls.Add(this.groupBox5);
	  this.groupBox1.Controls.Add(this.groupBox3);
	  this.groupBox1.Controls.Add(this.groupBox2);
	  this.groupBox1.Location = new System.Drawing.Point(13, 13);
	  this.groupBox1.Name = "groupBox1";
	  this.groupBox1.Size = new System.Drawing.Size(640, 229);
	  this.groupBox1.TabIndex = 0;
	  this.groupBox1.TabStop = false;
	  this.groupBox1.Text = "Thông tin";
	  // 
	  // groupBox6
	  // 
	  this.groupBox6.Controls.Add(this.comboBoxEDonViTinh);
	  this.groupBox6.Location = new System.Drawing.Point(428, 20);
	  this.groupBox6.Name = "groupBox6";
	  this.groupBox6.Size = new System.Drawing.Size(202, 52);
	  this.groupBox6.TabIndex = 4;
	  this.groupBox6.TabStop = false;
	  this.groupBox6.Text = "Đơn vị tính (Cân, chiếc, lạng, ... )";
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
	  this.comboBoxEDonViTinh.Size = new System.Drawing.Size(189, 20);
	  this.comboBoxEDonViTinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.comboBoxEDonViTinh.TabIndex = 0;
	  // 
	  // comboItem1
	  // 
	  this.comboItem1.Text = "Cân";
	  // 
	  // comboItem2
	  // 
	  this.comboItem2.Text = "Chiếc";
	  // 
	  // comboItem3
	  // 
	  this.comboItem3.Text = "Lạng";
	  // 
	  // comboItem4
	  // 
	  this.comboItem4.Text = "Kg";
	  // 
	  // labelX1
	  // 
	  // 
	  // 
	  // 
	  this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelX1.Location = new System.Drawing.Point(388, 37);
	  this.labelX1.Name = "labelX1";
	  this.labelX1.Size = new System.Drawing.Size(34, 23);
	  this.labelX1.TabIndex = 3;
	  this.labelX1.Text = "/ 1";
	  // 
	  // groupBox5
	  // 
	  this.groupBox5.Controls.Add(this.numericGiaViThuoc);
	  this.groupBox5.Location = new System.Drawing.Point(182, 20);
	  this.groupBox5.Name = "groupBox5";
	  this.groupBox5.Size = new System.Drawing.Size(200, 52);
	  this.groupBox5.TabIndex = 1;
	  this.groupBox5.TabStop = false;
	  this.groupBox5.Text = "Giá vị thuốc (12000, 99000, ... )";
	  // 
	  // numericGiaViThuoc
	  // 
	  this.numericGiaViThuoc.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
	  this.numericGiaViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.numericGiaViThuoc.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
	  this.numericGiaViThuoc.Name = "numericGiaViThuoc";
	  this.numericGiaViThuoc.Size = new System.Drawing.Size(187, 20);
	  this.numericGiaViThuoc.TabIndex = 0;
	  this.numericGiaViThuoc.ThousandsSeparator = true;
	  this.numericGiaViThuoc.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
	  // 
	  // groupBox3
	  // 
	  this.groupBox3.Controls.Add(this.txtXGhiChuViThuoc);
	  this.groupBox3.Location = new System.Drawing.Point(7, 78);
	  this.groupBox3.Name = "groupBox3";
	  this.groupBox3.Size = new System.Drawing.Size(623, 141);
	  this.groupBox3.TabIndex = 5;
	  this.groupBox3.TabStop = false;
	  this.groupBox3.Text = "Lưu ý về vị thuốc này (đặc điểm, ... )";
	  // 
	  // txtXGhiChuViThuoc
	  // 
	  // 
	  // 
	  // 
	  this.txtXGhiChuViThuoc.Border.Class = "TextBoxBorder";
	  this.txtXGhiChuViThuoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.txtXGhiChuViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.txtXGhiChuViThuoc.Multiline = true;
	  this.txtXGhiChuViThuoc.Name = "txtXGhiChuViThuoc";
	  this.txtXGhiChuViThuoc.Size = new System.Drawing.Size(610, 115);
	  this.txtXGhiChuViThuoc.TabIndex = 2;
	  // 
	  // groupBox2
	  // 
	  this.groupBox2.Controls.Add(this.txtXTenViThuoc);
	  this.groupBox2.Location = new System.Drawing.Point(7, 20);
	  this.groupBox2.Name = "groupBox2";
	  this.groupBox2.Size = new System.Drawing.Size(168, 52);
	  this.groupBox2.TabIndex = 0;
	  this.groupBox2.TabStop = false;
	  this.groupBox2.Text = "Tên vị thuốc";
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
	  this.txtXTenViThuoc.Size = new System.Drawing.Size(146, 20);
	  this.txtXTenViThuoc.TabIndex = 1;
	  // 
	  // groupBox4
	  // 
	  this.groupBox4.Controls.Add(this.buttonXHuyThemViThuoc);
	  this.groupBox4.Controls.Add(this.buttonXThemViThuoc);
	  this.groupBox4.Location = new System.Drawing.Point(13, 249);
	  this.groupBox4.Name = "groupBox4";
	  this.groupBox4.Size = new System.Drawing.Size(640, 56);
	  this.groupBox4.TabIndex = 1;
	  this.groupBox4.TabStop = false;
	  this.groupBox4.Text = "Chức năng";
	  // 
	  // buttonXHuyThemViThuoc
	  // 
	  this.buttonXHuyThemViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonXHuyThemViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonXHuyThemViThuoc.Image = global::THUOCBAC.Properties.Resources.Xoa;
	  this.buttonXHuyThemViThuoc.Location = new System.Drawing.Point(373, 20);
	  this.buttonXHuyThemViThuoc.Name = "buttonXHuyThemViThuoc";
	  this.buttonXHuyThemViThuoc.Size = new System.Drawing.Size(257, 23);
	  this.buttonXHuyThemViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonXHuyThemViThuoc.TabIndex = 0;
	  this.buttonXHuyThemViThuoc.Text = "Hủy";
	  this.buttonXHuyThemViThuoc.Click += new System.EventHandler(this.buttonXHuyThemViThuoc_Click);
	  // 
	  // buttonXThemViThuoc
	  // 
	  this.buttonXThemViThuoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
	  this.buttonXThemViThuoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
	  this.buttonXThemViThuoc.Image = global::THUOCBAC.Properties.Resources.add;
	  this.buttonXThemViThuoc.Location = new System.Drawing.Point(7, 20);
	  this.buttonXThemViThuoc.Name = "buttonXThemViThuoc";
	  this.buttonXThemViThuoc.Size = new System.Drawing.Size(240, 23);
	  this.buttonXThemViThuoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
	  this.buttonXThemViThuoc.TabIndex = 0;
	  this.buttonXThemViThuoc.Text = "Thêm vị thuốc trên";
	  this.buttonXThemViThuoc.Click += new System.EventHandler(this.buttonXThemViThuoc_Click);
	  // 
	  // FormThemViThuoc
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(666, 320);
	  this.Controls.Add(this.groupBox4);
	  this.Controls.Add(this.groupBox1);
	  this.Name = "FormThemViThuoc";
	  this.Text = "FormThemViThuoc";
	  this.Load += new System.EventHandler(this.FormThemViThuoc_Load);
	  this.groupBox1.ResumeLayout(false);
	  this.groupBox6.ResumeLayout(false);
	  this.groupBox5.ResumeLayout(false);
	  ((System.ComponentModel.ISupportInitialize)(this.numericGiaViThuoc)).EndInit();
	  this.groupBox3.ResumeLayout(false);
	  this.groupBox2.ResumeLayout(false);
	  this.groupBox4.ResumeLayout(false);
	  this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXTenViThuoc;
	private System.Windows.Forms.GroupBox groupBox3;
	private DevComponents.DotNetBar.Controls.TextBoxX txtXGhiChuViThuoc;
	private System.Windows.Forms.GroupBox groupBox4;
	private DevComponents.DotNetBar.ButtonX buttonXThemViThuoc;
	private DevComponents.DotNetBar.ButtonX buttonXHuyThemViThuoc;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.NumericUpDown numericGiaViThuoc;
	private DevComponents.DotNetBar.LabelX labelX1;
	private System.Windows.Forms.GroupBox groupBox6;
	private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEDonViTinh;
	private DevComponents.Editors.ComboItem comboItem1;
	private DevComponents.Editors.ComboItem comboItem2;
	private DevComponents.Editors.ComboItem comboItem3;
	private DevComponents.Editors.ComboItem comboItem4;
  }
}