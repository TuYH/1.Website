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
using System.IO;
using ptw.FileManager.Web.Processor;
public partial class adminmanage_FileManager_Manage_Notepad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (!IsPostBack)
        {
            string filePath = Request.QueryString["objfile"];
            string folderPath = Request.QueryString["objfolder"];
            if (string.IsNullOrEmpty(folderPath))
            {
                if (File.Exists(filePath))
                {
                    string fileContent;
                    string getEncode;
                    new FileManagerProcessor().ReadTextFile(filePath, out fileContent, out getEncode);
                    lblNew.Text = "false";
                    txtFilePath.Text = filePath;
                    txtFileContent.Text = fileContent;
                    ddlEncode.SelectedValue = getEncode;
                }
                else
                {
                    lblMsg.Text = "<script type=\"text/javascript\">alert(\"没有找到文件\");</script>";
                }
            }
            else
            {
                lblNew.Text = "true";
                txtFilePath.Text = folderPath + "\\newText.txt";
                txtFilePath.ReadOnly = false;
                txtFileContent.Text = "在此输入文本内容";
            }
        }
        btnSave.Click += new EventHandler(OnSaveFile);
    }
    /// <summary>
    /// 保存文件
    /// </summary>
    protected void OnSaveFile(object sender, EventArgs e)
    {
        string filePath = txtFilePath.Text;
        string fileContent = txtFileContent.Text;
        string fileEncode = ddlEncode.SelectedValue;
        bool fileNew = Convert.ToBoolean(lblNew.Text);

        if (fileNew)
        {
            if (File.Exists(filePath))
            {
                lblMsg.Text = "<script type=\"text/javascript\">alert(\"新建的文本文档名称目录下已存在\");</script>";
                return;
            }
        }
        lblMsg.Text = new FileManagerProcessor().SaveTextFile(filePath, fileContent, fileEncode);
    }
}
