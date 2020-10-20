using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QT.Framework.ToolCommon.Models {
  public class ModelBaseDataGrid:ModelBase {

	private int _stt = 0;

	public int Stt {
	  get { return _stt; }
	  set { _stt = value; OnPropertyChanged(nameof(Stt)); }
	}

	private object _objItem;

	public object ObjItem {
	  get { return _objItem; }
	  set { _objItem = value; OnPropertyChanged(nameof(ObjItem)); }
	}

	private bool? _selected = false;
	public bool? Selected {
	  get { return _selected; }
	  set { _selected = value; OnPropertyChanged(nameof(Selected)); }
	}

  }
}
