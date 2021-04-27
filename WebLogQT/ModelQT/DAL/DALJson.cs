using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelQT.Framework;

namespace ModelQT.DAL {
  public class DALJson:DALBase {
	public DALJson() {
	  QTMainDbContext=new Framework.WeblogQTDbContext();
	}

	public void GetListByPageAndSize(ref List<TblJson> lst,int intPageIndex,int intPageSize) {
	  lst=QTMainDbContext.TblJsons.OrderByDescending(x => x.CreatedDate)
		.Skip((intPageIndex-0)*intPageSize).Take(intPageSize).ToList();
	}

	public long LongInsert(TblJson minput) {
	  QTMainDbContext.TblJsons.Add(minput);
	  QTMainDbContext.SaveChanges();
	  return minput.Id;
	}

	public void GetListByListKey(ref List<TblJson> lst,List<string> lstStringKey) {
	  foreach(var item in lstStringKey) {
		var mtemp = new TblJson();
		try {
		  mtemp=QTMainDbContext.TblJsons.SingleOrDefault(x => x.Keyword==item);
		} catch(Exception et) {
		  string str = et.Message;
		}
		lst.Add(mtemp);
	  }
	}

	public void GetModelJsonDetailById(ref TblJson moutput,long longId) {
	  moutput=QTMainDbContext.TblJsons.SingleOrDefault(x => x.Id==longId);
	}

	public bool BlnUpdateSuccess(TblJson minput) {
	  try {
		TblJson mUser = QTMainDbContext.TblJsons.Find(minput.Id);
		mUser.Keyword=minput.Keyword;
		mUser.Json=minput.Json;
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

	public bool BlnUpdateSuccessByKeyword(TblJson minput) {
	  try {
		TblJson mUser = QTMainDbContext.TblJsons.SingleOrDefault(x => x.Keyword==minput.Keyword);
		//mUser.Keyword=minput.Keyword;
		mUser.Json=minput.Json;
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

  }
}
