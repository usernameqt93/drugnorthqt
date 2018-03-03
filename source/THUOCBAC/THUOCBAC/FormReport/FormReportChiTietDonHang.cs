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
using Microsoft.Reporting.WinForms;
using BusinessLogic;
using QTCommon;

namespace THUOCBAC.FormReport {
  public partial class FormReportChiTietDonHang:Form {
	private BL_CaiDat BL_CAIDAT=new BL_CaiDat();
	private BL_KhachHang BL_KHACHHANG=new BL_KhachHang();
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	private int INT_IDKH_HIENTAI=-1;
	public FormReportChiTietDonHang() {
	  InitializeComponent();
	}
	private DataTable DT_CHITIET_DONHANG;
	private DataTable DT_KHACHHANG=new DataTable();
	private decimal DEC_TONGTIEN=0;
	private int INT_MADH_HIENTAI=0;
	private string STR_SDT_KH_HIENTAI="";
	private decimal DEC_TIENNO_CU=0;
	private decimal DEC_TIENNO_HIENTAI_CUA_KH=-1;
	private DateTime DT_THOIGIAN_VIETDH;

	public FormReportChiTietDonHang(
	  DataTable dtChiTietDonHang,decimal decTongTien,int intMaDonHangHienTai,int intIdKHHienTai,string strSDTKH,decimal decTienNoCu,DateTime dtThoiGianVietDH) {
	  InitializeComponent();
	  DT_CHITIET_DONHANG=dtChiTietDonHang;
	  DEC_TONGTIEN=decTongTien;
	  INT_MADH_HIENTAI=intMaDonHangHienTai;
	  INT_IDKH_HIENTAI=intIdKHHienTai;
	  STR_SDT_KH_HIENTAI=strSDTKH;
	  DEC_TIENNO_CU=decTienNoCu;
	  DT_THOIGIAN_VIETDH=dtThoiGianVietDH;
	}

