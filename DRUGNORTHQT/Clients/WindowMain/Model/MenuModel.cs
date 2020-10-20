using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowMain.Models
{
    public class MenuModel
    {
        private int _iD;
        /// <summary>
        /// Mã id (mã quyền) của item
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _order;
        /// <summary>
        /// Thứ tự menu
        /// </summary>
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
        
        private string _name = "";
        /// <summary>
        /// Tên menu(item)
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<SubMenuModel> _lstMenuChilds = new List<SubMenuModel>();   
        /// <summary>
        /// Danh sách menu con
        /// </summary>
        public List<SubMenuModel> LstMenuChilds
        {
            get { return _lstMenuChilds; }
            set { _lstMenuChilds = value; }
        }
    }
}
