using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iField
    {
        /// <summary>
        /// ����ֶ�
        /// </summary>
        /// <param name="Info"></param>
        bool FieldInsert(mField Info);

        /// <summary>
        /// �޸��ֶ�
        /// </summary>
        /// <param name="Info"></param>
        bool FieldUpdate(mField Info);

        /// <summary>
        /// ɾ���ֶ�
        /// </summary>
        /// <param name="Info"></param>
        void FieldDel(mField Info);

        /// <summary>
        /// ����ID��ȡ������Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        mField FieldRead(mField Info);

        /// <summary>
        /// ���ݱ�����ȡ�ֶ��б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet FieldList(mField Info);

        /// <summary>
        /// �ƶ��ֶ���ʾλ��
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Action"></param>
        void FieldMove(mField Info, string Action);


        /// <summary>
        /// �����ֶ�ID����ȡ�������ֶ���
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        mField GetTableAndField(mField Info);

        /// <summary>
        /// ����ID��ȡ�ֶεı���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetFiledTitle(int Id);

        /// <summary>
        /// �����ֶ����ͱ�����ȡ�ֶα���
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        string GetFieldTitle(string Field, string Table);

        /// <summary>
        /// �����ֶ����ͱ�����ȡ�ֶ������
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        string GetFieldSort(string Field, string Table);
    }
}
