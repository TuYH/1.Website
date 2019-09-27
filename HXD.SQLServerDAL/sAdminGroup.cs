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
        /// ��ӹ���Ա��
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
        /// �޸Ĺ���Ա��
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
        /// ɾ������Ա��
        /// </summary>
        /// <param name="Info"></param>
        public void AdminGroupDel(mAdminGroup Info)
        {
            SQLHelper.ExecuteNonQuery("AdminGroupDel",Info.Id);
        }

        /// <summary>
        /// ����ID��ȡ��������Ա����Ϣ
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
        /// ���ݸ���ID��ȡ�������б�
        /// </summary>
        /// <param name="ParentId">-1Ϊ���У�����-1Ϊ��ID��</param>
        /// <returns></returns>
        public DataSet AdminGroupList(mAdminGroup Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("AdminGroupList",Info.ParentId);
            return ds;
        }

        /// <summary>
        /// ���ݸ���ID����/���������
        /// </summary>
        /// <param name="Info"></param>
        public void AdminGroupLock(mAdminGroup Info)
        {
            SQLHelper.ExecuteNonQuery("AdminGroupLock",Info.Id);
        }

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
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
