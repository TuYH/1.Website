<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logine.aspx.cs" Inherits="logine" %>

<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>登录-测评系统</title>
    <meta name="description" content="这是一个 index 页面">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="edumaste/assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="edumaste/assets/i/app-icon72x72@2x.png">
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <link rel="stylesheet" href="edumaste/assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="edumaste/assets/css/admin.css">
    <link rel="stylesheet" href="edumaste/assets/css/app.css">
</head>

<body data-type="login" style="background-color: #334054;">
    <form id="Form1" class="am-form" runat="server" method="post" action="logine.aspx" onsubmit="return SubCheck()">
        <div class="am-g myapp-login">
            <div class="myapp-login-logo-block  tpl-login-max">
                <div class="myapp-login-logo-text">
                    <div class="myapp-login-logo-text">
                        <img src="img/lx.png" />测评系统<span> Login</span> <i class="am-icon-skyatlas"></i>
                    </div>
                </div>

                <div class="login-font">
                    <i>Log In </i>or <span><a href="reg_xs.aspx">注册</a></span>
                </div>
                <div class="am-u-sm-10 login-am-center">

                    <fieldset>
                        <div class="am-form">
                            <div class="am-form-group">
                                <input type="text" class="" name="username" id="username" placeholder="输入用户名" runat="server" onblur="checkUserName()" oninput="checkUserName()">
                                <span style="color: red" class="default" id="nameErr"></span>

                            </div>
                            <div class="am-form-group">
                                <input type="password" class="" name="pwd" id="pwd" placeholder="输入密码" runat="server" onblur="checkPassword()" oninput="checkPassword()">
                                <span style="color: red" class="default" id="passwordErr"></span>

                            </div>
                        </div>
                        <p>
                            <asp:Button ID="Button1" runat="server" Text="登录"
                                class="am-btn am-btn-default" OnClick="Button1_Click1" />
                        </p>
                    </fieldset>
                </div>
            </div>
        </div>
    </form>
    <script language="javascript" type="text/javascript">
        //判断用户名的合法js代码

        //用户账号验证
        function checkUserName() {
            var username = document.getElementById('username');
            var errname = document.getElementById('nameErr');
            var pattern = /select|update|delete|exec|count and|-|'|"|=|;|>|<|%/i;  //请输入正确的手机号格式
            if (username.value.length == 0) {
                errname.innerHTML = "账号不能为空"
                errname.className = "error"
                return false;
            }
            if (pattern.test(username.value)) {
                errname.innerHTML = "请输入正确的账号格式"
                errname.className = "error"
                return false;
            } else {
                errname.innerHTML = "";
                errname.className = "success";
                return true;
            }
        }
        //密码验证
        function checkPassword() {
            var userpasswd = document.getElementById('pwd');
            var errPasswd = document.getElementById('passwordErr');
            var pattern = /^\w{6,12}$/; //密码要在6-8位 
            if (!pattern.test(userpasswd.value)) {
                errPasswd.innerHTML = "密码的范围应在6-12位"
                errPasswd.className = "error"
                return false;
            }
            else {
                errPasswd.innerHTML = "";
                errPasswd.className = "success";
                return true;
            }
        }

        function SubCheck() {

            var bool = true; //表示校验通过  
            if (!checkUserName()) {
                bool = false;
            }
            if (!checkPassword()) {
                bool = false;
            }


            return bool;

        }

    </script>
</body>
</html>
