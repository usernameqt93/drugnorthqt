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

			  QTAppInfo.FullName=txtXHoTen.Text;
			  QTAppInfo.Phone=txtXSoDienThoai.Text;
			  QTAppInfo.AccountBank=txtXSoTaiKhoan.Text;
			  QTAppInfo.PhoneDesk=txtXSoDienThoaiBan.Text;
			  QTAppInfo.JobInfo=txtXChuyen.Text;
			  QTAppInfo.Address=txtXDiaChi.Text;

			  MessageBox.Show("Cập nhật thông tin cài đặt thành công !");
			}
		  }
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void FormThongTinInAn_Load(object sender,EventArgs e) {
	  //string strHoTen ="";
	  //string strSDT="";
	  //string strSoTK="";
	  //string strSDTBan="";
	  //string strNgheNghiep="";
	  //string strDiaChi="";
	  //BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref strHoTen,ref strSDT,ref strSoTK,ref strSDTBan,ref strNgheNghiep,ref strDiaChi);
	  txtXHoTen.Text=QTAppInfo.FullName;
	  txtXSoDienThoai.Text=QTAppInfo.Phone;
	  txtXSoTaiKhoan.Text=QTAppInfo.AccountBank;
	  txtXSoDienThoaiBan.Text=QTAppInfo.PhoneDesk;
	  txtXChuyen.Text=QTAppInfo.JobInfo;
	  txtXDiaChi.Text=QTAppInfo.Address;
	}
  }
}
