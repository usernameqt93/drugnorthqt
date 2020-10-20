using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QT.Framework.ToolCommon.Models {
  public class ModelItems:ModelBase {
	private Int32 _iD = 0;
	public Int32 ID {
	  get { return _iD; }
	  set { _iD = value; OnPropertyChanged("ID"); }
	}
	private String _code = String.Empty;
	public String Code {
	  get { return _code; }
	  set { _code = value; OnPropertyChanged("Code"); }
	}
	private String _name = String.Empty;
	public String Name {
	  get { return _name; }
	  set { _name = value; OnPropertyChanged("Name"); }
	}

	private object _objItem;

	public object ObjItem {
	  get { return _objItem; }
	  set { _objItem = value; OnPropertyChanged(nameof(ObjItem)); }
	}

  }
}
