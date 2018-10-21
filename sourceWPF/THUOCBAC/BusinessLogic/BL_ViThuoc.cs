using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;

namespace BusinessLogic {
  
  public class BL_ViThuoc {
	private DAO_ViThuoc DAO_VITHUOC=new DAO_ViThuoc();

	public string strInsertViThuocVaGia(ref string err,string strTenViThuoc,decimal decGiaViThuoc,
	  string strDonViTinh,string strGhiChuViThuoc) {
		return DAO_VITHUOC.strInsertViThuocVaGia(ref err,strTenViThuoc,decGiaViThuoc,strDonViTinh,strGhiChuViThuoc);
	}
	public string strINSERT_VITHUOC_DAUTIEN(ref string err) {
	  string strTenViThuoc="Cam thảo";
	  decimal decGiaViThuoc=100000;
	  string strDonViTinh="Kg";
	  DateTime dtThoiGianCoGiaNay=DateTime.Now;
	  return DAO_VITHUOC.strINSERT_VITHUOC_DAUTIEN(ref err,strTenViThuoc,decGiaViThuoc,strDonViTinh,dtThoiGianCoGiaNay);
	}
	public string strInsertBangViThuoc(ref string err,string strTenViThuoc,string strGhiChuViThuoc) {
	  return DAO_VITHUOC.strInsertBangViThuoc(ref err,strTenViThuoc,strGhiChuViThuoc);
	}

	public DataTable dataTableBangDanhSachViThuoc() {
	  return DAO_VITHUOC.dataTableBangDanhSachViThuoc();
	}

	public DataTable dataTableBangDanhSachViThuocCungGia() {
	  DataTable dt=DAO_VITHUOC.dataTableBangDanhSachViThuocCungGiaCa();
	  return dt;
	}
	public DataTable dataTableBangDanhSachViThuocCungGiaCoSTT() {
	  DataTable dt=DAO_VITHUOC.dataTableBangDanhSachViThuocCungGiaCa();
	  dt.Columns.Add("STT");
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i]["STT"]=i+1;
	  return dt;
	}
	public DataTable dataTableBangDanhSachViThuocCungGiaCaTheoChuCai() {
	  DataTable dt=DAO_VITHUOC.dataTableBangDanhSachViThuocCungGiaCaTheoChuCai();
	  dt.Columns.Add("STT");
	  for(int i=0;i<dt.Rows.Count;i++)
		dt.Rows[i]["STT"]=i+1;
	  return dt;
	}
	public int intTongSoViThuocTrongDanhSach(ref string strLoi) {
	  int kq=0;
	  try {
		DataTable dt=DAO_VITHUOC.dataTableBangDanhSachViThuocCungGiaCaTheoChuCai();
		int temp=dt.Rows.Count;
		if(temp>0)
		  kq=temp;
	  } catch(Exception e) { strLoi=e.Message; }
	  return kq;
	}
	public bool boolDeleteViThuocTheoIdViThuoc(ref string err,string strIdViThuoc) {
	  bool boolCoXoaDuocKo=DAO_VITHUOC.boolDeleteViThuocTheoIdViThuoc(ref err,strIdViThuoc);
	  if(err.Equals("2"))
		return true;
	  return DAO_VITHUOC.boolDeleteViThuocTheoIdViThuoc(ref err,strIdViThuoc);
	}
  }
}
