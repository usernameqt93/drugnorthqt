using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_GiaViThuoc:Connection {
	public bool boolUpdateGiaViThuoc(ref string err,
	  decimal decimalGiaViThuoc,string strDonViTinh,int intMaGiaThuoc) {
	  try {
		string strSql="update BangGiaViThuoc set GiaViThuoc=@GiaViThuoc,DonViGiaThuoc=@DonViGiaThuoc where MaGiaThuoc=@MaGiaThuoc";
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decimalGiaViThuoc);
		SqlParameter DonViGiaThuoc=new SqlParameter("@DonViGiaThuoc",strDonViTinh);
		SqlParameter MaGiaThuoc=new SqlParameter("@MaGiaThuoc",intMaGiaThuoc);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
                    GiaViThuoc, DonViGiaThuoc, MaGiaThuoc});
	  } catch(Exception ex) {
		//log.Error("Loi Q201611120958T phuong thuc boolUpdateDanhSachLopHoc: "+ex.Message);
	  }
	  return false;
	}
	public bool boolUpdateViThuoc(ref string err,string strTenViThuoc,int intMaViThuoc) {
	  try {
		string strSql="update BangViThuoc set TenViThuoc=@TenViThuoc where MaViThuoc=@MaViThuoc";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		//SqlParameter MaGiaThuoc=new SqlParameter("@MaGiaThuoc",intMaGiaThuoc);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
                    TenViThuoc, MaViThuoc});
	  } catch(Exception ex) {
		//log.Error("Loi Q201611120958T phuong thuc boolUpdateDanhSachLopHoc: "+ex.Message);
	  }
	  return false;
	}

//	public string strInsertBangGiaViThuoc(ref string err,int intMaGiaThuoc,string strTenViThuoc,decimal decimalGiaViThuoc,string strDonViTinh) {
//	  try {
//		string strSql=@"Insert into BangGiaViThuoc(TenViThuoc,GhiChuViThuoc) 
//                    values (@TenViThuoc,@GhiChuViThuoc)";
//		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
//		SqlParameter GhiChuViThuoc=new SqlParameter("@GhiChuViThuoc",strGhiChuViThuoc);
//		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenViThuoc,GhiChuViThuoc }))
//		  return "pass";
//		else
//		  return "false";
//	  } catch(Exception ex) {
//		//log.Error("Loi Q201611150848T phuong thuc strInsertBangTinNhan: "+ex.Message);
//	  }
//	  return "false";
//	  //thực thi non query là khi ta thực hiện 1 câu lệnh query mà biểu thức chẳng trả về giá trị gì cả.
//	  //như câu lệnh update, insert, select, delete.
//	}


  }
}
