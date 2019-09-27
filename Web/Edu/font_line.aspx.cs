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

public partial class Edu_font_line : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        bd(Session["userid"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MenuId = Session["userid"].ToString();

        string title = this.TextBox1.Text.Trim();
        string note = this.TextBox2.Text.Trim();
        //string path = HttpContext.Current.Server.MapPath(formfile);
        string tag = this.TextBox3.Text.Trim();
        string content = this.container.Value.Trim();
        string str_se = this.Select1.Value;

        string sql = "insert into tb_U_info(Title,Note,Content,ClassId,userid)values('" + title + "','" + note + "','" + content + "','" + str_se + "','" + MenuId + "')";
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
        
    }
     /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd(string id)
    {
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where sid=" + id;
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
}