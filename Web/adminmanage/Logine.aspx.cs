using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using HXD.Model;
using HXD.BLL;
using HXD.Common;

public partial class adminmanage_Logine : System.Web.UI.Page
{
    protected string Msg;
    protected string yinc;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (IsPostBack)
        {
            mAdmin m = new mAdmin();
            m.UserName = this.tUserName.Text;
            m.UserPwd = Encryp.DESEncrypt(this.tUserPwd.Text);
            m.LastLoginIp = Request.UserHostAddress.ToString();
            string Code = this.tCode.Text;
            if (hidden1.Value == "1")
            {
                Code = Session["SGQ_WebValidate"].ToString().ToLower();
            }
            if (Session["SGQ_WebValidate"] == null)
            {
                Msg = "验证码过期,请重试!";
            }
            else if (Session["SGQ_WebValidate"].ToString().ToLower() != Code.ToLower())
            {
                Msg = "验证码输入错误,请重试!";
            }
            else
            {
                bAdmin b = new bAdmin();
                IList<mAdmin> list = b.AdminLogin(m);
                string state = list[0].Temp;
                if (state == "0")
                {
                    Msg = "密码输入有误!";
                }
                else if (state == "1")
                {
                    Msg = "密码输入有误!";
                }
                else if (state == "2")
                {
                    Msg = "帐号被锁定!";
                }
                else
                {
                    mOnlineAdmin mOA = new mOnlineAdmin();
                    bOnlineAdmin bOA = new bOnlineAdmin();
                    mOA.UserName = m.UserName;
                    mOA.SessionId = Session.SessionID;
                    if (Caches.GetCache("Admin_" + m.UserName) == null || b.GetAdminMultiLogin(m) || bOA.GetUpdateTimeSpan(mOA) > 10)
                    {
                        Caches.SetCache("Admin_" + m.UserName, "manage");
                        Session["AdminManage"] = m.UserName;
                        bOA.OnlineAdminInsert(mOA);
                        Response.Redirect("Default.aspx", true);
                    }
                    else
                    {
                        StringDeal.Alter("此管理帐号处于登陆状态，不允许多人同时登陆!");
                    }
                }
            }
        }
        else
        {
            this.tUserName.Text = "admin";
            this.tUserPwd.Attributes.Add("value", "admin");
            if (Systemlogin("IsManageCode").ToString().Trim() == "True")
            {
                yinc = "";
                hidden1.Value = "0";
            }
            else
            {
               
                hidden1.Value = "1";
                yinc=" style=\"display:none;\"";
            }

        }

       
    }
    public string Systemlogin(string ConfigName)
    {
        string mmt = "";
            XmlDoc xml = new XmlDoc();
            xml.xmlfilePath = "~/Config/SystemConfig.config";
            DataSet ds = xml.GetDataSet();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                mmt= ds.Tables[0].Rows[0][ConfigName].ToString();
            }
            return mmt;
    }
 
}
