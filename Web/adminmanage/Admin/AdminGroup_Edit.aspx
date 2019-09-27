<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminGroup_Edit.aspx.cs" Inherits="adminmanage_Admin_AdminGroup_Edit" %>

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
<script>
function GroupChecked(obj,id)
{
    var Parentobj = $(obj);
    var Count = document.getElementsByName("GroupSetting").length;
    for(var i=0;i<Count;i++)
    {   
        var objName = $("SetId_"+id+"_"+i);
		GroupOtherChecked(Parentobj.checked,id);
        if(objName)
        {
            if(Parentobj.checked==true)
            {
                objName.checked=true;
                GroupChecked("SetId_"+id+"_"+i,objName.value);
            }
            else
            {
                objName.checked=false;
                GroupChecked("SetId_"+id+"_"+i,objName.value);
            }
        }
    }
}

function GroupOtherChecked(obj,id)
{
	var checkbox = $("checkid_"+id).getElementsByTagName('input');
	for (i=0; i<checkbox.length; i++)
	{
		checkbox[i].checked = obj;
	}
}


function AllCheck(n)
{
    var obj = document.getElementsByName("GroupSetting");
    for(var i=0;i<obj.length;i++)
    {
        if(n == 1)
        {
            obj[i].checked=true;
			GroupOtherChecked(true,obj[i].value);
        }
        else
        {
            obj[i].checked=false;
			GroupOtherChecked(false,obj[i].value);
        }
    }
}
</script>
</head>

<body>
<form runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加/修改管理员组</td>
      <td align="right"  nowrap><span class="hui operation">管理导航 - 管理员组编辑 | <a href="AdminGroup_Manage.aspx">管理员组列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">管理员组编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>组名称：</strong></span></td>
      <td width="574">
          &nbsp;<asp:TextBox ID="Title" runat="server" CssClass="input1 required" MaxLength="25"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>组说明：</strong></span></td>
      <td>
          &nbsp;<asp:TextBox ID="Note" runat="server" CssClass="input1" MaxLength="400"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>父级组：</strong></span></td>
      <td>&nbsp;<asp:DropDownList ID="ParentId" runat="server">
            <asp:ListItem Value="0" Text="顶级管理组"></asp:ListItem>
          </asp:DropDownList>
        </td>
    </tr>
      <tr class="td_bg" onclick="change()" onmouseout="out()" onmouseover="over()">
          <td><strong>权限/操作：</strong></td>
          <td>
            <a href="javascript:AllCheck(1);">全选</a>/<a href="javascript:AllCheck(0);">置空</a><br />
              <%ChannelBind(0, "<img src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\" />"); %>
          </td>
      </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
        <input name="Submit2" type="submit" value="保 存" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
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