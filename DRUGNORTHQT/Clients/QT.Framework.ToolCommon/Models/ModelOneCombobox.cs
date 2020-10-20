using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace QT.Framework.ToolCommon.Models {
  public class ModelOneCombobox:ModelBase {

	private ModelItems _mItemSelected = null;

	public ModelItems MItemSelected {
	  get { return _mItemSelected; }
	  set { _mItemSelected = value; OnPropertyChanged(nameof(MItemSelected)); }
	}

	public ObservableCollection<ModelItems> _lstCbo = new ObservableCollection<ModelItems>();

	public ObservableCollection<ModelItems> LstCbo {
	  get { return _lstCbo; }
	  set { _lstCbo = value; OnPropertyChanged(nameof(LstCbo)); }
	}

  }
}
