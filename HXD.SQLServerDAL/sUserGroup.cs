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
    public class sUserGroup : iUserGroup
    {
        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="Info"></param>
        public void UserGroupInsert(mUserGroup Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@ParentId",Info.ParentId),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Model",Info.Model),
                new SqlParameter("@RegIntegral",Info.RegIntegral),
                new SqlParameter("@LoginIntegral",Info.LoginIntegral),
                new SqlParameter("@Collection",Info.Collection),
                new SqlParameter("@Invite",Info.Invite),
                new SqlParameter("@RegState",Info.RegState),
                new SqlParameter("@GroupSetting",Info.GroupSetting)
            };
            SQLHelper.ExecuteNonQuery("UserGroupInsert", par);
        }

        /// <summary>
        /// 修改用户组
        /// </summary>
        /// <param name="Info"></param>
        public int UserGroupUpdate(mUserGroup Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@ParentId",Info.ParentId),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Model",Info.Model),
                new SqlParameter("@RegIntegral",Info.RegIntegral),
                new SqlParameter("@LoginIntegral",Info.LoginIntegral),
                new SqlParameter("@Collection",Info.Collection),
                new SqlParameter("@Invite",Info.Invite),
                new SqlParameter("@RegState",Info.RegState),
                new SqlParameter("@GroupSetting",Info.GroupSetting)
            };
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("UserGroupEdit", par));
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="Info"></param>
        public void UserGroupDel(mUserGroup Info)
        {
            SQLHelper.ExecuteNonQuery("UserGroupDel", Info.Id);
        }

        /// <summary>
        /// 根据ID读取单个用户组信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mUserGroup> UserGroupReader(mUserGroup Info)
        {
            IList<mUserGroup> list = new List<mUserGroup>();
            using (SqlDataReader dr = SQLHelper.ExecuteReader("UserGroupRead", Info.Id))
            {
                if (dr.Read())
                {
                    mUserGroup mUG = new mUserGroup();
                    mUG.Title = dr[0].ToString();
                    mUG.ParentId = StringDeal.ToInt(dr[1]);
                    mUG.Note = dr[2].ToString();
                    mUG.Model = StringDeal.ToInt(dr[3]);
                    mUG.RegIntegral = StringDeal.ToInt(dr[4]);
                    mUG.LoginIntegral = StringDeal.ToInt(dr[5]);
                    mUG.Collection = StringDeal.ToInt(dr[6]);
                    mUG.Invite = StringDeal.ToInt(dr[7]);
                    mUG.RegState = StringDeal.ToBool(dr[8]);
                    mUG.GroupSetting = dr[9].ToString();
                    list.Add(mUG);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据父级ID获取用户组列表
        /// </summary>
        /// <param name="ParentId">-1为所有，大于-1为父ID号</param>
        /// <returns></returns>
        public DataSet UserGroupList(mUserGroup Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("UserGroupList", Info.ParentId);
            return ds;
        }

        /// <summary>
        /// 根据ID锁定/激活用户组
        /// </summary>
        /// <param name="Info"></param>
        public void UserGroupLock(mUserGroup Info)
        {
            SQLHelper.ExecuteNonQuery("UserGroupLock", Info.Id);
        }

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetUserGroupIsSub(int Id)
        {
            string temp;
            int c1 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_UserGroup WHERE [ParentId] = " + Id + "");
            int c2 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_UserGroup WHERE Id > (SELECT TOP 1 Id FROM tb_UserGroup WHERE Id = " + Id + ") AND ParentId = (SELECT TOP 1 ParentId FROM tb_UserGroup WHERE Id = " + Id + ")");
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

        /// <summary>
        /// 根据模型ID，获取模型标题
        /// </summary>
        /// <param name="ModelId"></param>
        /// <returns></returns>
        public string GetModelTitle(object ModelId)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetTableTitle", StringDeal.ToInt(ModelId)));
        }
    }
}
