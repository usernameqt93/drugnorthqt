namespace PluginDnqt.Order.Models {
  class ModelRowGoiYNameProduct:ModelRowMain {

	private double _doubleWidthHeightIconAlert = 0;

	public double DoubleWidthHeightIconAlert {
	  get { return _doubleWidthHeightIconAlert; }
	  set { _doubleWidthHeightIconAlert=value; OnPropertyChanged(nameof(DoubleWidthHeightIconAlert)); }
	}

	private double _doubleWidthHeightIconOk = 0;

	public double DoubleWidthHeightIconOk {
	  get { return _doubleWidthHeightIconOk; }
	  set { _doubleWidthHeightIconOk=value; OnPropertyChanged(nameof(DoubleWidthHeightIconOk)); }
	}

  }
}
