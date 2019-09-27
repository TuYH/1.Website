<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="SetConfig.aspx.cs" Inherits="adminmanage_Sys_SetConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!--#include file="../inc/NoLink.inc"-->
<!--#include file="../inc/Title_inc.inc"-->
<link href="../skin/01/css/edit.css" rel="stylesheet" type="text/css" />
<link href="../skin/01/css/validation.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../js/validation_cn.js"></script>
<script language="javascript" type="text/javascript" src="../js/prototype_for_validation.js"></script>
<script language="javascript" type="text/javascript" src="../js/effects.js"></script>
<script language="javascript" type="text/javascript" src="../js/target.js"></script>
</head>

<body>
<form id="Form1" runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">系统参数配置</td>
      <td align="right"  nowrap></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <td colspan="2" class="redbold"><asp:Literal ID="Title" runat="server"></asp:Literal></td>
    </tr>
    <tbody runat="server" id="SiteId" visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>站点名称：</strong></td>
      <td>
          <asp:TextBox ID="SiteName" runat="server" CssClass="input2 required" MaxLength="200"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td width="200"><span class="left2"><strong>站点域名：</strong></span></td>
      <td width="574">
          <asp:TextBox ID="SiteDomain" runat="server" CssClass="input2" MaxLength="200"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>后台管理目录：</strong></td>
      <td>
          <asp:TextBox ID="ManagePath" runat="server" CssClass="input1 required" MaxLength="50"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否启用后台管理验证码：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsManageCode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>全站页面生成方式：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="CreateType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="1">正常模式</asp:ListItem>
              <asp:ListItem Value="2">开启URL重写</asp:ListItem>
              <asp:ListItem Value="3">开启全站生成静态页</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>首页关键字：</strong></span></td>
      <td>
          <asp:TextBox ID="HomeKeyWords" runat="server" CssClass="input2" MaxLength="200"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>首页内容描述：</strong></td>
      <td>
          <asp:TextBox ID="HomeDescription" runat="server" CssClass="input2" Height="85px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>版权信息：</strong></span></td>
      <td>
          <asp:TextBox ID="CopyRight" runat="server" CssClass="input2" TextMode="MultiLine" Height="85px" Width="390px"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>网站ICP备案号：</strong></span></td>
      <td>
          <asp:TextBox ID="ICP" runat="server" CssClass="input2" MaxLength="50"></asp:TextBox>
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>网站内容干扰码：</strong></span></td>
      <td>
          <asp:TextBox ID="ObstructCode" runat="server" CssClass="input2" MaxLength="200"></asp:TextBox> 防止网站内容被轻易拷贝
                    </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>模型XML存储路径：</strong></span></td>
      <td>
          <asp:TextBox ID="TableXmlPath" runat="server" CssClass="input2" MaxLength="200"></asp:TextBox>
                    </td>
    </tr>
    </tbody>
    <tbody runat="server" id="FileId" visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>开启文件上传：</strong></span></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsUploadFile" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>允许选择已有文件：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsSelectFile" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>文件上传路径：</strong></td>
      <td>&nbsp;<asp:TextBox ID="UploadFilePath" runat="server" CssClass="input1 required" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>文件最大上传：</strong></td>
      <td>&nbsp;<asp:TextBox ID="FileSize" runat="server" CssClass="input1 required validate-digits" size="20" MaxLength="20"></asp:TextBox>
          KB</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>允许上传的文件格式：</strong></td>
      <td>&nbsp;允许上传的视频文件格式为：<asp:TextBox ID="VideoType" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;允许上传的音频文件格式为：<asp:TextBox ID="AudioType" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;允许上传的软件文件格式为：<asp:TextBox ID="SoftType" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;允许上传的其他文件格式为：<asp:TextBox ID="OtherType" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;（多种文件格式用“,”隔开，例如：rar,zip）</td>
    </tr>
    </tbody>
    <tbody runat="server" id="ImageId" visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>开启图片上传：</strong></span></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsUploadImage" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>允许选择已有图片：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsSelectImage" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>图片上传路径：</strong></td>
      <td>&nbsp;<asp:TextBox ID="UploadImagePath" runat="server" CssClass="input1 required" MaxLength="50"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>图片最大上传：</strong></td>
      <td>&nbsp;<asp:TextBox ID="ImageSize" runat="server" CssClass="input1 required validate-digits" size="20" MaxLength="20"></asp:TextBox>
          KB</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>允许上传的图片格式：</strong></td>
      <td>&nbsp;<asp:TextBox ID="ImageType" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox> （多种文件格式用“,”隔开，例如：jpg,gif）</td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否开启图片水印：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsWatermark" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList>
       </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>水印图片路径：</strong></td>
      <td>&nbsp;<asp:TextBox ID="WatermarkImage" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>水印的位置：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="WatermarkPos" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="1">左上</asp:ListItem>
              <asp:ListItem Value="2">右上</asp:ListItem>
              <asp:ListItem Value="3">左下</asp:ListItem>
              <asp:ListItem Value="4">右下</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>是否开启图片缩略图：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsThumbnail" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>缩略图尺寸：</strong></td>
      <td>&nbsp;<asp:TextBox ID="ThumbnailSize" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;（宽高格式为宽*高，用“*”隔开，例如：200*150）</td>
    </tr>
    </tbody>
    <tbody id="MailId" runat="server" visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>是否开启邮件功能：</strong></span></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsMail" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>邮件发送设置：</strong></td>
      <td>&nbsp;发送邮件服务器地址为：<asp:TextBox ID="SendMailServer" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox><br />
          &nbsp;发送邮件的地址名称为：<asp:TextBox ID="SendMailUserName" runat="server" CssClass="input1 validate-email" MaxLength="200"></asp:TextBox><br />
          &nbsp;发送邮件的账户密码为：<asp:TextBox ID="SendMailUserPwd" runat="server" TextMode="Password" CssClass="input1" MaxLength="50"></asp:TextBox><br />
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>邮件接收地址：</strong></td>
      <td>&nbsp;<asp:TextBox ID="ReceiveMail" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>邮件主题：</strong></td>
      <td>&nbsp;<asp:TextBox ID="MailSubject" runat="server" CssClass="input1" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>邮件内容模板：</strong></td>
      <td>&nbsp;<asp:TextBox ID="MailTemplate" runat="server" CssClass="input1" 
              TextMode="MultiLine" Height="245px" Width="477px"></asp:TextBox></td>
    </tr>
    </tbody>
    <tbody id="UserId" runat="server" visible="false">
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>允许新用户注册：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsReg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">是</asp:ListItem>
              <asp:ListItem Value="False">否</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>用户注册验证码：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsRegCode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">开启</asp:ListItem>
              <asp:ListItem Value="False">关闭</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>用户登录验证码：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsLoginCode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">开启</asp:ListItem>
              <asp:ListItem Value="False">关闭</asp:ListItem>
          </asp:RadioButtonList> 
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>用户邀请机制：</strong></td>
      <td>&nbsp;<asp:RadioButtonList ID="IsInvite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="True">开启</asp:ListItem>
              <asp:ListItem Value="False">关闭</asp:ListItem>
          </asp:RadioButtonList>开启此功能，用户激情好友注册获得积分（与会员积分结合使用）
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>禁用用户名：</strong></td>
      <td>&nbsp;<asp:TextBox ID="NotReg" runat="server" CssClass="input1" 
              TextMode="MultiLine" Height="85px" Width="390px"></asp:TextBox>
      </td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>注册须知：</strong></td>
      <td>&nbsp;<asp:TextBox ID="RegInfo" runat="server" CssClass="input1" 
              TextMode="MultiLine" Height="385px" Width="390px"></asp:TextBox>
      </td>
    </tr>
    </tbody>
  </table>
  <table height="75" border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td align="center"><input name="Submit2" type="submit" value="保 存" class="button" onmouseover="this.className='button1'" onmouseout="this.className='button'" />
        　
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
