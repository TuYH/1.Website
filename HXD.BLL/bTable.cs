using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bTable
    {
        private static readonly iTable dal = DataAccess.CreateTable();

        public void TableInsert(mTable Info)
        {
            dal.TableInsert(Info);
        }
        public void TableUpdate(mTable Info)
        {
            dal.TableUpdate(Info);
        }
        public void TableDel(mTable Info)
        {
            dal.TableDel(Info);
        }
        public mTable TableRead(mTable Info)
        {
            return dal.TableRead(Info);
        }
        public DataSet TableList()
        {
            return dal.TableList();
        }


        public bool IsTable(mTable Info)
        {
            return dal.IsTable(Info);
        }
        public string GetTableName(int Id)
        {
            return dal.GetTableName(Id);
        }
        public bool GetIsSystem(mTable Info)
        {
            return dal.GetIsSystem(Info);
        }
    }
}
