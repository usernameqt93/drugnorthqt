using System;
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
  public partial class FormDanhSachDonHang:Form {
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	private int INT_MADONHANG_DANGCHON=-1;
	private int INT_ID_KH_DANGCHON=-1;
	private string STR_SDT_KH_DANGCHON="";
	private decimal DEC_TIENNO_CU_DANGCHON=0;
	private DateTime DT_THOIGIAN_VIETDH_DANGCHON;
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private DataTable DT_KHACHHANG;
	private string STR_NUT_VUABAM="NutHienTatCa";

	public FormDanhSachDonHang() {
	  InitializeComponent();
	}

	private void btnXThemDonHang_Click(object sender,EventArgs e) {
	  FormChucNang.FormThemDonHang formThemDonHang=new FormChucNang.FormThemDonHang();
	  formThemDonHang.ShowDialog();
	  //dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang();
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  voidCAPNHAT_COMBOBOX_TENKH();
	}
	private void FormDanhSachDonHang_Load(object sender,EventArgs e) {
	  //dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang();
	  dateTimeInputThoiGian.Value=DateTime.Now;
	  voidCAPNHAT_COMBOBOX_TENKH();
	  //comboBoxExTenKhachHang.SelectedValue=0;
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  dataGridViewXCacDonHang.Columns["ThoiGianVietDonHangNay"].HeaderText="Thời gian viết";
	  dataGridViewXCacDonHang.Columns["TongViThuoc"].HeaderText="Tổng số vị thuốc";
	  dataGridViewXCacDonHang.Columns["TongKhoiLuong"].HeaderText="Tổng khối lượng";
	  dataGridViewXCacDonHang.Columns["TongGiaTriDonHang"].HeaderText="Tổng giá trị";
	  dataGridViewXCacDonHang.Columns["TenKhachHang"].HeaderText="Tên khách hàng";
	  dataGridViewXCacDonHang.Columns["MaDonHang"].Visible=false;
	  dataGridViewXCacDonHang.Columns["IdBangKhachHang"].Visible=false;
	  dataGridViewXCacDonHang.Columns["SDTKhachHang"].Visible=false;
	  dataGridViewXCacDonHang.Columns["TienNoCu"].Visible=false;
	  dataGridViewXCacDonHang.Columns["TongGiaTriDonHang"].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXCacDonHang.Columns["TongViThuoc"].DefaultCellStyle.Format="#,###.### vị thuốc";
	  dataGridViewXCacDonHang.Columns["TongKhoiLuong"].DefaultCellStyle.Format="#,###.### Kg";
	}
	private void voidHIENTHI_DGV_DH_CO_STT(string strViTriTroDen,string strDieuKien,int intIdBangKhachHang) {
	  dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang(strDieuKien,intIdBangKhachHang);
	  if(strDieuKien.Equals("TatCa"))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị tất cả đơn hàng)";
	  if(strDieuKien.Equals("TheoIdBangKhachHang"))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị những đơn hàng có TÊN KHÁCH HÀNG là '"+comboBoxExTenKhachHang.Text+"' )";
	  dataGridViewXCacDonHang.Columns["STT"].DisplayIndex=0;
	  if(strViTriTroDen.Equals("ViTriCuoiCung")) {
		//chuyển xuống dòng dưới cùng
		int intSoThuTuHangMuonTroVao=0;
		if(dataGridViewXCacDonHang.RowCount>1) { 
		  intSoThuTuHangMuonTroVao=dataGridViewXCacDonHang.RowCount-1;
		dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao].Cells["TongKhoiLuong"];// Đưa Control về vị trí của nó
		//dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao];
		dataGridViewXCacDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
		}
	  }
	}
	private void voidHIENTHI_DGV_THEONGAY(string strViTriTroDen,DateTime dtThoiGianTimKiem) {
	  dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTable_DANHSACH_DH_THEONGAY(dtThoiGianTimKiem);
		groupBoxDanhSachDH.Text=
		  "Danh sách đơn hàng (Đang hiển thị những đơn hàng trong ngày "+dtThoiGianTimKiem.Day+" tháng "+dtThoiGianTimKiem.Month+" năm "+dtThoiGianTimKiem.Year+" )";
	  dataGridViewXCacDonHang.Columns["STT"].DisplayIndex=0;
	  if(strViTriTroDen.Equals("ViTriCuoiCung")) {
		//chuyển xuống dòng dưới cùng
		int intSoThuTuHangMuonTroVao=0;
		if(dataGridViewXCacDonHang.RowCount>1) {
		  intSoThuTuHangMuonTroVao=dataGridViewXCacDonHang.RowCount-1;
		  dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao].Cells["TongKhoiLuong"];// Đưa Control về vị trí của nó
		  //dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao];
		  dataGridViewXCacDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
		}
	  }
	}
	private void dataGridViewXCacDonHang_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXemChiTietDonHang.Enabled=true;
		  DataGridViewRow r=dataGridViewXCacDonHang.Rows[e.RowIndex];
		  int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  INT_ID_KH_DANGCHON=Convert.ToInt32(r.Cells["IdBangKhachHang"].Value);
		  STR_SDT_KH_DANGCHON=Convert.ToString(r.Cells["SDTKhachHang"].Value);
		  DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		  //INT_MA_CHITIET_DONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaChiTietDonHang"].Value);
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
		MessageBox.Show(@"Lỗi: "+ex.Message,@"Thông Báo");
	  }
	}

	private void btnXXemChiTietDonHang_Click(object sender,EventArgs e) {
	  btnXXemChiTietDonHang.Enabled=false;
	  FormChucNang.FormThemDonHang formXemChiTietDonHang=new FormChucNang.FormThemDonHang(
		INT_MADONHANG_DANGCHON,INT_ID_KH_DANGCHON,STR_SDT_KH_DANGCHON,DEC_TIENNO_CU_DANGCHON,"XemChiTiet",DT_THOIGIAN_VIETDH_DANGCHON);
	  formXemChiTietDonHang.ShowDialog();
	  //dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang();
	  if(STR_NUT_VUABAM.Equals("NutHienTatCa"))
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  if(STR_NUT_VUABAM.Equals("NutTimTheoNgay"))
		btnXTimKiemTheoNgay.PerformClick();
	  if(STR_NUT_VUABAM.Equals("NutTimTheoTen")) {
		int intIdBangKH=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue);
		voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TheoIdBangKhachHang",intIdBangKH);
	  }
	  voidCAPNHAT_COMBOBOX_TENKH();
	}

	private void btnXXoaDH_Click(object sender,EventArgs e) {
	  string strLoi="";
	  bool boolabc=BL_DONHANG.boolDELETE_BANG_DSDH_THEOID(ref strLoi,INT_MADONHANG_DANGCHON);
	  if(boolabc) {
		voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
		MessageBox.Show("Bạn vừa XÓA đơn hàng trống có 0 vị thuốc kia THÀNH CÔNG");
	  } else {
		MessageBox.Show("Khi xóa đơn hàng trống xảy ra lỗi ("+strLoi+")");
	  }
	  btnXXoaDH.Enabled=false;
	  btnXXemChiTietDonHang.Enabled=false;
	}
	private void voidCAPNHAT_COMBOBOX_TENKH() {
	  DT_KHACHHANG=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  comboBoxExTenKhachHang.DataSource=DT_KHACHHANG;
	  comboBoxExTenKhachHang.DisplayMember="TenKhachHang";
	  comboBoxExTenKhachHang.ValueMember="IdBangKhachHang";
	  comboBoxExTenKhachHang.SelectedIndex=0;
	}

	private void comboBoxExTenKhachHang_DropDownClosed(object sender,EventArgs e) {
	  btnXTimKiemTheoTenKH.Enabled=true;
	}

	private void btnXTimKiemTheoTenKH_Click(object sender,EventArgs e) {
	  int intIdBangKH=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue);
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TheoIdBangKhachHang",intIdBangKH);
	  btnXTimKiemTheoTenKH.Enabled=false;
	  STR_NUT_VUABAM="NutTimTheoTen";
	}

	private void btnXHienThiTatCaDH_Click(object sender,EventArgs e) {
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  STR_NUT_VUABAM="NutHienTatCa";
	}

	private void btnXTimKiemTheoNgay_Click(object sender,EventArgs e) {
	  DateTime dtThoiGianTimKiem=dateTimeInputThoiGian.Value;
	  voidHIENTHI_DGV_THEONGAY("ViTriCuoiCung",dtThoiGianTimKiem);
	  STR_NUT_VUABAM="NutTimTheoNgay";
	}
  }
}
