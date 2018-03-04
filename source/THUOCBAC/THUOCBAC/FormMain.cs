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
using FValueObject.Models;

namespace THUOCBAC {
  public partial class FormMain:DevComponents.DotNetBar.Office2007RibbonForm {

	private BL_Setting BL_SETTING = new BL_Setting();
	BL_ViThuoc BL_VITHUOC=new BL_ViThuoc();
	BL_DonHang BL_DONHANG=new BL_DonHang();
	private const string CONST_STR_DS_DONHANG = "Danh sách các đơn hàng";
	private const string CONST_STR_DS_VITHUOC = "Danh sách các vị thuốc";

	public FormMain() {
	  FormSplashScreen formSpl=new FormSplashScreen();
	  formSpl.ShowDialog();
	  InitializeComponent();

	}

	static int intViTriTab(TabControl TabControlTen,string strTenTab) {
	  int temp=-1;
	  for(int i=0;i<TabControlTen.TabPages.Count;i++) {
		if(TabControlTen.TabPages[i].Text==strTenTab) {
		  temp=i;
		  break;
		}
	  }
	  return temp;
	}

	public void voidTaoTab(TabControl tabControlChinh,string strTenTab,Form Form) {
	  int intSoThuTuTab=intViTriTab(tabControlChinh,strTenTab);
	  if(intSoThuTuTab>=0) {
		//tabControlChinh.TabPages[intSoThuTuTab].Refresh();
		//for(int i=1;i<intSoThuTuTab;i++) {
		//  tabControlChinh.TabPages[intSoThuTuTab].Dispose();
		//}
		tabControlChinh.TabPages[intSoThuTuTab].Dispose();
		//tabControlChinh.SelectedTab=tabControlChinh.TabPages[intSoThuTuTab];
		//tabControlChinh.SelectedTab.Text=strTenTab;

		TabPage TabPage=new TabPage { Text=strTenTab };
		tabControlChinh.TabPages.Add(TabPage);
		tabControlChinh.SelectedTab=TabPage;
		Form.TopLevel=false;
		Form.Parent=TabPage;
		Form.Show();
		Form.Dock=DockStyle.Fill;
	  } else {
		if(tabControlChinh.TabCount==2)
		  tabControlChinh.TabPages[1].Dispose();
		TabPage TabPage=new TabPage { Text=strTenTab };
		tabControlChinh.TabPages.Add(TabPage);
		tabControlChinh.SelectedTab=TabPage;
		Form.TopLevel=false;
		Form.Parent=TabPage;
		//Form.StartPosition=FormStartPosition.CenterParent;
		Form.Show();
		Form.Dock=DockStyle.Fill;
	  }
	}

	private void btnIDanhSachViThuoc_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachViThuoc formDanhSachViThuoc=new FormDanhSach.FormDanhSachViThuoc();
	  voidTaoTab(tabControlChinh,CONST_STR_DS_VITHUOC,formDanhSachViThuoc);
	}

