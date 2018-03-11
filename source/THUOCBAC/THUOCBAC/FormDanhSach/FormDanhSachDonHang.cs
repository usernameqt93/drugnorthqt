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
	private string STR_TEN_KH_DANGCHON = "";
	private decimal DEC_TIENNO_CU_DANGCHON=0;
	private DateTime DT_THOIGIAN_VIETDH_DANGCHON;
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	//private DataTable DT_KHACHHANG;
	private string STR_NUT_VUABAM= QTStringConst.NUT_HIEN_TATCA.STR;

	private const string CONST_STR_TEN_KHACHHANG = QTStringConst.TENKHACHHANG.STR;

	public FormDanhSachDonHang() {
	  InitializeComponent();
	}

	private void btnXThemDonHang_Click(object sender,EventArgs e) {

	  if(QTAppSetting.STATIC_STR_CACHVIET_DONHANG.Equals(QTDbConst.VIET_DONHANG_CACH_2.STR)) {
		FormChucNang.frmThemDonHangNangCap frm = new FormChucNang.frmThemDonHangNangCap();
		frm.ShowDialog();
		voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
		return;
	  }

	  FormChucNang.FormThemDonHang formThemDonHang=new FormChucNang.FormThemDonHang();
	  formThemDonHang.ShowDialog();
	  voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
	}

	private void FormDanhSachDonHang_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  dateTimeInputThoiGian.Value=DateTime.Now;
	  voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
	}

	private void voidHIENTHI_DGV_DH_CO_STT(string strViTriTroDen,string strDieuKien,int intIdBangKhachHang) {
	  dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTableBangDanhSachDonHang(strDieuKien,intIdBangKhachHang);

	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXCacDonHang);

	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dataGridViewXCacDonHang,new List<string>() {
		QTDbConst.ID_BANG_DANHSACH_DONHANG.STR,QTDbConst.ID_BANG_KHACHHANG.STR,QTDbConst.SDT_KHACHHANG_LUU_VOI_DONHANG.STR,QTDbConst.TIENNO_CU_LUU_VOI_DONHANG.STR });

	  dataGridViewXCacDonHang.Columns[QTDbConst.TONG_GIATRI_DONHANG.STR].DefaultCellStyle.Format="#,###.### vnđ";
	  dataGridViewXCacDonHang.Columns[QTDbConst.TONG_VITHUOC.STR].DefaultCellStyle.Format="#,###.### vị thuốc";
	  dataGridViewXCacDonHang.Columns[QTDbConst.TONG_KHOILUONG.STR].DefaultCellStyle.Format="#,###.### Kg";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTDbConst.TONG_KHOILUONG.STR,QTStringConst.TONG_KHOILUONG.STR,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTDbConst.TONG_GIATRI_DONHANG.STR,QTStringConst.TONG_GIATRI_DONHANG.STR,150,DataGridViewContentAlignment.MiddleRight);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTDbConst.THOIGIAN_VIET_DONHANG.STR,QTStringConst.THOIGIAN_VIET.STR,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTDbConst.TONG_VITHUOC.STR,QTStringConst.TONG_SO_VITHUOC.STR,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXCacDonHang,QTDbConst.TENKHACHHANG.STR,CONST_STR_TEN_KHACHHANG,150,DataGridViewContentAlignment.MiddleCenter,DataGridViewAutoSizeColumnMode.Fill);

	  dataGridViewXCacDonHang.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  if(strDieuKien.Equals(QTStringConst.TATCA.STR))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị tất cả đơn hàng)";
	  if(strDieuKien.Equals(QTStringConst.THEO_ID_KHACHHANG.STR))
		groupBoxDanhSachDH.Text="Danh sách đơn hàng (Đang hiển thị những đơn hàng có TÊN KHÁCH HÀNG là '"+txtXNameCustomer.Text+"' )";
	  if(strViTriTroDen.Equals(QTStringConst.VITRI_CUOICUNG.STR)) {
		QTLibraryFunction.STATIC_VOID_FOCUS_LAST_ROW_DGV(ref dataGridViewXCacDonHang,QTDbConst.TONG_KHOILUONG.STR);
	  }
	}

	private void voidHIENTHI_DGV_THEONGAY(string strViTriTroDen,DateTime dtThoiGianTimKiem) {
	  dataGridViewXCacDonHang.DataSource=BL_DONHANG.dataTable_DANHSACH_DH_THEONGAY(dtThoiGianTimKiem);
		groupBoxDanhSachDH.Text=
		  "Danh sách đơn hàng (Đang hiển thị những đơn hàng trong ngày "+dtThoiGianTimKiem.Day+" tháng "+dtThoiGianTimKiem.Month+" năm "+dtThoiGianTimKiem.Year+" )";
	  dataGridViewXCacDonHang.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  if(strViTriTroDen.Equals(QTStringConst.VITRI_CUOICUNG.STR)) {
		//chuyển xuống dòng dưới cùng
		int intSoThuTuHangMuonTroVao=0;
		if(dataGridViewXCacDonHang.RowCount>1) {
		  intSoThuTuHangMuonTroVao=dataGridViewXCacDonHang.RowCount-1;
		  dataGridViewXCacDonHang.CurrentCell=dataGridViewXCacDonHang.Rows[intSoThuTuHangMuonTroVao].Cells[QTDbConst.TONG_KHOILUONG.STR];// Đưa Control về vị trí của nó
		  dataGridViewXCacDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
		}
	  }
	}

	private void dataGridViewXCacDonHang_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXemChiTietDonHang.Enabled=true;
		  DataGridViewRow r=dataGridViewXCacDonHang.Rows[e.RowIndex];
		  int intSoViThuocTrongDH=(r.Cells[QTDbConst.TONG_VITHUOC.STR].Value.ToString().Equals(""))?0:Convert.ToInt32(r.Cells[QTDbConst.TONG_VITHUOC.STR].Value);
		  btnXXoaDH.Enabled=(intSoViThuocTrongDH==0)?true:false;
		  INT_MADONHANG_DANGCHON=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_DANHSACH_DONHANG.STR].Value);
		  INT_ID_KH_DANGCHON=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_KHACHHANG.STR].Value);
		  STR_SDT_KH_DANGCHON=Convert.ToString(r.Cells[QTDbConst.SDT_KHACHHANG_LUU_VOI_DONHANG.STR].Value);

		  STR_TEN_KH_DANGCHON=Convert.ToString(r.Cells[QTDbConst.TENKHACHHANG.STR].Value);

		  DEC_TIENNO_CU_DANGCHON=(r.Cells[QTDbConst.TIENNO_CU_LUU_VOI_DONHANG.STR].Value.ToString().Equals(""))?0:Convert.ToDecimal(r.Cells[QTDbConst.TIENNO_CU_LUU_VOI_DONHANG.STR].Value);
		  DT_THOIGIAN_VIETDH_DANGCHON=(r.Cells[QTDbConst.THOIGIAN_VIET_DONHANG.STR].Value.ToString().Equals(""))?DateTime.Now:Convert.ToDateTime(r.Cells[QTDbConst.THOIGIAN_VIET_DONHANG.STR].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXXemChiTietDonHang_Click(object sender,EventArgs e) {
	  btnXXemChiTietDonHang.Enabled=false;

	  if(QTAppSetting.STATIC_STR_CACHVIET_DONHANG.Equals(QTDbConst.VIET_DONHANG_CACH_2.STR)) {
		FormChucNang.frmThemDonHangNangCap formXemChiTietDonHangNangCap = new FormChucNang.frmThemDonHangNangCap(
		  INT_MADONHANG_DANGCHON,INT_ID_KH_DANGCHON,STR_SDT_KH_DANGCHON,DEC_TIENNO_CU_DANGCHON,QTStringConst.XEM_CHITIET.STR,DT_THOIGIAN_VIETDH_DANGCHON,STR_TEN_KH_DANGCHON);
		formXemChiTietDonHangNangCap.ShowDialog();
	  } else {
		FormChucNang.FormThemDonHang formXemChiTietDonHang = new FormChucNang.FormThemDonHang(
		  INT_MADONHANG_DANGCHON,INT_ID_KH_DANGCHON,STR_SDT_KH_DANGCHON,DEC_TIENNO_CU_DANGCHON,QTStringConst.XEM_CHITIET.STR,DT_THOIGIAN_VIETDH_DANGCHON,STR_TEN_KH_DANGCHON);
		formXemChiTietDonHang.ShowDialog();
	  }
	  if(STR_NUT_VUABAM.Equals(QTStringConst.NUT_HIEN_TATCA.STR))
	  voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
	  if(STR_NUT_VUABAM.Equals(QTStringConst.NUT_TIM_THEO_NGAY.STR))
		btnXTimKiemTheoNgay.PerformClick();
	  if(STR_NUT_VUABAM.Equals(QTStringConst.NUT_TIM_THEO_TEN.STR)) {
		//int intIdBangKH = Convert.ToInt32(QTAppInfo.STATIC_STR_ID_CHOOSE);
		int intIdBangKH = QTAppTemp.STATIC_INT_ID_CHOOSE;
		voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.THEO_ID_KHACHHANG.STR,intIdBangKH);
	  }
	}

	private void btnXXoaDH_Click(object sender,EventArgs e) {
	  string strLoi="";
	  bool boolabc=BL_DONHANG.boolDELETE_BANG_DSDH_THEOID(ref strLoi,INT_MADONHANG_DANGCHON);
	  if(boolabc) {
		voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
		MessageBox.Show("Bạn vừa XÓA đơn hàng trống có 0 vị thuốc kia THÀNH CÔNG");
	  } else {
		MessageBox.Show("Khi xóa đơn hàng trống xảy ra lỗi ("+strLoi+")");
	  }
	  btnXXoaDH.Enabled=false;
	  btnXXemChiTietDonHang.Enabled=false;
	}

	//private void voidCAPNHAT_COMBOBOX_TENKH() {
	//  DT_KHACHHANG=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	//}

	//private void comboBoxExTenKhachHang_DropDownClosed(object sender,EventArgs e) {
	//  btnXTimKiemTheoTenKH.Enabled=true;
	//}

	private void btnXTimKiemTheoTenKH_Click(object sender,EventArgs e) {
	  if(QTAppTemp.STATIC_STR_NAME_CHOOSE.Equals("")) {
		btnXTimKiemTheoTenKH.Enabled=false;
		MessageBox.Show("Tên khách hàng đang để trống, bạn vui lòng chọn lại tên khách hàng !");
		btnXChonTenKhachHang.PerformClick();
		return;
	  }
	  //int intIdBangKH = Convert.ToInt32(QTAppInfo.STATIC_STR_ID_CHOOSE);
	  int intIdBangKH = QTAppTemp.STATIC_INT_ID_CHOOSE;
	  voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.THEO_ID_KHACHHANG.STR,intIdBangKH);
	  btnXTimKiemTheoTenKH.Enabled=false;
	  STR_NUT_VUABAM=QTStringConst.NUT_TIM_THEO_TEN.STR;
	}

	private void btnXHienThiTatCaDH_Click(object sender,EventArgs e) {
	  voidHIENTHI_DGV_DH_CO_STT(QTStringConst.VITRI_CUOICUNG.STR,QTStringConst.TATCA.STR,-1);
	  STR_NUT_VUABAM=QTStringConst.NUT_HIEN_TATCA.STR;
	}

	private void btnXTimKiemTheoNgay_Click(object sender,EventArgs e) {
	  DateTime dtThoiGianTimKiem=dateTimeInputThoiGian.Value;
	  voidHIENTHI_DGV_THEONGAY(QTStringConst.VITRI_CUOICUNG.STR,dtThoiGianTimKiem);
	  STR_NUT_VUABAM=QTStringConst.NUT_TIM_THEO_NGAY.STR;
	}

	private void btnXChonTenKhachHang_Click(object sender,EventArgs e) {
	  FormDialogPhu.frmChonTenTrongDanhSach frm = new FormDialogPhu.frmChonTenTrongDanhSach("Chọn tên khách hàng",450);
	  frm.FormBorderStyle=FormBorderStyle.FixedToolWindow;
	  frm.ShowDialog();

	  if(!QTAppTemp.STATIC_STR_NAME_CHOOSE.Equals("")) {
		txtXNameCustomer.Text=QTAppTemp.STATIC_STR_NAME_CHOOSE;
		btnXTimKiemTheoTenKH.Enabled=true;
	  } else
		btnXTimKiemTheoTenKH.Enabled=false;
	}
  }
}
