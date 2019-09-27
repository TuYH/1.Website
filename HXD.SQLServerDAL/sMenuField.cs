using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.DBUtility;
using HXD.Model;
using HXD.IDAL;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    public class sMenuField : iMenuField
    {
        /// <summary>
        /// 获取栏目模型的字段列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuFieldList(mMenuField Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("MenuFieldList", Info.Temp);
            return ds;
        }


        /// <summary>
        /// 根据ID获取字段的标题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetMenuFiledTitle(int Id)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetMenuFieldTitle", Id));
        }
    }
}
