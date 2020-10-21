using System;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Product:Connection {

	private readonly BLLQuery _bllQuery = new BLLQuery();

	public void GetDTAllIdProduct(ref DataTable dtOutput,ref Exception exDAL) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayAllIdProduct(ref strQuery);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exDAL=ex;
	  }
	}
  }
}
