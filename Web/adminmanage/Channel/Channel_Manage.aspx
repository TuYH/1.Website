<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Channel_Manage.aspx.cs" Inherits="adminmanage_Channel_Channel_Manage" %>
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
      <td class="title">频道管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">频道列表</span> | <a href="Channel_Edit.aspx" class="red">添加频道</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <tr>
      <td colspan="4" class="redbold">频道列表</td>
    </tr>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <th width="7%" align="center">序号</th>
      <th width="22%" align="center">频道名称</th>
      <th width="43%" align="center">频道说明</th>
      <th width="28%" align="center">操作</th>
    </tr>
    <%GetChannelList(0); %>
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
