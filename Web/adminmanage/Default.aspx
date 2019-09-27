<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="adminmanage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<html>
<head>
<!--#include file="inc/Title_Inc.inc"-->
<script language="javascript" type="text/javascript">
//function ifr()
//{
//    document.write("<frameset rows=\"130,*\" cols=\"*\" frameborder=\"no\" border=\"0\" framespacing=\"0\">");
//    document.write("<frame src=\"head.aspx\" name=\"topFrame\" scrolling=\"No\" noresize=\"noresize\" id=\"topFrame\" />");
//    document.write("<frameset rows=\"*\" cols=\"215,*\" framespacing=\"0\" frameborder=\"no\" border=\"0\" id=\"mainframeset\">");
//    document.write("<frame src=\"left.aspx\" name=\"leftFrame\" scrolling=\"No\" noresize=\"noresize\" id=\"leftFrame\" />");
//    document.write("<frame src=\"manage.aspx\" scrolling=\"auto\" name=\"mainframe\" id=\"mainframe\" />");
//    document.write("</frameset>");
//    document.write("</frameset>");
//    document.write("</frameset><noframes></noframes>");
//}
</script>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
</head>
<body status="no" scroll="no">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="130" colspan="2" valign="top"><iframe border="0" width="100%" name="topFrame" id="topFrame" height="100%" frameborder="0" src="head.aspx"></iframe></td>
  </tr>
  <tr>
    <td width="215" valign="top" style="display:" id="leftFrameId"><iframe width="100%" name="leftFrame" id="leftFrame" SCROLLING="auto" frameborder="0" src="left.aspx"></iframe></td>
    <td valign="top"><iframe width="100%" name="mainframe" id="mainframe" frameborder="0" src="manage.aspx"></iframe></td>
  </tr>
</table>
<script>
document.getElementById("leftFrame").height=Math.max(document.documentElement.scrollHeight,document.documentElement.clientHeight)-130;
document.getElementById("mainframe").height=Math.max(document.documentElement.scrollHeight,document.documentElement.clientHeight)-130;</script>
</body>
</html>
