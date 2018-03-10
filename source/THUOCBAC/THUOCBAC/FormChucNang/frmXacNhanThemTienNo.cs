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

	private DataTable DT_LICHSU_TIENNO;
	private int INT_ID_KHACHHANG = -1;
	private string STR_TENKHACHHANG = "";
	private decimal DEC_TIENNO_HIENTAI = 0;
	//private string STR_LUUY_FORM_TRUOC = "";

	public frmXacNhanThemTienNo() {
	  InitializeComponent();
	}

	public frmXacNhanThemTienNo(DataTable dtLichSuTienNo,int intIdKhachHang,string strTenKhachHang,decimal decTienNoHienTai,string _strDetailDebt,decimal _decTongTienDH) {
	  InitializeComponent();
	  DT_LICHSU_TIENNO=dtLichSuTienNo;
	  INT_ID_KHACHHANG=intIdKhachHang;
	  STR_TENKHACHHANG=strTenKhachHang;
	  DEC_TIENNO_HIENTAI=decTienNoHienTai;

	  lblDetailDebt.Text=_strDetailDebt;
	  lblXTongTienDH.Text=(_decTongTienDH==0) ? "0 đ" : _decTongTienDH.ToString("#,###.#")+" đ";
	  decimal decTemp = decTienNoHienTai+_decTongTienDH;
	  lblXDebtUpdate.Text=(decTemp==0) ? "0 đ" : decTemp.ToString("#,###.#")+" đ";
	}

	private void frmXacNhanThemTienNo_Load(object sender,EventArgs e) {
	  VOID_LOAD_FORM();
	}

	private void VOID_LOAD_FORM() {
	  lblXName.Text=STR_TENKHACHHANG;
	 // if(STR_LUUY_FORM_TRUOC.Equals(QTStringConst.HIDE_NUT_XACNHAN.STR))
		//btnXXacNhanTienNo.Visible=false;
	  lblXDebtCurrent.Text=(DEC_TIENNO_HIENTAI==0) ? "0 đ" : DEC_TIENNO_HIENTAI.ToString("#,###.#")+" đ";
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
	  DataTable dtSTT = DT_LICHSU_TIENNO;
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

	}

	private void frmXacNhanThemTienNo_Shown(object sender,EventArgs e) {

	  rtbNote.Focus();
	}
  }
}
