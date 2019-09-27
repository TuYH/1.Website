<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateLabelList.aspx.cs" Inherits="adminmanage_TemplateLabel_TemplateLabelList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript" type="text/javascript" src="../js/commen.js"></script>
</head>

<body>
<form runat="server" id="myform">
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">标签管理</td>
      <td align="right" nowrap="nowrap">
      <span class="hui operation">管理导航 - <span class="blue">标签列表</span>
	   | <a href="TemplateLabelAdd.aspx?Page=<%=Pages %>" class="red">添加标签</a>
	   | <asp:LinkButton ID="DelBut" runat="server" CssClass="red" OnClick="DelBut_Click">删除</asp:LinkButton>
       </span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table  align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
        <tr>
        <td colspan="7" class="redbold">标签列表</td>
        </tr>
        <tr class="td_bg">
        <th style="text-align:center;" style="width:8%"><input type="checkbox" onclick="SelectAllCheckboxes(this)" /></th>
        <th style="text-align:center;" style="width:5%" nowrap="nowrap" title="信息ID">Id</th>
        <th style="text-align:center;" style="width:20%">标签说明</th>
        <th style="text-align:center;" style="width:20%">标签名称</th>
        <th style="text-align:center;" style="width:10%">添加时间</th>
        <th style="text-align:center;" style="width:10%">操作</th>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td style="text-align:center;"><input type="checkbox" name="CK_ID" id="CK_ID" value="<%#Eval("id") %>" /></td>
            <td style="text-align:center;"><%# Eval("id")%></td>
            <td title="<%#Eval("labelHelp") %>"><%# HXD.Common.StringDeal.Substrings1(Eval("labelHelp").ToString(), 40)%></td>
            <td title="<%#Eval("labelname") %>"><%# HXD.Common.StringDeal.Substrings1(Eval("labelname").ToString(), 40)%></td>
            <td style="text-align:center;" title="<%# Convert.ToDateTime(Eval("submittime")).ToString("yyyy-MM-dd HH:mm:ss")%>"><%# Convert.ToDateTime(Eval("submittime")).ToString("yyyy-MM-dd")%></td>
            <td style="text-align:center;" nowrap="nowrap">
                <a href='TemplateLabelUpDate.aspx?id=<%#Eval("id") %>&Page=<%=Pages%>'>修改</a>
                <a onclick="JavaScript:return confirm('确定删除此标签吗？')" href='?type=del&id=<%#Eval("id") %>'>删除</a>
            </td>
            </tr>
          </ItemTemplate>
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
      <td height="10">&nbsp;</td>
    </tr>
  </table>
</div>
</form>
</body>
</html>