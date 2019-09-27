using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_fileimg : System.Web.UI.Page
{
   protected string avatarFlashParam;
        protected string EncodeLocalhost;
        protected string Localhost;
        protected string uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            int port = HttpContext.Current.Request.Url.Port;
            string ApplicationPath = HttpContext.Current.Request.ApplicationPath != "/" ? HttpContext.Current.Request.ApplicationPath : string.Empty;
            uid = "1";
            Localhost = string.Format("{0}://{1}{2}{3}",
                                 HttpContext.Current.Request.Url.Scheme,
                                 HttpContext.Current.Request.Url.Host,
                                 (port == 80 || port == 0) ? "" : ":" + port,
                                 ApplicationPath);
            EncodeLocalhost = HttpUtility.UrlEncode(Localhost);
            avatarFlashParam = string.Format("{0}/images/common/camera.swf?nt=1&inajax=1&appid=1&input={1}&ucapi={2}/Ajax.ashx", Localhost, uid, EncodeLocalhost);
        }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}