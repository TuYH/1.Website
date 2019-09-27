using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HXD.Common
{
    public class DataManage
    {

        /// <summary>
        /// 判断DataSet中是否含有数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool DataSetIsNull(DataSet ds)
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }


    }
}
