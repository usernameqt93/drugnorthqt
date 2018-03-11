using FValueObject.Models;
using Microsoft.Reporting.WinForms;
using QTCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormReport {
  public partial class frmReportInDonHang:Form {

	private InfoOrderModelToPrint M_INFO_ORDER;

	public frmReportInDonHang() {
	  InitializeComponent();
	}

	public frmReportInDonHang(InfoOrderModelToPrint _mInfo) {
	  InitializeComponent();
	  M_INFO_ORDER=_mInfo;
	}

	private void frmReportInDonHang_Load(object sender,EventArgs e) {
	  VOID_LOAD_FORM();
	}

	private void voidGAN_REPORTPATH(decimal DEC_TIENNO_CU) {
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A4.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA4ChuTo.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA4CoSoNoCu.rdlc";
	  }
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A4_KIEU_2.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA4Kieu2.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA4Kieu2CoSoNoCu.rdlc";
	  }
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A5.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA5.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA5CoSoNoCu.rdlc";
	  }
	}

	private void voidCAIDAT_KICHTHUOC_TRANG() {
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A5.STR)) {
		PageSettings caiDatTrang = new PageSettings();
		caiDatTrang.Margins.Top=39;
		caiDatTrang.Margins.Bottom=39;
		caiDatTrang.Margins.Left=0;
		caiDatTrang.Margins.Right=0;
		PaperSize kichThuoc = new PaperSize("",580,830);
		kichThuoc.RawKind=(int)PaperKind.A5;
		caiDatTrang.PaperSize=kichThuoc;
		//caiDatTrang.PaperSize=new PaperSize("",580,830);
		//caiDatTrang.Landscape=true;
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
		//rpt.SetPageSettings(new System.Drawing.Printing.PageSettings() { Landscape = true });
	  }
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A4_KIEU_2.STR)) {
		PageSettings caiDatTrang = new PageSettings();
		caiDatTrang.Margins.Top=79;
		caiDatTrang.Margins.Bottom=79;
		caiDatTrang.Margins.Left=39;
		caiDatTrang.Margins.Right=39;
		caiDatTrang.PaperSize=new PaperSize("",830,1170);
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
	  }
	  if(M_INFO_ORDER.strSizePaper.Equals(QTStringConst.KHO_A4.STR)) {
		PageSettings caiDatTrang = new PageSettings();
		caiDatTrang.Margins.Top=79;
		caiDatTrang.Margins.Bottom=79;
		caiDatTrang.Margins.Left=39;
		caiDatTrang.Margins.Right=39;
		caiDatTrang.PaperSize=new PaperSize("",830,1170);
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
	  }
	}

	private void VOID_LOAD_FORM() {
	  try {
		//string strThoiGian = M_INFO_ORDER.strTime;
		//string strTenNhaThuoc = txtXNhaThuoc.Text;
		//string strNganhNghe = txtXNgheNghiep.Text;
		//string strDiaChi = txtXDiaChi.Text;
		//string strSoDienThoai = txtXSoDienThoai.Text;
		//string strSoTaiKhoan = txtXSoTaiKhoanNganHang.Text;
		//string strSoDienThoaiBan = txtXDienThoaiBan.Text;
		string strTongTien = ""+M_INFO_ORDER.decSumMoney.ToString("#,###.#")+" đ";
		//string strTenKhachHang = (comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR)) ? " " : comboBoxExTenKhachHang.Text;
		//string strSDTKH = (txtXSDTKH.Text.Equals("")) ? " " : txtXSDTKH.Text;
		decimal DEC_TIENNO_CU=M_INFO_ORDER.decDebtNumber;
		string strTienNoCu = ""+DEC_TIENNO_CU.ToString("#,###.#")+" đ";
		string strTienCongDon = ""+(DEC_TIENNO_CU+M_INFO_ORDER.decSumMoney).ToString("#,###.#")+" đ";

		voidGAN_REPORTPATH(DEC_TIENNO_CU);

		ReportDataSource reportDataSourceGiDo = new ReportDataSource();
		reportDataSourceGiDo.Name="DataSetChiTietHoaDonTamThoi";

		reportDataSourceGiDo.Value=M_INFO_ORDER.dtDetailOrder;
		if(DEC_TIENNO_CU>0) {

		  QTLibraryFunction.STATIC_VOID_SET_PARAMETERS_TO_REPORT(ref reportViewerChiTietDonHang
		  ,new List<string>() { "ReportParameterTienNoCu","ReportParameterTienCongDon" }
		  ,new List<string>() { strTienNoCu,strTienCongDon });
		}
		QTLibraryFunction.STATIC_VOID_SET_PARAMETERS_TO_REPORT(ref reportViewerChiTietDonHang
		  ,new List<string>() { "ReportParameterTongTien","ReportParameterThoiGian","ReportParameterSDTKhachHang","ReportParameterTenKhachHang","ReportParameterTenNhaThuoc","ReportParameterNganhNghe","ReportParameterDiaChi","ReportParameterSoDienThoai","ReportParameterSoDienThoaiBan","ReportParameterSoTaiKhoan" }
		  ,new List<string>() { strTongTien,M_INFO_ORDER.strTime,M_INFO_ORDER.strPhone,M_INFO_ORDER.strCustomerName,QTAppInfo.FullName,QTAppInfo.JobInfo,QTAppInfo.Address,QTAppInfo.Phone,QTAppInfo.PhoneDesk,QTAppInfo.AccountBank });

		reportViewerChiTietDonHang.LocalReport.DataSources.Clear();
		reportViewerChiTietDonHang.LocalReport.DataSources.Add(reportDataSourceGiDo);

		reportViewerChiTietDonHang.SetDisplayMode(DisplayMode.PrintLayout);
		reportViewerChiTietDonHang.ZoomMode=ZoomMode.Percent;
		reportViewerChiTietDonHang.ZoomPercent=100;
		reportViewerChiTietDonHang.ShowRefreshButton=false;
		reportViewerChiTietDonHang.ShowZoomControl=false;
		reportViewerChiTietDonHang.ShowPrintButton=false;
		//reportViewerChiTietDonHang.
		reportViewerChiTietDonHang.LocalReport.DisplayName="Don hang";

		voidCAIDAT_KICHTHUOC_TRANG();

		reportViewerChiTietDonHang.RefreshReport();
		//string strLoi = "";
		//int intIdKhachHangDangChon = Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
		//bool boolCapNhatTenKHVaoDH=BL_DONHANG.boolUPDATE_IDKH_VAO_DH(ref strLoi,intIdKhachHangDangChon,INT_MADH_HIENTAI);
		//if(boolCapNhatTenKHVaoDH)
		//  MessageBox.Show("Tên khách hàng '"+strTenKhachHang+"' đã được lưu vào đơn hàng này !");
		//else
		//  MessageBox.Show("Có lỗi gì đó khi lưu tên khách hàng này vào đơn hàng ("+strLoi+")");
		//bool boolCapNhatTienNoCuTenKHVaoDH = BL_DONHANG.boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref strLoi,intIdKhachHangDangChon,strSDTKH,DEC_TIENNO_CU,INT_MADH_HIENTAI);
		//if(!boolCapNhatTienNoCuTenKHVaoDH) {
		//  MessageBox.Show("Có lỗi gì đó khi lưu tên khách hàng,tiền nợ cũ này vào đơn hàng ("+strLoi+")");
		//}
	  } catch(Exception ex) {
		//MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
		MessageBox.Show(this.Name+" - VOID_LOAD_FORM - "+@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXPrint_Click(object sender,EventArgs e) {
	  //reportViewerChiTietDonHang.PrinterSettings.Copies=(short)M_INFO_ORDER.decCopyNumber;

	  //ShowThePrintDialog printD = new ShowThePrintDialog(printDialog1.ShowDialog);

	  //this.BeginInvoke(printD);
	  //reportViewerChiTietDonHang.PrintDialog();
	  //string fdgfd = "";
	  timer1.Start();
	}

	private void timer1_Tick(object sender,EventArgs e) {
	  timer1.Stop();
	  reportViewerChiTietDonHang.PrinterSettings.Copies=(short)M_INFO_ORDER.decCopyNumber;
	  reportViewerChiTietDonHang.PrintDialog();
	}
  }
}
