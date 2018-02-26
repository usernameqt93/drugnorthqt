using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using QTCommon;

namespace BusinessLogic {
  public class BL_DonHang {
	private DAO_DonHang DAO_DONHANG=new DAO_DonHang();

	public bool boolDeleteBangChiTietDonHang(ref string err) {
	  return DAO_DONHANG.boolDeleteBangChiTietDonHang(ref err);
	}
	public bool boolDeleteBangChiTietDonHangTheoMaCTDH(ref string err,int intMaChiTietDonHang) {
	  return DAO_DONHANG.boolDeleteBangChiTietDonHangTheoMaCTDH(ref err,intMaChiTietDonHang);
	}
	public bool boolDELETE_BANG_DSDH_THEOID(ref string err,int intMaDonHang) {
	  return DAO_DONHANG.boolDELETE_BANG_DSDH_THEOID(ref err,intMaDonHang);
	}
	public DataTable dataTableBangDanhSachDonHang(string strDieuKien,int intIdBangKhachHang) {
	  DataTable dt=new DataTable();
	  if(strDieuKien.Equals("TatCa")&&intIdBangKhachHang==-1)
		dt=DAO_DONHANG.dataTableBangDanhSachDonHangCoTenKH();
	  if(strDieuKien.Equals("TheoIdBangKhachHang"))
		dt=DAO_DONHANG.dataTableBangDanhSachDHTheoIdKH(intIdBangKhachHang);
	 // dt.Columns.Add("STT");
	 // for(int i=0;i<dt.Rows.Count;i++)
		//dt.Rows[i]["STT"]=i+1;
	  QTLibraryFunction.VOID_ADD_STT_COL_TO_DATATABLE(ref dt);
	  return dt;
	}
	public DataTable dataTable_DANHSACH_DH_THEONGAY(DateTime dtThoiGianTimKiem) {
	  DataTable dt=DAO_DONHANG.dataTableBANG_DANHSACH_DH_THEONGAY(dtThoiGianTimKiem);
	 // dt.Columns.Add("STT");
	 // for(int i=0;i<dt.Rows.Count;i++)
		//dt.Rows[i]["STT"]=i+1;
	  QTLibraryFunction.VOID_ADD_STT_COL_TO_DATATABLE(ref dt);
	  return dt;
	}
	public int intTongDonHangTrongDanhSach(ref string strLoi) {
	  int kq=0;
	  try {
		DataTable dt=DAO_DONHANG.dataTableBangDanhSachDonHang();
		int temp=dt.Rows.Count;
		if(temp>0)
		  kq=temp;
	  } catch(Exception e) { strLoi=e.Message; }
	  return kq;
	}
	public DataTable dataTableBangDanhSachViThuocCungGia() {
	  return DAO_DONHANG.dataTableBangDanhSachViThuocCungGia();
	}
	public string STR_CAPNHAT_TIENNO_DH_CHUA(int intMaDonHang) {
	  DataTable dt=DAO_DONHANG.dataTableBangDonHangTheoId(intMaDonHang);
	  string kq=Convert.ToString(dt.Rows[0]["CapNhatTienNoChua"].ToString());
	  return kq;
	}
	public DataTable dataTableBangDanhSachViThuocXepTheoTenThuoc() {
	  return DAO_DONHANG.dataTableBangDanhSachViThuocXepTheoTenThuoc();
	}
	public DataTable dataTableBANG_DS_VITHUOC_DACO_DH() {
	  return DAO_DONHANG.dataTableBANG_DS_VITHUOC_DACO_DH();
	}
	public DataTable dataTableBANG_DS_VITHUOC_THEO_TENKH(string strTenKhachHang) {
	  return DAO_DONHANG.dataTableBANG_DS_VITHUOC_THEO_TENKH(strTenKhachHang);
	}
	public DataTable dataTableBANG_LICHSU_GD_VT(string strTenViThuoc) {
	  DataTable dt=DAO_DONHANG.dataTableBANG_LICHSU_GD_VT(strTenViThuoc);
	  dt.Columns.Add("STT");
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i]["STT"]=i+1;
	  return dt;
	}
	public DataTable dataTableBANG_LICHSU_CO_CACKITU(string strKiTu) {
	  DataTable dt=DAO_DONHANG.dataTableBANG_LICHSU_CO_CACKITU(strKiTu);
	  dt.Columns.Add("STT");
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i]["STT"]=i+1;
	  return dt;
	}
	public DataTable dataTableBANG_LICHSU_GD_VT(string strTenViThuoc,string strTenKhachHang) {
	  DataTable dt=DAO_DONHANG.dataTableBANG_LICHSU_GD_VT(strTenViThuoc,strTenKhachHang);
	  dt.Columns.Add("STT");
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i]["STT"]=i+1;
	  return dt;
	}
	public DataTable dataTableBangChiTietDonHang() {
	  return DAO_DONHANG.dataTableBangChiTietDonHang();
	}
	public DataTable dataTableBangChiTietDonHangTheoMaDonHang(int intMaDonHang) {
	  //return DAO_DONHANG.dataTableBangChiTietDonHangTheoMaDonHang(intMaDonHang);
	  return DAO_DONHANG.dataTableBangChiTietDHMaGiaMaDH(intMaDonHang);
	}
	public DataTable dataTableBangChiTietDonHangTheoMaDonHangCoSTT(int intMaDonHang) {
	  DataTable dtChiTietDonHang=new DataTable();
	  //dtChiTietDonHang=DAO_DONHANG.dataTableBangChiTietDonHangTheoMaDonHang(intMaDonHang);
	  dtChiTietDonHang=DAO_DONHANG.dataTableBangChiTietDHMaGiaMaDH(intMaDonHang);
	  dtChiTietDonHang.Columns.Add("STT");
	  for(int i=0;i<dtChiTietDonHang.Rows.Count;i++)
		dtChiTietDonHang.Rows[i]["STT"]=i+1;

	  return dtChiTietDonHang;
	}

	public bool boolCoMaViThuocNayTrongChiTietDHKo(ref string err,ref string result,int intMaViThuoc) {
	  bool kq=false;
	  try {
		object objTemp=DAO_DONHANG.objCoBaoNhieuMaViThuocNayTrongChiTietDH(ref err,ref result,intMaViThuoc);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=true;
	  } catch { }
	  return kq;
	}
	public int intCoBaoNhieuMaViThuocTrongMaDonHang(ref string err,ref string result,int intMaViThuoc,int intMaDonHang) {
	  int kq=-1;
	  try {
		object objTemp=DAO_DONHANG.objCoBaoNhieuMaViThuocTrongMaDonHang(ref err,ref result,intMaViThuoc,intMaDonHang);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}
	public int intMaViThuocCuaTenViThuocNay(ref string err,ref string result,string strTenViThuoc) {
	  int kq=-1;
	  try {
		object objTemp=DAO_DONHANG.objMaViThuocCuaTenViThuocNay(ref err,ref result,strTenViThuoc);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}

	public int intCoBaoNhieuTenViThuocTrongMaDonHang(ref string err,ref string result,string strTenViThuoc,int intMaDonHang) {
	  int kq=-1;
	  try {
		object objTemp=DAO_DONHANG.objCoBaoNhieuTenViThuocTrongMaDonHang(ref err,ref result,strTenViThuoc,intMaDonHang);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}
	public int intMaChiTietDHCuaTenViThuoc(ref string err,ref string result,string strTenViThuoc,int intMaDonHang) {
	  int kq=-1;
	  try {
		object objTemp=DAO_DONHANG.objMaChiTietDHCuaTenViThuoc(ref err,ref result,strTenViThuoc,intMaDonHang);
		int intTemp=Convert.ToInt32(objTemp);
		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}

	public string strInsertBangChiTietDonHang(ref string err,int intMaViThuoc,decimal decSoLuong,decimal decThanhTien) {
	  return DAO_DONHANG.strInsertBangChiTietDonHang(ref err,intMaViThuoc,decSoLuong,decThanhTien);
	}
	public string strInsertBangChiTietDonHangCoMaDonHang(ref string err,int intMaViThuoc,decimal decSoLuong,decimal decThanhTien,int intMaDonHang) {
	  return DAO_DONHANG.strInsertBangChiTietDonHangCoMaDonHang(ref err,intMaViThuoc,decSoLuong,decThanhTien,intMaDonHang);
	}
	public string strThemThongTinViThuocVaoDB(ref string err,string strTenViThuoc,decimal decDonGia,decimal decSoLuong,int intMaDonHang) {
	  decimal decThanhTien=0;
	  decThanhTien=decDonGia*decSoLuong;
	  DateTime dateBayGio=DateTime.Now;
	  return DAO_DONHANG.strThemThongTinViThuocVaoDB(ref err,strTenViThuoc,decDonGia,dateBayGio,decSoLuong,decThanhTien,intMaDonHang);
	}
	public string strThemViThuocDaCoVaoDonHang(ref string err,int intMaViThuoc,decimal decDonGia,decimal decSoLuong,int intMaDonHang) {
	  decimal decThanhTien=0;
	  decThanhTien=decDonGia*decSoLuong;
	  DateTime dateBayGio=DateTime.Now;
	  return DAO_DONHANG.strThemViThuocDaCoVaoDonHang(ref err,intMaViThuoc,decDonGia,dateBayGio,decSoLuong,decThanhTien,intMaDonHang);
	}

	public string strCapNhatGiaCaViThuocVaoDH(ref string err,int intMaChiTietDonHang,decimal decDonGia,decimal decSoLuong) {
	  decimal decThanhTien=0;
	  decThanhTien=decDonGia*decSoLuong;
	  DateTime dateBayGio=DateTime.Now;
	  return DAO_DONHANG.strCapNhatGiaCaViThuocVaoDH(ref err,intMaChiTietDonHang,decDonGia,dateBayGio,decSoLuong,decThanhTien);
	}

	public decimal decTongTienDonHang(ref string err,ref string result) {
	  decimal kq=0;
	  try {
		object objTemp=DAO_DONHANG.objTongTienDonHang(ref err,ref result);
		decimal decTemp=Convert.ToDecimal(objTemp);

		if(decTemp>0)
		  kq=decTemp;
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return kq;
	}
	public decimal decTongTienDonHangTheoMaDonHang(ref string err,ref string result,int intMaDonHang) {
	  decimal kq=0;
	  try {
		object objTemp=DAO_DONHANG.objTongTienDonHangTheoMaDonHang(ref err,ref result,intMaDonHang);
		decimal decTemp=Convert.ToDecimal(objTemp);

		if(decTemp>0)
		  kq=decTemp;
	  } catch { }
	  return kq;
	}
	public void voidLayThongTinCaDonHang(ref int intTongViThuoc,ref  decimal decTongKhoiLuong,ref decimal decTongTienDonHang,int intMaDonHang) {
	  DataTable dtBangThongTinDH=DAO_DONHANG.dataTableBangThongTinDH(intMaDonHang);
	  intTongViThuoc=Convert.ToInt32(dtBangThongTinDH.Rows[0]["TongViThuoc"].ToString());
	  if(intTongViThuoc>0) {
		decTongKhoiLuong=Convert.ToDecimal(dtBangThongTinDH.Rows[0]["TongKhoiLuong"].ToString());
		decTongTienDonHang=Convert.ToDecimal(dtBangThongTinDH.Rows[0]["TongTienDonHang"].ToString());
	  }
	  if(intTongViThuoc==0) {
		decTongKhoiLuong=0;
		decTongTienDonHang=0;
	  }
	}

	public int intMaDonHangVuaThem(ref string err,ref string result) {
	  int kq=0;
	  try {
		object objTemp=DAO_DONHANG.objMaDonHangVuaThem(ref err,ref result);
		int intTemp=Convert.ToInt32(objTemp);

		if(intTemp>0)
		  kq=intTemp;
	  } catch {
		//log.Error("Loi Q201611100920T phuong thuc dataTableBangSMSNhanDichVuConfig: "+ex.Message);
	  }
	  return kq;
	}
	public int intMaDonHangVuaThemCoThoiGianVietDH(ref string err,ref string result,DateTime dtThoiGianVietDonHang) {
	  int kq=0;
	  try {
		object objTemp=DAO_DONHANG.objMaDonHangVuaThemCoThoiGianVietDH(ref err,ref result,dtThoiGianVietDonHang);
		int intTemp=Convert.ToInt32(objTemp);

		if(intTemp>0)
		  kq=intTemp;
	  } catch { }
	  return kq;
	}

	public bool boolUpdateTongGiaTriDonHangTheoMaDH(ref string err,int intTongViThuoc,decimal decTongKhoiLuong,decimal decTongGiaTriDonHang,int intMaDonHang) {
	  return DAO_DONHANG.boolUpdateTongGiaTriDonHangTheoMaDH(ref err,intTongViThuoc,decTongKhoiLuong,decTongGiaTriDonHang,intMaDonHang);
	}
	public bool boolUPDATE_IDKH_VAO_DH(ref string err,int intIdBangKH,int intMaDonHang) {
	  return DAO_DONHANG.boolUPDATE_IDKH_VAO_DH(ref err,intIdBangKH,intMaDonHang);
	}
	public bool boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref string err,int intIdBangKH,string strSDTKH,decimal decTienNoCu,int intMaDonHang) {
	  return DAO_DONHANG.boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref err,intIdBangKH,strSDTKH,decTienNoCu,intMaDonHang);
	}
  }
}
