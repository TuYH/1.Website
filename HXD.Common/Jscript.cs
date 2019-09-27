using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HXD.Common
{
    public class Jscript
    {
        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        public static void RedirectTo(string url)
        {
            HttpContext.Current.Response.Write("<script>window.top.location.href='" + url + "'</script>");
        }

        /// <summary>
        /// 服务器端弹出alert对话框
        /// </summary>
        /// <param name="str_Message">提示信息,例子："请输入您姓名!"</param>
        /// <param name="page">Page类</param>
        public static void Alert(string str_Message, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + str_Message + "');</script>");
        }

        /// <summary>
        /// 系统自定义提示
        /// </summary>
        public static void DamicAlert()
        {
            Jscript.AlertAndRedirectJstr("您访问的数据不存在!", "window.history.go(-1);");
        }

        /// <summary>
        /// 没有数据或错误
        /// </summary>
        public static void NoDateOrError()
        {
            Jscript.RedirectTo((HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath) + "/wr.html");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 自己插入脚本
        /// </summary>
        /// <param name="str_Message">提示信息</param>
        /// <param name="url">脚本设置</param>
        public static void AlertAndRedirectJstr(string str_Message, string strjs)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str_Message + "');" + strjs + "</script>");

        }

        /// <summary>
        /// 权限跳转页面
        /// </summary>
        /// <param name="str_Message">提示信息</param>
        /// <param name="url">跳转页面</param>
        public static void PopedomRedirect(string str_Message, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str_Message + "');window.top.location.href='" + url + "'</script>");
        }

        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message)
        {
            string js = "<Script language='JavaScript'>alert('" + message + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            string js = "<Script language='JavaScript'>history.go({0});</Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = "<Script language='JavaScript'>parent.opener=null;window.close();</Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent(string url)
        {
            string js = "<Script language='JavaScript'>window.location.href='" + url + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string js = "<Script language='JavaScript'>opener.location.reload();</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            string js = "<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 打开新窗体
        /// </summary>    
        public static void OpenWebFormSize(string mess, string url)
        {
            string js = "<Script language='JavaScript'>alert('" + mess + "'); window.open('" + url + @"');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            string js = "<Script language='JavaScript'>window.location.replace('{0}');</Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = "<script language=javascript>showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }

        //    /// <summary>
        //    /// 弹出JavaScript小窗口
        //    /// </summary>
        //    /// <param name="js">窗口信息</param>
        //    public static void Alert(string message)
        //    {
        //        string js = "<Script language='JavaScript'>alert('" + message + "');</Script>";HttpContext.Current.Response.Write(js);
        //    }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirectTOP(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.parent.top.location.href='{1}'</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }

        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebForm(string url, Page page)
        {
            string js = "<Script language='JavaScript'>window.open('" + url + @"','','location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", js);
        }
    }
}
