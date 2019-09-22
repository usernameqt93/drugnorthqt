using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC {
  public partial class FormChinh:Form {
	public FormChinh() {
	  FormSplashScreen formSpl=new FormSplashScreen();
	  formSpl.ShowDialog();
	  InitializeComponent();
	}

	static int intViTriTab(TabControl TabControlName,string strTenTab) {
	  int temp=-1;
	  for(int i=0;i<TabControlName.TabPages.Count;i++) {
		if(TabControlName.TabPages[i].Text==strTenTab) {
		  temp=i;
		  break;
		}
	  }
	  return temp;
	}

	public void voidTaoTab(TabControl tabControlChinh,string strTenTab,Form Form) {
	  int intSoThuTuTab=intViTriTab(tabControlChinh,strTenTab);
	  if(intSoThuTuTab>=0) {
		tabControlChinh.SelectedTab=tabControlChinh.TabPages[intSoThuTuTab];
		tabControlChinh.SelectedTab.Text=strTenTab;
	  } else {
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

	private void buttonXDSViThuoc_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachViThuoc formDanhSachViThuoc=new FormDanhSach.FormDanhSachViThuoc();
	  voidTaoTab(tabControlChinh,"Danh sách các vị thuốc",formDanhSachViThuoc);
	}

	private void buttonXDSDonHang_Click(object sender,EventArgs e) {
	  FormDanhSach.FormDanhSachDonHang formDanhSachDonHang=new FormDanhSach.FormDanhSachDonHang();
	  voidTaoTab(tabControlChinh,"Danh sách các đơn hàng",formDanhSachDonHang);
	}
  }
}
