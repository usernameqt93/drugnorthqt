using HostViewer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowMain.Models
{
    public class SubMenuModel
    {
        private int _order;
        /// <summary>
        /// Thứ tự menu
        /// </summary>
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private string _nameItem = "";
        /// <summary>
        /// Tên menu con
        /// </summary>
        public string NameItem
        {
            get { return _nameItem; }
            set { _nameItem = value; }
        }

        private string _iconFileName = "";
        /// <summary>
        /// Tên file icon
        /// </summary>
        public string IconFileName
        {
            get { return _iconFileName; }
            set { _iconFileName = value; }
        }

        private AvailableArrayProcessor _tag = new AvailableArrayProcessor();
        /// <summary>
        /// Thông tin plugin
        /// </summary>
        public AvailableArrayProcessor Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
    }
}
