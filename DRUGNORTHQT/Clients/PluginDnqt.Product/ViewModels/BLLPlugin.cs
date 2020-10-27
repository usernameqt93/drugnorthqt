using DNQTConstTable.ListTableDatabase;
using DNQTDataAccessLayer.DALNew;
using PluginDnqt.Product.Models;
using QT.Framework.ToolCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace PluginDnqt.Product.ViewModels {
  class BLLPlugin {

	private DAL_Product DALProduct = new DAL_Product();

	internal void LoadGridMainByPage(ref ObservableCollection<ModelRowProduct> lstGridMain,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowProduct();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][Table_BangViThuoc.Col_MaViThuoc.NAME].ToString().Trim();
		mitem.StrName=""+dtInput.Rows[i][Table_BangViThuoc.Col_TenViThuoc.NAME].ToString().Trim();

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

	internal void ShowSumOrderOnGridMain(ref ObservableCollection<ModelRowProduct> lstGridMain) {
	  var lstStringId = new List<string>();
	  foreach(var item in lstGridMain) {
		lstStringId.Add(item.StrId);
	  }

	  Exception exOutput = null;
	  DataTable dtOutput = null;
	  DALProduct.GetDTListOrderByListIdProduct(ref dtOutput,ref exOutput,lstStringId);
	  if(exOutput!=null) {
		throw exOutput;
	  }
	  if(dtOutput==null) {
		return;
	  }

	  foreach(var mrow in lstGridMain) {
		var lstStringIdOrder = new List<string>();
		GetListIdOrderByIdProductFromDataTable(ref lstStringIdOrder,dtOutput,mrow.StrId);

		mrow.LstStringIdOrder=lstStringIdOrder;
		mrow.IntSumOrder=lstStringIdOrder.Count;

		string strListId = "";
		BLLTools.GetStringJoinSplitChar(ref strListId,lstStringIdOrder,",","");
		mrow.StrListOrder=strListId;
	  }
	}

	private void GetListIdOrderByIdProductFromDataTable(ref List<string> lstStringIdOrder,DataTable dtInput
	  ,string strId) {
	  foreach(DataRow dRow in dtInput.Rows) {
		if(dRow[Table_BangViThuoc.Col_MaViThuoc.NAME].ToString()==strId) {
		  lstStringIdOrder.Add(dRow[Table_BangChiTietDonHang.Col_MaDonHang.NAME].ToString());
		}
	  }
	}
  }
}
