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
	private BL_DonHang BL_DONHANG = new BL_DonHang();

	private DetailOrderModel M_DETAIL_ORDER;

	public frmAddInfoCustomerToOrder() {
	  InitializeComponent();
	}

	public frmAddInfoCustomerToOrder(DetailOrderModel _mDetailOrder) {
	  InitializeComponent();
	  M_DETAIL_ORDER=_mDetailOrder;
	}

	private void frmAddInfoCustomerToOrder_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  VOID_LOAD_FORM();
	}

	private void VOID_LOAD_FORM() {
	  cboKhoGiay.Items.Add(QTStringConst.KHO_A4.STR);
	  cboKhoGiay.Items.Add(QTStringConst.KHO_A5.STR);
	  cboKhoGiay.SelectedIndex=0;

	  lblDuongKeNgang.AutoSize=false;
	  lblDuongKeNgang.BorderStyle=BorderStyle.Fixed3D;
	  //lblDuongKeNgang.Height=2;

	  txtXNameCustomer.Text=QTStringConst.KHONGGHIVAO.STR;
	  dateTimeInputThoiGian.Value=M_DETAIL_ORDER.dtTimeCreate;

	  string strCapNhatChua = BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(M_DETAIL_ORDER.intIdOrderCurrent);
	  if(!strCapNhatChua.Equals(QTStringConst.CHUACAPNHAT.STR)) {
		VOID_LOCK_CONTROL_WHEN_SAVED();
	  }
	}

	private void VOID_LOCK_CONTROL_WHEN_SAVED() {
	  dateTimeInputThoiGian.Value=M_DETAIL_ORDER.dtTimeCreate;
	  //dateTimeInputThoiGian.Enabled=false;

	  txtXNameCustomer.Text=M_DETAIL_ORDER.strNameCustomerCurrent;
	  btnXChooseCustomer.Enabled=false;

	  numericUpDownTienNo.Value=M_DETAIL_ORDER.decDebtSaveWithOrder;
	  numericUpDownTienNo.Enabled=false;

	  txtPhone.Text=M_DETAIL_ORDER.strPhoneSaveWithOrder;
	  //txtPhone.Enabled=false;
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
	  btnXShowDetailDebt.PerformClick();
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

	  InfoOrderModelToPrint mInfoOrder = new InfoOrderModelToPrint();
	  mInfoOrder.strSizePaper=cboKhoGiay.Text;
	  mInfoOrder.strTime="Ngày   "+dtTemp.ToString("dd")+"   tháng   "+dtTemp.ToString("MM")+"   năm   "+dtTemp.Year;
	  mInfoOrder.decCopyNumber=nudCopyNumber.Value;
	  mInfoOrder.strCustomerName=(txtXNameCustomer.Text.Equals("")||txtXNameCustomer.Text.Equals(QTStringConst.KHONGGHIVAO.STR)) ?" ":txtXNameCustomer.Text;
	  mInfoOrder.decDebtNumber=numericUpDownTienNo.Value;
	  mInfoOrder.strPhone=(txtPhone.Text.Equals("")||!chkDisplayPhone.Checked) ?" ":txtPhone.Text;

	  mInfoOrder.decSumMoney=M_DETAIL_ORDER.decTongTien;
	  mInfoOrder.dtDetailOrder=M_DETAIL_ORDER.dtDetailOrder;

	  FormReport.frmReportInDonHang frm = new FormReport.frmReportInDonHang(mInfoOrder);
	  frm.ShowDialog();
	  this.Enabled=true;
	}

	private void btnXUpdateDebt_Click(object sender,EventArgs e) {
	  string strTenKhachHangDangChon = txtXNameCustomer.Text;

	  if(strTenKhachHangDangChon.Equals(QTStringConst.KHONGGHIVAO.STR)||strTenKhachHangDangChon.Trim().Equals("")) {
		MessageBox.Show("Bạn vui lòng chọn lại tên khách hàng !");
		btnXUpdateDebt.Enabled=false;
		return;
	  }
	  int intIdKHVuaChon = QTAppTemp.STATIC_INT_ID_CHOOSE;
	  DataTable dtLichSuTienNo = BL_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(intIdKHVuaChon);
	  if(dtLichSuTienNo.Rows.Count==0) {
		MessageBox.Show("Bạn vui lòng chọn lại tên khách hàng !");
		btnXChooseCustomer.PerformClick();
		return;
	  }
	  if(dtLichSuTienNo.Rows.Count>0) {
		decimal DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChon);

		ConfirmDebtModel mConfirmDebt = new ConfirmDebtModel();
		mConfirmDebt.dtLichSuTienNo=dtLichSuTienNo;
		mConfirmDebt.intIdCustomer=intIdKHVuaChon;
		mConfirmDebt.strNameCustomer=strTenKhachHangDangChon;
		mConfirmDebt.decTienNoHienTai=DEC_TIENNO_HIENTAI_CUA_KH;
		mConfirmDebt.strDetailDebt="Cộng thêm tiền đơn hàng "+M_DETAIL_ORDER.intIdOrderCurrent+" ("+M_DETAIL_ORDER.dtTimeCreate+","+M_DETAIL_ORDER.dtDetailOrder.Rows.Count+" vị thuốc)";
		mConfirmDebt.decTongTienDonHang=M_DETAIL_ORDER.decTongTien;
		mConfirmDebt.intIdOrderCurrent=M_DETAIL_ORDER.intIdOrderCurrent;

//frmXacNhanThemTienNo frm = new frmXacNhanThemTienNo(dtLichSuTienNo,intIdKHVuaChon,strTenKhachHangDangChon,DEC_TIENNO_HIENTAI_CUA_KH,strLyDoSua,DEC_TONGTIEN);
		frmXacNhanThemTienNo frm = new frmXacNhanThemTienNo(mConfirmDebt);
		frm.ShowDialog();
		if(QTAppTemp.STATIC_DEC_DEBT_CHOOSE>0) {
		  VOID_SAVE_DATA_TO_ORDER(mConfirmDebt.intIdCustomer,mConfirmDebt.decTienNoHienTai,mConfirmDebt.intIdOrderCurrent);
		  VOID_LOCK_CONTROL_WHEN_UPDATED_DEBT();
		}
	  }
	}

	private void VOID_LOCK_CONTROL_WHEN_UPDATED_DEBT() {
	  btnXUpdateDebt.Enabled=false;

	  numericUpDownTienNo.Value=QTAppTemp.STATIC_DEC_DEBT_CHOOSE;
	  numericUpDownTienNo.Enabled=false;

	  btnXShowDetailDebt.Enabled=false;

	  btnXChooseCustomer.Enabled=false;
	}

	private void VOID_SAVE_DATA_TO_ORDER(int _intIdCustomer,decimal _decTienNoHienTai,int _intIdOrderCurrent) {
	  string strLoi = "";
	  bool boolCapNhatTienNoCuTenKHVaoDH = BL_DONHANG.boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref strLoi,_intIdCustomer,txtPhone.Text,_decTienNoHienTai,_intIdOrderCurrent);
	  if(!boolCapNhatTienNoCuTenKHVaoDH) {
		MessageBox.Show("Có lỗi gì đó khi lưu tên khách hàng,tiền nợ cũ này vào đơn hàng ("+strLoi+")");
	  }
	}
  }
}
