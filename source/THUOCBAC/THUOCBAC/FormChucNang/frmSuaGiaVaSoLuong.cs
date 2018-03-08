using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormChucNang {
  public partial class frmSuaGiaVaSoLuong:Form {

	public frmSuaGiaVaSoLuong() {
	  InitializeComponent();
	}

	public frmSuaGiaVaSoLuong(string _strName,decimal _decSoLuong,decimal _decDonGia) {
	  InitializeComponent();
	  lblNameCurrent.Text=_strName;
	  nudSoLuongHienTai.Value=_decSoLuong;
	  nudDonGiaHienTai.Value=_decDonGia;

	  nudSoLuongMoi.Value=_decSoLuong;
	  nudDonGiaMoi.Value=_decDonGia;

	  lblThanhTienHienTai.Text=""+(_decSoLuong*_decDonGia).ToString("#,###.#")+" đ";
	}

	private void frmSuaGiaVaSoLuong_Load(object sender,EventArgs e) {
	  nudSoLuongMoi.Focus();
	  nudSoLuongMoi.Select(0,22);
	}

	private void nudSoLuongMoi_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.Enter) {
		nudDonGiaMoi.Focus();
		nudDonGiaMoi.Select(0,22);
	  }
	}

	private void nudDonGiaMoi_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.N) {
		nudDonGiaMoi.Value*=1000;

		voidTinhTien();

		nudDonGiaMoi.Focus();
		nudDonGiaMoi.Select(0,22);
	  }
	  if(e.KeyCode==Keys.Enter) {
		if(nudDonGiaMoi.Value<4001) {
		  MessageBox.Show("Đơn giá vị thuốc bạn nhập hiện tại đang là '"+nudDonGiaMoi.Value+"' vnđ , hơi thấp so với bình thường, bạn nên kiểm tra lại !");
		  nudDonGiaMoi.Focus();
		  nudDonGiaMoi.Select(0,22);
		  btnXAccept.Enabled=false;
		} else {
		  voidTinhTien();
		  btnXAccept.Enabled=true;
		  btnXAccept.Focus();
		}
	  }
	}

	private void btnXAccept_Click(object sender,EventArgs e) {
	  MessageBox.Show("mmmmmmmmmmmmmmmm");
	}

	private void frmSuaGiaVaSoLuong_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.F5) {
		nudSoLuongMoi.Focus();
		nudSoLuongMoi.Select(0,22);
		return;
	  }
	}

	private void grpThanhTienHienTai_MouseHover(object sender,EventArgs e) {
	  voidTinhTien();
	}

	private void btnXAccept_MouseHover(object sender,EventArgs e) {
	  voidTinhTien();
	}

	private void voidTinhTien(){
	  decimal DEC_THANHTIEN = nudDonGiaMoi.Value*nudSoLuongMoi.Value;
	  string strThanhTien = ""+""+DEC_THANHTIEN.ToString("#,###.#")+" đ";
	  lblThanhTienMoi.Text=strThanhTien;
	}

	private void lblThanhTienMoi_MouseHover(object sender,EventArgs e) {
	  voidTinhTien();
	  btnXAccept.Enabled=true;
	}
  }
}
