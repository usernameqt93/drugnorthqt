using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCommon {
  public static class QTMessageConst {
	private const string CONST_STR_TEN_KHACHHANG = "Tên khách hàng";

	//QTMessageConst.CUSTOMER_NAME_ADD_SUCCESS

	//public static void STATIC_VOID_SHOW_MUSTNOT_BE_EMPTY(string _strTemp) {
	//  MessageBox.Show(_strTemp+" không được để trống !");
	//}

	public static void STATIC_VOID_SHOW_CONTAIN_MORE_X_CHARS(string _strTemp,int _intNumberChar) {
	  MessageBox.Show(_strTemp+" phải có từ "+_intNumberChar+" kí tự trở lên !");
	}

	public static void STATIC_VOID_SHOW_EXIST(string _strTemp) {
	  MessageBox.Show(_strTemp+" đã tồn tại trong danh sách !");
	}

	public static void STATIC_VOID_SHOW_ADD_SUCCESS(string _strTemp) {
	  MessageBox.Show("Thêm "+_strTemp+" thành công !");
	}

	//public static void CUSTOMER_NAME_MUSTNOT_BE_EMPTY() {
	//  STATIC_VOID_SHOW_MUSTNOT_BE_EMPTY(CONST_STR_TEN_KHACHHANG);
	//}

	public static void CUSTOMER_NAME_MUST_CONTAIN_MORE_X_CHAR(int _intChar) {
	  STATIC_VOID_SHOW_CONTAIN_MORE_X_CHARS(CONST_STR_TEN_KHACHHANG,_intChar);
	}

	//public static void CUSTOMER_NAME_EXIST_IN_DB() {
	//  STATIC_VOID_SHOW_EXIST(CONST_STR_TEN_KHACHHANG);
	//}

	public static void CUSTOMER_NAME_EXIST_IN_DB(string _strText) {
	  STATIC_VOID_SHOW_EXIST(CONST_STR_TEN_KHACHHANG + " '"+_strText+"'");
	}

	public static void CUSTOMER_NAME_ADD_SUCCESS(string _strText) {
	  STATIC_VOID_SHOW_ADD_SUCCESS(CONST_STR_TEN_KHACHHANG+" '"+_strText+"'");
	}

	public static void UNIT_PRICE_IS_LOW(decimal _decDonGia) {
	  MessageBox.Show("Đơn giá bạn nhập hiện tại đang là '"+_decDonGia+"' vnđ , hơi thấp so với bình thường, bạn nên kiểm tra lại !");
	}

	public static void EDIT_PRICE_AMOUNT_ERROR(string _strEr) {
	  MessageBox.Show("Sửa đơn giá và số lượng lỗi ("+_strEr+")");
	}

	public static void EDIT_PRICE_AMOUNT_SUCCESS() {
	  MessageBox.Show("Sửa đơn giá và số lượng THÀNH CÔNG");
	}

	public static void NAME_IS_EXIST_SHOULD_EDIT(string _strName) {
	  MessageBox.Show("'"+_strName+"' đã được bạn thêm vào đơn hàng trước đó !\nĐể sửa giá và số lượng, bạn hãy bấm chuột phải vào dòng '"+_strName+"' rồi chọn sửa !");
	}

	//QTMessageConst.CUSTOMER_NAME_ADD_SUCCESS
  }
}
