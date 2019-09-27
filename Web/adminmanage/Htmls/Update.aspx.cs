using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class adminmanage_Htmls_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title1 = "音乐放松椅", title = "", Photo = "", sp_time = "03:45", strc = "",icd="";

        //string sql_class = "select * tb_Menu where Id=1";
        string class_title=HXD.DBUtility.SQLHelper.ExecuteScalar("select title from tb_Menu where Id=1").ToString();
       
        string sql = "select * from tb_U_goods";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
            {
                icd = ds.Tables[0].Rows[ii]["id"].ToString();
                title = ds.Tables[0].Rows[ii]["title"].ToString();
                Photo = ds.Tables[0].Rows[ii]["Photo"].ToString();
                title1 = ds.Tables[0].Rows[ii]["title1"].ToString();
                sp_time = "03:45";
                
                strc += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_topci_list\">";
                strc += "<a href=\"../product/" + icd + ".html\" class=\"pet_topci_block\">";
                strc += "<div class=\"pet_topci_video\"><i class=\"iconfont\">&#xe62d;</i><span>" + sp_time + "</span></div>";
                strc += "<div class=\"pet_topci_shadow_font\">" + title + "</div>";
                strc += "<div class=\"pet_topci_shadow\"></div>";
                strc += "<img src=\"" + Photo + "\" alt=\"\">";
                strc += "</a></li>";
               
            }
            string[] str1 = new string[] { strc, class_title };
            string[] str2 = new string[] { "[$strc$]","[$title$]" };//"[$ID$]"

                HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/M_list01.html", "~/list/1.html");
        }
        Response.Write("列表--生成成功！");


        string sqls = "select * from tb_U_goods";
        DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < dss.Tables[0].Rows.Count; ii++)
            {
                string id = dss.Tables[0].Rows[ii]["id"].ToString();
                string g_title = dss.Tables[0].Rows[ii]["title"].ToString();
                string g_Photo = dss.Tables[0].Rows[ii]["Photo"].ToString();
                string g_title1 = dss.Tables[0].Rows[ii]["title1"].ToString();
                string classid = dss.Tables[0].Rows[ii]["classid"].ToString();
                string content = dss.Tables[0].Rows[ii]["Content"].ToString();
                string addtime = dss.Tables[0].Rows[ii]["PostTime"].ToString();

                string strca = "";

                string sqlg = "select title from tb_Menu where Id=" + classid;
                    string classname = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlg).ToString();
                    string sqlgs = "select * from tb_U_goods where ClassId=" + classid;
                    DataSet dsg = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlgs);
                    if (dsg.Tables[0].Rows.Count > 0)
                    {
                        for (int iig = 0; iig < dsg.Tables[0].Rows.Count; iig++)
                        {
                            string gl_id = dsg.Tables[0].Rows[iig]["id"].ToString();
                            string gl_title = dsg.Tables[0].Rows[iig]["title"].ToString();
                            string gl_Photo = dsg.Tables[0].Rows[iig]["Photo"].ToString();
                            string gl_title1 = dsg.Tables[0].Rows[iig]["title1"].ToString();
                            strca += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                            strca += "<div class=\"pet_list_one_info\">";
                            strca += "<div class=\"pet_list_one_info_l\">";
                            strca += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                            strca += "<div class=\"pet_list_one_info_name\"></div></div><div class=\"pet_list_one_info_r\">";
                            strca += "<div class=\"pet_list_tag pet_list_tag_xxs\">" + classname + "</div></div></div>";
                            strca += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                            strca += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../product/" + gl_id + ".html\" class=\"\">" + gl_title + "</a></h3>";
                            strca += "<div class=\"am-list-item-text pet_list_one_text\">" + gl_title1 + "</div>";
                            strca += "</div><div class=\"am-u-sm-4 am-list-thumb\"><a href=\"###\" class=\"\"><img src=\"" + gl_Photo + "\" class=\"pet_list_one_img\" alt=\"\"/></a></div></li>";
                        }

                    }


                    string[] str1 = new string[] { strca, g_title, addtime, content };
                    string[] str2 = new string[] { "[$strca$]", "[$title$]", "[$addtime$]", "[$content$]" };//"[$ID$]"

                HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/M_good01.html", "~/product/"+id+".html");
            }
         
        }
        Response.Write("产品--生成成功！");
        html_index();
        html_news();
    }
    public void html_index()//生成首页
    {
        string str_news="";
        string sqls = "select * from tb_U_info order by id desc";
        DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < dss.Tables[0].Rows.Count; ii++)
            {
                string id = dss.Tables[0].Rows[ii]["id"].ToString();
                string g_title = dss.Tables[0].Rows[ii]["title"].ToString();
                string sp_time = dss.Tables[0].Rows[ii]["title1"].ToString();
                string g_Photo = dss.Tables[0].Rows[ii]["Photo"].ToString();
                string note = dss.Tables[0].Rows[ii]["note"].ToString();
                int classid = int.Parse(dss.Tables[0].Rows[ii]["classid"].ToString());
                string content = dss.Tables[0].Rows[ii]["Content"].ToString();

                #region 新闻
                switch (classid)
                {
　                case 7 ://趣闻
　　                    str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_zzs\">趣闻</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";

                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
　　                break;
　                case 8 ://新鲜事

                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_xxs\">新鲜事</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"news/"+id+".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
　　                
　　                break;
　                case 9 ://视频
　　                     str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                         str_news += "<div class=\"pet_list_one_info\">";
                         str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                         str_news += "</div>";
                         str_news += "<div class=\"pet_list_one_info_r\">";
                         str_news += "<div class=\"pet_list_tag pet_video_tag\">视频</div>";
                         str_news += "</div>";
                         str_news += "</div>";
                         str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                         str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                         str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                         str_news += "</div>";
                         str_news += "<div class=\"am-u-sm-4 am-list-thumb pet_video_info\">";
                         str_news += "<div class=\"pet_video_info_tag\"><i class=\"iconfont\">&#xe62d;</i>" + sp_time + "</div>";
                         str_news += "<a href=\"news/" + id + ".html\" class=\"\">";
                         str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                         str_news += "</a>";
                         str_news += "</div>";
                         str_news += "</li>";
　　                break;
                  case 10://阅读
                          str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                          str_news += "<div class=\"pet_list_one_info\">";
                          str_news += "<div class=\"pet_list_one_info_l\">";
                          str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                          str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                          str_news += "</div>";
                          str_news += "<div class=\"pet_list_one_info_r\">";
                          str_news += "<div class=\"pet_list_tag pet_list_tag_stj\">阅读</div>";
                          str_news += "</div>";
                          str_news += "</div>";
                          str_news += "<div class=\" am-list-main\">";
                          str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                          str_news += "<ul data-am-widget=\"gallery\" class=\"am-gallery am-avg-sm-3 am-avg-md-3 am-avg-lg-3 am-gallery-default pet_list_one_list\" >";
                          str_news += tqimg(content,id,g_title);
                          str_news += "</ul>";
                          str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                          str_news += "</div>";
                          str_news += "</li>";
                      break;
                  case 11://专题
                            str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                            str_news += "<div class=\"pet_list_one_info\">";
                            str_news += "<div class=\"pet_list_one_info_l\">";
                            str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"img/lx.png\" alt=\"\"></div>";
                            str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                            str_news += "</div>";
                            str_news += "<div class=\"pet_list_one_info_r\">";
                            str_news += "<div class=\"pet_list_tag pet_list_tag_mzt\">专题</div>";
                            str_news += "</div>";
                            str_news += "</div>";
                            str_news += "<div class=\" am-list-main\">";
                            str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                            str_news += "<div class=\"pet_list_zt_img\"><img src=\"" + g_Photo + "\" alt=\"\"></div>";
                            str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                            str_news += "</div>";
                            str_news += "</li>";
                      break;

　                default :
　　                str_news += "";
　　                break;
                }
                #endregion
            }
            string[] str1 = new string[] { str_news };
            string[] str2 = new string[] { "[$str_news$]" };//"[$ID$]"
            HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/M_index.html", "~/index.html");

        }
        Response.Write("首页--生成成功！");
    }
    /// <summary>
    /// 生成新闻列表页及新闻页
    /// </summary>
    public void html_news()
    {
        string str_news = "";
        string sqls = "select * from tb_U_info";
        DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < dss.Tables[0].Rows.Count; ii++)
            {
                string id = dss.Tables[0].Rows[ii]["id"].ToString();
                string g_title = dss.Tables[0].Rows[ii]["title"].ToString();
                string sp_time = dss.Tables[0].Rows[ii]["title1"].ToString();
                string g_Photo = dss.Tables[0].Rows[ii]["Photo"].ToString();
                string note = dss.Tables[0].Rows[ii]["note"].ToString();
                int classid = int.Parse(dss.Tables[0].Rows[ii]["classid"].ToString());
                string content = dss.Tables[0].Rows[ii]["Content"].ToString();

                #region 新闻
                switch (classid)
                {
                    case 7://趣闻
                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_zzs\">趣闻</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 8://新鲜事

                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_xxs\">新鲜事</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";

                        break;
                    case 9://视频
                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_video_tag\">视频</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb pet_video_info\">";
                        str_news += "<div class=\"pet_video_info_tag\"><i class=\"iconfont\">&#xe62d;</i>" + sp_time + "</div>";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 10://阅读
                        str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_stj\">阅读</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-list-main\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<ul data-am-widget=\"gallery\" class=\"am-gallery am-avg-sm-3 am-avg-md-3 am-avg-lg-3 am-gallery-default pet_list_one_list\" >";
                        str_news += tqimg(content, id, g_title);
                        str_news += "</ul>";
                        str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 11://专题
                        str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_mzt\">专题</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-list-main\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"pet_list_zt_img\"><img src=\"" + g_Photo + "\" alt=\"\"></div>";
                        str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;

                    default:
                        str_news += "";
                        break;
                }
                #endregion
            }
            string[] str1 = new string[] { str_news };
            string[] str2 = new string[] { "[$str_news$]" };//"[$ID$]"
            HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/M_newlist.html", "~/news/index.html");

        }
        Response.Write("新闻列表页--生成成功！");


        
        string sqlnews = "select * from tb_U_info";
        DataSet dsa = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlnews);
        if (dsa.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < dsa.Tables[0].Rows.Count; ii++)
            {
                string id = dsa.Tables[0].Rows[ii]["id"].ToString();
                string g_title = dsa.Tables[0].Rows[ii]["title"].ToString();
                string sp_time = dsa.Tables[0].Rows[ii]["title1"].ToString();
                string g_Photo = dsa.Tables[0].Rows[ii]["Photo"].ToString();
                string note = dsa.Tables[0].Rows[ii]["note"].ToString();
                int classid = int.Parse(dsa.Tables[0].Rows[ii]["classid"].ToString());
                string content = dsa.Tables[0].Rows[ii]["Content"].ToString();
                string addtime = dsa.Tables[0].Rows[ii]["PostTime"].ToString();;
                string strea = getnewlist();
                string[] str1 = new string[] { g_title, addtime, content, strea };
                string[] str2 = new string[] { "[$title$]", "[$addtime$]", "[$content$]", "[$strea$]" };//"[$ID$]"
                HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/M_news.html", "~/news/"+id+".html");
                
            }


        }
        Response.Write("新闻内容页--生成成功！");
    }
    /// <summary>
    /// 获取最新新闻列表top6
    /// </summary>
    /// <returns></returns>
    public string getnewlist()
    {
        string str_news = "";
        string sqls = "select top 6 * from tb_U_info";
        DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < dss.Tables[0].Rows.Count; ii++)
            {
                string id = dss.Tables[0].Rows[ii]["id"].ToString();
                string g_title = dss.Tables[0].Rows[ii]["title"].ToString();
                string sp_time = dss.Tables[0].Rows[ii]["title1"].ToString();
                string g_Photo = dss.Tables[0].Rows[ii]["Photo"].ToString();
                string note = dss.Tables[0].Rows[ii]["note"].ToString();
                int classid = int.Parse(dss.Tables[0].Rows[ii]["classid"].ToString());
                string content = dss.Tables[0].Rows[ii]["Content"].ToString();

                #region 新闻
                switch (classid)
                {
                    case 7://趣闻
                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_zzs\">趣闻</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 8://新鲜事

                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_xxs\">新鲜事</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb\">";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";

                        break;
                    case 9://视频
                        str_news += "<li class=\"am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-right pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_video_tag\">视频</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-u-sm-8 am-list-main pet_list_one_nr\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"am-list-item-text pet_list_one_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\"am-u-sm-4 am-list-thumb pet_video_info\">";
                        str_news += "<div class=\"pet_video_info_tag\"><i class=\"iconfont\">&#xe62d;</i>" + sp_time + "</div>";
                        str_news += "<a href=\"../news/" + id + ".html\" class=\"\">";
                        str_news += "<img src=\"" + HXD.Common.Utils.PhotoIco(g_Photo) + "\" class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                        str_news += "</a>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 10://阅读
                        str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_stj\">阅读</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-list-main\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<ul data-am-widget=\"gallery\" class=\"am-gallery am-avg-sm-3 am-avg-md-3 am-avg-lg-3 am-gallery-default pet_list_one_list\" >";
                        str_news += tqimg(content, id, g_title);
                        str_news += "</ul>";
                        str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;
                    case 11://专题
                        str_news += "<li class=\"am-g am-list-item-desced pet_list_one_block\">";
                        str_news += "<div class=\"pet_list_one_info\">";
                        str_news += "<div class=\"pet_list_one_info_l\">";
                        str_news += "<div class=\"pet_list_one_info_ico\"><img src=\"../img/lx.png\" alt=\"\"></div>";
                        str_news += "<div class=\"pet_list_one_info_name\">灵心心理 </div>";
                        str_news += "</div>";
                        str_news += "<div class=\"pet_list_one_info_r\">";
                        str_news += "<div class=\"pet_list_tag pet_list_tag_mzt\">专题</div>";
                        str_news += "</div>";
                        str_news += "</div>";
                        str_news += "<div class=\" am-list-main\">";
                        str_news += "<h3 class=\"am-list-item-hd pet_list_one_bt\"><a href=\"../news/" + id + ".html\" class=\"\">" + g_title + "</a></h3>";
                        str_news += "<div class=\"pet_list_zt_img\"><img src=\"" + g_Photo + "\" alt=\"\"></div>";
                        str_news += "<div class=\"am-list-item-text pet_list_two_text\">" + note + "</div>";
                        str_news += "</div>";
                        str_news += "</li>";
                        break;

                    default:
                        str_news += "";
                        break;
                }
                #endregion
            }
        }
        return str_news;
    }



    public string tqimg(string str,string id,string g_title)//提取图片
    {
        string str_news = "";
        string OriginalStr = str;

        StringBuilder mySB = new StringBuilder();
        int CurrenEnd;
        int StartPont = OriginalStr.IndexOf("src=\"");
        int a = 0;
        for (int i = StartPont; i < OriginalStr.Length && i > 0; i = OriginalStr.IndexOf("src=\"", CurrenEnd + 1))
        {
            CurrenEnd = OriginalStr.IndexOf("\"", i + 5);
            a = a + 1;
            if (a < 4)
            {
                

                str_news += "<li>";
                str_news += "<div class=\"am-gallery-item\">";
                str_news += "<a href=\"news/" + id + ".html\" class=\"\">";
                str_news += "<img " + OriginalStr.Substring(i, CurrenEnd - i + 1) + " class=\"pet_list_one_img\" alt=\"" + g_title + "\"/>";
                str_news += "</a>";
                str_news += "</div>";
                str_news += "</li>";
            }
            else
            {
                str_news += "";
            }
            
        }

        return str_news;

      
       
    }
}