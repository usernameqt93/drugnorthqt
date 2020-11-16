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
	  var lstDoublePercentColumn = new List<double>();
	  lstDoublePercentColumn= dicInput["List<double>"] as List<double>;

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

		SetCellFormatPercentByColumnHoaDon(ref documentBuilder,strColName,lstDoublePercentColumn);
		documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;

		lstStringColumnName.Add(strColName);
	  }
	  documentBuilder.EndRow();

	  documentBuilder.Font.Bold=false;

	  foreach(DataRow dRow in dtInput.Rows) {
		foreach(var strColName in lstStringColumnName) {
		  documentBuilder.InsertCell();

		  documentBuilder.Write(dRow[strColName].ToString().Trim());

		  SetCellFormatPercentByColumnHoaDon(ref documentBuilder,strColName,lstDoublePercentColumn);

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
	  double doublePercentColumn = (double)dicInput["double.sliderPercentSdt"];

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
	  documentBuilder.Write("");

	  table.PreferredWidth=PreferredWidth.FromPoints(doubleMaxWidth);

	  documentBuilder.Write("Tên khách hàng: "+(dicInput["string.lblTenKH"] as string));

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("ĐT: "+(dicInput["string.lblSdtKH"] as string));
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(doublePercentColumn);

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	private void SetCellFormatPercentByColumnHoaDon(ref DocumentBuilder documentBuilder,string strColName
	  ,List<double> lstDoublePercentColumn) {
	  switch(strColName) {
		case "STT":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[0]);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Center;
		  break;
		case "Tên vị thuốc":
		  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[1]);
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Số lượng":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[2]);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Đơn vị":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[3]);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Left;
		  break;
		case "Đơn giá":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[4]);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		case "Thành tiền":
		  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[5]);
		  documentBuilder.ParagraphFormat.Alignment=ParagraphAlignment.Right;
		  break;
		default:
		  break;
	  }
	}

	private void GetDocumentTongTienFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  var lstDoublePercentColumn = new List<double>();
	  lstDoublePercentColumn=dicInput["List<double>"] as List<double>;

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

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
	  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write(dicInput["string.lblTongGiaDH"] as string);

	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[5]);

	  documentBuilder.EndRow();

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Số nợ cũ (2):");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
	  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write(dicInput["string.lblTienNoCu"] as string);
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[5]);

	  documentBuilder.EndRow();

	  documentBuilder.InsertCell();
	  documentBuilder.Write("Tổng tiền ((1)+(2)):");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.Auto;
	  //documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(83);

	  documentBuilder.InsertCell();
	  documentBuilder.Write(dicInput["string.lblTongNoVaGiaDH"] as string);
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(lstDoublePercentColumn[5]);

	  documentBuilder.EndRow();

	  documentBuilder.EndTable();

	  table.Alignment=TableAlignment.Center;

	  docTable=docOutput;
	}

	private void GetDocumentThoiGianFromDictionary(ref Document docTable,Dictionary<string,object> dicInput
	  ,double doubleMaxWidth) {
	  double doublePercentColumn = (double)dicInput["double.sliderPercentThoiGian"];

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

	  documentBuilder.Write("");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(doublePercentColumn);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(100-doublePercentColumn*2);

	  documentBuilder.InsertCell();
	  documentBuilder.Write(dicInput["string.lblThoiGian"] as string);
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(doublePercentColumn);

	  documentBuilder.EndRow();

	  documentBuilder.Font.Italic=false;

	  documentBuilder.InsertCell();
	  documentBuilder.Write("NGƯỜI NHẬN HÀNG");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(doublePercentColumn);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(100-doublePercentColumn*2);

	  documentBuilder.InsertCell();
	  documentBuilder.Write("NGƯỜI GIAO HÀNG");
	  documentBuilder.CellFormat.PreferredWidth=PreferredWidth.FromPercent(doublePercentColumn);

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
