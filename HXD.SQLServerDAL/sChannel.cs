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
    public class sChannel : iChannel
    {
        /// <summary>
        /// ��Ӻ�̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        public void ChannelInsert(mChannel Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Target",Info.Target),
                new SqlParameter("@Url",Info.Url),
                new SqlParameter("@Setting",Info.Setting),
                new SqlParameter("@IsLock",Info.IsLock),
                new SqlParameter("@ParentId",Info.ParentId)
            };
            SQLHelper.ExecuteNonQuery("ChannelInsert", par);
        }

        /// <summary>
        /// �޸ĺ�̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        public int ChannelUpdate(mChannel Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Target",Info.Target),
                new SqlParameter("@Url",Info.Url),
                new SqlParameter("@ParentId",Info.ParentId),
                new SqlParameter("@Setting",Info.Setting),
                new SqlParameter("@IsLock",Info.IsLock)
            };
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("ChannelEdit", par));
        }

        /// <summary>
        /// ɾ����̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        public string ChannelDel(int Id)
        {
            return SQLHelper.ExecuteScalar("ChannelDel", Id).ToString();
        }

        /// <summary>
        /// ��ȡ��̨Ƶ����������
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mChannel> ChannelRead(mChannel Info)
        {
            IList<mChannel> list = new List<mChannel>();
            using (SqlDataReader dr = SQLHelper.ExecuteReader("ChannelRead", Info.Id))
            {
                if (dr.Read())
                {
                    mChannel mC = new mChannel();
                    mC.Title = dr[0].ToString();
                    mC.Note = dr[1].ToString();
                    mC.Target = dr[2].ToString();
                    mC.Url = dr[3].ToString();
                    mC.ParentId = StringDeal.ToInt(dr[4]);
                    mC.Setting = dr[5].ToString();
                    list.Add(mC);
                }
            }
            return list;
        }

        /// <summary>
        /// ��ȡƵ���б�DATASET
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public DataSet ChannelList(int ParentId)
        {
            DataSet ds = SQLHelper.ExecuteDataset("ChannelList", ParentId);
            return ds;
        }

        /// <summary>
        /// Ƶ���ر�/����
        /// </summary>
        /// <param name="Info"></param>
        public void ChannelLock(int Id)
        {
            SQLHelper.ExecuteNonQuery("ChannelLock", Id);
        }

        /// <summary>
        /// Ƶ������
        /// </summary>
        /// <param name="Info"></param>
        public void ChannelMove(int Id, string Action)
        {
            SQLHelper.ExecuteNonQuery("ChannelMove", Id, Action);
        }



        /// <summary>
        /// ��ȡ��̨Ƶ������
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetChannelTitle(int Id)
        {
            string temp = "";
            try
            {
                temp = SQLHelper.ExecuteScalar("ChannelTitle", Id).ToString();
            }
            catch { };
            return temp;
        }

        /// <summary>
        /// ��ȡ��̨���Ƶ�������б�
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public IList<DataSet> GetChannelMenu(int ParentId,string UserName)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@ParentId",ParentId),
                new SqlParameter("@UserName",UserName)
            };
            DataSet ds = SQLHelper.ExecuteDataset("ChannelMenu", par);
            IList<DataSet> list = new List<DataSet>();
            list.Add(ds);
            return list;
        }

        /// <summary>
        /// ��ȡ��̨���Ƶ���Ӽ���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetChannelSubCount(int Id)
        {
            try
            {
                return int.Parse(SQLHelper.ExecuteScalar("ChannelIsSub", Id).ToString());
            }
            catch 
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ȡ��̨���Ƶ����һ����ĿID
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int GetChannelFirstParentId(string UserName)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",UserName)
            };
            try
            {
                return int.Parse(SQLHelper.ExecuteScalar("ChannelFirstParentId", par).ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetChannelIsSub(int Id)
        {
            string temp;
            int c1 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_Channel WHERE [ParentId] = " + Id + "");
            int c2 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_Channel WHERE Sort > (SELECT TOP 1  Sort FROM tb_Channel WHERE Id = " + Id + ") AND ParentId = (SELECT TOP 1 ParentId FROM tb_Channel WHERE Id = " + Id + ")");
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
