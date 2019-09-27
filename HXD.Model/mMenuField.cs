using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mMenuField
    {
        private int id;
        private string field;
        private string title;
        private string note;
        private int type;
        private int sort;
        private string temp;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Field
        {
            get { return field; }
            set { field = value; }
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
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
