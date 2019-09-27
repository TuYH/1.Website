using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bAdminGroup
    {
        private static readonly iAdminGroup dal = DataAccess.CreateAdminGroup();

        public void AdminGroupInsert(mAdminGroup Info)
        {
            dal.AdminGroupInsert(Info);
        }

        public int AdminGroupUpdate(mAdminGroup Info)
        {
            return dal.AdminGroupUpdate(Info);
        }

        public void AdminGroupDel(mAdminGroup Info)
        {
            dal.AdminGroupDel(Info);
        }

        public IList<mAdminGroup> AdminGroupReader(mAdminGroup Info)
        {
            return dal.AdminGroupReader(Info);
        }

        public DataSet AdminGroupList(mAdminGroup Info)
        {
            return dal.AdminGroupList(Info);
        }

        public void AdminGroupLock(mAdminGroup Info)
        {
            dal.AdminGroupLock(Info);
        }

        public string GetAdminGroupIsSub(int Id)
        {
            return dal.GetAdminGroupIsSub(Id);
        }
    }
}
