using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;

namespace BusinessLogic {
  public class BL_GiaViThuoc {
	private DAO_GiaViThuoc data=new DAO_GiaViThuoc();

	public bool boolUpdateGiaViThuoc(ref string err,
	  decimal decimalGiaViThuoc,string strDonViTinh,int intMaGiaThuoc) {
		return data.boolUpdateGiaViThuoc(ref err,decimalGiaViThuoc,strDonViTinh,intMaGiaThuoc);
	}
	public bool boolUpdateViThuoc(ref string err,string strTenViThuoc,int intMaViThuoc) {
	  return data.boolUpdateViThuoc(ref err,strTenViThuoc,intMaViThuoc);
	}
  }
}
