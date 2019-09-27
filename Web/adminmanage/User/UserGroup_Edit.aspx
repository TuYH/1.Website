<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroup_Edit.aspx.cs" Inherits="adminmanage_User_UserGroup_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改用户组</td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - 用户组编辑 | <a href="UserGroup_Manage.aspx">用户组列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">用户组编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>组名称：</strong></span></td>
      <td width="574">
          &nbsp;<asp:TextBox ID="Title" runat="server" CssClass="input1 required" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>组说明：</strong></span></td>
      <td>
          &nbsp;<asp:TextBox ID="Note" runat="server" CssClass="input1" MaxLength="400" 
              Height="55px" TextMode="MultiLine" Width="343px"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>父级组：</strong></span></td>
      <td>
          &nbsp;<asp:DropDownList ID="ParentId" runat="server">
            <asp:ListItem Value="0" Text="顶级用户组"></asp:ListItem>
          </asp:DropDownList>
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>用户组模型：</strong></td>
        <td>
          &nbsp;<asp:DropDownList ID="Model" runat="server">
        <asp:ListItem Value="0" Text="选择模型"></asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>注册获得积分数：</strong></td>
        <td>
          &nbsp;<asp:TextBox ID="RegIntegral" runat="server" CssClass="input1 required" MaxLength="6"></asp:TextBox>
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>登陆获得积分数：</strong></td>
        <td>
          &nbsp;<asp:TextBox ID="LoginIntegral" runat="server" CssClass="input1 required" MaxLength="6"></asp:TextBox>
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>最多可收藏信息数：</strong></td>
        <td>
          &nbsp;<asp:TextBox ID="Collection" runat="server" CssClass="input1 required" MaxLength="8"></asp:TextBox> （如果为0，则不限制，-1为没有收藏权限） 
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>激请用户注册获得积分数：</strong></td>
        <td>
          &nbsp;<asp:TextBox ID="Invite" runat="server" CssClass="input1 required" MaxLength="6"></asp:TextBox>
        </td>
    </tr>
    <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
        <td>
          <strong>注册默认审核状态：</strong></td>
        <td>
          &nbsp;<asp:RadioButtonList ID="RegState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1" Text="是"></asp:ListItem>
            <asp:ListItem Value="0" Text="否" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
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