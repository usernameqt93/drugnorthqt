using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace WindowMain.Model {
  public class ModelHamburgerMenu:ModelBase {

	private int _ItemID;

	public int ItemID {
	  get { return _ItemID; }
	  set { _ItemID = value;OnPropertyChanged(nameof(ItemID)); }
	}

	private int _ParentID;

	public int ParentID {
	  get { return _ParentID; }
	  set { _ParentID = value;OnPropertyChanged(nameof(ParentID)); }
	}

	private int _intHeightWidthButton=90;

	public int IntHeightWidthButton {
	  get { return _intHeightWidthButton; }
	  set { _intHeightWidthButton = value;OnPropertyChanged(nameof(IntHeightWidthButton)); }
	}

	private int _intHeightWidthImage=35;

	public int IntHeightWidthImage {
	  get { return _intHeightWidthImage; }
	  set { _intHeightWidthImage = value;OnPropertyChanged(nameof(IntHeightWidthImage)); }
	}

	private int _intIndexColor=0;

	public int IntIndexColor {
	  get { return _intIndexColor; }
	  set { _intIndexColor = value;OnPropertyChanged(nameof(IntIndexColor)); }
	}

	private string _strColor = "Orange";
	//private string _strColor= "#FF058624";//Màu Hương Việt
	//private string _strColor= "#FF3C72A2";//Màu Sao Sài Gòn

	public string StrColor {
	  get { return _strColor; }
	  set { _strColor = value;OnPropertyChanged(nameof(StrColor)); }
	}

	private string _Text="";    

	public string Text {
	  get { return _Text; }
	  set { _Text = value;OnPropertyChanged(nameof(Text)); }
	}

	private string _strTextOriginal = "";

	public string StrTextOriginal {
	  get { return _strTextOriginal; }
	  set { _strTextOriginal = value;OnPropertyChanged(nameof(StrTextOriginal)); }
	}

	private ImageSource _Icon; 

	public ImageSource Icon {
	  get { return _Icon; }
	  set { _Icon = value;OnPropertyChanged(nameof(Icon)); }
	}

	private ICommand _SelectionCommand;

	public ICommand SelectionCommand {
	  get { return _SelectionCommand; }
	  set { _SelectionCommand = value;OnPropertyChanged(nameof(SelectionCommand)); }
	}

	private object _SelectionCommandParameter;

	public object SelectionCommandParameter {
	  get { return _SelectionCommandParameter; }
	  set { _SelectionCommandParameter = value;OnPropertyChanged(nameof(SelectionCommandParameter)); }
	}

	private double _doubleAngleToSpin=0.0;

	public double DoubleAngleToSpin {
	  get { return _doubleAngleToSpin; }
	  set { _doubleAngleToSpin = value;OnPropertyChanged(nameof(DoubleAngleToSpin)); }
	}

	private double _doubleAngleOnCircle=0.0;

	public double DoubleAngleOnCircle {
	  get { return _doubleAngleOnCircle; }
	  set { _doubleAngleOnCircle = value;OnPropertyChanged(nameof(DoubleAngleOnCircle)); }
	}

  }  
}
