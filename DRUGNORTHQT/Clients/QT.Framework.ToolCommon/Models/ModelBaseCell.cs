using QT.Framework.ToolCommon.Helpers;

namespace QT.Framework.ToolCommon.Models {
  public class ModelBaseCell:ModelBase {

	private object _objItem=null;

	public object ObjItem {
	  get { return _objItem; }
	  set { _objItem=value; OnPropertyChanged(nameof(ObjItem)); }
	}

	private string _str="";

	public string Str {
	  get { return _str; }
	  set { _str=value;OnPropertyChanged(nameof(Str)); }
	}

	private string _strColumnName="";

	public string StrColumnName {
	  get { return _strColumnName; }
	  set { _strColumnName=value;OnPropertyChanged(nameof(StrColumnName)); }
	}

  }
}
