using System.Collections.Generic;
using System.ComponentModel;

namespace QT.Framework.ToolCommon.Models {
  public class ModelProgress {

	public double DoublePercent { get; set; } = 0;

	public string StrTitle { get; set; } = "";

	public string StrMessageProgress { get; set; } = "";

	public string StrMessageOutput { get; set; } = "";

	public string StrConfirmOutput { get; set; } = "";

	public object ObjOutput { get; set; }

	public BackgroundWorker BgWorker=new BackgroundWorker();

  }
}
