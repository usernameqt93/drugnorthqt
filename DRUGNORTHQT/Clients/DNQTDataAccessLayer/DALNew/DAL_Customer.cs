using System;
using System.Collections.Generic;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Customer:Connection {

	private readonly BLLClass _bllClass = new BLLClass();

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

	public void GetDTDetailTienNoByListIdKH(ref DataTable dtOutput,ref Exception exOutput
	  ,List<string> lstStringId) {
	  try {
		//_bllQuery.GetQueryLayDetailOrderByListId(ref strQuery,lstStringId);
		string strSql = @" select IdBangKhachHang,ThoiGianThayDoiTienNo,LyDoSuaTienNo,TienNoTruocKhiSua,SoTienSuaCuThe,TienNoSauKhiSua"
+" from BangChiTietTienNo ";

		string strListId = "";
		_bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

		string strWhere = $" IdBangKhachHang IN ({strListId}) ";

		string strQuery = strSql+$" \nWHERE {strWhere}";

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}
  }
}
