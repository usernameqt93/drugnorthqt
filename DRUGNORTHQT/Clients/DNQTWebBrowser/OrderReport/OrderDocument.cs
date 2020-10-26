using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.Data;
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

	public void ShowWebViewDetailOrderByDictionary(WebBrowser webView,ref Exception exOutput
	  ,Dictionary<string,object> dicInput) {
	  try {
		Document docTable = null;
		GetDocumentTableFromDictionary(ref docTable,dicInput);
		if(docTable==null) {
		  throw new Exception("DocumentTable chưa được hoàn thành (docTable==null)");
		}

		string strPathFile = dicInput["string.strPathFile"] as string;
		var docOutput = new Document(strPathFile);
		var dbBuilderAll = new DocumentBuilder(docOutput);
		dbBuilderAll.MoveToDocumentEnd();

		//dbBuilderAll.Font.Size=doubleSize;
		//dbBuilderAll.Font.Name=strFontName;

		dbBuilderAll.ParagraphFormat.LeftIndent=0.0;
		dbBuilderAll.ParagraphFormat.RightIndent=0.0;
		dbBuilderAll.ParagraphFormat.Alignment=ParagraphAlignment.Center;

		//dbBuilderAll.InsertDocument(docTable,ImportFormatMode.UseDestinationStyles);
		dbBuilderAll.InsertDocument(docTable,ImportFormatMode.KeepSourceFormatting);
		//dbBuilderAll.InsertDocument(docTable,ImportFormatMode.KeepDifferentStyles);

		ShowDocumentWordOnWebBrowser(webView,docOutput,ref exOutput);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	private void GetDocumentTableFromDictionary(ref Document docTable,Dictionary<string,object> dicInput) {
	  var docOutput = new Document();
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  int intSize = (int)dicInput["double.doubleSize"];
	  double doubleSize = intSize;
	  documentBuilder.Font.Size=doubleSize;

	  string strFontName = dicInput["string.strFontName"] as string;
	  documentBuilder.Font.Name=strFontName;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.CellFormat.Borders.LineStyle=LineStyle.Single;
	  documentBuilder.CellFormat.Borders.LineWidth=0.3;
	  documentBuilder.CellFormat.Borders.Color=System.Drawing.Color.Gray;
	  documentBuilder.Font.Bold=true;

	  documentBuilder.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
	  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;

	  var lstStringColumnName = new List<string>();
	  DataTable dtInput = dicInput["DataTable"] as DataTable;
	  foreach(DataColumn dCol in dtInput.Columns) {
		documentBuilder.InsertCell();
		documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;

		string strColName = dCol.ColumnName;
		documentBuilder.Write(strColName);
		lstStringColumnName.Add(strColName);
	  }
	  documentBuilder.EndRow();

	  documentBuilder.Font.Bold=false;

	  foreach(DataRow dRow in dtInput.Rows) {
		foreach(var strColName in lstStringColumnName) {
		  documentBuilder.InsertCell();
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;

		  documentBuilder.Write(dRow[strColName].ToString().Trim());
		}

		documentBuilder.EndRow();
	  }

	  documentBuilder.EndTable();

	  table.AutoFit(AutoFitBehavior.AutoFitToWindow);
	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	public void SetWebBrowserFromPathFileWord(WebBrowser webView,ref Exception exOutput,string strPathFile) {
	  try {
		var docOutput = new Document(strPathFile);
		ShowDocumentWordOnWebBrowser(webView,docOutput,ref exOutput);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void ShowDocumentWordOnWebBrowser(WebBrowser webView,Document docOutput,ref Exception exOutput) {
	  try {
		if(docOutput==null) {
		  throw new Exception("Không nhận diện được file từ đường dẫn (docOutput==null)");
		}

		string strPathAll = System.IO.Path.GetTempPath();
		string strPath = strPathAll+Guid.NewGuid().ToString()+".pdf";
		docOutput.Save(strPath,SaveFormat.Pdf);
		if(webView!=null) {
		  webView.Navigate(strPath);
		}

	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	public void MMMMMMMMMMMMM(WebBrowser webView,ref Exception exOutput,string strPathFile
	  ,double doubleSize,string strFontName) {
	  try {
		Document docTable = null;
		GetDocumentTableFromBBB(ref docTable,doubleSize,strFontName);
		if(docTable==null) {
		  throw new Exception("DocumentTable chưa được hoàn thành (docTable==null)");
		}

		var docOutput = new Document(strPathFile);
		var dbBuilderAll = new DocumentBuilder(docOutput);
		dbBuilderAll.MoveToDocumentEnd();

		dbBuilderAll.Font.Size=doubleSize;
		dbBuilderAll.Font.Name=strFontName;

		dbBuilderAll.ParagraphFormat.Alignment=ParagraphAlignment.Center;

		dbBuilderAll.InsertDocument(docTable,ImportFormatMode.UseDestinationStyles);

		ShowDocumentWordOnWebBrowser(webView,docOutput,ref exOutput);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	private void GetDocumentTableFromBBB(ref Document docTable,double doubleSize,string strFontName) {
	  var docOutput = new Document();
	  //var dbBuilderAll = new DocumentBuilder(docOutput);
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  documentBuilder.Font.Size=doubleSize;
	  documentBuilder.Font.Name=strFontName;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.InsertCell();
	  documentBuilder.CellFormat.Width=30;

	  documentBuilder.Write("Quoc Tuan 30");

	  documentBuilder.InsertCell();
	  documentBuilder.CellFormat.Width=50;

	  documentBuilder.Write("Quoc Tuan 50");

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

	  table.AutoFit(AutoFitBehavior.FixedColumnWidths);
	  //table.ClearBorders();
	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

  }
}
