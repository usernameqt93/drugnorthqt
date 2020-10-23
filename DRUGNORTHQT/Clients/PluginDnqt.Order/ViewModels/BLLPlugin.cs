using DNQTConstTable.ListTableDatabase;
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

	internal void LoadGridMainByDataTable(ref ObservableCollection<ModelRowOrder> lstGridMain
	  ,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = 0;
	  int intEndIndex = dtInput.Rows.Count;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowOrder();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][Table_BangDanhSachDonHang.Col_MaDonHang.NAME].ToString().Trim();
		mitem.StrNameKH=""+dtInput.Rows[i][Table_BangKhachHang.Col_TenKhachHang.NAME].ToString().Trim();

		{
		  string strTemp = "Định dạng TG False";
		  DateTime objTemp = CVPConstValuePlugin.DTimeMacDinh;
		  try {
			objTemp=Convert.ToDateTime(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_ThoiGianVietDonHangNay.NAME]);
			strTemp=objTemp.ToString("yyyy-MM-dd HH:mm:ss");
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DTimeViet=objTemp;
		  mitem.StrDTimeViet=strTemp;
		}

		try {
		  mitem.IntSumProduct=Convert.ToInt32(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongViThuoc.NAME]);
		} catch(Exception e) {
		  string str = e.Message;
		}

		{
		  string strTemp = "Định dạng Float False";
		  float objTemp = 0;
		  try {
			objTemp=Convert.ToSingle(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongKhoiLuong.NAME]);
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
			objTemp=Convert.ToDecimal(dtInput.Rows[i][Table_BangDanhSachDonHang.Col_TongGiaTriDonHang.NAME]);
			//strTemp=string.Format("{0:N3}",objTemp);
			strTemp=string.Format("{0:0,0}",objTemp)+" vnđ";
			//strTemp=double.Parse(objTemp.ToString()).ToString("#,###",CultureInfo.GetCultureInfo("vi-VN"))+" vnđ";
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DecimalSumGiaTri=objTemp;
		  mitem.StrSumGiaTri=strTemp;
		}

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	internal void LoadGridChiTietDHByDataTable(ref ObservableCollection<ModelRowDetailOrder> lstGridMain
	  ,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = 0;
	  int intEndIndex = dtInput.Rows.Count;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
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

  }
}
