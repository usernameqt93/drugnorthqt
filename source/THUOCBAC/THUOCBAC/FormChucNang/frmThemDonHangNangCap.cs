using BusinessLogic;
using FValueObject.Models;
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
  public partial class frmThemDonHangNangCap:Form {

	#region " Defines "

	private BL_DonHang BL_DONHANG = new BL_DonHang();
	private decimal DEC_GIA_VITHUOC = 0;
	private DataTable DT_VITHUOC;
	private decimal DEC_THANHTIEN = 0;
	private int INT_MA_DONHANG_HIENTAI = -1;
	private int INT_MA_CHITIET_DONHANG_DANGCHON = -1;
	private int INT_IDKH_HIENTAI = 1;
	private string STR_TEN_VITHUOC_DANGCHON = "";
	private string STR_CHUCNANG_CUA_FORM = "ThemDonHang";
	private string STR_SDT_KH_HIENTAI = "";
	private string STR_TEN_KH_HIENTAI = "";
	private decimal DEC_TIENNO_CU_HIENTAI = 0;
	private DateTime DT_THOIGIAN_VIETDH = DateTime.Now;

	private int pos_xy_mouse_row = -1;
	private int pos_xy_mouse_col = -1;

	#endregion

	#region " Handle "

	public frmThemDonHangNangCap() {
	  InitializeComponent();
	}

	public frmThemDonHangNangCap(int intMaDonHangHienTai,int intIdKHHienTai,string strSDTKH,decimal decTienNoCu,string strChucNangCuaForm,DateTime dtThoiGianVietDH,string _strNameCustomer) {
	  InitializeComponent();
	  INT_MA_DONHANG_HIENTAI=intMaDonHangHienTai;
	  STR_CHUCNANG_CUA_FORM=strChucNangCuaForm;
	  INT_IDKH_HIENTAI=intIdKHHienTai;
	  STR_SDT_KH_HIENTAI=strSDTKH;
	  DEC_TIENNO_CU_HIENTAI=decTienNoCu;
	  DT_THOIGIAN_VIETDH=dtThoiGianVietDH;
	  STR_TEN_KH_HIENTAI=_strNameCustomer;
	}

	#endregion

	#region " Methods "

	#region " Form Events "

	private void frmThemDonHangNangCap_Load(object sender,EventArgs e) {
	  string strErr = "";
	  string strResult = "";
	  DateTime dateBayGio = DateTime.Now;
	  if(INT_MA_DONHANG_HIENTAI==-1)
		INT_MA_DONHANG_HIENTAI=BL_DONHANG.intMaDonHangVuaThemCoThoiGianVietDH(ref strErr,ref strResult,dateBayGio);

	  if(INT_IDKH_HIENTAI==-2&&DEC_TIENNO_CU_HIENTAI==-2) {
		groupBoxThemViThuoc.Visible=false;
		btnXXoaViThuoc.Visible=false;
		btnXXemReportCTHD.Visible=false;
	  }

	  if(QTAppSetting.STATIC_STR_VISIBLE_NUT_DELETE_VITHUOC.Equals(QTDbConst.ANNUT_XOA_VITHUOC.STR)) {
		btnXXoaViThuoc.Visible=false;
	  }

	  voidCAPNHAT_COMBOBOX_TENVITHUOC();

	  if(DT_VITHUOC.Rows.Count>0) {
		DEC_GIA_VITHUOC=Convert.ToDecimal(DT_VITHUOC.Rows[0][QTDbConst.GIA_VITHUOC.STR]);
		string strDonViTinh = Convert.ToString(DT_VITHUOC.Rows[0][QTDbConst.DONVI_GIATHUOC.STR]);
		string strDonGiaHienTai = ""+DEC_GIA_VITHUOC.ToString("#,###.#")+"đ/1 "+strDonViTinh;
	  }

	  voidHIENTHI_DGV_CO_STT();
	  QTLibraryFunction.STATIC_VOID_HIDE_LIST_COLUMN(ref dataGridViewXChiTietDonHang,new List<string>() { QTDbConst.ID_BANG_CHITIET_DONHANG.STR,QTDbConst.ID_BANG_VITHUOC.STR });

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTStringConst.SO_THUTU.STR,60,DataGridViewContentAlignment.MiddleCenter);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTDbConst.SOLUONG_VITHUOC.STR,QTStringConst.SOLUONG.STR,77,DataGridViewContentAlignment.MiddleRight);
	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTDbConst.DONVI_GIATHUOC.STR,QTStringConst.DONVI.STR,44,DataGridViewContentAlignment.MiddleLeft);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTDbConst.GIA_VITHUOC.STR,QTStringConst.DONGIA.STR,88,DataGridViewContentAlignment.MiddleRight);
	  dataGridViewXChiTietDonHang.Columns[QTDbConst.GIA_VITHUOC.STR].DefaultCellStyle.Format="#,###.### đ";

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTDbConst.TEN_VITHUOC.STR,QTStringConst.TENVITHUOC.STR,176,DataGridViewContentAlignment.MiddleLeft);

	  QTLibraryFunction.STATIC_VOID_SET_WIDTH_ALIGN_COLUMN(ref dataGridViewXChiTietDonHang,QTDbConst.THANHTIEN_TAMTHOI.STR,QTStringConst.THANHTIEN.STR,88,DataGridViewContentAlignment.MiddleLeft,DataGridViewAutoSizeColumnMode.Fill);
	  dataGridViewXChiTietDonHang.Columns[QTDbConst.THANHTIEN_TAMTHOI.STR].DefaultCellStyle.Format="#,###.### đ";

	  labelXDonViTinh.Text="("+"Kg"+")";

	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
	  voidTRODEN_VITRI_CHIDINH(DEC_TIENNO_CU_HIENTAI,STR_SDT_KH_HIENTAI);
	  if(dataGridViewXChiTietDonHang.RowCount<1)
		btnXXemReportCTHD.Enabled=false;
	}

	private void frmThemDonHangNangCap_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.F5) {
		comboBoxExDanhSachCacViThuoc.Focus();
		comboBoxExDanhSachCacViThuoc.SelectAll();
		numericSoLuongVT.Select(0,22);
		numericDonGiaVT.Select(0,22);
		return;
	  }
	  if(e.KeyCode==Keys.F6) {
		numericSoLuongVT.Focus();
		numericSoLuongVT.Select(0,22);
		return;
	  }
	  if(e.KeyCode==Keys.F7) {
		numericDonGiaVT.Focus();
		numericDonGiaVT.Select(0,22);
		return;
	  }
	}

	#endregion

	#region " Control Events "

	private void btnXXemReportCTHD_Click(object sender,EventArgs e) {

	  DataTable dtChiTietDonHang = BL_DONHANG.dataTableBangChiTietDonHangTheoMaDonHang(INT_MA_DONHANG_HIENTAI);
	  if(dtChiTietDonHang.Rows.Count<1) {
		MessageBox.Show("Hiện tại đơn hàng chưa có vị thuốc nào, chưa xem được");
		return;
	  }

	  string strLoi = "";
	  string strResult = "";
	  decimal decTongTienDonHang = BL_DONHANG.decTongTienDonHangTheoMaDonHang(ref strLoi,ref strResult,INT_MA_DONHANG_HIENTAI);

	  if(QTAppSetting.STATIC_STR_CACHXEM_BANIN.Equals(QTDbConst.XEM_BANIN_CACH_2.STR)) {
		DetailOrderModel mDetailOrder = new DetailOrderModel();
		mDetailOrder.dtDetailOrder=dtChiTietDonHang;
		mDetailOrder.decTongTien=decTongTienDonHang;
		mDetailOrder.intIdOrderCurrent=INT_MA_DONHANG_HIENTAI;
		mDetailOrder.intIdCustomerCurrent=INT_IDKH_HIENTAI;
		mDetailOrder.strPhoneSaveWithOrder=STR_SDT_KH_HIENTAI;
		mDetailOrder.decDebtSaveWithOrder=DEC_TIENNO_CU_HIENTAI;
		mDetailOrder.dtTimeCreate=DT_THOIGIAN_VIETDH;
		mDetailOrder.strNameCustomerCurrent=STR_TEN_KH_HIENTAI;

		//frmAddInfoCustomerToOrder frm = new frmAddInfoCustomerToOrder(dtChiTietDonHang,decTongTienDonHang,INT_MA_DONHANG_HIENTAI,DT_THOIGIAN_VIETDH);
		frmAddInfoCustomerToOrder frm = new frmAddInfoCustomerToOrder(mDetailOrder);
		frm.ShowDialog();
		btnXXemReportCTHD.Enabled=false;
		return;
	  }

	  FormReport.FormReportChiTietDonHang frmReport = new FormReport.FormReportChiTietDonHang(
		dtChiTietDonHang,decTongTienDonHang,INT_MA_DONHANG_HIENTAI,INT_IDKH_HIENTAI,STR_SDT_KH_HIENTAI,DEC_TIENNO_CU_HIENTAI,DT_THOIGIAN_VIETDH);
	  frmReport.ShowDialog();
	  btnXXemReportCTHD.Enabled=false;

	}

	private void dataGridViewXChiTietDonHang_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXoaViThuoc.Enabled=true;
		  DataGridViewRow r = dataGridViewXChiTietDonHang.Rows[e.RowIndex];
		  INT_MA_CHITIET_DONHANG_DANGCHON=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_CHITIET_DONHANG.STR].Value);
		  STR_TEN_VITHUOC_DANGCHON=Convert.ToString(r.Cells[QTDbConst.TEN_VITHUOC.STR].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	}

	private void btnXXoaViThuoc_Click(object sender,EventArgs e) {
	  VOID_DELETE_PRODUCT_SELECTED();
	}

	private void btnXThemViThuocVaoDH_Click(object sender,EventArgs e) {
	  groupBoxThemViThuoc.Enabled=false;
	  try {
		if(numericSoLuongVT.Value<=0)
		  MessageBox.Show("Số lượng vị thuốc này phải lớn hơn 0");
		else if(numericDonGiaVT.Value<1000)
		  MessageBox.Show("Đơn giá vị thuốc phải lớn hơn 1000");
		else if(comboBoxExDanhSachCacViThuoc.Text.Trim().Equals(""))
		  MessageBox.Show("Bạn hãy điền lại tên vị thuốc cho đúng!");
		else {
		  string strLoi = "";
		  string strResult = "";
		  string strTenViThuocOComBoBox = Convert.ToString(comboBoxExDanhSachCacViThuoc.Text).Trim();
		  string strTenViThuocNayDaVietHoaChuCaiDau = ""+strTenViThuocOComBoBox.ElementAt(0).ToString().ToUpper()+strTenViThuocOComBoBox.Substring(1);
		  int intMaChiTietDHCuaTenViThuocThem = BL_DONHANG.intMaChiTietDHCuaTenViThuoc(
			ref strLoi,ref strResult,strTenViThuocNayDaVietHoaChuCaiDau,INT_MA_DONHANG_HIENTAI);
		  decimal decSoLuongViThuoc = Convert.ToDecimal(numericSoLuongVT.Value);
		  decimal decDonGia = Convert.ToDecimal(numericDonGiaVT.Value);
		  if(intMaChiTietDHCuaTenViThuocThem>0) {
			if(QTAppSetting.STATIC_STR_EDIT_WHILE_CO_TEN_TRONG_DONHANG.Equals(QTDbConst.KHONG_SUA_KHI_CO_TEN_TRONG_DONHANG.STR)) {

			  #region nếu có tên vị thuốc này trong đơn hàng rồi thì thông báo người dùng là hãy sửa nó
			  QTMessageConst.NAME_IS_EXIST_SHOULD_EDIT(strTenViThuocNayDaVietHoaChuCaiDau);
			  #endregion

			} else {

			  #region nếu có tên vị thuốc này trong đơn hàng rồi thì chỉ sửa lại giá, số lượng của nó thôi
			  string strTrangThaiCapNhatGiaViThuocVaoDH = BL_DONHANG.strCapNhatGiaCaViThuocVaoDH(ref strLoi,intMaChiTietDHCuaTenViThuocThem,decDonGia,decSoLuongViThuoc);
			  if(strTrangThaiCapNhatGiaViThuocVaoDH.Equals("false")&&!strLoi.Equals("2"))
				MessageBox.Show("Trạng thái cập nhật thông tin vị thuốc vào đơn hàng lỗi ("+strLoi+")");
			  else {
				voidHIENTHI_DGV_CO_STT();
				voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
				voidTRODEN_VITRI_CUOI_DGV();
				MessageBox.Show("Vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau
				  +"' đã được thêm vào đơn hàng lúc trước, giờ đã được sửa thành đơn giá '"+decDonGia+"' vnđ , số lượng '"+decSoLuongViThuoc+" Kg'");
				voidCAPNHAT_TRANGTHAI_HOATDONG("Bạn vừa thêm thông tin vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau
				  +"'   đơn giá '"+decDonGia+"' vnđ , số lượng '"+decSoLuongViThuoc+" Kg' , thành tiền '"+(decDonGia*decSoLuongViThuoc)+"' vào đơn hàng");
				btnXThemViThuocVaoDH.Enabled=false;
				btnXXemReportCTHD.Enabled=true;
			  }
			  #endregion
			}
		  } else {
			#region nếu chưa có thì làm như dưới
			int intMaViThuocCuaTenVTVuaDien = BL_DONHANG.intMaViThuocCuaTenViThuocNay(ref strLoi,ref strResult,strTenViThuocNayDaVietHoaChuCaiDau);
			if(intMaViThuocCuaTenVTVuaDien==-1) {
			  #region nếu tên vị thuốc chưa có trong danh sách thì tự động thêm vào danh sách rồi lại thêm vào đơn hàng
			  string strTrangThaiInsertBang = BL_DONHANG.strThemThongTinViThuocVaoDB(ref strLoi,strTenViThuocNayDaVietHoaChuCaiDau,decDonGia,decSoLuongViThuoc,INT_MA_DONHANG_HIENTAI);
			  if(strTrangThaiInsertBang.Equals("false")&&!strLoi.Equals("3"))
				MessageBox.Show("Trạng thái thêm vào đơn hàng lỗi ("+strLoi+")");
			  else {
				voidHIENTHI_DGV_CO_STT();
				voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
				voidCAPNHAT_COMBOBOX_TENVITHUOC();
				voidTRODEN_VITRI_CUOI_DGV();
				MessageBox.Show("Vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau+"' này chưa từng có trong danh sách vị thuốc.\nHệ thống đã tự động thêm tên vị thuốc này vào danh sách vị thuốc.\nTHÊM VÀO ĐƠN HÀNG THÀNH CÔNG!");
				voidCAPNHAT_TRANGTHAI_HOATDONG("Bạn vừa thêm thông tin vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau
				+"'   đơn giá '"+decDonGia+"' vnđ , số lượng '"+decSoLuongViThuoc+" Kg' , thành tiền '"+(decDonGia*decSoLuongViThuoc)+"' vào đơn hàng");
				btnXThemViThuocVaoDH.Enabled=false;
				btnXXemReportCTHD.Enabled=true;
			  }
			  #endregion

			} else if(intMaViThuocCuaTenVTVuaDien>0) {
			  #region nếu tên vị thuốc có trong danh sách rồi thì ko thêm vào danh sách nữa và vẫn thêm vào đơn hàng
			  string strTrangThaiThemVTDaCoVaoDH = BL_DONHANG.strThemViThuocDaCoVaoDonHang(ref strLoi,intMaViThuocCuaTenVTVuaDien,decDonGia,decSoLuongViThuoc,INT_MA_DONHANG_HIENTAI);
			  if(strTrangThaiThemVTDaCoVaoDH.Equals("false")&&!strLoi.Equals("2"))
				MessageBox.Show("Trạng thái thêm tên vị thuốc đã có trong danh sách vào đơn hàng lỗi ("+strLoi+")");
			  else {
				voidHIENTHI_DGV_CO_STT();
				voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
				voidCAPNHAT_COMBOBOX_TENVITHUOC();
				voidTRODEN_VITRI_CUOI_DGV();
				MessageBox.Show("Vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau+"' là vị thuốc đã có trong danh sách vị thuốc của phần mềm.\nTHÊM VÀO ĐƠN HÀNG THÀNH CÔNG !");
				voidCAPNHAT_TRANGTHAI_HOATDONG("Bạn vừa thêm thông tin vị thuốc '"+strTenViThuocNayDaVietHoaChuCaiDau
				+"'   đơn giá '"+decDonGia+"' vnđ , số lượng '"+decSoLuongViThuoc+" Kg' , thành tiền '"+(decDonGia*decSoLuongViThuoc)+"' vào đơn hàng");
				btnXThemViThuocVaoDH.Enabled=false;
				btnXXemReportCTHD.Enabled=true;
			  }
			  #endregion

			}
			#endregion

		  }
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Ex.Message: "+ex.Message,QTStringConst.THONGBAO.STR);
	  }
	  groupBoxThemViThuoc.Enabled=true;
	  comboBoxExDanhSachCacViThuoc.Focus();
	  comboBoxExDanhSachCacViThuoc.SelectAll();
	  numericSoLuongVT.Select(0,22);
	  numericDonGiaVT.Select(0,22);

	}

	private void groupBoxThanhTien_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  btnXThemViThuocVaoDH.Enabled=true;
	}

	private void numericDonGiaVT_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.N) {
		numericDonGiaVT.Value*=1000;
		voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
		numericDonGiaVT.Focus();
		numericDonGiaVT.Select(0,22);
	  }
	  if(e.KeyCode==Keys.Enter) {
		if(numericDonGiaVT.Value<4001) {
		  MessageBox.Show("Đơn giá vị thuốc bạn nhập hiện tại đang là '"+numericDonGiaVT.Value+"' vnđ , hơi thấp so với bình thường, bạn nên kiểm tra lại !");
		  numericDonGiaVT.Focus();
		  numericDonGiaVT.Select(0,22);
		} else {
		  btnXThemViThuocVaoDH.PerformClick();
		}
	  }
	}

	private void comboBoxExDanhSachCacViThuoc_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.Enter) {
		numericSoLuongVT.Focus();
		numericSoLuongVT.Select(0,22);
	  }
	}

	private void numericSoLuongVT_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.Enter) {
		numericDonGiaVT.Focus();
		numericDonGiaVT.Select(0,22);
		string strThanhTien = ""+"= 0 đ";
		labelXTinhThanhTien.Text=strThanhTien;
	  }
	}

	private void dataGridViewXChiTietDonHang_MouseClick(object sender,MouseEventArgs e) {
	  if(e.Button==MouseButtons.Right) {
		pos_xy_mouse_row=dataGridViewXChiTietDonHang.HitTest(e.X,e.Y).RowIndex;
		pos_xy_mouse_col=dataGridViewXChiTietDonHang.HitTest(e.X,e.Y).ColumnIndex;

		if(pos_xy_mouse_row>=0&&pos_xy_mouse_col>=0) {
		  dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[pos_xy_mouse_row].Cells[pos_xy_mouse_col];
		  DataGridViewRow r = dataGridViewXChiTietDonHang.Rows[pos_xy_mouse_row];
		  INT_MA_CHITIET_DONHANG_DANGCHON=Convert.ToInt32(r.Cells[QTDbConst.ID_BANG_CHITIET_DONHANG.STR].Value);
		  STR_TEN_VITHUOC_DANGCHON=Convert.ToString(r.Cells[QTDbConst.TEN_VITHUOC.STR].Value);

		  ContextMenuStrip mnu = new ContextMenuStrip();
		  ToolStripMenuItem mnuEdit = new ToolStripMenuItem("Sửa giá và số lượng vị thuốc này");
		  ToolStripMenuItem mnuBlank1 = new ToolStripMenuItem("   ");
		  ToolStripMenuItem mnuBlank2 = new ToolStripMenuItem("   ");
		  ToolStripMenuItem mnuDelete = new ToolStripMenuItem("Xóa '"+STR_TEN_VITHUOC_DANGCHON+"' ra khỏi đơn");
		  mnuDelete.Image=Properties.Resources.Xoa;
		  mnuEdit.Image=Properties.Resources.update;

		  mnuEdit.Click+=new EventHandler(mnuEdit_Click);
		  mnuDelete.Click+=new EventHandler(mnuDelete_Click);

		  mnu.Items.AddRange(new ToolStripItem[] { mnuBlank1,mnuEdit,mnuBlank2,mnuDelete });

		  mnu.Show(dataGridViewXChiTietDonHang,new Point(e.X,e.Y));
		}

	  }
	}

	private void mnuDelete_Click(object sender,EventArgs e) {
	  VOID_DELETE_PRODUCT_SELECTED();
	}

	private void mnuEdit_Click(object sender,EventArgs e) {
	  DataGridViewRow row = dataGridViewXChiTietDonHang.Rows[pos_xy_mouse_row];
	  INT_MA_CHITIET_DONHANG_DANGCHON=Convert.ToInt32(row.Cells[QTDbConst.ID_BANG_CHITIET_DONHANG.STR].Value);
	  STR_TEN_VITHUOC_DANGCHON=Convert.ToString(row.Cells[QTDbConst.TEN_VITHUOC.STR].Value);

	  decimal decSoLuong = Convert.ToDecimal(row.Cells[QTDbConst.SOLUONG_VITHUOC.STR].Value);
	  decimal decDonGia = Convert.ToDecimal(row.Cells[QTDbConst.GIA_VITHUOC.STR].Value);
	  frmSuaGiaVaSoLuong frm = new frmSuaGiaVaSoLuong(INT_MA_CHITIET_DONHANG_DANGCHON,STR_TEN_VITHUOC_DANGCHON,decSoLuong,decDonGia);
	  frm.ShowDialog();

	  voidHIENTHI_DGV_CO_STT();
	  voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();

	  dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[pos_xy_mouse_row].Cells[QTDbConst.GIA_VITHUOC.STR];// Đưa Control về vị trí của nó
	  dataGridViewXChiTietDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
	}

	private void comboBoxExDanhSachCacViThuoc_TextUpdate(object sender,EventArgs e) {
	  btnXThemViThuocVaoDH.Enabled=true;
	}

	#endregion

	#region " Other "  

	private void VOID_DELETE_PRODUCT_SELECTED() {
	  string strLoi = "";
	  DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa vị thuốc '"+STR_TEN_VITHUOC_DANGCHON+"' ra khỏi đơn hàng ở dưới?",
		QTStringConst.THONGBAO.STR,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
	  if(dlr==DialogResult.Yes) {
		bool boolCoXoaDuocKo = BL_DONHANG.boolDeleteBangChiTietDonHangTheoMaCTDH(ref strLoi,INT_MA_CHITIET_DONHANG_DANGCHON);
		if(boolCoXoaDuocKo) {
		  voidHIENTHI_DGV_CO_STT();
		  voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
		  MessageBox.Show("Xóa vị thuốc '"+STR_TEN_VITHUOC_DANGCHON+"' ra khỏi đơn hàng thành công!");
		  btnXXoaViThuoc.Enabled=false;
		} else {
		  MessageBox.Show("Xóa thất bại, có lỗi ("+strLoi+")");
		}
	  }
	}

	private void voidCAPNHAT_COMBOBOX_TENVITHUOC() {
	  DT_VITHUOC=BL_DONHANG.dataTableBangDanhSachViThuocXepTheoTenThuoc();
	  if(DT_VITHUOC.Rows.Count>0) {
		comboBoxExDanhSachCacViThuoc.DataSource=DT_VITHUOC;
		comboBoxExDanhSachCacViThuoc.DisplayMember=QTDbConst.TEN_VITHUOC.STR;
		comboBoxExDanhSachCacViThuoc.ValueMember=QTDbConst.ID_BANG_VITHUOC.STR;
	  }
	}
	private void voidHIENTHI_DGV_CO_STT() {
	  dataGridViewXChiTietDonHang.DataSource=BL_DONHANG.dataTableBangChiTietDonHangTheoMaDonHangCoSTT(INT_MA_DONHANG_HIENTAI);
	  dataGridViewXChiTietDonHang.Columns[QTStringConst.SO_THUTU.STR].DisplayIndex=0;
	  QTLibraryFunction.STATIC_VOID_NOT_SORT_DGV(ref dataGridViewXChiTietDonHang);
	}
	public void voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG() {
	  string strLoi = "";
	  decimal decTongTienDonHang = 0;
	  int intTongViThuoc = 0;
	  decimal decTongKhoiLuong = 0;
	  BL_DONHANG.voidLayThongTinCaDonHang(ref intTongViThuoc,ref decTongKhoiLuong,ref decTongTienDonHang,INT_MA_DONHANG_HIENTAI);
	  bool boolUpdateTongGiaTriDHVaoBangDonHang = BL_DONHANG.boolUpdateTongGiaTriDonHangTheoMaDH(
		ref strLoi,intTongViThuoc,decTongKhoiLuong,decTongTienDonHang,INT_MA_DONHANG_HIENTAI);
	  labelXTongTienDonHang.Text=(decTongTienDonHang==0) ? "0 đ" : ""+decTongTienDonHang.ToString("#,###.#")+" đ";
	  groupBoxTongGiaDonHang.Text=(decTongKhoiLuong==0) ? "Tổng giá đơn hàng hiện tại (0 Kg)" : "Tổng giá đơn hàng hiện tại ("+decTongKhoiLuong.ToString("#,###.##")+" Kg)";
	}

	public void voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG() {
	  DEC_THANHTIEN=numericSoLuongVT.Value*numericDonGiaVT.Value;
	  string strThanhTien = ""+"= "+DEC_THANHTIEN.ToString("#,###.#")+" đ";
	  labelXTinhThanhTien.Text=strThanhTien;
	}

	private void voidCAPNHAT_TRANGTHAI_HOATDONG(string strTrangThai) {
	  DateTime dtBayGio = DateTime.Now;
	  labelXTrangThaiTruocDo.Text=""+labelXTrangThaiGanNhat.Text;
	  labelXTrangThaiGanNhat.Text=""+dtBayGio.ToString("HH:mm:ss")+" - "+strTrangThai;
	}

	private void voidTRODEN_VITRI_CUOI_DGV() {
	  int intSoThuTuHangMuonTroVao = 0;
	  if(dataGridViewXChiTietDonHang.RowCount>1) {
		dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[intSoThuTuHangMuonTroVao].Cells[QTDbConst.GIA_VITHUOC.STR];// Đưa Control về vị trí của nó
		dataGridViewXChiTietDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	}
	private void voidTRODEN_VITRI_CHIDINH(decimal decTienNo,string strSoDTKH) {
	  int intSoThuTuHangMuonTroVao = 0;
	  if(dataGridViewXChiTietDonHang.RowCount>1) {
		if(decTienNo==-2&&strSoDTKH.Substring(0,2).Equals("zz")) {
		  string strTenViThuocCanSoSanh = strSoDTKH.Substring(2);
		  for(int i = 0;i<dataGridViewXChiTietDonHang.RowCount;i++) {
			if(dataGridViewXChiTietDonHang.Rows[i].Cells[QTDbConst.TEN_VITHUOC.STR].Value.ToString().Equals(strTenViThuocCanSoSanh)) {
			  intSoThuTuHangMuonTroVao=i;
			  break;
			}
		  }
		} else
		  intSoThuTuHangMuonTroVao=dataGridViewXChiTietDonHang.RowCount-1;
		dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[intSoThuTuHangMuonTroVao].Cells[QTDbConst.GIA_VITHUOC.STR];// Đưa Control về vị trí của nó
		dataGridViewXChiTietDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	}

	#endregion

	#endregion

  }
}
