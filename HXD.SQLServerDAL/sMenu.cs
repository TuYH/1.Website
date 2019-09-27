using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.Model;
using HXD.IDAL;
using HXD.DBUtility;
using HXD.Common;
using System.Text.RegularExpressions;

namespace HXD.SQLServerDAL
{
    public class sMenu : iMenu
    {
        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="Info"></param>
        public void MenuInsert(int ParentId,string Field,string Value)
        {
            string sql = "INSERT INTO tb_Menu (ParentId," + Field.Trim(',') + ") VALUES (" + ParentId + "," + Value.Replace("{$split$}", ",").Trim(',') + ")";
            SQLHelper.ExecuteNonQuery("MenuInsert", ParentId, sql);
        }
        /// <summary>
        /// �����Ŀ(2)
        /// </summary>
        /// <param name="Info"></param>
        public void MenuInsert2(int ParentId, int MenuId, int MenuId2, string Field, string Value)
        {
            string sql = "INSERT INTO tb_Menu (PageType,ToMenu,ParentId," + Field.Trim(',') + ") VALUES (" + ParentId + "," + MenuId2 + "," + MenuId + "," + Value.Replace("{$split$}", ",").Trim(',') + ")";
            SQLHelper.ExecuteNonQuery("MenuInsert", ParentId, sql);
        }
        /// <summary>
        /// �����Ŀ(���� @@Identity)
        /// </summary>
        /// <param name="Info"></param>
        public int MenuInsert1(int ParentId, string Field, string Value)
        {
            string sql = "INSERT INTO tb_Menu (ParentId," + Field.Trim(',') + ") VALUES (" + ParentId + "," + Value.Replace("{$split$}", ",").Trim(',') + ")";
            return Convert.ToInt32(SQLHelper.ExecuteScalar("MenuInsert1", ParentId, sql));
        }

        /// <summary>
        /// �޸���Ŀ
        /// </summary>
        /// <param name="Info"></param>
        public void MenuUpdate(int Id, int ParentId,string Field, string Value)
        {
            string sql = "UPDATE tb_Menu SET ParentId = "+ParentId+"";
            for (int i = 0; i<Field.Trim(',').Split(',').Length; i++)
            {
                try
                {
                    sql += "," + Field.Trim(',').Split(',')[i] + "=" + Value.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None)[i] + "";
                }
                catch { }
            }
            sql += " WHERE Id = " + Id + "";
            SQLHelper.ExecuteNonQuery("MenuEdit", Id, ParentId, sql);
        }
        /// <summary>
        /// �޸���Ŀ
        /// </summary>
        /// <param name="Info"></param>
        public void MenuUpdate1(int Id, int ParentId, int MenuId, int MenuId2, string Field, string Value)
        {
            string sql = "UPDATE tb_Menu SET ParentId = " + MenuId + ",PageType=" + ParentId + ",ToMenu=" + MenuId2 + "";
            for (int i = 0; i < Field.Trim(',').Split(',').Length; i++)
            {
                try
                {
                    sql += "," + Field.Trim(',').Split(',')[i] + "=" + Value.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None)[i] + "";
                }
                catch { }
            }
            sql += " WHERE Id = " + Id + "";
            SQLHelper.ExecuteNonQuery("MenuEdit", Id, ParentId, sql);
        }

        /// <summary>
        /// ɾ����Ŀ�������Ŀ��������Ŀ���򷵻�1���򷵻�0
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public int MenuDel(mMenu Info)
        {
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("MenuDel",Info.Id));
        }

        /// <summary>
        /// ������Ŀ�б�DATASET
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuList()
        {
            DataSet ds = SQLHelper.ExecuteDataset("MenuList");
            return ds;
        }

        /// <summary>
        /// ������Ŀ�б�DATASET
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuList(int ParentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from tb_Menu ");
            sql.Append(" where ParentId=@ParentId ");

            SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4)};
            parameters[0].Value = ParentId;

            DataSet ds = SQLHelper.ExecuteDataset(sql.ToString(),parameters);
            return ds;
        }

        /// <summary>
        /// ��ȡ��Ŀ������Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuReader(mMenu Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("MenuRead", Info.Id);
            return ds;
        }

        /// <summary>
        /// ���ݱ�Ŷ�ȡ��Ŀ������Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuReader(int Id)
        {
            DataSet ds = SQLHelper.ExecuteDataset("MenuRead", Id);
            return ds;
        }

        /// <summary>
        /// ����/������Ŀ
        /// </summary>
        /// <param name="Info"></param>
        public void MenuLock(mMenu Info)
        {
            SQLHelper.ExecuteNonQuery("MenuLock", Info.Id);
        }

        /// <summary>
        /// �ö���Ŀ
        /// </summary>
        /// <param name="Info"></param>
        public void MenuTop(mMenu Info)
        {
            SQLHelper.ExecuteNonQuery("MenuTop", Info.Id);
        }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <param name="Info"></param>
        public void MenuMove(mMenu Info,string Action)
        {
            SQLHelper.ExecuteNonQuery("MenuMove", Info.Id, Action);
        }


        /// <summary>
        /// ������Ŀģ���Լ���Ϣģ�͵��ֶ�
        /// </summary>
        /// <param name="Info"></param>
        public void MenuSet(mMenu Info)
        {
            SQLHelper.ExecuteNonQuery("MenuSet", Info.Id, Info.Menu_Field, Info.Menu_List, Info.Model, Info.Model_Field, Info.Model_List);
        }



        /// <summary>
        /// ��ȡ��Ŀģ���ֶ���Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public string GetMenuField(mMenu Info,int MenuId)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetMenuField", MenuId, Info.Temp));
        }

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetMenuIsSub(int Id)
        {
            string temp;
            int c1 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_Menu WHERE [ParentId] = " + Id + "");
            int c2 = (int)SQLHelper.ExecuteScalar("SELECT COUNT(Id) FROM tb_Menu WHERE Sort > (SELECT TOP 1  Sort FROM tb_Menu WHERE Id = " + Id + ") AND ParentId = (SELECT TOP 1 ParentId FROM tb_Menu WHERE Id = " + Id + ")");
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
        /// ������ĿID��ȡģ�ͱ�����
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public string GetMenuTableName(int MenuId)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetMenuTableName", MenuId));
        }

        /// <summary>
        /// ����ID��ȡ��Ŀ����
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public string GetMenuTitle(int MenuId)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetMenuTitle", MenuId));
        }
    }
}
