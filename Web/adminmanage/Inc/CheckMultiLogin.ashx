<%@ WebHandler Language="C#" Class="CheckMultiLogin" %>

using System;
using System.Web;
using HXD.Model;
using System.Web.SessionState;
using HXD.BLL;

public class CheckMultiLogin : IHttpHandler ,IRequiresSessionState  {
    
    public void ProcessRequest (HttpContext context) 
    {
        context.Response.Cache.SetNoStore();
        context.Response.Clear();
        mOnlineAdmin mOA = new mOnlineAdmin();
        bOnlineAdmin bOA = new bOnlineAdmin();
        mOA.SessionId = context.Session.SessionID;
        mOA.UserName = context.Request.QueryString["UserName"];
        bOA.OnlineAdminUpdate(mOA);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}