using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using QTCommon;

namespace BusinessLogic {
  public class BL_DonXacNhan {
	private DAO_DonXacNhan DAO_DONXACNHAN=new DAO_DonXacNhan();

	public DataTable dataTableBangDanhSachViThuocXepTheoTenThuoc() {
	  return DAO_DONXACNHAN.dataTableBangDanhSachViThuocXepTheoTenThuoc();
	}
	public int intMaDonXacNhanVuaThemCoThoiGianViet(ref string err,ref string result,DateTime dtThoiGianVietDonXacNhan) {
	  int kq=0;
	  try {
		object objTemp=DAO_DONXACNHAN.objMaDonXacNhanVuaThemCoThoiGianViet(ref err,ref result,dtThoiGianVietDonXacNhan);
		int intTemp=Convert.ToInt32(objTemp);

		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}
	public DataTable dataTableBangChiTietDonXacNhanDeIn(int intMaDonXacNhan) {
	  return DAO_DONXACNHAN.dataTableBangChiTietDonXacNhanTheoMaDonXacNhan(intMaDonXacNhan);
	}
	public DataTable dataTableBangChiTietDonXacNhanTheoMaDonXacNhanCoSTT(int intMaDonXacNhan) {
	  DataTable dtChiTietDonXacNhan=new DataTable();
	  dtChiTietDonXacNhan=DAO_DONXACNHAN.dataTableBangChiTietDonXacNhanTheoMaDonXacNhan(intMaDonXacNhan);
	  dtChiTietDonXacNhan.Columns.Add(QTStringConst.SO_THUTU.STR);
	  for(int i=0;i<dtChiTietDonXacNhan.Rows.Count;i++)
		dtChiTietDonXacNhan.Rows[i][QTStringConst.SO_THUTU.STR]=i+1;
	  return dtChiTietDonXacNhan;
	}
	public int intCoBaoNhieuMaViThuocTrongMaDonXacNhan(ref string err,ref string result,int intMaViThuoc,int intMaDonXacNhan) {
	  int kq=-1;
	  try {
		object objTemp=DAO_DONXACNHAN.objCoBaoNhieuMaViThuocTrongMaDonXacNhan(ref err,ref result,intMaViThuoc,intMaDonXacNhan);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}
	public string strInsertBangChiTietDonHangCoMaDonHang(ref string err,int intMaViThuoc,int intMaDonXacNhan) {
	  return DAO_DONXACNHAN.strInsertBangChiTietDonXacNhanCoMaDonXacNhan(ref err,intMaViThuoc,intMaDonXacNhan);
	}
	public DataTable dataTableBangDanhSachDonXacNhan() {
	  return DAO_DONXACNHAN.dataTableBangDanhSachDonXacNhan();
	}
	public void voidLAY_TONG_VITHUOC_TRONG_DONXN(ref int intTongViThuoc,int intMaDonXacNhan) {
	  DataTable dtBangTongViThuoc=DAO_DONXACNHAN.dataTableBangSoViThuocDonXN(intMaDonXacNhan);
	  intTongViThuoc=Convert.ToInt32(dtBangTongViThuoc.Rows[0]["TongViThuoc"].ToString());
	}
	public void voidLAY_THONGTIN_NGUOIVIET(ref string strHoTen,ref string strSoCMTND,ref DateTime dtNgaySinh,ref string strHoKhauThuongTru,int intMaDonXacNhan) {
	  DataTable dtBangThongTinNguoiDung=DAO_DONXACNHAN.dataTableBANG_THONGTIN_NGUOIDUNG(intMaDonXacNhan);
	  string temp="";
	  temp=Convert.ToString(dtBangThongTinNguoiDung.Rows[0]["TenNguoiViet"].ToString());
	  strHoTen=(temp.Equals(""))?"Nguyễn Văn A":temp;
	  temp=Convert.ToString(dtBangThongTinNguoiDung.Rows[0]["SoCMTND"].ToString());
	  strSoCMTND=(temp.Equals(""))?"000111222333":temp;
	  dtNgaySinh=(temp.Equals(""))?(new DateTime(1974,10,20,0,0,0)):Convert.ToDateTime(dtBangThongTinNguoiDung.Rows[0]["NgaySinh"].ToString());
	  //dtNgaySinh=Convert.ToDateTime(dtBangThongTinNguoiDung.Rows[0]["NgaySinh"].ToString());

	  temp=Convert.ToString(dtBangThongTinNguoiDung.Rows[0]["HoKhauThuongTru"].ToString());
	  strHoKhauThuongTru=(temp.Equals(""))?"Hộ khẩu thường trú của bạn":temp;
	}
	public bool boolUPDATE_THONGTIN_DONXN(
	  ref string err,string strTenNguoiViet,string strSoCMTND,DateTime dtNgaySinh,string strHoKhau,int intTongViThuoc,int intMaDonXacNhan) {
		return DAO_DONXACNHAN.boolUPDATE_THONGTIN_DONXN(ref err,strTenNguoiViet,strSoCMTND,dtNgaySinh,strHoKhau,intTongViThuoc,intMaDonXacNhan);
	}
  }
}
