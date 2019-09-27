<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="adminmanage_Left" %>
<%@ Import Namespace="HXD.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="inc/Title_Inc.inc"-->
<link href="skin/01/css/left.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="js/target.js"></script>
<script language="javascript" type="text/javascript">
function tree(strTreename)
{
	var ParentUl = $('ulmenu').getElementsByTagName('ul');
	var ParentImg = $('ulmenu').getElementsByTagName('img');
	for (i=0; i<ParentUl.length; i++)
	{
		ParentUl[i].style.display="none";
		$("A"+(ParentUl[i].id)).style.color="#4B4B4B";
		if(ParentUl[i].innerHTML!="")
		{
			ParentImg[i].src="images/fold.gif";
		}
	}
	$(strTreename).style.display="";
	$("Pic" + strTreename).src="images/open.gif";
	$("A"+strTreename).style.color="#BA1313";
}

function clickmenu(str)
{
	var ula = $('ulmenu').getElementsByTagName('a');
	for (k=0; k<ula.length; k++)
	{
		ula[k].style.color="#4B4B4B";
	}
	$(str).style.color="#BA1313";
}
</script>
</head>
<body>
<div id="main">
<!--左侧部开始 -->
<div id="left">
    <h3><%=Titles%></h3>
    <div class="menu">
        <ul id="ulmenu">
        <asp:Repeater ID="DBList" runat="server"><ItemTemplate>
          <li><img src="images/<%#GetChannelIco(Eval("Id")) %>.gif" alt="展开关闭" style="padding-bottom:1px; text-align:inherit;" id="Pic_<%#Eval("Id") %>" /> <a href="<%#Eval("Url") %>" style="font-weight:bold;" id="A_<%#Eval("Id")%>" onclick="tree('_<%#Eval("Id")%>')" title="<%#Eval("Note") %>" rel="<%#Eval("Target") %>"><%#Eval("Title") %></a></li>
            <ul style="display:none; list-style-image:url(images/list.gif);" id="_<%#Eval("Id") %>">
            <asp:Repeater ID="DBList" runat="server" DataSource='<%#SubList(Eval("Id")) %>'><ItemTemplate>
                <li><a href="<%#StringDeal.StrFormat(Eval("Url")) %>" rel="<%#Eval("Target") %>" title="<%#StringDeal.StrFormat(Eval("Title")) %>" id='m<%#Eval("Id") %>' onclick="clickmenu('m<%#Eval("Id") %>')"><%#StringDeal.StrFormat(Eval("Title")) %></a></li>
            </ItemTemplate></asp:Repeater>
            </ul>
        </ItemTemplate></asp:Repeater>
        </ul>
    </div>
<!--左侧部分结束 -->
</div>
</div>
</body>
</html>
