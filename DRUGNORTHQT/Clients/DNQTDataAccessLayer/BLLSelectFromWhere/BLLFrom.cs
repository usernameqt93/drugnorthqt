using System;
using DNQTDataAccessLayer.ListTableDatabase;

namespace DNQTDataAccessLayer.BLLSelectFromWhere {
  class BLLFrom {

	private readonly BLLClass _bllClass = new BLLClass();

	internal void GetQueryLayAllIdProduct_From(ref string strFrom) {
	  strFrom+=$" {Table_BangViThuoc.NAME} {Table_BangViThuoc.NAME} ";
	}

	internal void GetQueryLayAllIdOrder_From(ref string strFrom) {
	  strFrom+=$" {Table_BangDanhSachDonHang.NAME} {Table_BangDanhSachDonHang.NAME} ";

	  {
		string strJoin2Table = "";
		_bllClass.GetStringJoin2Table(ref strJoin2Table,"\nINNER JOIN"
		  ,new Tuple<string,string>(Table_BangKhachHang.NAME
		  ,Table_BangKhachHang.Col_IdBangKhachHang.NAME)
		  ,new Tuple<string,string>(Table_BangDanhSachDonHang.NAME
		  ,Table_BangDanhSachDonHang.Col_IdBangKhachHang.NAME));
		strFrom+=strJoin2Table;
	  }

	}

	internal void GetQueryLayOrderByListId_From(ref string strFrom) {
	  strFrom+=$" {Table_BangDanhSachDonHang.NAME} {Table_BangDanhSachDonHang.NAME} ";

	  {
		string strJoin2Table = "";
		_bllClass.GetStringJoin2Table(ref strJoin2Table,"\nINNER JOIN"
		  ,new Tuple<string,string>(Table_BangKhachHang.NAME
		  ,Table_BangKhachHang.Col_IdBangKhachHang.NAME)
		  ,new Tuple<string,string>(Table_BangDanhSachDonHang.NAME
		  ,Table_BangDanhSachDonHang.Col_IdBangKhachHang.NAME));
		strFrom+=strJoin2Table;
	  }

	}

  }
}
