<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Channel_Edit.aspx.cs" Inherits="adminmanage_Channel_Channel_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>
<body id="Url">
<form runat="server" class="required-validate"><!--编辑部分开始 -->
<div id="edit">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
        <tr>
            <td class="title">添加频道</td>
            <td align="right" nowrap><span class="hui operation">管理导航 - 频道编辑 | <a href="Channel_Manage.aspx">频道列表</a></span></td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
        <tr>
            <td height="25">&nbsp;</td>
        </tr>
    </table>
    <table align="center" cellspacing="1" class="table table_all" id="table1">
        <tr class="td_bg"><td colspan="2" class="redbold">频道编辑面版</td></tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td width="140"><span class="left2"><strong>父级菜单：</strong></span></td>
            <td>&nbsp;<asp:DropDownList ID="ParentId" runat="server" Width="205px">
                    <asp:ListItem Value="0" Text="顶级栏目"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td>
                <span class="left2"><strong>栏目名称：</strong></span>
            </td>
            <td>&nbsp;<asp:TextBox ID="Title" runat="server" CssClass="required" MaxLength="25" Width="200px"></asp:TextBox></td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td><span class="left2"><strong>窗口打开方式：</strong></span></td>
            <td>&nbsp;<asp:DropDownList ID="Target" runat="server" Width="205px">
                    <asp:ListItem Text="右侧打开" Value="mainframe"></asp:ListItem>
                    <asp:ListItem Text="新窗口打开" Value="_blank"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td><span class="left2"><strong>指向页面类型：</strong></span></td>
            <td>
                &nbsp;<asp:DropDownList ID="PageType" runat="server" Width="205px" OnSelectedIndexChanged="PageType_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Text="自定义页面" Value="0"></asp:ListItem>
                    <asp:ListItem Text="内容页" Value="1"></asp:ListItem>
                    <asp:ListItem Text="信息列表页" Value="2"></asp:ListItem>
                    <asp:ListItem Text="分类列表页" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td><span class="left2"><strong>关联节点：</strong></span></td>
            <td>
                &nbsp;<asp:DropDownList ID="MenuList" runat="server" Width="205px" OnSelectedIndexChanged="MenuList_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="0" Text="顶级栏目"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td><span class="left2"><strong>菜单URL：</strong></span></td>
            <td>&nbsp;<asp:TextBox ID="Url" runat="server" CssClass="required" MaxLength="100" Width="303px">javascript:void(null);</asp:TextBox></td>
        </tr>
        <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td><span class="left2"><strong>栏目说明：</strong></span></td>
            <td>&nbsp;<asp:TextBox ID="Note" runat="server" Width="300px" Rows="3" MaxLength="400" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
            <td><strong>包含操作：</strong></td>
            <td><asp:CheckBoxList ID="Setting" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList></td>
        </tr>
    </table>
    <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
        <tr>
            <td align="center">
                <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" OnClick="ChannelSave" />
                <input name="Submit22" type="reset" value="重 置" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
                <input name="Submit23" type="button" value="取 消" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" onclick="history.back();" />
            </td>
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