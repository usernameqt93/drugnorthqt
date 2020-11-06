using QT.Framework.ToolCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PluginDnqt.Customer.ViewModels {
  class BLLPlugin {

	internal void LoadGridMainByPage(ref ObservableCollection<ModelBaseRow> lstGridMain,int intIdPage
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

		//mitem.StrId=""+dtInput.Rows[i][Table_BangViThuoc.Col_MaViThuoc.NAME].ToString().Trim();
		//mitem.StrName=""+dtInput.Rows[i][Table_BangViThuoc.Col_TenViThuoc.NAME].ToString().Trim();

		for(int k = 0;k<intSumColumn;k++) {
		  var mcell = new ModelBaseCell();
		  mcell.StrColumnName=dtInput.Columns[k].ColumnName;

		  object objTemp = dtInput.Rows[i][k];
		  mcell.ObjItem=objTemp;
		  if(objTemp!=null) {
			mcell.Str=dtInput.Rows[i][k].ToString(); 
		  }

		  mitem.SetValueCell(k,mcell);
		}

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}

  }
}
