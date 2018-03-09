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

namespace THUOCBAC.FormChucNang {
  public partial class frmSuaGiaVaSoLuong:Form {

	private BL_DonHang BL_DONHANG = new BL_DonHang();
	private int INT_MA_CHITIET_DONHANG_DANGCHON;

	public frmSuaGiaVaSoLuong() {
	  InitializeComponent();
	}

	public frmSuaGiaVaSoLuong(int _intMaChiTietDonHang,string _strName,decimal _decSoLuong,decimal _decDonGia) {
	  InitializeComponent();
	  lblNameCurrent.Text=_strName;
	  nudSoLuongHienTai.Value=_decSoLuong;
	  nudDonGiaHienTai.Value=_decDonGia;

	  nudSoLuongMoi.Value=_decSoLuong;
	  nudDonGiaMoi.Value=_decDonGia;

	  lblThanhTienHienTai.Text=""+(_decSoLuong*_decDonGia).ToString("#,###.#")+" đ";
	  INT_MA_CHITIET_DONHANG_DANGCHON=_intMaChiTietDonHang;
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

		voidTinhTienVaHienNut();

		nudDonGiaMoi.Focus();
		nudDonGiaMoi.Select(0,22);
	  }
	  if(e.KeyCode==Keys.Enter) {
		if(nudDonGiaMoi.Value<4001) {
		  QTMessageConst.UNIT_PRICE_IS_LOW(nudDonGiaMoi.Value);
		  nudDonGiaMoi.Focus();
		  nudDonGiaMoi.Select(0,22);
		  btnXAccept.Enabled=false;
		} else {
		  voidTinhTienVaHienNut();
		  btnXAccept.Focus();
		}
	  }
	}

	private void btnXAccept_Click(object sender,EventArgs e) {
	  if(nudDonGiaMoi.Value<4001) {
		QTMessageConst.UNIT_PRICE_IS_LOW(nudDonGiaMoi.Value);
		nudDonGiaMoi.Focus();
		nudDonGiaMoi.Select(0,22);
		btnXAccept.Enabled=false;
		return;
	  }

	  string strLoi = "";
	  string strTrangThaiCapNhatGiaViThuocVaoDH = BL_DONHANG.strCapNhatGiaCaViThuocVaoDH(ref strLoi,INT_MA_CHITIET_DONHANG_DANGCHON,nudDonGiaMoi.Value,nudSoLuongMoi.Value);
	  if(strTrangThaiCapNhatGiaViThuocVaoDH.Equals("false")&&!strLoi.Equals("2"))
		QTMessageConst.EDIT_PRICE_AMOUNT_ERROR(strLoi);
	  else {
		QTMessageConst.EDIT_PRICE_AMOUNT_SUCCESS();
		this.Close();
	  }
	}

	private void frmSuaGiaVaSoLuong_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.F5) {
		nudSoLuongMoi.Focus();
		nudSoLuongMoi.Select(0,22);
		return;
	  }
	}

	private void grpThanhTienHienTai_MouseHover(object sender,EventArgs e) {
	  voidTinhTienVaHienNut();
	}

	private void btnXAccept_MouseHover(object sender,EventArgs e) {
	  voidTinhTienVaHienNut();
	}

	private void lblThanhTienMoi_MouseHover(object sender,EventArgs e) {
	  voidTinhTienVaHienNut();
	}

	#region Other

	private void voidTinhTienVaHienNut() {
	  decimal DEC_THANHTIEN = nudDonGiaMoi.Value*nudSoLuongMoi.Value;
	  string strThanhTien = (DEC_THANHTIEN>0) ? ""+DEC_THANHTIEN.ToString("#,###.#")+" đ" : "0 đ";
	  lblThanhTienMoi.Text=strThanhTien;
	  btnXAccept.Enabled=(DEC_THANHTIEN>0) ? true : false;
	}



	#endregion
  }
}
