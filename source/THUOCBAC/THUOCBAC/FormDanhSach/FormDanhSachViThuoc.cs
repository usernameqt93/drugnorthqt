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
  public partial class FormDanhSachViThuoc:Form {
	private int INT_MAGIATHUOC=-1;
	private string STR_TEN_VITHUOC="";
	private decimal DEC_GIA_VITHUOC=0;
	private string STR_DONVITINH="";
	private int INT_MA_VITHUOC=-1;
	private int INT_SOTHUTU_DONG_DANGCHON=-1;
	private BL_ViThuoc BL_VITHUOC=new BL_ViThuoc();
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	public FormDanhSachViThuoc() {
	  InitializeComponent();
	}

	private void buttonXThemViThuoc_Click(object sender,EventArgs e) {
	  FormChucNang.FormThemViThuoc formThemViThuoc=new FormChucNang.FormThemViThuoc();
	  formThemViThuoc.ShowDialog();
	  //dataGridViewXDanhSachViThuoc.DataSource=BL_VITHUOC.dataTableBangDanhSachViThuocCungGia();
	  voidHIENTHI_DGV_VITHUOC_CO_STT("ViTriCuoiCung");
	  //dataGridViewXDanhSachViThuoc.FirstDisplayedScrollingRowIndex=dataGridViewXDanhSachViThuoc.RowCount-1;
	  
	}
	private void voidHIENTHI_DGV_VITHUOC_CO_STT(string strViTriTroDen) {
	  dataGridViewXDanhSachViThuoc.DataSource=BL_VITHUOC.dataTableBangDanhSachViThuocCungGiaCaTheoChuCai();
	  dataGridViewXDanhSachViThuoc.Columns["STT"].DisplayIndex=0;
	  if(strViTriTroDen.Equals("ViTriCuoiCung")) {
		//chuyển xuống dòng dưới cùng
		int intSoThuTuHangMuonTroVao=0;
		if (dataGridViewXDanhSachViThuoc.RowCount>1)
		intSoThuTuHangMuonTroVao=dataGridViewXDanhSachViThuoc.RowCount-1;
		dataGridViewXDanhSachViThuoc.CurrentCell=dataGridViewXDanhSachViThuoc.Rows[intSoThuTuHangMuonTroVao].Cells["TenViThuoc"];// Đưa Control về vị trí của nó
		dataGridViewXDanhSachViThuoc.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	  if(strViTriTroDen.Equals("ViTriDauTien")) {
		//chuyển đến dòng đầu tiên
		dataGridViewXDanhSachViThuoc.CurrentCell=dataGridViewXDanhSachViThuoc.Rows[0].Cells["TenViThuoc"];// Đưa Control về vị trí của nó
		dataGridViewXDanhSachViThuoc.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	  if(strViTriTroDen.Equals("ViTriDangChon")) {
		//chuyển đến dòng thứ n
		dataGridViewXDanhSachViThuoc.CurrentCell=dataGridViewXDanhSachViThuoc.Rows[INT_SOTHUTU_DONG_DANGCHON].Cells["TenViThuoc"];// Đưa Control về vị trí của nó
		dataGridViewXDanhSachViThuoc.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	}

	private void FormDanhSachViThuoc_Load(object sender,EventArgs e) {

	  //dataGridViewXDanhSachViThuoc.DataSource=BL_VITHUOC.dataTableBangDanhSachViThuocCungGia();
	  voidHIENTHI_DGV_VITHUOC_CO_STT("ViTriCuoiCung");
	  dataGridViewXDanhSachViThuoc.Columns["MaGiaThuoc"].Visible=false;
	  dataGridViewXDanhSachViThuoc.Columns["MaViThuoc"].Visible=false;
	  dataGridViewXDanhSachViThuoc.Columns["GiaViThuoc"].Visible=false;
	  dataGridViewXDanhSachViThuoc.Columns["DonViGiaThuoc"].Visible=false;
	  dataGridViewXDanhSachViThuoc.Columns["GhiChuViThuoc"].Visible=false;
	  dataGridViewXDanhSachViThuoc.Columns["GiaViThuoc"].DefaultCellStyle.Format="#,###.### vnđ";
	  //dataGridViewXDanhSachViThuoc.FirstDisplayedScrollingRowIndex=dataGridViewXDanhSachViThuoc.RowCount-1;
	  //dataGridViewXDanhSachViThuoc.SelectedRows[30].Selected=true;
	  //dataGridViewXDanhSachViThuoc.Rows[30].Cells[0].Selected=true;
	}
	private void dataGridViewXDanhSachViThuoc_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  //btnXSuaGiaViThuoc.Enabled=true;
		  //btnXXoaViThuoc.Enabled=true;
		  DataGridViewRow r=dataGridViewXDanhSachViThuoc.Rows[e.RowIndex];
		  STR_TEN_VITHUOC=Convert.ToString(r.Cells["TenViThuoc"].Value);
		  INT_MAGIATHUOC=Convert.ToInt32(r.Cells["MaGiaThuoc"].Value);
		  DEC_GIA_VITHUOC=Convert.ToDecimal(r.Cells["GiaViThuoc"].Value);
		  STR_DONVITINH=Convert.ToString(r.Cells["DonViGiaThuoc"].Value);
		  INT_MA_VITHUOC=Convert.ToInt32(r.Cells["MaViThuoc"].Value);
		  INT_SOTHUTU_DONG_DANGCHON=e.RowIndex;
		  //txtIdLopHoc.Text=Convert.ToString(r.Cells["IdLopHoc"].Value);
		  //txtTenLopHoc.Text=Convert.ToString(r.Cells["TenLopHoc"].Value);
		  //string abc=dataGridViewDSLopHoc.Rows[e.RowIndex].Cells["IdMonHoc"].Value.ToString();
		  //comboBoxLoaiLopHoc.SelectedValue=abc;
		  //dateTimePickerBatDauhoc.Value=Convert.ToDateTime(r.Cells["ThoiGianBatDau"].Value);
		  //dateTimePickerKetThucHoc.Value=Convert.ToDateTime(r.Cells["ThoiGianKetthuc"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXSuaGiaViThuoc_Click(object sender,EventArgs e) {
	  FormChucNang.FormSuaGiaViThuoc formSuaGiaViThuoc=
		new FormChucNang.FormSuaGiaViThuoc(INT_MA_VITHUOC,INT_MAGIATHUOC,STR_TEN_VITHUOC,DEC_GIA_VITHUOC,STR_DONVITINH);
	  formSuaGiaViThuoc.ShowDialog();
	  //dataGridViewXDanhSachViThuoc.DataSource=BL_VITHUOC.dataTableBangDanhSachViThuocCungGia();
	  voidHIENTHI_DGV_VITHUOC_CO_STT("ViTriDangChon");
	  btnXXoaViThuoc.Enabled=false;
	  btnXSuaGiaViThuoc.Enabled=false;
	}
	
	private void btnXXoaViThuoc_Click(object sender,EventArgs e) {
	  string strLoi="";
	  string strResult="";
	  bool boolCoViThuocNayTrongChiTietDHKo=BL_DONHANG.boolCoMaViThuocNayTrongChiTietDHKo(ref strLoi,ref strResult,INT_MA_VITHUOC);
	  if(boolCoViThuocNayTrongChiTietDHKo) {
		MessageBox.Show("Hiện tại vị thuốc này có tên trong một số đơn hàng lưu trữ,nếu xóa sẽ ảnh hưởng đến toàn bộ đơn hàng ngày trước, bạn hãy đổi tên vị thuốc thay vì xóa nó");
		btnXXoaViThuoc.Enabled=false;
	  } else {
		DialogResult dlr=MessageBox.Show(
		  "Bạn muốn xóa vị thuốc '"+STR_TEN_VITHUOC+"' ra khỏi danh sách?",QTStringConst.THONGBAO.STR,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
		if(dlr==DialogResult.Yes) {
		  bool boolCoXoaDuocKo=BL_VITHUOC.boolDeleteViThuocTheoIdViThuoc(ref strLoi,INT_MA_VITHUOC.ToString());
		  if(boolCoXoaDuocKo) {
			//dataGridViewXDanhSachViThuoc.DataSource=BL_VITHUOC.dataTableBangDanhSachViThuocCungGia();
			voidHIENTHI_DGV_VITHUOC_CO_STT("ViTriCuoiCung");
			MessageBox.Show("Xóa thành công, toàn bộ giá cùng tên vị thuốc này đã được xóa");
			btnXXoaViThuoc.Enabled=false;
			btnXSuaGiaViThuoc.Enabled=false;
		  } else {
			MessageBox.Show("Xóa thất bại,có lỗi ("+strLoi+")");
		  }
		}
	  }
	}
  }
}
