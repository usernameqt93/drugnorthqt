using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FValueObject.Models {
  public class InfoOrderModel {

	public string strSizePaper { get; set; }

	public string strTime { get; set; }

	public decimal decCopyNumber { get; set; }

	public string strCustomerName { get; set; }

	public decimal decDebtNumber { get; set; }

	public string strPhone { get; set; }

	public decimal decSumMoney { get; set; }

	public DataTable dtDetailOrder { get; set; }

  }
}
