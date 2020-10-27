using System.Collections.Generic;

namespace PluginDnqt.Product.Models {
  class ModelRowProduct:ModelRowMain {

	private string _strListOrder="Chưa tải được";

	public string StrListOrder {
	  get { return _strListOrder; }
	  set { _strListOrder=value;OnPropertyChanged(nameof(StrListOrder)); }
	}

	private int _intSumOrder=0;

	public int IntSumOrder {
	  get { return _intSumOrder; }
	  set { _intSumOrder=value;OnPropertyChanged(nameof(IntSumOrder)); }
	}

	public List<string> LstStringIdOrder { get; set; } = new List<string>();

  }
}
