using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Model
{
    public class mZhuBo
    {
        public mZhuBo()
        { }
        #region Model
        private int _id;
        private int? _classid = 0;
        private bool _istop = false;
        private bool _isstatus = false;
        private bool _iselite = false;
        private bool _ishot = false;
        private int _sort = 0;
        private string _createusers;
        private DateTime? _createtimes;
        private string _createip;
        private string _editusers;
        private DateTime? _edittimes;
        private string _editip;
        private string _name = "";
        private string _dianhua = "";
        private string _shouji = "";
        private decimal? _sy_sun = 0M;
        private decimal? _zj_sun = 0M;
        private decimal? _dz_sun = 0M;
        private decimal? _bf_sun = 0M;
        private DateTime? _add_time = DateTime.Now;
        private string _photo_tx = "";
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsStatus
        {
            set { _isstatus = value; }
            get { return _isstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsElite
        {
            set { _iselite = value; }
            get { return _iselite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUsers
        {
            set { _createusers = value; }
            get { return _createusers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTimes
        {
            set { _createtimes = value; }
            get { return _createtimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateIp
        {
            set { _createip = value; }
            get { return _createip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EditUsers
        {
            set { _editusers = value; }
            get { return _editusers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditTimes
        {
            set { _edittimes = value; }
            get { return _edittimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EditIp
        {
            set { _editip = value; }
            get { return _editip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dianhua
        {
            set { _dianhua = value; }
            get { return _dianhua; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shouji
        {
            set { _shouji = value; }
            get { return _shouji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sy_sun
        {
            set { _sy_sun = value; }
            get { return _sy_sun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? zj_sun
        {
            set { _zj_sun = value; }
            get { return _zj_sun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dz_sun
        {
            set { _dz_sun = value; }
            get { return _dz_sun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? bf_sun
        {
            set { _bf_sun = value; }
            get { return _bf_sun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string photo_tx
        {
            set { _photo_tx = value; }
            get { return _photo_tx; }
        }
        #endregion Model
    }
}
