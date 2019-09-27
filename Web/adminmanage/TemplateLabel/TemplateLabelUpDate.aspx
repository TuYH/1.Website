<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="TemplateLabelUpDate.aspx.cs" Inherits="adminmanage_TemplateLabel_TemplateLabelUpDate" %>
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
<script language="javascript" type="text/javascript" src='../../WebEditor/fckeditor.js'></script>
</head>

<body>
<form id="form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">修改标签</td>
      <td align="right" nowrap="nowrap"><span class="hui operation">管理导航 - 标签编辑 | <a href="AdvertisementList.aspx?Page=<%=Pages %>">标签列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">标签编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>标签说明：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TextBox1" CssClass="input1 required" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>标签名称：</strong></span></td>
      <td width="574">&nbsp;<asp:TextBox ID="TextBox2" CssClass="input1 required" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>文件名称：</strong></td>
      <td>&nbsp;~/<asp:TextBox ID="TextBox3" CssClass="input1 required" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>模板内容：</strong></td>
      <td>&nbsp;<input type="hidden" id="Content" runat="server" name="Content" value="" /><iframe id="Content___Frame" src="/WebEditor/editor/fckeditor.html?InstanceName=Content&amp;Toolbar=Default" width="580" height="400" frameborder="no" scrolling="no"></iframe></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>添加时间：</strong></td>
      <td>&nbsp;<asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
        <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" onclick="Button1_Click" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
        <input name="Button2" type="button"value="取 消" onclick="window.location.href='TemplateLabelList.aspx?Page=<%=Pages %>'" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
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