using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using QTCommon;

namespace THUOCBAC.FormDanhSach {
  public partial class FormDanhSachDonXinXacNhan:Form {
	public FormDanhSachDonXinXacNhan() {
	  InitializeComponent();
	}
	private BL_DonXacNhan BL_DONXACNHAN=new BL_DonXacNhan();
	private int INT_MADONXACNHAN_DANGCHON=-1;

	private void btnXThemDonXacNhan_Click(object sender,EventArgs e) {
	  FormChucNang.FormThemDonXacNhan formThemDonXacNhan=new FormChucNang.FormThemDonXacNhan();
	  formThemDonXacNhan.ShowDialog();
	  dataGridViewXDSDonXacNhan.DataSource=BL_DONXACNHAN.dataTableBangDanhSachDonXacNhan();
	}

	private void FormDanhSachDonXinXacNhan_Load(object sender,EventArgs e) {
	  dataGridViewXDSDonXacNhan.DataSource=BL_DONXACNHAN.dataTableBangDanhSachDonXacNhan();
	  dataGridViewXDSDonXacNhan.Columns["SoViThuocTrongDon"].DefaultCellStyle.Format="#,###.### vị thuốc";
	}

	private void dataGridViewXDSDonXacNhan_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXemChiTietDonXacNhan.Enabled=true;
		  DataGridViewRow r=dataGridViewXDSDonXacNhan.Rows[e.RowIndex];
		  INT_MADONXACNHAN_DANGCHON=Convert.ToInt32(r.Cells["MaDonXinXacNhan"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXXemChiTietDonXacNhan_Click(object sender,EventArgs e) {
	  btnXXemChiTietDonXacNhan.Enabled=false;
	  //FormChucNang.FormThemDonHang formXemChiTietDonHang=new FormChucNang.FormThemDonHang(INT_MADONHANG_DANGCHON,"XemChiTiet");
	  //formXemChiTietDonHang.ShowDialog();
	  FormChucNang.FormThemDonXacNhan formXemChiTietDonXacNhan=new FormChucNang.FormThemDonXacNhan(INT_MADONXACNHAN_DANGCHON,"XemChiTiet");
	  formXemChiTietDonXacNhan.ShowDialog();
	  dataGridViewXDSDonXacNhan.DataSource=BL_DONXACNHAN.dataTableBangDanhSachDonXacNhan();
	}
  }
}
