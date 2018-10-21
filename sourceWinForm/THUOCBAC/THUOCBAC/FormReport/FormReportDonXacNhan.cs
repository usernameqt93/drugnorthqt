using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace THUOCBAC.FormReport {
  public partial class FormReportDonXacNhan:Form {
	public FormReportDonXacNhan() {
	  InitializeComponent();
	}
	private DataTable DT_BANG_TENTHUOC;
	private string STR_HOTEN;
	private string STR_NGAYSINH;
	private string STR_SO_CMTND;
	private string STR_HOKHAUTHUONGTRU;
	public FormReportDonXacNhan(DataTable dtBangTenThuoc,string strHoTen,string strNgaySinh,string strSoCMTND,string strHoKhauThuongTru) {
	  InitializeComponent();
	  DT_BANG_TENTHUOC=dtBangTenThuoc;
	  STR_HOTEN=strHoTen;
	  STR_NGAYSINH=strNgaySinh;
	  STR_SO_CMTND=strSoCMTND;
	  STR_HOKHAUTHUONGTRU=strHoKhauThuongTru;
	}

	private void FormReportDonXacNhan_Load(object sender,EventArgs e) {
	  try {
		reportViewerDonXacNhan.ProcessingMode=ProcessingMode.Local;
		reportViewerDonXacNhan.LocalReport.ReportPath="FileReportRdlc/ReportDonXacNhan.rdlc";
		ReportDataSource reportDataSourceGiDo=new ReportDataSource();
		reportDataSourceGiDo.Name="DataSetDanhSachViThuoc";
		//reportDataSourceGiDo.Name="DataSetChiTietDonHang";

		reportDataSourceGiDo.Value=DT_BANG_TENTHUOC;
		ReportParameter reportParameter=new ReportParameter("ReportParameterHoTen",STR_HOTEN);
		reportViewerDonXacNhan.LocalReport.SetParameters(reportParameter);
		reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterNgaySinh",STR_NGAYSINH));
		reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterSoCMTND",STR_SO_CMTND));
		reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterHoKhauThuongTru",STR_HOKHAUTHUONGTRU));
		//reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterSoDienThoai",strSoDienThoai));
		//reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterSoDienThoaiBan",strSoDienThoaiBan));

		//reportViewerDonXacNhan.LocalReport.SetParameters(new ReportParameter("ReportParameterSoTaiKhoan",strSoTaiKhoan));
		reportViewerDonXacNhan.LocalReport.DataSources.Clear();
		reportViewerDonXacNhan.LocalReport.DataSources.Add(reportDataSourceGiDo);

		reportViewerDonXacNhan.RefreshReport();
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,@"Thông Báo");
	  }
	}
  }
}
