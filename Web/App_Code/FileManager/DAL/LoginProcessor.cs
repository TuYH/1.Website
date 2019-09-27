using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ptw.FileManager.Web.Processor.Manage
{
    /// <summary>
    /// 登录处理
    /// </summary>
    public class LoginProcessor
    {
        private string _Value;
        private bool _LoginState = true;

        /// <summary>
        /// 处理结果
        /// </summary>
        public string Value
        {
            get { return _Value; }
        }

        /// <summary>
        /// 登录验证是否成功
        /// </summary>
        public bool LoginState
        {
            get { return _LoginState; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public LoginProcessor()
        {
            HttpRequest Request = HttpContext.Current.Request;
            HttpSessionState Session = HttpContext.Current.Session;
            
            string userName = Request.Form["username"];
            string passWord = Request.Form["password"];
            string code = Request.Form["code"];
            string md5str = "89-DC-0D-1A-A1-0F-3F-B7-B3-6B-C2-2A-6A-FE-95-65";

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord) || string.IsNullOrEmpty(code))
            {
                this._Value = "请填写完整";
                this._LoginState = false;
            }
            else if (Session["CheckCode"] == null)
            {
                this._Value = "验证码已过期";
                this._LoginState = false;
            }
            else if (code != Session["CheckCode"].ToString())
            {
                this._Value = "验证码错误";
                this._LoginState = false;
            }

            if (this._LoginState == true)
            {
                if (HXD.Common.Encryp.PassWordEncrypt(userName) == md5str && HXD.Common.Encryp.PassWordEncrypt(passWord) == md5str)
                {
                    Session["FileName"] = userName;
                }
                else
                {
                    this._Value = "身份验证失败";
                }
            }
        }
    }
}