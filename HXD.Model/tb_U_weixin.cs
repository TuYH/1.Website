using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Model
{
    public class tb_U_weixin
    {

        private int _id;
		private int? _classid=0;
		private bool _istop= false;
		private bool _isstatus= false;
		private bool _iselite= false;
		private bool _ishot= false;
		private int _sort=0;
		private string _createusers;
		private DateTime? _createtimes;
		private string _createip;
		private string _editusers;
		private DateTime? _edittimes;
		private string _editip;
		private string _formusername="";
		private string _tousername="";
		private string _msgtype="";
		private string _msg="";
		private DateTime? _creatime= DateTime.Now;
		private string _location_x="";
		private string _location_y="";
		/// <summary>
		/// 标示ID
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 分类ID
		/// </summary>
		public int? ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 置顶
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 审核
		/// </summary>
		public bool IsStatus
		{
			set{ _isstatus=value;}
			get{return _isstatus;}
		}
		/// <summary>
		/// 推荐
		/// </summary>
		public bool IsElite
		{
			set{ _iselite=value;}
			get{return _iselite;}
		}
		/// <summary>
		/// 热门
		/// </summary>
		public bool IsHot
		{
			set{ _ishot=value;}
			get{return _ishot;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
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
		/// 发送方微信号
		/// </summary>
		public string FormUserName
		{
			set{ _formusername=value;}
			get{return _formusername;}
		}
		/// <summary>
		/// 接收方微信号
		/// </summary>
		public string ToUserName
		{
			set{ _tousername=value;}
			get{return _tousername;}
		}
		/// <summary>
		/// 消息类型
		/// </summary>
		public string MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 消息内容
		/// </summary>
		public string Msg
		{
			set{ _msg=value;}
			get{return _msg;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? Creatime
		{
			set{ _creatime=value;}
			get{return _creatime;}
		}
		/// <summary>
		/// X坐标
		/// </summary>
		public string Location_X
		{
			set{ _location_x=value;}
			get{return _location_x;}
		}
		/// <summary>
		/// Y坐标
		/// </summary>
		public string Location_Y
		{
			set{ _location_y=value;}
			get{return _location_y;}
		}
		

    }
}
