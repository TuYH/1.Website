using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iChannel
    {
        #region
        /// <summary>
        /// ��Ӻ�̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        void ChannelInsert(mChannel Info);

        /// <summary>
        /// �޸ĺ�̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        int ChannelUpdate(mChannel Info);

        /// <summary>
        /// ɾ����̨Ƶ��
        /// </summary>
        /// <param name="Info"></param>
        string ChannelDel(int Id);

        /// <summary>
        /// ��ȡ����Ƶ����Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mChannel> ChannelRead(mChannel Info);

        /// <summary>
        /// ��ȡƵ���б�DATASET
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        DataSet ChannelList(int ParentId);

        /// <summary>
        /// Ƶ���ر�/����
        /// </summary>
        /// <param name="Info"></param>
        void ChannelLock(int Id);

        /// <summary>
        /// Ƶ������
        /// </summary>
        /// <param name="Info"></param>
        void ChannelMove(int Id,string Action);
        #endregion

        #region 
        /// <summary>
        /// ����ID��ȡ��Ŀ����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetChannelTitle(int Id);

        /// <summary>
        /// ��̨��ඥ���˵�
        /// </summary>
        /// <returns></returns>
        IList<DataSet> GetChannelMenu(int ParentId, string UserName);

        /// <summary>
        /// ��ȡ��̨���Ƶ���Ӽ���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int GetChannelSubCount(int Id);

        /// <summary>
        /// ��ȡ��̨���Ƶ����һ����ĿID
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        int GetChannelFirstParentId(string UserName);

        /// <summary>
        /// ��ȡ�б�ǰ��ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetChannelIsSub(int Id);

        #endregion
    }
}
