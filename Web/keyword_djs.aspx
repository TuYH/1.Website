<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keyword_djs.aspx.cs" Inherits="keyword_djs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        输入关键词：<asp:TextBox 
            ID="TextBox1" runat="server" Width="203px"></asp:TextBox><br />
              输入手机号：<asp:TextBox 
            ID="TextBox2" runat="server" Width="203px"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="生成省级" onclick="Button1_Click" /><br />
        <asp:Button ID="Button2" runat="server" Text="生成地级市" onclick="Button2_Click" /><br />
    
    </div>
    </form>
</body>
</html>
