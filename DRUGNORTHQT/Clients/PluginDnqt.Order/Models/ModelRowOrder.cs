using System;
using System.Collections.ObjectModel;

namespace PluginDnqt.Order.Models {
  class ModelRowOrder:ModelRowMain {

	public DateTime DTimeViet { get; set; } = new DateTime();

	private string _strDTimeViet="";

	public string StrDTimeViet {
	  get { return _strDTimeViet; }
	  set { _strDTimeViet=value;OnPropertyChanged(nameof(StrDTimeViet)); }
	}

	private int _intSumProduct=0;

	public int IntSumProduct {
	  get { return _intSumProduct; }
	  set { _intSumProduct=value; OnPropertyChanged(nameof(IntSumProduct)); }
	}

	private float _floatSumKg=0;

	public float FloatSumKg {
	  get { return _floatSumKg; }
	  set { _floatSumKg=value;OnPropertyChanged(nameof(FloatSumKg)); }
	}

	private string _strSumKg="";

	public string StrSumKg {
	  get { return _strSumKg; }
	  set { _strSumKg=value;OnPropertyChanged(nameof(StrSumKg)); }
	}

	private decimal _decimalSumGiaTri=0;

	public decimal DecimalSumGiaTri {
	  get { return _decimalSumGiaTri; }
	  set { _decimalSumGiaTri=value;OnPropertyChanged(nameof(DecimalSumGiaTri)); }
	}

	private string _strSumGiaTri="";

	public string StrSumGiaTri {
	  get { return _strSumGiaTri; }
	  set { _strSumGiaTri=value;OnPropertyChanged(nameof(StrSumGiaTri)); }
	}

	private string _strIdKH="0";

	public string StrIdKH {
	  get { return _strIdKH; }
	  set { _strIdKH=value;OnPropertyChanged(nameof(StrIdKH)); }
	}

	private string _strNameKH="";

	public string StrNameKH {
	  get { return _strNameKH; }
	  set { _strNameKH=value;OnPropertyChanged(nameof(StrNameKH)); }
	}

	public ObservableCollection<ModelRowDetailOrder> LstGridDetailOrder { get; set; } = 
	  new ObservableCollection<ModelRowDetailOrder>();

  }
}
