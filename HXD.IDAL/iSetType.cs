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
        /// 获取所取类型列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet GetSetTypeList(mSetType Info);

        /// <summary>
        /// 根据ID获取某条类型的值
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mSetType> GetSetTypeRead(mSetType Info);
        #endregion
    }
}
