using System;
using System.Collections.Generic;
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

	public void GetDTOrderByListId(ref DataTable dtOutput,ref Exception exDAL,List<string> lstStringId) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayOrderByListId(ref strQuery,lstStringId);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exDAL=ex;
	  }
	}

	public void GetDTDetailOrderByListIdOrder(ref DataTable dtOutput,ref Exception exDAL,List<string> lstStringId) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayDetailOrderByListId(ref strQuery,lstStringId);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exDAL=ex;
	  }
	}

  }
}
