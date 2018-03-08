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
	  rdoXemBanInCach1.Text=QTLibraryFunction.STATIC_STR_UNLOCK(QTDbConst.XEM_BANIN_CACH_1.STR);
	  rdoXemBanInCach2.Text=QTLibraryFunction.STATIC_STR_UNLOCK(QTDbConst.XEM_BANIN_CACH_2.STR);

	  rdoVietDHCach1.Text=QTLibraryFunction.STATIC_STR_UNLOCK(QTDbConst.VIET_DONHANG_CACH_1.STR);
	  rdoVietDHCach2.Text=QTLibraryFunction.STATIC_STR_UNLOCK(QTDbConst.VIET_DONHANG_CACH_2.STR);

	  if(QTAppSetting.STATIC_STR_CACHXEM_BANIN.Equals(QTDbConst.XEM_BANIN_CACH_2.STR)) {
		rdoXemBanInCach2.Checked=true;
		rtxtENoteCachXemBanIn.Text=QTDbConst.NOTE_BANIN_CACH_2.STR;
	  }
	  if(QTAppSetting.STATIC_STR_CACHXEM_BANIN.Equals(QTDbConst.XEM_BANIN_CACH_1.STR)) {
		rdoXemBanInCach1.Checked=true;
		rtxtENoteCachXemBanIn.Text=QTDbConst.NOTE_BANIN_CACH_1.STR;
	  }

	  if(QTAppSetting.STATIC_STR_CACHVIET_DONHANG.Equals(QTDbConst.VIET_DONHANG_CACH_1.STR)) {
		rdoVietDHCach1.Checked=true;
	  }
	  if(QTAppSetting.STATIC_STR_CACHVIET_DONHANG.Equals(QTDbConst.VIET_DONHANG_CACH_2.STR)) {
		rdoVietDHCach2.Checked=true;
	  }
	}

	private void btnXSave_Click(object sender,EventArgs e) {
	 // string strCachXemBanIn = QTDbConst.XEM_BANIN_CACH_1.STR;
	 // if(rdoXemBanInCach2.Checked) {
		//strCachXemBanIn=QTDbConst.XEM_BANIN_CACH_2.STR;
	 // }

	  BangSettingModel mSetting = new BangSettingModel() { CACHXEM_BANIN=QTDbConst.XEM_BANIN_CACH_1.STR
		,CACHVIET_DONHANG=QTDbConst.VIET_DONHANG_CACH_1.STR };
	  if(rdoXemBanInCach2.Checked) {
		mSetting.CACHXEM_BANIN=QTDbConst.XEM_BANIN_CACH_2.STR;
	  }
	  if(rdoVietDHCach2.Checked) {
		mSetting.CACHVIET_DONHANG=QTDbConst.VIET_DONHANG_CACH_2.STR;
	  }

	  string strLoi = "";
	  string strTrangThaiUpdateCaiDat = BL_SETTING.STR_UPDATE_BANG_SETTING(ref strLoi,mSetting,1);
	  if(strTrangThaiUpdateCaiDat.Equals("false")&&!strLoi.Equals("1"))
		MessageBox.Show("Trạng thái cập nhật thông tin cài đặt in ấn bị lỗi ("+strLoi+")");
	  else {
		//btnXLuuLai.Enabled=false;
		QTAppSetting.STATIC_STR_CACHXEM_BANIN=mSetting.CACHXEM_BANIN;
		QTAppSetting.STATIC_STR_CACHVIET_DONHANG=mSetting.CACHVIET_DONHANG;
		MessageBox.Show("Cập nhật thông tin cài đặt thành công !");
	  }
	}

	private void frmOptionForQuocTuan_Shown(object sender,EventArgs e) {
	  this.Focus();
	}
  }
}
