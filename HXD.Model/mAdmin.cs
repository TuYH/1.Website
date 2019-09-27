using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mAdmin
    {
        private int id;
        private int groupid;
        private string username;
        private string userpwd;
        private string truename;
        private string tel;
        private string email;
        private DateTime regtime;
        private DateTime lastlogintime;
        private int logintimes;
        private string lastloginip;
        private bool islock;
        private bool ismodifypassword;
        private bool ismultilogin;
        private string temp;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int GroupId
        {
            get { return groupid; }
            set { groupid = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string UserPwd
        {
            get { return userpwd; }
            set { userpwd = value; }
        }
        public string TrueName
        {
            get { return truename; }
            set { truename = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime RegTime
        {
            get { return regtime; }
            set { regtime = value; }
        }
        public DateTime LastLoginTime
        {
            get { return lastlogintime; }
            set { lastlogintime = value; }
        }
        public int LoginTimes
        {
            get { return logintimes; }
            set { logintimes = value; }
        }
        public string LastLoginIp
        {
            get { return lastloginip; }
            set { lastloginip = value; }
        }
        public bool IsLock
        {
            get { return islock; }
            set { islock = value; }
        }
        public bool IsModifyPassword
        {
            get { return ismodifypassword; }
            set { ismodifypassword = value; }
        }
        public bool IsMultiLogin
        {
            get { return ismultilogin; }
            set { ismultilogin = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
