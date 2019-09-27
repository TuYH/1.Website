using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace HXD.Common
{
    public class Api_lianjing
    {
        protected string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";//密匙
        protected string tag = "1474881657";//签名

    
        #region 关键搜索 获取景区数据
        /// <summary>  
        /// 获取景区数据 （按关键词搜索）
        /// a=城市，b=景点
        /// </summary>  
        public static string getmdd(string stra1, string stra2)
        {
            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();//添加参数
            dic.Add("Area", stra1);
            dic.Add("Name", stra2);
            dic.Add("PageIndex", "1");
            dic.Add("PageSize", "10");
            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密
            string cans_p = "\"Area\":\"" + stra1 + "\",\"Name\":\"" + stra2 + "\",\"PageIndex\":\"1\",\"PageSize\":\"10\"";
            cans_p = cans_p.Replace("\"", "%22");
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=ScenicList&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";
            return url;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// stra1=城市
        /// stra2=mdd
        /// PageIndex=分页
        /// <returns></returns>
        public static string getmddpage(string stra1, string stra2, int PageIndex)
        {
            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();//添加参数
            dic.Add("Area", stra1);
            dic.Add("Name", stra2);
            dic.Add("PageIndex", PageIndex.ToString());
            dic.Add("PageSize", "10");
            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密
            string cans_p = "\"Area\":\"" + stra1 + "\",\"Name\":\"" + stra2 + "\",\"PageIndex\":\"" + PageIndex + "\",\"PageSize\":\"10\"";
            cans_p = cans_p.Replace("\"", "%22");
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=ScenicList&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";
            return url;
        }
        #endregion 

        #region 根据标识获取景区讲解集合
        /// <summary>  
        /// 根据标识获取景区讲解集合
        /// 举例：{"Code":"44268860","Unix":"1469523259"}
        /// </summary>    
        public static string getjingdian(string code, string unix)
        {
            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Code", code);
            dic.Add("Unix", unix);

            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密

            string cans_p = "\"Code\":\"" + code + "\",\"Unix\":\"" + unix + "\"";
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=ScenicExplain&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";

            return url;
           // Response.Write(url);


        }
        #endregion

        #region 获取景区实体
        /// <summary>  
        /// 获取景区数据 （按关键词搜索）
        /// 举例：{"Area":"北京","Name":"天坛"}
        /// </summary>    
        public static string getjingqushiti(string city, string mdd)
        {
            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();//添加参数
            dic.Add("Area", city);
            dic.Add("Name", mdd);

            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密

            string cans_p = "\"Area\":\"" + city + "\",\"Name\":\"" + mdd + "\"";
            cans_p = cans_p.Replace("\"", "%22");
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=FindScenic&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";

            return url;


        }
        #endregion

        #region 获取景点数据
        /// <summary>  
        /// 根据标识获取景区数据 
        /// 举例：{"Code":"44005643","Unix":"1469260042","PageIndex":"1","PageSize":"20"}
        /// </summary>    
        public static string getjingdian2(string code, string unix)
        {

            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Code", code);
            dic.Add("Unix", unix);
            dic.Add("PageIndex", "1");
            dic.Add("PageSize", "60");
            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密

            string cans_p = "\"Code\":\"" + code + "\",\"Unix\":\"" + unix + "\",\"PageIndex\":\"1\",\"PageSize\":\"60\"";
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=ScenicSpotList&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";

            return url;
            // Response.Write(url);


        }
        #endregion

        #region 根据标识获取景点讲解集合
        /// <summary>  
        /// 根据标识获取景点讲解集合 
        /// 举例：{"Code":"44268860","Unix":"1469523259"}
        /// </summary>    
        public static string getjingdianjh(string code, string unix)
        {
            string sign = "d085ed6baba84e6b8eaef3e2ba3218d8";
            string tag = "1474881657";
            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Code", code);
            dic.Add("Unix", unix);

            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密

            string cans_p = "\"Code\":\"" + code + "\",\"Unix\":\"" + unix + "\"";
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=ScenicSpotExplain&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";

            return url;
            // Response.Write(url);


        }
        #endregion


        protected void getdiqu()
        {
            //http://op.yjly.com/scenic.ashx?cmd=Area&p={"V ":"0"}&salt=1469415549&sign=130f4d3bdc2b991c011e0bb0dc313e2d&tag=10000&lang=1&version=1.0

            string str = GetTimeStamp();//时间戳
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("V", "0");

            string tmpStr = DictonarySort(dic);//参数字典排序
            string sign_q = tmpStr + str + sign;//参数集合
            string sign_f = GetMD5(sign_q);//参数MD5 32位小写加密

            string cans_p = "\"V\":\"0\"";
            cans_p = System.Web.HttpUtility.UrlEncode(cans_p, System.Text.Encoding.GetEncoding("utf-8"));//将简体汉字转换为Url编码
            string url = "http://op.yjly.com/scenic.ashx?cmd=Area&p={" + cans_p + "}&salt=" + str + "&sign=" + sign_f + "&tag=" + tag + "&lang=1&version=1.0";

            //Response.Write(url);
        }


        #region 字符串MD5 32位小写加密
        /// <summary>  
        /// MD5 32位小写加密  
        /// </summary>  
        public static string GetMD5(String input)
        {
            string cl = input;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("x2");

            }
            return pwd;
        }
        #endregion
        #region 参数字典排序
        /// <summary>  
        /// 参数字典排序  
        /// </summary>  
        private static string DictonarySort(Dictionary<string, string> dic)
        {
            string str = "";
            var dicSort = from objDic in dic orderby objDic.Key select objDic;
            foreach (KeyValuePair<string, string> kvp in dicSort)
            {
                str += kvp.Value;
            }
            return str;
        }
        #endregion
        #region 获取时间戳
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        public class Dataa
        {
            public int state { get; set; }
            public string msg { get; set; }
            public List<Dataa1> value { get; set; }
            public string pagecount { get; set; }
            public string extend { get; set; }
        }

        public class Dataa1
        {
            public string Code { get; set; }
            public string Unix { get; set; }
            public string Name { get; set; }
            public string Mp3Url { get; set; }
            public string AreaName { get; set; }
            public string Introduce { get; set; }
            public string Telephone { get; set; }
            public string PriceDesc { get; set; }
            public string Suitable { get; set; }
            public string BigImg { get; set; }
            public string PicImg { get; set; }
            public string DateTime { get; set; }
            public string NickName { get; set; }
            public string Sex { get; set; }
            public string HeadImg { get; set; }
        }

        /// <summary>
        /// 获得网址返回的json内容
        /// </summary>
        /// <returns></returns>
        public static string GetUrlContent(string urladdress)
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(urladdress); //从指定网站下载数据
            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句         

            // Encoding.Default.
            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

            return pageHtml;
        }
    }
}
