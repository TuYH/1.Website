<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="adminmanage_FileManage_UploadFile" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.NET2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript">
function UpLoadType(val) {
	switch (val) {
		case "upload1":
		    $("#upload1").attr("checked","checked");
			$("#Files1").attr("disabled",false);
			$("#WebUrl").attr("disabled",true);
			$("#Button2").attr("disabled",true);
			$("#SetFileId").attr("disabled",false);
			break;
		case "upload2":
		    $("#upload2").attr("checked","checked");
			$("#Files1").attr("disabled",true);
			$("#WebUrl").attr("disabled",true);
			$("#Button2").attr("disabled",false);
			$("#SetFileId").attr("disabled",true);
			break;
		case "upload3":
		    $("#upload3").attr("checked","checked");
			$("#Files1").attr("disabled",true);
			$("#WebUrl").attr("disabled",false);
			$("#Button2").attr("disabled",true);
			$("#SetFileId").attr("disabled",true);
			break;
	}
}
</script>
</head>
<body oncontextmenu="return true;" onselectstart="return true">
<div id="edit">
<form runat="server" id="mainForm" method="post">
<table cellpadding="2" height="100%" cellspacing="0" border="0" width="380" align="center">
        <tr>
            <td>
                <input name="FilePicPath" type="text" id="FilePicPath" style="display:none" />
                <table width="380" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="385" valign="top">
                            <fieldset>
                                <legend>文件来源</legend>
                                <table width="380" border="0" cellpadding="4" cellspacing="0">
                                    <tr id="IsUploadFile">
                                        <td width="18%">
                                            <input id="upload1" type="radio" name="UpLoad" value="upload1" checked="checked" onclick="UpLoadType(this.id);" /><label for="upload1">上传：</label>
                                      </td>
                                        <td width="82%"><radU:RadProgressManager ID="Radprogressmanager1" runat="server" />
                                      <radU:RadProgressArea ID="progressArea1" runat="server" /><asp:FileUpload ID="Files1" runat="server" style="width:100%" CssClass="divbutton" /></td>
                                    </tr>
                                    <tr id="IsSelectImage">
                                        <td>
                                            <input id="upload2" type="radio" name="UpLoad" value="upload2" onclick="UpLoadType(this.id);" /><label for="upload2">选择：</label>
                                        </td>
                                        <td>
                                            <input name="SelectFile" type="text" class="input" id="SelectFile" style="width:208px" readonly="true" />
                                            <input type="button" class="divbutton" id="Button2" value="浏览服务器" disabled="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input id="upload3" type="radio" name="UpLoad" value="upload3" onclick="UpLoadType(this.id);" /><label for="upload3">网络：</label>
                                        </td>
                                        <td>
                                            <input name="WebUrl" type="text" value="http://" style="width:300px" id="WebUrl" class="input" disabled="true" />
                                        </td>
                                    </tr>
                            </table>
                            </fieldset>
                            <fieldset>
                                <legend>确认提交</legend>
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="center" height="45"><asp:Button CssClass="divbutton" ID="btnUpload" runat="server" Text=" 确定 " OnClick="btnUpload_Click" />
                                        
                                        <input type="button" class="divbutton" id="Button3" style="margin-left:20px;" onclick="window.parent.cancel()" value=" 取消 " />                                      </td>
                                    </tr>
                                </table>
                            </fieldset>
                      </td>
                    </tr>
              </table>
            </td>
        </tr>
    </table>
<script language='javascript' type='text/javascript'>

<asp:Literal ID="JavascriptServer" runat="server"></asp:Literal>
</script>
</form>
</div>
</body>
</html>