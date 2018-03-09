using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
  public class Connection {
	public SqlConnection con;
	public SqlCommand cmd;
	public SqlDataAdapter dap;
	public DataSet dt;
	public DataTable dataTableBangDuLieu;
	public static string strcon="";
	public Connection() {
	  //strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CTSDBConnection"].ConnectionString;
	  //strcon = "Data Source=qt;" + "Initial Catalog=SmsGateway159;" + "User id=sa;" + "Password=1234$;";
	  //static string strConStr = ConfigurationManager.ConnectionStrings["ConnetionAutoCare"].ConnectionString;
	  //public static string strKetNoiCoSoDuLieu = "Data Source=qt;" + "Initial Catalog=Autocare2;" + "User id=sa;" + "Password=1234$;";
	  //public static string strKetNoiCoSoDuLieu = "Data Source=115.84.178.37;" + "Initial Catalog=Autocare_Dev;" + "User id=autocaredev;" + "Password=autocaredev123!@#;";
	  //strcon="Data Source=115.84.178.37;"+"Initial Catalog=Autocare_Dev;"+"User id=autocaredev;"+"Password=autocaredev123!@#;";
	  //strcon="Data Source=qt;"+"Initial Catalog=Autocare2;"+"User id=sa;"+"Password=1234$;";
	  strcon=ConfigurationManager.ConnectionStrings["ConnectionThuocBac"].ConnectionString;
	  //static string strConStr = "Data Source=115.84.178.37;" + "Initial Catalog=Autocare_Dev;" + "User id=autocaredev;" + "Password=autocaredev123!@#;";
	  con=new SqlConnection(strcon);
	  cmd=con.CreateCommand();
	}
	public void OpenConnection() {
	  if(con.State!=ConnectionState.Open)
		con.Open();
	}
	public void CloseConnection() {
	  //if (con.State == ConnectionState.Open)
	  //    con.Close();
	}
	public DataTable dataTableThucThiQuery(string strSQL,CommandType cmdT,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.CommandType=cmdT;
	  cmd.CommandText=strSQL;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  dap=new SqlDataAdapter(cmd);
	  dataTableBangDuLieu=new DataTable();
	  dap.Fill(dataTableBangDuLieu);

	  CloseConnection();
	  return dataTableBangDuLieu;
	}
	public DataSet ExecuteQueryDataSet(string strSQL,CommandType cmdT,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.CommandType=cmdT;
	  cmd.CommandText=strSQL;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  dap=new SqlDataAdapter(cmd);
	  dt=new DataSet();
	  dap.Fill(dt);
	  CloseConnection();
	  return dt;
	}
	public bool blnThucThiNonQuery(string strSQL,CommandType cmdT,ref string err,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  bool f=false;
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.Parameters.Clear();
	  cmd.CommandText=strSQL;
	  cmd.CommandType=cmdT;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  try {
		err=cmd.ExecuteNonQuery().ToString();
		if(err.Equals("1"))
		  f=true;
	  } catch(SqlException se) {
		err=se.Message;
	  } finally {
		CloseConnection();
	  }
	  return f;
	}
	public bool boolThucThiNonQuery(string strSQL,CommandType cmdT,ref string err,ref string result,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  bool f=false;
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.Parameters.Clear();
	  cmd.CommandText=strSQL;
	  cmd.CommandType=cmdT;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  try {
		cmd.ExecuteReader();
		//Lay parameter output
		foreach(SqlParameter item in cmd.Parameters) {
		  if(item.Direction==ParameterDirection.Output)
			result=item.Value.ToString();
		}
		f=true;
	  } catch(SqlException se) {
		err=se.Message;
	  } finally {
		CloseConnection();
	  }
	  return f;
	}
	public bool boolThucThiScalarSql(string strSQL,CommandType cmdT,ref string err,ref string result,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  bool f=false;
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.Parameters.Clear();
	  cmd.CommandText=strSQL;
	  cmd.CommandType=cmdT;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  try {
		result=cmd.ExecuteScalar().ToString();
		f=true;
	  } catch(SqlException se) {
		err=se.Message;
		f=false;
	  } finally {
		CloseConnection();
	  }
	  return f;
	}
	public object objectThucThiScalar(string strSQL,CommandType cmdT,ref string err,ref string result,params SqlParameter[] param) {
	  cmd.Parameters.Clear();
	  //bool f = false;
	  //object kq=null;
	  OpenConnection();
	  cmd.Connection=con;
	  cmd.Parameters.Clear();
	  cmd.CommandText=strSQL;
	  cmd.CommandType=cmdT;
	  if(param!=null) {
		cmd.Parameters.Clear();
		foreach(SqlParameter p in param) {
		  cmd.Parameters.Add(p);
		}
	  }
	  try {
		result=cmd.ExecuteScalar().ToString();
		//f = true;
		//kq = cmd.ExecuteScalar();
	  } catch(SqlException se) {
		err=se.Message;
		//f = false;
		//kq = null;
	  } finally { CloseConnection(); }
	  //return f;
	  return result;
	}
  }
}
