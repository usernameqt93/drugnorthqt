using DevComponents.DotNetBar.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCommon {
  public static class QTLibraryFunction {

	//QTLibraryFunction.STATIC_INT_INDEX_VALUE_EXIST_IN_COLUMN

	public static void STATIC_VOID_ADD_STT_COL_TO_DATATABLE(ref DataTable _dt) {
	  _dt.Columns.Add(QTStringConst.SO_THUTU.STR);
	  for(int i = 0;i<_dt.Rows.Count;i++)
		_dt.Rows[i][QTStringConst.SO_THUTU.STR]=i+1;
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

	public static bool STATIC_BOOL_VALUE_EXIST_IN_COLUMN(string _strValue,string _strIdColumn,DataTable _dtMain) {
	  int intCountDtMain = _dtMain.Rows.Count;
	  if(intCountDtMain>0) {
		for(int i = 0;i<intCountDtMain;i++) {
		  string strTemp = _dtMain.Rows[i][_strIdColumn].ToString();
		  if(strTemp.Equals(_strValue)) {
			return true;
		  }
		}
	  }
	  return false;
	}

	public static string STATIC_STR_SELECT_COLUMN(List<string> _lstColumnDb) {
	  string strResult = "";
	  if(_lstColumnDb.Count>0) {
		for(int i = 0;i<_lstColumnDb.Count;i++) {
		  strResult+=(i==0)? _lstColumnDb[i]:","+_lstColumnDb[i];
		}
	  }
	  return strResult;
	}

	public static string STATIC_STR_COLUMN_EQUAL_AT_COLUMN(List<string> _lstColumnDb,string _strSplitList) {
	  string strResult = "";
	  if(_lstColumnDb.Count>0) {
		for(int i = 0;i<_lstColumnDb.Count;i++) {
		  string strTemp = _lstColumnDb[i]+"=@"+_lstColumnDb[i];
		  strResult+=(i==0) ? strTemp : _strSplitList+strTemp;
		}
	  }
	  return strResult;
	}

	public static string STATIC_STR_COLUMN_WHERE_COLUMN(List<string> _lstWhereColumnDb,string _strSplitList) {
	  return STATIC_STR_COLUMN_EQUAL_AT_COLUMN(_lstWhereColumnDb,_strSplitList);
	}

	public static string STATIC_STR_COLUMN_SET_COLUMN(List<string> _lstSetColumnDb) {
	  return STATIC_STR_COLUMN_EQUAL_AT_COLUMN(_lstSetColumnDb,",");
	}

	public static string STATIC_STR_AT(string _strNameColumn) {
	  return "@"+_strNameColumn;
	}

	public static string STATIC_STR_QUERY_SELECT(List<string> _lstColumnDbSelect,string _strTable,List<string> _lstColumnDbWhere,string _strSplit) {
	  return "select "+STATIC_STR_SELECT_COLUMN(_lstColumnDbSelect)
		+" from "+_strTable
		+" where "+STATIC_STR_COLUMN_WHERE_COLUMN(_lstColumnDbWhere,_strSplit);
	}

	public static string STATIC_STR_QUERY_UPDATE(string _strTable,List<string> _lstSetColumnDb,List<string> _lstColumnDbWhere,string _strSplit) {
	  return "update "+_strTable
		+" set "+STATIC_STR_COLUMN_SET_COLUMN(_lstSetColumnDb)
		+" where "+STATIC_STR_COLUMN_WHERE_COLUMN(_lstColumnDbWhere,_strSplit);
	}

	public static void STATIC_VOID_SET_PARAMETERS_TO_REPORT(ref ReportViewer _reportViewer,List<string> _lstParameters,List<string> _lstValue) {
	  for(int i = 0;i<_lstParameters.Count;i++) {
		_reportViewer.LocalReport.SetParameters(new ReportParameter(_lstParameters[i],_lstValue[i]));
	  }
	}

	public static string STATIC_STR_UNLOCK(string _strNameColumn) {
	  return "Unlock "+_strNameColumn;
	}

	//QTLibraryFunction.STATIC_STR_UNLOCK
  }
}
