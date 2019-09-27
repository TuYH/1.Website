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
    public class sTable : iTable
    {
        /// <summary>
        /// 添加模型表
        /// </summary>
        /// <param name="Info"></param>
        public void TableInsert(mTable Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@TableName",Info.TableName),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Type",Info.Type)
            };
            SQLHelper.ExecuteNonQuery("TableInsert", par);
        }

        /// <summary>
        /// 修改模型表
        /// </summary>
        /// <param name="Info"></param>
        public void TableUpdate(mTable Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@Note",Info.Note)
            };
            SQLHelper.ExecuteNonQuery("TableEdit", par);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="Info"></param>
        public void TableDel(mTable Info)
        {
            SQLHelper.ExecuteNonQuery("TableDel", Info.Id);
        }

        /// <summary>
        /// 根据ID获取单条模型信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public mTable TableRead(mTable Info)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader("TableRead", Info.Id))
            {
                if (dr.Read())
                {
                    Info.Title = dr[0].ToString();
                    Info.TableName = dr[1].ToString();
                    Info.Note = dr[2].ToString();
                    Info.Type = StringDeal.ToInt(dr[3]);
                }
            }
            return Info;
        }

        /// <summary>
        /// 读取模型列表
        /// </summary>
        /// <returns></returns>
        public DataSet TableList()
        {
            DataSet ds = SQLHelper.ExecuteDataset("TableList");
            return ds;
        }


        /// <summary>
        /// 判断数据库中是否存在某表名
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool IsTable(mTable Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("IsExistTable",Info.TableName));
        }

        /// <summary>
        /// 根据模型表ID获取表名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetTableName(int Id)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetTableName",Id));
        }

        /// <summary>
        /// 获取模型是否为系统模型
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool GetIsSystem(mTable Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetTableIsSystem", Info.Id));
        }
    }
}
