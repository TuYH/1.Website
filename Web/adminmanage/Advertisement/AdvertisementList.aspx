<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvertisementList.aspx.cs" Inherits="adminmanage_Advertisement_AdvertisementList" %>
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
      <td class="title">广告管理</td>
      <td align="right" nowrap="nowrap">
      <span class="hui operation">管理导航 - <span class="blue">广告列表</span>
	   | <a href="AdvertisementAdd.aspx?Page=<%=Pages %>" class="red">添加广告</a>
	   | <asp:LinkButton ID="DelBut" runat="server" CssClass="red" OnClick="DelBut_Click">删除</asp:LinkButton>
       | <asp:LinkButton ID="StatusBut" runat="server" CssClass="red" OnClick="StatusBut_Click" Text="审核" /><span class="red">/</span><asp:LinkButton ID="unStatusBut" runat="server" CssClass="red" OnClick="unStatusBut_Click" Text="关闭" />
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
        <td colspan="7" class="redbold">广告列表</td>
        </tr>
        <tr class="td_bg">
        <th style="text-align:center;" style="width:8%"><input type="checkbox" onclick="SelectAllCheckboxes(this)" /></th>
        <th style="text-align:center;" style="width:5%" nowrap="nowrap" title="信息ID">Id</th>
        <th style="text-align:center;" style="width:30%">广告名称</th>
        <th style="text-align:center;" style="width:8%">广告类型</th>
        <th style="text-align:center;" style="width:10%">添加时间</th>
        <th style="text-align:center;" style="width:8%" nowrap="nowrap" title="锁定状态">状态</th>
        <th style="text-align:center;" style="width:10%">操作</th>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td style="text-align:center;"><input type="checkbox" name="CK_ID" id="CK_ID" value="<%#Eval("id") %>" /></td>
            <td style="text-align:center;"><%#Eval("id") %></td>
            <td title="<%#Eval("AdName") %>"><%# HXD.Common.StringDeal.Substrings1(Eval("AdName").ToString(), 40)%></td>
            <td style="text-align:center;"><%# adtype(Eval("type").ToString())%></td>
            <td style="text-align:center;" title="<%# Convert.ToDateTime(Eval("submittime")).ToString("yyyy-MM-dd HH:mm:ss")%>"><%# Convert.ToDateTime(Eval("submittime")).ToString("yyyy-MM-dd")%></td>
            <td style="text-align:center;" nowrap="nowrap"><%# Convert.ToBoolean(Eval("isqiyong")) ? "<img src='../Skin/01/ico/yes.gif' />" : "<img src='../Skin/01/ico/no.gif' />"%></td>
            <td nowrap="nowrap">
                <a href='javascript:void(0);' onclick="window.open('JSCode.aspx?id=<%#Eval("id") %>','脚本代码','height=1px,width=380px,top=450,left=450,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no')">获取代码</a>
                <a href='Preview.aspx?id=<%#Eval("id") %>' target="_blank">预览</a>
                <a href='AdvertisementUpDate.aspx?id=<%#Eval("id") %>&Page=<%=Pages%>'>修改</a>
                <a onclick="JavaScript:return confirm('确定删除此广告吗？')" href='?type=del&id=<%#Eval("id") %>'>删除</a>
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