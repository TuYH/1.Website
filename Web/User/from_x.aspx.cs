using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class User_from_x : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(1);
        if (!IsPostBack)
        {
            string sql = "select classid from tb_user where ID=" + Session["userid"].ToString();
            string xz_id = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
            
            
            bdinfo();
        }
    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    //protected void bd(string id)
    //{
    //    select id,ClassId,title,depth from tb_U_schoolfl where menuid='2' and [Depth] =0 and sid=26
    //    string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=2 and Depth=0 and sid=" + id;
    //    DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            string demp = ds.Tables[0].Rows[i]["depth"].ToString();
    //            string stritem = ds.Tables[0].Rows[i]["id"].ToString();
    //            string strvalues = ds.Tables[0].Rows[i]["title"].ToString();
    //            string classid = ds.Tables[0].Rows[i]["ClassId"].ToString();
    //            this.DropDownList1.Items.Add(new ListItem(strvalues, stritem));
              
    //            <option value="a">-The.CC</option>
    //        }
            
    //    }
    //}
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void bd2(string id, string sid)
    //{
    //    select id,ClassId,title,depth from tb_U_schoolfl where classid=188 and sid=26
    //    string sql = "select id,ClassId,title,depth from tb_U_schoolfl where classid='" + id + "' and sid='" + sid + "'";
    //    DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            string demp = ds.Tables[0].Rows[i]["depth"].ToString();
    //            string stritem = ds.Tables[0].Rows[i]["id"].ToString();
    //            string strvalues = ds.Tables[0].Rows[i]["title"].ToString();

    //            this.Select2.Items.Add(new ListItem(strvalues, stritem));

    //            <option value="a">-The.CC</option>
    //        }
    //    }
    //}
    /// <summary>
    /// 绑定个人信心
    /// </summary>
    protected void bdinfo()
    {
        string sql = "select * from tb_u_user where ID=" + Session["userid"].ToString();
        DataSet ds=HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if(ds.Tables[0].Rows.Count>0)
        {
            this.username.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            this.sex.Value = ds.Tables[0].Rows[0]["sex"].ToString();
            this.Nationality.Value = ds.Tables[0].Rows[0]["nationality"].ToString();
            this.Birthday.Text = ds.Tables[0].Rows[0]["shengri"].ToString();
            this.Telephone.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
            this.Textjztime.Text = ds.Tables[0].Rows[0]["posttime"].ToString();
            this.nianji.Text = ds.Tables[0].Rows[0]["nianji"].ToString();
            this.banji.Text = ds.Tables[0].Rows[0]["banji"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = this.username.Text;
        string sex = this.sex.Value;
        string Nationality = this.Nationality.Value;
        string Birthday = this.Birthday.Text;
        string Telephone = this.Telephone.Text;
        string jieji = this.Textjztime.Text;
        string nianji = this.nianji.Text;
        string banji = this.banji.Text;

        string sql = "update tb_u_user set name='"+ username+"',sex='"+ sex+"',Nationality='"+ Nationality+"',shengri='"+ Birthday+"',tel ='"+Telephone+"',jieji='"+jieji+"',banji='"+banji+"',nianji='"+nianji+"' where ID='"+ Session["userid"].ToString()+"'";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        StringDeal.Alter("提交成功！", "twolist.aspx");
    }

    protected string getname(string id)
    {
        string sql = "SELECT title from tb_U_schoolfl where id='" + id + "'";
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
}