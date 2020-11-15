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
		string strPathFile = dicInput["string.strPathFile"] as string;
		var docOutput = new Document(strPathFile);
		var dbBuilderAll = new DocumentBuilder(docOutput);
		dbBuilderAll.MoveToDocumentEnd();

		double doublePageWidth = dbBuilderAll.PageSetup.PageWidth;
		int intMarginLeftRight = 10;//đơn vị point
		double doubleMaxWidthTable = doublePageWidth-intMarginLeftRight*2;

		Document docTenKHSdt = null;
		GetDocumentKHSdtFromDictionary(ref docTenKHSdt,dicInput,doubleMaxWidthTable);
		if(docTenKHSdt==null) {
		  throw new Exception("docTenKHSdt chưa được hoàn thành (docTenKHSdt==null)");
		}

		Document docTable = null;
		GetDocumentTableFromDictionary(ref docTable,dicInput,doubleMaxWidthTable);
		if(docTable==null) {
		  throw new Exception("DocumentTable chưa được hoàn thành (docTable==null)");
		}

		Document docTongTien = null;
		GetDocumentTongTienFromDictionary(ref docTongTien,dicInput,doubleMaxWidthTable);
		if(docTongTien==null) {
		  throw new Exception("docTongTien chưa được hoàn thành (docTongTien==null)");
		}

		Document docThoiGian = null;
		GetDocumentThoiGianFromDictionary(ref docThoiGian,dicInput,doubleMaxWidthTable);
		if(docThoiGian==null) {
		  throw new Exception("docThoiGian chưa được hoàn thành (docThoiGian==null)");
		}

		//dbBuilderAll.Font.Size=doubleSize;
		//dbBuilderAll.Font.Name=strFontName;

		//dbBuilderAll.ParagraphFormat.LeftIndent=0.0;
		//dbBuilderAll.ParagraphFormat.RightIndent=0.0;
		//dbBuilderAll.ParagraphFormat.Alignment=ParagraphAlignment.Center;

		//dbBuilderAll.InsertDocument(docTable,ImportFormatMode.UseDestinationStyles);
		dbBuilderAll.InsertDocument(docTenKHSdt,ImportFormatMode.KeepSourceFormatting);
		dbBuilderAll.InsertDocument(docTable,ImportFormatMode.KeepSourceFormatting);
		dbBuilderAll.InsertDocument(docTongTien,ImportFormatMode.KeepSourceFormatting);
		dbBuilderAll.InsertDocument(docThoiGian,ImportFormatMode.KeepSourceFormatting);
		//dbBuilderAll.InsertDocument(docTable,ImportFormatMode.KeepDifferentStyles);

		ShowDocumentWordOnWebBrowser(webView,docOutput,ref exOutput);
	  } catch(Exception ex) {
		exOutput=ex;
	  }
	}

	private void GetDocumentTableFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  var docOutput = new Document();
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  int intSize = (int)dicInput["double.doubleSize"];
	  double doubleSize = intSize;
	  documentBuilder.Font.Size=doubleSize;

	  string strFontName = dicInput["string.strFontName"] as string;
	  documentBuilder.Font.Name=strFontName;

	  documentBuilder.ParagraphFormat.LeftIndent=0.0;
	  documentBuilder.ParagraphFormat.RightIndent=0.0;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.CellFormat.Borders.LineStyle=LineStyle.Single;
	  documentBuilder.CellFormat.Borders.LineWidth=0.3;
	  documentBuilder.CellFormat.Borders.Color=System.Drawing.Color.Gray;

	  documentBuilder.Font.Bold=true;

	  documentBuilder.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
	  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;

	  bool blnChuaThietLapWidthTable = true;

	  var lstStringColumnName = new List<string>();
	  DataTable dtInput = dicInput["DataTable"] as DataTable;
	  foreach(DataColumn dCol in dtInput.Columns) {
		documentBuilder.InsertCell();

		string strColName = dCol.ColumnName;

		documentBuilder.Write(strColName);

		if(blnChuaThietLapWidthTable==true) {
		  table.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth);
		  blnChuaThietLapWidthTable=false;
		}

		//SetCellFormatByColumnNameHoaDon(ref documentBuilder,strColName,doubleMaxWidth);
		SetCellFormatPercentByColumnHoaDon(ref documentBuilder,strColName);
		documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;

		lstStringColumnName.Add(strColName);
	  }
	  documentBuilder.EndRow();

	  documentBuilder.Font.Bold=false;

	  foreach(DataRow dRow in dtInput.Rows) {
		foreach(var strColName in lstStringColumnName) {
		  documentBuilder.InsertCell();

		  documentBuilder.Write(dRow[strColName].ToString().Trim());

		  SetCellFormatPercentByColumnHoaDon(ref documentBuilder,strColName);
		  //SetCellFormatByColumnNameHoaDon(ref documentBuilder,strColName,doubleMaxWidth);

		}

		documentBuilder.EndRow();
	  }

	  documentBuilder.EndTable();

	  //table.AutoFit(AutoFitBehavior.AutoFitToWindow);
	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	private void GetDocumentKHSdtFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  var docOutput = new Document();
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  int intSize = (int)dicInput["double.doubleSize"];
	  double doubleSize = intSize;
	  documentBuilder.Font.Size=doubleSize;

	  string strFontName = dicInput["string.strFontName"] as string;
	  documentBuilder.Font.Name=strFontName;

	  documentBuilder.ParagraphFormat.LeftIndent=0.0;
	  documentBuilder.ParagraphFormat.RightIndent=0.0;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.CellFormat.Borders.LineStyle=LineStyle.None;
	  documentBuilder.CellFormat.Borders.LineWidth=0.3;
	  documentBuilder.CellFormat.Borders.Color=System.Drawing.Color.Gray;

	  documentBuilder.Font.Bold=true;

	  documentBuilder.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
	  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Tên khách hàng: ");

	  table.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth);

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(100);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Công ty dược");

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("ĐT: ");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(25);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("0987.654.321");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(100);

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	private void SetCellFormatByColumnNameHoaDon(ref DocumentBuilder documentBuilder,string strColName
	  ,double doubleMaxWidth) {
	  switch(strColName) {
		case "STT":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(30);
		  //documentBuilder.CellFormat.Width=30;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;
		  break;
		case "Tên vị thuốc":
		  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth-30-50-40-90-90);
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Số lượng":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(50);
		  //documentBuilder.CellFormat.Width=50;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Đơn vị":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(40);
		  //documentBuilder.CellFormat.Width=40;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Đơn giá":
		  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(90);
		  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
		  //documentBuilder.CellFormat.Width=55;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Thành tiền":
		  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPoints(90);
		  //documentBuilder.CellFormat.Width=55;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		default:
		  break;
	  }
	}

	private void SetCellFormatPercentByColumnHoaDon(ref DocumentBuilder documentBuilder,string strColName) {
	  switch(strColName) {
		case "STT":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(7);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;
		  break;
		case "Tên vị thuốc":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(39);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Số lượng":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(12);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Đơn vị":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(10);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Đơn giá":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(15);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Thành tiền":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(17);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		default:
		  break;
	  }
	}

	private void GetDocumentTongTienFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  var docOutput = new Document();
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  int intSize = (int)dicInput["double.doubleSize"];
	  double doubleSize = intSize;
	  documentBuilder.Font.Size=doubleSize;

	  string strFontName = dicInput["string.strFontName"] as string;
	  documentBuilder.Font.Name=strFontName;

	  documentBuilder.ParagraphFormat.LeftIndent=0.0;
	  documentBuilder.ParagraphFormat.RightIndent=0.0;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.CellFormat.Borders.LineStyle=LineStyle.None;
	  documentBuilder.CellFormat.Borders.LineWidth=0.3;
	  documentBuilder.CellFormat.Borders.Color=System.Drawing.Color.Gray;

	  documentBuilder.Font.Bold=true;
	  documentBuilder.Font.Italic=true;

	  documentBuilder.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
	  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Tổng (1):");

	  table.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth);

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("99,999,999 đ");

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(17);

	  documentBuilder.EndRow();

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Số nợ cũ (2):");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("999,999,999 đ");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(17);

	  documentBuilder.EndRow();

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Tổng tiền ((1)+(2)):");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("999,999,999 đ");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(17);

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	private void GetDocumentThoiGianFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  var docOutput = new Document();
	  var documentBuilder = new DocumentBuilder(docOutput);
	  documentBuilder.MoveToDocumentEnd();

	  int intSize = (int)dicInput["double.doubleSize"];
	  double doubleSize = intSize;
	  documentBuilder.Font.Size=doubleSize;

	  string strFontName = dicInput["string.strFontName"] as string;
	  documentBuilder.Font.Name=strFontName;

	  documentBuilder.ParagraphFormat.LeftIndent=0.0;
	  documentBuilder.ParagraphFormat.RightIndent=0.0;

	  Table table = documentBuilder.StartTable();

	  documentBuilder.CellFormat.Borders.LineStyle=LineStyle.None;
	  documentBuilder.CellFormat.Borders.LineWidth=0.3;
	  documentBuilder.CellFormat.Borders.Color=System.Drawing.Color.Gray;

	  documentBuilder.Font.Bold=true;
	  documentBuilder.Font.Italic=true;

	  documentBuilder.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
	  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("");

	  table.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth);

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(60);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Ngày 21 tháng 02 năm 2019");

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(40);

	  documentBuilder.EndRow();

	  documentBuilder.Font.Italic=false;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("NGƯỜI NHẬN HÀNG");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(60);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("NGƯỜI GIAO HÀNG");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(40);

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

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

		string CONST_STR_TEMPORARY_FOLDER_NAME = "TemporaryFiles";
		string strPathFolderTemp = System.Windows.Forms.Application.StartupPath
		  +$"\\{CONST_STR_TEMPORARY_FOLDER_NAME}";
		//string strPathAll = System.IO.Path.GetTempPath();
		string strPathAll = strPathFolderTemp+"\\";
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
