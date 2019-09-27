using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_zx_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (!IsPostBack)
        {
            string MenuId = Session["userid"].ToString();
            int userid = int.Parse(MenuId);
            //cid 1=测评  2=预约  3=辅导 4=消息
            string sql = "select id,uid,zxs_id,Content,PostTime,state from tb_U_Message where cid=2 and uid=" + userid+" order by id desc";
            Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            Repeater1.DataBind();
        }

    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_user where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getzt(string str)
    {
        string name = "";
        int id = int.Parse(str);

        switch (id)
        {
            case 0:
                name = "<span class=\" hd_tag_jh\">等待中</span>";
                break;
            case 1:
                name = "<span>咨询中</span>";
                break;
            case 2:
                name = "<span class=\"hd_tag_js\">已完成</span>";
                break;
            default:
                name = "";
                break;
        }

        return name;
    }
}