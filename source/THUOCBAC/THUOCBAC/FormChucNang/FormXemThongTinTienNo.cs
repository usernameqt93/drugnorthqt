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
	  if(voidHIENTHI_TIENNOCU_RA_NUMBERIC!=null)
		voidHIENTHI_TIENNOCU_RA_NUMBERIC(DEC_TIENNO_HIENTAI);
	  Close();
	}

	private void FormXemThongTinTienNo_Load(object sender,EventArgs e) {
	  labelXTenKhachHang.Text=STR_TENKHACHHANG;
	  if(STR_LUUY_FORM_TRUOC.Equals("Ẩn nút Xác nhận"))
		btnXXacNhanTienNo.Visible=false;
	  labelXTienNoHienTai.Text=(DEC_TIENNO_HIENTAI==0)?"0 đ":DEC_TIENNO_HIENTAI.ToString("#,###.#")+" đ";
	  voidHIENTHI_DGV_LICHSU_CO_STT();
	  dataGridViewXLichSuTienNo.Columns["STT"].Width=22;
	  dataGridViewXLichSuTienNo.Columns["ThoiGianThayDoiTienNo"].HeaderText="Thời gian";
	  dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].HeaderText="Trước khi sửa";
	  dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].HeaderText="Số tiền sửa";
	  dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].HeaderText="Sau khi sửa";
	  dataGridViewXLichSuTienNo.Columns["LyDoSuaTienNo"].HeaderText="Chi tiết";
	  dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].DefaultCellStyle.Format="#,###.### đ";
	  dataGridViewXLichSuTienNo.Columns["TienNoTruocKhiSua"].Width=88;
	  dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].DefaultCellStyle.Format="#,###.### đ";
	  dataGridViewXLichSuTienNo.Columns["SoTienSuaCuThe"].Width=88;
	  dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].DefaultCellStyle.Format="#,###.### đ";
	  dataGridViewXLichSuTienNo.Columns["TienNoSauKhiSua"].Width=88;

	  voidTRO_XUONG_VITRI_CUOICUNG();
	}
	private void voidHIENTHI_DGV_LICHSU_CO_STT() {
	  DataTable dtSTT=DT_LICHSU_TIENNO;
	  dtSTT.Columns.Add("STT");
	  for(int i=0;i<dtSTT.Rows.Count;i++)
		dtSTT.Rows[i]["STT"]=i+1;
	  dataGridViewXLichSuTienNo.DataSource=dtSTT;
	  dataGridViewXLichSuTienNo.Columns["STT"].DisplayIndex=0;
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
