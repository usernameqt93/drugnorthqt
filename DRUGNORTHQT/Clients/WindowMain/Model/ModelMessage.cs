using QT.Framework.ToolCommon.Models;

namespace WindowMain.Model {
  class ModelMessage:ModelBaseDataGrid {

	private int _intId=0;

	public int IntId {
	  get { return _intId; }
	  set { _intId = value;OnPropertyChanged(nameof(IntId)); }
	}

	private string _strTaiKhoanGui="";

	public string StrTaiKhoanGui {
	  get { return _strTaiKhoanGui; }
	  set { _strTaiKhoanGui = value;OnPropertyChanged(nameof(StrTaiKhoanGui)); }
	}

	private int _intMessageType=0;

	public int IntMessageType {
	  get { return _intMessageType; }
	  set { _intMessageType = value;OnPropertyChanged(nameof(IntMessageType)); }
	}

	private string _strMessageType="";

	public string StrMessageType {
	  get { return _strMessageType; }
	  set { _strMessageType = value;OnPropertyChanged(nameof(StrMessageType)); }
	}

	private string _rtf = "";

	public string Rtf {
	  get { return _rtf; }
	  set { _rtf = value; OnPropertyChanged(nameof(Rtf)); }
	}

	private string _strText = "";

	public string StrText {
	  get { return _strText; }
	  set { _strText = value; OnPropertyChanged(nameof(StrText)); }
	}

  }
}
