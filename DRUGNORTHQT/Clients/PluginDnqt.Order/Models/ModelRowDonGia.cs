using System;

namespace PluginDnqt.Order.Models {
  class ModelRowDonGia:ModelRowDetailOrder {

	public DateTime DTimeViet { get; set; } = new DateTime();

	private string _strDTimeViet = "";

	public string StrDTimeViet {
	  get { return _strDTimeViet; }
	  set { _strDTimeViet=value; OnPropertyChanged(nameof(StrDTimeViet)); }
	}

	private string _strNameKH = "";

	public string StrNameKH {
	  get { return _strNameKH; }
	  set { _strNameKH=value; OnPropertyChanged(nameof(StrNameKH)); }
	}

  }
}
