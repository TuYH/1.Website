using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.ModelField.Common;

namespace HXD.ModelField.BLL
{
    public class Model
    {
        private readonly HXD.ModelField.SQLServerDAL.Model dal = new HXD.ModelField.SQLServerDAL.Model();

        /// <summary>
        /// Ϊģ�����������
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        public void ModelInsert(string TableName, string Field, string Value)
        {
            dal.ModelInsert(TableName, Field, Value);
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
            dal.ModelUpdate(Id, TableName, Field, Value);
        }
        /// <summary>
        /// ���ݱ�����Ҫ��ȡ���ֶ���ϣ���ȡ�˱����Ϣ�б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelList(Info);
        }

        /// <summary>
        /// ���ݱ�����Ҫ��ȡ���ֶ���ϣ���ȡ�˱����Ϣ�б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList2(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelList2(Info);
        }

        /// <summary>
        /// ��ȡǰ��������
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
            return dal.ModelList(TableName, FieldList, Condition, Sort, ExceptNum, GetNum);
        }

        /// <summary>
        /// ��ȡǰ��������
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="FieldList">�ֶ��б�</param>
        /// <param name="Condition">��������</param>
        /// <param name="Sort">����ʽ</param>
        /// <param name="ExceptNum">ȥ������</param>
        /// <param name="GetNum">��ȡ����</param>
        /// <returns></returns>
        public DataSet ModelList(string TableName, string Condition, string Sort, int GetNum)
        {
            return dal.ModelList(TableName, " * ", Condition, Sort, 0, GetNum);
        }

        /// <summary>
        /// ��ȡģ���б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelReader(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelReader(Info);
        }
        /// <summary>
        /// ����IDɾ��ģ���е�����
        /// </summary>
        /// <param name="Info"></param>
        public void ModelDelete(HXD.ModelField.Model.Model Info)
        {
            dal.ModelDelete(Info);
        }
        /// <summary>
        /// ����ID����ģ���е��������
        /// </summary>
        /// <param name="Info"></param>
        public void ModelStatus(HXD.ModelField.Model.Model Info)
        {
            dal.ModelStatus(Info);
        }
        /// <summary>
        /// ����ID����ģ���е������ö�
        /// </summary>
        /// <param name="Info"></param>
        public void ModelTop(HXD.ModelField.Model.Model Info)
        {
            dal.ModelTop(Info);
        }
        /// <summary>
        /// ����ID����ģ���е������Ƽ�
        /// </summary>
        /// <param name="Info"></param>
        public void ModelElite(HXD.ModelField.Model.Model Info)
        {
            dal.ModelElite(Info);
        }
        /// <summary>
        /// ����ID����ģ���е���������
        /// </summary>
        /// <param name="Info"></param>
        public void ModelHot(HXD.ModelField.Model.Model Info)
        {
            dal.ModelHot(Info);
        }
        /// <summary>
        /// �����޸�
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void ModelSort(int Id, string TableName, int Sort)
        {
            dal.ModelSort(Id, TableName, Sort);
        }
        /// <summary>
        /// ��ҳ��Ʒ�����޸�
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void Modelleibie(int Id, string TableName, int Sort)
        {
            dal.Modelleibie(Id, TableName, Sort);
        }
    }
}
