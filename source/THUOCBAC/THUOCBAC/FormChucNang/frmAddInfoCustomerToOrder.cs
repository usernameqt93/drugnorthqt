using QTCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormChucNang {
  public partial class frmAddInfoCustomerToOrder:Form {
	public frmAddInfoCustomerToOrder() {
	  InitializeComponent();
	}

	private void frmAddInfoCustomerToOrder_Load(object sender,EventArgs e) {

	}

	private void btnXChooseCustomer_Click(object sender,EventArgs e) {
	  FormDialogPhu.frmChonTenHoacThemMoi frm = new FormDialogPhu.frmChonTenHoacThemMoi(QTStringConst.TENKHACHHANG.STR,500,700);
	  frm.ShowDialog();
	  txtXNameCustomer.Text=QTAppTemp.STATIC_STR_NAME_CHOOSE;
	  numericUpDownTienNo.Value=QTAppTemp.STATIC_DEC_DEBT_CHOOSE;
	}
  }
}
