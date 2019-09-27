using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.Common;
using System.Management;
using System.Diagnostics;

public class LoginCheck
{
    /// <summary>
    /// 后台left和head文件登陆验证
    /// </summary>
    /// <param name="obj"></param>
    public static void AdminManage(object obj)
    {
        adminOsk();
        if (HttpContext.Current.Session["AdminManage"] == null)
        {
            HttpContext.Current.Response.Write("<script>window.parent.location='Logine.aspx'</script>");
            HttpContext.Current.Response.End();
        }
    }

    /// <summary>
    /// 后台操作页面登陆验证
    /// </summary>
    public static void AdminManage()
    {
        adminOsk();
        string path = HXD.Common.GetConfig.System("ManagePath");
        string Url = HttpContext.Current.Request.Url.ToString().Replace("&", "[@]");
        if (HttpContext.Current.Session["AdminManage"] == null)
        {
            HttpContext.Current.Response.Redirect(path + "Logine.aspx?ReturnUrl=" + Url, true);
        }
    }

    /// <summary>
    /// config ID
    /// </summary>
    public static string getadminid()
    {
        string m = "0";
        XmlDoc xml = new XmlDoc();
        xml.xmlfilePath = "~/Config/admin.config";
        DataSet ds = xml.GetDataSet();
        m = ds.Tables[0].Rows[0]["AdminID"].ToString();
        return m;
    }

    /// <summary>
    /// 后台操作页面登陆验证
    /// </summary>
    public static void AdManage()
    {
        adminOsk();
        string path = HXD.Common.GetConfig.System("ManagePath");
        string Url = HttpContext.Current.Request.Url.ToString().Replace("&", "[@]");
        if (HttpContext.Current.Session["AdminManage"] == null)
        {
            HttpContext.Current.Response.Redirect("../Logine.aspx?ReturnUrl=" + Url, true);
        }


    }

    /// <summary>
    /// 后台权限验证
    /// </summary>
    public static void AdManage(int id)
    {
        adminOsk();
        string path = HXD.Common.GetConfig.System("ManagePath");
        string Url = HttpContext.Current.Request.Url.ToString().Replace("&", "[@]");
        if (HttpContext.Current.Session["AdminManage"] == null || HttpContext.Current.Session["userid"] == null)
        {
            HttpContext.Current.Response.Redirect("../Logine.aspx?ReturnUrl=" + Url, true);
        }
        else
        {
            string userid = HttpContext.Current.Session["userid"].ToString();
            string sql_group = "select GroupId from tb_User where id=" + userid;
            int groupid = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_group).ToString());
            if (groupid == id)
            {

            }
            else
            {

                Caches.RemoveCache("Admin_" + HttpContext.Current.Session["AdminManage"].ToString());
                HttpContext.Current.Session.Remove("AdminManage");
                HttpContext.Current.Response.Redirect("../Logine.aspx?ReturnUrl=" + Url, true);
            }
        }

    }

    /// <summary>
    /// 获取学校量表权限
    /// </summary>
    public static string LbManage(int id)
    {
        adminOsk();
        string userid = HttpContext.Current.Session["userid"].ToString();
        //select Classid from tb_User where id=17
        string sql_group = "select Classid from tb_User where id=" + userid;
        int groupid = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_group).ToString());
        string sql_qx = "select UserSetting from tb_U_school where ID=" + groupid;
        string setting = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_qx).ToString();
        return setting;

    }

    /// <summary>
    /// 消息通知
    /// 限制一天只通知一次
    /// </summary>
    public static void Sendmsg(string cd, string id, string msg)
    {
        //cid 1=测评  2=预约  3=辅导 4=消息

        string sql = "insert into tb_U_Message (ClassId,zxs_id,Content,cid)values('" + cd + "','" + id + "','" + msg + "','4')";
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);



    }

    /// <summary>
    /// 授权
    /// </summary>
    /// <param name="obj"></param>
    public static void AdminSq()
    {
        adminOsk();
        ManagementClass mc = new ManagementClass("Win32_Processor");
        ManagementObjectCollection moc = mc.GetInstances();
        string strID = null;
        foreach (ManagementObject mo in moc)
        {
            strID = mo.Properties["ProcessorId"].Value.ToString();
            break;
        }
        string sql = "select Email from tb_Admin where id=1";
        string sqsn = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        /*       if (sqsn == strID)
               {
               }
               else
               {
                   StringDeal.Alter("没授权暂时无法使用！");
               }*/
    }

    public static void adminOsk()
    {
        Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘
        if (kbpr.HasExited)
        {
            kbpr = System.Diagnostics.Process.Start("osk.exe");
        }
    }
}
