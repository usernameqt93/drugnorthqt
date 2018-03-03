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

namespace THUOCBAC.FormCaiDat {
  public partial class FormThongTinInAn:Form {
	private BL_CaiDat BL_CAIDAT=new BL_CaiDat();
	private DataTable DT_THONGTIN_CAIDAT=new DataTable();
	public FormThongTinInAn() {
	  InitializeComponent();
	}

	private void btnXHuyBo_Click(object sender,EventArgs e) {
	  Close();
	}

	private void btnXLuuLai_Click(object sender,EventArgs e) {
	  try {
		if(txtXHoTen.Text.Equals(""))
		  MessageBox.Show("Họ tên không được để trống");
		else if(txtXSoDienThoai.Text.Equals(""))
		  MessageBox.Show("Số điện thoại không được để trống");
		else if(txtXSoTaiKhoan.Text.Equals(""))
		  MessageBox.Show("Số tài khoản không được để trống");
		else if(txtXSoDienThoaiBan.Text.Equals(""))
		  MessageBox.Show("Số điện thoại bàn không được để trống");
		else if(txtXChuyen.Text.Equals(""))
		  MessageBox.Show("Thông tin chuyên buôn bán không được để trống");
		else if(txtXDiaChi.Text.Equals(""))
		  MessageBox.Show("Địa chỉ không được để trống");
		else {
		  DialogResult dlr=MessageBox.Show("Toàn bộ thông tin in ấn cũ sẽ bị xóa bỏ thay bằng thông tin mới bạn vừa điền trên đây !\nBạn chắc chắn muốn lưu lại thông tin mới ?",
		"Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
		  if(dlr==DialogResult.Yes) {
			string strLoi="";
			string strTrangThaiUpdateCaiDat=BL_CAIDAT.STR_UPDATE_BANG_CAIDAT(
			  ref strLoi,txtXHoTen.Text,txtXSoDienThoai.Text,txtXSoTaiKhoan.Text,txtXSoDienThoaiBan.Text,txtXChuyen.Text,txtXDiaChi.Text);
			if(strTrangThaiUpdateCaiDat.Equals("false")&&!strLoi.Equals("1"))
			MessageBox.Show("Trạng thái cập nhật thông tin cài đặt in ấn bị lỗi ("+strLoi+")");
			else {
			  btnXLuuLai.Enabled=false;
			  MessageBox.Show("Cập nhật thông tin cài đặt thành công !");
			}
		  }
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void FormThongTinInAn_Load(object sender,EventArgs e) {
	  //DT_THONGTIN_CAIDAT=BL_CAIDAT.DATATABLE_BANG_CAIDAT();
	  //if(DT_THONGTIN_CAIDAT.Rows.Count>0) {  
	  //txtXHoTen.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0][QTDbConst.HOTEN_CAIDAT.STR].ToString());
	  //txtXSoDienThoai.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0]["SoDienThoaiCaiDat"].ToString());
	  //txtXSoTaiKhoan.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0]["SoTaiKhoanCaiDat"].ToString());
	  //txtXSoDienThoaiBan.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0]["SoDienThoaiBanCaiDat"].ToString());
	  //txtXChuyen.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0]["NgheNghiepCaiDat"].ToString());
	  //txtXDiaChi.Text=Convert.ToString(DT_THONGTIN_CAIDAT.Rows[0]["DiaChiCaiDat"].ToString());
	  //}
	  string strHoTen ="";
	  string strSDT="";
	  string strSoTK="";
	  string strSDTBan="";
	  string strNgheNghiep="";
	  string strDiaChi="";
	  BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref strHoTen,ref strSDT,ref strSoTK,ref strSDTBan,ref strNgheNghiep,ref strDiaChi);
	  txtXHoTen.Text=strHoTen;
	  txtXSoDienThoai.Text=strSDT;
	  txtXSoTaiKhoan.Text=strSoTK;
	  txtXSoDienThoaiBan.Text=strSDTBan;
	  txtXChuyen.Text=strNgheNghiep;
	  txtXDiaChi.Text=strDiaChi;
	}
  }
}
