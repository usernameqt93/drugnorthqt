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
  public partial class FormThemDonXacNhan:Form {
	
	private DataTable DT_VITHUOC=new DataTable();
	private BL_DonXacNhan BL_DON_XACNHAN=new BL_DonXacNhan();
	private int INT_MA_DONXACNHAN_HIENTAI=-1;
	private string STR_CHUCNANG_CUA_FORM="";
	private int INT_MA_VITHUOC_DANGCHON=-1;

	public FormThemDonXacNhan() {
	  InitializeComponent();
	}
	public FormThemDonXacNhan(int intMaDonXacNhanHienTai,string strChucNangCuaForm) {
	  InitializeComponent();
	  INT_MA_DONXACNHAN_HIENTAI=intMaDonXacNhanHienTai;
	  STR_CHUCNANG_CUA_FORM=strChucNangCuaForm;
	}
	private void FormThemDonXacNhan_Load(object sender,EventArgs e) {
	  string strErr="";
	  string strResult="";
	  DateTime dateBayGio=DateTime.Now;
	  if(INT_MA_DONXACNHAN_HIENTAI==-1)
		INT_MA_DONXACNHAN_HIENTAI=BL_DON_XACNHAN.intMaDonXacNhanVuaThemCoThoiGianViet(ref strErr,ref strResult,dateBayGio);

	  DT_VITHUOC=BL_DON_XACNHAN.dataTableBangDanhSachViThuocXepTheoTenThuoc();
	  if(DT_VITHUOC.Rows.Count>0) {
		comboBoxExTenThuoc.DataSource=DT_VITHUOC;
		comboBoxExTenThuoc.DisplayMember="TenViThuoc";
		comboBoxExTenThuoc.ValueMember="MaViThuoc";
		comboBoxExTenThuoc.SelectedIndex=0;
	  }

	  //if(STR_CHUCNANG_CUA_FORM.Equals("ThemDonHang")) {
	  //  labelXTieuDeBang.Text="Bảng thêm đơn hàng mới ("+dateBayGio.ToString("dd/MM/yyyy HH:mm:ss")+")";

	  voidHIENTHI_DGV_CO_STT();
	  dataGridViewXDSThuocXacNhan.Columns["MaChiTietDonXinXacNhan"].Visible=false;
	  dataGridViewXDSThuocXacNhan.Columns["MaViThuoc"].Visible=false;
	  //dataGridViewXChiTietDonHang.Columns["GiaViThuoc"].DefaultCellStyle.Format="#,###.### vnđ";
	  //dataGridViewXChiTietDonHang.Columns["ThanhTienTamThoi"].DefaultCellStyle.Format="#,###.### vnđ";
	  voidHIENTHI_THONGTIN_NGUOIDUNG_DALUU();
	  if(dataGridViewXDSThuocXacNhan.RowCount<2)
		btnXXemBanIn.Enabled=false;

	}
	private void voidHIENTHI_THONGTIN_NGUOIDUNG_DALUU() {
	  string strHoTen="";
	  string strSoCMTND="";
	  DateTime dtNgaySinh=DateTime.Now;
	  string strHoKhauThuongTru="";
	  BL_DON_XACNHAN.voidLAY_THONGTIN_NGUOIVIET(ref strHoTen,ref strSoCMTND,ref dtNgaySinh,ref strHoKhauThuongTru,INT_MA_DONXACNHAN_HIENTAI);
	  txtXHoTen.Text=strHoTen;
	  txtXSoCMTND.Text=strSoCMTND;
	  dateTimeInputNgaySinh.Value=dtNgaySinh;
	  txtXHoKhauThuongTru.Text=strHoKhauThuongTru;
	}
	private void voidHIENTHI_DGV_CO_STT() {
	  dataGridViewXDSThuocXacNhan.DataSource=BL_DON_XACNHAN.dataTableBangChiTietDonXacNhanTheoMaDonXacNhanCoSTT(INT_MA_DONXACNHAN_HIENTAI);
	  dataGridViewXDSThuocXacNhan.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	}

	private void btnXXemBanIn_Click(object sender,EventArgs e) {
	  try {
		if(txtXHoTen.Text.Equals(""))
		  MessageBox.Show("Họ tên của bạn không được để trống");
		else if(txtXSoCMTND.Text.Equals(""))
		  MessageBox.Show("Số chứng minh thư nhân dân của bạn không được để trống");
		else if(txtXHoKhauThuongTru.Text.Equals(""))
		  MessageBox.Show("Hộ khẩu thường trú không được để trống");
		else {
		  DataTable dtChiTietDonXacNhan=BL_DON_XACNHAN.dataTableBangChiTietDonXacNhanDeIn(INT_MA_DONXACNHAN_HIENTAI);

		  if(dtChiTietDonXacNhan.Rows.Count<1)
			MessageBox.Show("Hiện tại bảng chưa có vị thuốc nào, chưa xem bản in được");
		  else {
			//string strLoi="";
			//string strResult="";
			//decimal decTongTienDonHang=BL_DONHANG.decTongTienDonHangTheoMaDonHang(ref strLoi,ref strResult,INT_MA_DONHANG_HIENTAI);
			string strNgaySinh=dateTimeInputNgaySinh.Value.ToString("dd/MM/yyyy");
			voidCAPNHAT_THONGTIN_DONXN();
			FormReport.FormReportDonXacNhan f=new FormReport.FormReportDonXacNhan(dtChiTietDonXacNhan,txtXHoTen.Text,strNgaySinh,txtXSoCMTND.Text,txtXHoKhauThuongTru.Text);
			f.ShowDialog();
		  }
		}
		
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}
	private void voidCAPNHAT_THONGTIN_DONXN() {
	  string strLoi="";
	  //string strResult="";
	  //decimal decTongTienDonHang=BL_DONHANG.decTongTienDonHangTheoMaDonHang(ref strLoi,ref strResult,INT_MA_DONHANG_HIENTAI);
	  //decimal decTongTienDonHang=0;
	  string strHoTen=txtXHoTen.Text;
	  DateTime dtNgaySinh=dateTimeInputNgaySinh.Value;
	  string strSoCMTND=txtXSoCMTND.Text;
	  string strHoKhauThuongTru=txtXHoKhauThuongTru.Text;
	  int intTongViThuoc=0;
	  //decimal decTongKhoiLuong=0;
	  BL_DON_XACNHAN.voidLAY_TONG_VITHUOC_TRONG_DONXN(ref intTongViThuoc,INT_MA_DONXACNHAN_HIENTAI);
	  bool boolUpdateThongTinDonXacNhan=BL_DON_XACNHAN.boolUPDATE_THONGTIN_DONXN(
		ref strLoi,strHoTen,strSoCMTND,dtNgaySinh,strHoKhauThuongTru,intTongViThuoc,INT_MA_DONXACNHAN_HIENTAI);
	}
	private void btnXThemThuoc_Click(object sender,EventArgs e) {
	  try {
		if(INT_MA_VITHUOC_DANGCHON<0)
		  MessageBox.Show("Bạn hãy chọn lại tên thuốc!");
		else if(txtXHoTen.Text.Equals(""))
		  MessageBox.Show("Bạn hãy điền đầy đủ họ và tên");
		else if(txtXSoCMTND.Text.Equals(""))
		  MessageBox.Show("Bạn hãy điền đầy đủ số chứng minh thư nhân dân");
		else if(txtXHoKhauThuongTru.Text.Equals(""))
		  MessageBox.Show("Bạn hãy điền đầy đủ hộ khẩu thường trú !");
		else {
		  string strLoi="";
		  string strResult="";
		  string strTenViThuocNay=Convert.ToString(comboBoxExTenThuoc.Text);
		  int intSoViThuocNayDaCoTrongMaDonHang=BL_DON_XACNHAN.intCoBaoNhieuMaViThuocTrongMaDonXacNhan(
			ref strLoi,ref strResult,INT_MA_VITHUOC_DANGCHON,INT_MA_DONXACNHAN_HIENTAI);
		  if(intSoViThuocNayDaCoTrongMaDonHang>0)
			MessageBox.Show("Vị thuốc '"+strTenViThuocNay+"' đã được thêm vào bảng, bạn hãy xem lại bảng");
		  else {
			string strTrangThaiInsertBang=BL_DON_XACNHAN.strInsertBangChiTietDonHangCoMaDonHang(
			  ref strLoi,INT_MA_VITHUOC_DANGCHON,INT_MA_DONXACNHAN_HIENTAI);
			if(strTrangThaiInsertBang.Equals("false"))
			  MessageBox.Show("Trạng thái thêm vào bảng lỗi ("+strLoi+")");
			else {
			  voidHIENTHI_DGV_CO_STT();
			  voidCAPNHAT_THONGTIN_DONXN();
			  MessageBox.Show("Thêm vị thuốc '"+strTenViThuocNay+"' vào bảng thành công");
			  btnXThemThuoc.Enabled=false;
			  btnXXemBanIn.Enabled=true;
			}
		  }
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void comboBoxExTenThuoc_TextUpdate(object sender,EventArgs e) {
	  btnXThemThuoc.Enabled=false;
	}

	private void comboBoxExTenThuoc_DropDownClosed(object sender,EventArgs e) {
	  int intMaThuocHienTai=comboBoxExTenThuoc.SelectedIndex;
	  INT_MA_VITHUOC_DANGCHON=Convert.ToInt32(comboBoxExTenThuoc.SelectedValue);
	  btnXThemThuoc.Enabled=true;
	}
  }
}
