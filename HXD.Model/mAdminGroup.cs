using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mAdminGroup
    {
        private int id;
        private string title;
        private int parentid;
        private int depth;
        private string note;
        private bool islock;
        private string groupsetting;
        private string othersetting;
        private string temp;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int ParentId
        {
            get { return parentid; }
            set { parentid = value; }
        }
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public bool IsLock
        {
            get { return islock; }
            set { islock = value; }
        }
        public string GroupSetting
        {
            get { return groupsetting; }
            set { groupsetting = value; }
        }
        public string OtherSetting
        {
            get { return othersetting; }
            set { othersetting = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
