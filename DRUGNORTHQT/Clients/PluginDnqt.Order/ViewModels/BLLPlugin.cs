using DNQTConstTable.ListTableDatabase;
using DNQTDataAccessLayer.DALNew;
using PluginDnqt.Order.Models;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Controls;

namespace PluginDnqt.Order.ViewModels {
  class BLLPlugin {

	private DAL_Product DALProduct = new DAL_Product();

	private DateTime DTimeMacDinh = new DateTime(1993,11,13);

	#region Function for Loading

	internal void ShowPopupLoading(ref PopupLoading LoadingUC,ref Grid gridPopup) {
	  gridPopup.Children.Clear();
	  LoadingUC=new PopupLoading();
	  gridPopup.Width=LoadingUC.Width;
	  gridPopup.Height=LoadingUC.Height;
	  gridPopup.Children.Add(LoadingUC);
	}

	internal void ChangeInfoLoading(ref PopupLoading loadingUC,ModelProgress mpProgress) {
	  double doubleTemp = Math.Round(mpProgress.DoublePercent,2);
	  loadingUC.controlLoading.StrValue=""+doubleTemp+"%";
	  loadingUC.txtTitle.Content=mpProgress.StrTitle;
	  loadingUC.txtMessage.Text=mpProgress.StrMessageProgress;
	}

	internal void StartBgWorkerDoWork(ref DoWorkEventArgs e,ref ModelProgress mPProgress,
	  double doublePercent,string strTitle,string strMessage) {
	  BLLTools.ReportProgressWorker(ref mPProgress,doublePercent,strTitle,strMessage);
	  //e.Cancel=true;
	}

	#endregion

	internal void GetListStringIdInDataTable(ref List<string> lstStringId,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput,string strNameColumn) {
	  lstStringId=new List<string>();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  for(int i = intStartIndex;i<intEndIndex;i++) {
		lstStringId.Add(dtInput.Rows[i][strNameColumn].ToString());
	  }
	}

	//internal void LoadGridMainByDataTable(ref ObservableCollection<ModelRowOrder> lstGridMain
	//  ,DataTable dtInput) {
	//  lstGridMain.Clear();

	//  int intStartIndex = 0;
	//  int intEndIndex = dtInput.Rows.Count;

	//  int intIndexIncrease = 0;
	//  for(int i = intStartIndex;i<intEndIndex;i++) {
	//	var mitem = new ModelRowOrder();
	//	mitem.Stt=++intIndexIncrease;

	//	mitem.StrId=""+dtInput.Rows[i][Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();
	//	mitem.StrNameKH=""+dtInput.Rows[i][Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();

	//	{
	//	  string strTemp = "Định dạng TG False";
	//	  DateTime objTemp = CVPConstValuePlugin.DTimeMacDinh;
	//	  try {
	//		objTemp=Convert.ToDateTime(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
	//		strTemp=objTemp.ToString("yyyy-MM-dd HH:mm:ss");
	//	  } catch(Exception e) {
	//		string str = e.Message;
	//	  }
	//	  mitem.DTimeViet=objTemp;
	//	  mitem.StrDTimeViet=strTemp;
	//	}

	//	try {
	//	  mitem.IntSumProduct=Convert.ToInt32(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongViThuoc.NAME]);
	//	} catch(Exception e) {
	//	  string str = e.Message;
	//	}

	//	{
	//	  string strTemp = "Định dạng Float False";
	//	  float objTemp = 0;
	//	  try {
	//		objTemp=Convert.ToSingle(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongKhoiLuong.NAME]);
	//		//strTemp=string.Format("{0:N3}",objTemp);
	//		strTemp=string.Format("{0:0.###}",objTemp);
	//	  } catch(Exception e) {
	//		string str = e.Message;
	//	  }
	//	  mitem.FloatSumKg=objTemp;
	//	  mitem.StrSumKg=strTemp;
	//	}

	//	{
	//	  string strTemp = "Định dạng Decimal False";
	//	  decimal objTemp = 0;
	//	  try {
	//		objTemp=Convert.ToDecimal(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongGiaTriDonHang.NAME]);
	//		//strTemp=string.Format("{0:N3}",objTemp);
	//		strTemp=string.Format("{0:0,0}",objTemp)+" đ";
	//		//strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
	//	  } catch(Exception e) {
	//		string str = e.Message;
	//	  }
	//	  mitem.DecimalSumGiaTri=objTemp;
	//	  mitem.StrSumGiaTri=strTemp;
	//	}

	//	mitem.Selected=false;
	//	lstGridMain.Add(mitem);
	//  }
	//}

