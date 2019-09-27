<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="adminmanage_Model_UserAdd" %>
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
<form id="Form1" runat="server" class="required-validate">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改模型</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">添加/修改管理员</span> </span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">添加/修改管理员</td>
    </tr>

    <tr class="td_bg">
      <td width="300"><span class="left2"><strong>用户名：</strong></span></td>
      <td width="574"><asp:TextBox ID="username" runat="server" size="20" CssClass="input1 required" maxlength="50"></asp:TextBox>
        </td>
    </tr>
    
    <tr class="td_bg">
      <td><span class="left2"><strong>密码：</strong></span></td>
      <td>
        <asp:TextBox ID="userpwd" CssClass="input required validate-alphanum" runat="server" size="24" maxlength="50" Text="123465"></asp:TextBox></td>
    </tr>
      <tr class="td_bg">
      <td><span class="left2"><strong>昵称：</strong></span></td>
      <td>
        <asp:TextBox ID="Textname" CssClass="input required " runat="server" size="24" maxlength="50"></asp:TextBox></td>
    </tr>
      <tr class="td_bg">
      <td><span class="left2"><strong>联系方式：</strong></span></td>
      <td>
        <asp:TextBox ID="Texttell" CssClass="input required validate-alphanum" runat="server" size="24" maxlength="50"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td><strong>注意事项：</strong></td>
      <td>命名规则：区号+admin  比如：长沙 后台账号：0731admin</td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><asp:Button ID="Button2" runat="server" Text="提 交"  
              class="button" onclick="Button2_Click"/>
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" />
        　
        <input name="Submit23" type="button" value="取 消" class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" onClick="history.back();" />
        
        </td>
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