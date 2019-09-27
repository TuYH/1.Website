using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iMenu
    {
        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="Info"></param>
        void MenuInsert(int ParentId,string Field, string Value);
       
        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="Info"></param>
        void MenuInsert2(int ParentId, int MenuId, int MenuId2, string Field, string Value);
        /// <summary>
        /// �����Ŀ(���� @@Identity)
        /// </summary>
        /// <param name="Info"></param>
        int MenuInsert1(int ParentId, string Field, string Value);

        /// <summary>
        /// �޸���Ŀ
        /// </summary>
        /// <param name="Info"></param>
        void MenuUpdate(int Id, int ParentId,string Field, string Value);
        /// <summary>
        /// �޸���Ŀ
        /// </summary>
        /// <param name="Info"></param>
        void MenuUpdate1(int Id, int ParentId, int MenuId,int MenuId2, string Field, string Value);

        /// <summary>
        /// ɾ����Ŀ
        /// </summary>
        /// <param name="Info"></param>
        int MenuDel(mMenu Info);

        /// <summary>
        /// ��Ŀ�б�DATASET
        /// </summary>
        /// <returns></returns>
        DataSet MenuList();

        /// <summary>
        /// ��Ŀ�б�DATASET
        /// </summary>
        /// <returns></returns>
        DataSet MenuList(int ParentId);

        /// <summary>
        /// ��ȡ��Ŀ������Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet MenuReader(mMenu Info);

        /// <summary>
        /// ��ȡ��Ŀ������Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet MenuReader(int Id);

        /// <summary>
        /// ��Ŀ����/����
        /// </summary>
        /// <param name="Info"></param>
        void MenuLock(mMenu Info);

        /// <summary>
        /// ��Ŀ�ö�
        /// </summary>
        /// <param name="Info"></param>
        void MenuTop(mMenu Info);

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <param name="Info"></param>
        void MenuMove(mMenu Info, string Action);

        /// <summary>
        /// ������Ŀģ���Լ���Ϣģ�͵��ֶ�
        /// </summary>
        /// <param name="Info"></param>
        void MenuSet(mMenu Info);



        /// <summary>
        /// ��ȡ��Ŀģ���ֶ���Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetMenuField(mMenu Info, int MenuId);

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetMenuIsSub(int Id);

        /// <summary>
        /// ������ĿID��ȡģ�ͱ�����
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        string GetMenuTableName(int MenuId);

        /// <summary>
        /// ����ID��ȡ��Ŀ����
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        string GetMenuTitle(int MenuId);

    }
}
