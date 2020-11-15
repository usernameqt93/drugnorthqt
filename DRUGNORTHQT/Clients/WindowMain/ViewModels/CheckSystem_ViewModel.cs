using DNQTDataAccessLayer.DALNew;
using log4net;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Data;
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
	private const string STR_PASS = "quoctuan931113";
	private int _ctrl_count = 0;

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
		string strValueKey = "";
		BLLTools.GetValueFromFileConfig(ref strValueKey,"linkActive");
		_mainUserControl.webView.Navigate(strValueKey);

		string strQuery = "";
		strQuery +=@"SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BangAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](3000) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ModifyTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BangAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BangAccount] ADD  CONSTRAINT [DF_BangAccount_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
";

		strQuery+=@"
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BangGiaHan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAccount] [int] NOT NULL,
	[StartTimeUse] [datetime] NOT NULL,
	[EndTimeUse] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[JsonKeyGiaHanGiaiMa] [nvarchar](3000) NOT NULL,
	[KeyGiaHanMaHoa] [nvarchar](3000) NOT NULL,
 CONSTRAINT [PK_BangGiaHan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO";
		_mainUserControl.rtbQuery.Document.Blocks.Clear();
		_mainUserControl.rtbQuery.Document.Blocks.Add(new Paragraph(new Run(strQuery)));
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
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
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
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
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
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
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
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
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

	public ICommand CreateAccountCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		string strUserName = _mainUserControl.txtAccount.Text.Trim();
		if(strUserName.Length<7) {
		  QTMessageBox.ShowNotify("Username phải từ 7 kí tự trở lên!");
		  return;
		}

		var dicInput = new Dictionary<string,object>();
		dicInput["string.strUserName"]=strUserName;
		dicInput["string.strPassword"]=_bllPlugin.Base64Encode(strUserName);

		{
		  var dicOutput = new Dictionary<string,object>();
		  Exception exOutput = null;
		  DALAccount.AddAccount(ref dicOutput,ref exOutput,dicInput);
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }

		  string strKeyError = "string";
		  if(dicOutput.ContainsKey(strKeyError)) {
			QTMessageBox.ShowNotify(
			  "Tạo account không thành công, bạn vui lòng thử lại!"
			  ,dicOutput[strKeyError] as string);
			return;
		  }
		}

		QTMessageBox.ShowNotify("THAO TÁC THÀNH CÔNG!");

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand CreateJsonKeyGiaHanCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.txtPassKeyBox.Password!=STR_PASS) {
		  QTMessageBox.ShowNotify("Key không hợp lệ!");
		  return;
		}

		string strUserName = _mainUserControl.txtAccount.Text.Trim();
		if(strUserName.Length<7) {
		  QTMessageBox.ShowNotify("Username phải từ 7 kí tự trở lên!");
		  return;
		}

		var dicInput = new Dictionary<string,object>();
		dicInput["string.strUserName"]=strUserName;
		dicInput["DateTime.dtpStart"]=_mainUserControl.dtpStart.Value;
		dicInput["DateTime.dtpEnd"]=_mainUserControl.dtpEnd.Value;
		dicInput["DateTime.dtpNgaySuDung"]=_mainUserControl.dtpNgaySuDung.Value;

		string strJsonToSave = Newtonsoft.Json.JsonConvert.SerializeObject(dicInput
			  ,Newtonsoft.Json.Formatting.Indented);

		_mainUserControl.txtDecode.Text=strJsonToSave;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand KichHoatGiaHanCommand => new DelegateCommand(p => {
	  try {
		string strUserName = _mainUserControl.txtAccountGiaHan.Text.Trim();
		if(strUserName.Length<7) {
		  QTMessageBox.ShowNotify("Tên đăng nhập phải từ 7 kí tự trở lên!");
		  return;
		}

		string strMaGiaHan = _mainUserControl.txtMaGiaHan.Text.Trim();
		if(strMaGiaHan.Length<50) {
		  QTMessageBox.ShowNotify("Mã gia hạn không hợp lệ, bạn vui lòng kiểm tra lại!"
			,"(strMaGiaHan.Length<50)");
		  return;
		}

		string strJsonDictionary = "";
		try {
		  strJsonDictionary=_bllPlugin.Base64Decode(strMaGiaHan);
		} catch(Exception e) {
		  string str = e.Message;
		  QTMessageBox.ShowNotify("Mã gia hạn không phải từ đơn vị cung cấp, bạn vui lòng kiểm tra lại!"
			,"Exception decode");
		  return;
		}

		var dicInFile = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);
		if(dicInFile==null) {
		  QTMessageBox.ShowNotify("Mã gia hạn chưa được tạo chính xác, vui lòng tạo lại mã khác!"
			,"(dicInFile==null)");
		  return;
		}

		string strUserNameChuan = dicInFile["string.strUserName"] as string;
		if(strUserNameChuan!=strUserName) {
		  QTMessageBox.ShowNotify("Mã gia hạn này đã được kích hoạt cho tài khoản khác, vui lòng kiểm tra lại!"
			,"(strUserNameChuan!=strUserName)");
		  return;
		}

		DateTime dtNgaySuDung = (DateTime)dicInFile["DateTime.dtpNgaySuDung"];
		TimeSpan interval = DateTime.Now.Subtract(dtNgaySuDung);
		if(interval.Days!=0) {
		  QTMessageBox.ShowNotify("Mã gia hạn này đã được kích hoạt ở thời gian khác, vui lòng kiểm tra lại!"
			,"(interval.Days!=0)");
		  return;
		}

		var lstStringUser = new List<string>();
		lstStringUser.Add(strUserNameChuan);

		DataTable DT_AccountByListName = null;
		{
		  Exception exOutput = null;
		  DALAccount.GetDTAccountByListName(ref DT_AccountByListName,ref exOutput,lstStringUser);
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }
		}

		if(DT_AccountByListName==null||DT_AccountByListName.Rows.Count==0) {
		  QTMessageBox.ShowNotify(
			"Hiện tại chưa tải được dữ liệu của tên đăng nhập này, bạn vui lòng thao tác lại!"
			,"(DT_AccountByListName==null)");
		  return;
		}

		string strIdAccount = ""+DT_AccountByListName.Rows[0]["Id"].ToString();

		var dicInput = new Dictionary<string,object>(dicInFile);
		dicInput["string.strIdAccount"]=strIdAccount;
		dicInput["string.strJsonDictionary"]=strJsonDictionary;
		dicInput["string.strMaGiaHan"]=strMaGiaHan;

		{
		  var dicOutput = new Dictionary<string,object>();
		  Exception exOutput = null;
		  DALAccount.AddGiaHanIdAccount(ref dicOutput,ref exOutput,dicInput);
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }

		  string strKeyError = "string";
		  if(dicOutput.ContainsKey(strKeyError)) {
			QTMessageBox.ShowNotify(
			  "Kích hoạt mã gia hạn không thành công, bạn vui lòng thử lại!"
			  ,dicOutput[strKeyError] as string);
			return;
		  }
		}

		QTMessageBox.ShowNotify("Thao tác thành công!");

		System.Windows.Forms.Application.Restart();
		System.Diagnostics.Process.GetCurrentProcess().Kill();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand F1KeyUpCommand => new DelegateCommand(p => {
	  try {
		_ctrl_count++;
		if(_ctrl_count>5) {
		  _mainUserControl.stackPanelSecret.Visibility=System.Windows.Visibility.Visible;
		  _ctrl_count =0;
		} else {
		  _mainUserControl.stackPanelSecret.Visibility=System.Windows.Visibility.Collapsed;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand LoadedCommand => new DelegateCommand(p => {
	  try {
		F1KeyUpCommand.Execute(null);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
