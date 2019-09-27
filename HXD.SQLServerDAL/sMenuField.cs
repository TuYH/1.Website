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
        /// ��ȡ��Ŀģ�͵��ֶ��б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet MenuFieldList(mMenuField Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("MenuFieldList", Info.Temp);
            return ds;
        }


        /// <summary>
        /// ����ID��ȡ�ֶεı���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetMenuFiledTitle(int Id)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetMenuFieldTitle", Id));
        }
    }
}
