using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_Template_Label
    {
        private int _id;
        private string _labelhelp;
        private string _labelname;
        private string _labelfile;
        private string _counts;
        private DateTime _submittime;
        /// <summary>
        /// 自增id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标签说明
        /// </summary>
        public string labelHelp
        {
            set { _labelhelp = value; }
            get { return _labelhelp; }
        }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string labelname
        {
            set { _labelname = value; }
            get { return _labelname; }
        }
        /// <summary>
        /// 标签文件(相对路径)
        /// </summary>
        public string labelfile
        {
            set { _labelfile = value; }
            get { return _labelfile; }
        }
        /// <summary>
        /// 要替换的内容
        /// </summary>
        public string counts
        {
            set { _counts = value; }
            get { return _counts; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime submittime
        {
            set { _submittime = value; }
            get { return _submittime; }
        }
    }
}
