<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logine.aspx.cs" Inherits="adminmanage_Logine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="inc/Title_inc.inc"-->
<link href="skin/01/css/login.css" rel="stylesheet" type="text/css">
</head>
<script language="javascript" type="text/javascript" src="js/prototype.js"></script>
<script language="javascript" type="text/javascript">
function SubCheck()
{
	if ($("tUserName").value=="")
	{
		$("Msg").innerHTML="用户名不能为空！";
		$("tUserName").focus();
		return false;
	}
	if ($("tUserPwd").value=="")
	{
		$("Msg").innerHTML="密码不能为空！";
		$("tUserPwd").focus();
		return false;
	}
    if ($("tCode").value=="")
    {
	    $("Msg").innerHTML="验证码不能为空！";
	    $("tCode").focus();
	    return false;
    }
}
</script>
<body>
<form id="Form1" runat="server" onsubmit="return SubCheck()">
<div id="login">
  <div class="logo"><img src="Skin/01/images/admin_logo.gif" /></div>
  <dl>
    <dt>用户名：</dt>
    <dd>
        <asp:TextBox ID="tUserName" runat="server" CssClass="input" MaxLength="20" onmouseover="this.className='inputa'" onmouseout="this.className='input'"></asp:TextBox></dd><dt>密　码：</dt>
    <dd>
        <asp:TextBox ID="tUserPwd" runat="server" CssClass="input" MaxLength="20" onmouseover="this.className='inputa'" onmouseout="this.className='input'" TextMode="Password"></asp:TextBox><asp:HiddenField
            ID="hidden1" runat="server" />
    </dd>
        
        <dt <%=yinc %>>验证码：</dt>
    <dd <%=yinc %>>
        <asp:TextBox ID="tCode" runat="server" CssClass="input1a" MaxLength="4" onkeyup="this.value=this.value.toUpperCase();" onmouseover="this.className='input1'" onmouseout="this.className='input1a'"></asp:TextBox>
      <div class="yzm"><img src="skin/01/loginimg/CreateValidateImg1.aspx" alt="验证码" name="CodeImg" align="absmiddle" id="CodeImg" /> <span style="cursor:pointer;" onclick="document.getElementById('CodeImg').src = 'skin/01/loginimg/CreateValidateImg1.aspx?'+Math.random()">刷新</span></div>　
      </dd>
	  <dd <%=yinc %>><div id="Msg" style="color:#D70C18; text-align:center;"><%=Msg %></div></dd>
	  </dl>
  <div class="but">
    <input type="image" name="imageField" src="skin/01/images/button.gif" />
    
    　    <img src="skin/01/images/button1.gif" style="cursor:pointer" alt="取消" width="48" height="17" onclick="$('tUserName').value='';$('tUserPwd').value='';$('tCode').value=''" /></div>
</div>
</form>
</body>
</html>