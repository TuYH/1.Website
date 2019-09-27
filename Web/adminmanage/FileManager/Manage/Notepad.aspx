<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notepad.aspx.cs" Inherits="adminmanage_FileManager_Manage_Notepad" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="author" content="TakWai" />
    <title>文件管理</title>
    <link rel="stylesheet" type="text/css" href="../Style/Manage/Style.css" />
    <link rel="stylesheet" type="text/css" href="../Style/Manage/Layout.css" />
    <style type="text/css">
        body
        {
            width: 670px;
            padding: 10px;
            text-align: left;
        }
    </style>
</head>
<body>
<form id="notepadForm" runat="server">
<div id="notepad-frame">
<div class="box">
    <div id="notepad-title">
        文件路径: <asp:TextBox ID="txtFilePath" runat="server" ReadOnly="true" onfocus="this.className='colorfocus'" onblur="this.className='txt';" CssClass="txt" style="width: 300px;"></asp:TextBox>
        &nbsp;文件编码: <asp:DropDownList ID="ddlEncode" runat="server"><asp:ListItem Value="ANSI">ANSI</asp:ListItem>
            <asp:ListItem Value="UTF-8">UTF-8</asp:ListItem>
            <asp:ListItem Value="Unicode">Unicode</asp:ListItem>
            <asp:ListItem Value="Unicode big endian">Unicode-be</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" />&nbsp;&nbsp;<input type="button" name="close" value="关闭" class="btn" onclick="parent.hidePopWin(false);" />
    </div>
    
    <div id="notepad-content">
        <asp:TextBox ID="txtFileContent" TextMode="MultiLine" runat="server" onfocus="this.className='colorfocus'" onblur="this.className='txt';" class="txt" style="width: 600px; height: 260px; overflow-y: auto; overflow-x: hidden;" ></asp:TextBox>
    </div>
    
    <asp:Label ID="lblMsg" runat="Server"></asp:Label>
    <asp:Label ID="lblNew" runat="server" style="display: none;"></asp:Label>
</div>    
</div>
</form>
</body>
</html>