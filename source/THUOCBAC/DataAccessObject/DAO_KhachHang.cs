using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class DAO_KhachHang:Connection {
	public DataTable DATATABLE_BANG_KHACHHANG_XEPTHEOTEN() {
	  try {
		string strSql=@"select IdBangKhachHang,TenKhachHang from BangKhachHang order by TenKhachHang";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public DataTable DATATABLE_DANHSACH_KHACHHANG() {
	  try {
		string strSql=@"select IdBangKhachHang,TenKhachHang,TienNoHienTai from BangKhachHang order by TenKhachHang";
		return dataTableThucThiQuery(strSql,CommandType.Text,null);
	  } catch { }
	  return null;
	}
	public DataTable DATATABLE_KHACHHANG_THEO_ID(int intIdKhachHang) {
	  try {
		string strSql=@"select TenKhachHang,TienNoHienTai from BangKhachHang where IdBangKhachHang=@IdBangKhachHang ";
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdKhachHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangKhachHang });
	  } catch { }
	  return null;
	}
	public DataTable DATATABLE_LICHSU_TIENNO_THEO_IDKH(int intIdKhachHang) {
	  try {
		string strSql=@"select ThoiGianThayDoiTienNo,LyDoSuaTienNo,TienNoTruocKhiSua,SoTienSuaCuThe,TienNoSauKhiSua from BangChiTietTienNo where IdBangKhachHang=@IdBangKhachHang";
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdKhachHang);
		return dataTableThucThiQuery(strSql,CommandType.Text,new SqlParameter[] { IdBangKhachHang });
	  } catch { }
	  return null;
	}
	public string STR_INSERT_BANGKHACHHANG(ref string err,string strTenKhachHang) {
	  try {
		string strSql=@"Insert into BangKhachHang(TenKhachHang)  values (@TenKhachHang)";
		SqlParameter TenKhachHang=new SqlParameter("@TenKhachHang",strTenKhachHang);
		//SqlParameter GhiChuViThuoc=new SqlParameter("@GhiChuViThuoc",strGhiChuViThuoc);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenKhachHang }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
	public string STR_INSERT_KHACHHANG_LANDAU(ref string err,string strTenKhachHang) {
	  try {
		string strLyDoSuaTienNo="Thêm tên khách hàng lần đầu tiên";
		string strSql=@"declare @IdBangKhachHangVuaThem int;
			Insert into BangKhachHang(TenKhachHang,TienNoHienTai)  values (@TenKhachHang,0); ";
		strSql+="set @IdBangKhachHangVuaThem = (select @@IDENTITY);";
		strSql+=@"Insert into BangChiTietTienNo(IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua) 
			values (@IdBangKhachHangVuaThem,@ThoiGianThayDoiTienNo,0,N'"+strLyDoSuaTienNo+"',0,0);";
		SqlParameter TenKhachHang=new SqlParameter("@TenKhachHang",strTenKhachHang);
		DateTime dtThoiGianThayDoi=DateTime.Now;
		SqlParameter ThoiGianThayDoiTienNo=new SqlParameter("@ThoiGianThayDoiTienNo",dtThoiGianThayDoi);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { TenKhachHang,ThoiGianThayDoiTienNo }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}

	public string STR_SUA_TIENNO_KH(ref string err,decimal decTienNoHienTai,int intIdKhachHang,DateTime dtThoiGianThayDoi,decimal decTienNoTruocKhiSua,
	  string strLyDoSuaTienNo,decimal decSoTienSuaCuThe,decimal decTienNoSauKhiSua) {
	  try {
		//string strLyDoSuaTienNo="Thay đổi tiền nợ";
		string strSql=@"update BangKhachHang set TienNoHienTai=@TienNoHienTai where IdBangKhachHang=@IdBangKhachHang; ";
		//strSql+="set @IdBangKhachHangVuaThem = (select @@IDENTITY);";
		strSql+=@"Insert into BangChiTietTienNo(IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua) 
			values (@IdBangKhachHang,@ThoiGianThayDoiTienNo,@TienNoTruocKhiSua,@LyDoSuaTienNo,@SoTienSuaCuThe,@TienNoSauKhiSua);";
		SqlParameter TienNoHienTai=new SqlParameter("@TienNoHienTai",decTienNoHienTai);
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdKhachHang);
		SqlParameter ThoiGianThayDoiTienNo=new SqlParameter("@ThoiGianThayDoiTienNo",dtThoiGianThayDoi);
		SqlParameter TienNoTruocKhiSua=new SqlParameter("@TienNoTruocKhiSua",decTienNoTruocKhiSua);
		SqlParameter LyDoSuaTienNo=new SqlParameter("@LyDoSuaTienNo",strLyDoSuaTienNo);
		SqlParameter SoTienSuaCuThe=new SqlParameter("@SoTienSuaCuThe",decSoTienSuaCuThe);
		SqlParameter TienNoSauKhiSua=new SqlParameter("@TienNoSauKhiSua",decTienNoSauKhiSua);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  TienNoHienTai,IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}

	public string STR_SUA_TEN_KHACHHANG(ref string err,string _strTenKhachHangSua,int intIdKhachHang) {
	  try {
		//string strLyDoSuaTienNo="Thay đổi tiền nợ";
		string strSql = @"update BangKhachHang set TenKhachHang=@TenKhachHang where IdBangKhachHang=@IdBangKhachHang; ";
		//strSql+="set @IdBangKhachHangVuaThem = (select @@IDENTITY);";
		//strSql+=@"Insert into BangChiTietTienNo(IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua) 
		//	values (@IdBangKhachHang,@ThoiGianThayDoiTienNo,@TienNoTruocKhiSua,@LyDoSuaTienNo,@SoTienSuaCuThe,@TienNoSauKhiSua);";
		SqlParameter TenKhachHangSua = new SqlParameter("@TenKhachHang",_strTenKhachHangSua);
		SqlParameter IdBangKhachHang = new SqlParameter("@IdBangKhachHang",intIdKhachHang);
		//SqlParameter ThoiGianThayDoiTienNo = new SqlParameter("@ThoiGianThayDoiTienNo",dtThoiGianThayDoi);
		//SqlParameter TienNoTruocKhiSua = new SqlParameter("@TienNoTruocKhiSua",decTienNoTruocKhiSua);
		//SqlParameter LyDoSuaTienNo = new SqlParameter("@LyDoSuaTienNo",strLyDoSuaTienNo);
		//SqlParameter SoTienSuaCuThe = new SqlParameter("@SoTienSuaCuThe",decSoTienSuaCuThe);
		//SqlParameter TienNoSauKhiSua = new SqlParameter("@TienNoSauKhiSua",decTienNoSauKhiSua);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] {
		  TenKhachHangSua,IdBangKhachHang }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}

	public string STR_CAPNHAT_TIENNO_KH(
	  ref string err,int intMaDonHang,decimal decTienNoHienTai,int intIdKhachHang,DateTime dtThoiGianThayDoi,decimal decTienNoTruocKhiSua,
	  string strLyDoSuaTienNo,decimal decSoTienSuaCuThe,decimal decTienNoSauKhiSua) {
	  try {
		//string strLyDoSuaTienNo="Thêm tên khách hàng lần đầu tiên";
		string strSql=@"update BangDanhSachDonHang set CapNhatTienNoChua=N'Đã cập nhật' where MaDonHang=@MaDonHang; ";
		strSql+="update BangKhachHang set TienNoHienTai=@TienNoHienTai where IdBangKhachHang=@IdBangKhachHang; ";
		strSql+=@"Insert into BangChiTietTienNo(IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua) 
			values (@IdBangKhachHang,@ThoiGianThayDoiTienNo,@TienNoTruocKhiSua,@LyDoSuaTienNo,@SoTienSuaCuThe,@TienNoSauKhiSua); ";
		SqlParameter MaDonHang=new SqlParameter("@MaDonHang",intMaDonHang);
		SqlParameter TienNoHienTai=new SqlParameter("@TienNoHienTai",decTienNoHienTai);
		SqlParameter IdBangKhachHang=new SqlParameter("@IdBangKhachHang",intIdKhachHang);
		SqlParameter ThoiGianThayDoiTienNo=new SqlParameter("@ThoiGianThayDoiTienNo",dtThoiGianThayDoi);
		SqlParameter TienNoTruocKhiSua=new SqlParameter("@TienNoTruocKhiSua",decTienNoTruocKhiSua);
		SqlParameter LyDoSuaTienNo=new SqlParameter("@LyDoSuaTienNo",strLyDoSuaTienNo);
		SqlParameter SoTienSuaCuThe=new SqlParameter("@SoTienSuaCuThe",decSoTienSuaCuThe);
		SqlParameter TienNoSauKhiSua=new SqlParameter("@TienNoSauKhiSua",decTienNoSauKhiSua);
		if(blnThucThiNonQuery(strSql,CommandType.Text,ref err,new SqlParameter[] { 
		  MaDonHang,TienNoHienTai,IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua }))
		  return "pass";
		else
		  return "false";
	  } catch { }
	  return "false";
	}
  }
}
