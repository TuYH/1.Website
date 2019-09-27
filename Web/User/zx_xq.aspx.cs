using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_zx_xq : System.Web.UI.Page
{
    protected string xs_name = "", xs_note = "", xs_time = "", ls_name = "", ls_note = "", ls_time = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                string sql = "select Id,uid,Name,Content,yy_time,zxs_id,replay,PostTime from tb_U_Message where Id='"+id+"'";
                //string sql = "select id,ClassId,Title,content,PostTime from tb_U_info where Id=" + id;
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xs_name = getname(ds.Tables[0].Rows[0]["uid"].ToString());
                    xs_note = ds.Tables[0].Rows[0]["Content"].ToString();
                    xs_time = ds.Tables[0].Rows[0]["yy_time"].ToString();

                    ls_name = getname(ds.Tables[0].Rows[0]["zxs_id"].ToString());
                    ls_note = ds.Tables[0].Rows[0]["replay"].ToString();
                    ls_time = ds.Tables[0].Rows[0]["PostTime"].ToString();
                    if (ls_note == null || ls_note == "")
                    {
                        ls_note = "暂无回复！请稍后。";
                        ls_time = "";
                    }
                 
                    
                }
            }
        }
    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_user where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
}