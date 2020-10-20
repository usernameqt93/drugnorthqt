using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace QT.Framework.ToolCommon.Helpers {
  public class F1KeyUpEventTrigger:EventTrigger {
	public F1KeyUpEventTrigger() : base("KeyUp") {
	}

	protected override void OnEvent(EventArgs eventArgs) {
	  var e = eventArgs as KeyEventArgs;
	  if(e != null && e.Key == Key.F1)
		this.InvokeActions(eventArgs);
	}
  }
}
