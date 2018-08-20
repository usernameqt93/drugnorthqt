using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PQTTool.Helpers {
 public class Helpers {
	public static T DeepCopy<T>(T other) {
	  var objectJson = JsonConvert.SerializeObject(other);
	  return JsonConvert.DeserializeObject<T>(objectJson);
	}
  }
}
