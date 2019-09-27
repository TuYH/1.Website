<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="adminmanage_Advertisement_WebForm1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <base target="_self"/>
</head>
<body>
    <form id="form1" runat="server">
<script language="JavaScript" type="text/javascript">
function send(val){var myObj=window.dialogArguments;myObj.FileStr.value=val;window.close();}
</script>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="6" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" ShowFooter="False" ShowHeader="False" CellSpacing="0">
<ItemTemplate>
    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" style="word-wrap:break-word; overflow:hidden;">
    <tr style="background-color:#DEDFDE">
    <td><%#fileinfos(Eval("Filename").ToString(),Eval("Filetype").ToString()) %></td>
    </tr>
    <tr>
    <td align="center" title="<%#Eval("Name") %>"><%#HXD.Common.StringDeal.Substrings1(Eval("Name").ToString(),14)%></td>
    </tr>
    </table> 
</ItemTemplate>
</asp:DataList>
</form>
</body>
</html>