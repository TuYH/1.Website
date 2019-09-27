using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_TouPiao
    {
        private int _id;
        private string _title;
        private DateTime _releasetime;
        private int _clicknumber;
        private int _votetype;
        private int _is_examine;
        private int _is_recommendation;
        private DateTime _end_time;
        /// <summary>
        /// 自动编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 投票的标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime
        {
            set { _releasetime = value; }
            get { return _releasetime; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public int ClickNumber
        {
            set { _clicknumber = value; }
            get { return _clicknumber; }
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
        /// 是否审核
        /// </summary>
        public int is_Examine
        {
            set { _is_examine = value; }
            get { return _is_examine; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int is_Recommendation
        {
            set { _is_recommendation = value; }
            get { return _is_recommendation; }
        }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime end_time
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
    }
}
