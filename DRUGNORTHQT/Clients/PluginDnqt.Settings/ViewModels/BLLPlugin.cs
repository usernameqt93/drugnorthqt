using QT.Framework.ToolCommon.Helpers;
using System.Configuration;
using System.Linq;

namespace PluginDnqt.Settings.ViewModels {
  class BLLPlugin {

	#region Get và set value in file config

	/// <summary>
	/// Kiểm tra giá trị của key trong file config, nếu có key thì xóa đi và thêm mới giá trị key và value
	/// </summary>
	/// <param name="strKey"></param>
	/// <param name="strValue"></param>
	internal void ChangeValueOfKeyInFileConfig(string strKey,string strValue) {
	  Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	  if(_config.AppSettings.Settings.AllKeys.Contains(strKey)) {
		_config.AppSettings.Settings.Remove(strKey);
	  }
	  _config.AppSettings.Settings.Add(strKey,strValue);
	  ConfigurationManager.RefreshSection("appSettings");
	  _config.Save(ConfigurationSaveMode.Modified);
	  ConfigurationManager.RefreshSection(_config.AppSettings.SectionInformation.Name);
	  Properties.Settings.Default.Reload();
	}

	/// <summary>
	/// Lấy giá trị value A của key B trong file config, nếu không có key thì không làm gì Output
	/// </summary>
	/// <param name="strOutputValue"></param>
	/// <param name="strKey"></param>
	internal void GetValueFromFileConfig(ref string strOutputValue,string strKey) {
	  if(System.Configuration.ConfigurationManager.AppSettings[strKey]!=null) {
		strOutputValue=System.Configuration.ConfigurationManager.AppSettings[strKey];
	  }
	}

	#endregion

	internal void ShowValueKeyOnTextbox(ref NounicodeTextBox txtOutput,string strKey) {
	  string strValueKey = "";
	  GetValueFromFileConfig(ref strValueKey,strKey);
	  txtOutput.Text=strValueKey;
	}

  }
}
