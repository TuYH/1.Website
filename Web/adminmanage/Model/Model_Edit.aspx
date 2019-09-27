<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="Model_Edit.aspx.cs" Inherits="adminmanage_Model_Model_Edit" %>
<%@ Import Namespace="HXD.Common" %>
<html>
<head>
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script type="text/javascript" language="javascript" src="../../js/lhgdialog/lhgdialog.js"></script>
<script language="javascript" type="text/javascript" src="../js/Upload.js"></script>
<script language="javascript" type="text/javascript" src='../../WebEditor/fckeditor.js'></script>
</head>
<body>
<form id="Form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加</td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - <span class="blue">编辑</span> | <a href="Model_Manage.aspx?MenuId=<%=MenuId %>">列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" style="display:none;">
      <td><strong>栏目选择：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="ClassId" runat="server">
      <asp:ListItem Text="顶级栏目"></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
	<asp:Repeater ID="DBList" runat="server"><itemtemplate>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="130"><strong><%#GetFieldTitle(Eval("Name"),Eval("Title"))%>：</strong></td>
      <td><%#HXD.ModelField.Common.FieldType.GetType(ModelReader(Eval("Name").ToString()), xml, Eval("Name"), MenuId)%></td>
    </tr>
	</itemtemplate></asp:Repeater>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
          <td style="color:Red;"><strong>注意事项：</strong></td>
          <td style="color:Red;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
        </tr>
    </asp:Panel>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><input name="Submit2" type="submit" value="保 存" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        <input name="Submit23" type="button" value="取 消" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" onclick="history.back();" /></td>
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