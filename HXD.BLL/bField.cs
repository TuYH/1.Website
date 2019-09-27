using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bField
    {
        private static readonly iField dal = DataAccess.CreateField();

        public bool FieldInsert(mField Info)
        {
            return dal.FieldInsert(Info);
        }
        public bool FieldUpdate(mField Info)
        {
            return dal.FieldUpdate(Info);
        }
        public void FieldDel(mField Info)
        {
            dal.FieldDel(Info);
        }
        public mField FieldRead(mField Info)
        {
            return dal.FieldRead(Info);
        }
        public DataSet FieldList(mField Info)
        {
            return dal.FieldList(Info);
        }
        public void FieldMove(mField Info, string Action)
        {
            dal.FieldMove(Info, Action);
        }



        public mField GetTableAndField(mField Info)
        {
            return dal.GetTableAndField(Info);
        }
        public string GetFiledTitle(int Id)
        {
            return dal.GetFiledTitle(Id);
        }
        public string GetFieldTitle(string Field, string Table)
        {
            return dal.GetFieldTitle(Field, Table);
        }

        public string GetFieldSort(string Field, string Table)
        {
            return dal.GetFieldSort(Field, Table);
        }
    }
}
