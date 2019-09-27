using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_Info
	{
		
		private int _id;
        private int _u_id;
		private int? _classid=0;
		private bool _istop= false;
		private bool _isstatus= false;
		private bool _iselite= false;
		private bool _ishot= false;
		private int _sort=0;
		private string _title="";
		private string _lookpwd="";
		private string _note="";
		private string _content="";
		private string _year="2009";
		private decimal? _conut=0M;
		private DateTime? _posttime= DateTime.Now;
		private string _author="佚名";
		private string _infofrom="本站原创";
		private string _title1="";
		private string _url="";
		private string _infoeditor="";
		private string _abouttag="";
		private string _photo="";
		private string _createusers;
		private DateTime? _createtimes;
		private string _createip;
		private string _editusers;
		private DateTime? _edittimes;
		private string _editip;
		private string _keywords="";
		private string _description="";
		private string _fenlei="";
		private string _mp3="";
		private int? _f_leibie;
		private int? _p_gl;
		private string _city_city="";
		private string _city="";
        private string _z_time = "";
        private string _jd_time = "";
        private string _ms_time = "";
        private string _gw_time = "";
        private string _zb_time = "";
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsStatus
		{
			set{ _isstatus=value;}
			get{return _isstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsElite
		{
			set{ _iselite=value;}
			get{return _iselite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LookPwd
		{
			set{ _lookpwd=value;}
			get{return _lookpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Conut
		{
			set{ _conut=value;}
			get{return _conut;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoFrom
		{
			set{ _infofrom=value;}
			get{return _infofrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title1
		{
			set{ _title1=value;}
			get{return _title1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoEditor
		{
			set{ _infoeditor=value;}
			get{return _infoeditor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AboutTag
		{
			set{ _abouttag=value;}
			get{return _abouttag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUsers
		{
			set{ _createusers=value;}
			get{return _createusers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTimes
		{
			set{ _createtimes=value;}
			get{return _createtimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateIp
		{
			set{ _createip=value;}
			get{return _createip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EditUsers
		{
			set{ _editusers=value;}
			get{return _editusers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EditTimes
		{
			set{ _edittimes=value;}
			get{return _edittimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EditIp
		{
			set{ _editip=value;}
			get{return _editip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fenlei
		{
			set{ _fenlei=value;}
			get{return _fenlei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mp3
		{
			set{ _mp3=value;}
			get{return _mp3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? f_leibie
		{
			set{ _f_leibie=value;}
			get{return _f_leibie;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? p_gl
        {
            set { _p_gl = value; }
            get { return _p_gl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city_City
        {
            set { _city_city = value; }
            get { return _city_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string z_time
        {
            set { _z_time = value; }
            get { return _z_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jd_time
        {
            set { _jd_time = value; }
            get { return _jd_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ms_time
        {
            set { _ms_time = value; }
            get { return _ms_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gw_time
        {
            set { _gw_time = value; }
            get { return _gw_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zb_time
        {
            set { _zb_time = value; }
            get { return _zb_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int U_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }

	}
}
