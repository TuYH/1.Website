using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mTable
    {
        private int id;
        private string title;
        private string tablename;
        private string note;
        private string searchsql;
        private string field;
        private DateTime createtime;
        private bool issystem;
        private int type;
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
        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
        }
        public string Note
	    {
		    get { return note;}
		    set { note = value;}
	    }
        public string SearchSql
        {
            get { return searchsql; }
            set { searchsql = value; }
        }
        public string Field
        {
            get { return field; }
            set { field = value; }
        }
        public DateTime CreateTime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public bool IsSystem
        {
            get { return issystem; }
            set { issystem = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
