using System;
using System.Collections.Generic;
using System.Data;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Customer:Connection {

	private readonly BLLClass _bllClass = new BLLClass();
	private readonly DAL_Common DALCommon = new DAL_Common();

	public void GetDTAllIdCustomer(ref DataTable dtOutput,ref Exception exOutput) {
	  try {
		string strQuery = @"select IdBangKhachHang,TenKhachHang,TienNoHienTai"
+" from BangKhachHang order by TenKhachHang";

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDTAllIdCustomerSortByTienNo(ref DataTable dtOutput,ref Exception exOutput) {
	  try {
		string strQuery = @"select IdBangKhachHang,TenKhachHang,TienNoHienTai"
+" from BangKhachHang order by TienNoHienTai DESC";

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void GetDTDetailTienNoByListIdKH(ref DataTable dtOutput,ref Exception exOutput
	  ,List<string> lstStringId) {
	  try {
		string strSql = @" select IdBangKhachHang,ThoiGianThayDoiTienNo,LyDoSuaTienNo,TienNoTruocKhiSua,SoTienSuaCuThe,TienNoSauKhiSua"
+" from BangChiTietTienNo ";

		string strListId = "";
		_bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

		string strWhere = $" IdBangKhachHang IN ({strListId}) ";

		string strQuery = strSql+$" \nWHERE {strWhere}";

		dtOutput=dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void UpdateDetailTienNoKH(ref Dictionary<string,object> dicOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		strQuery+="\n"+@"update BangKhachHang set TienNoHienTai=@TienNoHienTai"
+" where IdBangKhachHang=@IdBangKhachHang; ";
		strQuery+="\n"+@"Insert into BangChiTietTienNo"
+"(IdBangKhachHang,ThoiGianThayDoiTienNo,TienNoTruocKhiSua,LyDoSuaTienNo,SoTienSuaCuThe,TienNoSauKhiSua) "
+" values (@IdBangKhachHang,@ThoiGianThayDoiTienNo,@TienNoTruocKhiSua,@LyDoSuaTienNo,@SoTienSuaCuThe,@TienNoSauKhiSua);";

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  decimal objTemp = (decimal)dicInput["decimal.TienNoHienTai"];
		  lstTupleParameter.Add(new Tuple<string,object>("TienNoHienTai",objTemp));
		}
		{
		  string objTemp = dicInput["string.IdBangKhachHang"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>("IdBangKhachHang",objTemp));
		}
		lstTupleParameter.Add(new Tuple<string,object>("ThoiGianThayDoiTienNo",DateTime.Now));
		{
		  decimal objTemp = (decimal)dicInput["decimal.TienNoTruocKhiSua"];
		  lstTupleParameter.Add(new Tuple<string,object>("TienNoTruocKhiSua",objTemp));
		}
		{
		  string objTemp = dicInput["string.LyDoSuaTienNo"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>("LyDoSuaTienNo",objTemp));
		}
		{
		  decimal objTemp = (decimal)dicInput["decimal.SoTienSuaCuThe"];
		  lstTupleParameter.Add(new Tuple<string,object>("SoTienSuaCuThe",objTemp));
		}
		{
		  decimal objTemp = (decimal)dicInput["decimal.TienNoSauKhiSua"];
		  lstTupleParameter.Add(new Tuple<string,object>("TienNoSauKhiSua",objTemp));
		}

		bool blnResult = false;
		string strError = "";
		DALCommon.ExcuteQueryWithListTupleParameter(ref strError,ref blnResult,strQuery,lstTupleParameter);
		if(blnResult==false&&strError!="2") {
		  dicOutput["string"]=strError;
		}
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}
  }
}
