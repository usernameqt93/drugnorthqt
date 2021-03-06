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
  public partial class frmChonTenTrongDanhSach:Form {
	private DataTable DT_MAIN;
	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();
	private string STR_NAME_CHOOSE="";
	private int INT_ID_CHOOSE= QTDbConst.SODACBIET.INT;

	public frmChonTenTrongDanhSach() {
	  InitializeComponent();
	}

	public frmChonTenTrongDanhSach(string _strTitleForm,int _intWidthForm) {
	  InitializeComponent();
	  this.Text=_strTitleForm;
	  this.Width=_intWidthForm;
	}

	private void frmChonTenTrongDanhSach_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  //QTAppInfo.STATIC_STR_NAME_CHOOSE=STR_NAME_CHOOSE;
	  //QTAppInfo.STATIC_STR_ID_CHOOSE=STR_ID_CHOOSE;
	  //DT_MAIN=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  DT_MAIN=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();
	  //QTLibraryFunction.STATIC_VOID_ADD_STT_COL_TO_DATATABLE(ref DT_MAIN);
	  dgvXMain.DataSource=DT_MAIN;
	  dgvXMain.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dgvXMain);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TENKHACHHANG.STR,QTStringConst.TENKHACHHANG.STR,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TIENNO_HIENTAI.STR,QTStringConst.TIENNO_HIENTAI.STR,110,DataGridViewContentAlignment.MiddleRight);
	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dgvXMain,new List<string>() { QTDbConst.ID_BANG_KHACHHANG.STR });

	  dgvXMain.Columns[QTDbConst.TIENNO_HIENTAI.STR].DefaultCellStyle.Format="#,###.### vnđ";
	}

	private void btnXClose_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void dgvXMain_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXChoose.Enabled=true;
		  DataGridViewRow r = dgvXMain.Rows[e.RowIndex];
		  STR_NAME_CHOOSE=Convert.ToString(r.Cells[QTDbConst.TENKHACHHANG.STR].Value);
		  INT_ID_CHOOSE=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_KHACHHANG.STR].Value);
		  //MessageBox.Show(STR_NAME_CHOOSE+STR_ID_CHOOSE);

		  //int intSoViThuocTrongDH = (r.Cells["TongViThuoc"].Value.ToString().Equals("")) ? 0 : Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0) ? true : false;
		  //INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  //STR_SDT_KH_DANGCHON=Convert.ToString(r.Cells["SDTKhachHang"].Value);
		  //DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals("")) ? 0 : Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  //DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals("")) ? DateTime.Now : Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		  //STR_TEN_VITHUOC_DANGCHON=Convert.ToString(r.Cells["TenViThuoc"].Value);
		  //STR_TEN_VITHUOC=Convert.ToString(r.Cells["TenViThuoc"].Value);
		  //INT_MAGIATHUOC=Convert.ToInt32(r.Cells["MaGiaThuoc"].Value);
		  //DEC_GIA_VITHUOC=Convert.ToDecimal(r.Cells["GiaViThuoc"].Value);
		  //STR_DONVITINH=Convert.ToString(r.Cells["DonViGiaThuoc"].Value);
		  //INT_MA_VITHUOC=Convert.ToInt32(r.Cells["MaViThuoc"].Value);
		  //txtIdLopHoc.Text=Convert.ToString(r.Cells["IdLopHoc"].Value);
		  //txtTenLopHoc.Text=Convert.ToString(r.Cells["TenLopHoc"].Value);
		  //string abc=dataGridViewDSLopHoc.Rows[e.RowIndex].Cells["IdMonHoc"].Value.ToString();
		  //comboBoxLoaiLopHoc.SelectedValue=abc;
		  //dateTimePickerBatDauhoc.Value=Convert.ToDateTime(r.Cells["ThoiGianBatDau"].Value);
		  //dateTimePickerKetThucHoc.Value=Convert.ToDateTime(r.Cells["ThoiGianKetthuc"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(this.Text+" - dgvXMain_CellClick - "+@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXChoose_Click(object sender,EventArgs e) {
	  QTAppTemp.STATIC_STR_NAME_CHOOSE=STR_NAME_CHOOSE;
	  QTAppTemp.STATIC_INT_ID_CHOOSE=INT_ID_CHOOSE;
	  this.Close();
	}
  }
}
