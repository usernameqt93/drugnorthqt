﻿using DNQTConstTable.ListTableDatabase;
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
		_bllQuery.AddProductExistToOrderDetail(ref strQuery,dicInput);

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

	public void AddProductNotExistToOrderDetail(ref Dictionary<string,object> dicOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		string strMaViThuocVuaThem = "MaViThuocVuaThem";
		string strMaGiaThuocVuaThem = "MaGiaThuocVuaThem";

		string strQuery = "";
		//_bllQuery.AddProductToOrderDetail(ref strQuery,dicInput);

		strQuery+=$"\n declare @{strMaViThuocVuaThem} int;";
		strQuery+=$"\n declare @{strMaGiaThuocVuaThem} int;";

		{
		  var lstColumnTable = new List<string>();
		  lstColumnTable.Add(Table_BangViThuoc.Col_TenViThuoc.NAME);

		  string strTemp = "";
		  _bllClass.GetQueryUseParameter(ref strTemp,"insert into"
			,Table_BangViThuoc.NAME,"values",lstColumnTable);
		  strQuery+=$"\n {strTemp}";
		}

		strQuery+=$"\n set @{strMaViThuocVuaThem} = (select @@IDENTITY);";

		{
		  var lstColumnTable = new List<string>();
		  lstColumnTable.Add(Table_BangGiaViThuoc.Col_MaViThuoc.NAME);
		  lstColumnTable.Add(Table_BangGiaViThuoc.Col_GiaViThuoc.NAME);
		  lstColumnTable.Add(Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME);
		  lstColumnTable.Add(Table_BangGiaViThuoc.Col_ThoiGianBatDauCoGiaNay.NAME);

		  string strTemp = "";
		  _bllClass.GetQueryUseParameter(ref strTemp,"insert into"
			,Table_BangGiaViThuoc.NAME,"values",lstColumnTable);
		  strQuery+=$"\n {strTemp}";
		}

		strQuery+=$"\n set @{strMaGiaThuocVuaThem} = (select @@IDENTITY);";

		{
		  var lstColumnTable = new List<string>();
		  lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaDonHang.NAME);
		  lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaGiaThuoc.NAME);
		  lstColumnTable.Add(Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME);
		  lstColumnTable.Add(Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME);

		  string strTemp = "";
		  _bllClass.GetQueryUseParameter(ref strTemp,"insert into"
			,Table_BangGiaViThuoc.NAME,"values",lstColumnTable);
		  strQuery+=$"\n {strTemp}";
		}


		var lstTupleParameter = new List<Tuple<string,object>>();

		//dtOutput =dataTableThucThiQuery(strQuery,CommandType.Text,null);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

  }
}
