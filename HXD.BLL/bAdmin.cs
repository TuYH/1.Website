using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bAdmin
    {
        private static readonly iAdmin dal = DataAccess.CreateAdmin();

        public void AdminInsert(mAdmin Info)
        {
            dal.AdminInsert(Info);
        }

        public void AdminUpdate(mAdmin Info)
        {
            dal.AdminUpdate(Info);
        }

        public void AdminDel(mAdmin Info)
        {
            dal.AdminDel(Info);
        }

        public IList<mAdmin> AdminReader(mAdmin Info)
        {
            return dal.AdminReader(Info);
        }

        public void AdminLock(mAdmin Info)
        {
            dal.AdminLock(Info);
        }

        public DataSet AdminList()
        {
            return dal.AdminList();
        }

        public IList<mAdmin> AdminLogin(mAdmin Info)
        {
            IList<mAdmin> list = dal.AdminLogin(Info);
            return list;
        }

        public bool GetAdminLock(mAdmin Info)
        {
            return dal.GetAdminLock(Info);
        }

        public bool GetAdminEditPwd(mAdmin Info)
        {
            return dal.GetAdminEditPwd(Info);
        }

        public bool GetAdminMultiLogin(mAdmin Info)
        {
            return dal.GetAdminMultiLogin(Info);
        }

        public bool IsAdminUserName(mAdmin Info)
        {
            return dal.IsAdminUserName(Info);
        }

        public bool IsOldPwd(mAdmin Info)
        {
            return dal.IsOldPwd(Info);
        }

        public bool AdminPwdEdit(mAdmin Info)
        {
            return dal.AdminPwdEdit(Info);
        }
    }
}
