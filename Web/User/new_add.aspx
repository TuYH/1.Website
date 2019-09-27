<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_add.aspx.cs" Inherits="user_new_add" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc2" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>添加文章</title>
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
  
  <form runat="server">
    <header class="am-topbar am-topbar-inverse admin-header">
        <div class="am-topbar-brand">
            <a href="javascript:;" class="tpl-logo">
                <img src="assets/img/logo.png" alt="">
            </a>
        </div>
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right">

        </div>

        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>

        <uc2:tongzhi ID="top" runat="server" />
  
    </header>

    <div class="tpl-page-container tpl-page-header-fixed">
        <uc1:left ID="left1" runat="server" RoomID="3"/>
        



       
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                添加文章
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">添加文章</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 添加文章
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
                                    <label for="user-name" class="am-u-sm-3 am-form-label">标题 </label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        <small>请填写标题文字10-20字左右。</small>
                                    </div>
                                </div>

                           

                             

                                <div class="am-form-group">
                                    <label class="am-u-sm-3 am-form-label">简介 </label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        <small>请填写标题文字30-60字左右。</small>
                                    </div>
                                </div>

                                   <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">选择分类 </label>
                                    <div class="am-u-sm-9">
                                       
                                        <select data-am-selected="{searchBox: 1}" id="Select1" runat="server"></select>
                                    </div>
                                </div>
 <%--  
                                <div class="am-form-group">
                                    <label for="user-weibo" class="am-u-sm-3 am-form-label">添加标签 </label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox ID="TextBox3" runat="server" placeholder="请添加分类用点号隔开"></asp:TextBox>
                                        <div>

                                        </div>
                                    </div>
                                </div>

                             <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">隐藏文章</label>
                                    <div class="am-u-sm-9">
                                        <div class="tpl-switch">
                                            <input type="checkbox" class="ios-switch bigswitch tpl-switch-btn" checked />
                                            <div class="tpl-switch-btn-view">
                                                <div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>--%>

                                <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">文章内容</label>
                                    <div class="am-u-sm-9">
                                        <textarea id="container" cols="20" rows="2" runat="server"></textarea>
                                     
    
                                    </div>
                                </div>

                                <div class="am-form-group">
                                    <div class="am-u-sm-9 am-u-sm-push-3">
                                        <asp:Panel ID="Panel1" runat="server">
                                        
                                        <asp:Button ID="Button1" runat="server" Text="提交" 
                                            class="am-btn am-btn-primary tpl-btn-bg-color-success " 
                                            onclick="Button1_Click"/></asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server">
                                        
                                           <asp:Button ID="Button2" runat="server" Text="更新" 
                                            class="am-btn am-btn-primary tpl-btn-bg-color-success " 
                                            onclick="Button2_Click"/></asp:Panel>
                                    </div>
                                </div>
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