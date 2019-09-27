using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ascx_left : System.Web.UI.UserControl
{
    protected string ry_style = "", ry_ds = "", ry_ls = "", ry_xs = "",ry_fl="", wz_style = "", wz_ds = "", wz_tj = "", wz_list = "", wz_fl = "";
    protected string school_style = "", school_ds = "", school_xx = "", school_xz = "", school_ls = "", school_xs = "";
    protected string lb_style = "", lb_ds = "", lb_jg = "", lb_tj = "";
    protected string xt_style = "", xt_ds = "", xt_infp = "", xt_banji = "", xt_banji2 = "", xt_glinfo = "", xt_psw = "", msg_style = "", msg_list = "", msg_ds="";
    protected string fd_style = "", fd_ds = "", fd_gt = "", fd_tt = "", fd_sp = "", fd_hh="";
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
        if (RoomID == 12)//系统-学校基本信息
        {
            xt_style = " active";
            xt_ds = " style=\"display:block\"";
            xt_infp = "class=\"active\"";
        }
        if (RoomID == 13)//系统-班级架构
        {
            xt_style = " active";
            xt_ds = " style=\"display:block\"";
            xt_banji = "class=\"active\"";
        }
        if (RoomID == 14)//系统-学校基本信息
        {
            xt_style = " active";
            xt_ds = " style=\"display:block\"";
            xt_infp = "class=\"active\"";
        }
        if (RoomID == 15)//系统-辅导-个人
        {
            fd_style = " active";
            fd_ds = " style=\"display:block\"";
            fd_gt = "class=\"active\"";
        }
        if (RoomID == 16)//系统-辅导-个人
        {
            fd_style = " active";
            fd_ds = " style=\"display:block\"";
            fd_tt = "class=\"active\"";
        }
        if (RoomID == 17)//系统-辅导-沙盘
        {
            fd_style = " active";
            fd_ds = " style=\"display:block\"";
            fd_sp = "class=\"active\"";
        }
        if (RoomID == 18)
        {
            ry_style = " active";
            ry_ds = " style=\"display:block\"";
            ry_fl = " class=\"active\"";
        }
        if (RoomID == 19)
        {
            msg_style = " active";
            msg_ds = " style=\"display:block\"";
            msg_list = " class=\"active\"";
        }
        if (RoomID == 20)//系统-辅导-沙盘
        {
            fd_style = " active";
            fd_ds = " style=\"display:block\"";
            fd_hh = "class=\"active\"";
        }
    }
}