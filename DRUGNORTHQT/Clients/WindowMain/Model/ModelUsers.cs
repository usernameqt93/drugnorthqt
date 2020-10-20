using QT.Framework.ToolCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowMain.Models
{
    public class ModelUsers : ModelBase
    {
        private Int32 _stt = 0;
        public Int32 Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged("Stt"); }
        }
        private Int32 _userID = 0;
        public Int32 UserID
        {
            get { return _userID; }
            set { _userID = value; OnPropertyChanged("UserID"); }
        }
        private String _fullName = String.Empty;
        public String FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged("FullName"); }
        }
        private String _userName = String.Empty;
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }
        private String _password = String.Empty;
        public String Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); OnPasswordChanged?.Invoke(this); }
        }
        private String _againpassword = String.Empty;
        public String AgainPassword
        {
            get { return _againpassword; }
            set { _againpassword = value; OnPropertyChanged("AgainPassword"); }
        }
        private String _name = String.Empty;
        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private String _surname = String.Empty;
        public String Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }
        private String _dOB = String.Empty;
        public String DOB
        {
            get { return _dOB; }
            set { _dOB = value; OnPropertyChanged("DOB"); }
        }
        private Boolean _gender = false;
        public Boolean Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("Gender"); }
        }
        private string _genderName = string.Empty;
        public String GenderName
        {
            get { return _genderName; }
            set { _genderName = value; OnPropertyChanged("GenderName"); }
        }
        private String _address = String.Empty;
        public String Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }
        private String _tel = String.Empty;
        public String Tel
        {
            get { return _tel; }
            set { _tel = value; OnPropertyChanged("Tel"); }
        }
        private Byte[] _avatar = new byte[0];
        public Byte[] Avatar
        {
            get { return _avatar; }
            set { _avatar = value; OnPropertyChanged("Avatar"); }
        }
        private Int32 _groupID = 0;
        public Int32 GroupID
        {
            get { return _groupID; }
            set { _groupID = value; OnPropertyChanged("GroupID"); }
        }
        private String _groupName = String.Empty;
        public String GroupName
        {
            get { return _groupName; }
            set { _groupName = value; OnPropertyChanged("GroupName"); }
        }
        private Int32 _muID = 0;
        public Int32 MuID
        {
            get { return _muID; }
            set { _muID = value; OnPropertyChanged("MuID"); }
        }
        private String _muInfo = String.Empty;
        public String MuInfo
        {
            get { return _muInfo; }
            set { _muInfo = value; OnPropertyChanged("MuInfo"); }
        }
        private Boolean _block = false;
        public Boolean Block
        {
            get { return _block; }
            set { _block = value; OnPropertyChanged("Block"); }
        }
        private String _blockName = string.Empty;
        public String BlockName
        {
            get { return _blockName; }
            set { _blockName = value; OnPropertyChanged("BlockName"); }
        }
        private Int32 _deleted = 0;
        public Int32 Deleted
        {
            get { return _deleted; }
            set { _deleted = value; OnPropertyChanged("Deleted"); }
        }
        private String _error = String.Empty;
        public String Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }
        private Int32 _page = 0;
        public Int32 Page
        {
            get { return _page; }
            set { _page = value; OnPropertyChanged("Page"); }
        }
        private bool? _selected = false;
        public bool? Selected
        {
            get { return _selected; }
            set { _selected = value; OnPropertyChanged("Selected"); }
        }

        #region Tạm
        public delegate void PasswordChangedChanged(ModelUsers sender);
        public PasswordChangedChanged OnPasswordChanged;

        #endregion
    }
}