	private void FormReportChiTietDonHang_Load(object sender,EventArgs e) {
	  QTAppTemp.QT_RESET_APP_TEMP();
	  comboBoxExTuyChonMauGiay.SelectedIndex=0;
	  reportViewerChiTietDonHang.ProcessingMode=ProcessingMode.Local;
	  string strHoTen="";
	  string strSDT="";
	  string strSoTK="";
	  string strSDTBan="";
	  string strNgheNghiep="";
	  string strDiaChi="";
	  BL_CAIDAT.VOID_LAYTHONGTIN_BANGCAIDAT(ref strHoTen,ref strSDT,ref strSoTK,ref strSDTBan,ref strNgheNghiep,ref strDiaChi);
	  txtXNhaThuoc.Text=strHoTen;
	  txtXSoDienThoai.Text=strSDT;
	  txtXSoTaiKhoanNganHang.Text=strSoTK;
	  txtXDienThoaiBan.Text=strSDTBan;
	  txtXNgheNghiep.Text=strNgheNghiep;
	  txtXDiaChi.Text=strDiaChi;
	  dateTimeInputThoiGian.Value=DT_THOIGIAN_VIETDH;

	  voidCAPNHAT_COMBOBOX_TENKH();
	  comboBoxExTenKhachHang.SelectedValue=INT_IDKH_HIENTAI;

	  //QTAppTemp.STATIC_INT_ID_CHOOSE=INT_IDKH_HIENTAI;

	  if(!comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR))
	  DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(INT_IDKH_HIENTAI);
	  txtXSDTKH.Text=STR_SDT_KH_HIENTAI;
	  numericUpDownTienNo.Value=DEC_TIENNO_CU;
	  if(!comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR)) {
		btnXXemThongTinNo.Enabled=true;
		string strCapNhatChua=BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(INT_MADH_HIENTAI);
		if(strCapNhatChua.Equals(QTStringConst.CHUACAPNHAT.STR))
		  btnXCongTienDonHangKH.Enabled=true;
	  }
	  //comboBoxExTenKhachHang.SelectedIndex=0;
	  //comboBoxExTenKhachHang.Items.Add("  --Để trống--  ");
	  //comboBoxExTenKhachHang.SelectedItem=comboBoxExTenKhachHang.Items.Add("  --Để trống--");
	}

	private void voidHIENTHI_TENKH_RA_COMBOBOX(string strTenKhachHang) {
	  voidCAPNHAT_COMBOBOX_TENKH();
	  int intSTTCuaTenKHTrongCombobox=comboBoxExTenKhachHang.FindStringExact(strTenKhachHang);
	  comboBoxExTenKhachHang.SelectedIndex=intSTTCuaTenKHTrongCombobox;
	}

	private void voidHIENTHI_TIENNOCU_RA_NUMBERIC(decimal decTienNoCu) {
	  numericUpDownTienNo.Value=decTienNoCu;
	}

	private void voidCAPNHAT_COMBOBOX_TENKH() {
	  DT_KHACHHANG=BL_KHACHHANG.DATATABLE_BANG_KHACHHANG_XEPTHEOTEN();
	  comboBoxExTenKhachHang.DataSource=DT_KHACHHANG;
	  comboBoxExTenKhachHang.DisplayMember=QTDbConst.TENKHACHHANG.STR;
	  comboBoxExTenKhachHang.ValueMember=QTDbConst.ID_BANG_KHACHHANG.STR;
	}

	private void btnXHienThi_Click(object sender,EventArgs e) {
	  //string strCapNhatChua=BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(INT_MADH_HIENTAI);
	  //if(strCapNhatChua.Equals("")) {
	  //  MessageBox.Show("Cột 'CapNhatTienNoChua' hiện đang có giá trị khác 'Đã cập nhật' và 'Chưa cập nhật' !");
	  //  return;
	  //}
	  //string strTenKhachHangDangChon=comboBoxExTenKhachHang.Text;
	  //decimal decTienNoCuDangGhi=numericUpDownTienNo.Value;
	  //if(strCapNhatChua.Equals(QTStringConst.CHUACAPNHAT.STR)&&!strTenKhachHangDangChon.Equals(QTStringConst.KHONGGHIVAO.STR)&&(DEC_TIENNO_HIENTAI_CUA_KH>-1)) {
	  //  string strNoiDung=(DEC_TIENNO_HIENTAI_CUA_KH<1)?"Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là 0 đ":"Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là "+DEC_TIENNO_HIENTAI_CUA_KH.ToString("#,###.#")+" đ";
	  //  strNoiDung+="\nBạn có muốn cộng tiền đơn hàng này ("+DEC_TONGTIEN.ToString("#,###.#")+" đ) vào tổng số tiền nợ của khách hàng này không ?";
	  //  strNoiDung+="\n        "+((DEC_TIENNO_HIENTAI_CUA_KH==0)?"0":DEC_TIENNO_HIENTAI_CUA_KH.ToString("#,###.#"))+" + "+DEC_TONGTIEN.ToString("#,###.#")+" = "+(DEC_TIENNO_HIENTAI_CUA_KH+DEC_TONGTIEN).ToString("#,###.#")+" đ";
	  //  DialogResult dlr=MessageBox.Show(strNoiDung, "Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
	  //  if(dlr==DialogResult.Yes) {
	  //	string strLoiCapNhatTienNo="";
	  //	int intIdKhachHangVuaChonComboBox=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
	  //	string strLyDoSua="Cộng thêm tiền đơn hàng "+INT_MADH_HIENTAI+" ("+DT_THOIGIAN_VIETDH+")";
	  //	string strTrangThaiCapNhat=BL_KHACHHANG.STR_CAPNHAT_TIENNO_KH(ref strLoiCapNhatTienNo,
	  //	  INT_MADH_HIENTAI,DEC_TIENNO_HIENTAI_CUA_KH,intIdKhachHangVuaChonComboBox,strLyDoSua,DEC_TONGTIEN);
	  //	if(strTrangThaiCapNhat.Equals("false")&&!(strLoiCapNhatTienNo.Equals("3"))) {
	  //	  MessageBox.Show("Trạng thái cập nhật tiền nợ bị lỗi ("+strLoiCapNhatTienNo+")");
	  //	} else {
	  //	  MessageBox.Show("LƯU THÀNH CÔNG!\nHiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' là "+(DEC_TIENNO_HIENTAI_CUA_KH+DEC_TONGTIEN).ToString("#,###.#")+" đ");
	  //	}
	  //  }
	  //}
	  groupBoxChucNang.Enabled=false;
	  groupBoxThongTinThem.Enabled=false;
	  try {
		string strThoiGian="Ngày   "+dateTimeInputThoiGian.Value.ToString("dd")+"   tháng   "+dateTimeInputThoiGian.Value.ToString("MM")+"   năm   "+dateTimeInputThoiGian.Value.Year;
		string strTenNhaThuoc=txtXNhaThuoc.Text;
		string strNganhNghe=txtXNgheNghiep.Text;
		string strDiaChi=txtXDiaChi.Text;
		string strSoDienThoai=txtXSoDienThoai.Text;
		string strSoTaiKhoan=txtXSoTaiKhoanNganHang.Text;
		string strSoDienThoaiBan=txtXDienThoaiBan.Text;
		string strTongTien=""+DEC_TONGTIEN.ToString("#,###.#")+" đ";
		string strTenKhachHang=(comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR))?" ":comboBoxExTenKhachHang.Text;
		string strSDTKH=(txtXSDTKH.Text.Equals(""))?" ":txtXSDTKH.Text;
		DEC_TIENNO_CU=numericUpDownTienNo.Value;
		string strTienNoCu=""+DEC_TIENNO_CU.ToString("#,###.#")+" đ";
		string strTienCongDon=""+(DEC_TIENNO_CU+DEC_TONGTIEN).ToString("#,###.#")+" đ";

		voidGAN_REPORTPATH();

		ReportDataSource reportDataSourceGiDo=new ReportDataSource();
		reportDataSourceGiDo.Name="DataSetChiTietHoaDonTamThoi";
		
		reportDataSourceGiDo.Value=DT_CHITIET_DONHANG;
		ReportParameter reportParameter=new ReportParameter("ReportParameterTongTien",strTongTien);
		reportViewerChiTietDonHang.LocalReport.SetParameters(reportParameter);
		if(DEC_TIENNO_CU>0) {
		  reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterTienNoCu",strTienNoCu));
		  reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterTienCongDon",strTienCongDon));
		}
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterThoiGian",strThoiGian));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterSDTKhachHang",strSDTKH));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterTenKhachHang",strTenKhachHang));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterTenNhaThuoc",strTenNhaThuoc));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterNganhNghe",strNganhNghe));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterDiaChi",strDiaChi));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterSoDienThoai",strSoDienThoai));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterSoDienThoaiBan",strSoDienThoaiBan));
		reportViewerChiTietDonHang.LocalReport.SetParameters(new ReportParameter("ReportParameterSoTaiKhoan",strSoTaiKhoan));
		reportViewerChiTietDonHang.LocalReport.DataSources.Clear();
		reportViewerChiTietDonHang.LocalReport.DataSources.Add(reportDataSourceGiDo);

		reportViewerChiTietDonHang.SetDisplayMode(DisplayMode.PrintLayout);
		reportViewerChiTietDonHang.ZoomMode=ZoomMode.Percent;
		reportViewerChiTietDonHang.ZoomPercent=100;
		reportViewerChiTietDonHang.LocalReport.DisplayName="Don hang";

		voidCAIDAT_KICHTHUOC_TRANG();

		reportViewerChiTietDonHang.RefreshReport();
		//reportViewerChiTietDonHang.PrinterSettings.
		string strLoi="";
		int intIdKhachHangDangChon=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
		//bool boolCapNhatTenKHVaoDH=BL_DONHANG.boolUPDATE_IDKH_VAO_DH(ref strLoi,intIdKhachHangDangChon,INT_MADH_HIENTAI);
		//if(boolCapNhatTenKHVaoDH)
		//  MessageBox.Show("Tên khách hàng '"+strTenKhachHang+"' đã được lưu vào đơn hàng này !");
		//else
		//  MessageBox.Show("Có lỗi gì đó khi lưu tên khách hàng này vào đơn hàng ("+strLoi+")");
		bool boolCapNhatTienNoCuTenKHVaoDH=BL_DONHANG.boolUPDATE_TIENNO_CU_IDKH_VAO_DH(ref strLoi,intIdKhachHangDangChon,strSDTKH,DEC_TIENNO_CU,INT_MADH_HIENTAI);
		if(!boolCapNhatTienNoCuTenKHVaoDH) {
		  MessageBox.Show("Có lỗi gì đó khi lưu tên khách hàng,tiền nợ cũ này vào đơn hàng ("+strLoi+")");
		}
	  } catch(Exception ex) {
		//MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
		MessageBox.Show(this.Name+" - btnXHienThi_Click - "+@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	  groupBoxChucNang.Enabled=true;
	  groupBoxThongTinThem.Enabled=true;
	}

	private void voidGAN_REPORTPATH() {
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A4.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA4ChuTo.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA4CoSoNoCu.rdlc";
	  }
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A4_KIEU_2.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA4Kieu2.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA4Kieu2CoSoNoCu.rdlc";
	  }
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A5.STR)) {
		if(DEC_TIENNO_CU==0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportChiTietDonHangKhoA5.rdlc";
		if(DEC_TIENNO_CU>0)
		  reportViewerChiTietDonHang.LocalReport.ReportPath="FileReportRdlc/ReportCTDHKhoA5CoSoNoCu.rdlc";
	  }
	}

	private void voidCAIDAT_KICHTHUOC_TRANG() {
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A5.STR)) {
		PageSettings caiDatTrang=new PageSettings();
		caiDatTrang.Margins.Top=39;
		caiDatTrang.Margins.Bottom=39;
		caiDatTrang.Margins.Left=0;
		caiDatTrang.Margins.Right=0;
		PaperSize kichThuoc=new PaperSize("",580,830);
		kichThuoc.RawKind=(int)PaperKind.A5;
		caiDatTrang.PaperSize=kichThuoc;
		//caiDatTrang.PaperSize=new PaperSize("",580,830);
		//caiDatTrang.Landscape=true;
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
		//rpt.SetPageSettings(new System.Drawing.Printing.PageSettings() { Landscape = true });
	  }
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A4_KIEU_2.STR)) {
		PageSettings caiDatTrang=new PageSettings();
		caiDatTrang.Margins.Top=79;
		caiDatTrang.Margins.Bottom=79;
		caiDatTrang.Margins.Left=39;
		caiDatTrang.Margins.Right=39;
		caiDatTrang.PaperSize=new PaperSize("",830,1170);
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
	  }
	  if(comboBoxExTuyChonMauGiay.SelectedItem.ToString().Equals(QTStringConst.KHO_A4.STR)) {
		PageSettings caiDatTrang=new PageSettings();
		caiDatTrang.Margins.Top=79;
		caiDatTrang.Margins.Bottom=79;
		caiDatTrang.Margins.Left=39;
		caiDatTrang.Margins.Right=39;
		caiDatTrang.PaperSize=new PaperSize("",830,1170);
		reportViewerChiTietDonHang.SetPageSettings(caiDatTrang);
	  }
	}


	private void btnXThemTenKhachHang_Click(object sender,EventArgs e) {
	  //int intSoThuTuABC=0;
	  FormChucNang.FormThemTenKhachHang formThemKhachHang=new FormChucNang.FormThemTenKhachHang();
	  formThemKhachHang.voidHIENTHI_TENKH_RA_COMBOBOX=new FormChucNang.FormThemTenKhachHang.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TENKH_RA_COMBOBOX);
	  formThemKhachHang.ShowDialog();
	  //voidCAPNHAT_COMBOBOX_TENKH();
	}

	private void numericUpDownTienNo_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.N) {
		numericUpDownTienNo.Value*=1000;
	  }
	}

	private void btnXXemThongTinNo_Click(object sender,EventArgs e) {
	  btnXXemThongTinNo.Enabled=false;
	  if(comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR)) {
		MessageBox.Show("Bạn chưa chọn tên khách hàng, chưa hiển thị thông tin được !");
		return;
	  }
	  int intIdKHVuaChonTrongComboBox = Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
	  string strTenKhachHangDangChon = comboBoxExTenKhachHang.Text;
	  //int intIdKHVuaChonTrongComboBox = QTAppTemp.STATIC_INT_ID_CHOOSE;
	  //string strTenKhachHangDangChon = txtXNameCustomer.Text;
	  DataTable dtLichSuTienNo=BL_KHACHHANG.DATATABLE_LICHSU_TIENNO_THEO_IDKH(intIdKHVuaChonTrongComboBox);
	  if(dtLichSuTienNo.Rows.Count==0) {
		MessageBox.Show("Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là 0 đ\nBạn có thể xem lại thông tin chi tiết ở phần danh sách khách hàng !");
		return;
	  }
	  if(dtLichSuTienNo.Rows.Count>0) {
		DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChonTrongComboBox);
		FormChucNang.FormXemThongTinTienNo formXemThongTinTienNo=new FormChucNang.FormXemThongTinTienNo(dtLichSuTienNo,intIdKHVuaChonTrongComboBox,strTenKhachHangDangChon,DEC_TIENNO_HIENTAI_CUA_KH);
		formXemThongTinTienNo.voidHIENTHI_TIENNOCU_RA_NUMBERIC=new FormChucNang.FormXemThongTinTienNo.DELEGATE_VOID_UYQUYEN_GIONG_HAMNAY(voidHIENTHI_TIENNOCU_RA_NUMBERIC);
		formXemThongTinTienNo.ShowDialog();
	  }
	}

	private void comboBoxExTenKhachHang_DropDownClosed(object sender,EventArgs e) {
	  try {
		if(comboBoxExTenKhachHang.Text.Equals(QTStringConst.KHONGGHIVAO.STR)) {
		  btnXXemThongTinNo.Enabled=false;
		  return;
		} else {
		  int intIdKHVuaChonTrongComboBox=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
		  DEC_TIENNO_HIENTAI_CUA_KH=BL_KHACHHANG.DEC_TIENNO_HIENTAI_KH(intIdKHVuaChonTrongComboBox);
		  btnXXemThongTinNo.Enabled=true;
		  string strCapNhatChua=BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(INT_MADH_HIENTAI);
		  if(strCapNhatChua.Equals(QTStringConst.CHUACAPNHAT.STR))
			btnXCongTienDonHangKH.Enabled=true;
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXCongTienDonHangKH_Click(object sender,EventArgs e) {
	  string strCapNhatChua=BL_DONHANG.STR_CAPNHAT_TIENNO_DH_CHUA(INT_MADH_HIENTAI);
	  if(strCapNhatChua.Equals("")) {
		MessageBox.Show("Cột 'CapNhatTienNoChua' hiện đang có giá trị khác 'Đã cập nhật' và 'Chưa cập nhật' !");
		return;
	  }
	  string strTenKhachHangDangChon=comboBoxExTenKhachHang.Text;
	  decimal decTienNoCuDangGhi=numericUpDownTienNo.Value;
	  if(strCapNhatChua.Equals(QTStringConst.CHUACAPNHAT.STR)&&!strTenKhachHangDangChon.Equals(QTStringConst.KHONGGHIVAO.STR)&&(DEC_TIENNO_HIENTAI_CUA_KH>-1)) {
		string strNoiDung=(DEC_TIENNO_HIENTAI_CUA_KH<1)?"Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là 0 đ":"Hiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' đang lưu là "+DEC_TIENNO_HIENTAI_CUA_KH.ToString("#,###.#")+" đ";
		strNoiDung+="\nBạn có muốn cộng tiền đơn hàng này ("+DEC_TONGTIEN.ToString("#,###.#")+" đ) vào tổng số tiền nợ của khách hàng này không ?";
		strNoiDung+="\n        "+((DEC_TIENNO_HIENTAI_CUA_KH==0)?"0":DEC_TIENNO_HIENTAI_CUA_KH.ToString("#,###.#"))+" + "+DEC_TONGTIEN.ToString("#,###.#")+" = "+(DEC_TIENNO_HIENTAI_CUA_KH+DEC_TONGTIEN).ToString("#,###.#")+" đ";
		DialogResult dlr=MessageBox.Show(strNoiDung,"Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
		if(dlr==DialogResult.Yes) {
		  string strLoiCapNhatTienNo="";
		  int intIdKhachHangVuaChonComboBox=Convert.ToInt32(comboBoxExTenKhachHang.SelectedValue.ToString());
		  string strLyDoSua="Cộng thêm tiền đơn hàng "+INT_MADH_HIENTAI+" ("+DT_THOIGIAN_VIETDH+")";
		  string strTrangThaiCapNhat=BL_KHACHHANG.STR_CAPNHAT_TIENNO_KH(ref strLoiCapNhatTienNo,
			INT_MADH_HIENTAI,DEC_TIENNO_HIENTAI_CUA_KH,intIdKhachHangVuaChonComboBox,strLyDoSua,DEC_TONGTIEN);
		  if(strTrangThaiCapNhat.Equals("false")&&!(strLoiCapNhatTienNo.Equals("3"))) {
			MessageBox.Show("Trạng thái cập nhật tiền nợ bị lỗi ("+strLoiCapNhatTienNo+")");
		  } else {
			MessageBox.Show("LƯU THÀNH CÔNG!\nHiện tại tiền nợ của khách hàng '"+strTenKhachHangDangChon+"' là "+(DEC_TIENNO_HIENTAI_CUA_KH+DEC_TONGTIEN).ToString("#,###.#")+" đ");
			btnXCongTienDonHangKH.Enabled=false;
		  }
		}
	  } else {
		MessageBox.Show("Đơn hàng này đã được cộng tiền, bạn vui lòng kiểm tra lại !");
		btnXCongTienDonHangKH.Enabled=false;
	  }
	}

	private void btnXChooseCustomer_Click(object sender,EventArgs e) {
	  FormDialogPhu.frmChonTenHoacThemMoi frm = new FormDialogPhu.frmChonTenHoacThemMoi(QTStringConst.TENKHACHHANG.STR,500,700);
	  frm.ShowDialog();
	  txtXNameCustomer.Text=QTAppTemp.STATIC_STR_NAME_CHOOSE;
	  numericUpDownTienNo.Value=QTAppTemp.STATIC_DEC_DEBT_CHOOSE;
	}
  }
}
