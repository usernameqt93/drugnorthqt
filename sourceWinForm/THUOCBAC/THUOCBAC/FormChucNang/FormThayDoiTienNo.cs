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

namespace THUOCBAC.FormChucNang {
  public partial class FormThayDoiTienNo:Form {
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private int INT_ID_KHACHHANG_HIENTAI=-1;
	private string STR_TEN_KHACHHANG="";
	private decimal DEC_TIENNO_HIENTAI=-1;
	public FormThayDoiTienNo() {
	  InitializeComponent();
	}
	public FormThayDoiTienNo(int intIdKhachHang,string strTenKhachHang,decimal decTienNoHienTai) {
	  InitializeComponent();
	  INT_ID_KHACHHANG_HIENTAI=intIdKhachHang;
	  STR_TEN_KHACHHANG=strTenKhachHang;
	  DEC_TIENNO_HIENTAI=decTienNoHienTai;
	}
	private void FormThayDoiTienNo_Load(object sender,EventArgs e) {
	  labelXTenKhachHang.Text=STR_TEN_KHACHHANG;
	  labelXTienNoHienTai.Text=(DEC_TIENNO_HIENTAI==0)?"0 đ":DEC_TIENNO_HIENTAI.ToString("#,###.#")+" đ";
	  numericUpDownTienSuaThanh.Value=0;
	  comboBoxExTuyChon.SelectedIndex=0;
	  labelXChiTietThayDoi.Text="";
	  labelXSauKhiThayDoi.Text="";
	}

