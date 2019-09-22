using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC {
  public partial class FormSplashScreen:Form {
	public FormSplashScreen() {
	  InitializeComponent();
	  progressBarXLoad.Minimum=0;
	  progressBarXLoad.Maximum=1000;
	  progressBarXLoad.Value=0;

	  timer1.Enabled=true;
	  //timer1.Interval=125;
	  timer1.Interval=25;
	  timer1.Start();
	}

	private int intValueCuaProgressBar=0;

	private void timer1_Tick(object sender,EventArgs e) {
	  intValueCuaProgressBar+=25;
	  progressBarXLoad.Value=intValueCuaProgressBar;
	  if(intValueCuaProgressBar>1000)
		this.Close();
	}

	private void FormSplashScreen_Load(object sender,EventArgs e) {
	  this.TransparencyKey=Color.Wheat;
	  this.BackColor=Color.Wheat;
	}
  }
}
