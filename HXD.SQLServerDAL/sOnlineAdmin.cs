using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using HXD.DBUtility;
using HXD.Model;
using HXD.IDAL;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    public class sOnlineAdmin : iOnlineAdmin
    {
        /// <summary>
        /// ����һ������Ա��½��¼
        /// </summary>
        /// <param name="Info"></param>
        public void OnlineAdminInsert(mOnlineAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@SessionId",Info.SessionId),
                new SqlParameter("@UpdateTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            SQLHelper.ExecuteNonQuery("OnlineAdminInsert", par);
        }

        /// <summary>
        /// �����ѵ�½�û�������ʱ��
        /// </summary>
        /// <param name="Info"></param>
        public void OnlineAdminUpdate(mOnlineAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@SessionId",Info.SessionId),
                new SqlParameter("@UpdateTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            SQLHelper.ExecuteNonQuery("OnlineAdminUpdate", par);
        }

        /// <summary>
        /// ��ȡ��ǰʱ�������ʱ���
        /// </summary>
        /// <returns></returns>
        public int GetUpdateTimeSpan(mOnlineAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@UpdateTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return (int)SQLHelper.ExecuteScalar("GetUpdateTimeSpan", par);
        }


    }
}
