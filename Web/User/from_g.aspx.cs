using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class User_from_g : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(1);
        if (!IsPostBack)
        {

            bd();
            //string MenuId = Session["userid"].ToString();
            //userid = int.Parse(MenuId);

            //string sql = "select * from tb_U_User where id=" + userid;
            //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //this.username.Text = ds.Tables[0].Rows[0]["name"].ToString();
            //this.userphone.Text = ds.Tables[0].Rows[0]["tel"].ToString();


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqla = "select classid from tb_user where ID=" + Session["userid"].ToString();
        string menid = HXD.DBUtility.SQLHelper.ExecuteScalar(sqla).ToString();

        string yy_nameid = this.Select1.Value;//预约的老师编号
        string yy_name = this.Select1.Name;//预约的老师名字
        string yy_time = Text_time.Value;//预约时间
        string username = Session["AdminManage"].ToString();//预约人
        string userphone = this.userphone.Text;//预约人联系方式
        string content = this.usercontent.Text;//咨询的问题
        string uid = Session["userid"].ToString();
        //cid 1=测评  2=预约  3=辅导 4=消息
        string sql = "insert into tb_U_Message (zxs_id,zxs_name,yy_time,Name,Tel,Content,classid,uid,state,cid)values('" + yy_nameid + "','" + yy_name + "','" + yy_time + "','" + username + "','" + userphone + "','" + content + "','" + menid + "','" + uid + "','0','2')";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        LoginCheck.Sendmsg(menid, yy_nameid, "您有一个新的预约,请及时<a href=\"fd_gt.aspx\">查看</a>。");
        StringDeal.Alter("预约成功！请耐心等待。", "zx_list.aspx");
        
        

    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd()
    {
        string sqla = "select classid from tb_user where ID=" + Session["userid"].ToString();
        string menid = HXD.DBUtility.SQLHelper.ExecuteScalar(sqla).ToString();
        
        string sql = "select id,name from tb_u_user where id in(select id from tb_user where Classid='" + menid + "' and GroupId=5)";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
              
                string stritem = ds.Tables[0].Rows[i]["id"].ToString();
                string strvalues = ds.Tables[0].Rows[i]["name"].ToString();
                this.Select1.Items.Add(new ListItem(strvalues, stritem));
                //<option value="a">-The.CC</option>
            }
        }
    }
}