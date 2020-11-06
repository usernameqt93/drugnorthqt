using System;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Customer:Connection {
	public void GetDTAllIdCustomer(ref DataTable dtOutput,ref Exception exOutput) {
	  try {
		string strQuery = @"select IdBangKhachHang,TenKhachHang,TienNoHienTai"
+" from BangKhachHang order by TenKhachHang";
		//_bllQuery.GetQueryLayAllIdProduct(ref strQuery);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}
  }
}
