using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace HXD.SQLServerDAL
{
    public class tb_U_Template_Label
    {
        #region 添加数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HXD.Model.tb_U_Template_Label model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_Template_Label(");
            strSql.Append("labelHelp,labelname,labelfile,counts)");
            strSql.Append(" values (");
            strSql.Append("@labelHelp,@labelname,@labelfile,@counts)");
            SqlParameter[] parameters = {
            new SqlParameter("@labelHelp", SqlDbType.NVarChar,50),
			new SqlParameter("@labelname", SqlDbType.VarChar,50),
			new SqlParameter("@labelfile", SqlDbType.VarChar,500),
			new SqlParameter("@counts", SqlDbType.Text)};
            parameters[0].Value = model.labelHelp;
            parameters[1].Value = model.labelname;
            parameters[2].Value = model.labelfile;
            parameters[3].Value = model.counts;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.tb_U_Template_Label model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_Template_Label set ");
            strSql.Append("labelHelp=@labelHelp,");
            strSql.Append("labelname=@labelname,");
            strSql.Append("labelfile=@labelfile,");
            strSql.Append("counts=@counts");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
			new SqlParameter("@id", SqlDbType.Int,4),
            new SqlParameter("@labelHelp", SqlDbType.NVarChar,50),
			new SqlParameter("@labelname", SqlDbType.VarChar,50),
			new SqlParameter("@labelfile", SqlDbType.VarChar,500),
			new SqlParameter("@counts", SqlDbType.Text)
            };
            parameters[0].Value = model.id;
            parameters[1].Value = model.labelHelp;
            parameters[2].Value = model.labelname;
            parameters[3].Value = model.labelfile;
            parameters[4].Value = model.counts;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        #endregion

        #region 返回对象
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.tb_U_Template_Label GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,labelHelp,labelname,labelfile,counts,submittime from tb_U_Template_Label ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            HXD.Model.tb_U_Template_Label model = new HXD.Model.tb_U_Template_Label();
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.labelHelp = ds.Tables[0].Rows[0]["labelHelp"].ToString();
                model.labelname = ds.Tables[0].Rows[0]["labelname"].ToString();
                model.labelfile = ds.Tables[0].Rows[0]["labelfile"].ToString();
                model.counts = ds.Tables[0].Rows[0]["counts"].ToString();
                if (ds.Tables[0].Rows[0]["submittime"].ToString() != "")
                {
                    model.submittime = DateTime.Parse(ds.Tables[0].Rows[0]["submittime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
