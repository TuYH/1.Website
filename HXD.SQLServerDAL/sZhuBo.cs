using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.DBUtility;
using HXD.Model;
using HXD.IDAL;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:sZhuBo
    /// </summary>
    public partial class sZhuBo : mZhuBo
    {
        public sZhuBo()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public void Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_U_zhubo");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HXD.Model.mZhuBo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_zhubo(");
            strSql.Append("ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,name,dianhua,shouji,sy_sun,zj_sun,dz_sun,bf_sun,add_time,photo_tx)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@IsTop,@IsStatus,@IsElite,@IsHot,@Sort,@CreateUsers,@CreateTimes,@CreateIp,@EditUsers,@EditTimes,@EditIp,@name,@dianhua,@shouji,@sy_sun,@zj_sun,@dz_sun,@bf_sun,@add_time,@photo_tx)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsStatus", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@CreateUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTimes", SqlDbType.DateTime),
					new SqlParameter("@CreateIp", SqlDbType.NVarChar,200),
					new SqlParameter("@EditUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@EditTimes", SqlDbType.DateTime),
					new SqlParameter("@EditIp", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@dianhua", SqlDbType.NVarChar,200),
					new SqlParameter("@shouji", SqlDbType.NVarChar,200),
					new SqlParameter("@sy_sun", SqlDbType.Decimal,9),
					new SqlParameter("@zj_sun", SqlDbType.Decimal,9),
					new SqlParameter("@dz_sun", SqlDbType.Decimal,9),
					new SqlParameter("@bf_sun", SqlDbType.Decimal,9),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@photo_tx", SqlDbType.NVarChar,1200)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.IsTop;
            parameters[2].Value = model.IsStatus;
            parameters[3].Value = model.IsElite;
            parameters[4].Value = model.IsHot;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.CreateUsers;
            parameters[7].Value = model.CreateTimes;
            parameters[8].Value = model.CreateIp;
            parameters[9].Value = model.EditUsers;
            parameters[10].Value = model.EditTimes;
            parameters[11].Value = model.EditIp;
            parameters[12].Value = model.name;
            parameters[13].Value = model.dianhua;
            parameters[14].Value = model.shouji;
            parameters[15].Value = model.sy_sun;
            parameters[16].Value = model.zj_sun;
            parameters[17].Value = model.dz_sun;
            parameters[18].Value = model.bf_sun;
            parameters[19].Value = model.add_time;
            parameters[20].Value = model.photo_tx;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.mZhuBo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_zhubo set ");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsStatus=@IsStatus,");
            strSql.Append("IsElite=@IsElite,");
            strSql.Append("IsHot=@IsHot,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("CreateUsers=@CreateUsers,");
            strSql.Append("CreateTimes=@CreateTimes,");
            strSql.Append("CreateIp=@CreateIp,");
            strSql.Append("EditUsers=@EditUsers,");
            strSql.Append("EditTimes=@EditTimes,");
            strSql.Append("EditIp=@EditIp,");
            strSql.Append("name=@name,");
            strSql.Append("dianhua=@dianhua,");
            strSql.Append("shouji=@shouji,");
            strSql.Append("sy_sun=@sy_sun,");
            strSql.Append("zj_sun=@zj_sun,");
            strSql.Append("dz_sun=@dz_sun,");
            strSql.Append("bf_sun=@bf_sun,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("photo_tx=@photo_tx");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsStatus", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@CreateUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTimes", SqlDbType.DateTime),
					new SqlParameter("@CreateIp", SqlDbType.NVarChar,200),
					new SqlParameter("@EditUsers", SqlDbType.NVarChar,200),
					new SqlParameter("@EditTimes", SqlDbType.DateTime),
					new SqlParameter("@EditIp", SqlDbType.NVarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@dianhua", SqlDbType.NVarChar,200),
					new SqlParameter("@shouji", SqlDbType.NVarChar,200),
					new SqlParameter("@sy_sun", SqlDbType.Decimal,9),
					new SqlParameter("@zj_sun", SqlDbType.Decimal,9),
					new SqlParameter("@dz_sun", SqlDbType.Decimal,9),
					new SqlParameter("@bf_sun", SqlDbType.Decimal,9),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@photo_tx", SqlDbType.NVarChar,1200),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.IsTop;
            parameters[2].Value = model.IsStatus;
            parameters[3].Value = model.IsElite;
            parameters[4].Value = model.IsHot;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.CreateUsers;
            parameters[7].Value = model.CreateTimes;
            parameters[8].Value = model.CreateIp;
            parameters[9].Value = model.EditUsers;
            parameters[10].Value = model.EditTimes;
            parameters[11].Value = model.EditIp;
            parameters[12].Value = model.name;
            parameters[13].Value = model.dianhua;
            parameters[14].Value = model.shouji;
            parameters[15].Value = model.sy_sun;
            parameters[16].Value = model.zj_sun;
            parameters[17].Value = model.dz_sun;
            parameters[18].Value = model.bf_sun;
            parameters[19].Value = model.add_time;
            parameters[20].Value = model.photo_tx;
            parameters[21].Value = model.Id;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_U_zhubo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_U_zhubo ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.mZhuBo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,name,dianhua,shouji,sy_sun,zj_sun,dz_sun,bf_sun,add_time,photo_tx from tb_U_zhubo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HXD.Model.mZhuBo model = new HXD.Model.mZhuBo();
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.mZhuBo DataRowToModel(DataRow row)
        {
            HXD.Model.mZhuBo model = new HXD.Model.mZhuBo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    if ((row["IsTop"].ToString() == "1") || (row["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }
                if (row["IsStatus"] != null && row["IsStatus"].ToString() != "")
                {
                    if ((row["IsStatus"].ToString() == "1") || (row["IsStatus"].ToString().ToLower() == "true"))
                    {
                        model.IsStatus = true;
                    }
                    else
                    {
                        model.IsStatus = false;
                    }
                }
                if (row["IsElite"] != null && row["IsElite"].ToString() != "")
                {
                    if ((row["IsElite"].ToString() == "1") || (row["IsElite"].ToString().ToLower() == "true"))
                    {
                        model.IsElite = true;
                    }
                    else
                    {
                        model.IsElite = false;
                    }
                }
                if (row["IsHot"] != null && row["IsHot"].ToString() != "")
                {
                    if ((row["IsHot"].ToString() == "1") || (row["IsHot"].ToString().ToLower() == "true"))
                    {
                        model.IsHot = true;
                    }
                    else
                    {
                        model.IsHot = false;
                    }
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["CreateUsers"] != null)
                {
                    model.CreateUsers = row["CreateUsers"].ToString();
                }
                if (row["CreateTimes"] != null && row["CreateTimes"].ToString() != "")
                {
                    model.CreateTimes = DateTime.Parse(row["CreateTimes"].ToString());
                }
                if (row["CreateIp"] != null)
                {
                    model.CreateIp = row["CreateIp"].ToString();
                }
                if (row["EditUsers"] != null)
                {
                    model.EditUsers = row["EditUsers"].ToString();
                }
                if (row["EditTimes"] != null && row["EditTimes"].ToString() != "")
                {
                    model.EditTimes = DateTime.Parse(row["EditTimes"].ToString());
                }
                if (row["EditIp"] != null)
                {
                    model.EditIp = row["EditIp"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["dianhua"] != null)
                {
                    model.dianhua = row["dianhua"].ToString();
                }
                if (row["shouji"] != null)
                {
                    model.shouji = row["shouji"].ToString();
                }
                if (row["sy_sun"] != null && row["sy_sun"].ToString() != "")
                {
                    model.sy_sun = decimal.Parse(row["sy_sun"].ToString());
                }
                if (row["zj_sun"] != null && row["zj_sun"].ToString() != "")
                {
                    model.zj_sun = decimal.Parse(row["zj_sun"].ToString());
                }
                if (row["dz_sun"] != null && row["dz_sun"].ToString() != "")
                {
                    model.dz_sun = decimal.Parse(row["dz_sun"].ToString());
                }
                if (row["bf_sun"] != null && row["bf_sun"].ToString() != "")
                {
                    model.bf_sun = decimal.Parse(row["bf_sun"].ToString());
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
                if (row["photo_tx"] != null)
                {
                    model.photo_tx = row["photo_tx"].ToString();
                }
            }
            return model;
        }
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,name,dianhua,shouji,sy_sun,zj_sun,dz_sun,bf_sun,add_time,photo_tx ");
            strSql.Append(" FROM tb_U_zhubo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,name,dianhua,shouji,sy_sun,zj_sun,dz_sun,bf_sun,add_time,photo_tx ");
            strSql.Append(" FROM tb_U_zhubo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_U_zhubo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_U_zhubo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_U_zhubo";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

