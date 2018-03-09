using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using QTCommon;

namespace BusinessLogic {
  public class BL_KhachHang {

	private DAO_KhachHang DAO_KHACHHANG=new DAO_KhachHang();

	public DataTable DATATABLE_BANG_KHACHHANG_XEPTHEOTEN() {
	  return DAO_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	}
	public DataTable DATATABLE_DANHSACH_KHACHHANG() {
	  DataTable dt=new DataTable();
	  dt=DAO_KHACHHANG.DATATABLE_DANHSACH_KHACHHANG();
	  dt.Columns.Add(QTStringConst.SO_THUTU.STR);
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i][QTStringConst.SO_THUTU.STR]=i+1;
	  return dt;
	}
	public DataTable DATATABLE_LICHSU_TIENNO_THEO_IDKH(int intIdKhachHang) {
	  return DAO_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(intIdKhachHang);
	}
	public string STR_INSERT_BANGKHACHHANG(ref string err,string strTenKhachHang) {
	  return DAO_KHACHHANG.STR_INSERT_BANGKHACHHANG(ref err,strTenKhachHang);
	}
	public string STR_INSERT_KHACHHANG_LANDAU(ref string err,string strTenKhachHang) {
	  return DAO_KHACHHANG.STR_INSERT_KHACHHANG_LANDAU(ref err,strTenKhachHang);
	}
	public decimal DEC_TIENNO_HIENTAI_KH(int intIdKhachHang) {
	  decimal kq=0;
	  try {
		DataTable dt=DAO_KHACHHANG.DATATABLE_KHACHHANG_THEO_ID(intIdKhachHang);
		//int intTemp=Convert.ToInt32(dt.Rows[0]["TienNoHienTai"].ToString());
		string strTemp=dt.Rows[0]["TienNoHienTai"].ToString();
		if(!strTemp.Equals(""))
		  kq=Convert.ToDecimal(strTemp);
		//kq=Convert.ToDecimal(dt.Rows[0]["TienNoHienTai"].ToString());
	  } catch { }
	  return kq;
	}
	public string STR_CAPNHAT_TIENNO_KH(
	  ref string err,int intMaDonHang,decimal decTienNoHienTai,int intIdKhachHang,string strLyDoSuaTienNo,decimal decSoTienSuaCuThe) {
	  DateTime dtThoiGianThayDoi=DateTime.Now;
	  return DAO_KHACHHANG.STR_CAPNHAT_TIENNO_KH(ref err,intMaDonHang,(decTienNoHienTai+decSoTienSuaCuThe),intIdKhachHang,
		dtThoiGianThayDoi,decTienNoHienTai,strLyDoSuaTienNo,decSoTienSuaCuThe,(decTienNoHienTai+decSoTienSuaCuThe));
	}
	public string STR_SUA_TIENNO_KH(ref string err,decimal decTienNoHienTai,int intIdKhachHang,decimal decSoTienSuaCuThe,string strLyDoSuaTienNo) {
	  DateTime dtThoiGianThayDoi=DateTime.Now;
	  //string strLyDoSuaTienNo="Thay đổi tiền nợ";
	  return DAO_KHACHHANG.STR_SUA_TIENNO_KH(ref err,decSoTienSuaCuThe,intIdKhachHang,
		dtThoiGianThayDoi,decTienNoHienTai,strLyDoSuaTienNo,decSoTienSuaCuThe,decSoTienSuaCuThe);
	}

	public string STR_SUA_TEN_KHACHHANG(ref string err,string _strTenKhachHangSua,int intIdKhachHang) {
	  //DateTime dtThoiGianThayDoi = DateTime.Now;
	  //string strLyDoSuaTienNo="Thay đổi tiền nợ";
	  return DAO_KHACHHANG.STR_SUA_TEN_KHACHHANG(ref err,_strTenKhachHangSua,intIdKhachHang);
	}

	public string STR_DATRA_TIENNO_KH(ref string err,decimal decTienNoHienTaiForm,int intIdKhachHangForm,decimal decSoTienSuaCuTheForm,string strLyDoSuaTienNoForm) {
	  DateTime dtThoiGianThayDoi=DateTime.Now;
	  //string strLyDoSuaTienNo="Thay đổi tiền nợ";
	  decimal decTienNoHienTaiSauKhiThayDoi=decTienNoHienTaiForm-decSoTienSuaCuTheForm;
	  int intIdKhachHang=intIdKhachHangForm;
	  decimal decTienNoTruocKhiSua=decTienNoHienTaiForm;
	  string strLyDoSuaTienNo=strLyDoSuaTienNoForm;
	  decimal decSoTienSuaCuThe=decSoTienSuaCuTheForm;
	  decimal decTienNoSauKhiSua=decTienNoHienTaiForm-decSoTienSuaCuTheForm;
	  return DAO_KHACHHANG.STR_SUA_TIENNO_KH(ref err,decTienNoHienTaiSauKhiThayDoi,intIdKhachHang,dtThoiGianThayDoi,decTienNoTruocKhiSua,
	  strLyDoSuaTienNo,decSoTienSuaCuThe,decTienNoSauKhiSua);
	}
	public string STR_VAYTHEM_TIENNO_KH(ref string err,decimal decTienNoHienTaiForm,int intIdKhachHangForm,decimal decSoTienSuaCuTheForm,string strLyDoSuaTienNoForm) {
	  DateTime dtThoiGianThayDoi=DateTime.Now;
	  //string strLyDoSuaTienNo="Thay đổi tiền nợ";
	  decimal decTienNoHienTaiSauKhiThayDoi=decTienNoHienTaiForm+decSoTienSuaCuTheForm;
	  int intIdKhachHang=intIdKhachHangForm;
	  decimal decTienNoTruocKhiSua=decTienNoHienTaiForm;
	  string strLyDoSuaTienNo=strLyDoSuaTienNoForm;
	  decimal decSoTienSuaCuThe=decSoTienSuaCuTheForm;
	  decimal decTienNoSauKhiSua=decTienNoHienTaiForm+decSoTienSuaCuTheForm;
	  return DAO_KHACHHANG.STR_SUA_TIENNO_KH(ref err,decTienNoHienTaiSauKhiThayDoi,intIdKhachHang,dtThoiGianThayDoi,decTienNoTruocKhiSua,
	  strLyDoSuaTienNo,decSoTienSuaCuThe,decTienNoSauKhiSua);
	}
  }
}
