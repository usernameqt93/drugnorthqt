using QT.Framework.ToolCommon.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace PluginDnqt.Customer.Models {
  class ModelRowCustomer:ModelBaseRow {

	internal ModelRowCustomer() {

	}

	internal ModelRowCustomer(ModelBaseRow c) {
	  // copy base class properties.
	  foreach(PropertyInfo prop in c.GetType().GetProperties()) {
		PropertyInfo prop2 = c.GetType().GetProperty(prop.Name);
		prop2.SetValue(this,prop.GetValue(c,null),null);
	  }
	}

	public ObservableCollection<ModelBaseRow> LstGridBaseDetail { get; set; } =
	  new ObservableCollection<ModelBaseRow>();

	public ObservableCollection<ModelRowDetailTienNo> LstGridDetail { get; set; } =
	  new ObservableCollection<ModelRowDetailTienNo>();

	private int _intSoLanThayDoi=0;

	public int IntSoLanThayDoi {
	  get { return _intSoLanThayDoi; }
	  set { _intSoLanThayDoi=value;OnPropertyChanged(nameof(IntSoLanThayDoi)); }
	}

	private ModelBaseDateTime _mbdtGanNhat = new ModelBaseDateTime();

	public ModelBaseDateTime MBDTGanNhat {
	  get { return _mbdtGanNhat; }
	  set { _mbdtGanNhat=value; OnPropertyChanged(nameof(MBDTGanNhat)); }
	}

	private ModelBaseDecimal _mbdTienNo = new ModelBaseDecimal();

	public ModelBaseDecimal MBDTienNo {
	  get { return _mbdTienNo; }
	  set { _mbdTienNo=value; OnPropertyChanged(nameof(MBDTienNo)); }
	}

  }
}
