using QT.Framework.ToolCommon.Helpers;

namespace QT.Framework.ToolCommon.Models {
  public class ModelBaseRow:ModelBase {

	private int _stt = 0;

	public int Stt {
	  get { return _stt; }
	  set { _stt=value; OnPropertyChanged(nameof(Stt)); }
	}

	private object _objItem;

	public object ObjItem {
	  get { return _objItem; }
	  set { _objItem=value; OnPropertyChanged(nameof(ObjItem)); }
	}

	private bool? _selected = false;
	public bool? Selected {
	  get { return _selected; }
	  set { _selected=value; OnPropertyChanged(nameof(Selected)); }
	}

	#region 11 cell base

	private ModelBaseCell _mbc000 = new ModelBaseCell();

	public ModelBaseCell MBC000 {
	  get { return _mbc000; }
	  set { _mbc000=value; OnPropertyChanged(nameof(MBC000)); }
	}

	private ModelBaseCell _mbc001 = new ModelBaseCell();

	public ModelBaseCell MBC001 {
	  get { return _mbc001; }
	  set { _mbc001=value; OnPropertyChanged(nameof(MBC001)); }
	}

	private ModelBaseCell _mbc002 = new ModelBaseCell();

	public ModelBaseCell MBC002 {
	  get { return _mbc002; }
	  set { _mbc002=value; OnPropertyChanged(nameof(MBC002)); }
	}

	private ModelBaseCell _mbc003 = new ModelBaseCell();

	public ModelBaseCell MBC003 {
	  get { return _mbc003; }
	  set { _mbc003=value; OnPropertyChanged(nameof(MBC003)); }
	}

	private ModelBaseCell _mbc004 = new ModelBaseCell();

	public ModelBaseCell MBC004 {
	  get { return _mbc004; }
	  set { _mbc004=value; OnPropertyChanged(nameof(MBC004)); }
	}

	private ModelBaseCell _mbc005 = new ModelBaseCell();

	public ModelBaseCell MBC005 {
	  get { return _mbc005; }
	  set { _mbc005=value; OnPropertyChanged(nameof(MBC005)); }
	}

	private ModelBaseCell _mbc006 = new ModelBaseCell();

	public ModelBaseCell MBC006 {
	  get { return _mbc006; }
	  set { _mbc006=value; OnPropertyChanged(nameof(MBC006)); }
	}

	private ModelBaseCell _mbc007 = new ModelBaseCell();

	public ModelBaseCell MBC007 {
	  get { return _mbc007; }
	  set { _mbc007=value; OnPropertyChanged(nameof(MBC007)); }
	}

	private ModelBaseCell _mbc008 = new ModelBaseCell();

	public ModelBaseCell MBC008 {
	  get { return _mbc008; }
	  set { _mbc008=value; OnPropertyChanged(nameof(MBC008)); }
	}

	private ModelBaseCell _mbc009 = new ModelBaseCell();

	public ModelBaseCell MBC009 {
	  get { return _mbc009; }
	  set { _mbc009=value; OnPropertyChanged(nameof(MBC009)); }
	}

	private ModelBaseCell _mbc010 = new ModelBaseCell();

	public ModelBaseCell MBC010 {
	  get { return _mbc010; }
	  set { _mbc010=value; OnPropertyChanged(nameof(MBC010)); }
	}

	private ModelBaseCell _mbc011 = new ModelBaseCell();

	public ModelBaseCell MBC011 {
	  get { return _mbc011; }
	  set { _mbc011=value; OnPropertyChanged(nameof(MBC011)); }
	} 

	#endregion

	public void SetValueCell(int intIndex,ModelBaseCell mbcInput) {
	  switch(intIndex) {
		case 0:
		  MBC000=mbcInput;
		  break;
		case 1:
		  MBC001=mbcInput;
		  break;
		case 2:
		  MBC002=mbcInput;
		  break;
		case 3:
		  MBC003=mbcInput;
		  break;
		case 4:
		  MBC004=mbcInput;
		  break;
		case 5:
		  MBC005=mbcInput;
		  break;
		case 6:
		  MBC006=mbcInput;
		  break;
		case 7:
		  MBC007=mbcInput;
		  break;
		case 8:
		  MBC008=mbcInput;
		  break;
		case 9:
		  MBC009=mbcInput;
		  break;
		case 10:
		  MBC010=mbcInput;
		  break;
		case 11:
		  MBC011=mbcInput;
		  break;
		default:
		  break;
	  }
	}

  }
}
