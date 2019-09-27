using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class news : System.Web.UI.Page
{
    protected string new_title = "", new_countent = "", new_time="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "" || Request.QueryString["id"] != null)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            string sql = "select id,ClassId,Title,content,PostTime from tb_U_info where Id=" + id;
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                new_title = ds.Tables[0].Rows[0]["Title"].ToString();
                new_countent = ds.Tables[0].Rows[0]["content"].ToString();
                new_time = ds.Tables[0].Rows[0]["PostTime"].ToString();
            }
        }
    }
}