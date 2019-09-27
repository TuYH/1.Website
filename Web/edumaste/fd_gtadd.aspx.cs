using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.IO;
using Telerik.WebControls;
using System.Data;

public partial class edumaste_fd_gtadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MenuId = Session["userid"].ToString();
        int xid = int.Parse(Request.QueryString["id"].ToString());
        string title = this.TextBox1.Text.Trim();
        string note = this.TextBox2.Text.Trim();
        //string path = HttpContext.Current.Server.MapPath(formfile);
        //string tag = this.TextBox3.Text.Trim();
        string content = this.container.Value.Trim();
        //string str_se = "2";
        string sc_id = LoginCheck.getadminid();
        string sql2 = "insert into tb_U_Message (ClassId,Content,zxs_id,uid,state,yy_time) values('" + sc_id + "','" + content + "','" + MenuId + "','" + xid + "','5','" + DateTime.Now.ToString() + "')";
        //string sql = "insert into tb_U_Message(Title,Note,Content,ClassId,userid,zxs_id)values('" + title + "','" + note + "','" + content + "','" + str_se + "','" + MenuId + "','" + tag + "')";
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql2);
        StringDeal.Alter("提交成功！", "fd_gt.aspx");

    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd(string id)
    {
        //string sql = "select id,ClassId,title,depth from tb_U_schoolfl where sid=" + id;
        //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        string demp = ds.Tables[0].Rows[i]["depth"].ToString();
        //        string stritem = ds.Tables[0].Rows[i]["id"].ToString();
        //        string strvalues = "├ " + ds.Tables[0].Rows[i]["title"].ToString();
        //        strvalues = getc(demp) + strvalues;
        //        this.Select1.Items.Add(new ListItem(strvalues, stritem));

        //        //<option value="a">-The.CC</option>
        //    }
        //}
    }
    protected string getc(string str)
    {
        string stm = "";
        int id = int.Parse(str);
        for (int i = 0; i < id; i++)
        {
            stm += "││";
        }
        return stm;
    }
   
}