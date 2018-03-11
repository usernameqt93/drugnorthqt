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
using QTCommon;

namespace THUOCBAC.FormChucNang {
  public partial class FormXemGiaThuoc:Form {
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private DataTable DT_VITHUOC;
	private DataTable DT_KHACHHANG;
	private DataTable DT_TENVITHUOC_THEO_TENKH;
	private int INT_MADONHANG_DANGCHON=-1;
	private int INT_ID_KH_DANGCHON=-2;
	private string STR_SDT_KH_DANGCHON="";
	private string STR_TEN_KH_DANGCHON = "";
	private decimal DEC_TIENNO_CU_DANGCHON=-2;
	private DateTime DT_THOIGIAN_VIETDH_DANGCHON=DateTime.Now;
	public FormXemGiaThuoc() {
	  InitializeComponent();
	}

	private void FormXemGiaThuoc_Load(object sender,EventArgs e) {
	  groupBoxTimTheoTenChinhXac.Visible=false;
	  voidCAPNHAT_COMBOBOX_TENVITHUOC_DACO_DH();
	  voidCAPNHAT_COMBOBOX_TENKH();
	}
	private void voidCAPNHAT_COMBOBOX_TENKH() {
	  DT_KHACHHANG=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  if(DT_KHACHHANG.Rows.Count>0) {
		comboBoxExTenKhachHang.DataSource=DT_KHACHHANG;
		comboBoxExTenKhachHang.DisplayMember=QTDbConst.TENKHACHHANG.STR;
		comboBoxExTenKhachHang.ValueMember=QTDbConst.ID_BANG_KHACHHANG.STR;
		comboBoxExTenKhachHang.SelectedIndex=0;
	  }
	}
	private void voidCAPNHAT_COMBOBOX_TENVITHUOC_DACO_DH() {
	  DT_VITHUOC=BL_DONHANG.dataTableBANG_DS_VITHUOC_DACO_DH();
	  if(DT_VITHUOC.Rows.Count>0) {
		comboBoxExTenViThuoc.DataSource=DT_VITHUOC;
		comboBoxExTenViThuoc.DisplayMember="TenViThuoc";
		comboBoxExTenViThuoc.ValueMember="MaViThuoc";
	  }
	}
	private void voidCAPNHAT_COMBOBOX_TENVITHUOC_THEO_TENKH(string strTenKhachHang) {
	  DT_TENVITHUOC_THEO_TENKH=BL_DONHANG.dataTableBANG_DS_VITHUOC_THEO_TENKH(strTenKhachHang);
	  if(DT_TENVITHUOC_THEO_TENKH.Rows.Count>0) {
		comboBoxExTenVTCuaKH.DataSource=DT_TENVITHUOC_THEO_TENKH;
		comboBoxExTenVTCuaKH.DisplayMember="TenViThuoc";
		comboBoxExTenVTCuaKH.ValueMember="MaViThuoc";
	  }
	}
	private void btnXHienThi_Click(object sender,EventArgs e) {
	  try {
		string strTenViThuoc=comboBoxExTenViThuoc.Text;
		if(strTenViThuoc.Equals("")) {
		  MessageBox.Show("Bạn chưa nhập tên vị thuốc cần hiển thị!");
		  return;
		}
		string strTenViThuocDaVietHoaChuCaiDau=""+strTenViThuoc.ElementAt(0).ToString().ToUpper()+strTenViThuoc.Substring(1);
		int intSTTCuaTenVTTrongComboBox=comboBoxExTenViThuoc.FindStringExact(strTenViThuocDaVietHoaChuCaiDau);
		if(intSTTCuaTenVTTrongComboBox==-1) {
		  MessageBox.Show("Vị thuốc '"+strTenViThuocDaVietHoaChuCaiDau+"' này bạn chưa từng thêm vào đơn hàng nào cả, vui lòng nhập tên khác!");
		  return;
		}
		if(intSTTCuaTenVTTrongComboBox>-1) {
		  DataTable dtLichSuGD=BL_DONHANG.dataTableBANG_LICHSU_GD_VT(strTenViThuocDaVietHoaChuCaiDau);
		  dataGridViewXLichSuGDVT.DataSource=dtLichSuGD;
		  dataGridViewXLichSuGDVT.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;

		  voidCAIDAT_HIENTHI_DGV_LICHSU();
		}
	  } catch(Exception ex) {
		MessageBox.Show("Có lỗi xảy ra ("+ex.Message+")");
	  }
	}

	private void dataGridViewXLichSuGDVT_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXemChiTietDonHang.Enabled=true;
		  DataGridViewRow r=dataGridViewXLichSuGDVT.Rows[e.RowIndex];
		  //int intSoViThuocTrongDH=(r.Cells["TongViThuoc"].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells["TongViThuoc"].Value);
		  //btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaDonHang"].Value);
		  STR_SDT_KH_DANGCHON="zz"+Convert.ToString(r.Cells["TenViThuoc"].Value);
		  STR_TEN_KH_DANGCHON=Convert.ToString(r.Cells[QTDbConst.TENKHACHHANG.STR].Value);
		  //DEC_TIENNO_CU_DANGCHON=(r.Cells["TienNoCu"].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells["TienNoCu"].Value);
		  //DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells["ThoiGianVietDonHangNay"].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells["ThoiGianVietDonHangNay"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXXemChiTietDonHang_Click(object sender,EventArgs e) {
	  btnXXemChiTietDonHang.Enabled=false;
	  FormChucNang.FormThemDonHang formXemChiTietDonHang=new FormChucNang.FormThemDonHang(
		INT_MADONHANG_DANGCHON,INT_ID_KH_DANGCHON,STR_SDT_KH_DANGCHON,DEC_TIENNO_CU_DANGCHON,QTStringConst.XEM_CHITIET.STR,DT_THOIGIAN_VIETDH_DANGCHON,STR_TEN_KH_DANGCHON);
	  formXemChiTietDonHang.ShowDialog();
	}

