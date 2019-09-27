using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using HXD.DBUtility;
using HXD.Model;
using HXD.IDAL;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    public class sSetType : iSetType
    {
        /// <summary>
        /// ��ȡ��ȡ�����б�
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet GetSetTypeList(mSetType Info)
        {
            DataSet ds = SQLHelper.ExecuteDataset("SetTypeList", Info.ParentId);
            return ds;
        }

        /// <summary>
        /// ����ID��ȡĳ�����͵�ֵ
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mSetType> GetSetTypeRead(mSetType Info)
        {
            IList<mSetType> list = new List<mSetType>();
            if (Info.Id > 0)
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader("SetTypeRead", Info.Id))
                {
                    if (dr.Read())
                    {
                        mSetType mST = new mSetType();
                        mST.Id = (int)dr[0];
                        mST.Title = dr[1].ToString();
                        mST.Value = dr[2].ToString();
                        list.Add(mST);
                    }
                }
            }
            return list;
        }
    }
}