	private void btnIDanhSachDonHang_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachDonHang formDanhSachDonHang=new FormDanhSach.FormDanhSachDonHang();
	  voidTaoTab(tabControlChinh,CONST_STR_DS_DONHANG,formDanhSachDonHang);
	}

	private void buttonItemDonXinXacNhan_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachDonXinXacNhan formDanhSachDonXacNhan=new FormDanhSach.FormDanhSachDonXinXacNhan();
	  voidTaoTab(tabControlChinh,"Danh sách đơn xin xác nhận",formDanhSachDonXacNhan);
	}

	private void btnXXemChiTietDSDonHang_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachDonHang formDanhSachDonHang=new FormDanhSach.FormDanhSachDonHang();
	  voidTaoTab(tabControlChinh,CONST_STR_DS_DONHANG,formDanhSachDonHang);
	}

	private void btnXXemChiTietDSViThuoc_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachViThuoc formDanhSachViThuoc=new FormDanhSach.FormDanhSachViThuoc();
	  voidTaoTab(tabControlChinh,CONST_STR_DS_VITHUOC,formDanhSachViThuoc);
	}

	private void FormMain_Load(object sender,EventArgs e) {
	  //tabPage1.w
	  string strLoiTongViThuoc="";
	  int intTongViThuoc=BL_VITHUOC.intTongSoViThuocTrongDanhSach(ref strLoiTongViThuoc);
	  if(!strLoiTongViThuoc.Equals("")) {
		MessageBox.Show("Hiện tại có lỗi trong danh sách hoặc lỗi kết nối csdl hoặc lỗi service ("+strLoiTongViThuoc+")");
		Application.Exit();
	  }
	  if(intTongViThuoc==0) {
		string strThemViThuocDauTien=BL_VITHUOC.strINSERT_VITHUOC_DAUTIEN(ref strLoiTongViThuoc);
		labelXTongViThuoc.Text="1 vị thuốc";
	  } else
		labelXTongViThuoc.Text=""+intTongViThuoc+" vị thuốc";
	  string strLoiTongDonHang="";
	  int intTongDonHang=BL_DONHANG.intTongDonHangTrongDanhSach(ref strLoiTongDonHang);
	  if(!strLoiTongDonHang.Equals(""))
		MessageBox.Show("Hiện tại có lỗi trong danh sách đơn hàng ("+strLoiTongDonHang+")");
	  labelXTongSoDonHang.Text=""+intTongDonHang+" đơn hàng";
	}

	private void buttonItemThongTinInAn_Click(object sender,EventArgs e) {
	  FormCaiDat.FormThongTinInAn formCaiDatInAn=new FormCaiDat.FormThongTinInAn();
	  formCaiDatInAn.ShowDialog();
	}

	private void FormMain_Shown(object sender,EventArgs e) {
	  DateTime dtBayGio=DateTime.Now;
	  DateTime dtThoiGianHetHan=new DateTime(2018,03,29);
	  DateTime dtThoiGianGanHetHan=dtThoiGianHetHan.AddDays(-5);
	  DateTime dtThoiGianBatDauSuDung=new DateTime(2017,12,27);
	  int intSoSanhHetHan=DateTime.Compare(dtBayGio,dtThoiGianHetHan);
	  int intSoSanhBatDauSuDung=DateTime.Compare(dtBayGio,dtThoiGianBatDauSuDung);
	  //Tuc la den ngay 21/05/2017 00h00 thi no hien ra
	  if(intSoSanhHetHan==1||intSoSanhBatDauSuDung==-1) {
		FormThongBao.FormThongBaoHetHan formThongBaoHetHan=new FormThongBao.FormThongBaoHetHan();
		formThongBaoHetHan.ShowDialog();
		Application.Exit();
	  }

	  VOID_LOAD_APP_SETTING();
	}

	private void VOID_LOAD_APP_SETTING() {

	  BangSettingModel mBangSetting = new BangSettingModel();
	  BL_SETTING.VOID_LAYTHONGTIN_BANGSETTING(ref mBangSetting);
	  QTAppSetting.STATIC_STR_CACHXEM_BANIN=mBangSetting.CACHXEM_BANIN;
	}

	private void buttonItemXemGiaThuoc_Click(object sender,EventArgs e) {
	  FormChucNang.FormXemGiaThuoc formXemGiaThuoc=new FormChucNang.FormXemGiaThuoc();
	  formXemGiaThuoc.ShowDialog();
	}

	private void btnIDanhSachKhachHang_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachKhachHang formDanhSachKH=new FormDanhSach.FormDanhSachKhachHang();
	  voidTaoTab(tabControlChinh,"Danh sách khách hàng",formDanhSachKH);
	}

	private void btnItemOption_Click(object sender,EventArgs e) {
	  FormCaiDat.frmLoginOption frm = new FormCaiDat.frmLoginOption();
	  frm.ShowDialog();
	}
  }
}
