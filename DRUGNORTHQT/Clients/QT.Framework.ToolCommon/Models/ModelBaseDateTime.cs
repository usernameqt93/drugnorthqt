using QT.Framework.ToolCommon.Helpers;
using System;

namespace QT.Framework.ToolCommon.Models {
  public class ModelBaseDateTime:ModelBase {

	public DateTime Value { get; set; } = new DateTime(1993,11,13);

	private string _str = "";

	public string Str {
	  get { return _str; }
	  set { _str=value; OnPropertyChanged(nameof(Str)); }
	}

  }
}
