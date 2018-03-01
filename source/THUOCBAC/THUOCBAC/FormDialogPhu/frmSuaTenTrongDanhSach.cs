using BusinessLogic;
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
  public partial class frmSuaTenTrongDanhSach:Form {
	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();
	private int INT_ID;
	private string STR_NAME;
	private DataTable DT_MAIN;

	public frmSuaTenTrongDanhSach() {
	  InitializeComponent();
	}

	public frmSuaTenTrongDanhSach(string _strTitleForm,int _intWidthForm,int _intHeightForm,int _intIdCustomer,string _strNameCustomer,DataTable _dtMain) {
	  InitializeComponent();
	  this.Text="Sửa "+_strTitleForm.ToLower();
	  grpOldValue.Text=_strTitleForm+" cũ";
	  grpNewValue.Text=_strTitleForm+" mới";
	  this.Width=_intWidthForm;
	  this.Height=_intHeightForm;
	  INT_ID=_intIdCustomer;
	  STR_NAME=_strNameCustomer;
	  DT_MAIN=_dtMain;
	}

	private void btnXCancel_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void frmSuaTenTrongDanhSach_Load(object sender,EventArgs e) {
	  txtXOldValue.Text=STR_NAME;
	  txtXNewValue.Text=STR_NAME;
	  txtXNewValue.Focus();
	  txtXNewValue.SelectAll();
	}

	private void btnXAccept_Click(object sender,EventArgs e) {
	  string strValue = txtXNewValue.Text.Trim();
	  if(strValue.Length<3) {
		QTMessageConst.CUSTOMER_NAME_MUST_CONTAIN_MORE_X_CHAR(3);
		txtXNewValue.Focus();
		return;
	  }

	  if(QTLibraryFunction.STATIC_BOOL_VALUE_EXIST_IN_COLUMN(strValue,"TenKhachHang",DT_MAIN)) {
		QTMessageConst.CUSTOMER_NAME_EXIST_IN_DB(strValue);
		txtXNewValue.Focus();
		return;
	  }

	  string strNameCustomerUpper = ""+strValue.ElementAt(0).ToString().ToUpper()+strValue.Substring(1);
	  string strLoi = "";
	  string strTrangThaiSuaTienNo = BL_KHACHHANG.STR_SUA_TEN_KHACHHANG(ref strLoi,strNameCustomerUpper,INT_ID);
	  if(strTrangThaiSuaTienNo.Equals("false")&&!strLoi.Equals("1")) {
		MessageBox.Show("Xảy ra lỗi khi "+this.Text.ToLower()+" ("+strLoi+") !");
		return;
	  } else {
		MessageBox.Show(this.Text+" '"+STR_NAME+"' thành '"+strNameCustomerUpper+"' thành công !");
		this.Close();
	  }
	}
  }
}
