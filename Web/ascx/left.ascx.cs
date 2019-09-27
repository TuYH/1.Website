using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ascx_left : System.Web.UI.UserControl
{
    protected string strarm = "", h_str="";
    private int _RoomID = 0;

    public int RoomID
    {
        get { return _RoomID; }
        set { _RoomID = value; }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        string classid=LoginCheck.getadminid();
        bdlhead(classid);
        //if (RoomID == 1)
        //{
        //    h_str = " active";
        //}
    }
    protected void bdlhead(string menid)
    {
        string sql = "select id,title from tb_U_schoolfl where depth=0 and menuid=1 and sid=" + menid;
        Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        Repeater1.DataBind();
    }
}