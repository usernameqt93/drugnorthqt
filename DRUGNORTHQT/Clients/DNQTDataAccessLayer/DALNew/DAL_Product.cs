using System;
using System.Collections.Generic;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Product:Connection {

	private readonly BLLQuery _bllQuery = new BLLQuery();

	public void GetDTAllIdProduct(ref DataTable dtOutput,ref Exception exOutput) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayAllIdProduct(ref strQuery);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDTListOrderByListIdProduct(ref DataTable dtOutput,ref Exception exOutput
	  ,List<string> lstStringId) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayListOrderByListId(ref strQuery,lstStringId);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDTListDonGiaByListIdProduct(ref DataTable dtOutput,ref Exception exOutput
	  ,List<string> lstStringId) {
	  try {
		string strQuery = "";
		_bllQuery.GetQueryLayListDonGiaByListId(ref strQuery,lstStringId);

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

  }
}
