using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelQT.Framework;

namespace ModelQT.DAL {
  public class DALHtmlRaw:DALBase {
	public DALHtmlRaw() {
	  QTMainDbContext=new Framework.WeblogQTDbContext();
	}

	public void GetListByPageAndSize(ref List<TblHtmlRaw> lst,int intPageIndex,int intPageSize) {
	  lst=QTMainDbContext.TblHtmlRaws.OrderByDescending(x => x.CreatedDate)
		.Skip((intPageIndex-0)*intPageSize).Take(intPageSize).ToList();
	}

	public long LongInsert(TblHtmlRaw minput) {
	  QTMainDbContext.TblHtmlRaws.Add(minput);
	  QTMainDbContext.SaveChanges();
	  return minput.Id;
	}

	public void GetModelHtmlRawDetailById(ref TblHtmlRaw moutput,long longId) {
	  moutput=QTMainDbContext.TblHtmlRaws.SingleOrDefault(x => x.Id==longId);
	}

	public bool BlnUpdateSuccess(TblHtmlRaw minput) {
	  try {
		TblHtmlRaw mUser = QTMainDbContext.TblHtmlRaws.Find(minput.Id);
		mUser.Keyword=minput.Keyword;
		mUser.Html=minput.Html;
		mUser.Description=minput.Description;
		mUser.ModifiedDate=DateTime.Now;
		mUser.ModifiedBy=minput.ModifiedBy;

		QTMainDbContext.SaveChanges();
		return true;
	  } catch(Exception et) {
		string str = et.Message;
		return false;
	  }
	}

	public void GetListByListKey(ref List<TblHtmlRaw> lst,List<string> lstStringKey) {
	  foreach(var item in lstStringKey) {
		var mtemp = new TblHtmlRaw();
		try {
		  mtemp=QTMainDbContext.TblHtmlRaws.SingleOrDefault(x => x.Keyword==item);
		} catch(Exception et) {
		  string str = et.Message;
		}
		lst.Add(mtemp);
	  }
	}
  }
}
