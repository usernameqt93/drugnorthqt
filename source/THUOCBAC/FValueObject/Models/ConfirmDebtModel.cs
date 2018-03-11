using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FValueObject.Models {
  public class ConfirmDebtModel {

	public int intIdCustomer { get; set; }

	public int intIdOrderCurrent { get; set; }

	public string strNameCustomer { get; set; }

	public decimal decTienNoHienTai { get; set; }

	public string strDetailDebt { get; set; }

	public decimal decTongTienDonHang { get; set; }

	public DataTable dtLichSuTienNo { get; set; }

  }
}
