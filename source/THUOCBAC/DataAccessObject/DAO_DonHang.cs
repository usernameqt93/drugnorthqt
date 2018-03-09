using QTCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_DonHang:Connection {

	public bool boolDeleteBangChiTietDonHang(ref string err) {
	  try {
		string strSql=@"Delete from BangChiTietDonHang";
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,null);
	  } catch { }
	  return false;
	}

	public bool boolDeleteBangChiTietDonHangTheoMaCTDH(ref string err,int intMaChiTietDonHang) {
	  try {
		string strSql=@"Delete from BangChiTietDonHang where MaChiTietDonHang=@MaChiTietDonHang";
		SqlParameter MaChiTietDonHang=new SqlParameter("@MaChiTietDonHang",intMaChiTietDonHang);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { MaChiTietDonHang });
	  } catch { }
	  return false;
	}
	public bool boolDELETE_BANG_DSDH_THEOID(ref string err,int intMaDonHang) {
	  try {
		string strSql=@"Delete from BangDanhSachDonHang where MaDonHang=@MaDonHang";
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { MaDonHang });
	  } catch { }
	  return false;
	}
	public DataTable dataTableBangDanhSachDonHang() {
	  try {
		string strSql=@"select MaDonHang,ThoiGianVietDonHangNay,TongViThuoc,TongKhoiLuong,TongGiaTriDonHang from BangDanhSachDonHang";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangDonHangTheoId(int intMaDonHang) {
	  try {
		string strSql=@"select CapNhatTienNoChua from BangDanhSachDonHang where MaDonHang=@MaDonHang ";
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { MaDonHang });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangDanhSachDonHangCoTenKH() {
	  try {
		string strSql=@"select bdsdh.MaDonHang,bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc, 
			bdsdh.TongKhoiLuong,bdsdh.TongGiaTriDonHang,bdsdh.IdBangKhachHang,bkh.TenKhachHang, 
			bdsdh.SDTKhachHang,bdsdh.TienNoCu
			from BangDanhSachDonHang bdsdh 
			inner join BangKhachHang bkh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public DataTable dataTableBangDanhSachDHTheoIdKH(int intIdBangKhachHang) {
	  try {
		string strSql=@"select bdsdh.MaDonHang,bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc, 
			bdsdh.TongKhoiLuong,bdsdh.TongGiaTriDonHang,bdsdh.IdBangKhachHang,bkh.TenKhachHang, 
			bdsdh.SDTKhachHang,bdsdh.TienNoCu
			from BangDanhSachDonHang bdsdh 
			inner join BangKhachHang bkh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang 
			where bdsdh.IdBangKhachHang=@IdBangKhachHang";
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdBangKhachHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangKhachHang });
	  } catch { }
	  return null;
	}
	public DataTable dataTableBANG_DANHSACH_DH_THEONGAY(DateTime dtThoiGianTimKiem) {
	  try {
		string strSql=@"select bdsdh.MaDonHang,bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc, 
			bdsdh.TongKhoiLuong,bdsdh.TongGiaTriDonHang,bdsdh.IdBangKhachHang,bkh.TenKhachHang, 
			bdsdh.SDTKhachHang,bdsdh.TienNoCu
			from BangDanhSachDonHang bdsdh 
			inner join BangKhachHang bkh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang ";
		strSql+=" where YEAR(bdsdh.ThoiGianVietDonHangNay)="+dtThoiGianTimKiem.Year
		  +" and MONTH(bdsdh.ThoiGianVietDonHangNay)="+dtThoiGianTimKiem.Month+" and DAY(bdsdh.ThoiGianVietDonHangNay)="+dtThoiGianTimKiem.Day;
		//SqlParameter ThoiGianVietDonHangNay=new SqlParameter("@ThoiGianVietDonHangNay",dtThoiGianTimKiem);
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public DataTable dataTableBangDanhSachViThuocCungGia() {
	  try {
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangDanhSachViThuocXepTheoTenThuoc() {
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
	public DataTable dataTableBANG_DS_VITHUOC_DACO_DH() {
	  try {
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc 
			and bgvt.ThoiGianBatDauCoGiaNay = (select MAX(bgvt.ThoiGianBatDauCoGiaNay) from BangGiaViThuoc bgvt where bgvt.MaViThuoc=bvt.MaViThuoc) 
			inner join BangChiTietDonHang bctdh on bgvt.MaGiaThuoc=bctdh.MaGiaThuoc 
			order by bvt.TenViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBANG_DS_VITHUOC_THEO_TENKH(string strTenKhachHang) {
	  try {
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.MaGiaThuoc   
			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc 
			inner join BangChiTietDonHang bctdh on bgvt.MaGiaThuoc=bctdh.MaGiaThuoc 
			inner join BangDanhSachDonHang bdsdh on bctdh.MaDonHang=bdsdh.MaDonHang 
			inner join BangKhachHang bkh on bdsdh.IdBangKhachHang=bkh.IdBangKhachHang 
			where bkh.TenKhachHang = @TenKhachHang 
			order by bvt.TenViThuoc";
		SqlParameter TenKhachHang=new SqlParameter("@TenKhachHang",strTenKhachHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { TenKhachHang });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBANG_LICHSU_GD_VT(string strTenViThuoc) {
	  try {
		string strSql=@"select bvt.TenViThuoc,bkh.TenKhachHang,bctdh.SoLuongViThuoc,bgvt.DonViGiaThuoc,bgvt.GiaViThuoc,bctdh.ThanhTienTamThoi,
	bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc,bdsdh.TongGiaTriDonHang,bdsdh.MaDonHang    
	from BangKhachHang bkh inner join BangDanhSachDonHang bdsdh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang 
	inner join BangChiTietDonHang bctdh on bdsdh.MaDonHang=bctdh.MaDonHang 
	inner join BangGiaViThuoc bgvt on bctdh.MaGiaThuoc=bgvt.MaGiaThuoc 
	inner join BangViThuoc bvt on bgvt.MaViThuoc=bvt.MaViThuoc 
	where bvt.TenViThuoc = @TenViThuoc";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { TenViThuoc });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBANG_LICHSU_CO_CACKITU(string strKiTu) {
	  try {
		string strSql=@"select bvt.TenViThuoc,bkh.TenKhachHang,bctdh.SoLuongViThuoc,bgvt.DonViGiaThuoc,bgvt.GiaViThuoc,bctdh.ThanhTienTamThoi,
	bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc,bdsdh.TongGiaTriDonHang,bdsdh.MaDonHang    
	from BangKhachHang bkh inner join BangDanhSachDonHang bdsdh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang 
	inner join BangChiTietDonHang bctdh on bdsdh.MaDonHang=bctdh.MaDonHang 
	inner join BangGiaViThuoc bgvt on bctdh.MaGiaThuoc=bgvt.MaGiaThuoc 
	inner join BangViThuoc bvt on bgvt.MaViThuoc=bvt.MaViThuoc 
	where bvt.TenViThuoc like N'%"+strKiTu+"%' order by bvt.TenViThuoc ";
		//SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strKiTu);
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBANG_LICHSU_GD_VT(string strTenViThuoc,string strTenKhachHang) {
	  try {
		string strSql=@"select bvt.TenViThuoc,bkh.TenKhachHang,bctdh.SoLuongViThuoc,bgvt.DonViGiaThuoc,bgvt.GiaViThuoc,bctdh.ThanhTienTamThoi,
	bdsdh.ThoiGianVietDonHangNay,bdsdh.TongViThuoc,bdsdh.TongGiaTriDonHang,bdsdh.MaDonHang    
	from BangKhachHang bkh inner join BangDanhSachDonHang bdsdh on bkh.IdBangKhachHang=bdsdh.IdBangKhachHang 
	inner join BangChiTietDonHang bctdh on bdsdh.MaDonHang=bctdh.MaDonHang 
	inner join BangGiaViThuoc bgvt on bctdh.MaGiaThuoc=bgvt.MaGiaThuoc 
	inner join BangViThuoc bvt on bgvt.MaViThuoc=bvt.MaViThuoc 
	where bkh.TenKhachHang=@TenKhachHang and bvt.TenViThuoc = @TenViThuoc";
		SqlParameter TenKhachHang=new SqlParameter("@TenKhachHang",strTenKhachHang);
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] {TenKhachHang, TenViThuoc });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangChiTietDonHang() {
	  try {
		string strSql=@"select bcthdtt.MaChiTietDonHang,bcthdtt.MaViThuoc,bvt.TenViThuoc,
		  bcthdtt.SoLuongViThuoc,bgvt.DonViGiaThuoc, bgvt.GiaViThuoc,bcthdtt.ThanhTienTamThoi,bcthdtt.GhiChuTamThoi
	from BangChiTietDonHang bcthdtt inner join BangViThuoc bvt on bcthdtt.MaViThuoc=bvt.MaViThuoc
	inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public DataTable dataTableBangChiTietDonHangTheoMaDonHang(int intMaDonHang) {
	  try {
		string strSql=@"select bcthd.MaChiTietDonHang,bcthd.MaViThuoc,bvt.TenViThuoc,
		  bcthd.SoLuongViThuoc,bgvt.DonViGiaThuoc, bgvt.GiaViThuoc,bcthd.ThanhTienTamThoi
	from BangChiTietDonHang bcthd inner join BangViThuoc bvt on bcthd.MaViThuoc=bvt.MaViThuoc
	inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc 
	and bgvt.ThoiGianBatDauCoGiaNay = (select MAX(bgvt.ThoiGianBatDauCoGiaNay) from BangGiaViThuoc bgvt where bgvt.MaViThuoc=bvt.MaViThuoc) 
	where bcthd.MaDonHang="+intMaDonHang+" order by bcthd.MaChiTietDonHang";
		//+" order by bgvt.ThoiGianBatDauCoGiaNay";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public DataTable dataTableBangChiTietDHMaGiaMaDH(int intMaDonHang) {
	  try {
		string strSql=@"select bcthd.MaChiTietDonHang,bvt.MaViThuoc,bvt.TenViThuoc,
		  bcthd.SoLuongViThuoc,bgvt.DonViGiaThuoc, bgvt.GiaViThuoc,bcthd.ThanhTienTamThoi
	from BangChiTietDonHang bcthd inner join BangGiaViThuoc bgvt on bcthd.MaGiaThuoc=bgvt.MaGiaThuoc 
	inner join BangViThuoc bvt on bgvt.MaViThuoc=bvt.MaViThuoc"
		  //+@" and bgvt.ThoiGianBatDauCoGiaNay = (select MAX(bgvt.ThoiGianBatDauCoGiaNay) from BangGiaViThuoc bgvt where bgvt.MaViThuoc=bvt.MaViThuoc)"
		  +@" where bcthd.MaDonHang="+intMaDonHang+" order by bcthd.MaChiTietDonHang";
		//+" order by bgvt.ThoiGianBatDauCoGiaNay";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public object objCoBaoNhieuMaViThuocNayTrongChiTietDH(ref string err,ref string result,int intMaViThuoc) {
	  try {
		string strSql=@"select COUNT(MaChiTietDonHang) From BangChiTietDonHang where MaViThuoc=@MaViThuoc";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { 
                    MaViThuoc});
	  } catch { }
	  return null;
	}

	public object objCoBaoNhieuMaViThuocTrongMaDonHang(ref string err,ref string result,int intMaViThuoc,int intMaDonHang) {
	  try {
		string strSql=@"select COUNT(MaChiTietDonHang) From BangChiTietDonHang where MaViThuoc=@MaViThuoc and MaDonHang=@MaDonHang";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { 
                    MaViThuoc,MaDonHang});
	  } catch { }
	  return null;
	}
	public object objMaViThuocCuaTenViThuocNay(ref string err,ref string result,string strTenViThuoc) {
	  try {
		string strSql=@"select MaViThuoc from BangViThuoc where TenViThuoc=@TenViThuoc";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { TenViThuoc });
	  } catch { }
	  return null;
	}

	public object objCoBaoNhieuTenViThuocTrongMaDonHang(ref string err,ref string result,string strTenViThuoc,int intMaDonHang) {
	  try {
		string strSql=@"select COUNT(MaChiTietDonHang) From BangChiTietDonHang bctdh inner join BangViThuoc bvt 
			on bctdh.MaViThuoc=bvt.MaViThuoc where TenViThuoc=@TenViThuoc and MaDonHang=@MaDonHang";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { 
                    TenViThuoc,MaDonHang});
	  } catch { }
	  return null;
	}

	public object objMaChiTietDHCuaTenViThuoc(ref string err,ref string result,string strTenViThuoc,int intMaDonHang) {
	  try {
		string strSql=@"select bctdh.MaChiTietDonHang From BangChiTietDonHang bctdh 
			inner join BangGiaViThuoc bgvt on bctdh.MaGiaThuoc=bgvt.MaGiaThuoc 
			inner join BangViThuoc bvt 
			on bgvt.MaViThuoc=bvt.MaViThuoc where TenViThuoc=@TenViThuoc and MaDonHang=@MaDonHang";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { 
                    TenViThuoc,MaDonHang});
	  } catch { }
	  return null;
	}

	public object objTongTienDonHang(ref string err,ref string result) {
	  try {
		string strSql=@"select sum(ThanhTienTamThoi) from BangChiTietDonHang ";
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public object objTongTienDonHangTheoMaDonHang(ref string err,ref string result,int intMaDonHang) {
	  try {
		string strSql=@"select sum(ThanhTienTamThoi) from BangChiTietDonHang where MaDonHang=@MaDonHang ";
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { MaDonHang });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public DataTable dataTableBangThongTinDH(int intMaDonHang) {
	  try {
		string strSql=@"select sum(ThanhTienTamThoi) as TongTienDonHang,sum(SoLuongViThuoc) as TongKhoiLuong,count(MaChiTietDonHang) as TongViThuoc 
			from BangChiTietDonHang where MaDonHang=@MaDonHang";
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { MaDonHang });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}

	public object objMaDonHangVuaThem(ref string err,ref string result) {
	  try {
		string strSql=@"insert into BangDanhSachDonHang(TongGiaTriDonHang) values (0); 
			select @@IDENTITY as MaDonHangVuaThem;";
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { });
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return null;
	}
	public object objMaDonHangVuaThemCoThoiGianVietDH(ref string err,ref string result,DateTime dtThoiGianVietDonHang) {
	  try {
		string strDaCapNhatTienNoChua= QTStringConst.CHUACAPNHAT.STR;
		string strSql=@"insert into BangDanhSachDonHang(ThoiGianVietDonHangNay,TongGiaTriDonHang,IdBangKhachHang,CapNhatTienNoChua) values (@ThoiGianVietDonHangNay,0,1,N'"+strDaCapNhatTienNoChua+@"'); 
			select @@IDENTITY as MaDonHangVuaThem;";
		SqlParameter ThoiGianVietDonHangNay=new SqlParameter("@ThoiGianVietDonHangNay",dtThoiGianVietDonHang);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { ThoiGianVietDonHangNay });
	  } catch { }
	  return null;
	}

	public string strInsertBangChiTietDonHang(ref string err,int intMaViThuoc,decimal decSoLuong,decimal decThanhTien) {
	  try {
		string strSql=@"Insert into BangChiTietDonHang(MaViThuoc,SoLuongViThuoc,ThanhTienTamThoi)
	values(@MaViThuoc,@SoLuongViThuoc,@ThanhTienTamThoi)";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		SqlParameter SoLuongViThuoc=new SqlParameter("@SoLuongViThuoc",decSoLuong);
		SqlParameter ThanhTienTamThoi=new SqlParameter("@ThanhTienTamThoi",decThanhTien);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { MaViThuoc,SoLuongViThuoc,ThanhTienTamThoi }))
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
	public string strInsertBangChiTietDonHangCoMaDonHang(ref string err,int intMaViThuoc,decimal decSoLuong,decimal decThanhTien,int intMaDonHang) {
	  try {
		string strSql=@"Insert into BangChiTietDonHang(MaViThuoc,MaDonHang,SoLuongViThuoc,ThanhTienTamThoi)
	values(@MaViThuoc,@MaDonHang,@SoLuongViThuoc,@ThanhTienTamThoi)";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		SqlParameter SoLuongViThuoc=new SqlParameter("@SoLuongViThuoc",decSoLuong);
		SqlParameter ThanhTienTamThoi=new SqlParameter("@ThanhTienTamThoi",decThanhTien);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { MaViThuoc,MaDonHang,SoLuongViThuoc,ThanhTienTamThoi }))
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

	public string strThemThongTinViThuocVaoDB(ref string err,string strTenViThuoc,decimal decDonGia,DateTime dtThoiGianCoGiaNay,
	  decimal decSoLuong,decimal decThanhTien,int intMaDonHang) {
	  try {
		string strDonVi="Kg";
		string strSql="declare @MaViThuocVuaThem int;declare @MaGiaThuocVuaThem int;";
		strSql+=@"insert into BangViThuoc(TenViThuoc) values(@TenViThuoc);";
		strSql+=@"set @MaViThuocVuaThem = (select @@IDENTITY);";
		//strSql+=@"select @@IDENTITY as MaViThuocVuaThem;";
		strSql+=@"insert into BangGiaViThuoc(MaViThuoc,GiaViThuoc,DonViGiaThuoc,ThoiGianBatDauCoGiaNay) 
			values(@MaViThuocVuaThem,@GiaViThuoc,'"+strDonVi+"',@ThoiGianBatDauCoGiaNay);";
		strSql+=@"set @MaGiaThuocVuaThem = (select @@IDENTITY);";
		strSql+=@"Insert into BangChiTietDonHang(MaDonHang,MaGiaThuoc,SoLuongViThuoc,ThanhTienTamThoi)
	values(@MaDonHang,@MaGiaThuocVuaThem,@SoLuongViThuoc,@ThanhTienTamThoi);";
		SqlParameter TenViThuoc=new SqlParameter("@TenViThuoc",strTenViThuoc);
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decDonGia);
		SqlParameter ThoiGianBatDauCoGiaNay=new SqlParameter("@ThoiGianBatDauCoGiaNay",dtThoiGianCoGiaNay);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		SqlParameter SoLuongViThuoc=new SqlParameter("@SoLuongViThuoc",decSoLuong);
		SqlParameter ThanhTienTamThoi=new SqlParameter("@ThanhTienTamThoi",decThanhTien);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  TenViThuoc,GiaViThuoc,ThoiGianBatDauCoGiaNay,MaDonHang,SoLuongViThuoc,ThanhTienTamThoi }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public string strThemViThuocDaCoVaoDonHang(ref string err,int intMaViThuoc,decimal decDonGia,DateTime dtThoiGianCoGiaNay,
	  decimal decSoLuong,decimal decThanhTien,int intMaDonHang) {
	  try {
		string strDonVi="Kg";
		string strSql="declare @MaGiaThuocVuaThem int;";
		//strSql+=@"insert into BangViThuoc(TenViThuoc) values(@TenViThuoc);";
		//strSql+=@"set @MaViThuocVuaThem = (select @@IDENTITY);";
		strSql+=@"insert into BangGiaViThuoc(MaViThuoc,GiaViThuoc,DonViGiaThuoc,ThoiGianBatDauCoGiaNay) 
			values(@MaViThuoc,@GiaViThuoc,'"+strDonVi+"',@ThoiGianBatDauCoGiaNay);";
		strSql+=@"set @MaGiaThuocVuaThem = (select @@IDENTITY);";
		strSql+=@"Insert into BangChiTietDonHang(MaDonHang,MaGiaThuoc,SoLuongViThuoc,ThanhTienTamThoi)
	values(@MaDonHang,@MaGiaThuocVuaThem,@SoLuongViThuoc,@ThanhTienTamThoi);";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decDonGia);
		SqlParameter ThoiGianBatDauCoGiaNay=new SqlParameter("@ThoiGianBatDauCoGiaNay",dtThoiGianCoGiaNay);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		SqlParameter SoLuongViThuoc=new SqlParameter("@SoLuongViThuoc",decSoLuong);
		SqlParameter ThanhTienTamThoi=new SqlParameter("@ThanhTienTamThoi",decThanhTien);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  MaViThuoc,GiaViThuoc,ThoiGianBatDauCoGiaNay,MaDonHang,SoLuongViThuoc,ThanhTienTamThoi }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public string strCapNhatGiaCaViThuocVaoDH(ref string err,int intMaChiTietDonHang,decimal decDonGia,DateTime dtThoiGianCoGiaNay,
	  decimal decSoLuong,decimal decThanhTien) {
	  try {
		//string strDonVi="Kg";
		string strSql="";
		strSql+="declare @MaGiaThuoc int;";
		//		strSql+=@"insert into BangViThuoc(TenViThuoc) values(@TenViThuoc);";
		//		strSql+=@"set @MaGiaThuoc = (select TOP 1 MaGiaThuoc from BangGiaViThuoc bgvt inner join BangViThuoc bvt on bgvt.MaViThuoc=bvt.MaViThuoc
		//			inner join BangChiTietDonHang bctdh on bvt.MaViThuoc=bgvt.MaViThuoc 
		//			where bctdh.MaChiTietDonHang=@MaChiTietDonHang order by bgvt.ThoiGianBatDauCoGiaNay asc );";
		strSql+=@"set @MaGiaThuoc = (select MaGiaThuoc from BangChiTietDonHang  where MaChiTietDonHang=@MaChiTietDonHang);";
		//		strSql+=@"insert into BangGiaViThuoc(MaViThuoc,GiaViThuoc,DonViGiaThuoc,ThoiGianBatDauCoGiaNay) 
		//			values(@MaViThuocVuaThem,@GiaViThuoc,'"+strDonVi+"',@ThoiGianBatDauCoGiaNay);";
		//		strSql+=@"Insert into BangChiTietDonHang(MaViThuoc,MaDonHang,SoLuongViThuoc,ThanhTienTamThoi)
		//	values(@MaViThuocVuaThem,@MaDonHang,@SoLuongViThuoc,@ThanhTienTamThoi);";
		strSql+=@"update BangGiaViThuoc set GiaViThuoc=@GiaViThuoc,ThoiGianBatDauCoGiaNay=@ThoiGianBatDauCoGiaNay where MaGiaThuoc=@MaGiaThuoc;";
		strSql+=@"update BangChiTietDonHang set SoLuongViThuoc=@SoLuongViThuoc,ThanhTienTamThoi=@ThanhTienTamThoi where MaChiTietDonHang=@MaChiTietDonHang;";
		SqlParameter MaChiTietDonHang=new SqlParameter("@MaChiTietDonHang",intMaChiTietDonHang);
		SqlParameter GiaViThuoc=new SqlParameter("@GiaViThuoc",decDonGia);
		SqlParameter ThoiGianBatDauCoGiaNay=new SqlParameter("@ThoiGianBatDauCoGiaNay",dtThoiGianCoGiaNay);
		//SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		SqlParameter SoLuongViThuoc=new SqlParameter("@SoLuongViThuoc",decSoLuong);
		SqlParameter ThanhTienTamThoi=new SqlParameter("@ThanhTienTamThoi",decThanhTien);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  MaChiTietDonHang,GiaViThuoc,ThoiGianBatDauCoGiaNay,SoLuongViThuoc,ThanhTienTamThoi }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public bool boolUpdateTongGiaTriDonHangTheoMaDH(ref string err,int intTongViThuoc,decimal decTongKhoiLuong,decimal decTongGiaTriDonHang,int intMaDonHang) {
	  try {
		string strSql=@"update BangDanhSachDonHang set TongViThuoc=@TongViThuoc,TongKhoiLuong=@TongKhoiLuong,TongGiaTriDonHang=@TongGiaTriDonHang 
			where MaDonHang=@MaDonHang";
		SqlParameter TongViThuoc=new SqlParameter("@TongViThuoc",intTongViThuoc);
		SqlParameter TongKhoiLuong=new SqlParameter("@TongKhoiLuong",decTongKhoiLuong);
		SqlParameter TongGiaTriDonHang=new SqlParameter("@TongGiaTriDonHang",decTongGiaTriDonHang);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TongViThuoc,TongKhoiLuong,TongGiaTriDonHang,MaDonHang });
	  } catch { }
	  return false;
	}
	public bool boolUPDATE_IDKH_VAO_DH(ref string err,int intIdBangKH,int intMaDonHang) {
	  try {
		string strSql=@"update BangDanhSachDonHang set IdBangKhachHang=@IdBangKhachHang  where MaDonHang=@MaDonHang";
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdBangKH);
		//SqlParameter TongKhoiLuong=new SqlParameter("@TongKhoiLuong",decTongKhoiLuong);
		//SqlParameter TongGiaTriDonHang=new SqlParameter("@TongGiaTriDonHang",decTongGiaTriDonHang);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { IdBangKhachHang,MaDonHang });
	  } catch { }
	  return false;
	}
	public bool boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref string err,int intIdBangKH,string strSDTKH,decimal decTienNoCu,int intMaDonHang) {
	  try {
		string strSql=@"update BangDanhSachDonHang set IdBangKhachHang=@IdBangKhachHang,SDTKhachHang=@SDTKhachHang,TienNoCu=@TienNoCu  where MaDonHang=@MaDonHang";
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdBangKH);
		SqlParameter SDTKhachHang=new SqlParameter("@SDTKhachHang",strSDTKH);
		SqlParameter TienNoCu=new SqlParameter("@TienNoCu",decTienNoCu);
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { IdBangKhachHang,SDTKhachHang,TienNoCu,MaDonHang });
	  } catch { }
	  return false;
	}
  }
}
