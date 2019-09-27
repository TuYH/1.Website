using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Net;
using System.IO;
using HXD.Model;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using System.Web.UI.WebControls.Adapters;



namespace HXD.Common
{
    /// <summary>  System .Web .HttpContext.Current.Server
    /// 微信公众平台操作类  
    /// </summary>  
    public class weixin
    {
        private string Token = "xunjiang123"; //换成自己的token  
        public void Auth()
        {
            string echoStr = System.Web.HttpContext.Current.Request.QueryString["echoStr"];
            if (CheckSignature()) //校验签名是否正确  
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    System.Web.HttpContext.Current.Response.Write(echoStr); //返回原值表示校验成功  
                    System.Web.HttpContext.Current.Response.End();
                }
            }
        }


        public void Handle(string postStr)
        {
            //封装请求类  
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postStr);
            XmlElement rootElement = doc.DocumentElement;
            //MsgType  
            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");
            //接收的值--->接收消息类(也称为消息推送)  

            RequestXML requestXML = new RequestXML();
            requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
            requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
            requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
            requestXML.MsgType = MsgType.InnerText;

            //根据不同的类型进行不同的处理  
            switch (requestXML.MsgType)
            {
                case "text": //文本消息  
                    requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;
                    break;
                case "image": //图片  
                    requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                    break;
                case "location": //位置  
                    requestXML.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;
                    requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;
                    requestXML.Scale = rootElement.SelectSingleNode("Scale").InnerText;
                    requestXML.Label = rootElement.SelectSingleNode("Label").InnerText;
                    break;
                case "link": //链接  
                    break;
                case "event": //事件推送 支持V4.5+  
                    requestXML.Event = rootElement.SelectSingleNode("Event").InnerText;
                    requestXML.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                    break;
                case "voice"://语音识别
                    requestXML.Recognition = rootElement.SelectSingleNode("Recognition").InnerText;
                    break;
                case "click"://点击事件 
                    requestXML.click = rootElement.SelectSingleNode("Click").InnerText;
                    break;
            }

            //消息回复  
            ResponseMsg(requestXML);
        }


        /// <summary>  
        /// 验证微信签名  
        /// * 将token、timestamp、nonce三个参数进行字典序排序  
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密  
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。  
        /// </summary>  
        /// <returns></returns>  
        private bool CheckSignature()
        {
            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];
            //加密/校验流程：  
            //1. 将token、timestamp、nonce三个参数进行字典序排序  
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);//字典排序  
            //2.将三个参数字符串拼接成一个字符串进行sha1加密  
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            //3.开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。  
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// 消息回复(微信信息返回)  
        /// </summary>  
        /// <param name="requestXML">The request XML.</param>  
        private void ResponseMsg(RequestXML requestXML)
        {
            try
            {
                XmlDoc xml = new XmlDoc();
                xml.xmlfilePath = "~/Config/SystemConfig.config";
                DataSet dsc;
                dsc = xml.GetDataSet();
                string contct = dsc.Tables[0].Rows[0]["HomeDescription"].ToString();
                string resxml = "";
                //主要是调用数据库进行关键词匹配自动回复内容，可以根据自己的业务情况编写。  
                //1.通常有，没有匹配任何指令时，返回帮助信息  
                Requesttxt mi = new Requesttxt();
                string contetn = requestXML.Content;
                string name = requestXML.FromUserName;

                


                switch (requestXML.MsgType)
                {
                    case "text":
                        //在这里执行一系列操作，从而实现自动回复内容.   
;
                        resxml += "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
                        resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
                        resxml += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
                        resxml += mi.gettxt3(requestXML.Content);
                        resxml += "</xml>";

                        break;
                    case "location":
                        string city = GetMapInfo(requestXML.Location_X, requestXML.Location_Y);
                        if (city == "0")
                        {
                            resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[好啦，我们知道您的位置啦。您可以:222222222222222]]></Content><FuncFlag>1</FuncFlag></xml>";
                        }
                        else
                        {
                            resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[好啦，我们知道您的位置啦。您可以:3333333333333333]]></Content><FuncFlag>1</FuncFlag></xml>";
                        }
                        break;
                    case "image":
                        //图文混合的消息 具体格式请见官方API“回复图文消息”   
                        break;
                    case "event":
                        switch(requestXML.Event)
                        {
                            case "subscribe":

                                resxml += "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
                                resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
                                resxml += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
                                resxml += "<MsgType><![CDATA[text]]></MsgType>";
                                resxml += "<Content><![CDATA[" + contct + "]]></Content>";
                                resxml += "</xml>";
                                break;

                            case "CLICK":
                                switch (requestXML.EventKey)
                                {
                                    case "mp3":
                                        resxml += "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
                                        resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
                                        resxml += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
                                        resxml += "<MsgType><![CDATA[news]]></MsgType>";
                                        resxml += "<ArticleCount>1</ArticleCount>";
                                        resxml += "<Articles>";
                                        resxml += "<item>";
                                        resxml += "<Title><![CDATA[纪念杰克逊诞辰,致敬经典《Beat It》-格列佛出品]]></Title> ";
                                        resxml += "<Description><![CDATA[8月29日是已故天王——迈克尔.杰克逊诞辰之日，8月29日格列佛——听的旅行攻略上线。格君将天王神曲《Beat It》改编为旅行版《Beat It》为此次上线助力。]]></Description>";
                                        resxml += "<PicUrl><![CDATA[http://geliefofm.com/images/wx_jkx.jpg]]></PicUrl>";
                                        resxml += "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzAxMDU0MDM3NQ==&mid=207066391&idx=1&sn=210e7e1ec467ba6f7d2aae2414533fba#rd]]></Url>";
                                        resxml += "</item>";
                                        resxml += "</Articles>";
                                        resxml += "</xml>";
                                        break;

                                    case "lianxiwomen":
                                        resxml += "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
                                        resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
                                        resxml += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
                                        resxml += "<MsgType><![CDATA[text]]></MsgType>";
                                        resxml += "<Content><![CDATA[亲爱的格友，想联系，可在微信中留言。比较着急呢! ......，还可以通过以下方式。\n\n电话：13910012101\n\nQQ：1927829510]]></Content>";
                                        resxml += "</xml>";
                                        break;


                                }
                                break;
                        }
                        break;
                    case "voice":
                        resxml += "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>";
                        resxml += "<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>";
                        resxml += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
                        resxml += mi.gettxt3(requestXML.Recognition);
                        resxml += "</xml>";

                        break;

                  
                }

                System.Web.HttpContext.Current.Response.Write(resxml);
                WriteToDB(requestXML);
            }
            catch 
            {
                //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());  
                //wx_logs.MyInsert("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());  
            }
        }



        /// <summary>  
        /// unix时间转换为datetime  
        /// </summary>  
        /// <param name="timeStamp"></param>  
        /// <returns></returns>  
        private DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }


        /// <summary>  
        /// datetime转换为unixtime  
        /// </summary>  
        /// <param name="time"></param>  
        /// <returns></returns>  
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }


        /// <summary>  
        /// 调用百度地图，返回坐标信息  
        /// </summary>  
        /// <param name="y">经度</param>  
        /// <param name="x">纬度</param>  
        /// <returns></returns>  
        public string GetMapInfo(string x, string y)
        {
            try
            {
                string res = string.Empty;
                string parame = string.Empty;
                string url = "http://maps.googleapis.com/maps/api/geocode/xml";

                parame = "latlng=" + x + "," + y + "&language=zh-CN&sensor=false";//此key为个人申请  
                res = webRequestPost(url, parame);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);

                XmlElement rootElement = doc.DocumentElement;
                string Status = rootElement.SelectSingleNode("status").InnerText;

                if (Status == "OK")
                {
                    //仅获取城市  
                    XmlNodeList xmlResults = rootElement.SelectSingleNode("/GeocodeResponse").ChildNodes;
                    for (int i = 0; i < xmlResults.Count; i++)
                    {
                        XmlNode childNode = xmlResults[i];
                        if (childNode.Name == "status")
                        {
                            continue;
                        }
                        string city = "0";
                        for (int w = 0; w < childNode.ChildNodes.Count; w++)
                        {
                            for (int q = 0; q < childNode.ChildNodes[w].ChildNodes.Count; q++)
                            {
                                XmlNode childeTwo = childNode.ChildNodes[w].ChildNodes[q];
                                if (childeTwo.Name == "long_name")
                                {
                                    city = childeTwo.InnerText;
                                }
                                else if (childeTwo.InnerText == "locality")
                                {
                                    return city;
                                }
                            }
                        }
                        return city;
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteTxt("map异常:" + ex.Message.ToString() + "Struck:" + ex.StackTrace.ToString());  
                return "0";
            }
            return "0";
        }


        /// <summary>  
        /// Post 提交调用抓取  
        /// </summary>  
        /// <param name="url">提交地址</param>  
        /// <param name="param">参数</param>  
        /// <returns>string</returns>  
        public string webRequestPost(string url, string param)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + "?" + param);
            req.Method = "Post";
            req.Timeout = 120 * 1000;
            req.ContentType = "application/x-www-form-urlencoded;";
            req.ContentLength = bs.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
            }

            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理  
                Stream strm = wr.GetResponseStream();
                StreamReader sr = new StreamReader(strm, System.Text.Encoding.UTF8);

                string line;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line + System.Environment.NewLine);
                }
                sr.Close();
                strm.Close();
                return sb.ToString();
            }
        }

        /// <summary>  
        /// 将本次交互信息保存至数据库中  
        /// </summary>  
        /// <param name="requestXML"></param>  
        /// <param name="_xml"></param>  
        /// <param name="_pid"></param>  
        private void WriteToDB(RequestXML requestXML)
        {
            try
            {
                if (requestXML.MsgType == "voice")
                {
                    requestXML.Content = requestXML.Recognition;
                }
                string sqlstr = "insert into tb_U_weixin (FormUserName,ToUserName,MsgType,Msg,Location_X,Location_Y)values('" + requestXML.FromUserName + "','" + requestXML.ToUserName + "','" + requestXML.MsgType + "','" + requestXML.Content + "','" + requestXML.Location_X + "','" + requestXML.Location_Y + "')";
                HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqlstr);
            }
            catch { }
   
        }


        public string get_acctoken(string durl)
        {
           

            //开发者ID
            //AppID(应用ID)wx3bbdf1d17a189725                           
            //AppSecret(应用密钥)c3be4c615300838e91a15bac49723c33 

            string gettokenurl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx3bbdf1d17a189725&secret=c3be4c615300838e91a15bac49723c33";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(gettokenurl);
            req.Method = "GET";
            //use request to get response
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //otherwise will return messy code
            //  Encoding htmlEncoding = Encoding.GetEncoding(htmlCharset);
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            //read out the returned html
            string respHtml = sr.ReadToEnd();
            //上边为读取json数据，下边就是解析了
            //Access_Token j2 = new JavaScriptSerializer().Deserialize<Access_Token>(respHtml);
            //acctoken是一个静态变量，全局的就是。
            //{"access_token":"slHOS8ZvwEZN80quzc4ciqDWLzphGXa3e-_wDlHtSM-mtxvfQFspfWgUKGqgKNB57XMVpdVtrvGSMmnIJDRn7i0vjJyUoND4uNS0c3985Tw","expires_in":7200}
            respHtml = respHtml.Replace("{", "");
            respHtml = respHtml.Replace("}", "");
            respHtml = respHtml.Replace("\"", "");
            respHtml = respHtml.Replace("access_token", "");
            respHtml = respHtml.Replace(":", "");
            respHtml = respHtml.Replace(",", "");
            respHtml = respHtml.Replace("expires_in", "");
            respHtml = respHtml.Replace("7200", "");
            
            string getticketurl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + respHtml + "&type=jsapi";
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(getticketurl);
            req2.Method = "GET";
            HttpWebResponse resp2 = (HttpWebResponse)req2.GetResponse();
            //otherwise will return messy code
            //  Encoding htmlEncoding = Encoding.GetEncoding(htmlCharset);
            StreamReader sr2 = new StreamReader(resp2.GetResponseStream(), Encoding.UTF8);
            //read out the returned html
            string respHtml2 = sr2.ReadToEnd();
            //上边为读取json数据，下边就是解析了
            //Access_Token j2 = new JavaScriptSerializer().Deserialize<Access_Token>(respHtml);
            //acctoken是一个静态变量，全局的就是。
            //{"access_token":"slHOS8ZvwEZN80quzc4ciqDWLzphGXa3e-_wDlHtSM-mtxvfQFspfWgUKGqgKNB57XMVpdVtrvGSMmnIJDRn7i0vjJyUoND4uNS0c3985Tw","expires_in":7200}
            respHtml2 = respHtml2.Replace("{", "");
            respHtml2 = respHtml2.Replace("}", "");
            respHtml2 = respHtml2.Replace("\"errcode\":0,", "");
            respHtml2 = respHtml2.Replace("\"errmsg\":\"ok\",", "");
            respHtml2 = respHtml2.Replace("\"", "");
            respHtml2 = respHtml2.Replace("ticket", "");
            respHtml2 = respHtml2.Replace(":", "");
            respHtml2 = respHtml2.Replace(",", "");
            respHtml2 = respHtml2.Replace("expires_in", "");
            respHtml2 = respHtml2.Replace("7200", "");


            string noncestr = "Wm3WZYTPz0wzccnW";
            string jsapi_ticket =respHtml2;
            string timestamp = "1414587457";
            string wxurl = durl;


            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(wxurl.IndexOf("#") >= 0 ? wxurl.Substring(0, wxurl.IndexOf("#")) : wxurl);
            string string1 = string1Builder.ToString();
            string signature2 = SHA1(string1);

            return "jsonFlickrFeed({\"signature\":\"" + signature2 + "\"})";


        }



    
        //sha1算法
        public static string SHA1(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }


        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, long timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();
            return SHA1(string1);
        }






        /// <summary>
    /// 创建二维码ticket
    /// </summary>
    /// <returns></returns>
    public static string CreateTicket(string TOKEN)
    {

        string result = "";
        //string strJson = @"{""expire_seconds"":1800, ""action_name"": ""QR_SCENE"", ""action_info"": {""scene"": {""scene_id"":100000023}}}";
        string strJson = @"{""action_name"": ""QR_LIMIT_SCENE"", ""action_info"": {""scene"": {""scene_id"":123}}}";
        string wxurl = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + TOKEN;

        WebClient myWebClient = new WebClient();
        myWebClient.Credentials = CredentialCache.DefaultCredentials;
        try
        {

            result = myWebClient.UploadString(wxurl, "POST", strJson);
            //WriteLog("上传result:" + result);
            Ticket _mode = JsonHelper.ParseFromJson<Ticket>(result);
            //UploadMM _mode = JsonHelper.ParseFromJson<UploadMM>(result);
            //result = _mode.ticket;
            result = _mode.ticket + "_" + _mode.expire_seconds;
        }
        catch (Exception ex)
        {
            result = "Error:" + ex.Message;
        }
        //WriteLog("上传MediaId:" + result);

        return result;
    }


    


    } 
}
