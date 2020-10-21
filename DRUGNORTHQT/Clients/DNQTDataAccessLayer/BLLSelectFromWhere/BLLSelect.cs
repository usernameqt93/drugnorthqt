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

	internal void GetQueryLayAllIdOrder_Select(ref string strSelect) {
	  string strListColumnJoinTable1 = "";
	  {
		var lstColumnTable = new List<string>();
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_MaDonHang.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_TongViThuoc.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_TongKhoiLuong.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_TongGiaTriDonHang.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_IdBangKhachHang.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_SDTKhachHang.NAME);
		lstColumnTable.Add(Table_BangDanhSachDonHang.Col_TienNoCu.NAME);

		_bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable1
		  ,lstColumnTable,",",Table_BangDanhSachDonHang.NAME);
	  }

	  string strListColumnJoinTable2 = "";
	  {
		var lstColumnTable = new List<string>();
		lstColumnTable.Add(Table_BangKhachHang.Col_TenKhachHang.NAME);

		_bllClass.GetStringJoinSplitChar(ref strListColumnJoinTable2
		  ,lstColumnTable,",",Table_BangKhachHang.NAME);
	  }

	  var lstStringInput = new List<string>();
	  lstStringInput.Add(strListColumnJoinTable1);
	  lstStringInput.Add(strListColumnJoinTable2);

	  _bllClass.GetStringJoinSplitChar(ref strSelect,lstStringInput,"\n,","");

	}
  }
}
