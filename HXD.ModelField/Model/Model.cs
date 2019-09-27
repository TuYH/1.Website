using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.ModelField.Model
{
    public class Model
    {
        private int id;
        private string tablename;
        private string fieldlist;
        private string condition;
        private string sort;
        private string f_leibie;
        private int pagesize;
        private int pageindex;
        private bool isstatus;
        private bool istop;
        private bool iselite;
        private bool ishot;
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
        public string FieldList
        {
            get { return fieldlist; }
            set { fieldlist = value; }
        }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        public string F_leibie
        {
            get { return f_leibie; }
            set { f_leibie = value; }
        }
        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }
        public int PageIndex
        {
            get { return pageindex; }
            set { pageindex = value; }
        }
        public bool IsStatus
        {
            get { return isstatus; }
            set { isstatus = value; }
        }
        public bool IsTop
        {
            get { return istop; }
            set { istop = value; }
        }
        public bool IsElite
        {
            get { return iselite; }
            set { iselite = value; }
        }
        public bool IsHot
        {
            get { return ishot; }
            set { ishot = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
