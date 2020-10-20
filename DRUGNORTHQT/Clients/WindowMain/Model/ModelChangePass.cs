using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowMain.Models
{
    public class ModelChangePass : ModelBase
    {
        private String _oldPassword = String.Empty;
        /// <summary>
        /// Mật khẩu cũ
        /// </summary>
        public String OldPassword
        {
            get { return _oldPassword; }
            set { _oldPassword = value; OnPropertyChanged("OldPassword"); }
        }

        private String _newPassword = String.Empty;
        /// <summary>
        /// Mật khẩu mới
        /// </summary>
        public String NewPassword
        {
            get { return _newPassword; }
            set { _newPassword = value; OnPropertyChanged("NewPassword"); }
        }

        private String _againNewPassword = String.Empty;
        /// <summary>
        /// Nhập lại mật khẩu mới
        /// </summary>
        public String AgainNewPassword
        {
            get { return _againNewPassword; }
            set { _againNewPassword = value; OnPropertyChanged("AgainNewPassword"); }
        }
    }
}
