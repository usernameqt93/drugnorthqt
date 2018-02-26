using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCommon {
  public static class QTLibraryFunction {

	public static string GetValue(string str) {
	  return "'"+str+"'";
	}

	public static void STATIC_VOID_ADD_STT_COL_TO_DATATABLE(ref DataTable _dt) {
	  _dt.Columns.Add("STT");
	  for(int i = 0;i<_dt.Rows.Count;i++)
		_dt.Rows[i]["STT"]=i+1;
	}

	public static void STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref DataGridViewX dgvXTemp,string _strMaCot,int _intWidth,DataGridViewContentAlignment _dgvContentAlign) {
	  dgvXTemp.Columns[_strMaCot].Width=_intWidth;
	  dgvXTemp.Columns[_strMaCot].DefaultCellStyle.Alignment=_dgvContentAlign;
	  dgvXTemp.Columns[_strMaCot].HeaderCell.Style.Alignment=_dgvContentAlign;
	}

	public static void STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref DataGridViewX dgvXTemp,string _strMaCot,int _intWidth,DataGridViewContentAlignment _dgvContentAlign,DataGridViewAutoSizeColumnMode _dgvAutoSizeColumnMode) {
	  STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXTemp,_strMaCot,_intWidth,_dgvContentAlign);
	  dgvXTemp.Columns[_strMaCot].AutoSizeMode=_dgvAutoSizeColumnMode;
	}

	public static void STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref DataGridViewX dgvXTemp,string _strMaCot,string _strHeaderText,int _intWidth,DataGridViewContentAlignment _dgvContentAlign,DataGridViewAutoSizeColumnMode _dgvAutoSizeColumnMode) {
	  STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXTemp,_strMaCot,_intWidth,_dgvContentAlign,_dgvAutoSizeColumnMode);
	  dgvXTemp.Columns[_strMaCot].HeaderText=_strHeaderText;
	}

	public static void STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref DataGridViewX dgvXTemp,string _strMaCot,string _strHeaderText,int _intWidth,DataGridViewContentAlignment _dgvContentAlign) {
	  STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dgvXTemp,_strMaCot,_intWidth,_dgvContentAlign);
	  dgvXTemp.Columns[_strMaCot].HeaderText=_strHeaderText;
	}

	public static void STATIC_VOID_HIDE_LIST_COLUMN(ref DataGridViewX dgvXTemp,List<string> _lstIdColumn) {
	  if(_lstIdColumn.Count>0) {
		foreach(string strItem in _lstIdColumn) {
		  dgvXTemp.Columns[strItem].Visible=false;
		}
	  }
	}

	public static void STATIC_VOID_NOT_SORT_DGV(ref DataGridViewX _dgvXTemp) {
	  foreach(DataGridViewColumn column in _dgvXTemp.Columns) {
		column.SortMode=DataGridViewColumnSortMode.NotSortable;
	  }
	}
  }
}
