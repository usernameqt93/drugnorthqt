using BusinessLogic;
using FValueObject.Models;
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

namespace THUOCBAC.FormChucNang {
  public partial class frmAddInfoCustomerToOrder:Form {

	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();
	private DataTable DT_CHITIET_DONHANG;
	private decimal DEC_TONGTIEN;
	private int INT_MADH_HIENTAI;
	private DateTime DT_THOIGIAN_VIETDH;

	public frmAddInfoCustomerToOrder() {
	  InitializeComponent();
	}

	public frmAddInfoCustomerToOrder(DataTable _dtChiTietDonHang,decimal _decTongTien,int _intMaDHHienTai,DateTime dtThoiGianVietDH) {
	  InitializeComponent();
	  DT_CHITIET_DONHANG=_dtChiTietDonHang;
	  DEC_TONGTIEN=_decTongTien;
	  INT_MADH_HIENTAI=_intMaDHHienTai;
	  DT_THOIGIAN_VIETDH=dtThoiGianVietDH;
	}

	private void frmAddInfoCustomerToOrder_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  cboKhoGiay.Items.Add(QTStringConst.KHO_A4.STR);
	  cboKhoGiay.Items.Add(QTStringConst.KHO_A5.STR);
	  cboKhoGiay.SelectedIndex=0;
	  //cboKhoGiay.
	  lblDuongKeNgang.AutoSize=false;
	  lblDuongKeNgang.BorderStyle=BorderStyle.Fixed3D;
	  //lblDuongKeNgang.Height=2;
	}

	private void btnXChooseCustomer_Click(object sender,EventArgs e) {
	  FormDialogPhu.frmChonTenHoacThemMoi frm = new FormDialogPhu.frmChonTenHoacThemMoi(QTStringConst.TENKHACHHANG.STR,500,700);
	  frm.ShowDialog();
	  txtXNameCustomer.Text=QTAppTemp.STATIC_STR_NAME_CHOOSE;
	  //numericUpDownTienNo.Value=QTAppTemp.STATIC_DEC_DEBT_CHOOSE;

	  btnXShowDetailDebt.Enabled=true;
	  if(txtXNameCustomer.Text.Trim().Length>0) {
		btnXUpdateDebt.Enabled=true;

	  }
	}

	private void btnXShowDetailDebt_Click(object sender,EventArgs e) {
	  if(QTAppTemp.STATIC_STR_NAME_CHOOSE.Equals(QTStringConst.KHONGGHIVAO.STR)||QTAppTemp.STATIC_STR_NAME_CHOOSE.Equals("")) {
		MessageBox.Show("Bạn vui lòng chọn lại tên khách hàng !");
		btnXShowDetailDebt.Enabled=false;
		return;
	  }
	  //int intIdKHVuaChonTrongComboBox=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
	  //string strTenKhachHangDangChon=comboBoxExTenKhachHang.Text;
	  DataTable dtLichSuTienNo = BL_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(QTAppTemp.STATIC_INT_ID_CHOOSE);
	  if(dtLichSuTienNo.Rows.Count==0) {
		MessageBox.Show("Hiện tại tiền nợ của khách hàng '"+QTAppTemp.STATIC_STR_NAME_CHOOSE+"' chưa lưu gì cả\nBạn hãy chọn 'Thay đổi tiền nợ' để cập nhật lại tiền nợ !");
		return;
	  }
	  if(dtLichSuTienNo.Rows.Count>0) {
		//DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChonTrongComboBox);
		FormXemThongTinTienNo formXemThongTinTienNo = new FormXemThongTinTienNo(dtLichSuTienNo,QTAppTemp.STATIC_INT_ID_CHOOSE,QTAppTemp.STATIC_STR_NAME_CHOOSE,QTAppTemp.STATIC_DEC_DEBT_CHOOSE,QTStringConst.SUDUNG_APPTEMP.STR);
		//formXemThongTinTienNo.voidHIENTHI_TIENNOCU_RA_NUMBERIC=new FormChucNang.FormXemThongTinTienNo.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TIENNOCU_RA_NUMBERIC);
		formXemThongTinTienNo.ShowDialog();

		numericUpDownTienNo.Value=QTAppTemp.STATIC_DEC_DEBT_CHOOSE;
	  }
	}

	private void btnXDisplayLayout_Click(object sender,EventArgs e) {
	  this.Enabled=false;
	  DateTime dtTemp = dateTimeInputThoiGian.Value;

	  InfoOrderModel mInfoOrder = new InfoOrderModel();
	  mInfoOrder.strSizePaper=cboKhoGiay.Text;
	  mInfoOrder.strTime="Ngày   "+dtTemp.ToString("dd")+"   tháng   "+dtTemp.ToString("MM")+"   năm   "+dtTemp.Year;
	  mInfoOrder.decCopyNumber=nudCopyNumber.Value;
	  mInfoOrder.strCustomerName=(txtXNameCustomer.Text.Equals("")) ?" ":txtXNameCustomer.Text;
	  mInfoOrder.decDebtNumber=numericUpDownTienNo.Value;
	  mInfoOrder.strPhone=(txtPhone.Text.Equals("")||!chkDisplayPhone.Checked) ?" ":txtPhone.Text;

	  mInfoOrder.decSumMoney=DEC_TONGTIEN;
	  mInfoOrder.dtDetailOrder=DT_CHITIET_DONHANG;

	  FormReport.frmReportInDonHang frm = new FormReport.frmReportInDonHang(mInfoOrder);
	  frm.ShowDialog();
	  this.Enabled=true;
	}

	private void btnXUpdateDebt_Click(object sender,EventArgs e) {
	  //frmXacNhanThemTienNo frm = new frmXacNhanThemTienNo();
	  //frm.ShowDialog();
	  string strTenKhachHangDangChon = txtXNameCustomer.Text;

	  if(strTenKhachHangDangChon.Equals(QTStringConst.KHONGGHIVAO.STR)||strTenKhachHangDangChon.Trim().Equals("")) {
		MessageBox.Show("Bạn chưa chọn tên khách hàng, chưa hiển thị thông tin được !");
		return;
	  }
	  int intIdKHVuaChon = QTAppTemp.STATIC_INT_ID_CHOOSE;
	  DataTable dtLichSuTienNo = BL_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(intIdKHVuaChon);
	  if(dtLichSuTienNo.Rows.Count==0) {
		MessageBox.Show("Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là 0 đ\nBạn có thể xem lại thông tin chi tiết ở phần danh sách khách hàng !");
		return;
	  }
	  if(dtLichSuTienNo.Rows.Count>0) {
		decimal DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChon);
		string strLyDoSua = "Cộng thêm tiền đơn hàng "+INT_MADH_HIENTAI+" ("+DT_THOIGIAN_VIETDH+")";
		frmXacNhanThemTienNo frm = new frmXacNhanThemTienNo(dtLichSuTienNo,intIdKHVuaChon,strTenKhachHangDangChon,DEC_TIENNO_HIENTAI_CUA_KH,strLyDoSua,DEC_TONGTIEN);
		//formXemThongTinTienNo.voidHIENTHI_TIENNOCU_RA_NUMBERIC=new FormChucNang.FormXemThongTinTienNo.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TIENNOCU_RA_NUMBERIC);
		frm.ShowDialog();
	  }
	}
  }
}
