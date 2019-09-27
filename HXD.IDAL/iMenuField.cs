using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iMenuField
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Info"></param>
        DataSet MenuFieldList(mMenuField Info);

        /// <summary>
        /// 根据ID获取字段的标题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetMenuFiledTitle(int Id);
    }
}
