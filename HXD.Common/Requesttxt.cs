using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;

using System.IO;
using System.Collections;



namespace HXD.Common
{
    class Requesttxt
    {
        protected string Repeater = "";
        
        public string gettxt(string postStr)
        {
            string strSqlzd1 = "select * from tb_U_Info where Title like '%" + postStr.Trim() + "%'";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSqlzd1);
            Repeater += "<ArticleCount>" + ds.Tables[0].Rows.Count + "</ArticleCount>";
            Repeater += "<Articles>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                
                   // Repeater += "{&quot;id&quot;:1,&quot;short_title&quot;:&quot;1&quot;,&quot;long_title&quot;:&quot;1&quot;,&quot;pic&quot;:&quot;" + ds.Tables[0].Rows[i]["Photo"].ToString() + "&quot;,&quot;type&quot;:3,&quot;track_id&quot;:1,&quot;uid&quot;:&quot;" + ds.Tables[0].Rows[i]["href"].ToString() + "&quot;}";
                    
                    Repeater += "<item>";
                    Repeater += "<Title><![CDATA[" + ds.Tables[0].Rows[i]["title"].ToString() + "]]></Title> ";
                    Repeater += "<Description><![CDATA[" + ds.Tables[0].Rows[i]["note"].ToString() + "]]></Description>";
                    Repeater += "<PicUrl><![CDATA[http://geliefofm.com/" + ds.Tables[0].Rows[i]["Photo"].ToString() + "]]></PicUrl>";
                    Repeater += "<Url><![CDATA[http://geliefofm.com/sound/" + ds.Tables[0].Rows[i]["id"].ToString() + ".html]]></Url>";
                    Repeater += "</item>";
            }
            return Repeater;
        }
        public string gettxt2(string postStr)
        {
            //你好！
            postStr = postStr.Replace("!","");
            postStr = postStr.Replace("！", "");
            postStr = StringDeal.RemoveHtml(postStr);
            if (postStr == "抢月饼" || postStr == "红包")
            {
                Repeater += "<MsgType><![CDATA[text]]></MsgType>";
                Repeater += "<Content><![CDATA[Hi，格友你好。抢月饼，赢微信红包已经结束，你来晚了。欢迎持续关注我们的微信，格列佛―听的旅行攻略。我们将有更精彩活动，不定期推出哟。]]></Content>";
            }
            else
            {
                string strSqlzd1 = "select top 10 * from tb_U_Info where Title like '%" + postStr.Trim() + "%'  or title1 like '%" + postStr.Trim() + "%' order by Sort desc";
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSqlzd1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Repeater += "<MsgType><![CDATA[news]]></MsgType>";
                    Repeater += "<Content><![CDATA[]]></Content>";
                    Repeater += "<ArticleCount>" + ds.Tables[0].Rows.Count + "</ArticleCount>";
                    Repeater += "<Articles>";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        // Repeater += "{&quot;id&quot;:1,&quot;short_title&quot;:&quot;1&quot;,&quot;long_title&quot;:&quot;1&quot;,&quot;pic&quot;:&quot;" + ds.Tables[0].Rows[i]["Photo"].ToString() + "&quot;,&quot;type&quot;:3,&quot;track_id&quot;:1,&quot;uid&quot;:&quot;" + ds.Tables[0].Rows[i]["href"].ToString() + "&quot;}";
                        Repeater += "<item>";
                        Repeater += "<Title><![CDATA[" + ds.Tables[0].Rows[i]["title"].ToString() + "]]></Title> ";
                        Repeater += "<Description><![CDATA[" + ds.Tables[0].Rows[i]["note"].ToString() + "]]></Description>";
                        Repeater += "<PicUrl><![CDATA[http://geliefofm.com/" + ds.Tables[0].Rows[i]["Photo"].ToString() + "]]></PicUrl>";
                        Repeater += "<Url><![CDATA[http://geliefofm.com/sound/" + ds.Tables[0].Rows[i]["id"].ToString() + ".html]]></Url>";
                        Repeater += "</item>";
                    }
                    Repeater += "</Articles>";
                }
                else
                {
                    //select COUNT(id) from tb_U_weixin where Msg like '%巴厘%'
                    string strSql2 = "select count(*) from tb_U_weixin where Msg like '%" + postStr.Trim() + "%'";
                    int count = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(strSql2).ToString());
                    count = count + 1;
                    Repeater += "<MsgType><![CDATA[text]]></MsgType>";
                    Repeater += "<Content><![CDATA[已有" + count + "人搜索" + postStr.Trim() + "，格君会将您的需求，马上告知编导。给我点时间，一定会为您精彩呈现的！旅行路上，听格列佛。格列佛，听的旅行攻略。]]></Content>";


                }
            }
            return Repeater;
        }

        public string gettxt3(string postStr)
        {
            string word = "";
            String text = postStr.Trim(); ;
            Analyzer anal = new PanGuAnalyzer();//使用盘古分词
            StringReader sb = new StringReader(text);
            TokenStream ts = anal.ReusableTokenStream("", sb);
            Token t = null;
            word = "select top 1 Content from tb_U_Message where 1=1";
            while ((t = ts.Next()) != null)
            {
                Console.WriteLine(t.TermText());
                // Response.Write(t.TermText());
                word += "and Title like'%" + t.TermText() + "%'"; //and Title like'%"+t.TermText()+"%'

            }


            string count = HXD.DBUtility.SQLHelper.ExecuteScalar(word).ToString();
                    
                    Repeater += "<MsgType><![CDATA[text]]></MsgType>";
                    Repeater += "<Content><![CDATA[" + count + "\n\n如词答案任没有解决您的问题，你可以点击直接询问我们在泰国的达人。]]></Content>";


            
            return Repeater;
        }
      
    }
}
