<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu_Manage.aspx.cs" Inherits="adminmanage_Menu_Menu_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form name="myform" method="post" action="User_Manage.aspx" id="myform">
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
<script type="text/javascript">
//<![CDATA[
    var theForm = document.forms['myform'];
    if (!theForm) {
        theForm = document.myform;
    }
    function __doPostBack(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.__EVENTTARGET.value = eventTarget;
            theForm.__EVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
//]]>
</script>
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title"><%=MenuTitle%>管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue"><%=MenuTitle%>列表</span> | <a href="Menu_Edit.aspx?MenuId=<%=MenuId %>" class="red">添加<%=MenuTitle%></a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    
	<asp:Label ID="MenuListLabel" runat="server"></asp:Label>

  </table>
  <table width="90%" align="center">
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