using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Areas.AreaAccount.Models;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers
{
    public class CtlLoginController : Controller {
	// GET: AreaAccount/CtlLogin
	public ActionResult Index() {
	  return View();
	}

	[HttpGet]
	public ActionResult ARIndex() {
	  Session[CommonConstants.USER_SESSION]=null;
	  if(TempData["strMessage"]!=null) {
		ViewBag.strMessageJs=TempData["strMessage"].ToString();
	  }
	  return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult ARIndex(LoginModel mLogin) {
	  if(ModelState.IsValid==false) {
		ViewBag.strMessageJs="Tên đăng nhập và mật khẩu không hợp lệ, bạn vui lòng kiểm tra lại!";
		return View(mLogin);
	  }

	  if(mLogin.StrUserName==null||mLogin.StrPassword==null||mLogin==null) {
		ViewBag.strMessageJs="Tên đăng nhập và mật khẩu không được để trống!";
		return View(mLogin);
	  }

	  string strUsername = mLogin.StrUserName.Trim();
	  string strPass = mLogin.StrPassword.Trim();
	  var dal = new DALUser();
	  if(strUsername=="superadminqt") {
		bool blnDaCoTaiKhoanNay = false;
		dal.CheckExistUsername(ref blnDaCoTaiKhoanNay,strUsername);
		if(blnDaCoTaiKhoanNay==false) {
		  ViewBag.objAddJSClickButton=true;

		  ViewBag.objAddJSConfirm=true;

		  //(@Html.Raw(Json.Encode()))

		  ViewBag.strIdButtonCreate="idBtnCreate";
		  ViewBag.strConfirmJs="Tài khoản QT này chưa tồn tại, bạn muốn tạo mới nó không?";
		  //ViewBag.strNewHref=$"/AreaAccount/CtlLogin/{nameof(ARCheckAndCreateAccount)}?strUserNameCreate={strUsername}";
		  ViewBag.strNewHref=$"/AreaAccount/CtlLogin/{nameof(ARCheckAndCreateAccount)}";
		  return View(mLogin);
		}

		//ViewBag.strMessageJs="Tên đăng nhập QT này đã có, chuyển sang đăng nhập! - Đặc biệt nên mới hiện message này";
	  }

	  TblTaiKhoan mUser = null;
	  dal.GetModelUserByUsername(ref mUser,strUsername);
	  if(mUser==null) {
		ViewBag.strMessageJs="Tên đăng nhập hoặc mật khẩu không đúng!";
		return View(mLogin);
	  }

	  if(mUser.Status==false) {
		ViewBag.strMessageJs="Tên đăng nhập này đang bị khóa!";
		return View(mLogin);
	  }

	  if(mUser.Password!=Common.QTTools.MD5Hash(strPass)) {
		ViewBag.strMessageJs="Tên đăng nhập hoặc mật khẩu không đúng!";
		return View(mLogin);
	  }

	  Session.Add(CommonConstants.USER_SESSION,strUsername);
	  if(strUsername=="superadminqt") {
		return RedirectToAction("ARIndex","CtlHomeAccount"); 
	  }

	  return RedirectToAction("ARIndex","CtlHomeUser");
	}

	public ActionResult ARCheckAndCreateAccount() {
	  string strUserName = "superadminqt";
	  bool blnDaCoTaiKhoanNay = false;
	  var dal = new DALUser();
	  dal.CheckExistUsername(ref blnDaCoTaiKhoanNay,strUserName);
	  if(blnDaCoTaiKhoanNay==true) {
		string strMessage="Tên đăng nhập này đã tồn tại, bạn vui lòng kiểm tra lại!";
		TempData["strMessage"]=strMessage;
		return RedirectToAction(nameof(ARIndex));
	  }

	  var minput = new TblTaiKhoan();
	  minput.UserName=strUserName;
	  minput.Password=Common.QTTools.MD5Hash(strUserName);
	  minput.Name="Phạm Quốc Tuấn";
	  minput.CreatedBy="Trình tự động QT";
	  long longId = dal.LongInsert(minput);
	  if(longId>0) {
		ViewBag.strMessageJs="Tự động tạo tài khoản QT thành công(tk=mk)!";
		return View(nameof(ARIndex));
	  }

	  ViewBag.strMessageJs="Tự động tạo tài khoản QT không thành công, cần kiểm tra lại!";
	  return View(nameof(ARIndex));
	}

	public ActionResult ARLogout() {
	  Session[CommonConstants.USER_SESSION]=null;
	  return Redirect("/admin");
	}
  }
}