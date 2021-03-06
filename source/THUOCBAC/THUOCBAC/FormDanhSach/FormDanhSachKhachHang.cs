﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using QTCommon;

namespace THUOCBAC.FormDanhSach {
  public partial class FormDanhSachKhachHang:Form {
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private int INT_ID_KH_DANGCHON=-1;
	private string STR_TEN_KH_DANGCHON="";
	private decimal DEC_TIENNO_DANGCHON=-1;
	private int INT_INDEX_ROW_DANGCHON = -1;

	//private const string CONST_STR_TEN_KHACHHANG = QTStringConst.TENKHACHHANG.STR;
	//private const string CONST_STR_TIENNO_HIENTAI = "Tiền nợ hiện tại";

	public FormDanhSachKhachHang() {
	  InitializeComponent();
	}

	private void FormDanhSachKhachHang_Load(object sender,EventArgs e) {
	  //voidHIENTHI_DGV_KHACHHANG();
	  //QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXDanhSachKH);
	  //QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXDanhSachKH,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);

	  QTAppTemp.QT_RESET_APP_TEMP();
	  VOID_LOAD_FORM_FOCUS_LAST_ROW();
	}

	private void VOID_LOAD_FORM() {
	  voidHIENTHI_DGV_KHACHHANG();
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXDanhSachKH);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXDanhSachKH,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXDanhSachKH,QTDbConst.TENKHACHHANG.STR,QTStringConst.TENKHACHHANG.STR,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXDanhSachKH,QTDbConst.TIENNO_HIENTAI.STR,QTStringConst.TIENNO_HIENTAI.STR,150,DataGridViewContentAlignment.MiddleRight);

