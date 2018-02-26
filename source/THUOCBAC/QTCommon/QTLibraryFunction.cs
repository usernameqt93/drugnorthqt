using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCommon {
  public static class QTLibraryFunction {

	public static string GetValue(string str) {
	  return "'"+str+"'";
	}

	public static void VOID_ADD_STT_COL_TO_DATATABLE(ref DataTable _dt) {
	  _dt.Columns.Add("STT");
	  for(int i = 0;i<_dt.Rows.Count;i++)
		_dt.Rows[i]["STT"]=i+1;
	}
  }
}
