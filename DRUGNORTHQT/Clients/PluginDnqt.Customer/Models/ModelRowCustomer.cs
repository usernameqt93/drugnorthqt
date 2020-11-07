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

	private decimal _decimalSumTienNo = 0;

	public decimal DecimalSumTienNo {
	  get { return _decimalSumTienNo; }
	  set { _decimalSumTienNo=value; OnPropertyChanged(nameof(DecimalSumTienNo)); }
	}

	private string _strSumTienNo = "";

	public string StrSumTienNo {
	  get { return _strSumTienNo; }
	  set { _strSumTienNo=value; OnPropertyChanged(nameof(StrSumTienNo)); }
	}

  }
}
