using DNQTDataAccessLayer.ListTableDatabase;
using System.Collections.Generic;

namespace DNQTDataAccessLayer.BLLSelectFromWhere {
  class BLLSelect {

	private readonly BLLClass _bllClass = new BLLClass();

	internal void GetQueryLayAllIdProduct_Select(ref string strSelect) {
	  string strListColumnJoinTable1 = "";
	  {
		var lstColumnTable = new List<string>();
		lstColumnTable.Add(Table_BangViThuoc.Col_MaViThuoc.NAME);
		lstColumnTable.Add(Table_BangViThuoc.Col_TenViThuoc.NAME);

		_bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable1
		  ,lstColumnTable,",",Table_BangViThuoc.NAME);
	  }

	  strSelect=strListColumnJoinTable1;
	}
  }
}
