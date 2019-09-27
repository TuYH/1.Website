using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.Model;
using HXD.BLL;
using HXD.Common;

public partial class adminmanage_Model_Inc_Validate_Sort : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Model = Request.QueryString["Model"];
        int Id = StringDeal.ToInt(Request.QueryString["Id"]);
        int Sort = StringDeal.ToInt(Request.QueryString["Sort"]);
        HXD.ModelField.BLL.Model mm = new HXD.ModelField.BLL.Model();
        mm.ModelSort(Id, Model, Sort);
    }
}
