using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bChannel
    {
        private static readonly iChannel dal = DataAccess.CreateChannel();

        public void ChannelInsert(mChannel Info)
        {
            dal.ChannelInsert(Info);
        }

        public int ChannelUpdate(mChannel Info)
        {
            return dal.ChannelUpdate(Info);
        }

        public string ChannelDel(int Id)
        {
            return dal.ChannelDel(Id);
        }

        public IList<mChannel> ChannelRead(mChannel Info)
        {
            return dal.ChannelRead(Info);
        }

        public DataSet ChannelList(int ParentId)
        {
            return dal.ChannelList(ParentId);
        }

        public void ChannelLock(int Id)
        {
            dal.ChannelLock(Id);
        }

        public void ChannelMove(int Id, string Action)
        {
            dal.ChannelMove(Id,Action);
        }

        public string GetChannelTitle(int Id)
        {
            return dal.GetChannelTitle(Id);
        }

        public IList<DataSet> GetChannelMenu(int ParentId, string UserName)
        {
            IList<DataSet> list = dal.GetChannelMenu(ParentId, UserName);
            return list;
        }

        public int GetChannelSubCount(int Id)
        {
            return dal.GetChannelSubCount(Id);
        }

        public int GetChannelFirstParentId(string UserName)
        {
            return dal.GetChannelFirstParentId(UserName);
        }

        public string GetChannelIsSub(int Id)
        {
            return dal.GetChannelIsSub(Id);
        }
    }
}
