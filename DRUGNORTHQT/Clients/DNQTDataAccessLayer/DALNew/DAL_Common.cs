using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DNQTDataAccessLayer.DALNew {
  class DAL_Common:Connection {

	internal void ExcuteQueryWithListTupleParameter(ref string strError,ref bool blnResult,string strQuery
	  ,List<Tuple<string,object>> lstTupleParameter) {
	  SqlParameter[] arrayTemp = new SqlParameter[lstTupleParameter.Count];
	  for(int i = 0;i<lstTupleParameter.Count;i++) {
		arrayTemp[i]=new SqlParameter("@"+lstTupleParameter[i].Item1,lstTupleParameter[i].Item2);
	  }

	  if(blnThucThiNonQuery(strQuery,CommandType.Text,ref strError,arrayTemp)) {
		blnResult=true;
	  }
	}

  }
}
