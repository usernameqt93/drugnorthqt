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

namespace THUOCBAC.FormDialogPhu {
  public partial class frmThemTenVaoDanhSach:Form {
	private DataTable DT_MAIN;

	public frmThemTenVaoDanhSach() {
	  InitializeComponent();
	}

	public frmThemTenVaoDanhSach(string _strTitleForm,int _intWidthForm,int _intHeightForm,DataTable _dtMain) {
	  InitializeComponent();
	  this.Text=_strTitleForm;
	  this.Width=_intWidthForm;
	  this.Height=_intHeightForm;
	  DT_MAIN=_dtMain;
	}

	private void frmThemTenVaoDanhSach_Load(object sender,EventArgs e) {
	  txtXValue.Focus();
	}

	private void btnXCancel_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void btnXAccept_Click(object sender,EventArgs e) {
	  if(txtXValue.Text.Equals("")) {
		QTMessageConst.CUSTOMER_NAME_MUSTNOT_BE_EMPTY();
		txtXValue.Focus();
		return;
	  }
	  if(txtXValue.Text.Length<3) {
		QTMessageConst.CUSTOMER_NAME_MUST_CONTAIN_MORE_X_CHAR(3);
		txtXValue.Focus();
		return;
	  }
	  if(BOOL_VALUE_EXIST_IN_COLUMN(txtXValue.Text,"TenKhachHang",DT_MAIN)) {
		QTMessageConst.CUSTOMER_NAME_EXIST_IN_DB();
		txtXValue.Focus();
		return;
	  }
	}

	private bool BOOL_VALUE_EXIST_IN_COLUMN(string _strValue,string _strIdColumn,DataTable _dtMain) {
	  int intCountDtMain = _dtMain.Rows.Count;
	  if(intCountDtMain>0) {
		for(int i = 0;i<intCountDtMain;i++) {
		  string strTemp = _dtMain.Rows[i][_strIdColumn].ToString();
		  if(strTemp.Equals(_strValue)) {
			return true;
		  }
		}
	  }
	  return false;
	}
  }
}
