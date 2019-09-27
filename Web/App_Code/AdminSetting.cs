using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HXD.Model;
using HXD.BLL;
using HXD.Common;

/// <summary>
///管理员组操作权限判断
/// </summary>
public class AdminSetting
{
    /// <summary>
    /// 判断是否有权限
    /// </summary>
    public static void isPermissions(string ClassID, string OtherSetting)
    {
        string str1 = "select GroupId from tb_Admin where UserName='" + HttpContext.Current.Session["AdminManage"] + "'";
        string str = "select GroupSetting,OtherSetting from tb_AdminGroup where id=(" + str1 + ");";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(str);
        string GroupSettingStr = "";
        string OtherSettingStr = "";
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                GroupSettingStr = ds.Tables[0].Rows[0][0].ToString();
                OtherSettingStr = ds.Tables[0].Rows[0][1].ToString();
                string[] GroupSettingS = GroupSettingStr.Split(',');
                string[] OtherSettingS = OtherSettingStr.Split(',');
                bool bool1 = true, bool2 = false;
                for (int i = 0; i < GroupSettingS.Length; i++)
                {
                    if (GroupSettingS[i] == ClassID)
                    {
                        bool1 = false;
                        if (!bool1 && OtherSettingS[i].IndexOf(OtherSetting) == -1)
                        {
                            bool2 = true;
                            break;
                        }
                        break;
                    }
                }
                if (bool1)
                {
                    HttpContext.Current.Response.Clear();
                    HXD.Common.Jscript.Alert("权限不足！");
                    HttpContext.Current.Response.End();
                }
                if (bool2)
                {
                    HttpContext.Current.Response.Clear();
                    HXD.Common.Jscript.Alert("没有操作权限！");
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}
