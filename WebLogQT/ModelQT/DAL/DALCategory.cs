using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelQT.Framework;

namespace ModelQT.DAL {
  public class DALCategory:DALBase {
	public DALCategory() {
	  QTMainDbContext=new Framework.WeblogQTDbContext();
	}

	public void GetListCategoryByPageAndSize(ref List<TblCategoryTheLoai> lst,int intPageIndex,int intPageSize) {
	  lst=QTMainDbContext.TblCategoryTheLoais.OrderByDescending(x => x.CreatedDate)
		.Skip((intPageIndex-0)*intPageSize).Take(intPageSize).ToList();
	}

	public long LongInsert(TblCategoryTheLoai minput) {
	  QTMainDbContext.TblCategoryTheLoais.Add(minput);
	  QTMainDbContext.SaveChanges();
	  return minput.Id;
	}
  }
}
