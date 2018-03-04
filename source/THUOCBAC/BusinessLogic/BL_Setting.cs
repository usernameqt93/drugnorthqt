using DataAccessObject;
using FValueObject.Models;
using QTCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic {
  public class BL_Setting {
	private DAO_Setting DAO_CAIDAT = new DAO_Setting();

	public string STR_UPDATE_BANG_SETTING( ref string err,string strCachXemBanIn,int _intIdBangSetting) {
	  return DAO_CAIDAT.STR_UPDATE_BANG_SETTING(ref err,strCachXemBanIn,_intIdBangSetting);
	}

	public void VOID_LAYTHONGTIN_BANGSETTING(ref BangSettingModel mBangCaiDat) {
	  DataTable dtCaiDat = DAO_CAIDAT.DATATABLE_BANG_SETTING(1);
	  if(dtCaiDat.Rows.Count>0) {
		mBangCaiDat.CACHXEM_BANIN=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.CACHXEM_BANIN.STR].ToString());
		//mBangCaiDat.SO_DIENTHOAI_CAIDAT=Convert.ToString(dtCaiDat.Rows[0]["SoDienThoaiCaiDat"].ToString());
		//mBangCaiDat.SO_TAIKHOAN_CAIDAT=Convert.ToString(dtCaiDat.Rows[0]["SoTaiKhoanCaiDat"].ToString());
		//mBangCaiDat.SO_DIENTHOAIBAN_CAIDAT=Convert.ToString(dtCaiDat.Rows[0]["SoDienThoaiBanCaiDat"].ToString());
		//mBangCaiDat.NGHENGHIEP_CAIDAT=Convert.ToString(dtCaiDat.Rows[0]["NgheNghiepCaiDat"].ToString());
		//mBangCaiDat.DIACHI_CAIDAT=Convert.ToString(dtCaiDat.Rows[0]["DiaChiCaiDat"].ToString());
	  }
	}
  }
}
