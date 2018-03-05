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

namespace THUOCBAC.FormCaiDat {
  public partial class frmOptionForQuocTuan:Form {

	private BL_CaiDat BL_CAIDAT = new BL_CaiDat();
	private BL_Setting BL_SETTING = new BL_Setting();

	public frmOptionForQuocTuan() {
	  InitializeComponent();
	}

	private void btnxCancel_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void frmOptionForQuocTuan_Load(object sender,EventArgs e) {
	  rdoXemBanInCach1.Text=QTDbConst.XEM_BANIN_CACH_1.STR;
	  rdoXemBanInCach2.Text=QTDbConst.XEM_BANIN_CACH_2.STR;

	  //string strHoTen = "";
	  //string strSDT = "";
	  //string strSoTK = "";
	  //string strSDTBan = "";
	  //string strNgheNghiep = "";
	  //string strDiaChi = "";
	  //BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref strHoTen,ref strSDT,ref strSoTK,ref strSDTBan,ref strNgheNghiep,ref strDiaChi);

	  //BangCaiDatModel mBangCaiDat = new BangCaiDatModel();
	  //BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref mBangCaiDat);

	  //BangSettingModel mBangSetting = new BangSettingModel();
	  //BL_SETTING.VOID_LAYTHONGTIN_BANGSETTING(ref mBangSetting);
	  if(QTAppSetting.STATIC_STR_CACHXEM_BANIN.Equals(QTDbConst.XEM_BANIN_CACH_2.STR)) {
		rdoXemBanInCach2.Checked=true;
		rtxtENoteCachXemBanIn.Text=QTDbConst.NOTE_BANIN_CACH_2.STR;
	  }
	  if(QTAppSetting.STATIC_STR_CACHXEM_BANIN.Equals(QTDbConst.XEM_BANIN_CACH_1.STR)) {
		rdoXemBanInCach1.Checked=true;
		rtxtENoteCachXemBanIn.Text=QTDbConst.NOTE_BANIN_CACH_1.STR;
	  }
	  //txtXHoTen.Text=strHoTen;
	  //txtXSoDienThoai.Text=strSDT;
	  //txtXSoTaiKhoan.Text=strSoTK;
	  //txtXSoDienThoaiBan.Text=strSDTBan;
	  //txtXChuyen.Text=strNgheNghiep;
	  //txtXDiaChi.Text=strDiaChi;
	}

	private void btnXSave_Click(object sender,EventArgs e) {
	  string strCachXemBanIn = rdoXemBanInCach1.Text;
	  if(rdoXemBanInCach2.Checked) {
		strCachXemBanIn=rdoXemBanInCach2.Text;
	  }

	  string strLoi = "";
	  string strTrangThaiUpdateCaiDat = BL_SETTING.STR_UPDATE_BANG_SETTING( ref strLoi,strCachXemBanIn,1);
	  if(strTrangThaiUpdateCaiDat.Equals("false")&&!strLoi.Equals("1"))
		MessageBox.Show("Trạng thái cập nhật thông tin cài đặt in ấn bị lỗi ("+strLoi+")");
	  else {
		//btnXLuuLai.Enabled=false;
		QTAppSetting.STATIC_STR_CACHXEM_BANIN=strCachXemBanIn;
		MessageBox.Show("Cập nhật thông tin cài đặt thành công !");
	  }
	}

	private void frmOptionForQuocTuan_Shown(object sender,EventArgs e) {
	  this.Focus();
	}
  }
}
