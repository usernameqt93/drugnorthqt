namespace THUOCBAC {
  partial class FormSplashScreen {
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
	  this.components = new System.ComponentModel.Container();
	  this.labelX1 = new DevComponents.DotNetBar.LabelX();
	  this.progressBarXLoad = new DevComponents.DotNetBar.Controls.ProgressBarX();
	  this.timer1 = new System.Windows.Forms.Timer(this.components);
	  this.labelX2 = new DevComponents.DotNetBar.LabelX();
	  this.SuspendLayout();
	  // 
	  // labelX1
	  // 
	  // 
	  // 
	  // 
	  this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
	  this.labelX1.Location = new System.Drawing.Point(12, 47);
	  this.labelX1.Name = "labelX1";
	  this.labelX1.Size = new System.Drawing.Size(766, 44);
	  this.labelX1.TabIndex = 0;
	  this.labelX1.Text = "Loading ...";
	  // 
	  // progressBarXLoad
	  // 
	  // 
	  // 
	  // 
	  this.progressBarXLoad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.progressBarXLoad.Location = new System.Drawing.Point(13, 98);
	  this.progressBarXLoad.Name = "progressBarXLoad";
	  this.progressBarXLoad.Size = new System.Drawing.Size(870, 30);
	  this.progressBarXLoad.TabIndex = 1;
	  this.progressBarXLoad.Text = "progressBarX1";
	  // 
	  // timer1
	  // 
	  this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
	  // 
	  // labelX2
	  // 
	  // 
	  // 
	  // 
	  this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
	  this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	  this.labelX2.Location = new System.Drawing.Point(669, 134);
	  this.labelX2.Name = "labelX2";
	  this.labelX2.Size = new System.Drawing.Size(214, 23);
	  this.labelX2.TabIndex = 2;
	  this.labelX2.Text = "Phạm Quốc Tuấn - ĐT 01667 002 325";
	  // 
	  // FormSplashScreen
	  // 
	  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	  this.ClientSize = new System.Drawing.Size(895, 171);
	  this.Controls.Add(this.labelX2);
	  this.Controls.Add(this.progressBarXLoad);
	  this.Controls.Add(this.labelX1);
	  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
	  this.Name = "FormSplashScreen";
	  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	  this.Text = "FormSplashScreen";
	  this.Load += new System.EventHandler(this.FormSplashScreen_Load);
	  this.ResumeLayout(false);

	}

	#endregion

	private DevComponents.DotNetBar.LabelX labelX1;
	private DevComponents.DotNetBar.Controls.ProgressBarX progressBarXLoad;
	private System.Windows.Forms.Timer timer1;
	private DevComponents.DotNetBar.LabelX labelX2;
  }
}