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
  public partial class frmChonTenHoacThemMoi:Form {

	private DataTable DT_MAIN;
	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();
	private string STR_NAME_CHOOSE = "";
	private int INT_ID_CHOOSE = -1311;
	private decimal DEC_DEBT_CHOOSE = 0;

	private const string CONST_STR_TEN_KHACHHANG = QTStringConst.TENKHACHHANG.STR;
	private const string CONST_STR_TIENNO_HIENTAI = "Tiền nợ hiện tại";

	public frmChonTenHoacThemMoi() {
	  InitializeComponent();
	}

	public frmChonTenHoacThemMoi(string _strTitleForm,int _intWidthForm,int _intHeightForm) {
	  InitializeComponent();
	  this.Text="Chọn "+_strTitleForm.ToLower();
	  btnXAddNew.Text="Thêm "+_strTitleForm.ToLower()+" mới";

	  //grpOldValue.Text=_strTitleForm+" cũ";
	  //grpNewValue.Text=_strTitleForm+" mới";
	  this.Width=_intWidthForm;
	  this.Height=_intHeightForm;
	  //INT_ID=_intIdCustomer;
	  //STR_NAME=_strNameCustomer;
	  //DT_MAIN=_dtMain;
	}

	private void frmChonTenHoacThemMoi_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  //QTAppTemp.STATIC_STR_NAME_CHOOSE=STR_NAME_CHOOSE;
	  //QTAppTemp.STATIC_INT_ID_CHOOSE=INT_ID_CHOOSE;
	  //QTAppTemp.STATIC_DEC_DEBT_CHOOSE=DEC_DEBT_CHOOSE;

	  //DT_MAIN=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();

	  //dgvXMain.DataSource=DT_MAIN;
	  //dgvXMain.Columns["STT"].DisplayIndex=0;
	  //QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dgvXMain);
	  //QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"STT",60,DataGridViewContentAlignment.MiddleCenter);
	  //QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"TienNoHienTai",CONST_STR_TIENNO_HIENTAI,120,DataGridViewContentAlignment.MiddleRight);
	  //QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"TenKhachHang",CONST_STR_TEN_KHACHHANG,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  //QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dgvXMain,new List<string>() { "IdBangKhachHang" });

	  //dgvXMain.Columns["TienNoHienTai"].DefaultCellStyle.Format="#,###.### vnđ";
	  //dgvXMain.Focus();
	  VOID_LOAD_FORM_FOCUS_LAST_ROW();
	}

	private void VOID_LOAD_FORM_FOCUS_LAST_ROW() {
	  VOID_LOAD_FORM();
	  QTLibraryFunction.STATIC_VOID_FOCUS_LAST_ROW_DGV(ref dgvXMain,"TenKhachHang");
	}

	private void VOID_LOAD_FORM() {
	  DT_MAIN=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();

	  dgvXMain.DataSource=DT_MAIN;
	  dgvXMain.Columns["STT"].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dgvXMain);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"STT",60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"TienNoHienTai",CONST_STR_TIENNO_HIENTAI,120,DataGridViewContentAlignment.MiddleRight);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,"TenKhachHang",CONST_STR_TEN_KHACHHANG,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dgvXMain,new List<string>() { "IdBangKhachHang" });

	  dgvXMain.Columns["TienNoHienTai"].DefaultCellStyle.Format="#,###.### vnđ";
	  dgvXMain.Focus();
	}

	private void btnXAccept_Click(object sender,EventArgs e) {

	  QTAppTemp.STATIC_DEC_DEBT_CHOOSE=DEC_DEBT_CHOOSE;
	  QTAppTemp.STATIC_INT_ID_CHOOSE=INT_ID_CHOOSE;
	  QTAppTemp.STATIC_STR_NAME_CHOOSE=STR_NAME_CHOOSE;
	  this.Close();
	}

	private void btnXAddNew_Click(object sender,EventArgs e) {

	}

	private void dgvXMain_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  DataGridViewRow r = dgvXMain.Rows[e.RowIndex];
		  //int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  //INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  DEC_DEBT_CHOOSE=(r.Cells["TienNoHienTai"].Value.ToString().Equals("")) ? 0 : Convert.ToDecimal(r.Cells["TienNoHienTai"].Value);
		  INT_ID_CHOOSE=Convert.ToInt32(r.Cells["IdBangKhachHang"].Value);
		  STR_NAME_CHOOSE=Convert.ToString(r.Cells["TenKhachHang"].Value);
		  //INT_INDEX_ROW_DANGCHON=Convert.ToInt32(r.Cells["STT"].Value);
		  //INT_INDEX_ROW_DANGCHON=e.RowIndex;
		  //btnXThayDoiTienNo.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR)) ? false : true;
		  //btnXXemChiTiet.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR)) ? false : true;
		  //btnXChangeNameCustomer.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR)) ? false : true;
		  btnXAccept.Enabled=true;
		  //DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  //DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}
  }
}
