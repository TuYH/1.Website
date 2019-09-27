<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TouPiaoList.aspx.cs" Inherits="adminmanage_TouPiao_TouPiaoList" %>
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
      <td class="title">投票管理</td>
      <td align="right" nowrap="nowrap">
      <span class="hui operation">管理导航 - <span class="blue">投票列表</span>
	   | <a href="TouPiaoAdd.aspx?Page=<%=Pages %>" class="red">添加投票</a>
	   | <asp:LinkButton ID="LinkButton1" runat="server" CssClass="red" onclick="LinkButton1_Click">审核</asp:LinkButton>/<asp:LinkButton ID="LinkButton2" runat="server" CssClass="red" onclick="LinkButton2_Click">取消</asp:LinkButton>
	   | <asp:LinkButton ID="LinkButton3" runat="server" CssClass="red" onclick="LinkButton3_Click">推荐</asp:LinkButton>/<asp:LinkButton ID="LinkButton4" runat="server" CssClass="red" onclick="LinkButton4_Click">取消</asp:LinkButton>
	   | <asp:LinkButton ID="DelBut" runat="server" CssClass="red" onclick="DelBut_Click">删除</asp:LinkButton>
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
        <td colspan="8" class="redbold">投票列表</td>
        </tr>
        <tr class="td_bg">
        <th style="text-align:center;" style="width:5%"><input type="checkbox" onclick="SelectAllCheckboxes(this)" /></th>
        <th style="text-align:center;" style="width:30%" nowrap="nowrap">投票信息标题</th>
        <th style="text-align:center;" style="width:10%">发布时间</th>
        <th style="text-align:center;" style="width:10%">截止时间</th>
        <th style="text-align:center;" style="width:5%">审核</th>
        <th style="text-align:center;" style="width:5%">推荐</th>
        <th style="text-align:center;" style="width:10%">详细信息</th>
        <th style="text-align:center;" style="width:5%">操作</th>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td style="text-align:center;"><input type="checkbox" name="CK_ID" id="CK_ID" value="<%#Eval("id") %>" /></td>
            <td style="text-align:center;" title="<%#Eval("title") %>"><%# HXD.Common.StringDeal.Substrings1(Eval("title").ToString(), 40)%></td>
            <td style="text-align:center;" title="<%# Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss")%>"><%# Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd")%></td>
            <td style="text-align:center;" title="<%# Convert.ToDateTime(Eval("end_time")).ToString("yyyy-MM-dd HH:mm:ss")%>"><%# Convert.ToDateTime(Eval("end_time")).ToString("yyyy-MM-dd")%></td>
            <td style="text-align:center;"><%# Eval("is_Examine")%></td>
            <td style="text-align:center;"><%# Eval("is_Recommendation")%></td>
            <td style="text-align:center;">
            <a href='../TouPiao1/SonTouPiaoList.aspx?fid=<%#Eval("id") %>&Page=<%=Pages%>'>投票选项</a>/<a href='../TouPiao1/ResultList.aspx?fid=<%#Eval("id") %>&Page=<%=Pages%>' target="_blank">投票结果</a>
            </td>
            <td style="text-align:center;" nowrap="nowrap">
                <a href='TouPiaoUpDate.aspx?id=<%#Eval("id") %>&Page=<%=Pages%>'>修改</a>
                <a onclick="JavaScript:return confirm('确定删除此投票吗？')" href='?type=del&id=<%#Eval("id") %>'>删除</a>
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