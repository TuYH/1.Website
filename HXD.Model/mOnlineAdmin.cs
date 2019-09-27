using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mOnlineAdmin
    {
        private int id;
        private string username;
        private string sessionid;
        private DateTime updatetime;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string SessionId
        {
            get { return sessionid; }
            set { sessionid = value; }
        }
        public DateTime UpdateTime
        {
            get { return updatetime; }
            set { updatetime = value; }
        }
    }
}
