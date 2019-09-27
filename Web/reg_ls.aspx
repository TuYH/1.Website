<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg_ls.aspx.cs" Inherits="reg_ls" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>咨询师注册</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
<meta name="format-detection" content="telephone=no">
<meta name="renderer" content="webkit">
<meta http-equiv="Cache-Control" content="no-siteapp" />
<link rel="stylesheet" href="css/amazeui.min.css"/>
<link rel="stylesheet" href="css/style.css"/>

</head>

<body>
<form id="Form1" class="am-form" runat="server" method="post" action="reg_ls.aspx" onsubmit="return SubCheck()">
<div class="container">
	<header data-am-widget="header" class="am-header am-header-default my-header">
      <div class="am-header-left am-header-nav">
        <a href="javascript:history.go(-1)" class="">
          <i class="am-header-icon am-icon-chevron-left"></i>
        </a>
      </div>
      <h1 class="am-header-title">
        <a href="#title-link" class="">咨询师注册</a>
      </h1>
      <div class="am-header-right am-header-nav">
        <a href="#right-link" class="">
          <i class="am-header-icon  am-icon-home"></i>
        </a>
      </div>
    </header>
    <div class="cart-panel">
		
            <div class="am-form-group am-form-icon">
                <i class="am-icon-user" style="color:#329cd9"></i>
                <asp:TextBox ID="TextBox1" runat="server"  class="am-form-field  my-radius" placeholder="请输入您的用户名"  onblur="checkUsername()"></asp:TextBox>
            </div>
            <div class="am-form-group am-form-icon">
                <i class="am-icon-lock" style="color:#329cd9"></i>
                <asp:TextBox ID="TextBox2" runat="server" type="password"  class="am-form-field  my-radius" placeholder="请输入您的密码"  onblur="checkpassword()"></asp:TextBox>
            </div>
            <div class="am-form-group am-form-icon">
                <i class="am-icon-lock" style="color:#e9c740"></i>
                <asp:TextBox ID="TextBox3" runat="server" type="password"  class="am-form-field  my-radius" placeholder="请重复输入一次密码" onblur="checkpassword2()"></asp:TextBox>
            </div>
            <div class="am-form-group am-form-icon">
                <i class="am-icon-envelope" style="color:#78c3ca"></i>
                
                <asp:TextBox ID="TextBox4" runat="server"  class="am-form-field  my-radius" placeholder="请输入您的姓名" onblur="checkname()"></asp:TextBox>
            </div>
            <div class="am-form-group am-form-icon">
                <i class="am-icon-phone" style="color:#f09513"></i>
                
                <asp:TextBox ID="TextBox5" runat="server"  class="am-form-field  my-radius" placeholder="请输入手机号"></asp:TextBox>
            </div>

            <div class="am-checkbox">
              <label>
                <input type="checkbox" checked="checked"> 我已阅读并同意<a href="#">《协议》</a>
              </label>
            </div>
            <p class="am-text-center">
            <asp:Button ID="Button1" runat="server" Text="立即注册"  
                    class="am-btn am-btn-danger am-radius am-btn-block" onclick="Button1_Click"/>
            </p>
        
    </div>
    
    <footer data-am-widget="footer" class="am-footer am-footer-default" data-am-footer="{  }">
        <hr data-am-widget="divider" style="" class="am-divider am-divider-default"/>
      <div class="am-footer-miscs ">
        <p>CopyRight©2017 AllMobilize Inc.</p>
        <p>灵心心理，专业心理康复设备提供商。</p>
      </div>
    </footer>
    <!--底部-->
    
</div>

</form>
   <script  language="javascript" type="text/javascript">
       //判断用户名的合法js代码

       function checkUsername() {
           var username = document.getElementById("TextBox1").value;
           if (username.length > 19) {

               alert("长度不要超过18位");

               return false;
           }
           if (username == "" || username == null) {

               alert("用户名不能为空！");
               return false;
           }
           else {
               re = /select|update|delete|exec|count|and|-|'|"|=|;|>|<|%/i;
               if (re.test(username)) {

                   alert("请勿填写非法字符！"); //注意中文乱码


                   return false;
               }
               return true;
           }

       }

       function checkpassword() {
           var checkpassword = document.getElementById("TextBox2").value;
           var triggerElement = document.activeElement;
           if (checkpassword == "" || checkpassword == null) {
               alert("密码不能为空！");
               return false;
           }
           else {
               re = /select|update|delete|exec|count|and|-|'|"|=|;|>|<|%/i;
               if (re.test(username)) {
                   alert("请勿填写非法字符！"); //注意中文乱码

                   return false;
               }
               return true;
           }

       }
       function checkpassword2() {
           var id = document.getElementById("TextBox2");
           var id2 = document.getElementById("TextBox3");
           var password = id.value;
           var password2 = id2.value;
           if (password != password2) {
               alert("密码不一致");
               return false;
           }
           return true;

       }

       function checkname() {
           var name = document.getElementById("TextBox4").value;
           var triggerElement = document.activeElement;
           if (name == "" || name == null) {
               alert("昵称不能为空！");
               return false;
           }
           else {
               var regu = "^[\u4e00-\u9fa5]+$";
               var re = new RegExp(regu);
               if (re.test(str)) {
                   return true;
               }
               else {
                   alert("请输入汉字、字母或数字");
                   return false;
               }
               return true;
           }

       }
       function SubCheck() {

           var bool = true; //表示校验通过  
           if (!checkUsername()) {
               bool = false;
           }
           if (!checkpassword()) {
               bool = false;
           }
           if (!checkpassword2()) {
               bool = false;
           }
           if (!checkname()) {
               bool = false;
           }

           return bool;

       }

        </script>
</body>
</html>