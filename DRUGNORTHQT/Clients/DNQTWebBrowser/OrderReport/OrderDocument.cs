using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNQTWebBrowser.OrderReport {
  public class OrderDocument {

	public OrderDocument() {
	  new Aspose.Words.License().SetLicense(LicenseHelper.License.LStream);
	}

	public void GetDocumentDetailOrderByDictionary(ref Document docOutput,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {

	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	//public void GetDocumentFromPathFile(ref Document docOutput,ref Exception exOutput,string strPathFile) {
	//  try {
	//	docOutput = new Document(strPathFile);
	//	if(docOutput!=null) {
	//	  var pathAll = System.IO.Path.GetTempPath();
	//	  var path = pathAll+Guid.NewGuid().ToString()+".pdf";
	//	  docOutput.Save(path,SaveFormat.Pdf);
	//	  _mainUserControl.webView.Navigate(path);
	//	}

	//  } catch(Exception ex) {
	//	exOutput=ex;
	//  }
	//}

	public void SetWebBrowserFromPathFile(WebBrowser webView,ref Exception exOutput,string strPathFile) {
	  try {
		Document docOutput=new Document(strPathFile);
		if(docOutput!=null) {
		  var pathAll = System.IO.Path.GetTempPath();
		  var path = pathAll+Guid.NewGuid().ToString()+".pdf";
		  docOutput.Save(path,SaveFormat.Pdf);
		  if(webView!=null) {
			webView.Navigate(path); 
		  }
		}

	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}
  }
}
