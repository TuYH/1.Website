<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="AdvertisementAdd.aspx.cs" Inherits="adminmanage_Advertisement_AdvertisementAdd" %>
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
<script type="text/javascript" language="javascript" src="../Js/WdatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form id="form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">添加广告</td>
      <td align="right" nowrap="nowrap"><span class="hui operation">管理导航 - 广告编辑 | <a href="AdvertisementList.aspx?Page=<%=Pages %>">广告列表</a></span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold">广告编辑面版</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>广告类型：</strong></td>
      <td>
      &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">文字</asp:ListItem>
            <asp:ListItem Value="2">图片</asp:ListItem>
            <asp:ListItem Value="3">Flash</asp:ListItem>
            <asp:ListItem Value="4">脚本</asp:ListItem>
            <asp:ListItem Value="5">浮动广告</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>广告名称：</strong></span></td>
      <td width="574">&nbsp;<asp:TextBox ID="TextBox1" CssClass="input1 required" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr id="adsize" style="display:none;" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>广告大小：</strong></span></td>
      <td>宽度：<asp:TextBox ID="TextBox2" CssClass="input1 required validate-digits min-value-0" runat="server" MaxLength="5" Width="40px">0</asp:TextBox>高度：<asp:TextBox ID="TextBox3" CssClass="input1 required validate-digits min-value-0" runat="server" MaxLength="5" Width="40px">0</asp:TextBox></td>
    </tr>
    <tr id="adfile" style="display:none;" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>图片文件：</strong></span></td>
      <td>
            <%--<input id="Radio1" checked="true" name="0" type="radio" onclick="checks(this)" runat="server" />服务器图片<input id="Radio2" name="0" type="radio" onclick="checks(this)" runat="server"/>本地图片
            <div id="filetable1">&nbsp;<asp:TextBox ID="FileStr" CssClass="input1" runat="server"></asp:TextBox><input id="Button3" class="input1" type="button" value="浏览..." onclick="openWin();" style="width: 70px; height: 22px; font-size: 13px;"/></div>
            <div id="filetable2" style="display:none;">&nbsp;<input id="File1" class="input1" runat="server" type="file" /></div>--%>
            &nbsp;<input id="File1" class="input1" runat="server" type="file" />
      </td>
    </tr>
    <tr id="adflash" style="display: none" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>Flash文件：</strong></td>
      <td>&nbsp;<input id="File2" class="input1" runat="server" type="file" /></td>
    </tr>
    <tr id="adlink" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>广告链接：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server" MaxLength="300" CssClass="input1"></asp:TextBox></td>
    </tr>
    <tr id="adlinkstr" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>文字说明：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TextBox5" runat="server" MaxLength="100" CssClass="input1"></asp:TextBox></td>
    </tr>
    <tr id="adjs" style="display:none;" onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>脚本信息：</strong></td>
      <td>&nbsp;<asp:TextBox ID="TextBox6" runat="server" Height="152px" TextMode="MultiLine" Width="502px" CssClass="input1"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>结束时间：</strong></td>
      <td>&nbsp;<input id="Text1" runat="server" type="text" class="input1 required validate-date-yyyy-MM-dd" onfocus="WdatePicker({skin:'YcloudRed',lang:'zh-cn',isShowClear:true,readOnly:true,dateFmt:'yyyy-MM-dd'})" maxlength="50" style="width: 180px"/></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否启用：</strong></td>
      <td>&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" CssClass="input1"/></td>
    </tr>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center">
          <asp:Button ID="Button1" runat="server" Text="保 存" 
              CssClass="button" onclick="Button1_Click" />
        　
        <input name="Submit22" type="reset" value="重 置"  class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
        <input name="Button2" type="button"value="取 消" onclick="window.location.href='AdvertisementList.aspx?Page=<%=Pages %>'" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
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
<script language="javascript" type="text/javascript">
  function openWin(){        
    var srcFile = "WebForm1.aspx";//新窗口的文档名称
    var winFeatures = "dialogHeight:400px;dialogWidth:850px;";
    var obj = form1;//将form作为对象传递给新窗口
    window.showModalDialog(srcFile, obj, winFeatures);//模态对话框
  }
  function checks(obj)
  {
    if(obj.checked==true&&obj.id=="Radio1")
    {
        document.getElementById("filetable1").style.display="";
        document.getElementById("filetable2").style.display="none";
    }
    if(obj.checked==true&&obj.id=="Radio2")
    {
        document.getElementById("filetable1").style.display="none";
        document.getElementById("filetable2").style.display="";
    }
  }
  function selectvalue(obj)
  {
    if(obj.value=="1")
    {
        document.getElementById("adsize").style.display="none";
        document.getElementById("adfile").style.display="none";
        document.getElementById("adjs").style.display="none";
        document.getElementById("adflash").style.display="none";
        document.getElementById("adlink").style.display="";
        document.getElementById("adlinkstr").style.display="";
    }
    if(obj.value=="2")
    {
        document.getElementById("adsize").style.display="";
        document.getElementById("adfile").style.display="";
        document.getElementById("adflash").style.display="none";
        document.getElementById("adjs").style.display="none";
        document.getElementById("adlink").style.display="";
        document.getElementById("adlinkstr").style.display="";
    }
    if(obj.value=="3")
    {
        document.getElementById("adsize").style.display="";
        document.getElementById("adfile").style.display="none";
        document.getElementById("adflash").style.display="";
        document.getElementById("adjs").style.display="none";
        document.getElementById("adlink").style.display="none";
        document.getElementById("adlinkstr").style.display="none";
    }
    if(obj.value=="4")
    {
        document.getElementById("adsize").style.display="none";
        document.getElementById("adfile").style.display="none";
        document.getElementById("adflash").style.display="none";
        document.getElementById("adjs").style.display="";
        document.getElementById("adlink").style.display="none";
        document.getElementById("adlinkstr").style.display="none";
    }
    if(obj.value=="5")
    {
        document.getElementById("adsize").style.display="";
        document.getElementById("adfile").style.display="";
        document.getElementById("adflash").style.display="none";
        document.getElementById("adjs").style.display="none";
        document.getElementById("adlink").style.display="";
        document.getElementById("adlinkstr").style.display="";
    }
  }
</script>
</form>
</body>
</html>