<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Manage.aspx.cs" Inherits="Adminmanage_User_User_manage" %>
<%@ Import Namespace="HXD.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form id="myform" runat="server">
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">用户管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">用户列表</span>
       | <a href="User_Edit.aspx?GroupId=1" id="InsertId" runat="server" class="red">添加用户</a>
       | <asp:LinkButton ID="DelBut" runat="server" CssClass="red" OnClick="DelBut_Click" OnClientClick="return confirm('确认删除');">批量删除</asp:LinkButton>
       | <asp:LinkButton ID="LockBut" runat="server" CssClass="red" OnClick="LockBut_Click">批量锁定</asp:LinkButton>
       | <asp:LinkButton ID="unLockBut" runat="server" CssClass="red" OnClick="unLockBut_Click">批量解锁</asp:LinkButton></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <tr>
      <td colspan="10" class="redbold"><asp:Literal ID="GroupTitle" runat="server"></asp:Literal>列表</td>
    </tr>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <th align="center"><input type="checkbox" onClick="check();" /></th>
      <th align="center">ID</th>
      <th align="center">用户名</th>
      <th align="center">密码</th>
      <th align="center">所属用户组</th>
      <th align="center">最后登陆时间</th>
      <th align="center">登陆次数</th>
      <th align="center">最后登陆IP</th>
      <th align="center">操作</th>
    </tr>
	<asp:Repeater ID="DBList" runat="server">
	<itemtemplate>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <td align="center"><input type="checkbox" name="Id" value="<%#Eval("Id")%>" /></td>
      <td align="center"><%#Eval("Id")%></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("UserName")) %></td>
      <td align="center"><%#Encryp.DESDecrypt(Eval("UserPwd"))%></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("GroupTitle")) %></td>
      <td align="center"><%#StringDeal.GetDateTime(Eval("LastLoginTime"),"yyyy-MM-dd HH:mm:ss") %></td>
      <td align="center"><%#Eval("LoginTimes") %></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("LastLoginIP")) %></td>
      <td align="center"><a href="?Action=lock&GroupId=<%#Eval("GroupId") %>&Id=<%#Eval("Id")%>"><%#StringDeal.GetLock(Eval("IsLock"),"用户")%></a> <a href="User_Edit.aspx?GroupId=<%#Eval("GroupId") %>&Id=<%#Eval("Id")%>">修改</a> <a onclick="return confirm('确认删除');" href="?Action=del&GroupId=<%#Eval("GroupId") %>&Id=<%#Eval("Id")%>">删除</a></td>
    </tr>
	</itemtemplate>
	</asp:Repeater>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">
        <asp:Label ID="PageView" runat="server" />      
      </td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">
              
      </td>
    </tr>
  </table>
</div>
</form>
</body>
</html>

