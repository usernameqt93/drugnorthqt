﻿using System;
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
  public partial class FormThemDonHang:Form {
	private BL_DonHang BL_DONHANG=new BL_DonHang();
	private decimal DEC_GIA_VITHUOC=0;
	private DataTable DT_VITHUOC;
	private decimal DEC_THANHTIEN=0;
	//private int INT_MA_VITHUOC_DANGCHON=-1;
	private int INT_MA_DONHANG_HIENTAI=-1;
	private int INT_MA_CHITIET_DONHANG_DANGCHON=-1;
	private int INT_IDKH_HIENTAI=1;
	private string STR_TEN_VITHUOC_DANGCHON="";
	private string STR_CHUCNANG_CUA_FORM="ThemDonHang";
	private string STR_SDT_KH_HIENTAI="";
	private decimal DEC_TIENNO_CU_HIENTAI=0;
	private DateTime DT_THOIGIAN_VIETDH=DateTime.Now;
	public FormThemDonHang() {
	  InitializeComponent();
	}
	public FormThemDonHang(int intMaDonHangHienTai,int intIdKHHienTai,string strSDTKH,decimal decTienNoCu,string strChucNangCuaForm,DateTime dtThoiGianVietDH) {
	  InitializeComponent();
	  INT_MA_DONHANG_HIENTAI=intMaDonHangHienTai;
	  STR_CHUCNANG_CUA_FORM=strChucNangCuaForm;
	  INT_IDKH_HIENTAI=intIdKHHienTai;
	  STR_SDT_KH_HIENTAI=strSDTKH;
	  DEC_TIENNO_CU_HIENTAI=decTienNoCu;
	  DT_THOIGIAN_VIETDH=dtThoiGianVietDH;
	}
	private void FormThemDonHang_Load(object sender,EventArgs e) {
	  string strErr="";
	  string strResult="";
	  DateTime dateBayGio=DateTime.Now;
	  if(INT_MA_DONHANG_HIENTAI==-1)
		INT_MA_DONHANG_HIENTAI=BL_DONHANG.intMaDonHangVuaThemCoThoiGianVietDH(ref strErr,ref strResult,dateBayGio);

	  if(INT_IDKH_HIENTAI==-2&&DEC_TIENNO_CU_HIENTAI==-2) {
		groupBoxThemViThuoc.Visible=false;
		btnXXoaViThuoc.Visible=false;
		//groupBoxTongGiaDonHang.Visible=false;
		btnXXemReportCTHD.Visible=false;
	  }

	  voidCAPNHAT_COMBOBOX_TENVITHUOC();

	  if(DT_VITHUOC.Rows.Count>0) {
		DEC_GIA_VITHUOC=Convert.ToDecimal(DT_VITHUOC.Rows[0]["GiaViThuoc"]);
		string strDonViTinh=Convert.ToString(DT_VITHUOC.Rows[0]["DonViGiaThuoc"]);
		string strDonGiaHienTai=""+DEC_GIA_VITHUOC.ToString("#,###.#")+"đ/1 "+strDonViTinh;
	  }

	  voidHIENTHI_DGV_CO_STT();
	  dataGridViewXChiTietDonHang.Columns["MaChiTietDonHang"].Visible=false;
	  dataGridViewXChiTietDonHang.Columns["MaViThuoc"].Visible=false;

	  dataGridViewXChiTietDonHang.Columns["SoLuongViThuoc"].HeaderText="Số lượng";
	  dataGridViewXChiTietDonHang.Columns["SoLuongViThuoc"].Width=77;
	  dataGridViewXChiTietDonHang.Columns["DonViGiaThuoc"].HeaderText="Đơn vị";
	  dataGridViewXChiTietDonHang.Columns["DonViGiaThuoc"].Width=44;
	  dataGridViewXChiTietDonHang.Columns["GiaViThuoc"].HeaderText="Đơn giá";
	  dataGridViewXChiTietDonHang.Columns["GiaViThuoc"].Width=88;
	  dataGridViewXChiTietDonHang.Columns["TenViThuoc"].HeaderText="Tên vị thuốc";
	  dataGridViewXChiTietDonHang.Columns["GiaViThuoc"].DefaultCellStyle.Format="#,###.### đ";
	  dataGridViewXChiTietDonHang.Columns["ThanhTienTamThoi"].HeaderText="Thành tiền";
	  //dataGridViewXChiTietDonHang.Columns["ThanhTienTamThoi"].Width=88;
	  dataGridViewXChiTietDonHang.Columns["ThanhTienTamThoi"].DefaultCellStyle.Format="#,###.### đ";

	  //labelXDonViTinh.Text="("+strDonViTinh+")";
	  labelXDonViTinh.Text="("+"Kg"+")";

	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG();
	  //voidTRODEN_VITRI_CUOI_DGV();
	  voidTRODEN_VITRI_CHIDINH(DEC_TIENNO_CU_HIENTAI,STR_SDT_KH_HIENTAI);
	  if(dataGridViewXChiTietDonHang.RowCount<1)
		btnXXemReportCTHD.Enabled=false;

	  //comboBoxExDanhSachCacViThuoc.Focus();
	  //comboBoxExDanhSachCacViThuoc.SelectAll();
	}
	private void voidCAPNHAT_COMBOBOX_TENVITHUOC() {
	  DT_VITHUOC=BL_DONHANG.dataTableBangDanhSachViThuocXepTheoTenThuoc();
	  if(DT_VITHUOC.Rows.Count>0) {
		comboBoxExDanhSachCacViThuoc.DataSource=DT_VITHUOC;
		comboBoxExDanhSachCacViThuoc.DisplayMember="TenViThuoc";
		comboBoxExDanhSachCacViThuoc.ValueMember="MaViThuoc";
	  }
	}
	private void voidHIENTHI_DGV_CO_STT() {
	  dataGridViewXChiTietDonHang.DataSource=BL_DONHANG.dataTableBangChiTietDonHangTheoMaDonHangCoSTT(INT_MA_DONHANG_HIENTAI);
	  dataGridViewXChiTietDonHang.Columns["STT"].DisplayIndex=0;
	}
	public void voidCAPNHAT_TONGTIEN_DH_THEO_MADONHANG() {
	  string strLoi="";
	  //string strResult="";
	  //decimal decTongTienDonHang=BL_DONHANG.decTongTienDonHangTheoMaDonHang(ref strLoi,ref strResult,INT_MA_DONHANG_HIENTAI);
	  decimal decTongTienDonHang=0;
	  int intTongViThuoc=0;
	  decimal decTongKhoiLuong=0;
	  BL_DONHANG.voidLayThongTinCaDonHang(ref intTongViThuoc,ref decTongKhoiLuong,ref decTongTienDonHang,INT_MA_DONHANG_HIENTAI);
	  bool boolUpdateTongGiaTriDHVaoBangDonHang=BL_DONHANG.boolUpdateTongGiaTriDonHangTheoMaDH(
		ref strLoi,intTongViThuoc,decTongKhoiLuong,decTongTienDonHang,INT_MA_DONHANG_HIENTAI);
	  labelXTongTienDonHang.Text=(decTongTienDonHang==0)?"0 đ":""+decTongTienDonHang.ToString("#,###.#")+" đ";
	  groupBoxTongGiaDonHang.Text=(decTongKhoiLuong==0)?"Tổng giá đơn hàng hiện tại (0 Kg)":"Tổng giá đơn hàng hiện tại ("+decTongKhoiLuong.ToString("#,###.##")+" Kg)";
	}
	private void btnXXemReportCTHD_Click(object sender,EventArgs e) {
	  DataTable dtChiTietDonHang=BL_DONHANG.dataTableBangChiTietDonHangTheoMaDonHang(INT_MA_DONHANG_HIENTAI);

	  if(dtChiTietDonHang.Rows.Count<1)
		MessageBox.Show("Hiện tại đơn hàng chưa có vị thuốc nào, chưa xem được");
	  else {
		string strLoi="";
		string strResult="";
		decimal decTongTienDonHang=BL_DONHANG.decTongTienDonHangTheoMaDonHang(ref strLoi,ref strResult,INT_MA_DONHANG_HIENTAI);
		FormReport.FormReportChiTietDonHang f=new FormReport.FormReportChiTietDonHang(
		  dtChiTietDonHang,decTongTienDonHang,INT_MA_DONHANG_HIENTAI,INT_IDKH_HIENTAI,STR_SDT_KH_HIENTAI,DEC_TIENNO_CU_HIENTAI,DT_THOIGIAN_VIETDH);
		f.ShowDialog();
	  }
	}

	public void voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG() {
	  DEC_THANHTIEN=numericSoLuongVT.Value*numericDonGiaVT.Value;
	  string strThanhTien=""+"= "+DEC_THANHTIEN.ToString("#,###.#")+" đ";
	  labelXTinhThanhTien.Text=strThanhTien;
	}

	private void dataGridViewXChiTietDonHang_CellClick(object sender,DataGridViewCellEventArgs e) {
	  try {
		if(e.ColumnIndex>=-1&&e.RowIndex>=0) {
		  btnXXoaViThuoc.Enabled=true;
		  DataGridViewRow r=dataGridViewXChiTietDonHang.Rows[e.RowIndex];
		  INT_MA_CHITIET_DONHANG_DANGCHON=Convert.ToInt32(r.Cells["MaChiTietDonHang"].Value);
		  STR_TEN_VITHUOC_DANGCHON=Convert.ToString(r.Cells["TenViThuoc"].Value);
		}
	  } catch(Exception ex) {
		MessageBox.Show(@"Lỗi: "+ex.Message,@"Thông Báo");
	  }
	}

	private void btnXXoaViThuoc_Click(object sender,EventArgs e) {
	  string strLoi="";
	  DialogResult dlr=MessageBox.Show("Bạn chắc chắn muốn xóa vị thuốc '"+STR_TEN_VITHUOC_DANGCHON+"' ra khỏi đơn hàng ở dưới?",
		"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
	  if(dlr==DialogResult.Yes) {
		bool boolCoXoaDuocKo=BL_DONHANG.boolDeleteBangChiTietDonHangTheoMaCTDH(ref strLoi,INT_MA_CHITIET_DONHANG_DANGCHON);
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
	private void voidCAPNHAT_TRANGTHAI_HOATDONG(string strTrangThai) {
	  DateTime dtBayGio=DateTime.Now;
	  labelXTrangThaiTruocDo.Text=""+labelXTrangThaiGanNhat.Text;
	  labelXTrangThaiGanNhat.Text=""+dtBayGio.ToString("HH:mm:ss")+" - "+strTrangThai;
	}
	private void btnXThemViThuocVaoDH_Click(object sender,EventArgs e) {
	  groupBoxThemViThuoc.Enabled=false;
	  try {
		if(numericSoLuongVT.Value<=0)
		  MessageBox.Show("Số lượng vị thuốc này phải lớn hơn 0");
		else if(numericDonGiaVT.Value<1000)
		  MessageBox.Show("Đơn giá vị thuốc phải lớn hơn 1000");
		else if(comboBoxExDanhSachCacViThuoc.Text.Equals(""))
		  MessageBox.Show("Bạn hãy điền lại tên vị thuốc cho đúng!");
		else {
		  string strLoi="";
		  string strResult="";
		  string strTenViThuocOComBoBox=Convert.ToString(comboBoxExDanhSachCacViThuoc.Text);
		  string strTenViThuocNayDaVietHoaChuCaiDau=""+strTenViThuocOComBoBox.ElementAt(0).ToString().ToUpper()+strTenViThuocOComBoBox.Substring(1);
		  int intMaChiTietDHCuaTenViThuocThem=BL_DONHANG.intMaChiTietDHCuaTenViThuoc(
			ref strLoi,ref strResult,strTenViThuocNayDaVietHoaChuCaiDau,INT_MA_DONHANG_HIENTAI);
		  decimal decSoLuongViThuoc=Convert.ToDecimal(numericSoLuongVT.Value);
		  decimal decDonGia=Convert.ToDecimal(numericDonGiaVT.Value);
		  if(intMaChiTietDHCuaTenViThuocThem>0) {
			#region nếu có tên vị thuốc này trong đơn hàng rồi thì chỉ sửa lại giá, số lượng của nó thôi
			string strTrangThaiCapNhatGiaViThuocVaoDH=BL_DONHANG.strCapNhatGiaCaViThuocVaoDH(ref strLoi,intMaChiTietDHCuaTenViThuocThem,decDonGia,decSoLuongViThuoc);
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

		  } else {
			#region nếu chưa có thì làm như dưới
			int intMaViThuocCuaTenVTVuaDien=BL_DONHANG.intMaViThuocCuaTenViThuocNay(ref strLoi,ref strResult,strTenViThuocNayDaVietHoaChuCaiDau);
			if(intMaViThuocCuaTenVTVuaDien==-1) {
			  #region nếu tên vị thuốc chưa có trong danh sách thì tự động thêm vào danh sách rồi lại thêm vào đơn hàng
			  string strTrangThaiInsertBang=BL_DONHANG.strThemThongTinViThuocVaoDB(ref strLoi,strTenViThuocNayDaVietHoaChuCaiDau,decDonGia,decSoLuongViThuoc,INT_MA_DONHANG_HIENTAI);
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
			  string strTrangThaiThemVTDaCoVaoDH=BL_DONHANG.strThemViThuocDaCoVaoDonHang(ref strLoi,intMaViThuocCuaTenVTVuaDien,decDonGia,decSoLuongViThuoc,INT_MA_DONHANG_HIENTAI);
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
		MessageBox.Show(@"Ex.Message: "+ex.Message,@"Thông Báo");
	  }
	  groupBoxThemViThuoc.Enabled=true;
	  comboBoxExDanhSachCacViThuoc.Focus();
	  comboBoxExDanhSachCacViThuoc.SelectAll();
	  numericSoLuongVT.Select(0,22);
	  numericDonGiaVT.Select(0,22);

	}
	private void voidTRODEN_VITRI_CUOI_DGV() {
	  int intSoThuTuHangMuonTroVao=0;
	  if(dataGridViewXChiTietDonHang.RowCount>1) {
		//intSoThuTuHangMuonTroVao=dataGridViewXChiTietDonHang.RowCount-1;
		dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[intSoThuTuHangMuonTroVao].Cells["GiaViThuoc"];// Đưa Control về vị trí của nó
		dataGridViewXChiTietDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	}
	private void voidTRODEN_VITRI_CHIDINH(decimal decTienNo,string strSoDTKH) {
	  int intSoThuTuHangMuonTroVao=0;
	  if(dataGridViewXChiTietDonHang.RowCount>1) {
		if(decTienNo==-2&&strSoDTKH.Substring(0,2).Equals("zz")) {
		  string strTenViThuocCanSoSanh=strSoDTKH.Substring(2);
		  for(int i=0;i<dataGridViewXChiTietDonHang.RowCount;i++) {
			if(dataGridViewXChiTietDonHang.Rows[i].Cells["TenViThuoc"].Value.ToString().Equals(strTenViThuocCanSoSanh)) {
			  intSoThuTuHangMuonTroVao=i;
			  break;
			}
		  }
		} else
		  intSoThuTuHangMuonTroVao=dataGridViewXChiTietDonHang.RowCount-1;
		dataGridViewXChiTietDonHang.CurrentCell=dataGridViewXChiTietDonHang.Rows[intSoThuTuHangMuonTroVao].Cells["GiaViThuoc"];// Đưa Control về vị trí của nó
		dataGridViewXChiTietDonHang.CurrentRow.Selected=true;// Set trạng thái Selected
	  }
	}

	private void btnXThemViThuocVaoDH_MouseHover(object sender,EventArgs e) {
	  //numericSoLuongVT.Select(0,22);
	  //numericDonGiaVT.Select(0,22);
	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	}

	private void labelXTinhThanhTien_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  btnXThemViThuocVaoDH.Enabled=true;
	}

	private void comboBoxExDanhSachCacViThuoc_TextUpdate(object sender,EventArgs e) {
	  btnXThemViThuocVaoDH.Enabled=true;
	}

	private void comboBoxExDanhSachCacViThuoc_DropDownClosed(object sender,EventArgs e) {
	  //int intMaThuocHienTai=comboBoxExDanhSachCacViThuoc.SelectedIndex;
	  //DEC_GIA_VITHUOC=Convert.ToDecimal(DT_VITHUOC.Rows[intMaThuocHienTai]["GiaViThuoc"]);
	  //string strDonViTinh=Convert.ToString(DT_VITHUOC.Rows[intMaThuocHienTai]["DonViGiaThuoc"]);
	  //numericDonGiaVT.Value=DEC_GIA_VITHUOC;

	  //labelXDonViTinh.Text="("+strDonViTinh+")";

	  //voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  //btnXThemViThuocVaoDH.Enabled=true;
	}

	private void groupBoxThanhTien_MouseHover(object sender,EventArgs e) {
	  voidCAPNHAT_THANHTIEN_SAUKHISUA_SOLUONG();
	  btnXThemViThuocVaoDH.Enabled=true;
	}

	private void FormThemDonHang_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.F5) {
		comboBoxExDanhSachCacViThuoc.Focus();
		comboBoxExDanhSachCacViThuoc.SelectAll();
		numericSoLuongVT.Select(0,22);
		numericDonGiaVT.Select(0,22);
	  }
	  if(e.KeyCode==Keys.F6) {
		numericSoLuongVT.Focus();
		numericSoLuongVT.Select(0,22);
	  }
	  if(e.KeyCode==Keys.F7) {
		numericDonGiaVT.Focus();
		numericDonGiaVT.Select(0,22);
	  }
	}

	private void groupBoxTenViThuoc_MouseHover(object sender,EventArgs e) {
	  //numericSoLuongVT.Select(0,22);
	  //numericDonGiaVT.Select(0,22);
	}

	private void numericDonGiaVT_KeyDown(object sender,KeyEventArgs e) {
	  if(e.KeyCode==Keys.N) {
		numericDonGiaVT.Value*=1000;
		//string strThanhTien=""+"= 0 đ";
		//labelXTinhThanhTien.Text=strThanhTien;
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
		string strThanhTien=""+"= 0 đ";
		labelXTinhThanhTien.Text=strThanhTien;
	  }
	}

  }
}
