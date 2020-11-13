using System;
using System.Data.SqlClient;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Account:Connection {
	public void CheckConnectionDbFromConfig(ref bool blnSuccess) {
	  blnSuccess=false;

	  string strConnection = "";
	  GetStringConnectionDecodeFromConfig(ref strConnection);
	  CheckConnectionDbFromString(ref blnSuccess,strConnection);
	}

	public void CheckConnectionDbFromString(ref bool blnSuccess,string strConnection) {
	  blnSuccess=false;
	  try {
		using(SqlConnection connection = new SqlConnection(strConnection)) {
		  try {
			connection.Open();
			blnSuccess=true;
			return;
		  } catch(SqlException) {
			blnSuccess=false;
			return;
		  }
		}
	  } catch(Exception e) {
		string str = e.Message;
	  }
	}

  }
}
