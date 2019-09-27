using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bMenuField
    {
        private static readonly iMenuField dal = DataAccess.CreateMenuField();

        public DataSet MenuFieldList(mMenuField Info)
        {
            return dal.MenuFieldList(Info);
        }

        public string GetMenuFiledTitle(int Id)
        {
            return dal.GetMenuFiledTitle(Id);
        }
    }
}
