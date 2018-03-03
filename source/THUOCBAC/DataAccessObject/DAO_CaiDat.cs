using QTCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_CaiDat:Connection {
	public string STR_UPDATE_BANG_CAIDAT(
	  ref string err,string strHoTen,string strSoDienThoai,string strSoTaiKhoan,string strSDTBan,string strNgheNghiep,string strDiaChi) {
	  try {
		string strSql = @"Update BangCaiDat set 
			HoTenCaiDat=@HoTenCaiDat,SoDienThoaiCaiDat=@SoDienThoaiCaiDat,SoTaiKhoanCaiDat=@SoTaiKhoanCaiDat, 
			SoDienThoaiBanCaiDat=@SoDienThoaiBanCaiDat,NgheNghiepCaiDat=@NgheNghiepCaiDat,DiaChiCaiDat=@DiaChiCaiDat 
			where IdBangCaiDat=1";
		SqlParameter HoTenCaiDat = new SqlParameter("@HoTenCaiDat",strHoTen);
		SqlParameter SoDienThoaiCaiDat = new SqlParameter("@SoDienThoaiCaiDat",strSoDienThoai);
		SqlParameter SoTaiKhoanCaiDat = new SqlParameter("@SoTaiKhoanCaiDat",strSoTaiKhoan);
		SqlParameter SoDienThoaiBanCaiDat = new SqlParameter("@SoDienThoaiBanCaiDat",strSDTBan);
		SqlParameter NgheNghiepCaiDat = new SqlParameter("@NgheNghiepCaiDat",strNgheNghiep);
		SqlParameter DiaChiCaiDat = new SqlParameter("@DiaChiCaiDat",strDiaChi);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] {
		  HoTenCaiDat,SoDienThoaiCaiDat,SoTaiKhoanCaiDat,SoDienThoaiBanCaiDat,NgheNghiepCaiDat,DiaChiCaiDat }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public DataTable DATATABLE_BANG_CAIDAT(int intIdCaiDat) {
	  try {
		//string strSql=@"select HoTenCaiDat,SoDienThoaiCaiDat,SoTaiKhoanCaiDat,SoDienThoaiBanCaiDat,NgheNghiepCaiDat,DiaChiCaiDat 
		//	from BangCaiDat where IdBangCaiDat=@IdBangCaiDat";
		string strSql = QTLibraryFunction.STATIC_STR_QUERY_SELECT(
		  new List<string>() {
			QTDbConst.HOTEN_CAIDAT.STR,
			QTDbConst.SO_DIENTHOAI_CAIDAT.STR,
			QTDbConst.SO_TAIKHOAN_CAIDAT.STR,
			QTDbConst.SO_DIENTHOAIBAN_CAIDAT.STR,
			QTDbConst.NGHENGHIEP_CAIDAT.STR,
			QTDbConst.DIACHI_CAIDAT.STR }
		  ,QTDbConst.BANG_CAIDAT.STR
		  ,new List<string>() {
			QTDbConst.ID_BANG_CAIDAT.STR }
		  ,"and");
		SqlParameter IdBangCaiDat = new SqlParameter(QTLibraryFunction.STATIC_STR_AT(QTDbConst.ID_BANG_CAIDAT.STR),intIdCaiDat);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangCaiDat });
	  } catch { }
	  return null;
	}
  }
}
