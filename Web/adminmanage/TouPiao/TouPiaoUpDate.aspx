<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TouPiaoUpDate.aspx.cs" Inherits="adminmanage_TouPiao_TouPiaoUpDate" %>
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
<script type="text/javascript" language="javascript" src="../Js/WdatePicker/WdatePicker.js"></script>
</head>

<body>
<form id="form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加投票</td>
      <td align="right" nowrap="nowrap"><span class="hui operation">管理导航 - 投票编辑 | <a href="TouPiaoList.aspx?Page=<%=Pages %>">投票列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">投票编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>投票信息标题：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TextBox1" CssClass="input1 required" runat="server" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>截止日期：</strong></span></td>
      <td width="574">&nbsp;<input id="Text1" runat="server" type="text" readonly="readonly" class="input1 required" onfocus="WdatePicker({skin:'YcloudRed',lang:'zh-cn',isShowClear:true,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'})" maxlength="50" style="width: 180px"/></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否审核：</strong></td>
      <td>&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" /></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否推荐：</strong></td>
      <td>&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" /></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td>&nbsp;<strong>投票类型：</strong></td>
      <td>&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="0" Text="多选" /><asp:RadioButton ID="RadioButton2" runat="server" GroupName="0" Text="单选" /></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td>&nbsp;<strong>发布时间：</strong></td>
      <td>&nbsp;<asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
        <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" onclick="Button1_Click" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
        <input name="Button2" type="button"value="取 消" onclick="window.location.href='TouPiaoList.aspx?Page=<%=Pages %>'" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
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