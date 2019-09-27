<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTMLOperation.aspx.cs" Inherits="adminmanage_Model_HTMLOperation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css">
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<style type="text/css">.style1{width: 162px;}</style>
</head>
<body>
<div id="edit">
<form id="Form1" runat="server" class="required-validate">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">HTML生成操作</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">HTML生成操作</span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">HTML生成操作</td>
    </tr>
    <tr class="td_bg">
      <td class="style1"><strong>更新全部静态页：</strong></td>
      <td width="574"><asp:Button ID="Button1" runat="server" CssClass="button" Text="生成" 
              onclick="Button1_Click" /></td>
    </tr>
    <tr class="td_bg">
      <td class="style1"><strong>重新生成全部静态页：</strong></td>
      <td><asp:Button ID="Button2" runat="server" CssClass="button" Text="生成" 
              onclick="Button2_Click" /></td>
    </tr>
    <tr class="td_bg">
      <td class="style1"><strong>更新指定分类静态页：</strong></td>
      <td width="574"><asp:DropDownList ID="ClassId" runat="server">
      <asp:ListItem Text="顶级栏目" Value="-1"></asp:ListItem>
          </asp:DropDownList><asp:Button ID="Button3" runat="server" CssClass="button" 
              Text="生成" onclick="Button3_Click" /></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr></tr>
  </table>
  <table width="90%" align="center">
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">&nbsp;</td>
    </tr>
  </table>
 </form>
</div>
</body>
</html>