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
  public partial class FormXemThongTinTienNo:Form {
	private DataTable DT_LICHSU_TIENNO;
	private int INT_ID_KHACHHANG=-1;
	private string STR_TENKHACHHANG="";
	private decimal DEC_TIENNO_HIENTAI=0;
	private string STR_LUUY_FORM_TRUOC="";

	private const string CONST_STR_THOIGIAN = "Thời gian";
	private const string CONST_STR_TRUOC_KHI_SUA = "Trước khi sửa";
	private const string CONST_STR_SOTIEN_SUA = "Số tiền sửa";
	private const string CONST_STR_SAU_KHI_SUA = "Sau khi sửa";
	private const string CONST_STR_CHITIET = "Chi tiết";

	public FormXemThongTinTienNo() {
	  InitializeComponent();
	}
	public delegate void DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(decimal decTienNoCu);
	public DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY voidHIENTHI_TIENNOCU_RA_NUMBERIC;
	public FormXemThongTinTienNo(DataTable dtLichSuTienNo,int intIdKhachHang,string strTenKhachHang,decimal decTienNoHienTai) {
	  InitializeComponent();
	  DT_LICHSU_TIENNO=dtLichSuTienNo;
	  INT_ID_KHACHHANG=intIdKhachHang;
	  STR_TENKHACHHANG=strTenKhachHang;
	  DEC_TIENNO_HIENTAI=decTienNoHienTai;
	}
	public FormXemThongTinTienNo(DataTable dtLichSuTienNo,int intIdKhachHang,string strTenKhachHang,decimal decTienNoHienTai,string strLuuY) {
	  InitializeComponent();
	  DT_LICHSU_TIENNO=dtLichSuTienNo;
	  INT_ID_KHACHHANG=intIdKhachHang;
	  STR_TENKHACHHANG=strTenKhachHang;
	  DEC_TIENNO_HIENTAI=decTienNoHienTai;
	  STR_LUUY_FORM_TRUOC=strLuuY;
	}

	private void btnXXacNhanTienNo_Click(object sender,EventArgs e) {
	  if(STR_LUUY_FORM_TRUOC.Equals("")) {
		if(voidHIENTHI_TIENNOCU_RA_NUMBERIC!=null)
		  voidHIENTHI_TIENNOCU_RA_NUMBERIC(DEC_TIENNO_HIENTAI);
		this.Close();
	  }
	  if(STR_LUUY_FORM_TRUOC.Equals(QTStringConst.SUDUNG_APPTEMP.STR)) {

		this.Close();

	  }
	}

	private void FormXemThongTinTienNo_Load(object sender,EventArgs e) {
	  labelXTenKhachHang.Text=STR_TENKHACHHANG;
	  if(STR_LUUY_FORM_TRUOC.Equals(QTStringConst.HIDE_NUT_XACNHAN.STR))
		btnXXacNhanTienNo.Visible=false;
	  labelXTienNoHienTai.Text=(DEC_TIENNO_HIENTAI==0)?"0 đ":DEC_TIENNO_HIENTAI.ToString("#,###.#")+" đ";
	  voidHIENTHI_DGV_LICHSU_CO_STT();
	  //dataGridViewXLichSuTienNo.Columns[QTStringConst.SO_THUTU.STR].Width=22;
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);

	  //dataGridViewXLichSuTienNo.Columns["ThoiGianThayDoiTienNo"].HeaderText="Thời gian";
	  //dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].HeaderText="Trước khi sửa";
	  //dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].HeaderText="Số tiền sửa";
	  //dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].HeaderText="Sau khi sửa";
	  //dataGridViewXLichSuTienNo.Columns["LyDoSuaTienNo"].HeaderText="Chi tiết";

	  //dataGridViewXLichSuTienNo.Columns["ThoiGianThayDoiTienNo"].HeaderText=CONST_STR_THOIGIAN;
	  //dataGridViewXLichSuTienNo.Columns["LyDoSuaTienNo"].HeaderText=CONST_STR_CHITIET;
	  //dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].HeaderText=CONST_STR_TRUOC_KHI_SUA;
	  //dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].DefaultCellStyle.Format="#,###.### đ";
	  //dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].Width=88;
	  //dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].HeaderText=CONST_STR_SOTIEN_SUA;
	  //dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].DefaultCellStyle.Format="#,###.### đ";
	  //dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].Width=88;
	  //dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].HeaderText=CONST_STR_SAU_KHI_SUA;
	  //dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].DefaultCellStyle.Format="#,###.### đ";
	  //dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].Width=88;

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,"ThoiGianThayDoiTienNo",CONST_STR_THOIGIAN,150,DataGridViewContentAlignment.MiddleCenter);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,"LyDoSuaTienNo",CONST_STR_CHITIET,150,DataGridViewContentAlignment.MiddleLeft,DataGridViewAutoSizeColumnMode.Fill);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,"TienNoTruocKhiSua",CONST_STR_TRUOC_KHI_SUA,100,DataGridViewContentAlignment.MiddleRight);
	  dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].DefaultCellStyle.Format="#,###.### đ";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,"SoTienSuaCuThe",CONST_STR_SOTIEN_SUA,100,DataGridViewContentAlignment.MiddleRight);
	  dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].DefaultCellStyle.Format="#,###.### đ";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXLichSuTienNo,"TienNoSauKhiSua",CONST_STR_SAU_KHI_SUA,100,DataGridViewContentAlignment.MiddleRight);
	  dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].DefaultCellStyle.Format="#,###.### đ";

	  voidTRO_XUONG_VITRI_CUOICUNG();
	}
	private void voidHIENTHI_DGV_LICHSU_CO_STT() {
	  DataTable dtSTT=DT_LICHSU_TIENNO;
	  dtSTT.Columns.Add(QTStringConst.SO_THUTU.STR);
	  for(int i=0;i<dtSTT.Rows.Count;i++)
		dtSTT.Rows[i][QTStringConst.SO_THUTU.STR]=i+1;
	  dataGridViewXLichSuTienNo.DataSource=dtSTT;
	  dataGridViewXLichSuTienNo.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXLichSuTienNo);
	}
	private void voidTRO_XUONG_VITRI_CUOICUNG() {
	  int intSoThuTuHangMuonTroVao=0;
	  if(dataGridViewXLichSuTienNo.RowCount>1)
		intSoThuTuHangMuonTroVao=dataGridViewXLichSuTienNo.RowCount-1;
	  dataGridViewXLichSuTienNo.CurrentCell=dataGridViewXLichSuTienNo.Rows[intSoThuTuHangMuonTroVao].Cells["ThoiGianThayDoiTienNo"];// Đưa Control về vị trí của nó
	  dataGridViewXLichSuTienNo.CurrentRow.Selected=true;// Set trạng thái Selected
	}
  }
}
