<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchUploadImage.aspx.cs" Inherits="adminmanage_FileManage_BatchUploadImage" %>
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
			$("#up2").hide();
			$("#up3").hide();
			$("#up1").show("slow");
			$("#SetImageId").attr("disabled",false);
			break;
		case "upload2":
			$("#upload2").attr("checked","checked");
		    $("#up1").hide();
			$("#up3").hide();
			$("#up2").fadeIn("slow");
			$("#SetImageId").attr("disabled",false);
			break;
		case "upload3":
			$("#upload3").attr("checked","checked");
		    $("#up1").hide(); 
			$("#up2").hide(); 
			$("#up3").show("slow");
			$("#SetImageId").attr("disabled",true);
			break;
		case "uploadsend":
			$("#up1").hide(); 
			$("#up2").hide(); 
			$("#up3").hide();
			$("#UploadProgress").show("slow");
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

function BackVal(id,val)
{
	var obj = window.parent.loadinndlg().document.getElementById(id);
	var Arry = val.split(",");//新数据
	var item="";
    for(var c=0;c<obj.options.length;c++)//老数据
	{
		if(obj.options[c].value.length>0 && obj.options[c].value.toLowerCase()!="http://")
		{
			item += obj.options[c].value + ",";
		}
	}
	item += val;//新的数据和老数据合并
	for(var i=0;i<Arry.length;i++)//新数据添加到select中
	{
		if(Arry[i].length>0 && Arry[i].toLowerCase()!="http://")
		{
			obj.options.add(new Option(Arry[i],Arry[i]));
		}
	}
	window.parent.loadinndlg().document.getElementById(id.replace("_Select","")).value = item;
	window.parent.cancel();
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
                        <td valign="top">
                            <fieldset>
                                <legend>图片批量来源</legend>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0">
                                    <tr>
                                      <td><span id="IsUploadImage"><input id="upload1" type="radio" name="UpLoad" value="upload1" checked="checked" onclick="UpLoadType(this.id);" /><label for="upload1">图片上传</label></span>
									  <span id="IsSelectImage"><input id="upload2" type="radio" name="UpLoad" value="upload2" onclick="UpLoadType(this.id);" /><label for="upload2">选择服务器上图片</label></span>
									  <input id="upload3" type="radio" name="UpLoad" value="upload3" onclick="UpLoadType(this.id);" /><label for="upload3">网络图片地址</label></td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0" id="up1">
                                    <tr>
                                     <td width="50%"><asp:FileUpload ID="Files1" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                     <td width="50%"><asp:FileUpload ID="Files2" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                    </tr>
                                    <tr>
                                      <td><asp:FileUpload ID="Files3" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                      <td><asp:FileUpload ID="Files4" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                    </tr>
                                    <tr>
                                      <td><asp:FileUpload ID="Files5" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                      <td><asp:FileUpload ID="Files6" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                    </tr>
                                    <tr>
                                      <td><asp:FileUpload ID="Files7" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                      <td><asp:FileUpload ID="Files8" runat="server" style="width:95%" CssClass="divbutton" /></td>
                                    </tr>
								</table>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0" style="display:none;" id="up2">
                                    <tr>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage1" style="width:210px" readonly="true" /> <input type="button" class="divbutton" id="Button2" value="浏览" /></td>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage2" style="width:210px" readonly="true" /> <input name="button" type="button" class="divbutton" id="button" value="浏览" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage3" style="width:210px" readonly="true" /> <input name="button2" type="button" class="divbutton" id="button2" value="浏览" /></td>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage4" style="width:210px" readonly="true" /> <input name="button3" type="button" class="divbutton" id="button3" value="浏览" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage5" style="width:210px" readonly="true" /> <input name="button4" type="button" class="divbutton" id="button4" value="浏览" /></td>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage6" style="width:210px" readonly="true" /> <input name="button5" type="button" class="divbutton" id="button5" value="浏览" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage7" style="width:210px" readonly="true" /> <input name="button6" type="button" class="divbutton" id="button6" value="浏览" /></td>
                                      <td><input name="SelectImage" type="text" class="input" id="SelectImage8" style="width:210px" readonly="true" /> <input name="button7" type="button" class="divbutton" id="button7" value="浏览" /></td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0" style="display:none;" id="up3">
                                    <tr>
                                      <td width="50%"><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl1" class="input" /></td>
                                      <td width="50%"><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl2" class="input" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl3" class="input" /></td>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl4" class="input" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl5" class="input" /></td>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl6" class="input" /></td>
                                    </tr>
                                    <tr>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl7" class="input" /></td>
                                      <td><input name="WebUrl" type="text" value="http://" style="width:255px" id="WebUrl8" class="input" /></td>
                                    </tr>
                                </table>
								<table width="100%" border="0" cellpadding="4" cellspacing="0" id="UploadProgress" style="display:none;">
									<tr>
                                      <td><span style="display:none;"><radU:RadProgressManager ID="Radprogressmanager1" runat="server" /></span>
                                      <radU:RadProgressArea ID="progressArea1" runat="server" Height="50" Width="570" /></td>
                                    </tr>
								</table>
                            </fieldset>
                            <fieldset>
                                <legend>设置图片</legend>
                                <table width="100%" border="0" cellpadding="4" cellspacing="0" id="SetImageId">
                                    <tr>
                                        <td colspan="2">
                                            <input id="IsWatermark" type="checkbox" name="IsWatermark" value="true" />水印&nbsp;&nbsp;<input id="IsThumbnail" type="checkbox" name="IsThumbnail" onclick="IsThumbnails(this.id)" value="true" />缩略图
											&nbsp;&nbsp;<span id="lableThumbWidth">缩放：宽<input name="ThumbWidth" type="text" class="input" id="ThumbWidth" size="2" maxlength="3" />
高<input name="ThumbHeight" type="text" class="input" id="ThumbHeight" size="2" maxlength="3" />
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
                                        <td align="center" height="45"><asp:Button CssClass="divbutton" ID="btnUpload" runat="server" Text=" 确定 " OnClick="btnUpload_Click" OnClientClick="UpLoadType('uploadsend');" />
                                        
                                        <input type="button" class="divbutton" id="Button3" style="margin-left:20px;" onclick="window.parent.cancel()" value=" 取消 " />                                      </td>
                                    </tr>
                                </table>
                            </fieldset>                      </td>
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