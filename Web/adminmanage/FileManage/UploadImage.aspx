<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImage.aspx.cs" Inherits="adminmanage_FileManage_UploadImage" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.NET2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/FormatImg.js"></script>
<script language="javascript" type="text/javascript">
function UpLoadType(val) {
	switch (val) {
		case "upload1":
		    $("#upload1").attr("checked","checked");
			$("#Files1").attr("disabled",false);
			$("#WebUrl").attr("disabled",true);
			$("#Button2").attr("disabled",true);
			$("#SetImageId").attr("disabled",false);
			break;
		case "upload2":
		    $("#upload2").attr("checked","checked");
			$("#Files1").attr("disabled",true);
			$("#WebUrl").attr("disabled",true);
			$("#Button2").attr("disabled",false);
			$("#SetImageId").attr("disabled",false);
			break;
		case "upload3":
		    $("#upload3").attr("checked","checked");
			$("#Files1").attr("disabled",true);
			$("#WebUrl").attr("disabled",false);
			$("#Button2").attr("disabled",true);
			$("#SetImageId").attr("disabled",true);
			break;
	}
}

function IsThumbnails(val)
{
	if($("#"+val).attr('checked')==undefined)
	{
		$("#lableThumbWidth").attr("disabled",true);
		$("#lableThumbModel").attr("disabled",true);
	}
	else
	{
		$("#lableThumbWidth").attr("disabled",false);
		$("#lableThumbModel").attr("disabled",false);
	}
}

function PreviewImg(val) 
{
	if(val.length>0)
	{
		$("#PreviewImgId").html("<img id='ViewImage' src='"+val+"' onmouseover=\"FormatImg(240,270,'ViewImage');\" />");
		FormatImg(240,270,'ViewImage');
	}
}
</script>
</head>
<body oncontextmenu="return true;" onselectstart="return true">
<div id="edit">
<form runat="server" id="mainForm" method="post">
<table cellpadding="2" height="100%" cellspacing="0" border="0" width="585" align="center">
        <tr>
            <td>
                <input name="FilePicPath" type="text" id="FilePicPath" style="display:none" />
                <table width="585" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="323" valign="top">
                            <fieldset>
                                <legend>图片来源</legend>
                                <table width="320" border="0" cellpadding="4" cellspacing="0">
                                    <tr id="IsUploadImage">
                                        <td width="21%">
                                            <input id="upload1" type="radio" name="UpLoad" value="upload1" checked="checked" onclick="UpLoadType(this.id);" /><label for="upload1">上传：</label>
                                      </td>
                                        <td width="79%"><radU:RadProgressManager ID="Radprogressmanager1" runat="server" />
                                      <radU:RadProgressArea ID="progressArea1" runat="server" /><asp:FileUpload ID="Files1" runat="server" style="width:100%" CssClass="divbutton" /></td>
                                    </tr>
                                    <tr id="IsSelectImage">
                                        <td>
                                            <input id="upload2" type="radio" name="UpLoad" value="upload2" onclick="UpLoadType(this.id);" /><label for="upload2">选择：</label>
                                        </td>
                                        <td>
                                            <input name="SelectImage" type="text" class="input" id="SelectImage" onchange="javascript:PreviewImg(this.value);" style="width:150px" readonly="true" />
                                            <input type="button" class="divbutton" id="Button2" value="浏览服务器" disabled="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input id="upload3" type="radio" name="UpLoad" value="upload3" onclick="UpLoadType(this.id);" /><label for="upload3">网络：</label>
                                        </td>
                                        <td>
                                            <input name="WebUrl" type="text" value="http://" style="width:240px" id="WebUrl" class="input" disabled="true" onblur="PreviewImg(this.value);" />
                                        </td>
                                    </tr>
                            </table>
                            </fieldset>
                            <fieldset>
                                <legend>设置图片</legend>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0" id="SetImageId">
                                    <tr>
                                        <td colspan="2">
                                            <input id="IsWatermark" type="checkbox" name="IsWatermark" value="true" />水印&nbsp;&nbsp;<input id="IsThumbnail" type="checkbox" name="IsThumbnail" onclick="IsThumbnails(this.id)" value="true" />缩略图
											&nbsp;&nbsp;<span id="lableThumbWidth">缩放：宽<input name="ThumbWidth" type="text" class="input" id="ThumbWidth" size="2" maxlength="5" />
高<input name="ThumbHeight" type="text" class="input" id="ThumbHeight" size="2" maxlength="5" />
像素</span></td>
                                    </tr>
									<tbody id="lableThumbModel">
                                    <tr>
                                      <td><input id="ThumbMode1" type="radio" name="ThumbMode" value="HW" />指定高宽缩放</td>
                                      <td><input id="ThumbMode2" type="radio" name="ThumbMode" value="W" />指定宽，高按比例</td>
                                    </tr>
                                    <tr>
                                      <td><input id="ThumbMode3" type="radio" name="ThumbMode" value="H" />指定高，宽按比例</td>
                                      <td><input id="ThumbMode4" type="radio" name="ThumbMode" value="Cut" />指定高宽裁减</td>
                                    </tr>
									</tbody>
                                    <tr>
                                        <td colspan="2">                                        </td>
                                    </tr>
                            </table>
                            </fieldset>
                            <fieldset>
                                <legend>确认提交</legend>
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="center" height="45"><asp:Button CssClass="divbutton" ID="btnUpload" runat="server" Text=" 确定 " OnClick="btnUpload_Click" />
                                        
                                        <input type="button" class="divbutton" id="Button3" style="margin-left:20px;" onclick="window.parent.cancel()" value=" 取消 " /></td>
                                    </tr>
                                </table>
                            </fieldset>
                      </td>
                        <td width="262" valign="top" style="padding-left: 6px">
                            <fieldset>
                                <legend>预览图像</legend>
                                <table width="100%" height="279" border="0" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td align="center" id="PreviewImgId"></td>
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