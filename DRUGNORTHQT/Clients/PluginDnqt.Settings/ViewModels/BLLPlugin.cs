using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;

namespace PluginDnqt.Settings.ViewModels {
  class BLLPlugin {

	internal void ShowValueKeyOnTextbox(ref NounicodeTextBox txtOutput,string strKey) {
	  string strValueKey = "";
	  BLLTools.GetValueFromFileConfig(ref strValueKey,strKey);
	  txtOutput.Text=strValueKey;
	}

  }
}
