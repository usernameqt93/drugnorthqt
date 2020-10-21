using PluginDnqt.Order.Models;
using System.Collections.ObjectModel;
using System.Data;

namespace PluginDnqt.Order.ViewModels {
  class BLLPlugin {
	internal void LoadGridMainByPage(ref ObservableCollection<ModelRowMain> lstGridMain,int intIdPage
	  ,int CONST_INT_PAGE_SIZE,DataTable dtInput) {
	  lstGridMain.Clear();

	  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	  int intMaxEndIndexByPage = (intIdPage+1)*CONST_INT_PAGE_SIZE;
	  int intEndIndex = dtInput.Rows.Count<intMaxEndIndexByPage ?
		dtInput.Rows.Count : intMaxEndIndexByPage;

	  string STR_ID = "MaDonHang";
	  string STR_TEN_KH = "TenKhachHang";

	  int intIndexIncrease = 0;
	  for(int i = intStartIndex;i<intEndIndex;i++) {
		var mitem = new ModelRowMain();
		mitem.Stt=++intIndexIncrease;

		mitem.StrId=""+dtInput.Rows[i][STR_ID].ToString().Trim();
		mitem.StrName=""+dtInput.Rows[i][STR_TEN_KH].ToString().Trim();

		mitem.Selected=false;
		lstGridMain.Add(mitem);
	  }
	}
  }
}
