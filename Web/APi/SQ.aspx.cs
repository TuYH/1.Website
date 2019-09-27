using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;

public partial class APi_SQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
            TextBox1.Text = strID;
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "update  tb_Admin set Email='" + TextBox1.Text + "' where id=1";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        Response.Write("授权成功！");
    }
}