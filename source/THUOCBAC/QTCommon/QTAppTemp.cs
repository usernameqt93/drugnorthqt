using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCommon {
  public static class QTAppTemp {
	public static string STATIC_STR_TEMP;
	public static string STATIC_STR_NAME_ADD_SUCCESS;

	public static void QT_RESET_APP_TEMP() {
	  STATIC_STR_TEMP="";
	  STATIC_STR_NAME_ADD_SUCCESS="";
	}
  }
}
