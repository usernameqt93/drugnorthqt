using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_ViThuoc:Connection {
	public string strInsertViThuocVaGia(ref string err,string strTenViThuoc,decimal decGiaViThuoc,
	  string strDonViTinh,string strGhiChuViThuoc) {
	  try {
		string strSql=@"insert into BangViThuoc(TenViThuoc,GhiChuViThuoc) values(@TenViThuoc,@GhiChuViThuoc);
			select @@IDENTITY as MaViThuocVuaThem into #tenBang;
			DECLARE @MaViThuocVuaThem int;
			SET @MaViThuocVuaThem = (select MaViThuocVuaThem from #tenBang);
			insert into BangGiaViThuoc(MaViThuoc,GiaViThuoc,DonViGiaThuoc) values(@MaViThuocVuaThem,@GiaViThuoc,@DonViGiaThuoc);";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter GhiChuViThuoc=new SqlParameter("@GhiChuViThuoc",strGhiChuViThuoc);
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decGiaViThuoc);
		SqlParameter DonViGiaThuoc=new SqlParameter("@DonViGiaThuoc",strDonViTinh);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenViThuoc,GhiChuViThuoc,GiaViThuoc,DonViGiaThuoc }))
		  return "pass";
		else
		  return "false";
	  } catch {
		//log.Error("Loi Q201611150848T phuong thuc strInsertBangTinNhan: "+ex.Message);
	  }
	  return "false";
	  //thực thi non query là khi ta thực hiện 1 câu lệnh query mà biểu thức chẳng trả về giá trị gì cả.
	  //như câu lệnh update, insert, select, delete.
	}
	public string strINSERT_VITHUOC_DAUTIEN(ref string err,string strTenViThuoc,decimal decGiaViThuoc, string strDonViTinh,DateTime dtThoiGianCoGiaNay) {
	  try {
		string strSql=@"insert into BangViThuoc(TenViThuoc) values(@TenViThuoc);
			select @@IDENTITY as MaViThuocVuaThem into #tenBang;
			DECLARE @MaViThuocVuaThem int;
			SET @MaViThuocVuaThem = (select MaViThuocVuaThem from #tenBang);
			insert into BangGiaViThuoc(MaViThuoc,GiaViThuoc,DonViGiaThuoc,ThoiGianBatDauCoGiaNay) 
			values(@MaViThuocVuaThem,@GiaViThuoc,@DonViGiaThuoc,@ThoiGianBatDauCoGiaNay);";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter ThoiGianBatDauCoGiaNay=new SqlParameter("@ThoiGianBatDauCoGiaNay",dtThoiGianCoGiaNay);
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decGiaViThuoc);
		SqlParameter DonViGiaThuoc=new SqlParameter("@DonViGiaThuoc",strDonViTinh);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenViThuoc,ThoiGianBatDauCoGiaNay,GiaViThuoc,DonViGiaThuoc }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public string strInsertBangViThuoc(ref string err,string strTenViThuoc,string strGhiChuViThuoc) {
	  try {
		string strSql=@"Insert into BangViThuoc(TenViThuoc,GhiChuViThuoc) 
                    values (@TenViThuoc,@GhiChuViThuoc)";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter GhiChuViThuoc=new SqlParameter("@GhiChuViThuoc",strGhiChuViThuoc);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenViThuoc,GhiChuViThuoc }))
		  return "pass";
		else
		  return "false";
	  } catch {
		//log.Error("Loi Q201611150848T phuong thuc strInsertBangTinNhan: "+ex.Message);
	  }
	  return "false";
	  //thực thi non query là khi ta thực hiện 1 câu lệnh query mà biểu thức chẳng trả về giá trị gì cả.
	  //như câu lệnh update, insert, select, delete.
	}

	public DataTable dataTableBangDanhSachViThuoc() {
	  try {
		string strSql="select TenViThuoc,GhiChuViThuoc from BangViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public DataTable dataTableBangDanhSachViThuocCungGia() {
	  try {
		string strSql=@"select bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public DataTable dataTableBangDanhSachViThuocCungGiaCa() {
	  try {
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangDanhSachViThuocCungGiaCaTheoChuCai() {
	  try {
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc 
			and bgvt.ThoiGianBatDauCoGiaNay = (select MAX(bgvt.ThoiGianBatDauCoGiaNay) from BangGiaViThuoc bgvt where bgvt.MaViThuoc=bvt.MaViThuoc) 
			order by bvt.TenViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public bool boolDeleteViThuocTheoIdViThuoc(ref string err,string strIdViThuoc) {
	  try {
		string strSql="Delete from BangGiaViThuoc where MaViThuoc="+strIdViThuoc+";";
		strSql+="Delete from BangViThuoc where MaViThuoc="+strIdViThuoc+";";
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,null);
	  } catch { }
	  return false;
	}
  }
}
