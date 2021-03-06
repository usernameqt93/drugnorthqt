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

namespace THUOCBAC.FormDanhSach {
  public partial class FormDanhSachKhachHang:Form {
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private int INT_ID_KH_DANGCHON=-1;
	private string STR_TEN_KH_DANGCHON="";
	private decimal DEC_TIENNO_DANGCHON=-1;
	public FormDanhSachKhachHang() {
	  InitializeComponent();
	}

	private void FormDanhSachKhachHang_Load(object sender,EventArgs e) {
	  voidHIENTHI_DGV_KHACHHANG();
	  dataGridViewXDanhSachKH.Columns["TenKhachHang"].HeaderText="Tên khách hàng";
	  dataGridViewXDanhSachKH.Columns["TienNoHienTai"].HeaderText="Tiền nợ hiện tại";
	  dataGridViewXDanhSachKH.Columns["IdBangKhachHang"].Visible=false;
	  dataGridViewXDanhSachKH.Columns["TienNoHienTai"].DefaultCellStyle.Format="#,###.### vnđ";
	}
	private void voidHIENTHI_DGV_KHACHHANG() {
	  dataGridViewXDanhSachKH.DataSource=BL_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();
	  dataGridViewXDanhSachKH.Columns["STT"].DisplayIndex=0;
	}

	private void dataGridViewXDanhSachKH_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  DataGridViewRow r=dataGridViewXDanhSachKH.Rows[e.RowIndex];
		  //int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  //INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  DEC_TIENNO_DANGCHON=(r.Cells["TienNoHienTai"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoHienTai"].Value);
		  INT_ID_KH_DANGCHON=Convert.ToInt32(r.Cells["IdBangKhachHang"].Value);
		  STR_TEN_KH_DANGCHON=Convert.ToString(r.Cells["TenKhachHang"].Value);
		  btnXThayDoiTienNo.Enabled=(STR_TEN_KH_DANGCHON.Equals(" --Không ghi vào--"))?false:true;
		  btnXXemChiTiet.Enabled=(STR_TEN_KH_DANGCHON.Equals(" --Không ghi vào--"))?false:true;
		  //DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  //DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,@"Thông Báo");
	  }
	}

	private void btnXThayDoiTienNo_Click(object sender,EventArgs e) {
	  FormChucNang.FormThayDoiTienNo formThayDoiTienNo=new FormChucNang.FormThayDoiTienNo(INT_ID_KH_DANGCHON,STR_TEN_KH_DANGCHON,DEC_TIENNO_DANGCHON);
	  formThayDoiTienNo.ShowDialog();
	  voidHIENTHI_DGV_KHACHHANG();
	  btnXThayDoiTienNo.Enabled=false;
	}

	private void btnXXemChiTiet_Click(object sender,EventArgs e) {
	  btnXXemChiTiet.Enabled=false;
	  if(STR_TEN_KH_DANGCHON.Equals(" --Không ghi vào--")) {
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
		FormChucNang.FormXemThongTinTienNo formXemThongTinTienNo=new FormChucNang.FormXemThongTinTienNo(dtLichSuTienNo,INT_ID_KH_DANGCHON,STR_TEN_KH_DANGCHON,DEC_TIENNO_DANGCHON,"Ẩn nút Xác nhận");
		//formXemThongTinTienNo.voidHIENTHI_TIENNOCU_RA_NUMBERIC=new FormChucNang.FormXemThongTinTienNo.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TIENNOCU_RA_NUMBERIC);
		formXemThongTinTienNo.ShowDialog();
	  }
	}
  }
}
