using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bSetType
    {
        private static readonly iSetType dal = DataAccess.CreateSetType();
        public DataSet GetSetTypeList(mSetType Info)
        {
            return dal.GetSetTypeList(Info);
        }
        public IList<mSetType> GetSetTypeRead(mSetType Info)
        {
            return dal.GetSetTypeRead(Info);
        }
    }
}