	internal void LoadGridChiTietDHByDataTable(ref ObservableCollection<ModelRowDetailOrder> lstGridMain
	  ,DataTable dtInput,string strIdOrder) {
	  lstGridMain.Clear();

	  int intStartIndex = 0;
	  int intEndIndex = dtInput.Rows.Count;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		string strIdOrderInTable = ""+dtInput.Rows[i][Table_BangChiTietDonHang.Col_MaDonHang.NAME].ToString();
		if(strIdOrderInTable!=strIdOrder) {
		  continue;
		}

		var mitem = new ModelRowDetailOrder();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][Table_BangChiTietDonHang.Col_MaChiTietDonHang.NAME].ToString().Trim();
		mitem.StrNameDrug=""+dtInput.Rows[i][Table_BangViThuoc.Col_TenViThuoc.NAME].ToString().Trim();

		{
		  string strTemp = "Định dạng Float False";
		  float objTemp = 0;
		  try {
			objTemp=Convert.ToSingle(dtInput.Rows[i][Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME]);
			strTemp=string.Format("{0:N3}",objTemp);
			//strTemp=string.Format("{0:0.###}",objTemp);
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.FloatSumKg=objTemp;
		  mitem.StrSumKg=strTemp;
		}

		mitem.StrDonVi=""+dtInput.Rows[i][Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME].ToString().Trim();

		{
		  string strTemp = "Định dạng Decimal False";
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(dtInput.Rows[i][Table_BangGiaViThuoc.Col_GiaViThuoc.NAME]);
			//strTemp=string.Format("{0:N3}",objTemp);
			strTemp=string.Format("{0:0,0}",objTemp)+" đ";
			//strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DecimalDonGia=objTemp;
		  mitem.StrDonGia=strTemp;
		}

		{
		  string strTemp = "Định dạng Decimal False";
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(dtInput.Rows[i][Table_BangChiTietDonHang.Col_ThanhTienTamThoi.NAME]);
			//strTemp=string.Format("{0:N3}",objTemp);
			strTemp=string.Format("{0:0,0}",objTemp)+" đ";
			//strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DecimalThanhTien=objTemp;
		  mitem.StrThanhTien=strTemp;
		}

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	internal void GetDataTableReportFromGridMain(ref DataTable dtReport
	  ,ref List<Tuple<string,int,string>> lstTupleMaxCharInColumn
	  ,ObservableCollection<ModelRowDetailOrder> lstGridMain) {
	  var lstStringNameColumn = new List<string>();
	  lstStringNameColumn.Add("STT");
	  lstStringNameColumn.Add("Tên vị thuốc");
	  lstStringNameColumn.Add("Số lượng");
	  lstStringNameColumn.Add("Đơn vị");
	  lstStringNameColumn.Add("Đơn giá");
	  lstStringNameColumn.Add("Thành tiền");

	  lstTupleMaxCharInColumn=new List<Tuple<string,int,string>>();
	  var dtOutput = new DataTable();
	  foreach(var item in lstStringNameColumn) {
		dtOutput.Columns.Add(item);
		lstTupleMaxCharInColumn.Add(new Tuple<string, int, string>(item,item.Length+2,item));
	  }

	  foreach(var mrow in lstGridMain) {
		int intIndexIncrease = -1;

		DataRow dRow = dtOutput.NewRow();

		{
		  string strTemp = ""+mrow.Stt;
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		{
		  string strTemp = ""+mrow.StrNameDrug;
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		{
		  string strTemp= ""+string.Format("{0:N2}",mrow.FloatSumKg);
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		{
		  string strTemp = ""+mrow.StrDonVi;
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		{
		  string strTemp = ""+string.Format("{0:0,0}",mrow.DecimalDonGia)+" đ";
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		{
		  string strTemp = ""+string.Format("{0:0,0}",mrow.DecimalThanhTien)+" đ";
		  dRow[lstStringNameColumn[++intIndexIncrease]]=strTemp;
		  ChangeValueMaxLengthInListTuple(ref lstTupleMaxCharInColumn,intIndexIncrease,strTemp);
		}

		dtOutput.Rows.Add(dRow);
	  }

	  dtReport=dtOutput;

	}

	private void ChangeValueMaxLengthInListTuple(ref List<Tuple<string,int,string>> lstTupleMaxCharInColumn
	  ,int intIndexIncrease,string strTemp) {
	  int intNewMaxlenght = strTemp.Length;
	  if(intNewMaxlenght>lstTupleMaxCharInColumn[intIndexIncrease].Item2) {
		string strColumnName = lstTupleMaxCharInColumn[intIndexIncrease].Item1;
		lstTupleMaxCharInColumn[intIndexIncrease]=new Tuple<string,int,string>
		  (strColumnName,intNewMaxlenght,strTemp);
	  }
	}

	internal void LoadGridMainByDataTableDetail(ref ObservableCollection<ModelRowOrder> lstGridMain
	  ,DataTable dT_AllDetailOrderByListIdOrder) {
	  foreach(var mitem in lstGridMain) {
		//var lstGridDetail = new ObservableCollection<ModelRowDetailOrder>();
		//LoadGridChiTietDHByDataTable(ref lstGridDetail,dT_AllDetailOrderByListIdOrder,mitem.StrId);
		//mitem.LstGridDetailOrder=lstGridDetail;

		//mitem.IntSumProduct=lstGridDetail.Count;

		//float floatSumKg = 0;
		//decimal decimalSumGiaTri = 0;
		//foreach(var item in lstGridDetail) {
		//  floatSumKg+=item.FloatSumKg;
		//  decimalSumGiaTri+=(decimal)item.FloatSumKg*item.DecimalDonGia;
		//}

		//mitem.FloatSumKg=floatSumKg;
		//mitem.StrSumKg=string.Format("{0:0.###}",floatSumKg);

		//mitem.DecimalSumGiaTri=decimalSumGiaTri;
		//mitem.StrSumGiaTri=string.Format("{0:0,0}",decimalSumGiaTri)+" đ";

		LoadOneOrderByTableDetail(mitem,dT_AllDetailOrderByListIdOrder);
	  }
	}

	internal void LoadOneOrderByTableDetail(ModelRowOrder mitem,DataTable dT_AllDetailOrderByListIdOrder) {
	  var lstGridDetail = new ObservableCollection<ModelRowDetailOrder>();
	  LoadGridChiTietDHByDataTable(ref lstGridDetail,dT_AllDetailOrderByListIdOrder,mitem.StrId);
	  mitem.LstGridDetailOrder=lstGridDetail;

	  mitem.IntSumProduct=lstGridDetail.Count;

	  float floatSumKg = 0;
	  decimal decimalSumGiaTri = 0;
	  foreach(var item in lstGridDetail) {
		floatSumKg+=item.FloatSumKg;
		decimalSumGiaTri+=(decimal)item.FloatSumKg*item.DecimalDonGia;
	  }

	  mitem.FloatSumKg=floatSumKg;
	  mitem.StrSumKg=string.Format("{0:0.###}",floatSumKg);

	  mitem.DecimalSumGiaTri=decimalSumGiaTri;
	  //mitem.StrSumGiaTri=string.Format("{0:0,0}",decimalSumGiaTri)+" đ";

	  string strSumGiaTri = "";
	  BLLTools.GetStringFormatTienMat(ref strSumGiaTri,decimalSumGiaTri," đ");
	  mitem.StrSumGiaTri=strSumGiaTri;
	}

	internal void LoadGridMainIdTenKHByPage(ref ObservableCollection<ModelRowOrder> lstGridMain
	  ,int intIdPage,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowOrder();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();
		mitem.StrNameKH=""+dtInput.Rows[i][Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();
		mitem.StrIdKH=""+dtInput.Rows[i][Table_BangKhachHang.Col_IdBangKhachHang.NAME].ToString().Trim();

		{
		  string strTemp = "Định dạng TG False";
		  DateTime objTemp = CVPConstValuePlugin.DTimeMacDinh;
		 // try {
			//objTemp=Convert.ToDateTime(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
			//strTemp=objTemp.ToString("yyyy-MM-dd HH:mm:ss");
		 // } catch(Exception e) {
			//string str = e.Message;
		 // }

		  BLLTools.GetStringFormatDateTimeVN(ref objTemp,ref strTemp
			,dtInput.Rows[i][Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
		  mitem.DTimeViet=objTemp;
		  mitem.StrDTimeViet=strTemp;
		}

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	#region Funtion for UpdateOrder_ViewModel

	internal void LoadGridSuggestByDataTableByFilter(ref ObservableCollection<ModelRowGoiYNameProduct> lstGridMain
	  ,DataTable dtInput,string strTextFilter) {
	  lstGridMain.Clear();

	  var lstStringId = new List<string>();
	  var lstTemp = new List<string>();
	  foreach(DataRow dRow in dtInput.Rows) {
		string item = dRow[Table_BangViThuoc.Col_TenViThuoc.NAME].ToString();
		lstTemp.Add(item);
		string strId = dRow[Table_BangViThuoc.Col_MaViThuoc.NAME].ToString();
		lstStringId.Add(strId);
	  }

	  int intIndexIncrease = 0;

	  int intSoItemDaCo = 0;
	  foreach(var item in lstTemp) {
		if(item.ToLower()==(strTextFilter.ToLower())) {
		  intSoItemDaCo++;
		  break;
		}
	  }

	  int intWidthHeight = 16;
	  if(intSoItemDaCo==0) {
		var mitem = new ModelRowGoiYNameProduct();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId="";

		mitem.DoubleWidthHeightIconAlert=0;
		mitem.DoubleWidthHeightIconOk=0;

		mitem.DoubleWidthHeightIconAlert=intWidthHeight;

		string strTextVietHoa = "";
		BLLTools.UpperTextStartByQuantity(ref strTextVietHoa,strTextFilter,1);
		mitem.StrName=strTextVietHoa;

		lstGridMain.Add(mitem);
	  }

	  int intIndexListTemp = -1;
	  foreach(var item in lstTemp) {
		intIndexListTemp++;
		if(!item.ToLower().Contains(strTextFilter.ToLower())) {
		  continue;
		}

		var mitem = new ModelRowGoiYNameProduct();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=lstStringId[intIndexListTemp];

		mitem.DoubleWidthHeightIconAlert=0;
		mitem.DoubleWidthHeightIconOk=0;

		mitem.DoubleWidthHeightIconOk=intWidthHeight;
		mitem.StrName=item;

		lstGridMain.Add(mitem);
	  }

	}

	internal void HienThiLabelDonGiaByDecimal(ref Label lblOutput,decimal decInput) {
	  lblOutput.Tag=decInput;
	  lblOutput.ToolTip=""+decInput;
	  if(decInput==0) {
		lblOutput.Content="0";
		return;
	  }

	  lblOutput.Content=""+string.Format("{0:0,0}",decInput);
	}

	internal void HienThiLabelSoLuongByDecimal(ref Label lblOutput,decimal decInput) {
	  lblOutput.Tag=decInput;
	  lblOutput.ToolTip=""+decInput;
	  if(decInput==0) {
		lblOutput.Content="0";
		return;
	  }

	  lblOutput.Content=""+string.Format("{0:0.####}",decInput);
	}

	internal void LoadGridDonGiaByIdProduct(ref ObservableCollection<ModelRowDonGia> lstGridMain
	  ,string strId) {
	  lstGridMain.Clear();

	  var lstStringId = new List<string>();
	  lstStringId.Add(strId);

	  Exception exOutput = null;
	  DataTable dtOutput = null;
	  DALProduct.GetDTListDonGiaByListIdProduct(ref dtOutput,ref exOutput,lstStringId);
	  if(exOutput!=null) {
		throw exOutput;
	  }
	  if(dtOutput==null) {
		return;
	  }

	  int intIndexIncrease = 0;
	  foreach(DataRow dRow in dtOutput.Rows) {
		var mitem = new ModelRowDonGia();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dRow[Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();
		mitem.StrNameKH=""+dRow[Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();
		mitem.StrDonVi=""+dRow[Table_BangGiaViThuoc.Col_DonViGiaThuoc.NAME].ToString().Trim();

		{
		  string strTemp = "Định dạng TG False";
		  DateTime objTemp = CVPConstValuePlugin.DTimeMacDinh;
		 // try {
			//objTemp=Convert.ToDateTime(dRow[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
			//strTemp=objTemp.ToString("yyyy-MM-dd HH:mm:ss");
		 // } catch(Exception e) {
			//string str = e.Message;
		 // }

		  BLLTools.GetStringFormatDateTimeVN(ref objTemp,ref strTemp
			,dRow[Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
		  mitem.DTimeViet=objTemp;
		  mitem.StrDTimeViet=strTemp;
		}

		{
		  string strTemp = "Định dạng Float False";
		  float objTemp = 0;
		  try {
			objTemp=Convert.ToSingle(dRow[Table_BangChiTietDonHang.Col_SoLuongViThuoc.NAME]);
			//strTemp=string.Format("{0:N3}",objTemp);
			strTemp=string.Format("{0:0.###}",objTemp);
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.FloatSumKg=objTemp;
		  mitem.StrSumKg=strTemp;
		}

		{
		  string strTemp = "Định dạng Decimal False";
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(dRow[Table_BangGiaViThuoc.Col_GiaViThuoc.NAME]);
			//strTemp=string.Format("{0:N3}",objTemp);
			strTemp=string.Format("{0:0,0}",objTemp)+" đ";
			//strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DecimalDonGia=objTemp;
		  mitem.StrDonGia=strTemp;
		}

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	internal void GetDecimalFromObject(ref decimal decOutput,object objInput) {
	  if(objInput!=null) {
		try {
		  decOutput=(decimal)objInput;
		} catch(Exception e) {
		  string str = e.Message;
		}
	  }
	}

	#endregion

  }
}
