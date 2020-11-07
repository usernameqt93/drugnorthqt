using QT.Framework.ToolCommon.Helpers;

namespace QT.Framework.ToolCommon.Models {
  public class ModelBaseDecimal:ModelBase {

	public decimal Value { get; set; } = 0;

	private string _str="";

	public string Str {
	  get { return _str; }
	  set { _str=value;OnPropertyChanged(nameof(Str)); }
	}

  }
}
