using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mChannel
    {
        private int id;
        private string title;
        private string note;
        private string target;
        private string url;
        private int parentid;
        private int depth;
        private int sort;
        private DateTime createtime;
        private string setting;
        private bool islock;
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
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public string Target
        {
            get { return target; }
            set { target = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
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
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        public DateTime CreateTime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public string Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        public bool IsLock
        {
            get { return islock; }
            set { islock = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
