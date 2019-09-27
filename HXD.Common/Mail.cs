using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Data;

namespace HXD.Common
{
    public class Mail
    {
        
        public string Server
        {
            get;
            set;
        }
        public string LoginUser
        {
            get;
            set;
        }
        public string LoginPass
        {
            get;
            set;
        }

        public Mail(string _Server, string _User, string _Pass)
        {
            Server = _Server;
            LoginUser = _User;
            LoginPass = _Pass;


        }
        public bool sendMail(string TO, string Subject, string Body)
        {
            return sendMail(LoginUser, TO, Subject, Body);
        }

        public bool sendMail(string From, string TO, string Subject, string Body)
        {
            //try
            //{
                XmlDoc xml = new XmlDoc();
                DataSet ds;
                xml.xmlfilePath = "~/Config/MailConfig.config";
                ds = xml.GetDataSet();
                string server = Server.ToString() != "" ? Server : ds.Tables[0].Rows[0]["SendMailServer"].ToString();
                string loginUser = LoginUser.ToString() != "" ? LoginUser : ds.Tables[0].Rows[0]["SendMailUserName"].ToString();
                string loginPass = LoginPass.ToString() != "" ? LoginUser : ds.Tables[0].Rows[0]["SendMailUserPwd"].ToString();
                From = LoginUser.ToString() != "" ? LoginUser : ds.Tables[0].Rows[0]["SendMailUserName"].ToString();

                System.Net.Mail.SmtpClient client = new SmtpClient(server);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(loginUser, loginPass);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                System.Net.Mail.MailMessage message = new MailMessage();
                message.From = new System.Net.Mail.MailAddress(From);
                message.Subject = Subject;
                message.Body = Body;

                string[] temp = TO.Split(',');
                int i;
                for (i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Trim() != "")
                    {
                        message.To.Add(temp[i].Trim());
                    }
                }
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                client.Send(message);
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}
