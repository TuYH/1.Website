using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HXD.SQLServerDAL
{
    public class tb_U_TouPiao1
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public DataSet Add(HXD.Model.tb_U_TouPiao1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_TouPiao1(");
            strSql.Append("FatherId,title,VoteType)");
            strSql.Append(" values (");
            strSql.Append("@FatherId,@title,@VoteType)");
            strSql.Append(";select * from tb_U_TouPiao1 where id=@@IDENTITY");
            SqlParameter[] parameters = {
			new SqlParameter("@FatherId", SqlDbType.Int,4),
			new SqlParameter("@title", SqlDbType.NVarChar,100),
			new SqlParameter("@VoteType", SqlDbType.Int,4)};
            parameters[0].Value = model.FatherId;
            parameters[1].Value = model.title;
            parameters[2].Value = 1;
            return HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static int delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_U_TouPiao where ID in(@id)");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.tb_U_TouPiao1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_TouPiao1 set ");
            strSql.Append("title=@title");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
			new SqlParameter("@id", SqlDbType.Int,4),
			new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.title;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.tb_U_TouPiao1 GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,FatherId,title,VoteType,AddTime,Click from tb_U_TouPiao1 ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            HXD.Model.tb_U_TouPiao1 model = new HXD.Model.tb_U_TouPiao1();
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            model.id = id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FatherId"].ToString() != "")
                {
                    model.FatherId = int.Parse(ds.Tables[0].Rows[0]["FatherId"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["VoteType"].ToString() != "")
                {
                    model.VoteType = int.Parse(ds.Tables[0].Rows[0]["VoteType"].ToString());
                }
                model.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]);
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
