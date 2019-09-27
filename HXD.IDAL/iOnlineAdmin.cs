using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iOnlineAdmin
    {
        /// <summary>
        /// ����һ������Ա��½��¼
        /// </summary>
        /// <param name="Info"></param>
        void OnlineAdminInsert(mOnlineAdmin Info);

        /// <summary>
        /// �����ѵ�½�û�������ʱ��
        /// </summary>
        /// <param name="Info"></param>
        void OnlineAdminUpdate(mOnlineAdmin Info);

        /// <summary>
        /// ��ȡ��ǰʱ�������ʱ���
        /// </summary>
        /// <returns></returns>
        int GetUpdateTimeSpan(mOnlineAdmin Info);
    }
}