	private void comboBoxExTenKhachHang_DropDownClosed(object sender,EventArgs e) {
	  if(comboBoxExTenKhachHang.Text.Equals(""))
		return;
	  groupBoxTenVTTheoTenKH.Enabled=true;
	  btnXHienThiTheoTenKH.Enabled=true;
	  voidCAPNHAT_COMBOBOX_TENVITHUOC_THEO_TENKH(comboBoxExTenKhachHang.Text);
	}

	private void btnXHienThiTheoTenKH_Click(object sender,EventArgs e) {
	  try {
		string strTenViThuoc=comboBoxExTenVTCuaKH.Text;
		if(strTenViThuoc.Equals("")) {
		  MessageBox.Show("Bạn chưa nhập tên vị thuốc cần hiển thị!");
		  return;
		}
		string strTenViThuocDaVietHoaChuCaiDau=""+strTenViThuoc.ElementAt(0).ToString().ToUpper()+strTenViThuoc.Substring(1);
		int intSTTCuaTenVTTrongComboBox=comboBoxExTenViThuoc.FindStringExact(strTenViThuocDaVietHoaChuCaiDau);
		string strTenKhachHang=comboBoxExTenKhachHang.Text;
		if(intSTTCuaTenVTTrongComboBox==-1) {
		  MessageBox.Show("Hệ thống kiểm tra thấy không có tên vị thuốc '"+strTenViThuocDaVietHoaChuCaiDau+"' trong các đơn hàng của khách hàng '"+strTenKhachHang+"', bạn hãy xem lại!");
		  return;
		}
		if(intSTTCuaTenVTTrongComboBox>-1) {
		  DataTable dtLichSuGD=BL_DONHANG.dataTableBANG_LICHSU_GD_VT(strTenViThuocDaVietHoaChuCaiDau,strTenKhachHang);
		  dataGridViewXLichSuGDVT.DataSource=dtLichSuGD;
		  dataGridViewXLichSuGDVT.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;

		  voidCAIDAT_HIENTHI_DGV_LICHSU();
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}
	private void voidCAIDAT_HIENTHI_DGV_LICHSU() {
	  dataGridViewXLichSuGDVT.Columns["ThoiGianVietDonHangNay"].HeaderText="Đơn hàng viết lúc";
	  dataGridViewXLichSuGDVT.Columns["TongViThuoc"].HeaderText="Tổng vị thuốc trong đơn";
	  dataGridViewXLichSuGDVT.Columns["TongGiaTriDonHang"].HeaderText="Tổng giá trị";
	  dataGridViewXLichSuGDVT.Columns["TenViThuoc"].HeaderText=QTStringConst.TENVITHUOC.STR;
	  dataGridViewXLichSuGDVT.Columns["SoLuongViThuoc"].HeaderText=QTStringConst.SOLUONG.STR;
	  dataGridViewXLichSuGDVT.Columns["DonViGiaThuoc"].HeaderText=QTStringConst.DONVI.STR;
	  dataGridViewXLichSuGDVT.Columns["GiaViThuoc"].HeaderText=QTStringConst.DONGIA.STR;
	  dataGridViewXLichSuGDVT.Columns["ThanhTienTamThoi"].HeaderText=QTStringConst.THANHTIEN.STR;
	  dataGridViewXLichSuGDVT.Columns[QTDbConst.TENKHACHHANG.STR].HeaderText=QTStringConst.TENKHACHHANG.STR;
	  dataGridViewXLichSuGDVT.Columns["DonViGiaThuoc"].Width=44;
	  dataGridViewXLichSuGDVT.Columns["GiaViThuoc"].Width=88;
	  dataGridViewXLichSuGDVT.Columns["SoLuongViThuoc"].Width=77;
	  dataGridViewXLichSuGDVT.Columns["MaDonHang"].Visible=false;
	  dataGridViewXLichSuGDVT.Columns["TongGiaTriDonHang"].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXLichSuGDVT.Columns["GiaViThuoc"].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXLichSuGDVT.Columns["ThanhTienTamThoi"].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXLichSuGDVT.Columns["TongViThuoc"].DefaultCellStyle.Format="#,###.### vị thuốc";
	  //dataGridViewXLichSuGDVT.Columns["TongKhoiLuong"].DefaultCellStyle.Format="#,###.### Kg";
	}

	private void btnXTimTheoKiTu_Click(object sender,EventArgs e) {
	  string strKiTuCanTim=txtXKiTuCanTim.Text;
	  if(strKiTuCanTim.Length<2||strKiTuCanTim.Length>8) {
		MessageBox.Show("Bạn chỉ được điền từ 2 đến 8 kí tự!");
		return;
	  }
	  btnXTimTheoKiTu.Enabled=false;
	  try {
		DataTable dtLichSuGD=BL_DONHANG.dataTableBANG_LICHSU_CO_CACKITU(strKiTuCanTim);
		dataGridViewXLichSuGDVT.DataSource=dtLichSuGD;
		dataGridViewXLichSuGDVT.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;

		voidCAIDAT_HIENTHI_DGV_LICHSU();
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	  btnXTimTheoKiTu.Enabled=true;
	}
  }
}
