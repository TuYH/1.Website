<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="Menu_Edit.aspx.cs" Inherits="adminmanage_Menu_Menu_Edit" %>
<%@ Import Namespace="HXD.Common" %>
<html>
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script type="text/javascript" language="javascript" src="../../js/lhgdialog/lhgdialog.js"></script>
<script language="javascript" type="text/javascript" src="../js/Upload.js"></script>
<script language="javascript" type="text/javascript" src='../../WebEditor/fckeditor.js'></script>

</head>

<body>
<form id="Form1" runat="server" class="required-validate">


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<!--编辑部分开始 -->
<div id="edit">

  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/编辑<%=MenuTitle %></td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - <%=MenuTitle %>编辑<span runat="server" id="ListLinkId"> | <a href="Menu_Manage.aspx?MenuId=<%=MenuId %>"><%=MenuTitle %>列表</a></span></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold"><%=MenuTitle %>编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="MenuTableId">
      <td width="20%"><strong>父级：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="ParentId" runat="server">
            <asp:ListItem Value="0" Text="顶级栏目"></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="ModelId">
      <td><strong>信息模型：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="Model" runat="server">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
	<asp:Repeater ID="DBList" runat="server"><itemtemplate>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="130"><strong><%#GetFieldTitle(Eval("Id"),Eval("Title"))%>：</strong></td>
      <td><%#FieldType.GetType(MenuReader(Eval("Field").ToString()), Eval("Parameter"))%> <%#StringDeal.StrFormat(Eval("Note"))%></td>
    </tr>
	</itemtemplate></asp:Repeater>
	 <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()" >
          <td>
              <strong>包含操作：</strong></td>
          <td><asp:CheckBoxList ID="Setting" runat="server" RepeatDirection="Horizontal">
              </asp:CheckBoxList></td>
      </tr>
  </table>
  
  <br />
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <table align="center" cellspacing="1" class="table table_all" id="table2">
    <tr class="td_bg">
      <td colspan="2" class="redbold">编辑模板</td>
    </tr>
    
    
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="Tr3">
      <td width="20%"><strong>指向形式：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="PageType" runat="server" Width="242px" 
              onselectedindexchanged="PageType_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="0" Text="模板生成"></asp:ListItem>
            <asp:ListItem Value="1" Text="外部链接"></asp:ListItem>
            <asp:ListItem Value="2" Text="其他栏目"></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
    
    
    <asp:Panel ID="P_OutLink" runat="server" Visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="Tr4">
      <td width="20%"><strong>外部链接：</strong></td>
      <td>&nbsp;<asp:TextBox ID="OutLink" runat="server" CssClass="input1" Width="240px"></asp:TextBox>
	  </td>
    </tr>
    </asp:Panel>
    
    <asp:Panel ID="P_ToMenu" runat="server" Visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="Tr5">
      <td width="20%"><strong>选择栏目：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="ToMenu" runat="server" Width="242px">
            <asp:ListItem Value="0" Text="请选择要指向的栏目"></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
    </asp:Panel>
    
    <asp:Panel ID="P_Style" runat="server">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="Tr1">
      <td width="20%"><strong>模板风格：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="TemeplateStyle" runat="server" Width="242px">
            <asp:ListItem Value="Default" Text="默认风格"></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
    </asp:Panel>
    
    <asp:Panel ID="P_Formwork" runat="server">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg" runat="server" id="Tr2">
      <td><strong>选择模板：</strong></td>
      <td>&nbsp;<asp:DropDownList ID="TemplatePath" runat="server" Width="242px">
            <asp:ListItem Value="0" Text=""></asp:ListItem>
          </asp:DropDownList>
	  </td>
    </tr>
    </asp:Panel>
  </table>
  
  
    </ContentTemplate>
    </asp:UpdatePanel>
  
  
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
          <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button"  OnClick="MenuSave" />
        
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