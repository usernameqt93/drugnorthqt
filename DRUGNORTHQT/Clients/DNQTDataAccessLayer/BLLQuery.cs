using DNQTDataAccessLayer.BLLSelectFromWhere;
using DNQTDataAccessLayer.ListTableDatabase;

namespace DNQTDataAccessLayer {
  class BLLQuery {

	private readonly BLLSelect _bllSelect = new BLLSelect();
	private readonly BLLFrom _bllFrom = new BLLFrom();

	internal void GetQueryLayAllIdProduct(ref string strQuery) {
	  string strSelect = "";
	  _bllSelect.GetQueryLayAllIdProduct_Select(ref strSelect);

	  string strFrom = "";
	  _bllFrom.GetQueryLayAllIdProduct_From(ref strFrom);

	  string strOrderBy = "";
	  strOrderBy+=$"\n {Table_BangViThuoc.NAME}.{Table_BangViThuoc.Col_TenViThuoc.NAME} ";

	  strQuery=$"SELECT \n{strSelect} \nFROM {strFrom} \nORDER BY {strOrderBy} ;";
	}
  }
}
