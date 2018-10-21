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
		string strSql=@"Update BangCaiDat set 
			HoTenCaiDat=@HoTenCaiDat,SoDienThoaiCaiDat=@SoDienThoaiCaiDat,SoTaiKhoanCaiDat=@SoTaiKhoanCaiDat, 
			SoDienThoaiBanCaiDat=@SoDienThoaiBanCaiDat,NgheNghiepCaiDat=@NgheNghiepCaiDat,DiaChiCaiDat=@DiaChiCaiDat 
			where IdBangCaiDat=1";
		SqlParameter HoTenCaiDat=new SqlParameter("@HoTenCaiDat",strHoTen);
		SqlParameter SoDienThoaiCaiDat=new SqlParameter("@SoDienThoaiCaiDat",strSoDienThoai);
		SqlParameter SoTaiKhoanCaiDat=new SqlParameter("@SoTaiKhoanCaiDat",strSoTaiKhoan);
		SqlParameter SoDienThoaiBanCaiDat=new SqlParameter("@SoDienThoaiBanCaiDat",strSDTBan);
		SqlParameter NgheNghiepCaiDat=new SqlParameter("@NgheNghiepCaiDat",strNgheNghiep);
		SqlParameter DiaChiCaiDat=new SqlParameter("@DiaChiCaiDat",strDiaChi);
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
		string strSql=@"select HoTenCaiDat,SoDienThoaiCaiDat,SoTaiKhoanCaiDat,SoDienThoaiBanCaiDat,NgheNghiepCaiDat,DiaChiCaiDat 
			from BangCaiDat where IdBangCaiDat=@IdBangCaiDat";
		SqlParameter IdBangCaiDat=new SqlParameter("@IdBangCaiDat",intIdCaiDat);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangCaiDat });
	  } catch { }
	  return null;
	}
  }
}
