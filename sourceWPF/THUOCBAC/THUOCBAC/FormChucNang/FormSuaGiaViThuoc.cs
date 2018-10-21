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
  public partial class FormSuaGiaViThuoc:Form {
	private int INT_MAGIATHUOC=-1;
	private int INT_MA_VITHUOC=-1;
	private BL_GiaViThuoc BL_GIA_VITHUOC=new BL_GiaViThuoc();
	public FormSuaGiaViThuoc() {
	  InitializeComponent();
	}
	public FormSuaGiaViThuoc(int intMaViThuoc,int intMaGiaThuoc,string strTenViThuoc,decimal decimalGiaViThuoc,string strDonViTinh) {
	  InitializeComponent();
	  txtXTenViThuoc.Text=strTenViThuoc;
	  numericGiaViThuoc.Value=decimalGiaViThuoc;
	  comboBoxEDonViTinh.SelectedText=strDonViTinh;
	  INT_MAGIATHUOC=intMaGiaThuoc;
	  INT_MA_VITHUOC=intMaViThuoc;
	}

	private void btnXHuyBo_Click(object sender,EventArgs e) {
	  this.Close();
	}
	private void btnXLuuGiaViThuoc_Click(object sender,EventArgs e) {
	  try {
		if(numericGiaViThuoc.Value<1000)
		  MessageBox.Show("Giá vị thuốc không được nhỏ hơn 1.000 VNĐ");
		else if(comboBoxEDonViTinh.Text.Equals(""))
		  MessageBox.Show("Bạn chưa chọn đơn vị tính cho vị thuốc này");
		else if(txtXTenViThuoc.Text.Equals(""))
		  MessageBox.Show("Tên vị thuốc không được để trống");
		else {
		  string strLoiUpdateGia="";
		  string strLoiUpdateTenThuoc="";
		  string strDonViTinh=comboBoxEDonViTinh.Text;
		  bool boolTrangThaiUpdateGiaViThuoc=
			BL_GIA_VITHUOC.boolUpdateGiaViThuoc(ref strLoiUpdateGia,numericGiaViThuoc.Value,strDonViTinh,INT_MAGIATHUOC);
		  bool boolTrangThaiUpdateTenViThuoc=
			BL_GIA_VITHUOC.boolUpdateViThuoc(ref strLoiUpdateTenThuoc,txtXTenViThuoc.Text,INT_MA_VITHUOC);
		  if(!boolTrangThaiUpdateGiaViThuoc || !boolTrangThaiUpdateTenViThuoc)
			MessageBox.Show("Trạng thái sửa giá thuốc lỗi ("+strLoiUpdateGia+")("+strLoiUpdateTenThuoc+")");
		  else {
			MessageBox.Show("Sửa giá thuốc như trên thành công");
			this.Close();
		  }
		}
		//if(txtXTenViThuoc.Text.Equals(""))
		//  MessageBox.Show("Tên vị thuốc không được để trống !");
		//else {
		//  string strLoi="";
		//  string strTrangThaiInsertViThuoc=
		//	BL_VITHUOC.strInsertBangDanhSachLopHoc(ref strLoi,txtXTenViThuoc.Text,txtXGhiChuViThuoc.Text);
		//  if(strTrangThaiInsertViThuoc.Equals("false"))
		//	MessageBox.Show("Trạng thái thêm vị thuốc lỗi ("+strLoi+")");
		//  else {
		//	MessageBox.Show("Thêm tên vị thuốc thành công!");
		//	this.Close();
		//  }
		//}
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,@"Thông Báo");
	  }
	}
  }
}
