<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Model_Manage.aspx.cs" Inherits="adminmanage_Model_Model_Manage" %>
<%@ Import Namespace="HXD.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css">
<link href="../skin/01/css/jquery.boxy.css" rel="stylesheet" type="text/css">
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript">
function IsNum(str,id)
{
    var regEx = /[^0-9]+/gi ;
    if( regEx.test( str ))
    {
        alert("不是合法数字");
        return false;
    }
    else
    {
        $("s"+id).innerHTML="<img src='../images/loading.gif' />";
        var url = 'Inc/Validate_Sort.aspx';
		var pars = 'Id='+id+'&Model=<%=Model %>&Sort='+str;
		var myAjax = new Ajax.Request(
					url,
					{method: 'get', parameters: pars}
					);
		$("s"+id).innerHTML="";
    }
}
</script>
</head>

<body>
<form runat="server" id="myform">
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title"><asp:Literal ID="MenuTitle" runat="server"></asp:Literal>管理</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - <span class="blue"><asp:Literal ID="MenuTitle1" runat="server"></asp:Literal>列表</span>
	   <%=add %>
	   <asp:LinkButton ID="DelBut" runat="server" CssClass="red" OnClick="DelBut_Click"> | 删除</asp:LinkButton>
       <asp:LinkButton ID="StatusBut" runat="server" CssClass="red" OnClick="StatusBut_Click" Text=" | 审核" /><asp:LinkButton ID="unStatusBut" runat="server" CssClass="red" OnClick="unStatusBut_Click" Text="<span class='red'>/</span>关闭" />
       <asp:LinkButton ID="TopBut" runat="server" CssClass="red" Text=" | 置顶" OnClick="TopBut_Click"  /> <asp:LinkButton ID="unTopBut" runat="server" CssClass="red" Text="<span class='red'>/</span>取消" OnClick="unTopBut_Click" />
       <asp:LinkButton ID="EliteBut" runat="server" CssClass="red" Text=" | 推荐" OnClick="EliteBut_Click" /> <asp:LinkButton ID="unEliteBut" runat="server" CssClass="red" Text="<span class='red'>/</span>取消" OnClick="unEliteBut_Click" />
       <asp:LinkButton ID="HotBut" runat="server" CssClass="red" Text=" | 热门" OnClick="HotBut_Click" /> <asp:LinkButton ID="unHotBut" runat="server" CssClass="red" Text="<span class='red'>/</span>取消" OnClick="unHotBut_Click" />
       </span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table  align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
    <asp:Label ID="ListTable" runat="server" /></table>
    <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">
        <asp:Label ID="PageView" runat="server" />
      </td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="10">&nbsp;</td>
    </tr>
  </table>
</div>
</form>
</body>
</html>
