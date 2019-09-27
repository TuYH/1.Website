<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sc_fladd.aspx.cs" Inherits="user_sc_fladd" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc2" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>测评系统</title>
    <meta name="description" content="这是一个 index 页面">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png">
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css">
    <link rel="stylesheet" href="assets/css/app.css">
</head>

<body data-type="generalComponents">
  
  <form id="Form1" runat="server">
    <header class="am-topbar am-topbar-inverse admin-header">
        <div class="am-topbar-brand">
            <a href="javascript:;" class="tpl-logo">
                <img src="assets/img/logo.png" alt="">
            </a>
        </div>
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right"></div>
        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>
        <uc2:tongzhi ID="top" runat="server" />
  
    </header>







    <div class="tpl-page-container tpl-page-header-fixed">
        <uc1:left ID="left1" runat="server" RoomID="3"/>
        


      
       
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                添加分类
            </div>
            <ol class="am-breadcrumb">
                <li><a href="#" class="am-icon-home">首页</a></li>
                <li><a href="#">栏目分类</a></li>
                <li class="am-active">添加分类</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 添加分类
                    </div>
                    <div class="tpl-portlet-input tpl-fz-ml">
                        <div class="portlet-input input-small input-inline">
                            <div class="input-icon right">
                                <i class="am-icon-search" style="display:none"></i>
                                <input type="text" class="form-control form-control-solid" placeholder="搜索..." style="display:none"> </div>
                        </div>
                    </div>


                </div>

                <div class="tpl-block">

                    <div class="am-g">
                        <div class="tpl-form-body tpl-form-line">
                         
                            <div class="am-form tpl-form-line-form">
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">分类名称 </label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        <small>请填写3-6字左右文字。</small>
                                    </div>
                                </div>

                           

                             

                               <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">选择上级 </label>
                                    <div class="am-u-sm-9">
                                       
                                        <select data-am-selected="{searchBox: 1}" id="Select1" runat="server">
                                         
                                        </select>
                                    </div>
                                </div>
                                 <div class="am-form-group">
                                    <div class="am-u-sm-9 am-u-sm-push-3">
                                        
                                        <asp:Button ID="Button1" runat="server" Text="提交" class="am-btn am-btn-primary tpl-btn-bg-color-success " onclick="Button1_Click"/>
                                    </div>
                                </div>
                                <div class="am-form-group" style="height:300px;"></div>
                            </div>

                        </div>
                    </div>
                </div>


            </div>










        </div>

    </div>

</form>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
    <!-- 配置文件 -->
    <script type="text/javascript" src="../ueditor/ueditor.config.js"></script>
    <!-- 编辑器源码文件 -->
    <script type="text/javascript" src="../ueditor/ueditor.all.js"></script>
    <script type="text/javascript" src="../ueditor/lang/zh-cn/zh-cn.js"></script>
    <!-- 实例化编辑器 -->
    <script type="text/javascript">
        var ue = UE.getEditor('container');
    </script>
</body>

</html>