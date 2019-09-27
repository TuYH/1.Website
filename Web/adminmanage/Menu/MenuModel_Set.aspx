<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuModel_Set.aspx.cs" Inherits="adminmanage_Menu_MenuModel_Set" %>
<%@ Import Namespace="HXD.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript" type="text/javascript">
function ClickChecked(id)
{
	if($("IsOpen"+id).checked==false)
	{
		$("IsList"+id).disabled="true";
		$("ListWidth"+id).disabled="true";
		$("Title"+id).disabled="true";
	}
	else
	{
		$("IsList"+id).disabled="";
		$("ListWidth"+id).disabled="";
		$("Title"+id).disabled="";
	}
}
</script>
</head>

<body>
<form id="Form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">

  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">栏目模型设置</td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - 栏目模型设置 | <a href="Menu_Manage.aspx">栏目列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="6" class="redbold">栏目模型设置面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td bgcolor="#EFF1F3"><strong>字段标题</strong></td>
      <td align="center" bgcolor="#EFF1F3"><strong>字段类型</strong></td>
      <td align="center" bgcolor="#EFF1F3"><strong>开启状态</strong></td>
      <td align="center" bgcolor="#EFF1F3"><strong>列表显示</strong></td>
      <td align="center" bgcolor="#EFF1F3"><strong>列表宽度</strong></td>
      <td align="center" bgcolor="#EFF1F3"><strong>重命名标题</strong></td>
    </tr>
    <asp:Repeater ID="DBList" runat="server">
      <itemtemplate>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
          <td width="214"><%#StringDeal.StrFormat(Eval("Title"))%></td>
          <td width="180"><%#FieldType.GetTypeName(Eval("Type"))%></td>
          <td width="80" align="center"><input name="IsOpen" type="checkbox" id="IsOpen<%#Eval("Id")%>" value="<%#Eval("Id")%>"<%#GetMenuFieldState(Eval("Id")," checked='checked'")%> onclick="ClickChecked(<%#Eval("Id")%>);" /></td>
          <td width="80" align="center"><input name="IsList" type="checkbox" id="IsList<%#Eval("Id")%>" value="<%#Eval("Id")%>"<%#GetMenuListState(Eval("Id")," checked='checked'")%> /></td>
          <td width="84" align="center"><input name="ListWidth" type="text" class="input validate-integer" id="ListWidth<%#Eval("Id")%>" size="4" maxlength="2" value="<%#GetMenuListState(Eval("Id"),"")%>" />
            %</td>
          <td width="220" align="center"><input name="Title" type="text" class="input1" id="Title<%#Eval("Id")%>" size="50" maxlength="50" value="<%#GetMenuFieldState(Eval("Id"),"")%>" /></td>
        </tr>
		<script language="javascript" type="text/javascript">ClickChecked(<%#Eval("Id")%>);</script>
      </itemtemplate>
    </asp:Repeater>
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
