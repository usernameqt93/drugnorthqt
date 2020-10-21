using System;
using System.Collections.Generic;

namespace DNQTDataAccessLayer {
  class BLLClass {

	#region Function dùng chung

	/// <summary>
	/// Ví dụ list string là a b c 
	/// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="lstStringInput"></param>
	/// <param name="strCharSplit"></param>
	/// <param name="strTienTo"></param>
	internal void GetStringJoinSplitChar(ref string strOutput
	  ,List<string> lstStringInput,string strCharSplit,string strTienTo) {
	  if(lstStringInput.Count==0) {
		return;
	  }

	  string strThemVao = "";
	  if(strTienTo!="") {
		strThemVao=$"{strTienTo}.";
	  }

	  for(int i = 0;i<lstStringInput.Count;i++) {
		if(i==0) {
		  strOutput+=strThemVao+lstStringInput[i];
		  continue;
		}

		strOutput+=strCharSplit+strThemVao+lstStringInput[i];
	  }
	}

	/// <summary>
	/// Ví dụ list string là a b c 
	/// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="lstStringInput"></param>
	/// <param name="strCharSplit"></param>
	/// <param name="strTienTo"></param>
	internal void GetStringJoinSplitChar(ref string strOutput
	  ,List<int> lstStringInput,string strCharSplit,string strTienTo) {
	  if(lstStringInput.Count==0) {
		return;
	  }

	  string strThemVao = "";
	  if(strTienTo!="") {
		strThemVao=$"{strTienTo}.";
	  }

	  for(int i = 0;i<lstStringInput.Count;i++) {
		if(i==0) {
		  strOutput+=strThemVao+lstStringInput[i];
		  continue;
		}

		strOutput+=strCharSplit+strThemVao+lstStringInput[i];
	  }
	}

	/// <summary>
	/// output trả về là " LEFT JOIN x x ON x.u=y.t " 
	/// với x u là tuple1 và y t là tuple2
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="strTypeJoin"></param>
	/// <param name="tupleBangJoinVaColumn"></param>
	/// <param name="tupleBangGocVaColumn"></param>
	internal void GetStringJoin2Table(ref string strOutput,string strTypeJoin
	  ,Tuple<string,string> tupleBangJoinVaColumn,Tuple<string,string> tupleBangGocVaColumn) {
	  strOutput+=$" {strTypeJoin} ";
	  strOutput+=$" {tupleBangJoinVaColumn.Item1} {tupleBangJoinVaColumn.Item1} ";
	  strOutput+=$"\n ON ";
	  strOutput+=$"\n {tupleBangJoinVaColumn.Item1}.{tupleBangJoinVaColumn.Item2}={tupleBangGocVaColumn.Item1}.{tupleBangGocVaColumn.Item2} ";
	}

	#endregion

  }
}
