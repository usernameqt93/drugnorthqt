using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PQTTool.Helpers {
  public class NounicodeTextBox:TextBox {
	private Regex _regex = null;

	#region StringFilter

	/// <summary>
	/// Chuổi lọc các ký tự
	/// </summary>
	public string StringFilter {
	  get; set;
	}

	/// <summary>
	/// Lọc ký tự
	/// </summary>
	public Regex Regex {
	  get {
		return _regex ?? (_regex = new Regex(StringFilter));
	  }
	}

	/// <summary>
	/// Mặc định là các chữ số từ a-d kể cả in hoa
	/// </summary>


	#endregion

	protected override void OnPreviewTextInput(TextCompositionEventArgs e) {
	  if(!Regex.IsMatch(e.Text)) {
		e.Handled = true;
		return;
	  }
	  base.OnPreviewTextInput(e);
	}
  }

  public class NumberTextBox:TextBox {
	static NumberTextBox() {
	  EventManager.RegisterClassHandler(
		  typeof(NumberTextBox),
		  DataObject.PastingEvent,
		  (DataObjectPastingEventHandler)((sender,e) => {
			if(!IsDataValid(e.DataObject)) {
			  DataObject data = new DataObject();
			  data.SetText(String.Empty);
			  e.DataObject = data;
			  e.Handled = false;
			}
		  }));
	}

	protected override void OnDrop(DragEventArgs e) {
	  e.Handled = !IsDataValid(e.Data);
	  base.OnDrop(e);
	}

	protected override void OnDragOver(DragEventArgs e) {
	  if(!IsDataValid(e.Data)) {
		e.Handled = true;
		e.Effects = DragDropEffects.None;
	  }

	  base.OnDragEnter(e);
	}

	private static Boolean IsDataValid(IDataObject data) {
	  Boolean isValid = false;
	  if(data != null) {
		String text = data.GetData(DataFormats.Text) as String;
		if(!String.IsNullOrEmpty(text == null ? null : text.Trim())) {
		  Int32 result = -1;
		  if(Int32.TryParse(text,out result)) {
			if(result > 0) {
			  isValid = true;
			}
		  }
		}
	  }

	  return isValid;
	}

	protected override void OnKeyDown(KeyEventArgs e) {
	  if(e.Key < Key.D0 || e.Key > Key.D9) {
		if(e.Key < Key.NumPad0 || e.Key > Key.NumPad9) {
		  if(e.Key != Key.Back) {
			e.Handled = true;
		  }
		}
	  }
	}

	private void KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e) {

	  if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
		e.Handled = true;
	  }
	}
  }
}
