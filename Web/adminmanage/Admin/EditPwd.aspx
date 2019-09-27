<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPwd.aspx.cs" Inherits="adminmanage_Admin_EditPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
<script language="javascript" type="text/javascript">
function CharMode(iN)
{  
    if (iN>=48 && iN <=57)
        return 1;  
    if (iN>=65 && iN <=90)
        return 2;  
    if (iN>=97 && iN <=122)
        return 4;  
    else  
        return 8;  
}  

function bitTotal(num)
{  
    modes=0;  
    for (i=0;i<4;i++)
    {  
        if (num & 1) modes++;  
        num>>>=1;  
    }  
    return modes;  
}

function checkStrong(sPW)
{  
    if (sPW.length<=4)
    {
        return 0;
    } 
    Modes=0;  
    for (i=0;i<sPW.length;i++)
    {    
        Modes|=CharMode(sPW.charCodeAt(i));  
    }  
    return bitTotal(Modes);  
}  

function pwStrength(pwd)
{  
    O_color="#eeeeee";  
    L_color="#FF0000";  
    M_color="#FF9900";  
    H_color="#33CC00";  
    if (pwd==null||pwd=='')
    {  
        Lcolor=Mcolor=Hcolor=O_color;  
    }  
    else
    {  
        S_level=checkStrong(pwd);  
        switch(S_level)
        {  
            case 0:  
            Lcolor=Mcolor=Hcolor=O_color;  
            case 1:  
            Lcolor=L_color;  
            Mcolor=Hcolor=O_color;  
            break;  
            case 2:  
            Lcolor=Mcolor=M_color;  
            Hcolor=O_color;  
            break;  
            default:  
            Lcolor=Mcolor=Hcolor=H_color;  
        }  
    }
    $("strength_L").style.background=Lcolor;
    $("strength_M").style.background=Mcolor;
    $("strength_H").style.background=Hcolor;  
    return;  
}
</script>
</head>
<body>
<form runat="server" class="required-validate">
<!--编辑部分开始 -->
<div id="edit">
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="red_xx table_all">
    <tr>
      <td class="title">密码修改</td>
      <td align="right"  nowrap="nowrap"><span class="hui operation">管理导航 - 修改密码</span></td>
    </tr>
  </table>
  <table border="0" align="center" cellpadding="0" cellspacing="0" class="table_all">
    <tr>
      <td height="25">&nbsp;</td>
    </tr>
  </table>
  <table align="center" cellspacing="1" class="table table_all" id="table1">
    <tr class="td_bg">
      <th colspan="2" class="redbold"><span class="tableHeaderText">密码修改</span></th>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>旧 密 码：</strong></span></td>
      <td>
          <asp:TextBox ID="OldPwd" runat="server" CssClass="input1 required validate-ajax-Inc/Validate_EditPwd.aspx" MaxLength="20" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>新 密 码：</strong></span></td>
      <td>
          <asp:TextBox ID="UserPwd" runat="server" CssClass="input1 required" title="新密码不能为空！" MaxLength="20" onKeyUp="pwStrength(this.value);" onBlur="pwStrength(this.value);" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><strong>密码强度：</strong></td>
      <td><table width="150" height="20" border="0" cellpadding="0" cellspacing="0" bgcolor="#cccccc" style='display:inline'>
        <tr align="center" bgcolor="#eeeeee">
          <td width="33%" class="csspwd" id="strength_L">弱</td>
          <td width="33%" class="csspwd" id="strength_M">中</td>
          <td width="33%" class="csspwd" id="strength_H">强</td>
        </tr>
      </table></td>
    </tr>
    <tr onmouseover="over()" onclick="change()" onmouseout="out()" class="td_bg">
      <td><span class="left2"><strong>确认密码：</strong></span></td>
      <td>
          <asp:TextBox ID="UserPwd1" runat="server" CssClass="input1 equals-UserPwd" title="请将确认密码与新密码输入一致！" MaxLength="20" TextMode="Password"></asp:TextBox></td>
    </tr>
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
