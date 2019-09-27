using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mSetType
    {
        private int id;
        private string title;
        private string values;
        private int parentid;
        private int sort;

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
        public string Value
        {
            get { return values; }
            set { values = value; }
        }
        public int ParentId
        {
            get { return parentid; }
            set { parentid = value; }
        }
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
    }
}
