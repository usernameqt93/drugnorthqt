using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNQTDataAccessLayer {
  public class DAO_DonXacNhan:Connection {

	public DataTable dataTableBangDanhSachViThuocXepTheoTenThuoc() {
	  try {
		//		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc,bgvt.GiaViThuoc,bgvt.DonViGiaThuoc,bvt.GhiChuViThuoc,bgvt.MaGiaThuoc 
		//			from BangViThuoc bvt inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc order by bvt.TenViThuoc";
		string strSql=@"select bvt.MaViThuoc,bvt.TenViThuoc
			from BangViThuoc bvt order by bvt.TenViThuoc";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public object objMaDonXacNhanVuaThemCoThoiGianViet(ref string err,ref string result,DateTime dtThoiGianVietDonXacNhan) {
	  try {
		string strSql=@"insert into BangDanhSachDonXinXacNhan(ThoiGianVietDonNay,SoViThuocTrongDon) values (@ThoiGianVietDonNay,0); 
			select @@IDENTITY as MaDonXacNhanVuaThem;";
		SqlParameter ThoiGianVietDonNay=new SqlParameter("@ThoiGianVietDonNay",dtThoiGianVietDonXacNhan);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { ThoiGianVietDonNay });
	  } catch { }
	  return null;
	}
	public DataTable dataTableBangChiTietDonXacNhanTheoMaDonXacNhan(int intMaDonXacNhan) {
	  try {
		//		string strSql=@"select bcthd.MaChiTietDonHang,bcthd.MaViThuoc,bvt.TenViThuoc,
		//		  bcthd.SoLuongViThuoc,bgvt.DonViGiaThuoc, bgvt.GiaViThuoc,bcthd.ThanhTienTamThoi
		//	from BangChiTietDonHang bcthd inner join BangViThuoc bvt on bcthd.MaViThuoc=bvt.MaViThuoc
		//	inner join BangGiaViThuoc bgvt on bvt.MaViThuoc=bgvt.MaViThuoc where bcthd.MaDonHang="+intMaDonHang+"";
		string strSql=@"select bcthd.MaChiTietDonXinXacNhan,bcthd.MaViThuoc,bvt.TenViThuoc
	from BangChiTietDonXinXacNhan bcthd inner join BangViThuoc bvt on bcthd.MaViThuoc=bvt.MaViThuoc
	 where bcthd.MaDonXinXacNhan="+intMaDonXacNhan+" order by bcthd.MaChiTietDonXinXacNhan";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public object objCoBaoNhieuMaViThuocTrongMaDonXacNhan(ref string err,ref string result,int intMaViThuoc,int intMaDonXacNhan) {
	  try {
		//string strSql=@"select COUNT(MaChiTietDonHang) From BangChiTietDonHang where MaViThuoc=@MaViThuoc and MaDonHang=@MaDonHang";
		string strSql=@"select COUNT(MaChiTietDonXinXacNhan) From BangChiTietDonXinXacNhan where MaViThuoc=@MaViThuoc and MaDonXinXacNhan=@MaDonXinXacNhan";
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		SqlParameter MaDonXinXacNhan=new SqlParameter("@MaDonXinXacNhan",intMaDonXacNhan);
		return objectThucThiScalar(strSql,CommandType.Text,ref err,ref result,new SqlParameter[] { 
                    MaViThuoc,MaDonXinXacNhan});
	  } catch { }
	  return null;
	}
	public string strInsertBangChiTietDonXacNhanCoMaDonXacNhan(ref string err,
	  int intMaViThuoc,int intMaDonXacNhan) {
	  try {
		string strSql=@"Insert into BangChiTietDonXinXacNhan(MaDonXinXacNhan,MaViThuoc)
	values(@MaDonXinXacNhan,@MaViThuoc)";
		SqlParameter MaDonXinXacNhan=new SqlParameter("@MaDonXinXacNhan",intMaDonXacNhan);
		SqlParameter MaViThuoc=new SqlParameter("@MaViThuoc",intMaViThuoc);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  MaDonXinXacNhan,MaViThuoc}))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public DataTable dataTableBangDanhSachDonXacNhan() {
	  try {
		string strSql=@"select MaDonXinXacNhan,ThoiGianVietDonNay,TenNguoiViet,SoCMTND,NgaySinh,HoKhauThuongTru,SoViThuocTrongDon from BangDanhSachDonXinXacNhan";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public DataTable dataTableBangSoViThuocDonXN(int intMaDonXinXacNhan) {
	  try {
		string strSql=@"select count(MaChiTietDonXinXacNhan) as TongViThuoc 
			from BangChiTietDonXinXacNhan where MaDonXinXacNhan=@MaDonXinXacNhan";
		SqlParameter MaDonXinXacNhan=new SqlParameter("@MaDonXinXacNhan",intMaDonXinXacNhan);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { MaDonXinXacNhan });
	  } catch { }
	  return null;
	}
	public DataTable dataTableBANG_THONGTIN_NGUOIDUNG(int intMaDonXinXacNhan) {
	  try {
		string strSql=@"select TenNguoiViet,SoCMTND,NgaySinh,HoKhauThuongTru 
			from BangDanhSachDonXinXacNhan where MaDonXinXacNhan=@MaDonXinXacNhan";
		SqlParameter MaDonXinXacNhan=new SqlParameter("@MaDonXinXacNhan",intMaDonXinXacNhan);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { MaDonXinXacNhan });
	  } catch { }
	  return null;
	}
	public bool boolUPDATE_THONGTIN_DONXN(
	  ref string err,string strTenNguoiViet,string strSoCMTND,DateTime dtNgaySinh,string strHoKhau,int intTongViThuoc,int intMaDonXacNhan) {
	  try {
		string strSql=@"update BangDanhSachDonXinXacNhan 
			set TenNguoiViet=@TenNguoiViet,SoCMTND=@SoCMTND,NgaySinh=@NgaySinh,HoKhauThuongTru=@HoKhauThuongTru,SoViThuocTrongDon=@SoViThuocTrongDon 
			where MaDonXinXacNhan=@MaDonXinXacNhan";
		SqlParameter TenNguoiViet=new SqlParameter("@TenNguoiViet",strTenNguoiViet);
		SqlParameter SoCMTND=new SqlParameter("@SoCMTND",strSoCMTND);
		SqlParameter NgaySinh=new SqlParameter("@NgaySinh",dtNgaySinh);
		SqlParameter HoKhauThuongTru=new SqlParameter("@HoKhauThuongTru",strHoKhau);
		SqlParameter SoViThuocTrongDon=new SqlParameter("@SoViThuocTrongDon",intTongViThuoc);
		SqlParameter MaDonXinXacNhan=new SqlParameter("@MaDonXinXacNhan",intMaDonXacNhan);
		return blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  TenNguoiViet,SoCMTND,NgaySinh,HoKhauThuongTru,SoViThuocTrongDon,MaDonXinXacNhan });
	  } catch { }
	  return false;
	}
  }
}
