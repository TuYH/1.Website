using System;
using System.Collections.Generic;
using System.Text;
using HXD.DALFactory;
using HXD.Model;
using HXD.IDAL;

namespace HXD.BLL
{
    public class bOnlineAdmin
    {
        private static readonly iOnlineAdmin dal = DataAccess.CreateOnlineAdmin();
        
        public void OnlineAdminInsert(mOnlineAdmin Info)
        {
            dal.OnlineAdminInsert(Info);
        }

        public void OnlineAdminUpdate(mOnlineAdmin Info)
        {
            dal.OnlineAdminUpdate(Info);
        }

        public int GetUpdateTimeSpan(mOnlineAdmin Info)
        {
            return dal.GetUpdateTimeSpan(Info);
        }
    }
}
