using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelQT.Framework;

namespace ModelQT.DAL {
  public class DALUser:DALBase {
	public DALUser() {
	  QTMainDbContext=new Framework.WeblogQTDbContext();
	}

	public void CheckExistUsername(ref bool blnDaCoTaiKhoanNay,string strInput) {
	  int intKq = QTMainDbContext.TblTaiKhoans.Count(x => x.UserName==strInput);
	  if(intKq>0) {
		blnDaCoTaiKhoanNay=true;
	  }
	}

	public long LongInsert(TblTaiKhoan minput) {
	  QTMainDbContext.TblTaiKhoans.Add(minput);
	  QTMainDbContext.SaveChanges();
	  return minput.Id;
	}

	public void GetModelUserByUsername(ref TblTaiKhoan moutput,string strUsername) {
	  moutput=QTMainDbContext.TblTaiKhoans.SingleOrDefault(x => x.UserName==strUsername);
	}
  }
}
