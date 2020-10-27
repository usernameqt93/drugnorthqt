using BasicArrayProcessorSDK;
using DNQTConstTable;
using PluginDnqt.Product.Views;
using QT.Framework.ToolCommon;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PluginDnqt.Product {
  [ArrayProcessorPlugIn("2","Quản lý vị thuốc","1|4|Phạm Quốc Tuấn","leaf-icon49x49.png","1.0.0",1,"1")]
  public class ConnectionSDK:IArrayProcessor {
	private static IHostProcessor _mHostViewer;
	private ArrayProcessorPlugInAttribute _mAttributes;

	private static IDictionary<string,object> dicInputOriginal;
	internal static int INT_SO_ROW_1PAGE_PLUGIN = 50;

	public void Process(IDictionary<string,object> key) {
	  dicInputOriginal=key;

	  string strValueKey = "";
	  BLLTools.GetValueFromFileConfig(ref strValueKey,KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_PRODUCT.STR);
	  if(Int32.TryParse(strValueKey,out int intSoDong1Trang)) {
		if(intSoDong1Trang>=50&&intSoDong1Trang<101) {
		  INT_SO_ROW_1PAGE_PLUGIN=intSoDong1Trang;
		}
	  }

	  // Gọi form ở đây
	  var _content = key["content"] as Grid;
	  //var _wMain = new MainWindow();

	  var _wMain = new MainWindow();
	  _content.Children.Add(_wMain);
	  _mHostViewer.Report("Ascending Array Sorted.");
	}

	public static void ResetProcess() {
	  IDictionary<string,object> key = dicInputOriginal;

	  var _content = key["content"] as Grid;
	  _content.Children.Clear();

	  var _wMain = new MainWindow();
	  _content.Children.Add(_wMain);
	  _mHostViewer.Report("Ascending Array Sorted.");
	}

	public void Initialize(IHostProcessor host) {
	  _mHostViewer=host;
	}

	public void Dispose() {
	  _mAttributes=null;
	}

	public ArrayProcessorPlugInAttribute Attributes {
	  get { return _mAttributes; }
	  set { _mAttributes=value; }
	}
  }
}
