<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Table_Edit.aspx.cs" Inherits="adminmanage_Model_Table_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
</head>

<body>
<div id="edit">
<form runat="server" class="required-validate">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改模型</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">添加/修改模型</span> | <a href="Table_Manage.aspx" class="red">模型列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">添加/修改模型</td>
    </tr>
    <tr class="td_bg">
      <td width="300"><span class="left2"><strong>模型类型：</strong></span></td>
      <td width="574">
          <asp:DropDownList ID="Type" runat="server">
          <asp:ListItem Value="0" Text="常规模型"></asp:ListItem>
          <asp:ListItem Value="1" Text="会员模型"></asp:ListItem>
          </asp:DropDownList>
        </td>
    </tr>
    <tr class="td_bg">
      <td width="300"><span class="left2"><strong>模型名称：</strong></span></td>
      <td width="574"><asp:TextBox ID="Title" runat="server" size="20" CssClass="input1 required" maxlength="50"></asp:TextBox>
        </td>
    </tr>
    
    <tr class="td_bg">
      <td><span class="left2"><strong>表名称：</strong></span></td>
      <td>tb_U_
        <asp:TextBox ID="TableName" CssClass="input required validate-alphanum" runat="server" size="24" maxlength="50"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td><strong>模型描述：</strong></td>
      <td><asp:TextBox ID="Note" CssClass="input" cols="90" rows="5" runat="server" TextMode="MultiLine" Width="344px"></asp:TextBox></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><input name="Submit2" type="submit" value="保 存" class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" />
        　
        <input name="Submit23" type="button" value="取 消" class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" onClick="history.back();" /></td>
    </tr>
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
