using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mField
    {
        private int id;
        private string tablename;
        private string field;
        private string title;
        private string note;
        private string prompt;
        private string type;
        private int sort;
        private DateTime createtime;
        private string temp;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
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
        public string Prompt
        {
            get { return prompt; }
            set { prompt = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
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
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
