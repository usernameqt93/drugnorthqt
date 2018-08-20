using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace QTTool.Helpers {
  public static class ModalContentCommands {
	private static RoutedUICommand showModalContent;
	private static RoutedUICommand hideModalContent;

	/// <summary>
	/// Gets the value that represents the show modal content command.
	/// </summary>
	public static RoutedUICommand ShowModalContent {
	  get {
		if(showModalContent == null) {
		  showModalContent = new RoutedUICommand("Show Modal Content","ShowModalContent",typeof(ModalContentCommands));
		}

		return showModalContent;
	  }
	}

	/// <summary>
	/// Gets the value that represents the hide modal content command.
	/// </summary>
	public static RoutedUICommand HideModalContent {
	  get {
		if(hideModalContent == null) {
		  hideModalContent = new RoutedUICommand("Hide Modal Content","HideModalContent",typeof(ModalContentCommands));
		}

		return hideModalContent;
	  }
	}
  }
}
