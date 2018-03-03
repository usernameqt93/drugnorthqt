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

	public frmOptionForQuocTuan() {
	  InitializeComponent();
	}

	private void btnxCancel_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void frmOptionForQuocTuan_Load(object sender,EventArgs e) {
	  rdoXemBanInCach1.Text=QTDbConst.XEM_BANIN_CACH_1.STR;
	  rdoXemBanInCach2.Text=QTDbConst.XEM_BANIN_CACH_2.STR;

	  string strHoTen = "";
	  string strSDT = "";
	  string strSoTK = "";
	  string strSDTBan = "";
	  string strNgheNghiep = "";
	  string strDiaChi = "";
	  //BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref strHoTen,ref strSDT,ref strSoTK,ref strSDTBan,ref strNgheNghiep,ref strDiaChi);

	  BangCaiDatModel mBangCaiDat = new BangCaiDatModel();
	  BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref mBangCaiDat);
	  //txtXHoTen.Text=strHoTen;
	  //txtXSoDienThoai.Text=strSDT;
	  //txtXSoTaiKhoan.Text=strSoTK;
	  //txtXSoDienThoaiBan.Text=strSDTBan;
	  //txtXChuyen.Text=strNgheNghiep;
	  //txtXDiaChi.Text=strDiaChi;
	}

	private void btnXSave_Click(object sender,EventArgs e) {

	}

	private void frmOptionForQuocTuan_Shown(object sender,EventArgs e) {
	  this.Focus();
	}
  }
}
