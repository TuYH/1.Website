<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Table_Manage.aspx.cs" Inherits="adminmanage_Model_Table_Manage" %>
<%@ Import Namespace="HXD.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css">
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">模型管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">模型列表</span> | <a href="Table_Edit.aspx" class="red">添加模型</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <tr>
      <td colspan="7" class="redbold">模型列表</td>
    </tr>
    <tr class="td_bg">
      <th align="center">序号</th>
      <th align="center">项目名称</th>
      <th align="center">表名称</th>
      <th align="center">项目描述</th>
      <th align="center">创建时间</th>
      <th align="center">操作</th>
    </tr>
    <asp:Repeater ID="DBList" runat="server"><ItemTemplate>
    <tr class="td_bg">
      <td align="center"><%#Eval("Id") %></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("Title")) %></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("TableName")) %></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("Note")) %></td>
      <td align="center"><%#StringDeal.GetDateTime(Eval("CreateTime"),"yyyy-MM-dd") %></td>
      <td align="center">
	   <a href="Field_Manage.aspx?TableId=<%#Eval("Id") %>">字段管理</a>
	   <a href="Table_Edit.aspx?Id=<%#Eval("Id") %>">修改</a>
	   <a onClick="return confirm('确认删除')" href="?Action=del&Id=<%#Eval("Id") %>">删除</a></td>
    </tr>
    </ItemTemplate></asp:Repeater>
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