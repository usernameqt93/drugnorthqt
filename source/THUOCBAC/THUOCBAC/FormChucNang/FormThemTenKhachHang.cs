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
  public partial class FormThemTenKhachHang:Form {
	private DataTable DT_KHACHHANG=new DataTable();
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	//private int INTSOTHUTUABC=0;
	public FormThemTenKhachHang() {
	  InitializeComponent();
	}
	public delegate void DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(String strTenKhachHang);
	public DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY voidHIENTHI_TENKH_RA_COMBOBOX;
	private void btnXThoat_Click(object sender,EventArgs e) {
	  Close();
	}

	private void FormThemTenKhachHang_Load(object sender,EventArgs e) {
	  voidCAPNHAT_COMBOBOX_TENKH();
	  comboBoxExTenKhachHang.Text="";
	}
	private void voidCAPNHAT_COMBOBOX_TENKH() {
	  DT_KHACHHANG=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  comboBoxExTenKhachHang.DataSource=DT_KHACHHANG;
	  comboBoxExTenKhachHang.DisplayMember=QTDbConst.TENKHACHHANG.STR;
	  comboBoxExTenKhachHang.ValueMember=QTDbConst.ID_BANG_KHACHHANG.STR;
	}

	private void btnXThemTenKH_Click(object sender,EventArgs e) {
	  try {
		if(comboBoxExTenKhachHang.Text.Equals(""))
		  MessageBox.Show("Bạn chưa nhập tên khách hàng !");
		else {
		  string strTenKhachHang=comboBoxExTenKhachHang.Text;
		  string strTenKhachHangDaVietHoaChuCaiDau=""+strTenKhachHang.ElementAt(0).ToString().ToUpper()+strTenKhachHang.Substring(1);
		  int intSTTCuaTenKHTrongComboBox=comboBoxExTenKhachHang.FindStringExact(strTenKhachHangDaVietHoaChuCaiDau);
		  if(intSTTCuaTenKHTrongComboBox>-1) {
			if(voidHIENTHI_TENKH_RA_COMBOBOX!=null)
			  voidHIENTHI_TENKH_RA_COMBOBOX(strTenKhachHangDaVietHoaChuCaiDau);
			MessageBox.Show("Tên khách hàng '"+strTenKhachHangDaVietHoaChuCaiDau+"' đã có trong danh sách, bạn vui lòng xem lại để chọn !");
			Close();
		  } else {
			string strLoi="";
			string strTrangThaiThemKH=BL_KHACHHANG.STR_INSERT_KHACHHANG_LANDAU(ref strLoi,strTenKhachHangDaVietHoaChuCaiDau);
			if(strTrangThaiThemKH.Equals("false")&&!strLoi.Equals("2")) {
			  MessageBox.Show("Thêm tên khách hàng bị LỖI ("+strLoi+")");
			} else {
			  if(voidHIENTHI_TENKH_RA_COMBOBOX!=null)
				voidHIENTHI_TENKH_RA_COMBOBOX(strTenKhachHangDaVietHoaChuCaiDau);
			  MessageBox.Show("Thêm tên khách hàng '"+strTenKhachHangDaVietHoaChuCaiDau+"' vào danh sách THÀNH CÔNG !");
			  Close();
			}
		  }
		}

	  } catch(Exception ex) {
		MessageBox.Show("Có lỗi xảy ra ("+ex.Message+")");

	  }
	}
  }
}
