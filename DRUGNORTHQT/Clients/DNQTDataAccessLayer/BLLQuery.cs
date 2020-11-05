using DNQTDataAccessLayer.BLLSelectFromWhere;
using DNQTConstTable.ListTableDatabase;
using System.Collections.Generic;
using System;

namespace DNQTDataAccessLayer {
  class BLLQuery {

	private readonly BLLSelect _bllSelect = new BLLSelect();
	private readonly BLLFrom _bllFrom = new BLLFrom();
	private readonly BLLClass _bllClass = new BLLClass();

	internal void GetQueryLayAllIdProduct(ref string strQuery) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayAllIdProduct_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayAllIdProduct_From(ref strFrom);

	  string strOrderBy = "";
	  strOrderBy+=$"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_TenViThuoc.NAME} ";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nORDER BY {strOrderBy} ;";
	}

	internal void GetQueryLayAllIdOrder(ref string strQuery) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayAllIdOrder_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayAllIdOrder_From(ref strFrom);

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} ;";
	}

	internal void GetQueryLayOrderByListId(ref string strQuery,List<string> lstStringId) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayOrderByListId_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayOrderByListId_From(ref strFrom);

	  string strWhere = "";

	  string strListId = "";
	  _bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

	  strWhere+=$"\n {Table_BangDanhSachDonHang.NAME}.{Table_BangDanhSachDonHang.Col_MaDonHang.NAME} IN ({strListId}) ";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} ;";
	}

	internal void GetQueryLayDetailOrderByListId(ref string strQuery,List<string> lstStringId) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayDetailOrderByListId_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayDetailOrderByListId_From(ref strFrom);

	  string strWhere = "";

	  string strListId = "";
	  _bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

	  strWhere+=$"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaDonHang.NAME} IN ({strListId}) ";

	  string strOrderBy = "";
	  strOrderBy+=$"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} ";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} \nORDER BY {strOrderBy} ;";
	}

	internal void GetQueryLayListOrderByListId(ref string strQuery,List<string> lstStringId) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayListOrderByListId_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayListOrderByListId_From(ref strFrom);

	  string strWhere = "";

	  string strListId = "";
	  _bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

	  strWhere+=$"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_MaViThuoc.NAME} IN ({strListId}) ";

	  //string strOrderBy = "";
	  //strOrderBy+=$"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} ";

	  //strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} \nORDER BY {strOrderBy} ;";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} ;";
	}

	internal void GetQueryLayListDonGiaByListId(ref string strQuery,List<string> lstStringId) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayListDonGiaByListId_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayListDonGiaByListId_From(ref strFrom);

	  string strWhere = "";

	  string strListId = "";
	  _bllClass.GetStringJoinSplitChar(ref strListId,lstStringId,",","");

	  strWhere+=$"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_MaViThuoc.NAME} IN ({strListId}) ";

	  //string strOrderBy = "";
	  //strOrderBy+=$"\n {Table_BangChiTietDonHang.NAME}.{Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME} ";

	  //strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} \nORDER BY {strOrderBy} ;";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nWHERE {strWhere} ;";
	}

	internal void AddProductExistToOrderDetail(ref string strQuery,Dictionary<string,object> dicInput) {
	  string strOutput = "";
	  string strMaGiaThuocVuaThem = "MaGiaThuocVuaThem";
	  strOutput+=$"\n declare @{strMaGiaThuocVuaThem} int;";

	  {
		var lstColumnTable = new List<string>();
		lstColumnTable.Add(Table_BangGiaViThuoc.Col_MaViThuoc.NAME);
		lstColumnTable.Add(Table_BangGiaViThuoc.Col_GiaViThuoc.NAME);
		lstColumnTable.Add(Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME);
		lstColumnTable.Add(Table_BangGiaViThuoc.Col_ThoiGianBatDauCoGiaNay.NAME);

		string strTemp = "";
		_bllClass.GetQueryUseParameter(ref strTemp,"insert into"
		  ,Table_BangGiaViThuoc.NAME,"values",lstColumnTable);
		strOutput+=$"\n {strTemp}";
	  }

	  strOutput+=$"\n set @{strMaGiaThuocVuaThem} = (select @@IDENTITY);";

	  // {
	  //var lstColumnTable = new List<string>();
	  //lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaDonHang.NAME);
	  //lstColumnTable.Add(Table_BangChiTietDonHang.Col_MaGiaThuoc.NAME);
	  //lstColumnTable.Add(Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME);
	  //lstColumnTable.Add(Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME);

	  //string strTemp = "";
	  //_bllClass.GetQueryUseParameter(ref strTemp,"insert into"
	  //  ,Table_BangGiaViThuoc.NAME,"values",lstColumnTable);
	  //strOutput+=$"\n {strTemp}";
	  // }
	  strOutput+="\n "+@"Insert into BangChiTietDonHang(MaDonHang,MaGiaThuoc,SoLuongViThuoc,ThanhTienTamThoi)
	values(@MaDonHang,@MaGiaThuocVuaThem,@SoLuongViThuoc,@ThanhTienTamThoi);";

	  strQuery=strOutput;
	}

  }
}
