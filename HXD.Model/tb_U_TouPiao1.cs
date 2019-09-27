using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_TouPiao1
    {
        private int _id;
        private int _fatherid;
        private string _title;
        private int _votetype;
        private DateTime _addtime;
        /// <summary>
        /// 自动编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父类id
        /// </summary>
        public int FatherId
        {
            set { _fatherid = value; }
            get { return _fatherid; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 投票类型1为多选2为单选
        /// </summary>
        public int VoteType
        {
            set { _votetype = value; }
            get { return _votetype; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
    }
}
