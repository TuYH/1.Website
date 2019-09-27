using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AJAX_clicks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //<script type="text/javascript">clicks(<%=id %>);</script>
        //function clicks(id){jQuery.get("../AJAX/clicks.aspx",{id:id});};
        if (Request.QueryString["id"] != null)
        {
            int id = HXD.Common.StringDeal.ToInt(Request.QueryString["id"]);
            if (id != 0)
            { HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_Info set Conut=Conut+1 where id=" + id); }
        }
    }
}
