using DNQTDataAccessLayer.ListTableDatabase;

namespace DNQTDataAccessLayer.BLLSelectFromWhere {
  class BLLFrom {

	private readonly BLLClass _bllClass = new BLLClass();

	internal void GetQueryLayAllIdProduct_From(ref string strFrom) {
	  strFrom+=$" {Table_BangViThuoc.NAME} {Table_BangViThuoc.NAME} ";
	}
  }
}
