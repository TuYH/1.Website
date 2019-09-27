<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="adminmanage_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="inc/Title_Inc.inc"-->
<link href="skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
.drag_div {
	background-color: #C01818;
	color:#FFFFFF;
	margin:10px auto;
	padding:5px;
}
-->
</style>
<script language="C#" runat="server">
new public void Page_Load(Object sender,EventArgs e)
{
	Response.Expires = 0;
	Response.CacheControl = "no-cache";
	if (!Page.IsPostBack)
	{
		 //取得页面执行开始时间
         DateTime stime=DateTime.Now;
		 
		 int build, major, minor,revision;
		 build=Environment.Version.Build;
		 major=Environment.Version.Major;
		 minor=Environment.Version.Minor;
		 revision=Environment.Version.Revision;

		 name.Text=Server.MachineName;
		 ip.Text=Request.ServerVariables["LOCAL_ADDR"];
		 domain.Text=Request.ServerVariables["SERVER_NAME"];
		 port.Text=Request.ServerVariables["SERVER_PORT"];
		 ontime.Text=DateTime.Now.ToString();
		 lan.Text=Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
		 cpuqty.Text=System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
		 cpumore.Text=System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
		 system.Text=Environment.OSVersion.ToString();
		 dotnet.Text=".NET CLR  "+major +"."+ minor + "." + build+"."+revision;
		 
		 user.Text=Environment.UserName;
		 sysdir.Text=System.Environment.GetEnvironmentVariable("windir");
		 systmp.Text=System.Environment.GetEnvironmentVariable("TEMP");
		 mem.Text=(Environment.WorkingSet/1024/1024).ToString()+" MB";
		 atdomain.Text=System.Environment.GetEnvironmentVariable("USERDOMAIN");
		 
		 
		 SSL.Text=Request.ServerVariables["HTTPS"];
		 CGI.Text=Request.ServerVariables["GATEWAY_INTERFACE"];
		 IIS.Text=Request.ServerVariables["SERVER_SOFTWARE"];		 
		 timeout.Text=Server.ScriptTimeout.ToString();
		 path.Text=Request.ServerVariables["APPL_PHYSICAL_PATH"];
		 pathinfo.Text=Request.ServerVariables["PATH_TRANSLATED"].Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"],"");
		 

		 //组件支持验证代码
    	 this.check("MSWC.AdRotator",adrot);
		 this.check("MSWC.BrowserType",brow);
		 this.check("MSWC.NextLink",next);
		 this.check("MSWC.Tools",tool);
		 this.check("AMSWC.Status",stat);
		 this.check("MSWC.Counters",coun);
		 this.check("IISSample.ContentRotator",cont);
		 this.check("IISSample.PageCounter",pagec);
		 this.check("MSWC.PermissionChecker",perm);
		 this.check("Scripting.FileSystemObject",fso);
		 this.check("ADODB.RecordSet",adodb);
		 
		 this.check("SoftArtisans.FileUp",saup);
		 this.check("SoftArtisans.FileManager",arup);
		 this.check("LyfUpload.UploadFile",lyup);
		 this.check("Persits.Upload",aspup);
		 this.check("W3.Upload",w3up);  
		   	 
		 this.check("JMail.SMTPMail",jmail);
		 this.check("CDONTS.NewMail",cdon);
		 this.check("Persits.MailSender",pers);
		 this.check("SMTPsvg.Mailer",smtp);
		 this.check("dkQmail.Qmail",qmail);
		 this.check("Geocel.Mailer",mailer);
		 this.check("iismail.iismail.1",iismail);
		 this.check("SmtpMail.SmtpMail.1",smtpmail);
		 
		 this.check("SoftArtisans.ImageGen",saimg);
		 this.check("W3Image.Image",w3img);

	 
		 //取得页面执行结束时间
 		 DateTime etime=DateTime.Now; 

		 //100万次相加循环测试
		DateTime ontime1=DateTime.Now;
		int sum=0;
		for (int i=1;i<=10000000;i++){
		sum=sum+i;
		}
		DateTime endtime1=DateTime.Now;

		//100万次开平方测试
		DateTime ontime2=DateTime.Now;
		long k=2;
		for( int a=1; a < 1000000; a++ )
		{
			 k = k * k;
		}
		DateTime endtime2=DateTime.Now;

		
	}
}
bool isobj(string obj){
    try {
        object meobj = Server.CreateObject(obj);
        return(true);
     }
     catch 
     {
        return(false);
     }
}

void check(string obj,Label sup)
	{
		string yes="<font class=fonts1><b>√</b></font>";
		string no="<font color=red><b>×</b></font>";
		try 
		{
			object claobj = Server.CreateObject(obj);
			sup.Text=yes;
		 }
		catch
		{
			sup.Text=no;
		}
	}
