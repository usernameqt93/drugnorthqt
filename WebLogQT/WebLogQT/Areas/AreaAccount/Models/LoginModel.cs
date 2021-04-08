using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogQT.Areas.AreaAccount.Models {
  public class LoginModel {
	[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bạn chưa nhập username")]
	public string StrUserName { get; set; }

	[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bạn chưa nhập password")]
	public string StrPassword { get; set; }
	public bool BlnRememberMe { get; set; }
  }
}