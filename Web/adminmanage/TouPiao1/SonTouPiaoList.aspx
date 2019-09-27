<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SonTouPiaoList.aspx.cs" Inherits="adminmanage_TouPiao1_SonTouPiaoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
<script language="javascript" type="text/javascript" src="../js/commen.js"></script>

<script type="text/javascript" src="/JS/jquery.js"></script>
<link  rel ="stylesheet" type ="text/css" href ="/JS/ext/resources/css/ext-all.css" />
<script type="text/javascript" src="/JS/ext/ext-base.js"></script>
<script type="text/javascript" src="/JS/ext/ext-all.js"></script>

<script type="text/javascript">
function AddOpenWindow()
{
    var htmls="<table border='0' cellpadding='0' cellspacing='0' style='width: 350px; height: 1px'><tr><td style='width: 30%; height: 25px;text-align:right;'>请填写投票内容：</td><td width='88%' style='text-align: left; height: 25px;'><input id='Text2' style='width: 210px; height: 18px' type='text' maxlength='100' /></td></tr></table>";
    var win=new Ext.Window({
    id:"windows1",
    title:"添加投票内容",
    width:360,
    height:120,
    resizable:false,
    draggable:true,
    constrain:true,
    collapsible:true,
    buttonAlign:'right',
    bodyStyle:'padding:8px',
    shadowOffset:0,
    disabled:false,
    html:htmls,
    buttons:[{text:"确定",handler:function(){insertinto();}},{text:"取消",handler:function(){Ext.getCmp("windows1").close();}}]
    })
    win.show();
}

function UpDateOpenWindow(id)
{
    var htmls="<table border='0' cellpadding='0' cellspacing='0' style='width: 350px; height: 1px'><tr><td style='width: 30%; height: 25px;text-align:right;'>请填写投票内容：</td><td width='88%' style='text-align: left; height: 25px;'><input id='Text2' style='width: 210px; height: 18px' type='text' maxlength='100' /></td></tr></table>";
    var win=new Ext.Window({
    id:"windows1",
    title:"修改投票内容",
    width:360,
    height:120,
    resizable:false,
    draggable:true,
    constrain:true,
    collapsible:true,
    buttonAlign:'right',
    bodyStyle:'padding:8px',
    shadowOffset:0,
    disabled:false,
    html:htmls,
    buttons:[{text:"确定",handler:function(){update(id);}},{text:"取消",handler:function(){Ext.getCmp("windows1").close();}}]
    })
    win.show();
    $("#Text2").val($("#title"+id).html());
}

function insertinto()
{
    if($("#Text2").val()!="")
    {
        $.get("/AJAX/TouPiao.aspx",{fid:<%=fid %>,value:$("#Text2").val(),Page:<%=Pages %>},function(data){
            if(data!="")
            {alert("投票内容添加成功！");$("#table1").append(data);Ext.getCmp("windows1").close();}
            else
            {alert("投票内容添加失败！");}
        });
    }
    else
    {alert("投票内容不能为空！");}
}
function update(id)
{
    if($("#Text2").val()!="")
    {
        $.get("/AJAX/TouPiao.aspx",{id:id,value:$("#Text2").val()},function(data){
            if(data=="1")
            {alert("投票内容修改成功！");$("#title"+id).html($("#Text2").val());Ext.getCmp("windows1").close();}
            else
            {alert("投票内容修改失败！");}
        });
    }
    else
    {alert("投票内容不能为空！");}
}
</script>
</head>

<body>
<form runat="server" id="myform">
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">投票管理</td>
      <td align="right" nowrap="nowrap">
      <span class="hui operation">管理导航 - <span class="blue"><a href="../TouPiao/TouPiaoList.aspx?Page=<%=Pages %>">返回投票列表</a></span>
	   | <a href="javascript:void(0);" onclick="AddOpenWindow();" class="red">添加投票内容</a>
	   | <asp:LinkButton ID="DelBut" runat="server" CssClass="red" onclick="DelBut_Click">删除</asp:LinkButton>
       </span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table  align="center" cellpadding="0" cellspacing="1" class="table table_all" id="table1">
        <tr>
        <td colspan="5" class="redbold">投票内容列表</td>
        </tr>
        <tr class="td_bg">
        <th style="text-align:center;" style="width:5%"><input type="checkbox" onclick="SelectAllCheckboxes(this)" /></th>
        <th style="text-align:center;" style="width:30%" nowrap="nowrap">投票内容标题</th>
        <th style="text-align:center;" style="width:10%">发布时间</th>
        <th style="text-align:center;" style="width:5%">编辑</th>
        <th style="text-align:center;" style="width:5%">操作</th>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
            <td style="text-align:center;"><input type="checkbox" name="CK_ID" id="CK_ID" value="<%#Eval("id") %>" /></td>
            <td style="text-align:center;" title="<%#Eval("title") %>" id="title<%#Eval("id") %>"><%# HXD.Common.StringDeal.Substrings1(Eval("title").ToString(), 70)%></td>
            <td style="text-align:center;" title="<%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd HH:mm:ss")%>"><%# Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%></td>
            <td style="text-align:center;"><a href="javascript:void(null);" onclick="UpDateOpenWindow(<%#Eval("id") %>);">编辑</a></td>
            <td style="text-align:center;" nowrap="nowrap">
                <a onclick="JavaScript:return confirm('确定删除此投票吗？')" href='?type=del&id=<%#Eval("id") %>&fid=<%=fid %>&Page=<%=Pages %>'>删除</a>
            </td>
            </tr>
          </ItemTemplate>
      </asp:Repeater>
  </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="10"></td>
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