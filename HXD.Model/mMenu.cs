using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class mMenu
    {
        private int id;
        private string title;
        private string infophoto;
        private string linkurl;
        private string note;
        private string content;
        private string keywords;
        private string description;
        private int parentid;
        private int pageType;
        private int toMenu;

        private int depth;
        private int sort;
        private bool istop;
        private bool islock;
        private DateTime createtime;
        private string menu_field;
        private string menu_list;
        private int model;
        private string model_field;
        private string model_list;
        private string temp;
        private string sitting;
        private string templateStyle;
        private string templatePath;
        private string outLink;

        public string Sitting
        {
            get { return sitting; }
            set { sitting = value; }
        }

        public int PageType
        {
            get
            {
                return pageType;
            }
            set
            {
                pageType = value;
            }
        }

        public string TemplateStyle
        {
            get
            {
                return templateStyle;
            }
            set
            {
                templateStyle = value;
            }
        }

        public string TemplatePath
        {
            get
            {
                return templatePath;
            }
            set
            {
                templatePath = value;
            }
        }

        public string OutLink
        {
            get
            {
                return outLink;
            }
            set
            {
                outLink = value;
            }
        }

        public int ToMenu
        {
            get
            {
                return toMenu;
            }
            set
            {
                toMenu = value;
            }
        }

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
        public string InfoPhoto
        {
            get { return infophoto; }
            set { infophoto = value; }
        }
        public string LinkUrl
        {
            get { return linkurl; }
            set { linkurl = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
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
        public bool IsTop
        {
            get { return istop; }
            set { istop = value; }
        }
        public bool IsLock
        {
            get { return islock; }
            set { islock = value; }
        }
        public DateTime CreateTime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public string Menu_Field
        {
            get { return menu_field; }
            set { menu_field = value; }
        }
        public string Menu_List
        {
            get { return menu_list; }
            set { menu_list = value; }
        }
        public int Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Model_Field
        {
            get { return model_field; }
            set { model_field = value; }
        }
        public string Model_List
        {
            get { return model_list; }
            set { model_list = value; }
        }
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}
