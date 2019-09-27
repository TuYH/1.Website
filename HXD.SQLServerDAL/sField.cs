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
    public class sField : iField
    {
        /// <summary>
        /// 添加字段
        /// </summary>
        /// <param name="Info"></param>
        public bool FieldInsert(mField Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@TableName",Info.TableName),
                new SqlParameter("@Field",Info.Field),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Prompt",Info.Prompt),
                new SqlParameter("@Type",Info.Type)
            };
            return StringDeal.ToBool(SQLHelper.ExecuteNonQuery("FieldInsert", par));
        }

        /// <summary>
        /// 修改字段
        /// </summary>
        /// <param name="Info"></param>
        public bool FieldUpdate(mField Info)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@TableName",Info.TableName),
                new SqlParameter("@Field",Info.Field),
                new SqlParameter("@Title",Info.Title),
                new SqlParameter("@Note",Info.Note),
                new SqlParameter("@Prompt",Info.Prompt),
                new SqlParameter("@Type",Info.Type)
            };
            return StringDeal.ToBool(SQLHelper.ExecuteNonQuery("FieldEdit", par));
        }

        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="Info"></param>
        public void FieldDel(mField Info)
        {
            SQLHelper.ExecuteNonQuery("FieldDel", Info.Id);
        }

        /// <summary>
        /// 根据ID读取单条信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public mField FieldRead(mField Info)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader("FieldRead", Info.Id))
            {
                if (dr.Read())
                {
                    Info.TableName = dr[0].ToString();
                    Info.Field = dr[1].ToString();
                    Info.Title = dr[2].ToString();
                    Info.Note = dr[3].ToString();
                    Info.Prompt = dr[4].ToString();
                    Info.Type = dr[5].ToString();
                    Info.Sort = (int)dr[6];
                }
            }
            return Info;
        }

        /// <summary>
        /// 根据表名读取字段列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet FieldList(mField Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("FieldList",Info.TableName);
            return ds;
        }

        /// <summary>
        /// 移动字段显示位置
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Action"></param>
        public void FieldMove(mField Info, string Action)
        {
            SQLHelper.ExecuteNonQuery("FieldMove", Info.Id, Action);
        }



        /// <summary>
        /// 根据字段ID，获取表名和字段名
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public mField GetTableAndField(mField Info)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader("GetTableAndField", Info.Id))
            {
                if (dr.Read())
                {
                    Info.TableName = dr[0].ToString();
                    Info.Field = dr[1].ToString();
                }
            }
            return Info;
        }

        /// <summary>
        /// 根据ID获取字段的标题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetFiledTitle(int Id)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetFieldTitle", Id,"",""));
        }

        /// <summary>
        /// 根据字段名和表明获取字段标题
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        public string GetFieldTitle(string Field, string Table)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetFieldTitle", 0, Field, Table));
        }

        /// <summary>
        /// 根据字段名和表明获取字段排序号
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        public string GetFieldSort(string Field, string Table)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetFieldSort", 0, Field, Table));
        }
    }
}