</script>
<script type="text/javascript" language="javascript" src="js/prototype.js"></script>
<script type="text/javascript" language="javascript" src="js/drag.js"></script>
<script type="text/javascript" language="javascript" src="js/google_drag.js"></script>
</head>
<body>
<table width="90%" border="0" align="center" cellpadding="5" cellspacing="0">
  <tr>
    <td colspan="2" align="center" valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top"><div style="background-color:#C01818;color:#FFFFFF;"><strong>服务器信息</strong></div></td>
  </tr>
  <tr>
    <td valign="top" width="50%">

	<div id="drag_1" class="drag_div">
		<div id="drag_1_h" class="drag_header"> 服务器的基本参数</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
        <tr>
          <td width="29%" bgcolor="#FFFFFF">服务器名</td>
          <td width="71%" bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="name" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器IP</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="ip" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器域名</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="domain" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器端口</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="port" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器时间</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="ontime" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器语言</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="lan" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器CPU数量</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="cpuqty" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器CPU结构</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="cpumore" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">服务器操作系统</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="system" runat="server" />            
          </td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">DotNET引擎版本</td>
          <td bgcolor="#FFFFFF"><font size="2">
            <asp:label ID="dotnet" runat="server" />            
          </td>
        </tr>
      </table>
	</div>
	<div id="drag_2" class="drag_div">
		<div id="drag_2_h" class="drag_header">服务器的其它参数</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
          <tr>
            <td width="29%" bgcolor="#FFFFFF">当前执行用户</td>
            <td width="312" bgcolor="#FFFFFF">
                  <asp:label ID="user" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">系统安装目录</td>
            <td bgcolor="#FFFFFF">
                  <asp:Label ID="sysdir" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">系统临时目录</td>
            <td bgcolor="#FFFFFF">
                  <asp:Label ID="systmp" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">IIS版本</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="IIS" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">SSL支持</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="SSL" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">CGI版本</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="CGI" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">脚本超时时间</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="timeout" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">系统运行时间</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="runtime" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">当前文件目录</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="path" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">当前文件位置</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="pathinfo" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">已使用内存</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="mem" runat="server" />                
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">主机所在域</td>
            <td bgcolor="#FFFFFF">
                  <asp:label ID="atdomain" runat="server" />                
</td>
          </tr>
        </table>
	  </div>
	<div id="drag_3" class="drag_div">
		<div id="drag_3_h" class="drag_header">常见的图像处理组件</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
          <tr>
            <td width="84%" bgcolor="#FFFFFF">SoftArtisans.ImageGen (SA 的图像读写组件)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="saimg" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">W3Image.Image (Dimac 的图像读写组件)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="w3img" runat="server" />            
</td>
          </tr>
        </table>
	</div>
</td>
    <td valign="top" width="50%">

	<div id="drag_11" class="drag_div">
		<div id="drag_11_h" class="drag_header">IIS自带的常用组件</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
          <tr>
            <td width="84%" bgcolor="#FFFFFF">MSWC.AdRotator</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="adrot" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.BrowserType</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="brow" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.NextLink</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="next" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.Tools</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="tool" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.Status</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="stat" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.Counters</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="coun" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">IISSample.ContentRotator</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="cont" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">IISSample.PageCounter</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="pagec" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">MSWC.PermissionChecker</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="perm" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">Scripting.FileSystemObject (FSO 文本文件读写)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="fso" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">Adodb.Connection (ADO 数据对象)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="adodb" runat="server" />            
</td>
          </tr>
        </table>
	</div>
	<div id="drag_12" class="drag_div">
		<div id="drag_12_h" class="drag_header">常见的文件上传组件</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
        <tr>
          <td width="84%" bgcolor="#FFFFFF">SoftArtisans.FileUp (SA-FileUp 文件上传)</td>
          <td align="left" bgcolor="#FFFFFF">
            <asp:label ID="saup" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">SoftArtisans.FileManager (SoftArtisans 文件管理)</td>
          <td align="left" bgcolor="#FFFFFF">
            <asp:label ID="arup" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">LyfUpload.UploadFile (刘云峰的文件上传组件)</td>
          <td align="left" bgcolor="#FFFFFF">
            <asp:label ID="lyup" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">Persits.Upload.1 (ASPUpload 文件上传)</td>
          <td align="left" bgcolor="#FFFFFF">
            <asp:label ID="aspup" runat="server" />          
</td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">w3.upload (Dimac 文件上传)</td>
          <td align="left" bgcolor="#FFFFFF">
            <asp:label ID="w3up" runat="server" />          
</td>
        </tr>
      </table>
	</div>
	<div id="drag_13" class="drag_div">
		<div id="drag_13_h" class="drag_header">常见的邮件收发组件</div>
		<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#C74949" class="hui">
          <tr>
            <td width="84%" bgcolor="#FFFFFF">JMail.SmtpMail (Dimac JMail 邮件收发)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="jmail" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">CDONTS.NewMail (虚拟 SMTP 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="cdon" runat="server" />            
&nbsp;<font color="red">&nbsp;</font></td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">Persits.MailSender (ASPemail 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="pers" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">SMTPsvg.Mailer (ASPmail 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="smtp" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">DkQmail.Qmail (dkQmail 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="qmail" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">Geocel.Mailer (Geocel 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="mailer" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">IISmail.Iismail.1 (IISmail 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="iismail" runat="server" />            
</td>
          </tr>
          <tr>
            <td bgcolor="#FFFFFF">SmtpMail.SmtpMail.1 (SmtpMail 发信)</td>
            <td align="left" bgcolor="#FFFFFF">
              <asp:label ID="smtpmail" runat="server" />            
</td>
          </tr>
        </table>
	  </div>
</td>
  </tr>
</table>

<script type="text/javascript">
window.onload = function(){initDrag();}
</script>
</body>
</html>