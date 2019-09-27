using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using HXD.DBUtility;
using HXD.Model;
using HXD.IDAL;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    public class sAdminGroup : iAdminGroup
    {
        /// <summary>
        /// 添加管理员组
        /// </summary>
        /// <param name="Info"></param>
        public void AdminGroupInsert(mAdminGroup Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@ParentId",Info.ParentId),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@GroupSetting",Info.GroupSetting),
                new SqlParameter("@OtherSetting",Info.OtherSetting)
            };
            SQLHelper.ExecuteNonQuery("AdminGroupInsert", par);
        }

        /// <summary>
        /// 修改管理员组
        /// </summary>
        /// <param name="Info"></param>
        public int AdminGroupUpdate(mAdminGroup Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@ParentId",Info.ParentId),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@GroupSetting",Info.GroupSetting),
                new SqlParameter("@OtherSetting",Info.OtherSetting)
            };
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("AdminGroupEdit", par));
        }

        /// <summary>
        /// 删除管理员组
        /// </summary>
        /// <param name="Info"></param>
        public void AdminGroupDel(mAdminGroup Info)
        {
            SQLHelper.ExecuteNonQuery("AdminGroupDel",Info.Id);
        }

        /// <summary>
        /// 根据ID读取单个管理员组信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mAdminGroup> AdminGroupReader(mAdminGroup Info)
        {
            IList<mAdminGroup> list = new List<mAdminGroup>();
            using (SqlDataReader dr = SQLHelper.ExecuteReader("AdminGroupRead", Info.Id))
            {
                if (dr.Read())
                {
                    mAdminGroup mAG = new mAdminGroup();
                    mAG.Title = dr[0].ToString();
                    mAG.ParentId = StringDeal.ToInt(dr[1]);
                    mAG.Note = dr[2].ToString();
                    mAG.GroupSetting = dr[3].ToString();
                    mAG.OtherSetting = dr[4].ToString();
                    list.Add(mAG);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据父级ID获取管理组列表
        /// </summary>
        /// <param name="ParentId">-1为所有，大于-1为父ID号</param>
        /// <returns></returns>
        public DataSet AdminGroupList(mAdminGroup Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("AdminGroupList",Info.ParentId);
            return ds;
        }

        /// <summary>
        /// 根据父级ID锁定/激活管理组
        /// </summary>
        /// <param name="Info"></param>
        public void AdminGroupLock(mAdminGroup Info)
        {
            SQLHelper.ExecuteNonQuery("AdminGroupLock",Info.Id);
        }

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetAdminGroupIsSub(int Id)
        {
            string temp;
            int c1 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_AdminGroup WHERE [ParentId] = " + Id + "");
            int c2 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_AdminGroup WHERE Id > (SELECT TOP 1 Id FROM tb_AdminGroup WHERE Id = " + Id + ") AND ParentId = (SELECT TOP 1 ParentId FROM tb_AdminGroup WHERE Id = " + Id + ")");
            if (c1 > 0)
            {
                if (c2 > 0)
                    temp = "<img alt=\"\" src=\"../skin/01/ico/tree_plusmiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">";
                else
                    temp = "<img alt=\"\" src=\"../skin/01/ico/tree_plusmiddle1.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">";
            }
            else
            {
                if (c2 > 0)
                    temp = "<img alt=\"\" src=\"../skin/01/ico/tree_minusmiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">";
                else
                    temp = "<img alt=\"\" src=\"../skin/01/ico/tree_minusmiddle1.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">";
            }
            return temp;
        }
    }
}
