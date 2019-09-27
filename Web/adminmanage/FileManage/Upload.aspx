<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="adminmanage_FileManage_Upload" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.NET2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>

<style type="text/css">
<!--
.boders {
	border: 2px solid #BDBEBF;
}
-->
</style>
</head>
<body oncontextmenu="return false;" onselectstart="return false"><form runat="server" id="mainForm" method="post" style="width: 100%" class="required-validate">
    <table width="330" height="220" border="0" cellpadding="3" cellspacing="0" bgcolor="#CACACA" class="boders" runat="server">
      <tr>
        <td height="23" align="center" bgcolor="#DDDDDD"><strong>文件上传
        <radU:RadProgressManager ID="Radprogressmanager1" runat="server" />
        </strong></td>
      </tr>

      <tr id="uptd" runat="server">
        <td bgcolor="#F6F6F6"><radU:RadProgressArea ID="progressArea1" runat="server" /><asp:FileUpload ID="Files" runat="server" Width="318" /></td>
      </tr>
	  <tr>
        <td align="left" bgcolor="#F6F6F6">允许上传类型：<%=FileType%><br />
        允许上传大小：<%=FileSize/1024%>KB</td>
      </tr>
      <tr id="overtd" runat="server">
        <td height="20" align="center" bgcolor="#DDDDDD"> 
          <asp:Button ID="btnUpload" runat="server" CssClass="input" Text="上传" OnClick="btnUpload_Click" />
          
        <input id="but_close" runat="server" class="input" onclick="CloseUpload();" type="button" value="关闭" /><input id="but_over" runat="server" onclick="CloseUpload();" class="input" type="button" value="完成" visible="false" /></td>
      </tr>
  </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function CloseUpload()
{
	window.parent.$("AllDiv").style.display = "none";
	window.parent.$("BigDiv").innerHTML = "";
}
</script>