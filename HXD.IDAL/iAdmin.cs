using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iAdmin
    {
        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="Info"></param>
        void AdminInsert(mAdmin Info);

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        void AdminUpdate(mAdmin Info);

        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="Info"></param>
        void AdminDel(mAdmin Info);

        /// <summary>
        /// ����ID��ȡ��������Ա��Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mAdmin> AdminReader(mAdmin Info);

        /// <summary>
        /// ����ID���Ĺ���Ա����״̬
        /// </summary>
        /// <param name="Info"></param>
        void AdminLock(mAdmin Info);

        /// <summary>
        /// ��ȡ����Ա�б�
        /// </summary>
        /// <returns></returns>
        DataSet AdminList();

        /// <summary>
        /// ����Ա��̨��½
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mAdmin> AdminLogin(mAdmin Info);

        /// <summary>
        /// ��ȡ����Ա����״̬
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminLock(mAdmin Info);

        /// <summary>
        /// ��ȡ����Ա�Ƿ������޸�����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminEditPwd(mAdmin Info);

        /// <summary>
        /// ��ȡ����Ա�Ƿ��������ͬʱ��½
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminMultiLogin(mAdmin Info);

        /// <summary>
        /// �鿴����Ա�û����Ƿ����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsAdminUserName(mAdmin Info);

        /// <summary>
        /// �жϾ������Ƿ�������ȷ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsOldPwd(mAdmin Info);

        /// <summary>
        /// ����Ա�޸�����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool AdminPwdEdit(mAdmin Info);
    }
}
