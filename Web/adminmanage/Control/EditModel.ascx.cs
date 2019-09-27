using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HXD.Common;
using HXD.Model;
using HXD.BLL;

public partial class adminmanage_Control_EditModel : System.Web.UI.UserControl
{
    protected HXD.ModelField.Model.Model mm = new HXD.ModelField.Model.Model();
    protected HXD.ModelField.BLL.Model bm = new HXD.ModelField.BLL.Model();
    protected DataSet dsReader;
    protected XmlDoc xml;
    protected string[] Arry;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
