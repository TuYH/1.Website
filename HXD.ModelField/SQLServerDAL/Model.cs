using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.ModelField.Model;
using HXD.Common;
using HXD.DBUtility;

namespace HXD.ModelField.SQLServerDAL
{
    public class Model
    {
        /// <summary>
        /// Ϊģ�����������
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        public void ModelInsert(string TableName, string Field, string Value)
        {
            string sql = "INSERT INTO " + TableName + " (" + Field.Trim(',') + ") VALUES (" + Value.Replace("{$split$}", ",").Trim(',') + ")";
            SQLHelper.ExecuteNonQuery("ModelSave", sql);
        }

        /// <summary>
        /// �޸�ģ�����Ѵ��ڵ�����
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        public void ModelUpdate(int Id, string TableName, string Field, string Value)
        {
            string sql = "UPDATE " + TableName + " SET ";
            for (int i = 0; i < Field.Trim(',').Split(',').Length ; i++)
            {
                try
                {
                    sql += Field.Trim(',').Split(',')[i] + "=" + Value.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None)[i] + ",";
                }
                catch { }
            }
            sql=sql.TrimEnd(',');
            sql += " WHERE Id = " + Id + "";
            SQLHelper.ExecuteNonQuery("ModelSave", sql);
        }

        /// <summary>
        /// ���ݱ����Լ�������ȡ��Ҫ���ֶβ������б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList(HXD.ModelField.Model.Model Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("ModelList", Info.TableName, Info.FieldList, Info.Condition, Info.Sort, Info.PageSize, Info.PageIndex);
            return ds;
        }

        /// <summary>
        /// ���ݱ����Լ�������ȡ��Ҫ���ֶβ������б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList2(HXD.ModelField.Model.Model Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("ModelList", Info.TableName, Info.FieldList, Info.Condition, Info.F_leibie, Info.PageSize, Info.PageIndex);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="FieldList">�ֶ��б�</param>
        /// <param name="Condition">��������</param>
        /// <param name="Sort">����ʽ</param>
        /// <param name="ExceptNum">ȥ������</param>
        /// <param name="GetNum">��ȡ����</param>
        /// <returns></returns>
        public DataSet ModelList(string TableName, string FieldList, string Condition, string Sort, int ExceptNum, int GetNum)
        {
            DataSet ds = SQLHelper.ExecuteDataset("TopModelList", TableName, FieldList, Condition, Sort, ExceptNum, GetNum);
            return ds;
        }


        /// <summary>
        /// ��ȡģ���б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelReader(HXD.ModelField.Model.Model Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("ModelReader", Info.Id, Info.TableName);
            return ds;
        }

        /// <summary>
        /// ����IDɾ��ģ���е�����
        /// </summary>
        /// <param name="Info"></param>
        public void ModelDelete(HXD.ModelField.Model.Model Info)
        {
            try
            {
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from " + Info.TableName + " where id in(" + Info.Temp + ")");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                    {
                        if (ds.Tables[0].Rows[i][c].ToString().IndexOf("/") == 0 && ds.Tables[0].Rows[i][c].ToString().Length > 30)
                        {
                            string[] files = ds.Tables[0].Rows[i][c].ToString().Split(',');
                            for (int k = 0; k < files.Length; k++)
                            {
                                if (files[k].IndexOf("/") == 0)
                                {
                                    HXD.Common.Utils.DelThumbnail(files[k]);//ɾ����������ͼ�ļ�
                                    FileOperate.DeleteFile(files[k]);//ɾ��ԭʼ�ļ�
                                }
                            }
                        }
                        if (ds.Tables[0].Rows[i][c].ToString().Length > 30)
                        {
                            FileOperate.GetImgTag(ds.Tables[0].Rows[i][c].ToString());//ɾ�������е�ͼƬ
                            //FileOperate.DelFiles(ds.Tables[0].Rows[i][c].ToString(), "url", "flv");//ɾ�������е�Flv
                        }
                    }
                }
                SQLHelper.ExecuteNonQuery("ModelDelete", Info.Temp, Info.TableName);
            }
            catch { }
        }

        /// <summary>
        /// ����ID����ģ���е��������
        /// </summary>
        /// <param name="Info"></param>
        public void ModelStatus(HXD.ModelField.Model.Model Info)
        {
            SQLHelper.ExecuteNonQuery("ModelStatus", Info.Temp, Info.TableName, Info.IsStatus);
        }

        /// <summary>
        /// ����ID����ģ���е������ö�
        /// </summary>
        /// <param name="Info"></param>
        public void ModelTop(HXD.ModelField.Model.Model Info)
        {
            SQLHelper.ExecuteNonQuery("ModelTop", Info.Temp, Info.TableName, Info.IsTop);
        }

        /// <summary>
        /// ����ID����ģ���е������Ƽ�
        /// </summary>
        /// <param name="Info"></param>
        public void ModelElite(HXD.ModelField.Model.Model Info)
        {
            SQLHelper.ExecuteNonQuery("ModelElite", Info.Temp, Info.TableName, Info.IsElite);
        }

        /// <summary>
        /// ����ID����ģ���е���������
        /// </summary>
        /// <param name="Info"></param>
        public void ModelHot(HXD.ModelField.Model.Model Info)
        {
            SQLHelper.ExecuteNonQuery("ModelHot", Info.Temp, Info.TableName, Info.IsHot);
        }

        /// <summary>
        /// �����޸�
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void ModelSort(int Id,string TableName,int Sort)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@Id",Id),
                new SqlParameter("@TableName",TableName),
                new SqlParameter("@Sort",Sort)
            };
            SQLHelper.ExecuteNonQuery("ModelSort",par);
        }

        /// <summary>
        /// �����޸�2
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void Modelleibie(int Id, string TableName, int Sort)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@Id",Id),
                new SqlParameter("@TableName",TableName),
                new SqlParameter("@f_leibie",Sort)
            };
            SQLHelper.ExecuteNonQuery("ModelSort", par);
        }
    }
}
