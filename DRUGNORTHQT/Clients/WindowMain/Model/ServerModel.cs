using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QT.Framework.ToolCommon.Helpers;

namespace WindowMain.Models
{
    public class ServerModel : ModelBase
    {
        private int _isServer;
        /// <summary>
        /// mã server. 0 - máy local; 1 - server hệ thống
        /// </summary>
        public int IsServer
        {
            get { return _isServer; }
            set { _isServer = value; OnPropertyChanged("IsServer"); }
        }

        private string _serverName;
        /// <summary>
        /// Tên server
        /// </summary>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; OnPropertyChanged("ServerName"); }
        }
    }
}
