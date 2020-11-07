using QT.Framework.ToolCommon.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace PluginDnqt.Customer.Models {
  class ModelRowDetailTienNo:ModelBaseRow {

	internal ModelRowDetailTienNo() {

	}

	internal ModelRowDetailTienNo(ModelBaseRow c) {
	  // copy base class properties.
	  foreach(PropertyInfo prop in c.GetType().GetProperties()) {
		PropertyInfo prop2 = c.GetType().GetProperty(prop.Name);
		prop2.SetValue(this,prop.GetValue(c,null),null);
	  }
	}

	public ObservableCollection<ModelBaseRow> LstGridBaseDetail { get; set; } =
	  new ObservableCollection<ModelBaseRow>();

	public ObservableCollection<ModelBaseRow> LstGridDetail { get; set; } =
	  new ObservableCollection<ModelBaseRow>();

	private ModelBaseDateTime _mbdtTime=new ModelBaseDateTime();

	public ModelBaseDateTime MBDTTime {
	  get { return _mbdtTime; }
	  set { _mbdtTime=value;OnPropertyChanged(nameof(MBDTTime)); }
	}

	private ModelBaseDecimal _mbdTruocKhiSua = new ModelBaseDecimal();

	public ModelBaseDecimal MBDTruocKhiSua {
	  get { return _mbdTruocKhiSua; }
	  set { _mbdTruocKhiSua=value; OnPropertyChanged(nameof(MBDTruocKhiSua)); }
	}

	private ModelBaseDecimal _mbdSoTienSua = new ModelBaseDecimal();

	public ModelBaseDecimal MBDSoTienSua {
	  get { return _mbdSoTienSua; }
	  set { _mbdSoTienSua=value; OnPropertyChanged(nameof(MBDSoTienSua)); }
	}

	private ModelBaseDecimal _mbdSauKhiSua = new ModelBaseDecimal();

	public ModelBaseDecimal MBDSauKhiSua {
	  get { return _mbdSauKhiSua; }
	  set { _mbdSauKhiSua=value; OnPropertyChanged(nameof(MBDSauKhiSua)); }
	}

  }
}
