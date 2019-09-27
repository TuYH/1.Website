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
    public class sAdmin : iAdmin
    {
        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="Info"></param>
        public void AdminInsert(mAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@GroupId",Info.GroupId),
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@UserPwd",Info.UserPwd),
                new SqlParameter("@TrueName",Info.TrueName),
                new SqlParameter("@Tel",Info.Tel),
                new SqlParameter("@Email",Info.Email),
                new SqlParameter("@IsModifyPassword",Info.IsModifyPassword),
                new SqlParameter("@IsMultiLogin",Info.IsMultiLogin)
            };
            SQLHelper.ExecuteNonQuery("AdminInsert", par);
        }

        /// <summary>
        /// �޸Ĺ���Ա��Ϣ
        /// </summary>
        /// <param name="Info"></param>
        public void AdminUpdate(mAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@GroupId",Info.GroupId),
                new SqlParameter("@UserPwd",Info.UserPwd),
                new SqlParameter("@TrueName",Info.TrueName),
                new SqlParameter("@Tel",Info.Tel),
                new SqlParameter("@Email",Info.Email),
                new SqlParameter("@IsModifyPassword",Info.IsModifyPassword),
                new SqlParameter("@IsMultiLogin",Info.IsMultiLogin)
            };
            SQLHelper.ExecuteNonQuery("AdminEdit", par);
        }

        /// <summary>
        /// ɾ������Ա
        /// </summary>
        /// <param name="Info"></param>
        public void AdminDel(mAdmin Info)
        {
            SQLHelper.ExecuteNonQuery("AdminDel", Info.Temp);
        }

        /// <summary>
        /// ����ID��ȡ��������Ա��Ϣ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mAdmin> AdminReader(mAdmin Info)
        {
            IList<mAdmin> list = new List<mAdmin>();
            using (SqlDataReader dr = SQLHelper.ExecuteReader("AdminRead", Info.Id))
            {
                if (dr.Read())
                {
                    mAdmin mA = new mAdmin();
                    mA.GroupId = StringDeal.ToInt(dr[0]);
                    mA.UserName = dr[1].ToString();
                    mA.UserPwd = dr[2].ToString();
                    mA.TrueName = dr[3].ToString();
                    mA.Tel = dr[4].ToString();
                    mA.Email = dr[5].ToString();
                    mA.IsModifyPassword = StringDeal.ToBool(dr[6]);
                    mA.IsMultiLogin = StringDeal.ToBool(dr[7]);
                    list.Add(mA);
                }
            }
            return list;
        }

        /// <summary>
        /// ����ID���Ĺ���Ա����״̬
        /// </summary>
        /// <param name="Info"></param>
        public void AdminLock(mAdmin Info)
        {
            SQLHelper.ExecuteNonQuery("AdminLock", Info.Temp,Info.IsLock);
        }

        /// <summary>
        /// ��ȡ����Ա�б�
        /// </summary>
        /// <returns></returns>
        public DataSet AdminList()
        {
            DataSet ds = SQLHelper.ExecuteDataset("AdminList");
            return ds;
        }


        /// <summary>
        /// ����Ա��̨��½
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>��½�ʺ�״̬</returns>
        public IList<mAdmin> AdminLogin(mAdmin Info)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@UserPwd",Info.UserPwd),
                new SqlParameter("@UserIp",Info.LastLoginIp)
            };
            IList<mAdmin> list = new List<mAdmin>();
            mAdmin m = new mAdmin();
            m.Temp = SQLHelper.ExecuteScalar("AdminLogin", par).ToString();
            list.Add(m);
            return list;
        }

        /// <summary>
        /// ��ȡ����Ա����״̬
        /// </summary>
        /// <returns></returns>
        public bool GetAdminLock(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminLock", Info.Id));
        }

        /// <summary>
        /// ��ȡ����Ա�Ƿ������޸�����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool GetAdminEditPwd(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminEditPwd", Info.UserName));
        }

        /// <summary>
        /// ��ȡ����Ա�Ƿ��������ͬʱ��½
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool GetAdminMultiLogin(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminMultiLogin", Info.UserName));
        }

        /// <summary>
        /// �鿴����Ա�û����Ƿ����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool IsAdminUserName(mAdmin Info)
        {
            if(StringDeal.ToInt(SQLHelper.ExecuteScalar("IsAdminUserName",Info.UserName))>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �жϾ������Ƿ�������ȷ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool IsOldPwd(mAdmin Info)
        {
            if (StringDeal.ToInt(SQLHelper.ExecuteScalar("IsAdminOldPwd", Info.UserName,Info.UserPwd)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ����Ա�޸�����
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool AdminPwdEdit(mAdmin Info)
        {
            if (StringDeal.ToInt(SQLHelper.ExecuteScalar("AdminPwdEdit", Info.UserName, Info.UserPwd)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
