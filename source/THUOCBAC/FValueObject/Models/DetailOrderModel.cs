using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FValueObject.Models {
  public class DetailOrderModel {

	public decimal decTongTien { get; set; }

	public int intIdOrderCurrent { get; set; }

	public int intIdCustomerCurrent { get; set; }

	public string strPhoneSaveWithOrder { get; set; }

	public decimal decDebtSaveWithOrder { get; set; }

	public DateTime dtTimeCreate { get; set; }

	public DataTable dtDetailOrder { get; set; }

  }
}
