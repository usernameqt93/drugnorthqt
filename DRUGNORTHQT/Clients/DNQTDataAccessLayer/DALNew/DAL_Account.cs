using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Account:Connection {

	private readonly DAL_Common DALCommon = new DAL_Common();
	private readonly BLLClass _bllClass = new BLLClass();

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

	public void AddAccount(ref Dictionary<string,object> dicOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		strQuery+="\n"+@"Insert into BangAccount"
+"(Username,Password,CreateTime,ModifyTime) "
+" values (@Username,@Password,@CreateTime,@ModifyTime);";

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  string objTemp = dicInput["string.strUserName"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Username",objTemp));
		}
		{
		  string objTemp = dicInput["string.strPassword"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Password",objTemp));
		}
		lstTupleParameter.Add(new Tuple<string,object>
		  ("CreateTime",DateTime.Now));
		lstTupleParameter.Add(new Tuple<string,object>
		  ("ModifyTime",DateTime.Now));

		bool blnResult = false;
		string strError = "";
		DALCommon.ExcuteQueryWithListTupleParameter(ref strError,ref blnResult,strQuery,lstTupleParameter);
		if(blnResult==false&&strError!="1") {
		  dicOutput["string"]=strError;
		}
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDTAccountByListName(ref DataTable dtOutput
	  ,ref Exception exOutput,List<string> lstString) {
	  try {
		string strSql = @" select Id,Username,IsDeleted"
+" from BangAccount ";

		string strListId = "";
		_bllClass.GetStringJoinSplitCharNotDot(ref strListId,lstString,",","","'");

		string strWhere = $" Username IN ({strListId}) ";

		string strQuery = strSql+$" \nWHERE {strWhere}";

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void AddGiaHanIdAccount(ref Dictionary<string,object> dicOutput
	  ,ref Exception exOutput,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		strQuery+="\n"+@"Insert into BangGiaHan"
+"(IdAccount,StartTimeUse,EndTimeUse,CreateTime,JsonKeyGiaHanGiaiMa,KeyGiaHanMaHoa) "
+" values (@IdAccount,@StartTimeUse,@EndTimeUse,@CreateTime,@JsonKeyGiaHanGiaiMa,@KeyGiaHanMaHoa);";

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  string objTemp = dicInput["string.strIdAccount"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("IdAccount",objTemp));
		}
		{
		  DateTime objTemp = (DateTime)dicInput["DateTime.dtpStart"];
		  lstTupleParameter.Add(new Tuple<string,object>
			("StartTimeUse",objTemp));
		}
		{
		  DateTime objTemp = (DateTime)dicInput["DateTime.dtpEnd"];
		  lstTupleParameter.Add(new Tuple<string,object>
			("EndTimeUse",objTemp));
		}
		lstTupleParameter.Add(new Tuple<string,object>
		  ("CreateTime",DateTime.Now));
		{
		  string objTemp = dicInput["string.strJsonDictionary"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("JsonKeyGiaHanGiaiMa",objTemp));
		}
		{
		  string objTemp = dicInput["string.strMaGiaHan"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("KeyGiaHanMaHoa",objTemp));
		}

		bool blnResult = false;
		string strError = "";
		DALCommon.ExcuteQueryWithListTupleParameter(ref strError,ref blnResult,strQuery,lstTupleParameter);
		if(blnResult==false&&strError!="1") {
		  dicOutput["string"]=strError;
		}
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDtAccountGiaHanByUserPass(ref DataTable dtOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		strQuery+="\n"+@"SELECT BangAccount.Id,BangAccount.Username,BangAccount.IsDeleted "
+" ,BangGiaHan.StartTimeUse,BangGiaHan.EndTimeUse "
+" FROM BangAccount BangAccount LEFT JOIN BangGiaHan BangGiaHan "
+" ON BangGiaHan.IdAccount=BangAccount.Id "
+" WHERE BangAccount.Username=@Username AND BangAccount.Password=@Password;";

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  string objTemp = dicInput["string.strUserName"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Username",objTemp));
		}
		{
		  string objTemp = dicInput["string.strPassword"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Password",objTemp));
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

	public void UpdatePasswordAccount(ref Dictionary<string,object> dicOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		strQuery+="\n"+@"UPDATE BangAccount "
+" SET Password=@Password,ModifyTime=@ModifyTime "
+" WHERE Id=@Id AND Username=@Username;";

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  string objTemp = dicInput["string.strPassword"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Password",objTemp));
		}
		lstTupleParameter.Add(new Tuple<string,object>
		  ("ModifyTime",DateTime.Now));
		{
		  string objTemp = dicInput["string.strId"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Id",objTemp));
		}
		{
		  string objTemp = dicInput["string.strUserName"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			("Username",objTemp));
		}

		bool blnResult = false;
		string strError = "";
		DALCommon.ExcuteQueryWithListTupleParameter(ref strError,ref blnResult,strQuery,lstTupleParameter);
		if(blnResult==false&&strError!="1") {
		  dicOutput["string"]=strError;
		}
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

  }
}
