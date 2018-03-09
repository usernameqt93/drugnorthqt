using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCommon {
  public static class QTAppTemp {

	//QTAppTemp.QT_RESET_APP_TEMP()

	public static string STATIC_STR_TEMP;
	public static string STATIC_STR_NAME_ADD_SUCCESS { get; set; }
	public static string STATIC_STR_NAME_CHOOSE { get; set; }
	public static int STATIC_INT_ID_CHOOSE { get; set; }
	public static decimal STATIC_DEC_DEBT_CHOOSE { get; set; }

	public static void QT_RESET_APP_TEMP() {
	  STATIC_STR_TEMP="";
	  STATIC_STR_NAME_ADD_SUCCESS="";
	  STATIC_STR_NAME_CHOOSE="";
	  STATIC_INT_ID_CHOOSE=QTDbConst.SODACBIET.INT;
	  STATIC_DEC_DEBT_CHOOSE=0;
	}

	//QTAppTemp.QT_RESET_APP_TEMP()

  }
}
