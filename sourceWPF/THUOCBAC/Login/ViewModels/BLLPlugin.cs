using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login.ViewModels {
  internal class BLLPlugin {
	internal void GetPassBase64Decode(ref string strPass,string strInput) {
	  var base64EncodedBytes = System.Convert.FromBase64String(strInput);
	  strPass=System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
	}

	internal void GetPassBase64Encode(ref string strPassEncode,string strInput) {
	  var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(strInput);
	  strPassEncode= System.Convert.ToBase64String(plainTextBytes);
	}
  }
}
