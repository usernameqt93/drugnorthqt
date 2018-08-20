using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PQTTool.Helpers {
 public class ModelBase:INotifyPropertyChanged {
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName) {
	  PropertyChangedEventHandler handler = PropertyChanged;
	  if(handler != null)
		handler(this,new PropertyChangedEventArgs(propertyName));
	}
	/// <summary>
	/// For Modal 171212
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="field"></param>
	/// <param name="value"></param>
	/// <param name="propertyName"></param>
	/// <returns></returns>
	protected bool SetProperty<T>(ref T field,T value,string propertyName) {
	  bool propertyHasChanged = !EqualityComparer<T>.Default.Equals(field,value);

	  if(propertyHasChanged) {
		field = value;
		OnPropertyChanged(propertyName);
	  }

	  return propertyHasChanged;
	}

	/// <summary>
	/// Returns whether an exception is thrown, or if a Debug.Fail() is used
	/// when an invalid property name is passed to the VerifyPropertyName method.
	/// The default value is false, but subclasses used by unit tests might 
	/// override this property's getter to return true.
	/// </summary>
	protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
	/// <summary>
	/// Warns the developer if this object does not have
	/// a public property with the specified name. This 
	/// method does not exist in a Release build.
	/// </summary>
	[Conditional("DEBUG")]
	[DebuggerStepThrough]
	public void VerifyPropertyName(string propertyName) {
	  // Verify that the property name matches a real,  
	  // public, instance property on this object.
	  if(TypeDescriptor.GetProperties(this)[propertyName] == null) {
		string msg = "Invalid property name: " + propertyName;

		if(this.ThrowOnInvalidPropertyName)
		  throw new Exception(msg);
		else
		  Debug.Fail(msg);
	  }
	}

	protected virtual void OnPropertyChanged(params string[] propertyNames) {
	  Debug.Assert(propertyNames.Length > 0);

	  foreach(string propertyName in propertyNames) {
		this.VerifyPropertyName(propertyName);

		PropertyChangedEventHandler handler = this.PropertyChanged;
		if(handler != null) {
		  var e = new PropertyChangedEventArgs(propertyName);
		  handler(this,e);
		}
	  }
	}
  }
}
