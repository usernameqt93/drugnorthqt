using PluginDnqt.Order.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;

namespace PluginDnqt.Order.ViewModels {
  class BLLPlugin {

	private DateTime DTimeMacDinh = new DateTime(1993,11,13);

	internal void LoadGridMainByPage(ref ObservableCollection<ModelRowOrder> lstGridMain,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowOrder();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_ID_ORDER.STR].ToString().Trim();
		mitem.StrName=""+dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_TEN_KH.STR].ToString().Trim();

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

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

		mitem.StrId=""+dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_ID_ORDER.STR].ToString().Trim();
		mitem.StrNameKH=""+dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_TEN_KH.STR].ToString().Trim();

		{
		  string strTemp = "Định dạng TG False";
		  DateTime objTemp = CVPConstValuePlugin.DTimeMacDinh;
		  try {
			objTemp=Convert.ToDateTime(dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_THOIGIAN_VIET.STR]);
			strTemp=objTemp.ToString("yyyy-MM-dd HH:mm:ss");
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  mitem.DTimeViet=objTemp;
		  mitem.StrDTimeViet=strTemp;
		}

		try {
		  mitem.IntSumProduct=Convert.ToInt32(dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_TONGVITHUOC.STR]);
		} catch(Exception e) {
		  string str = e.Message;
		}

		{
		  string strTemp = "Định dạng Float False";
		  float objTemp = 0;
		  try {
			objTemp=Convert.ToSingle(dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_TONGKHOILUONG.STR]);
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
			objTemp=Convert.ToDecimal(dtInput.Rows[i][CVPConstValuePlugin.STR_CONST_COL_TONGGIATRI.STR]);
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
  }
}
