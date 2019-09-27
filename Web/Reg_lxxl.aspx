<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg_lxxl.aspx.cs" Inherits="Reg_lxxl" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>超级管理员</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
<meta name="format-detection" content="telephone=no">
<meta name="renderer" content="webkit">
<meta http-equiv="Cache-Control" content="no-siteapp" />
<link rel="stylesheet" href="css/amazeui.min.css"/>
<link rel="stylesheet" href="css/style.css"/>
<script src="js/jquery.min.js"></script>
<script src="js/amazeui.min.js"></script>
</head>

<body>
<div class="container">
	<header data-am-widget="header" class="am-header am-header-default my-header">
      <div class="am-header-left am-header-nav">
        <a href="javascript:history.go(-1)" class="">
          <i class="am-header-icon am-icon-chevron-left"></i>
        </a>
      </div>
      <h1 class="am-header-title">
        <a href="#title-link" class="">生成二维码</a>
      </h1>
      <div class="am-header-right am-header-nav">
        <a href="#right-link" class="">
          <i class="am-header-icon  am-icon-home"></i>
        </a>
      </div>
    </header>
    <div class="cart-panel">
		<form id="Form1" class="am-form" runat="server">
          <%--  <div class="am-form-group am-form-icon">
                <i class="am-icon-user" style="color:#329cd9"></i>
                <asp:TextBox ID="TextBox1" runat="server"  class="am-form-field  my-radius" placeholder="请输入学校名字"></asp:TextBox>
            </div>--%>
            <div class="am-form-group am-form-icon">
                <i class="am-icon-lock" style="color:#329cd9"></i>
                <asp:TextBox ID="TextBox2" runat="server" type="password"  class="am-form-field  my-radius" placeholder="请输管理员识别码"></asp:TextBox>
            </div>

        
            <p class="am-text-center">
            <asp:Button ID="Button1" runat="server" Text="生成老师、学生注册二维码"  
                    class="am-btn am-btn-danger am-radius am-btn-block" onclick="Button1_Click"/>
            </p>
        </form>
    </div>
    
    <footer data-am-widget="footer" class="am-footer am-footer-default" data-am-footer="{  }">
        <hr data-am-widget="divider" style="" class="am-divider am-divider-default"/>
      <div class="am-footer-miscs ">
        <p>CopyRight©2017 AllMobilize Inc.</p>
        <p>灵心心理，专业心理康复设备提供商。</p>
      </div>
    </footer>
    <!--底部-->
    <div data-am-widget="navbar" class="am-navbar am-cf my-nav-footer " id="">
      <ul class="am-navbar-nav am-cf am-avg-sm-4 my-footer-ul">
        <li>
          <a href="/wap/" class="">
            <span class="am-icon-home"></span>
            <span class="am-navbar-label">首页</span>
          </a>
        </li>
        <li>
          <a href="###" class="">
            <span class=" am-icon-phone"></span>
            <span class="am-navbar-label">电话</span>
          </a>
        </li>
        <li>
          <a href="###" class="">
            <span class=" am-icon-comments"></span>
            <span class="am-navbar-label">产品</span>
          </a>
        </li>
        <li>
          <a href="#" class="">
            <span class=" am-icon-map-marker"></span>
            <span class="am-navbar-label">测评</span>
          </a>
        </li>
        <li style="position:relative">
          <a href="javascript:;" onClick="showFooterNav();" class="">
            <span class="am-icon-user"></span>
            <span class="am-navbar-label">会员</span>
          </a>
          <div class="footer-nav" id="footNav">
          	<span class=" am-icon-bank"><a href="#">买家中心</a></span>
            <span class="am-icon-suitcase"><a href="#">卖家中心</a></span>
            <span class="am-icon-usd"><a href="#">我的钱包</a></span>
            <span class="am-icon-user"><a href="#">个人资料</a></span>
            <span class="am-icon-th-list"><a href="#">帮助中心</a></span>
            <span class="am-icon-comments"><a href="#">消息中心</a></span>
            <span class="am-icon-power-off"><a href="#">安全退出</a></span>
          </div>
        </li>

      </ul>
      <script>
          function showFooterNav() {
              $("#footNav").toggle();
          }
	  </script>
    </div>
</div>
</body>
</html>