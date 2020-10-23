namespace PluginDnqt.Order.Models {
  class ModelRowDetailOrder:ModelRowMain {

	private string _strNameDrug = "";

	public string StrNameDrug {
	  get { return _strNameDrug; }
	  set { _strNameDrug=value; OnPropertyChanged(nameof(StrNameDrug)); }
	}

	private float _floatSumKg = 0;

	public float FloatSumKg {
	  get { return _floatSumKg; }
	  set { _floatSumKg=value; OnPropertyChanged(nameof(FloatSumKg)); }
	}

	private string _strSumKg = "";

	public string StrSumKg {
	  get { return _strSumKg; }
	  set { _strSumKg=value; OnPropertyChanged(nameof(StrSumKg)); }
	}

	private string _strDonVi="";

	public string StrDonVi {
	  get { return _strDonVi; }
	  set { _strDonVi=value;OnPropertyChanged(nameof(StrDonVi)); }
	}

	private decimal _decimalDonGia = 0;

	public decimal DecimalDonGia {
	  get { return _decimalDonGia; }
	  set { _decimalDonGia=value; OnPropertyChanged(nameof(DecimalDonGia)); }
	}

	private string _strDonGia = "";

	public string StrDonGia {
	  get { return _strDonGia; }
	  set { _strDonGia=value; OnPropertyChanged(nameof(StrDonGia)); }
	}

	private decimal _decimalThanhTien = 0;

	public decimal DecimalThanhTien {
	  get { return _decimalThanhTien; }
	  set { _decimalThanhTien=value; OnPropertyChanged(nameof(DecimalThanhTien)); }
	}

	private string _strThanhTien = "";

	public string StrThanhTien {
	  get { return _strThanhTien; }
	  set { _strThanhTien=value; OnPropertyChanged(nameof(StrThanhTien)); }
	}

  }
}
