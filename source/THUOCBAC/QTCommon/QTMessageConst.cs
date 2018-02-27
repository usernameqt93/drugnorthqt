using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCommon {
  public static class QTMessageConst {
	private const string CONST_STR_TEN_KHACHHANG = "Tên khách hàng";

	public static void STATIC_VOID_SHOW_MUSTNOT_BE_EMPTY(string _strTemp) {
	  MessageBox.Show(_strTemp+" không được để trống !");
	}

	public static void STATIC_VOID_SHOW_CONTAIN_MORE_X_CHARS(string _strTemp,int _intNumberChar) {
	  MessageBox.Show(_strTemp+" phải có từ "+_intNumberChar+" kí tự trở lên !");
	}

	public static void STATIC_VOID_SHOW_EXIST(string _strTemp) {
	  MessageBox.Show(_strTemp+" đã tồn tại trong danh sách !");
	}

	public static void CUSTOMER_NAME_MUSTNOT_BE_EMPTY() {
	  STATIC_VOID_SHOW_MUSTNOT_BE_EMPTY(CONST_STR_TEN_KHACHHANG);
	}

	public static void CUSTOMER_NAME_MUST_CONTAIN_MORE_X_CHAR(int _intChar) {
	  STATIC_VOID_SHOW_CONTAIN_MORE_X_CHARS(CONST_STR_TEN_KHACHHANG,_intChar);
	}

	public static void CUSTOMER_NAME_EXIST_IN_DB() {
	  STATIC_VOID_SHOW_EXIST(CONST_STR_TEN_KHACHHANG);
	}
  }
}
