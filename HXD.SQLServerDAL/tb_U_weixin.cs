using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HXD.SQLServerDAL
{
    public class tb_U_weixin
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_U_weixin");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;
        
            return HXD.DBUtility.SQLHelper.Equals(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HXD.Model.tb_U_weixin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_weixin(");
            strSql.Append("ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,FormUserName,ToUserName,MsgType,Msg,Creatime,Location_X,Location_Y)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@IsTop,@IsStatus,@IsElite,@IsHot,@Sort,@CreateUsers,@CreateTimes,@CreateIp,@EditUsers,@EditTimes,@EditIp,@FormUserName,@ToUserName,@MsgType,@Msg,@Creatime,@Location_X,@Location_Y)");
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
					new SqlParameter("@FormUserName", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserName", SqlDbType.NVarChar,200),
					new SqlParameter("@MsgType", SqlDbType.NVarChar,200),
					new SqlParameter("@Msg", SqlDbType.NText),
					new SqlParameter("@Creatime", SqlDbType.DateTime),
					new SqlParameter("@Location_X", SqlDbType.NVarChar,200),
					new SqlParameter("@Location_Y", SqlDbType.NVarChar,200)};
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
            parameters[12].Value = model.FormUserName;
            parameters[13].Value = model.ToUserName;
            parameters[14].Value = model.MsgType;
            parameters[15].Value = model.Msg;
            parameters[16].Value = model.Creatime;
            parameters[17].Value = model.Location_X;
            parameters[18].Value = model.Location_Y;

            //object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.tb_U_weixin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_weixin set ");
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
            strSql.Append("FormUserName=@FormUserName,");
            strSql.Append("ToUserName=@ToUserName,");
            strSql.Append("MsgType=@MsgType,");
            strSql.Append("Msg=@Msg,");
            strSql.Append("Creatime=@Creatime,");
            strSql.Append("Location_X=@Location_X,");
            strSql.Append("Location_Y=@Location_Y");
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
					new SqlParameter("@FormUserName", SqlDbType.NVarChar,200),
					new SqlParameter("@ToUserName", SqlDbType.NVarChar,200),
					new SqlParameter("@MsgType", SqlDbType.NVarChar,200),
					new SqlParameter("@Msg", SqlDbType.NText),
					new SqlParameter("@Creatime", SqlDbType.DateTime),
					new SqlParameter("@Location_X", SqlDbType.NVarChar,200),
					new SqlParameter("@Location_Y", SqlDbType.NVarChar,200),
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
            parameters[12].Value = model.FormUserName;
            parameters[13].Value = model.ToUserName;
            parameters[14].Value = model.MsgType;
            parameters[15].Value = model.Msg;
            parameters[16].Value = model.Creatime;
            parameters[17].Value = model.Location_X;
            parameters[18].Value = model.Location_Y;
            parameters[19].Value = model.Id;

            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_U_weixin ");
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
            strSql.Append("delete from tb_U_weixin ");
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
        public HXD.Model.tb_U_weixin GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,FormUserName,ToUserName,MsgType,Msg,Creatime,Location_X,Location_Y from tb_U_weixin ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HXD.Model.tb_U_weixin model = new HXD.Model.tb_U_weixin();
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
        public HXD.Model.tb_U_weixin DataRowToModel(DataRow row)
        {
            HXD.Model.tb_U_weixin model = new HXD.Model.tb_U_weixin();
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
                if (row["FormUserName"] != null)
                {
                    model.FormUserName = row["FormUserName"].ToString();
                }
                if (row["ToUserName"] != null)
                {
                    model.ToUserName = row["ToUserName"].ToString();
                }
                if (row["MsgType"] != null)
                {
                    model.MsgType = row["MsgType"].ToString();
                }
                if (row["Msg"] != null)
                {
                    model.Msg = row["Msg"].ToString();
                }
                if (row["Creatime"] != null && row["Creatime"].ToString() != "")
                {
                    model.Creatime = DateTime.Parse(row["Creatime"].ToString());
                }
                if (row["Location_X"] != null)
                {
                    model.Location_X = row["Location_X"].ToString();
                }
                if (row["Location_Y"] != null)
                {
                    model.Location_Y = row["Location_Y"].ToString();
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
            strSql.Append("select Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,FormUserName,ToUserName,MsgType,Msg,Creatime,Location_X,Location_Y ");
            strSql.Append(" FROM tb_U_weixin ");
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
            strSql.Append(" Id,ClassId,IsTop,IsStatus,IsElite,IsHot,Sort,CreateUsers,CreateTimes,CreateIp,EditUsers,EditTimes,EditIp,FormUserName,ToUserName,MsgType,Msg,Creatime,Location_X,Location_Y ");
            strSql.Append(" FROM tb_U_weixin ");
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
            strSql.Append("select count(1) FROM tb_U_weixin ");
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
            strSql.Append(")AS Row, T.*  from tb_U_weixin T ");
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
            parameters[0].Value = "tb_U_weixin";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod


    }
}
