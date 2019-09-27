<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroup_Manage.aspx.cs" Inherits="adminmanage_User_UserGroup_Manage" %>

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
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">用户组管理</td>
      <td align="right" nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">组列表</span> | <a href="UserGroup_Edit.aspx" class="red">添加组</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <tr>
      <td colspan="5" class="redbold">用户组列表</td>
    </tr>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <th width="7%" align="center">序号</th>
      <th width="22%" align="center">组名称</th>
      <th width="22%" align="center">所属模型</th>
      <th width="21%" align="center">用户数量</th>
      <th width="28%" align="center">操作</th>
    </tr>
    <%GetUserGroupList(0); %>
  </table>
  <table width="90%" align="center">
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">&nbsp;</td>
    </tr>
  </table>
</div>
</body>
</html>
