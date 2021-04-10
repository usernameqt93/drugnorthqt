using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelQT.Framework;

namespace ModelQT.DAL {
  public class DALPost:DALBase {
	public DALPost() {
	  QTMainDbContext=new Framework.WeblogQTDbContext();
	}

	public void GetListByPageAndSize(ref List<TblPostBaiViet> lst,int intPageIndex,int intPageSize) {
	  lst=QTMainDbContext.TblPostBaiViets.OrderByDescending(x => x.CreatedDate)
		.Skip((intPageIndex-0)*intPageSize).Take(intPageSize).ToList();
	}

	public void GetModelPostDetailById(ref TblPostBaiViet moutput,long longId) {
	  moutput=QTMainDbContext.TblPostBaiViets.SingleOrDefault(x => x.Id==longId);
	}

	public long LongInsert(TblPostBaiViet minput) {
	  QTMainDbContext.TblPostBaiViets.Add(minput);
	  QTMainDbContext.SaveChanges();
	  return minput.Id;
	}
  }
}
