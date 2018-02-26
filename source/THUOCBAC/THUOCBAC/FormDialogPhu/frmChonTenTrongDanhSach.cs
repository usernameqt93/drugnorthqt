using BusinessLogic;
using QTCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormDialogPhu {
  public partial class frmChonTenTrongDanhSach:Form {
	private DataTable DT_MAIN;
	private BL_KhachHang BL_KHACHHANG = new BL_KhachHang();

	public frmChonTenTrongDanhSach() {
	  InitializeComponent();
	}

	private void frmChonTenTrongDanhSach_Load(object sender,EventArgs e) {
	  DT_MAIN=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  QTLibraryFunction.VOID_ADD_STT_COL_TO_DATATABLE(ref DT_MAIN);
	  dgvXMain.DataSource=DT_MAIN;
	  dgvXMain.Columns["STT"].DisplayIndex=0;
	}

	private void btnXClose_Click(object sender,EventArgs e) {
	  this.Close();
	}
  }
}
