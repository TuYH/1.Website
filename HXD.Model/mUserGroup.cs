using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mUserGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public int Depth { get; set; }
        public string Note { get; set; }
        public int Model { get; set; }
        public int  RegIntegral { get; set; }
        public int LoginIntegral { get; set; }
        public int Collection { get; set; }
        public int Invite { get; set; }
        public bool RegState { get; set; }
        public bool IsLock { get; set; }
        public string GroupSetting { get; set; }
        public string Temp { get; set; }
    }
}
