using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_Advertisement
    {
        private int _id;
        private string _adname;
        private int _width;
        private int _height;
        private string _files;
        private int _filetype;
        private string _href;
        private string _elucidation;
        private string _scripttext;
        private int _type;
        private DateTime _closetime;
        private bool _isqiyong;
        private DateTime _submittime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string AdName
        {
            set { _adname = value; }
            get { return _adname; }
        }
        /// <summary>
        /// 广告宽度
        /// </summary>
        public int Width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 广告高度
        /// </summary>
        public int Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 图片文件
        /// </summary>
        public string Files
        {
            set { _files = value; }
            get { return _files; }
        }
        /// <summary>
        /// 图片类型1服务器2本地
        /// </summary>
        public int FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 文字广告连接
        /// </summary>
        public string href
        {
            set { _href = value; }
            get { return _href; }
        }
        /// <summary>
        /// 连接说明
        /// </summary>
        public string Elucidation
        {
            set { _elucidation = value; }
            get { return _elucidation; }
        }
        /// <summary>
        /// 脚本广告
        /// </summary>
        public string scripttext
        {
            set { _scripttext = value; }
            get { return _scripttext; }
        }
        /// <summary>
        /// 广告类型1文字2图片3Flash4脚本5浮动广告6Flash滚动
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 广告到期时间
        /// </summary>
        public DateTime CloseTime
        {
            set { _closetime = value; }
            get { return _closetime; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isqiyong
        {
            set { _isqiyong = value; }
            get { return _isqiyong; }
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
