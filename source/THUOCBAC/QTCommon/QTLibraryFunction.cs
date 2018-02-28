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

	public static void STATIC_VOID_FOCUS_LAST_ROW_DGV(ref DataGridViewX _dgvXTemp,string _strIdColumnFocus) {
	  int intSoThuTuHangMuonTroVao = 0;
	  if(_dgvXTemp.RowCount>1) {
		intSoThuTuHangMuonTroVao=_dgvXTemp.RowCount-1;
		// Đưa Control về vị trí của nó
		_dgvXTemp.CurrentCell=_dgvXTemp.Rows[intSoThuTuHangMuonTroVao].Cells[_strIdColumnFocus];
		// Set trạng thái Selected
		_dgvXTemp.CurrentRow.Selected=true;
	  }
	}

	public static void STATIC_VOID_FOCUS_ROW_X_IN_DGV(ref DataGridViewX _dgvXTemp,string _strIdColumnFocus,int _intIndexFocus) {
	  int intSoThuTuHangMuonTroVao = 0;
	  if(_dgvXTemp.RowCount>1&&_intIndexFocus>=0) {
		intSoThuTuHangMuonTroVao=_dgvXTemp.RowCount-1;
		// Đưa Control về vị trí của nó
		_dgvXTemp.CurrentCell=_dgvXTemp.Rows[_intIndexFocus].Cells[_strIdColumnFocus];
		// Set trạng thái Selected
		_dgvXTemp.CurrentRow.Selected=true;
	  }
	}

	public static int STATIC_INT_INDEX_VALUE_EXIST_IN_COLUMN(string _strValue,string _strIdColumn,DataTable _dtMain) {
	  int intCountDtMain = _dtMain.Rows.Count;
	  if(intCountDtMain>0) {
		for(int i = 0;i<intCountDtMain;i++) {
		  string strTemp = _dtMain.Rows[i][_strIdColumn].ToString();
		  if(strTemp.Equals(_strValue)) {
			return i;
		  }
		}
	  }
	  return -1311;
	}
  }
}
