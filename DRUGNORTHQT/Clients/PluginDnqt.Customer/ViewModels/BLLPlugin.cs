using DNQTConstTable.ListTableDatabase;
using PluginDnqt.Customer.Models;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PluginDnqt.Customer.ViewModels {
  class BLLPlugin {

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

	internal void LoadGridMainByPage(ref ObservableCollection<ModelRowCustomer> lstGridMain,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  int intSumColumn = dtInput.Columns.Count;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelBaseRow();
		mitem.Stt=++intIndexIncrease;

		BLLTools.SetValueBaseRowDataTableByIndexRow(ref mitem,i,dtInput);

		mitem.Selected=false;
		lstGridMain.Add(new ModelRowCustomer(mitem));
	  }
	}

	//internal void LoadGridMainByDataTableDetail(ref ObservableCollection<ModelRowCustomer> lstGridMain
	//  ,DataTable dT_AllDetailOrderByListIdOrder) {
	//  foreach(var mitem in lstGridMain) {
	//	LoadOneOrderByTableDetail(mitem,dT_AllDetailOrderByListIdOrder);
	//  }
	//}

	internal void LoadOneCustomerByTableDetail(ModelRowCustomer mitem,DataTable dtInput) {
	  var lstGridBaseDetail = new ObservableCollection<ModelBaseRow>();
	  LoadGridBaseDetailByDataTable(ref lstGridBaseDetail,dtInput,mitem.MBC000.Str);
	  mitem.LstGridBaseDetail=lstGridBaseDetail;

	 // mitem.IntSumProduct=lstGridDetail.Count;

	 // float floatSumKg = 0;
	 // decimal decimalSumGiaTri = 0;
	 // foreach(var item in lstGridDetail) {
		//floatSumKg+=item.FloatSumKg;
		//decimalSumGiaTri+=(decimal)item.FloatSumKg*item.DecimalDonGia;
	 // }

	 // mitem.FloatSumKg=floatSumKg;
	 // mitem.StrSumKg=string.Format("{0:0.###}",floatSumKg);

	 // mitem.DecimalSumGiaTri=decimalSumGiaTri;
	 // mitem.StrSumGiaTri=string.Format("{0:0,0}",decimalSumGiaTri)+" đ";
	}

	internal void LoadGridBaseDetailByDataTable(ref ObservableCollection<ModelBaseRow> lstGridMain
	  ,DataTable dtInput,string strIdOrder) {
	  lstGridMain.Clear();

	  int intStartIndex = 0;
	  int intEndIndex = dtInput.Rows.Count;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		string strIdOrderInTable = ""+dtInput.Rows[i]["IdBangKhachHang"].ToString();
		if(strIdOrderInTable!=strIdOrder) {
		  continue;
		}

		var mitem = new ModelBaseRow();
		mitem.Stt=++intIndexIncrease;

		BLLTools.SetValueBaseRowDataTableByIndexRow(ref mitem,i,dtInput);

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	internal void LoadFormatGridMain(ref ObservableCollection<ModelRowCustomer> lstGridMain) {
	  foreach(var mrow in lstGridMain) {
		decimal objTemp = 0;
		string strTienNo = "";
		BLLTools.GetStringFormatTienMat(ref objTemp,ref strTienNo,mrow.MBC002.ObjItem," vnđ");
		mrow.DecimalSumTienNo=objTemp;
		mrow.StrSumTienNo=strTienNo;
	  }
	}

	internal void LoadFormatGridDetail(ModelRowCustomer mRow) {
	  mRow.LstGridDetail.Clear();
	  foreach(var item in mRow.LstGridBaseDetail) {
		mRow.LstGridDetail.Add(new ModelRowDetailTienNo(item));
	  }

	  foreach(var item in mRow.LstGridDetail) {
		{
		  var mtemp = new ModelBaseDateTime();
		  BLLTools.GetModelDateTimeFromObject(ref mtemp,item.MBC001.ObjItem);
		  item.MBDTTime=mtemp;
		}
		{
		  var mtemp = new ModelBaseDecimal();
		  BLLTools.GetModelDecimalFromObject(ref mtemp,item.MBC003.ObjItem," đ");
		  item.MBDTruocKhiSua=mtemp;
		}
		{
		  var mtemp = new ModelBaseDecimal();
		  BLLTools.GetModelDecimalFromObject(ref mtemp,item.MBC004.ObjItem," đ");
		  item.MBDSoTienSua=mtemp;
		}
		{
		  var mtemp = new ModelBaseDecimal();
		  BLLTools.GetModelDecimalFromObject(ref mtemp,item.MBC005.ObjItem," đ");
		  item.MBDSauKhiSua=mtemp;
		}
	  }
	}
  }
}
