<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Field_Manage.aspx.cs" Inherits="adminmanage_Model_Field_Manage" %>
<%@ Import Namespace="HXD.Common" %>
<%@ Import Namespace="HXD.ModelField.Common" %>
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
      <td class="title">字段管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">字段列表</span> | <a href="Field_Edit.aspx?TableId=<%=TableId%>" class="red">添加字段</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <tr>
      <td colspan="6" class="redbold">字段列表</td>
    </tr>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <th width="7%" align="center">序号</th>
      <th align="center">字段名称</th>
      <th align="center">字段标题</th>
      <th align="center">字段类型</th>
	  <th align="center">创建日期</th>
      <th align="center">操作</th>
    </tr>
	<asp:Repeater ID="DBList" runat="server"><itemtemplate>
    <tr class="td_bg">
      <td align="center"><%#Eval("Id")%></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("Field"))%></td>
      <td align="center"><%#StringDeal.StrFormat(Eval("Title"))%></td>
      <td align="center"><%#HXD.ModelField.Common.FieldType.GetFieldType(Eval("Type"))%></td>
      <td align="center"><%#StringDeal.GetDateTime(Eval("CreateTime"),"yyyy-MM-dd HH:mm:ss")%></td>
      <td align="center">
	   <a href="?Action=up&Id=<%#Eval("Id")%>&TableId=<%=TableId%>">上移</a>
	   <a href="?Action=down&Id=<%#Eval("Id")%>&TableId=<%=TableId%>">下移</a>
	   <a href="Field_Edit.aspx?Id=<%#Eval("Id")%>&TableId=<%=TableId%>">修改</a>
	   <a onClick="return confirm('确认删除')" href="?Action=del&Id=<%#Eval("Id")%>&TableId=<%=TableId%>">删除</a>
	  </td>
    </tr>
	</itemtemplate></asp:Repeater>
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
