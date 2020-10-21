using System;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Order:Connection {

	private readonly BLLQuery _bllQuery = new BLLQuery();

	public void GetDTAllIdOrder(ref DataTable dtOutput,ref Exception exDAL) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayAllIdOrder(ref strQuery);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exDAL=ex;
	  }
	}
  }
}
