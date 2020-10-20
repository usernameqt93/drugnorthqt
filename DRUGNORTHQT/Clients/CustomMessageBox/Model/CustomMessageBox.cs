using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QT.MessageBox
{
    public class CustomMessageBox
    {
        public enum MessageBoxType
        {
            ConfirmationWithYesNo = 0,
            ConfirmationWithYesNoCancel,
            Information,
            Error,
            Warning
        }

        public enum MessageBoxImage
        {
            Warning = 0,
            Question,
            Information,
            Error,
            None
        }
    }
}
