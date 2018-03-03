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

namespace THUOCBAC.FormChucNang {
  public partial class FormThemViThuoc:Form {
	private BL_ViThuoc BL_VITHUOC=new BL_ViThuoc();
	public FormThemViThuoc() {
	  InitializeComponent();
	}

	private void buttonXHuyThemViThuoc_Click(object sender,EventArgs e) {
	  this.Close();
	}

	private void buttonXThemViThuoc_Click(object sender,EventArgs e) {
	  try {
		if(txtXTenViThuoc.Text.Equals(""))
		  MessageBox.Show("Tên vị thuốc không được để trống !");
		else if(numericGiaViThuoc.Value<1000)
		  MessageBox.Show("Giá vị thuốc không được nhỏ hơn 1.000 VNĐ");
		else if(comboBoxEDonViTinh.Text.Equals(""))
		  MessageBox.Show("Đơn vị tính không được để trống");
		else {
		  string strLoi="";
		  string strDonViTinh=comboBoxEDonViTinh.SelectedItem.ToString();
		  //string strTenViThuocVietHoaChuDau=txtXTenViThuoc.Text;
		  string strTenViThuocVietHoaChuDau=""+txtXTenViThuoc.Text.ElementAt(0).ToString().ToUpper()+
			txtXTenViThuoc.Text.Substring(1);
		  string strTrangThaiInsertViThuoc=
			BL_VITHUOC.strInsertViThuocVaGia(ref strLoi,strTenViThuocVietHoaChuDau,numericGiaViThuoc.Value,
				strDonViTinh,txtXGhiChuViThuoc.Text);
		  if (strTrangThaiInsertViThuoc.Equals("false") && !strLoi.Equals("3"))
			MessageBox.Show("Trạng thái thêm vị thuốc lỗi ("+strLoi+")");
		  else {
			MessageBox.Show("Thêm tên vị thuốc thành công!");
			this.Close();
		  }
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void FormThemViThuoc_Load(object sender,EventArgs e) {
	  comboBoxEDonViTinh.SelectedIndex=3;
	}
  }
}
