using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using QTCommon;
using FValueObject.Models;

namespace BusinessLogic {
  public class BL_CaiDat {
	private DAO_CaiDat DAO_CAIDAT=new DAO_CaiDat();
	public string STR_UPDATE_BANG_CAIDAT(
	  ref string err,string strHoTen,string strSoDienThoai,string strSoTaiKhoan,string strSDTBan,string strNgheNghiep,string strDiaChi) {
		return DAO_CAIDAT.STR_UPDATE_BANG_CAIDAT(ref err,strHoTen,strSoDienThoai,strSoTaiKhoan,strSDTBan,strNgheNghiep,strDiaChi);
	}
	public DataTable DATATABLE_BANG_CAIDAT() {
	  return DAO_CAIDAT.DATATABLE_BANG_CAIDAT(1);
	}
	public void VOID_LAYTHONGTIN_BANGCAIDAT(ref string strHoTen,ref string strSDT,ref string strSoTK,ref string strSDTBan,ref string strNgheNghiep,ref string strDiaChi) {
	  DataTable dtCaiDat=DAO_CAIDAT.DATATABLE_BANG_CAIDAT(1);
	  if(dtCaiDat.Rows.Count>0) {
		strHoTen=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.HOTEN_CAIDAT.STR].ToString());
		strSDT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_DIENTHOAI_CAIDAT.STR].ToString());
		strSoTK=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_TAIKHOAN_CAIDAT.STR].ToString());
		strSDTBan=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_DIENTHOAIBAN_CAIDAT.STR].ToString());
		strNgheNghiep=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.NGHENGHIEP_CAIDAT.STR].ToString());
		strDiaChi=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.DIACHI_CAIDAT.STR].ToString());
	  }
	  if(dtCaiDat.Rows.Count==0) {
		strHoTen="";
		strSDT="";
		strSoTK="";
		strSDTBan="";
		strNgheNghiep="";
		strDiaChi="";
	  }
	}

	public void VOID_LAYTHONGTIN_BANGCAIDAT(ref BangCaiDatModel mBangCaiDat) {
	  DataTable dtCaiDat = DAO_CAIDAT.DATATABLE_BANG_CAIDAT(1);
	  if(dtCaiDat.Rows.Count>0) {
		mBangCaiDat.HOTEN_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.HOTEN_CAIDAT.STR].ToString());
		mBangCaiDat.SO_DIENTHOAI_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_DIENTHOAI_CAIDAT.STR].ToString());
		mBangCaiDat.SO_TAIKHOAN_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_TAIKHOAN_CAIDAT.STR].ToString());
		mBangCaiDat.SO_DIENTHOAIBAN_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.SO_DIENTHOAIBAN_CAIDAT.STR].ToString());
		mBangCaiDat.NGHENGHIEP_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.NGHENGHIEP_CAIDAT.STR].ToString());
		mBangCaiDat.DIACHI_CAIDAT=Convert.ToString(dtCaiDat.Rows[0][QTDbConst.DIACHI_CAIDAT.STR].ToString());
	  }
	 // if(dtCaiDat.Rows.Count==0) {
		//strHoTen="";
		//strSDT="";
		//strSoTK="";
		//strSDTBan="";
		//strNgheNghiep="";
		//strDiaChi="";
	 // }
	}
  }
}
