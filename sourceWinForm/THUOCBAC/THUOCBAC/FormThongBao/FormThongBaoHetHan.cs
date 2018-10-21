using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUOCBAC.FormThongBao {
  public partial class FormThongBaoHetHan:Form {
	public FormThongBaoHetHan() {
	  InitializeComponent();
	}

	private void FormThongBaoHetHan_Load(object sender,EventArgs e) {
	  string strThongBao="Hiện tại phần mềm của bạn đã hết hạn đăng kí với bên nhà mạng.";
	  strThongBao+="\nĐể tiếp tục sử dụng phần mềm, bạn vui lòng thanh toán phí duy trì phần mềm với nhà mạng.";
	  strThongBao+="\nPhí dịch vụ: 200.000đ/1 tháng.";
	  strThongBao+="\nĐể biết thêm thông tin chi tiết, bạn vui lòng liên hệ số ĐT '01667 002 325' gặp nhân viên kĩ thuật Phạm Quốc Tuấn để được hỗ trợ tốt nhất.";
	  labelXThongBao.Text=strThongBao;
	}

	private void btnXThoatChuongTrinh_Click(object sender,EventArgs e) {
	  Application.Exit();
	}
  }
}
