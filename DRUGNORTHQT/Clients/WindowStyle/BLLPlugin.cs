using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowStyle {
  public class BLLPlugin {

	public void ChangeColorInFileConfigStyle(string strColorXanhDam,
	  string strColorXanhNhat,string strColorXanhNhatHon) {
	  Properties.Settings.Default.ColorXanhDam=strColorXanhDam;
	  Properties.Settings.Default.ColorXanhNhat=strColorXanhNhat;
	  Properties.Settings.Default.ColorXanhNhatHon=strColorXanhNhatHon;
	  Properties.Settings.Default.Save();
	}

  }
}
