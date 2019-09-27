<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DB_BackUp.aspx.cs" Inherits="adminmanage_DataBase_DB_BackUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">数据库备份</td>
      <td align="right"  nowrap></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  
  
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="3" class="redbold">数据库备份</td>
    </tr>

    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <th align="center">备份名称</th>
      <th align="center">备份日期</th>
      <th align="center">操作</th>
    </tr>
	<asp:Repeater ID="DBList" runat="server" OnItemCommand="Repeater1_ItemCommand">
	<itemtemplate>
    <tr onMouseOver="over()" onClick="change()" onMouseOut="out()" class="td_bg">
      <td align="center"><%#Eval("Name")%></td>
      <td align="center"><%#Eval("Date")%></td>
      <td align="center"><asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Name")%>' CommandName="down" >下载</asp:LinkButton> <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Name")%>' CommandName="del">删除</asp:LinkButton></td>
    </tr>
	</itemtemplate>
	</asp:Repeater>

  </table>
  
  <asp:Label ID="Message" runat="server" Text=""></asp:Label>
  
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
          <asp:Button ID="MakeBackUp" runat="server" Text="创建新备份" OnClick="NewClick" />
      </td>
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
