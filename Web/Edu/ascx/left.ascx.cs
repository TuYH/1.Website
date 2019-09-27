using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edu_ascx_left : System.Web.UI.UserControl
{
    protected string ry_style = "", ry_ds = "", ry_ls = "", ry_xs = "", wz_style = "", wz_ds = "", wz_tj = "", wz_list = "", wz_fl="";
    protected string school_style = "", school_ds = "", school_xx = "", school_xz = "", school_ls = "", school_xs = "";
    protected string lb_style = "", lb_ds = "", lb_jg = "", lb_tj = "";
    private int _RoomID = 0;

    public int RoomID
    {
        get { return _RoomID; }
        set { _RoomID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (RoomID == 1)
        {
            ry_style = " active";
            ry_ds = " style=\"display:block\"";
            ry_ls = " class=\"active\"";
            ry_xs = "";

        }
        if (RoomID == 2)
        {
            ry_style = " active";
            ry_ds = " style=\"display:block\"";
            ry_ls = "";
            ry_xs = " class=\"active\"";

        }
        if (RoomID == 3)
        {
            wz_style = " active";
            wz_ds = " style=\"display:block\"";
            wz_tj = "class=\"active\"";
            wz_list = "";

        }
        if (RoomID == 4)
        {
            wz_style = " active";
            wz_ds = " style=\"display:block\"";
            wz_tj = "";
            wz_list = "class=\"active\"";

        }
        if (RoomID == 5)//学校管理
        {
            school_style = " active";
            school_ds = " style=\"display:block\"";
            school_xx = "class=\"active\"";

        }
        if (RoomID == 6)//校长管理
        {
            school_style = " active";
            school_ds = " style=\"display:block\"";
            school_xz = "class=\"active\"";

        }
        if (RoomID == 7)//老师管理
        {
            school_style = " active";
            school_ds = " style=\"display:block\"";
            school_ls = "class=\"active\"";

        }
        if (RoomID == 8)//学生管理
        {
            school_style = " active";
            school_ds = " style=\"display:block\"";
            school_xs = "class=\"active\"";
        }
        if (RoomID == 9)//添加文章分类
        {
            wz_style = " active";
            wz_ds = " style=\"display:block\"";
            wz_fl = "class=\"active\"";

        }
        if (RoomID == 10)//添加文章列表
        {
            wz_style = " active";
            wz_ds = " style=\"display:block\"";
            wz_list = "class=\"active\"";

        }
        if (RoomID == 11)//量表查看结果
        {
            lb_style = " active";
            lb_ds = " style=\"display:block\"";
            lb_jg = "class=\"active\"";

        }
    }
}