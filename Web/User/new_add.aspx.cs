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

public partial class user_new_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(5);
        if (!IsPostBack)
        {
            string classid = LoginCheck.getadminid();
            bd(classid);
            if (Request.QueryString["wzid"] != null)
            {
                string wzid = Request.QueryString["wzid"].ToString();
                string sql = "select * from tb_U_info where id=" + wzid;
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.TextBox1.Text = ds.Tables[0].Rows[0]["title"].ToString();
                    this.TextBox2.Text = ds.Tables[0].Rows[0]["note"].ToString();
                    this.container.Value = ds.Tables[0].Rows[0]["Content"].ToString();
                    this.Select1.Value = ds.Tables[0].Rows[0]["ClassId"].ToString();
                }

                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
            }
            else
            {
                this.Panel1.Visible = true;
                this.Panel2.Visible = false;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MenuId = Session["userid"].ToString();

        string title = this.TextBox1.Text.Trim();
        string note = this.TextBox2.Text.Trim();
        //string path = HttpContext.Current.Server.MapPath(formfile);
        //string tag = this.TextBox3.Text.Trim();
        string content = this.container.Value.Trim();
        string str_se = this.Select1.Value;

        string sql = "insert into tb_U_info(Title,Note,Content,ClassId,userid)values('" + title + "','" + note + "','" + content + "','" + str_se + "','" + MenuId + "')";
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
        StringDeal.Alter("提交成功！", "new_list.aspx");
        
    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd(string id)
    {
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=1 and sid=" + id;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string demp = ds.Tables[0].Rows[i]["depth"].ToString();
                string stritem = ds.Tables[0].Rows[i]["id"].ToString();
                string strvalues = "├ " + ds.Tables[0].Rows[i]["title"].ToString();
                strvalues = getc(demp) + strvalues;
                this.Select1.Items.Add(new ListItem(strvalues, stritem));

                //<option value="a">-The.CC</option>
            }
        }
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
    protected void Button2_Click(object sender, EventArgs e)
    {

        string idc = Request.QueryString["wzid"].ToString();
        string title = this.TextBox1.Text.Trim();
        string note = this.TextBox2.Text.Trim();
        //string tag = this.TextBox3.Text.Trim();
        string content = this.container.Value.Trim();
        string str_se = this.Select1.Value;

        string sql = "update tb_U_info set title='" + title + "',note='" + note + "',Content='" + content + "',ClassId='" + str_se + "' where id=" + idc;
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
        StringDeal.Alter("更新成功！","new_list.aspx");
        
    }
}