using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;

namespace QT.Framework.ToolCommon.Helpers {
  public class Helpers {
	public static T DeepCopy<T>(T other) {
	  var objectJson = JsonConvert.SerializeObject(other);
	  return JsonConvert.DeserializeObject<T>(objectJson);
	}
  }

  public class BindingProxy:Freezable {
	public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data",typeof(object),typeof(BindingProxy));

	protected override Freezable CreateInstanceCore() {
	  return new BindingProxy();
	}

	public object Data {
	  get { return GetValue(DataProperty); }
	  set { SetValue(DataProperty,value); }
	}
  }

}
