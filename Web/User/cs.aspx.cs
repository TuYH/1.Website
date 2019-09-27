using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_cs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "1,2,3,4,39,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,90,91,93,94,0,5,6,7,8,9,11,13,18,19,20,21,22,23,24,25,27,28,29,31,40,41,42,44,53,54,55,58,59,62,63,64,65,67,68,69,88,89,92,95,96";

        int i = str.IndexOf(",0,") +3;
        int ii = str.IndexOf(",0,");
        string stra = str.Substring(i);//0， 后面的字符串
        string strb = str.Substring(0,ii);//,0 前的字符串
        Response.Write(stra+"<br/>");
        Response.Write(strb);
    }
}