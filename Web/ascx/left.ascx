<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="ascx_left" %>
<div class="sb1_main">
<ul class="tabs" id="tabs">    

    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <li class="cid_808 "><a href="list.aspx?c=<%#Eval("id")%>"><%#Eval("title")%></a></li>
    </ItemTemplate>
    </asp:Repeater>
</ul>
</div>