using DNQTConstTable.ListTableDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DNQTDataAccessLayer.DALNew {
  public class DAL_Order:Connection {

	private readonly BLLQuery _bllQuery = new BLLQuery();
	private readonly BLLClass _bllClass = new BLLClass();
	private readonly DAL_Common DALCommon = new DAL_Common();

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

	public void AddProductExistToOrderDetail(ref Dictionary<string,object> dicOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strQuery = "";
		_bllQuery.AddProductExistToOrderDetail(ref strQuery);

		var lstTupleParameter = new List<Tuple<string,object>>();
		{
		  string objTemp = dicInput["string.strIdProduct"] as string;
		  lstTupleParameter.Add(new Tuple<string, object>
			(Table_BangGiaViThuoc.Col_MaViThuoc.NAME,objTemp));
		}
		{
		  decimal objTemp = (decimal)dicInput["decimal.decDonGia"];
		  lstTupleParameter.Add(new Tuple<string,object>
			(Table_BangGiaViThuoc.Col_GiaViThuoc.NAME,objTemp));
		}
		lstTupleParameter.Add(new Tuple<string,object>
		  (Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME,"Kg"));
		lstTupleParameter.Add(new Tuple<string,object>
		  (Table_BangGiaViThuoc.Col_ThoiGianBatDauCoGiaNay.NAME,DateTime.Now));
		{
		  string objTemp = dicInput["string.strIdOrder"] as string;
		  lstTupleParameter.Add(new Tuple<string,object>
			(Table_BangChiTietDonHang.Col_MaDonHang.NAME,objTemp));
		}
		{
		  decimal objTemp = (decimal)dicInput["decimal.decSoLuong"];
		  lstTupleParameter.Add(new Tuple<string,object>
			(Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME,objTemp));
		}
		{
		  decimal objTemp = (decimal)dicInput["decimal.decThanhTien"];
		  lstTupleParameter.Add(new Tuple<string,object>
			(Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME,objTemp));
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

	public void DeleteOrderDetailByListId(ref bool blnSuccess,ref string strError,ref Exception exOutput
	  ,List<string> lstStringId) {
	  try {
		string strQuery = "";
		_bllQuery.DeleteOrderDetailByListId(ref strQuery,lstStringId);

		blnSuccess=blnThucThiNonQuery(strQuery,CommandType.Text,ref strError,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}
  }
}
