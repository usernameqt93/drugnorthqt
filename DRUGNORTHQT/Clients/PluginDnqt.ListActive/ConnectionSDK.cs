﻿using BasicArrayProcessorSDK;
using PluginDnqt.ListActive.Views;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PluginDnqt.ListActive {
  [ArrayProcessorPlugIn("8","Mã kích hoạt","1|12|Phạm Quốc Tuấn","ProductLicense.png","1.0.0",1,"1")]
  public class ConnectionSDK:IArrayProcessor {
	private static IHostProcessor _mHostViewer;
	private ArrayProcessorPlugInAttribute _mAttributes;

	private static IDictionary<string,object> dicInputOriginal;

	public void Process(IDictionary<string,object> key) {
	  dicInputOriginal=key;

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
