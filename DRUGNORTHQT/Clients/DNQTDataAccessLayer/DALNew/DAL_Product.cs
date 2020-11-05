using DNQTConstTable.ListTableDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

	public void GetDTIdNewByInsertNameProduct(ref DataTable dtOutput,ref Exception exOutput
	  ,string strName) {
	  try {
		string strQuery = "";
		_bllQuery.GetDTIdNewByInsertNameProduct(ref strQuery);

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  //string objTemp = dicInput["string.strIdProduct"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			(Table_BangViThuoc.Col_TenViThuoc.NAME,strName));
		}

		SqlParameter[] arrayTemp = new SqlParameter[lstTupleParameter.Count];
		for(int i = 0;i<lstTupleParameter.Count;i++) {
		  arrayTemp[i]=new SqlParameter("@"+lstTupleParameter[i].Item1,lstTupleParameter[i].Item2);
		}

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,arrayTemp);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

  }
}
