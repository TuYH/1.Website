using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace HXD.SQLServerDAL
{
    public class tb_U_TouPiao
    {       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HXD.Model.tb_U_TouPiao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_U_TouPiao(");
            strSql.Append("title,VoteType,is_Examine,end_time,is_Recommendation)");
            strSql.Append(" values (");
            strSql.Append("@title,@VoteType,@is_Examine,@end_time,@is_Recommendation)");
            SqlParameter[] parameters = {
			new SqlParameter("@title", SqlDbType.NVarChar,100),
			new SqlParameter("@VoteType", SqlDbType.Int,4),
			new SqlParameter("@is_Examine", SqlDbType.Int,4),
            new SqlParameter("@end_time", SqlDbType.DateTime,8),
            new SqlParameter("@is_Recommendation", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.VoteType;
            parameters[2].Value = model.is_Examine;
            parameters[3].Value = model.end_time;
            parameters[4].Value = model.is_Recommendation;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HXD.Model.tb_U_TouPiao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_TouPiao set ");
            strSql.Append("title=@title,");
            strSql.Append("is_Examine=@is_Examine,");
            strSql.Append("end_time=@end_time,");
            strSql.Append("VoteType=@VoteType,");
            strSql.Append("is_Recommendation=@is_Recommendation");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
			new SqlParameter("@id", SqlDbType.Int,4),
			new SqlParameter("@title", SqlDbType.NVarChar,100),
			new SqlParameter("@is_Examine", SqlDbType.Int,4),
            new SqlParameter("@end_time", SqlDbType.DateTime,8),
            new SqlParameter("@VoteType", SqlDbType.Int,4),
            new SqlParameter("@is_Recommendation", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.is_Examine;
            parameters[3].Value = model.end_time;
            parameters[4].Value = model.VoteType;
            parameters[5].Value = model.is_Recommendation;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HXD.Model.tb_U_TouPiao GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,ReleaseTime,ClickNumber,VoteType,is_Examine,is_Recommendation,end_time from tb_U_TouPiao ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            HXD.Model.tb_U_TouPiao model = new HXD.Model.tb_U_TouPiao();
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.ReleaseTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReleaseTime"].ToString());
                if (ds.Tables[0].Rows[0]["ClickNumber"].ToString() != "")
                {
                    model.ClickNumber = int.Parse(ds.Tables[0].Rows[0]["ClickNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VoteType"].ToString() != "")
                {
                    model.VoteType = int.Parse(ds.Tables[0].Rows[0]["VoteType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_Examine"].ToString() != "")
                {
                    model.is_Examine = int.Parse(ds.Tables[0].Rows[0]["is_Examine"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_Recommendation"].ToString() != "")
                {
                    model.is_Recommendation = int.Parse(ds.Tables[0].Rows[0]["is_Recommendation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["end_time"].ToString() != "")
                {
                    model.end_time = DateTime.Parse(ds.Tables[0].Rows[0]["end_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新投票的数量
        /// </summary>
        public static bool UpdateClick(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_TouPiao1 set ");
            strSql.Append("Click=Click+1");
            strSql.Append(" where id in (@id) ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.VarChar, 50) };
            parameters[0].Value = id;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        #region 返回投票列表
        /// <summary>
        /// 返回投票列表
        /// </summary>
        public static string votes()
        {
            StringBuilder strvotes = new StringBuilder();
            string click = "";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 1 id,title,ReleaseTime,ClickNumber,VoteType,is_Examine,is_Recommendation,end_time from tb_U_TouPiao where is_Recommendation=1 and is_Examine=1 and end_time>='" + System.DateTime.Now.ToShortDateString().Trim() + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                strvotes.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                strvotes.Append("<tr>");
                strvotes.Append("<td colspan='2' align='left' valign='middle' class='hong'>" + ds.Tables[0].Rows[0]["title"].ToString().Trim() + "</td>");
                strvotes.Append("</tr>");
                strvotes.Append("<tr>");
                strvotes.Append("<td colspan='2' align='left' valign='top'>");
                string FatherId = ds.Tables[0].Rows[0]["id"].ToString().Trim();
                DataSet ds1 = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,FatherId,title,VoteType,AddTime,Click from tb_U_TouPiao1 where FatherId=" + FatherId);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    strvotes.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    if (ds.Tables[0].Rows[0]["VoteType"].ToString().Trim() == "2")
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            strvotes.Append("<tr>");
                            strvotes.Append("<td width='20%'>");
                            strvotes.Append("<input type='radio' name='radio" + FatherId + "' id='radio" + FatherId + "' value='" + ds1.Tables[0].Rows[i]["id"].ToString().Trim() + "'>");
                            strvotes.Append("</td>");
                            strvotes.Append("<td width='80%' class='l1'>" + HXD.Common.StringDeal.Substrings1(ds1.Tables[0].Rows[i]["title"].ToString().Trim(), 25) + "</td>");
                            strvotes.Append("</tr>");
                        }
                        click = "onclick=\"LetterVote('" + FatherId + "');\"";//单选类型
                    }
                    else
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            strvotes.Append("<tr>");
                            strvotes.Append("<td width='20%'>");
                            strvotes.Append("<input type='checkbox' value='" + ds1.Tables[0].Rows[i]["id"].ToString().Trim() + "' id='checkbox" + FatherId + "'>");
                            strvotes.Append("</td>");
                            strvotes.Append("<td width='80%' class='l1'>" + HXD.Common.StringDeal.Substrings1(ds1.Tables[0].Rows[i]["title"].ToString().Trim(), 25) + "</td>");
                            strvotes.Append("</tr>");
                        }
                        click = "onclick=\"LetterVote1('" + FatherId + "');\"";//多选类型
                    }
                    strvotes.Append("</table>");
                }
                ds1.Tables[0].Clear();
                ds1.Tables[0].Dispose();

                strvotes.Append("</td>");
                strvotes.Append("</tr>");
                strvotes.Append("<tr>");
                strvotes.Append("<td width='44%' align='left' valign='middle'><img " + click + " src='images/an5.jpg' width='60' style='cursor:hand' height='18' border='0'/></td>");
                strvotes.Append("<td width='56%' align='left' valign='middle'><A href='VoteCount.aspx?id=" + ds.Tables[0].Rows[0]["id"].ToString().Trim() + "' target='_blank'><img src='images/an6.jpg' width='60' height='18' style='cursor:help' border='0'/></a></td>");
                strvotes.Append("</tr>");
                strvotes.Append("</table>");
            }
            ds.Tables[0].Clear();
            ds.Tables[0].Dispose();
            return strvotes.ToString();
        }
        #endregion

    }
}
