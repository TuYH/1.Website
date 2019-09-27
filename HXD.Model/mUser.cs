using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mUser
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int LoginTimes { get; set; }
        public string LastLoginIp { get; set; }
        public bool IsLock { get; set; }
        public string Temp { get; set; }
    }
}
