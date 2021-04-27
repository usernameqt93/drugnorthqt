using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQT.ViewModel {
  public class VMLienLac {
	public long Id { get; set; }
	public string StrNameButton { get; set; } = "Tên nút";
	public string StrLinkLienLac { get; set; } = "";
	public string StrLinkImageIcon { get; set; } = "";
	public bool BlnOpenNewTab { get; set; } = false;
	public bool BlnHienThi { get; set; } = true;
  }
}
