using PluginDnqt.Customer.Models;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

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

	internal void LoadGridMainByDataTableDetail(ref ObservableCollection<ModelRowCustomer> lstGridMain
	  ,DataTable dtInput) {
	  foreach(var mitem in lstGridMain) {
		LoadOneCustomerByTableDetail(mitem,dtInput);
	  }
	}

	internal void LoadOneCustomerByTableDetail(ModelRowCustomer mitem,DataTable dtInput) {
	  var lstGridBaseDetail = new ObservableCollection<ModelBaseRow>();
	  LoadGridBaseDetailByDataTable(ref lstGridBaseDetail,dtInput,mitem.MBC000.Str);
	  mitem.LstGridBaseDetail=lstGridBaseDetail;

	  int intSumRowDetail = lstGridBaseDetail.Count;
	  mitem.IntSoLanThayDoi=intSumRowDetail;

	  if(intSumRowDetail>0) {
		{
		  var mtemp = new ModelBaseDateTime();
		  BLLTools.GetModelDateTimeFromObject(ref mtemp,lstGridBaseDetail[intSumRowDetail-1].MBC001.ObjItem);
		  mitem.MBDTGanNhat=mtemp;
		}
		{
		  var mtemp = new ModelBaseDecimal();
		  BLLTools.GetModelDecimalFromObject(ref mtemp,lstGridBaseDetail[intSumRowDetail-1].MBC005.ObjItem," đ");
		  mitem.MBDTienNo=mtemp;
		}
	  }
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

	internal void HienThiLabelDonGiaByDecimal(ref Label lblOutput,decimal decInput) {
	  lblOutput.Tag=decInput;
	  lblOutput.ToolTip=""+decInput;
	  if(decInput==0) {
		lblOutput.Content="0";
		return;
	  }

	  lblOutput.Content=""+string.Format("{0:0,0}",decInput);
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

  }
}
