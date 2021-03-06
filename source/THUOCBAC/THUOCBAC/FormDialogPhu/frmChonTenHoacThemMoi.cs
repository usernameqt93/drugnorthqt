﻿using BusinessLogic;
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
	private int INT_ID_CHOOSE = QTDbConst.SODACBIET.INT;
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
	  VOID_LOAD_FORM_FOCUS_LAST_ROW();
	}

	private void VOID_LOAD_FORM_FOCUS_LAST_ROW() {
	  VOID_LOAD_FORM();
	  QTLibraryFunction.STATIC_VOID_FOCUS_LAST_ROW_DGV(ref dgvXMain,QTDbConst.TENKHACHHANG.STR);
	}

	private void VOID_LOAD_FORM() {
	  DT_MAIN=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();

	  dgvXMain.DataSource=DT_MAIN;
	  dgvXMain.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dgvXMain);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TIENNO_HIENTAI.STR,CONST_STR_TIENNO_HIENTAI,120,DataGridViewContentAlignment.MiddleRight);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TENKHACHHANG.STR,CONST_STR_TEN_KHACHHANG,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dgvXMain,new List<string>() { QTDbConst.ID_BANG_KHACHHANG.STR });

	  dgvXMain.Columns[QTDbConst.TIENNO_HIENTAI.STR].DefaultCellStyle.Format="#,###.### vnđ";
	  dgvXMain.Focus();
	}

	private void btnXAccept_Click(object sender,EventArgs e) {

	  QTAppTemp.STATIC_DEC_DEBT_CHOOSE=DEC_DEBT_CHOOSE;
	  QTAppTemp.STATIC_INT_ID_CHOOSE=INT_ID_CHOOSE;
	  QTAppTemp.STATIC_STR_NAME_CHOOSE=STR_NAME_CHOOSE;
	  this.Close();
	}

	private void btnXAddNew_Click(object sender,EventArgs e) {
	  DataTable dtMain = new DataTable();
	  dtMain=(DataTable)dgvXMain.DataSource;
	  FormDialogPhu.frmThemTenVaoDanhSach frm = new FormDialogPhu.frmThemTenVaoDanhSach("Thêm tên khách hàng mới",491,157,dtMain);
	  frm.ShowDialog();
	  VOID_LOAD_FORM_FOCUS_ROW_ADD_SUCCESS();
	}

	private void VOID_LOAD_FORM_FOCUS_ROW_ADD_SUCCESS() {
	  if(QTAppTemp.STATIC_STR_NAME_ADD_SUCCESS.Equals("")) {
		VOID_LOAD_FORM_FOCUS_LAST_ROW();
		return;
	  }
	  VOID_LOAD_FORM();
	  DataTable dtMain = new DataTable();
	  dtMain=(DataTable)dgvXMain.DataSource;
	  int INT_INDEX_ROW_DANGCHON=QTLibraryFunction.STATIC_INT_INDEX_VALUE_EXIST_IN_COLUMN(QTAppTemp.STATIC_STR_NAME_ADD_SUCCESS,QTDbConst.TENKHACHHANG.STR,dtMain);
	  if(INT_INDEX_ROW_DANGCHON==QTDbConst.SODACBIET.INT)
		return;
	  QTLibraryFunction.STATIC_VOID_FOCUS_ROW_X_IN_DGV(ref dgvXMain,QTDbConst.TENKHACHHANG.STR,INT_INDEX_ROW_DANGCHON);
	}

	private void dgvXMain_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  DataGridViewRow r = dgvXMain.Rows[e.RowIndex];
		  //int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  //INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  DEC_DEBT_CHOOSE=(r.Cells[QTDbConst.TIENNO_HIENTAI.STR].Value.ToString().Equals("")) ? 0 : Convert.ToDecimal(r.Cells[QTDbConst.TIENNO_HIENTAI.STR].Value);
		  INT_ID_CHOOSE=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_KHACHHANG.STR].Value);
		  STR_NAME_CHOOSE=Convert.ToString(r.Cells[QTDbConst.TENKHACHHANG.STR].Value);
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
