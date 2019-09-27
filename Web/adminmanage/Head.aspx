<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Head.aspx.cs" Inherits="adminmanage_Head" %>
<%@ Import Namespace="HXD.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="inc/Title_Inc.inc"-->
<link href="skin/01/css/head.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="js/target.js"></script>
<script language="javascript" type="text/javascript">
var i=0;
function UpdateLoginTime()
{
    var url = 'inc/CheckMultiLogin.ashx';
	var pars = 'UserName=<%=UserName %>';
	var myAjax = new Ajax.Request(
				url,
				{method: 'get', parameters: pars}
				);
    setTimeout('UpdateLoginTime()',10000);
}
UpdateLoginTime();
</script>
</head>
<body>
<form runat="server">
<div id="header">
    <div id="logo"><img alt="logo" src="skin/01/images/admin_logo.gif" /></div>
    <div id="topmenu">
        <ul>
        <asp:Repeater ID="DBList" runat="server">
        <ItemTemplate>
          <li><a onclick="channelNav(this);" class="<%#Container.ItemIndex==0?"current":""%>" href="Left.aspx?Id=<%#Eval("Id") %>" target="leftFrame" title="<%#Eval("Note") %>"><%#StringDeal.GetSubString(Eval("Title"),14,"") %></a> </li>
        </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
</div>
<div id="nav">
  <div class="left">欢迎 <%=UserName %> 登陆到网站管理系统</div>
  <div class="center"></div>
  <div class="center01"><img src="skin/01/images/icon3.gif" alt="关闭/开放左侧栏" width="11" height="14" /><a class="opened" id="sideswitch" onclick="sideSwitch();" href="javascript:void(null);">关闭左栏侧</a></div>
  <div class="right">
      <ul>
      <li><a href="tencent://Message/?menu=yes&exe=&uin=185164633&websiteName=hongru.com&info=无所谓" target="blank">在线服务</a></li>
      <li><a href="javascript:toolBack();"><img src="skin/01/ico/backward.png" alt="后退" style="padding-bottom:5px;" />后退</a></li>
      <li><a href="javascript:toolForward();"><img src="skin/01/ico/forward.png" alt="前进" style="padding-bottom:5px;" />前进</a></li>
      <li><a href="javascript:toolReload();"><img src="skin/01/ico/refresh.png" alt="刷新" style="padding-bottom:5px;" />刷新</a></li>
      <li runat="server" id="EditPwdId"><a href="admin/EditPwd.aspx" rel="mainframe"><img src="skin/01/ico/home.png" alt="修改密码" style="padding-bottom:5px;" />修改密码</a></li>
      <li><asp:LinkButton ID="OutLoginBt" runat="server" OnClick="OutLoginBt_Click"><img src="skin/01/ico/user_remove.png" alt="退出" style="padding-bottom:5px;" />退出</asp:LinkButton></li>
      </ul>
  </div>
</div>
</form>
</body>
</html>