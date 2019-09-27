<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Edit.aspx.cs" Inherits="adminmanage_Admin_Admin_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/prototype_for_validation.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改管理员</td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - 管理员编辑 | <a href="Admin_Manage.aspx">管理员列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">管理员编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>管理组：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="GroupId" runat="server"></asp:DropDownList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>用户名：</strong></span></td>
      <td width="574">&nbsp;<asp:TextBox ID="UserName" runat="server" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>密码：</strong></span></td>
      <td>&nbsp;<asp:TextBox ID="UserPwd" runat="server" CssClass="input1 required validate-length-range-4-20 useTitle" title="密码请输入4-20位有效字符！" MaxLength="400" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>确认密码：</strong></span></td>
      <td>&nbsp;<asp:TextBox ID="UserPwd1" runat="server" CssClass="input1 required validate-equals-UserPwd useTitle" title="确认密码输入有误！" MaxLength="400" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>真实姓名：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TrueName" runat="server" CssClass="input1" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>电话号码：</strong></td>
      <td>&nbsp;<asp:TextBox ID="Tel" runat="server" CssClass="input1" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>电子邮件：</strong></td>
      <td>&nbsp;<asp:TextBox ID="Email" runat="server" CssClass="input1" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否允许修改密码：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsModifyPassword" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否允许多人登录：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsMultiLogin" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><input name="Submit2" type="submit" value="保 存" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
        <input name="Submit23" type="button" value="取 消" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" onclick="history.back();" /></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="35">&nbsp;</td>
    </tr>
  </table>
</div>
<!--编辑部分结束 -->
</form>
</body>
</html>