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
  public partial class frmXacNhanThemTienNo:Form {

	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	private ConfirmDebtModel M_CONFIRM_DEBT;

	public frmXacNhanThemTienNo() {
	  InitializeComponent();
	}

	public frmXacNhanThemTienNo(ConfirmDebtModel mConfirmDebt) {
	  InitializeComponent();
	  M_CONFIRM_DEBT=mConfirmDebt;
	}

	private void frmXacNhanThemTienNo_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  VOID_LOAD_FORM();
	}

	private void VOID_LOAD_FORM() {
	  lblXName.Text=M_CONFIRM_DEBT.strNameCustomer;

	  lblDetailDebt.Text=M_CONFIRM_DEBT.strDetailDebt;
	  lblXTongTienDH.Text=(M_CONFIRM_DEBT.decTongTienDonHang==0) ? "0 đ" : M_CONFIRM_DEBT.decTongTienDonHang.ToString("#,###.#")+" đ";
	  decimal decTemp = M_CONFIRM_DEBT.decTienNoHienTai+M_CONFIRM_DEBT.decTongTienDonHang;
	  lblXDebtUpdate.Text=(decTemp==0) ? "0 đ" : decTemp.ToString("#,###.#")+" đ";
	  // if(STR_LUUY_FORM_TRUOC.Equals(QTStringConst.HIDE_NUT_XACNHAN.STR))
	  //btnXXacNhanTienNo.Visible=false;
	  lblXDebtCurrent.Text=(M_CONFIRM_DEBT.decTienNoHienTai==0) ? "0 đ" : M_CONFIRM_DEBT.decTienNoHienTai.ToString("#,###.#")+" đ";
	  voidHIENTHI_DGV_LICHSU_CO_STT();
	  //dataGridViewXLichSuTienNo.Columns[QTStringConst.SO_THUTU.STR].Width=22;
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.THOIGIAN_THAYDOI_TIENNO.STR,QTStringConst.THOIGIAN.STR,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.LYDO_SUA_TIENNO.STR,QTStringConst.CHITIET.STR,150,DataGridViewContentAlignment.MiddleLeft,DataGridViewAutoSizeColumnMode.Fill);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TIENNO_TRUOCKHISUA.STR,QTStringConst.TRUOCKHISUA.STR,100,DataGridViewContentAlignment.MiddleRight);
	  dgvXMain.Columns[QTDbConst.TIENNO_TRUOCKHISUA.STR].DefaultCellStyle.Format="#,###.### đ";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.SOTIENSUA_CUTHE.STR,QTStringConst.SOTIEN_SUA.STR,100,DataGridViewContentAlignment.MiddleRight);
	  dgvXMain.Columns[QTDbConst.SOTIENSUA_CUTHE.STR].DefaultCellStyle.Format="#,###.### đ";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXMain,QTDbConst.TIENNO_SAUKHISUA.STR,QTStringConst.SAUKHISUA.STR,100,DataGridViewContentAlignment.MiddleRight);
	  dgvXMain.Columns[QTDbConst.TIENNO_SAUKHISUA.STR].DefaultCellStyle.Format="#,###.### đ";

	  voidTRO_XUONG_VITRI_CUOICUNG();

	  lblXMessage.Text=QTMessageConst.CONFIRM_CHANGE_DEBT(lblXName.Text,lblXDebtUpdate.Text);
	}

	private void voidHIENTHI_DGV_LICHSU_CO_STT() {
	  DataTable dtSTT = M_CONFIRM_DEBT.dtLichSuTienNo;
	  dtSTT.Columns.Add(QTStringConst.SO_THUTU.STR);
	  for(int i = 0;i<dtSTT.Rows.Count;i++)
		dtSTT.Rows[i][QTStringConst.SO_THUTU.STR]=i+1;
	  dgvXMain.DataSource=dtSTT;
	  dgvXMain.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dgvXMain);
	}

	private void voidTRO_XUONG_VITRI_CUOICUNG() {
	  int intSoThuTuHangMuonTroVao = 0;
	  if(dgvXMain.RowCount>1)
		intSoThuTuHangMuonTroVao=dgvXMain.RowCount-1;
	  dgvXMain.CurrentCell=dgvXMain.Rows[intSoThuTuHangMuonTroVao].Cells[QTDbConst.THOIGIAN_THAYDOI_TIENNO.STR];// Đưa Control về vị trí của nó
	  dgvXMain.CurrentRow.Selected=true;// Set trạng thái Selected
	}

	private void btnXCancel_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void btnXAccept_Click(object sender,EventArgs e) {
	  string strCapNhatChua = BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(M_CONFIRM_DEBT.intIdOrderCurrent);
	  if(strCapNhatChua.Equals("")) {
		MessageBox.Show("MaDHHienTai la '"+M_CONFIRM_DEBT.intIdOrderCurrent+"' có Cột 'CapNhatTienNoChua' hiện đang có giá trị khác 'Đã cập nhật' và 'Chưa cập nhật' !");
		return;
	  }

	  string strLoiCapNhatTienNo = "";
	  string strLyDoSua = (rtbNote.Text.Trim().Equals(""))? M_CONFIRM_DEBT.strDetailDebt : M_CONFIRM_DEBT.strDetailDebt+"(Ghi chú: "+rtbNote.Text.Trim()+")";
	  string strTrangThaiCapNhat = BL_KHACHHANG.STR_CAPNHAT_TIENNO_KH(ref strLoiCapNhatTienNo,
		M_CONFIRM_DEBT.intIdOrderCurrent,M_CONFIRM_DEBT.decTienNoHienTai,M_CONFIRM_DEBT.intIdCustomer,strLyDoSua,M_CONFIRM_DEBT.decTongTienDonHang);
	  if(strTrangThaiCapNhat.Equals("false")&&!(strLoiCapNhatTienNo.Equals("3"))) {
		MessageBox.Show("Trạng thái cập nhật tiền nợ bị lỗi ("+strLoiCapNhatTienNo+")");
	  } else {
		QTAppTemp.STATIC_DEC_DEBT_CHOOSE=M_CONFIRM_DEBT.decTienNoHienTai;
		QTAppTemp.STATIC_INT_ID_CHOOSE=M_CONFIRM_DEBT.intIdCustomer;
		MessageBox.Show("LƯU THÀNH CÔNG!\nHiện tại tiền nợ của khách hàng '"+M_CONFIRM_DEBT.strNameCustomer+"' là "+(M_CONFIRM_DEBT.decTienNoHienTai+M_CONFIRM_DEBT.decTongTienDonHang).ToString("#,###.#")+" đ");
		this.Close();
	  }
	}

	private void frmXacNhanThemTienNo_Shown(object sender,EventArgs e) {
	  rtbNote.Focus();
	}
  }
}
