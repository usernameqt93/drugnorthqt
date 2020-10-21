using PluginDnqt.Product.Models;
using System.Collections.ObjectModel;
using System.Data;

namespace PluginDnqt.Product.ViewModels {
  class BLLPlugin {
	internal void LoadGridMainByPage(ref ObservableCollection<ModelRowMain> lstGridMain,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  int INT_INDEX_COL_ID = 0;
	  int INT_INDEX_COL_NAME = 1;

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowMain();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][INT_INDEX_COL_ID].ToString().Trim();
		mitem.StrName=""+dtInput.Rows[i][INT_INDEX_COL_NAME].ToString().Trim();

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}
  }
}
