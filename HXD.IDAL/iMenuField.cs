using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iMenuField
    {
        /// <summary>
        /// ��ȡ
        /// </summary>
        /// <param name="Info"></param>
        DataSet MenuFieldList(mMenuField Info);

        /// <summary>
        /// ����ID��ȡ�ֶεı���
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetMenuFiledTitle(int Id);
    }
}
