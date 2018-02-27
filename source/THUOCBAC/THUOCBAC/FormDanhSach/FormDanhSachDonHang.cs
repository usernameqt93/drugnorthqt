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

	private const string CONST_STR_THOIGIAN_VIET = "Thời gian viết";
	private const string CONST_STR_TONG_VITHUOC = "Tổng số vị thuốc";
	private const string CONST_STR_TONG_KHOILUONG = "Tổng khối lượng";
	private const string CONST_STR_TONG_GIATRI_DH = "Tổng giá trị đơn hàng";
	private const string CONST_STR_TEN_KHACHHANG = "Tên khách hàng";

	public FormDanhSachDonHang() {
	  InitializeComponent();
	}

	private void btnXThemDonHang_Click(object sender,EventArgs e) {
	  FormChucNang.FormThemDonHang formThemDonHang=new FormChucNang.FormThemDonHang();
	  formThemDonHang.ShowDialog();
	  //dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang();
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  //voidCAPNHAT_COMBOBOX_TENKH();
	}
	private void FormDanhSachDonHang_Load(object sender,EventArgs e) {
	  //dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang();
	  dateTimeInputThoiGian.Value=DateTime.Now;
	  //voidCAPNHAT_COMBOBOX_TENKH();
	  //comboBoxExTenKhachHang.SelectedValue=0;
	  voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TatCa",-1);
	  //dataGridViewXCacDonHang.Columns["ThoiGianVietDonHangNay"].HeaderText=CONST_STR_THOIGIAN_VIET;
	  //dataGridViewXCacDonHang.Columns["TongViThuoc"].HeaderText=CONST_STR_TONG_VITHUOC;
	  //dataGridViewXCacDonHang.Columns["TongKhoiLuong"].HeaderText=CONST_STR_TONG_KHOILUONG;
	  //dataGridViewXCacDonHang.Columns["TongGiaTriDonHang"].HeaderText=CONST_STR_TONG_GIATRI_DH;
	  //dataGridViewXCacDonHang.Columns["TenKhachHang"].HeaderText=CONST_STR_TEN_KHACHHANG;
	  //dataGridViewXCacDonHang.Columns["ThoiGianVietDonHangNay"].HeaderText="Thời gian viết";
	  //dataGridViewXCacDonHang.Columns["TongViThuoc"].HeaderText="Tổng số vị thuốc";
	  //dataGridViewXCacDonHang.Columns["TongKhoiLuong"].HeaderText="Tổng khối lượng";
	  //dataGridViewXCacDonHang.Columns["TongGiaTriDonHang"].HeaderText="Tổng giá trị đơn hàng";
	  //dataGridViewXCacDonHang.Columns["TenKhachHang"].HeaderText="Tên khách hàng";

	  //dataGridViewXCacDonHang.Columns["MaDonHang"].Visible=false;
	  //dataGridViewXCacDonHang.Columns["IdBangKhachHang"].Visible=false;
	  //dataGridViewXCacDonHang.Columns["SDTKhachHang"].Visible=false;
	  //dataGridViewXCacDonHang.Columns["TienNoCu"].Visible=false;

	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dataGridViewXCacDonHang,new List<string>() { "MaDonHang","IdBangKhachHang","SDTKhachHang","TienNoCu" });
	  //QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dataGridViewXCacDonHang,new List<string>() { "MaDonHang","IdBangKhachHang","SDTKhachHang" });

	  dataGridViewXCacDonHang.Columns["TongGiaTriDonHang"].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXCacDonHang.Columns["TongViThuoc"].DefaultCellStyle.Format="#,###.### vị thuốc";
	  dataGridViewXCacDonHang.Columns["TongKhoiLuong"].DefaultCellStyle.Format="#,###.### Kg";
	}

	//private void VOID_SET_WIDTH_ALIGN_COLUMN(string _strTenCot,int _intWidth,DataGridViewContentAlignment _dgvContentAlign) {
	//  dataGridViewXCacDonHang.Columns[_strTenCot].Width=_intWidth;
	//  dataGridViewXCacDonHang.Columns[_strTenCot].DefaultCellStyle.Alignment=_dgvContentAlign;
	//  dataGridViewXCacDonHang.Columns[_strTenCot].HeaderCell.Style.Alignment=_dgvContentAlign;
	//}

	//private void VOID_SET_WIDTH_ALIGN_COLUMN(string _strTenCot,int _intWidth,DataGridViewContentAlignment _dgvContentAlign,DataGridViewAutoSizeColumnMode _dgvAutoSizeColumnMode) {
	//  dataGridViewXCacDonHang.Columns[_strTenCot].Width=_intWidth;
	//  dataGridViewXCacDonHang.Columns[_strTenCot].DefaultCellStyle.Alignment=_dgvContentAlign;
	//  dataGridViewXCacDonHang.Columns[_strTenCot].HeaderCell.Style.Alignment=_dgvContentAlign;
	//  dataGridViewXCacDonHang.Columns[_strTenCot].AutoSizeMode=_dgvAutoSizeColumnMode;
	//}

	private void voidHIENTHI_DGV_DH_CO_STT(string strViTriTroDen,string strDieuKien,int intIdBangKhachHang) {
	  dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang(strDieuKien,intIdBangKhachHang);

	 // foreach(DataGridViewColumn column in dataGridViewXCacDonHang.Columns) {
		//column.SortMode=DataGridViewColumnSortMode.NotSortable;
	 // }
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXCacDonHang);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("STT",60,DataGridViewContentAlignment.MiddleCenter);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("TongKhoiLuong",150,DataGridViewContentAlignment.MiddleCenter);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("TongGiaTriDonHang",150,DataGridViewContentAlignment.MiddleCenter);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("ThoiGianVietDonHangNay",150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("TongViThuoc",150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  //VOID_SET_WIDTH_ALIGN_COLUMN("TenKhachHang",150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"STT",60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"TongKhoiLuong",CONST_STR_TONG_KHOILUONG,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"TongGiaTriDonHang",CONST_STR_TONG_GIATRI_DH,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"ThoiGianVietDonHangNay",CONST_STR_THOIGIAN_VIET,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"TongViThuoc",CONST_STR_TONG_VITHUOC,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,"TenKhachHang",CONST_STR_TEN_KHACHHANG,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);

	  dataGridViewXCacDonHang.Columns["STT"].DisplayIndex=0;
	  if(strDieuKien.Equals("TatCa"))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị tất cả đơn hàng)";
	  if(strDieuKien.Equals("TheoIdBangKhachHang"))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị những đơn hàng có TÊN KHÁCH HÀNG là '"+txtXNameCustomer.Text+"' )";
	  if(strViTriTroDen.Equals("ViTriCuoiCung")) {
		//chuyển xuống dòng dưới cùng
		//int intSoThuTuHangMuonTroVao=0;
		//if(dataGridViewXCacDonHang.RowCount>1) { 
		//  intSoThuTuHangMuonTroVao=dataGridViewXCacDonHang.RowCount-1;
		//dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao].Cells["TongKhoiLuong"];// Đưa Control về vị trí của nó
		////dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao];
		//dataGridViewXCacDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
		//}
		QTLibraryFunction.STATIC_VOID_FOCUS_LAST_ROW_DGV(ref dataGridViewXCacDonHang,"TongKhoiLuong");
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
		//int intIdBangKH=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue);
		//voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TheoIdBangKhachHang",intIdBangKH);
		int intIdBangKH = Convert.ToInt32(QTAppInfo.STATIC_STR_ID_CHOOSE);
		voidHIENTHI_DGV_DH_CO_STT("ViTriCuoiCung","TheoIdBangKhachHang",intIdBangKH);
		//btnXTimKiemTheoTenKH.PerformClick();
	  }
	  //voidCAPNHAT_COMBOBOX_TENKH();
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
	  //comboBoxExTenKhachHang.DataSource=DT_KHACHHANG;
	  //comboBoxExTenKhachHang.DisplayMember="TenKhachHang";
	  //comboBoxExTenKhachHang.ValueMember="IdBangKhachHang";
	  //comboBoxExTenKhachHang.SelectedIndex=0;
	}

	private void comboBoxExTenKhachHang_DropDownClosed(object sender,EventArgs e) {
	  btnXTimKiemTheoTenKH.Enabled=true;
	}

	private void btnXTimKiemTheoTenKH_Click(object sender,EventArgs e) {
	  if(QTAppInfo.STATIC_STR_ID_CHOOSE.Equals("")) {
		btnXTimKiemTheoTenKH.Enabled=false;
		MessageBox.Show("Tên khách hàng đang để trống, bạn vui lòng chọn lại tên khách hàng !");
		btnXChonTenKhachHang.PerformClick();
		return;
	  }
	  //int intIdBangKH=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue);
	  int intIdBangKH = Convert.ToInt32(QTAppInfo.STATIC_STR_ID_CHOOSE);
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

	private void btnXChonTenKhachHang_Click(object sender,EventArgs e) {
	  FormDialogPhu.frmChonTenTrongDanhSach frm = new FormDialogPhu.frmChonTenTrongDanhSach("Chọn tên khách hàng",450);
	  frm.FormBorderStyle=FormBorderStyle.FixedToolWindow;
	  frm.ShowDialog();

	  if(!QTAppInfo.STATIC_STR_ID_CHOOSE.Equals("")) {
		txtXNameCustomer.Text=QTAppInfo.STATIC_STR_NAME_CHOOSE;
		btnXTimKiemTheoTenKH.Enabled=true;
		//btnXTimKiemTheoTenKH.PerformClick();
	  } else
		btnXTimKiemTheoTenKH.Enabled=false;
	}
  }
}
