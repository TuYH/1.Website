using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iSetType
    {
        #region
        /// <summary>
        /// ��ȡ��ȡ�����б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet GetSetTypeList(mSetType Info);

        /// <summary>
        /// ����ID��ȡĳ�����͵�ֵ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mSetType> GetSetTypeRead(mSetType Info);
        #endregion
    }
}
