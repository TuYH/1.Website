<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="adminmanage_FileManager_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Style/Manage/Style.css" />
    <link rel="stylesheet" type="text/css" href="Style/Manage/Layout.css" />
    <link rel="stylesheet" type="text/css" href="Style/Manage/Login.css" />
</head>
<body>
<div id="login">
<form id="loginForm" method="post" action="Default.aspx?act=check">
<fieldset>
    <legend>Login Panel</legend>
    <div>
        <label>用户名:</label>
        <input type="text" name="username" id="username" class="txt" style="width: 130px;"/>
    </div>
    <div>
        <label>密　码:</label>
        <input type="password" name="password" id="password" class="txt" style="width: 130px;"/>
    </div>
    <div>
        <label>验证码:</label>
        <input type="text" name="code" id="code" class="txt" size="8" maxlength="4" /> <img src="Client/getCode.aspx" align="absmiddle" />
    </div>
    <div>
        <label>&nbsp;</label>
        <input type="submit" name="submit" class="btn" value="登录" /> <span style="padding-left: 20px;color: red"><%= loginResult %></span>
    </div>
</fieldset>
</form>
</div>
<script type="text/javascript">
    document.getElementById("username").focus();
</script>
</body>
</html>