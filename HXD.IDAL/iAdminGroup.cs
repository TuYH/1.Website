using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iAdminGroup
    {
        #region
        /// <summary>
        /// ��ӹ���Ա��
        /// </summary>
        /// <param name="Info"></param>
        void AdminGroupInsert(mAdminGroup Info);

        /// <summary>
        /// �޸Ĺ���Ա��
        /// </summary>
        /// <param name="Info"></param>
        int AdminGroupUpdate(mAdminGroup Info);

        /// <summary>
        /// ����Idɾ������Ա��
        /// </summary>
        /// <param name="Id"></param>
        void AdminGroupDel(mAdminGroup Info);

        /// <summary>
        /// ����Id��ȡ����Ա�鵥����Ϣ
        /// </summary>
        /// <param name="Id"></param>
        IList<mAdminGroup> AdminGroupReader(mAdminGroup Info);

        /// <summary>
        /// ���ݸ���ID��ȡDataSet
        /// </summary>
        /// <param name="ParentId"></param>
        DataSet AdminGroupList(mAdminGroup Info);

        /// <summary>
        /// ����ID����/�������Ա��
        /// </summary>
        /// <param name="Info"></param>
        void AdminGroupLock(mAdminGroup Info);

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetAdminGroupIsSub(int Id);
        #endregion
    }
}
