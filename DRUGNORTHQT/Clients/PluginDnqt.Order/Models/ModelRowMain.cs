using QT.Framework.ToolCommon.Helpers;

namespace PluginDnqt.Order.Models {
  internal class ModelRowMain:ModelBase {

	private int _stt = 0;

	public int Stt {
	  get { return _stt; }
	  set { _stt=value; OnPropertyChanged(nameof(Stt)); }
	}

	private string _strStt = "";

	public string StrStt {
	  get { return _strStt; }
	  set { _strStt=value; OnPropertyChanged(nameof(StrStt)); }
	}

	private int _intId = 0;

	public int IntId {
	  get { return _intId; }
	  set { _intId=value; OnPropertyChanged(nameof(IntId)); }
	}

	private string _strId = "";

	public string StrId {
	  get { return _strId; }
	  set { _strId=value; OnPropertyChanged(nameof(StrId)); }
	}

	private string _strName = "";

	public string StrName {
	  get { return _strName; }
	  set { _strName=value; OnPropertyChanged(nameof(StrName)); }
	}

	private object _objItem;

	public object ObjItem {
	  get { return _objItem; }
	  set { _objItem=value; OnPropertyChanged(nameof(ObjItem)); }
	}

	private bool? _selected = false;

	public bool? Selected {
	  get { return _selected; }
	  set { _selected=value; OnPropertyChanged(nameof(Selected)); }
	}

  }
}