	  dataGridViewXDanhSachKH.Columns[QTDbConst.ID_BANG_KHACHHANG.STR].Visible=false;
	  dataGridViewXDanhSachKH.Columns[QTDbConst.TIENNO_HIENTAI.STR].DefaultCellStyle.Format="#,###.### vnđ";
	}

	private void VOID_LOAD_FORM_FOCUS_LAST_ROW() {
	  VOID_LOAD_FORM();
	  QTLibraryFunction.STATIC_VOID_FOCUS_LAST_ROW_DGV(ref dataGridViewXDanhSachKH,QTDbConst.TENKHACHHANG.STR);
	}

	private void VOID_LOAD_FORM_FOCUS_CURRENT_ROW() {
	  VOID_LOAD_FORM();
	  QTLibraryFunction.STATIC_VOID_FOCUS_ROW_X_IN_DGV(ref dataGridViewXDanhSachKH,QTDbConst.TENKHACHHANG.STR,INT_INDEX_ROW_DANGCHON);
	}

	private void VOID_LOAD_FORM_FOCUS_ROW_ADD_SUCCESS() {
	  if(QTAppTemp.STATIC_STR_NAME_ADD_SUCCESS.Equals("")) {
		VOID_LOAD_FORM_FOCUS_LAST_ROW();
		return;
	  }
	  VOID_LOAD_FORM();
	  DataTable dtMain = new DataTable();
	  dtMain=(DataTable)dataGridViewXDanhSachKH.DataSource;
	  INT_INDEX_ROW_DANGCHON=QTLibraryFunction.STATIC_INT_INDEX_VALUE_EXIST_IN_COLUMN(QTAppTemp.STATIC_STR_NAME_ADD_SUCCESS,QTDbConst.TENKHACHHANG.STR,dtMain);
	  if(INT_INDEX_ROW_DANGCHON==QTDbConst.SODACBIET.INT)
		return;
	  QTLibraryFunction.STATIC_VOID_FOCUS_ROW_X_IN_DGV(ref dataGridViewXDanhSachKH,QTDbConst.TENKHACHHANG.STR,INT_INDEX_ROW_DANGCHON);
	}

	private void voidHIENTHI_DGV_KHACHHANG() {
	  dataGridViewXDanhSachKH.DataSource=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();
	  dataGridViewXDanhSachKH.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	}

	private void dataGridViewXDanhSachKH_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  DataGridViewRow r=dataGridViewXDanhSachKH.Rows[e.RowIndex];
		  //int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  //INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  DEC_TIENNO_DANGCHON=(r.Cells[QTDbConst.TIENNO_HIENTAI.STR].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells[QTDbConst.TIENNO_HIENTAI.STR].Value);
		  INT_ID_KH_DANGCHON=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_KHACHHANG.STR].Value);
		  STR_TEN_KH_DANGCHON=Convert.ToString(r.Cells[QTDbConst.TENKHACHHANG.STR].Value);
		  //INT_INDEX_ROW_DANGCHON=Convert.ToInt32(r.Cells[QTStringConst.SO_THUTU.STR].Value);
		  INT_INDEX_ROW_DANGCHON=e.RowIndex;
		  btnXThayDoiTienNo.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR))?false:true;
		  btnXXemChiTiet.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR))?false:true;
		  btnXChangeNameCustomer.Enabled=(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR)) ? false : true;
		  //DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  //DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXThayDoiTienNo_Click(object sender,EventArgs e) {
	  FormChucNang.FormThayDoiTienNo formThayDoiTienNo=new FormChucNang.FormThayDoiTienNo(INT_ID_KH_DANGCHON,STR_TEN_KH_DANGCHON,DEC_TIENNO_DANGCHON);
	  formThayDoiTienNo.ShowDialog();
	  //voidHIENTHI_DGV_KHACHHANG();
	  VOID_LOAD_FORM_FOCUS_CURRENT_ROW();
	  btnXThayDoiTienNo.Enabled=false;
	}

	private void btnXXemChiTiet_Click(object sender,EventArgs e) {
	  btnXXemChiTiet.Enabled=false;
	  if(STR_TEN_KH_DANGCHON.Equals(QTStringConst.KHONGGHIVAO.STR)) {
		MessageBox.Show("Bạn vui lòng chọn lại tên khách hàng !");
		return;
	  }
	  //int intIdKHVuaChonTrongComboBox=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
	  //string strTenKhachHangDangChon=comboBoxExTenKhachHang.Text;
	  DataTable dtLichSuTienNo=BL_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(INT_ID_KH_DANGCHON);
	  if(dtLichSuTienNo.Rows.Count==0) {
		MessageBox.Show("Hiện tại tiền nợ của khách hàng '"+STR_TEN_KH_DANGCHON+"' chưa lưu gì cả\nBạn hãy chọn 'Thay đổi tiền nợ' để cập nhật lại tiền nợ !");
		return;
	  }
	  if(dtLichSuTienNo.Rows.Count>0) {
		//DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChonTrongComboBox);
		FormChucNang.FormXemThongTinTienNo formXemThongTinTienNo=new FormChucNang.FormXemThongTinTienNo(dtLichSuTienNo,INT_ID_KH_DANGCHON,STR_TEN_KH_DANGCHON,DEC_TIENNO_DANGCHON,QTStringConst.HIDE_NUT_XACNHAN.STR);
		//formXemThongTinTienNo.voidHIENTHI_TIENNOCU_RA_NUMBERIC=new FormChucNang.FormXemThongTinTienNo.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TIENNOCU_RA_NUMBERIC);
		formXemThongTinTienNo.ShowDialog();
	  }
	}

	private void btnXAddCustomer_Click(object sender,EventArgs e) {
	  DataTable dtMain = new DataTable();
	  dtMain=(DataTable)dataGridViewXDanhSachKH.DataSource;
	  FormDialogPhu.frmThemTenVaoDanhSach frm = new FormDialogPhu.frmThemTenVaoDanhSach("Thêm tên khách hàng mới",491,157,dtMain);
	  frm.ShowDialog();
	  VOID_LOAD_FORM_FOCUS_ROW_ADD_SUCCESS();
	}

	private void btnXChangeNameCustomer_Click(object sender,EventArgs e) {
	  DataTable dtMain = new DataTable();
	  dtMain=(DataTable)dataGridViewXDanhSachKH.DataSource;
	  FormDialogPhu.frmSuaTenTrongDanhSach frm = new FormDialogPhu.frmSuaTenTrongDanhSach(QTStringConst.TENKHACHHANG.STR,491,230,INT_ID_KH_DANGCHON,STR_TEN_KH_DANGCHON,dtMain);
	  frm.ShowDialog();

	  VOID_LOAD_FORM_FOCUS_CURRENT_ROW();
	  btnXChangeNameCustomer.Enabled=false;
	}
  }
}
