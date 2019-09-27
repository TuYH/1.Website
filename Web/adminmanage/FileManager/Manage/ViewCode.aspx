<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCode.aspx.cs" Inherits="adminmanage_FileManager_Manage_ViewCode" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>代码查看</title>
<link type="text/css" rel="stylesheet" href="../Client/SyntaxHighlighter/Styles/SyntaxHighlighter.css"></link>
<script language="javascript" src="../Client/SyntaxHighlighter/Scripts/shCore.js"></script>
<script language="javascript" src="../Client/SyntaxHighlighter/Scripts/<%= highLighterJs %>"></script>
<style type="text/css">
body
{
    margin: 0px;
    background-color: #F7F3F7;
    font-size: 9pt;
    font-family: Tahoma, Verdana, Arial, "新宋体", "宋体";
}
</style> 
</head>
<body>
<form id="Form1" runat="server">
    <asp:TextBox ID="txtHighLighter" TextMode="MultiLine" runat="server" style="width: 300px;">
    </asp:TextBox>
</form>
<script language="javascript">
    dp.SyntaxHighlighter.HighlightAll('txtHighLighter');
</script>
</body>
</html>