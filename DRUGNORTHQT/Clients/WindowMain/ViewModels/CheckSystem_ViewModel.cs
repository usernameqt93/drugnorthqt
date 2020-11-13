using DNQTDataAccessLayer.DALNew;
using log4net;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using WindowMain.View;

namespace WindowMain.ViewModels {
  class CheckSystem_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	internal CheckSystem _mainUserControl;

	private Dictionary<string,object> DicData;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private DAL_Account DALAccount = new DAL_Account();

	#region === Những thuộc tính binding ===

	#region Variables for loading

	private bool _blnHideMain = false;

	public bool BlnHideMain {
	  get { return _blnHideMain; }
	  set { _blnHideMain=value; OnPropertyChanged(nameof(BlnHideMain)); }
	}

	#endregion

	#endregion

	#endregion

	#region === Handle ===

	public CheckSystem_ViewModel(CheckSystem _viewMain,Dictionary<string,object> dicData) {
	  _mainUserControl=_viewMain;
	  //MainCollection.Source=_lstGridMain;
	  DicDataInPreviousUC=dicData as Dictionary<string,object>;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)DicDataInPreviousUC["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  DicData=dicData;

	  LoadForm();
	}

	#endregion

	#region === Các hàm chung ===

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dic) {
	  try {

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadForm() {
	  try {
		LoadControlDefault();

		LoadData();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		var lstStringKey = new List<string>();
		lstStringKey.Add("IpPortConnect");

		var lstTupleKeyValueCurrent = new List<Tuple<string,string>>();
		_bllPlugin.GetListTupleValueFromListKeyFromConfig(ref lstTupleKeyValueCurrent,lstStringKey);

		int intSumValueBlank = 0;
		var lstTupleKeyValueIfBlank = new List<Tuple<string,string,string>>();
		foreach(var item in lstTupleKeyValueCurrent) {
		  string strKey = item.Item1;
		  string strValueKey = item.Item2;
		  string strNote = "";
		  if(strValueKey=="") {
			intSumValueBlank++;
			strValueKey=_bllPlugin.Base64Encode(strKey);
			strNote="(Create because blank)";
		  }

		  lstTupleKeyValueIfBlank.Add(new Tuple<string,string,string>(strKey,strValueKey,strNote));
		}

		string strCurrentConfig = "Current config:";
		foreach(var item in lstTupleKeyValueIfBlank) {
		  if(item.Item2=="") {
			BLLTools.ChangeValueOfKeyInFileConfig(item.Item1,item.Item2); 
		  }
		  strCurrentConfig+=$"\n+{item.Item1}: {item.Item2} {item.Item3}";
		}

		_mainUserControl.rtbAllConfig.Document.Blocks.Clear();
		_mainUserControl.rtbAllConfig.Document.Blocks.Add(new Paragraph(new Run(strCurrentConfig)));
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadControlDefault() {
	  try {
		//_mainUserControl.gridTxtMauTieuDeBQ.txtText.Text="Bản quyền cấp cho {0}";
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand GiaiMaCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!="quoctuan931113") {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		try {
		  _mainUserControl.txtDecode.Text=_bllPlugin.Base64Decode(_mainUserControl.txtEncode.Text);
		} catch(Exception e) {
		  string str = e.Message;
		  _mainUserControl.txtDecode.Text="Error";
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand MaHoaCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!="quoctuan931113") {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		try {
		  _mainUserControl.txtEncode.Text=_bllPlugin.Base64Encode(_mainUserControl.txtDecode.Text);
		} catch(Exception e) {
		  string str = e.Message;
		  _mainUserControl.txtEncode.Text="Error";
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand TestConnectionByStringCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!="quoctuan931113") {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		bool blnSuccess = false;
		string strConnection = _mainUserControl.txtDecode.Text.Trim();
		DALAccount.CheckConnectionDbFromString(ref blnSuccess,strConnection);
		_mainUserControl.chkStatusConnectionString.IsChecked=blnSuccess;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand TestConnectionCommand => new DelegateCommand(p => {
	  try {
		bool blnSuccess = false;
		DALAccount.CheckConnectionDbFromConfig(ref blnSuccess);
		_mainUserControl.chkStatusConnection.IsChecked=blnSuccess;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand SetValueKeyIpConnectCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!="quoctuan931113") {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		BLLTools.ChangeValueOfKeyInFileConfig("IpPortConnect"
		  ,_mainUserControl.txtEncode.Text.Trim());
		QTMessageBox.ShowNotify("Set key success!");

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand LoadedCommand => new DelegateCommand(p => {
	  try {

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
