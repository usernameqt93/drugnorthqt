using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormCaiDat {
  public partial class frmLoginOption:Form {
	public frmLoginOption() {
	  InitializeComponent();
	}

	private void btnXExit_Click(object sender,EventArgs e) {
	  if(txtXPassword.Text.Length<8) {
		this.Close();
		return;
	  }

	  if(txtXPassword.Text.Equals("adminpqt93")) {
		FormCaiDat.frmOptionForQuocTuan frm = new frmOptionForQuocTuan();

		frm.Show();
		this.Close();
	  }
	}

	private void frmLoginOption_Load(object sender,EventArgs e) {
	  txtXPassword.Focus();
	}

	private void txtXPassword_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.Enter) {
		btnXExit.PerformClick();
	  }
	}
  }
}
