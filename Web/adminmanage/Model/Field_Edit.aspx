<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Field_Edit.aspx.cs" Inherits="adminmanage_Model_Field_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css">
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript" type="text/javascript">
var Id = <%=Id %>;
function FiledAjax(type)
{
    $("FieldAttribute").innerHTML = "<img src='../images/loading.gif'>";
	var url = 'FieldAttribute.aspx';
	var pars = 'Id='+ Id +'&Type=' + type;
	var myAjax = new Ajax.Request(
				url,
				{method: 'get', parameters: pars, onComplete: showResponse}
				);
}

function showResponse(originalRequest)
{
    $('FieldAttribute').innerHTML = originalRequest.responseText;
}
</script>
</head>

<body>
<div id="edit">
<form runat="server" class="required-validate">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改字段</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue">添加/修改字段</span> | <a href="Field_Manage.aspx?TableId=<%=TableId%>" class="red">字段列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">添加/修改字段</td>
    </tr>
    <tr class="td_bg">
      <td><strong>表名称：</strong></td>
      <td><asp:TextBox ID="TableName" CssClass="input1 required" runat="server" size="50" maxlength="50" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td width="300"><span class="left2"><strong>字段名称：</strong></span></td>
      <td width="574"><asp:TextBox ID="Field" CssClass="input1 required validate-alphanum" runat="server" size="50" maxlength="50"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td width="300"><span class="left2"><strong>字段标题：</strong></span></td>
      <td width="574"><asp:TextBox ID="Title" CssClass="input1 required" runat="server" size="50" maxlength="100"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td><span class="left2"><strong>字段描述：</strong></span></td>
      <td><asp:TextBox ID="Note" cols="60" rows="3" CssClass="input1" runat="server" TextMode="MultiLine" Height="106px" Width="329px"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td><span class="left2"><strong>字段提示：</strong></span></td>
      <td><asp:TextBox ID="Prompt" CssClass="input1" runat="server" size="50" maxlength="50"></asp:TextBox></td>
    </tr>
    <tr class="td_bg">
      <td><span class="left2"><strong>字段类型：</strong></span></td>
      <td><asp:DropDownList ID="Type" runat="server" CssClass="validate-selection">
          <asp:ListItem Value="" Text="请选择"></asp:ListItem>
          <asp:ListItem Value="SingleLine" Text="单行文本"></asp:ListItem>
          <asp:ListItem Value="Password" Text="密码"></asp:ListItem>
          <asp:ListItem Value="MultiLine" Text="多行文本"></asp:ListItem>
          <asp:ListItem Value="Editor" Text="编辑器"></asp:ListItem>
          <asp:ListItem Value="Select" Text="选项"></asp:ListItem>
          <asp:ListItem Value="Number" Text="数字"></asp:ListItem>
          <asp:ListItem Value="DateTime" Text="日期和时间"></asp:ListItem>
          <asp:ListItem Value="Image" Text="图片"></asp:ListItem>
          <asp:ListItem Value="File" Text="文件"></asp:ListItem>
          <asp:ListItem Value="BatchImage" Text="批量图片"></asp:ListItem>
          <asp:ListItem Value="BatchFile" Text="批量文件"></asp:ListItem>
          <asp:ListItem Value="OtherMenu" Text="其他节点"></asp:ListItem>
          <asp:ListItem Value="Provinces" Text="省份城市联动"></asp:ListItem>
          <asp:ListItem Value="Increment" Text="动态增加"></asp:ListItem>
          </asp:DropDownList>
    </td>
    </tr>
    <tr class="td_bg">
      <td><strong>字段属性：</strong></td>
      <td id="FieldAttribute">&nbsp;</td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><input name="Submit2" type="submit" value="保 存" class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" />
        　
        <input name="Submit23" type="button" value="取 消" class="button" onMouseOver="this.className='button1'" onMouseOut="this.className='button'" onClick="history.back();" /></td>
    </tr>
  </table>
  
  <table width="90%" align="center">
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">&nbsp;</td>
    </tr>
  </table>
 </form>
</div>
<asp:Literal ID="OnloadJs" runat="server"></asp:Literal>
</body>
</html>