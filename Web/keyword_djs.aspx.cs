using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class keyword_djs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string stea=this.TextBox1.Text;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         string city = "";
        string stea=this.TextBox1.Text;
        
        //string sql = "select * from tb_U_province";
        string sql = "select * from tb_U_province";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
            {
                city = ds.Tables[0].Rows[ii]["name"].ToString();
                city = city + stea + "【灵心心理】<br />";
                city = city.Replace("市", "");
                city = city.Replace("区", "");
                city = city.Replace("县", "");
                Response.Write(city);
             
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string city = "";
        string stea = this.TextBox1.Text;
        //string sql = "select * from tb_U_province";
        string sql = "select * from tb_U_city";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
            {
                city = ds.Tables[0].Rows[ii]["city"].ToString();
                city = city + stea + "【灵心心理】<br />";
                city = city.Replace("市", "");
                city = city.Replace("区", "");
                city = city.Replace("县", "");
                Response.Write(city);
            }
        }
    }
}