	private void btnXSuaTienNoHienTai_Click(object sender,EventArgs e) {
	  try {
		string strLoi="";
		if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Sửa thành")) {
		  string strLyDoSua=labelXChiTietThayDoi.Text;
		  string strTrangThaiSuaTienNo=BL_KHACHHANG.STR_SUA_TIENNO_KH(ref strLoi,DEC_TIENNO_HIENTAI,INT_ID_KHACHHANG_HIENTAI,numericUpDownTienSuaThanh.Value,strLyDoSua);
		  if(strTrangThaiSuaTienNo.Equals("false")&&!strLoi.Equals("2")) {
			MessageBox.Show("Xảy ra lỗi khi thay đổi tiền nợ ("+strLoi+") !");
			return;
		  } else {
			decimal decTienNoSuaThanh=numericUpDownTienSuaThanh.Value;
			MessageBox.Show("Thay đổi tiền nợ THÀNH CÔNG !\nTiền nợ hiện tại của khách hàng '"+STR_TEN_KHACHHANG+"' là "+((decTienNoSuaThanh==0)?"0 đ":decTienNoSuaThanh.ToString("#,###.#"))+" đ");
			Close();
		  }
		} else if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Đã trả")) {
		  string strLyDoSua=labelXChiTietThayDoi.Text;
		  string strTrangThaiDaTra=BL_KHACHHANG.STR_DATRA_TIENNO_KH(ref strLoi,DEC_TIENNO_HIENTAI,INT_ID_KHACHHANG_HIENTAI,numericUpDownTienSuaThanh.Value,strLyDoSua);
		  if(strTrangThaiDaTra.Equals("false")&&!strLoi.Equals("2")) {
			MessageBox.Show("Xảy ra lỗi khi cập nhật đã trả ("+strLoi+") !");
			return;
		  } else {
			decimal decTienNoSauKhiSua=DEC_TIENNO_HIENTAI-numericUpDownTienSuaThanh.Value;
			MessageBox.Show("Cập nhật tiền nợ THÀNH CÔNG !\nTiền nợ hiện tại của khách hàng '"+STR_TEN_KHACHHANG+"' là "+((decTienNoSauKhiSua==0)?"0 đ":decTienNoSauKhiSua.ToString("#,###.#"))+" đ");
			Close();
		  }
		} else if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Vay thêm")) {
		  string strLyDoSua=labelXChiTietThayDoi.Text;
		  string strTrangThaiVayThem=BL_KHACHHANG.STR_VAYTHEM_TIENNO_KH(ref strLoi,DEC_TIENNO_HIENTAI,INT_ID_KHACHHANG_HIENTAI,numericUpDownTienSuaThanh.Value,strLyDoSua);
		  if(strTrangThaiVayThem.Equals("false")&&!strLoi.Equals("2")) {
			MessageBox.Show("Xảy ra lỗi khi cập nhật vay thêm ("+strLoi+") !");
			return;
		  } else {
			decimal decTienNoSauKhiSua=DEC_TIENNO_HIENTAI+numericUpDownTienSuaThanh.Value;
			MessageBox.Show("Cập nhật THÀNH CÔNG !\nTiền nợ hiện tại của khách hàng '"+STR_TEN_KHACHHANG+"' là "+((decTienNoSauKhiSua==0)?"0 đ":decTienNoSauKhiSua.ToString("#,###.#"))+" đ");
			Close();
		  }
		} 
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,@"Thông Báo");
	  }
	}


	private void groupBoxChiTietThayDoi_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_CAC_LABEL();
	}
	private void voidCAPNHAT_CAC_LABEL() {
	  string strTienSuaCuThe=((numericUpDownTienSuaThanh.Value==0)?"0":numericUpDownTienSuaThanh.Value.ToString("#,###.#"));
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Sửa thành")) {
		labelXChiTietThayDoi.Text="Tiền nợ sửa thành "+strTienSuaCuThe+" đ";
		labelXSauKhiThayDoi.Text="Từ    "+labelXTienNoHienTai.Text+"    thành    "+strTienSuaCuThe+" đ";
		btnXSuaTienNoHienTai.Enabled=true;
		return;
	  }
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Đã trả")) {
		decimal decHieu=DEC_TIENNO_HIENTAI-numericUpDownTienSuaThanh.Value;
		string strHieu=(decHieu==0)?"0":decHieu.ToString("#,###.#");
		if(decHieu<0) {
		  MessageBox.Show("Bạn đang nhập số tiền khách hàng trả lớn hơn số tiền nợ hiện tại, vui lòng xem lại !");
		  voidRESET_CAC_LABEL();
		  return;
		}
		labelXChiTietThayDoi.Text="Khách hàng đã trả "+strTienSuaCuThe+" đ";
		labelXSauKhiThayDoi.Text=""+labelXTienNoHienTai.Text+"   -   "+strTienSuaCuThe+" đ   =   "+strHieu+" đ";
		btnXSuaTienNoHienTai.Enabled=true;
		return;
	  }
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Vay thêm")) {
		decimal decTong=DEC_TIENNO_HIENTAI+numericUpDownTienSuaThanh.Value;
		string strTong=(decTong==0)?"0":decTong.ToString("#,###.#");
		if(numericUpDownTienSuaThanh.Value<4000) {
		  MessageBox.Show("Bạn đang nhập số tiền khách hàng vay thêm nhỏ hơn 4.000 đ, vui lòng xem lại !");
		  voidRESET_CAC_LABEL();
		  return;
		}
		labelXChiTietThayDoi.Text="Khách hàng vay thêm "+strTienSuaCuThe+" đ";
		labelXSauKhiThayDoi.Text=""+labelXTienNoHienTai.Text+"   +   "+strTienSuaCuThe+" đ   =   "+strTong+" đ";
		btnXSuaTienNoHienTai.Enabled=true;
		return;
	  }
	}
	private void voidRESET_CAC_LABEL() {
	  btnXSuaTienNoHienTai.Enabled=false;
	  numericUpDownTienSuaThanh.Value=0;
	  labelXChiTietThayDoi.Text="";
	  labelXSauKhiThayDoi.Text="";
	}

	private void comboBoxExTuyChon_DropDownClosed(object sender,EventArgs e) {
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Sửa thành")) {
		groupBoxSoTienCuThe.Text="Số tiền nợ cần sửa thành";
	  }
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Đã trả")) {
		groupBoxSoTienCuThe.Text="Số tiền khách hàng trả";
	  }
	  if(comboBoxExTuyChon.SelectedItem.ToString().Equals("Vay thêm")) {
		groupBoxSoTienCuThe.Text="Số tiền khách hàng vay thêm";
	  }
	  labelXChiTietThayDoi.Text="";
	  labelXSauKhiThayDoi.Text="";
	  btnXSuaTienNoHienTai.Enabled=false;
	}

	private void numericUpDownTienSuaThanh_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.N) {
		numericUpDownTienSuaThanh.Value*=1000;
	  }
	}

	private void btnXHuyBo_Click(object sender,EventArgs e) {
	  Close();
	}

	private void labelXChiTietThayDoi_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_CAC_LABEL();
	}

	private void btnXSuaTienNoHienTai_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_CAC_LABEL();
	}
  }
}
