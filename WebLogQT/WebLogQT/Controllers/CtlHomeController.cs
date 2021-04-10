using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLogQT.Controllers {
  public class CtlHomeController:Controller {
	// GET: CtlHome
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  List<TblPostBaiViet> lst = new List<TblPostBaiViet>();

	  var lstStringBackground = new List<string>();
	  lstStringBackground.Add("bg-warning");
	  lstStringBackground.Add("bg-success");
	  lstStringBackground.Add("bg-danger");
	  lstStringBackground.Add("bg-info");

	  var dal = new DALPost();
	  dal.GetListByPageAndSize(ref lst,0,10);

	  var lstIntRandom = new List<int>();
	  Common.QTTools.GetListIntIndexRandomByCountList(ref lstIntRandom,lstStringBackground.Count);

	  var lstStringClassBackgroundRandom = new List<string>();
	  for(int i = 0;i<200;i++) {
		if(i%2==0) {
		  lstStringClassBackgroundRandom.Add("");
		  continue;
		}

		int intIndex = (i/2)%lstStringBackground.Count;
		lstStringClassBackgroundRandom.Add(lstStringBackground[lstIntRandom[intIndex]]);
	  }

	  ViewBag.LstString=lstStringClassBackgroundRandom;
	  ViewBag.VBLstPost=lst;
	  return View();
	}

  }
}