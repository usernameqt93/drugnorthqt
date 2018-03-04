using QTCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_Setting:Connection {

	public DataTable DATATABLE_BANG_SETTING(int intIdBangSetting) {
	  try {
		//string strSql=@"select HoTenCaiDat,SoDienThoaiCaiDat,SoTaiKhoanCaiDat,SoDienThoaiBanCaiDat,NgheNghiepCaiDat,DiaChiCaiDat 
		//	from BangCaiDat where IdBangCaiDat=@IdBangCaiDat";
		string strSql = QTLibraryFunction.STATIC_STR_QUERY_SELECT(
		  new List<string>() {
			QTDbConst.CACHXEM_BANIN.STR }
		  ,QTDbConst.BANG_SETTING.STR
		  ,new List<string>() {
			QTDbConst.ID_BANG_SETTING.STR }
		  ,"and");
		SqlParameter IdBangSetting = new SqlParameter(QTLibraryFunction.STATIC_STR_AT(QTDbConst.ID_BANG_SETTING.STR),intIdBangSetting);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangSetting });
	  } catch { }
	  return null;
	}

	public string STR_UPDATE_BANG_SETTING( ref string err,string strCachXemBanIn,int _intIdBangSetting) {
	  try {
		//string strSql = @"Update BangCaiDat set 
		//	HoTenCaiDat=@HoTenCaiDat,SoDienThoaiCaiDat=@SoDienThoaiCaiDat,SoTaiKhoanCaiDat=@SoTaiKhoanCaiDat, 
		//	SoDienThoaiBanCaiDat=@SoDienThoaiBanCaiDat,NgheNghiepCaiDat=@NgheNghiepCaiDat,DiaChiCaiDat=@DiaChiCaiDat 
		//	where IdBangCaiDat=1";
		//string strSql = @"Update BangSetting set 
		//	CachXemBanIn=@CachXemBanIn
		//	where IdBangSetting=@IdBangSetting";
		string strSql = QTLibraryFunction.STATIC_STR_QUERY_UPDATE(
		  QTDbConst.BANG_SETTING.STR
		  ,new List<string>() {
			QTDbConst.CACHXEM_BANIN.STR }
		  ,new List<string>() {
			QTDbConst.ID_BANG_SETTING.STR }
		  ,"and" );
		SqlParameter CachXemBanIn = new SqlParameter(QTLibraryFunction.STATIC_STR_AT(QTDbConst.CACHXEM_BANIN.STR),strCachXemBanIn);
		SqlParameter IdBangSetting = new SqlParameter(QTLibraryFunction.STATIC_STR_AT(QTDbConst.ID_BANG_SETTING.STR),_intIdBangSetting);
		//SqlParameter SoTaiKhoanCaiDat = new SqlParameter("@SoTaiKhoanCaiDat",strSoTaiKhoan);
		//SqlParameter SoDienThoaiBanCaiDat = new SqlParameter("@SoDienThoaiBanCaiDat",strSDTBan);
		//SqlParameter NgheNghiepCaiDat = new SqlParameter("@NgheNghiepCaiDat",strNgheNghiep);
		//SqlParameter DiaChiCaiDat = new SqlParameter("@DiaChiCaiDat",strDiaChi);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] {
		  CachXemBanIn,IdBangSetting }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
  }
}
