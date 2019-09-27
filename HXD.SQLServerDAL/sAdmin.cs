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
        /// 添加管理员
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
        /// 修改管理员信息
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
        /// 删除管理员
        /// </summary>
        /// <param name="Info"></param>
        public void AdminDel(mAdmin Info)
        {
            SQLHelper.ExecuteNonQuery("AdminDel", Info.Temp);
        }

        /// <summary>
        /// 根据ID读取单条管理员信息
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
        /// 根据ID更改管理员锁定状态
        /// </summary>
        /// <param name="Info"></param>
        public void AdminLock(mAdmin Info)
        {
            SQLHelper.ExecuteNonQuery("AdminLock", Info.Temp,Info.IsLock);
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        public DataSet AdminList()
        {
            DataSet ds = SQLHelper.ExecuteDataset("AdminList");
            return ds;
        }


        /// <summary>
        /// 管理员后台登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>登陆帐号状态</returns>
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
        /// 获取管理员锁定状态
        /// </summary>
        /// <returns></returns>
        public bool GetAdminLock(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminLock", Info.Id));
        }

        /// <summary>
        /// 获取管理员是否允许修改密码
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool GetAdminEditPwd(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminEditPwd", Info.UserName));
        }

        /// <summary>
        /// 获取管理员是否允许多人同时登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool GetAdminMultiLogin(mAdmin Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetAdminMultiLogin", Info.UserName));
        }

        /// <summary>
        /// 查看管理员用户名是否存在
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
        /// 判断旧密码是否输入正确
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
        /// 管理员修改密码
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
