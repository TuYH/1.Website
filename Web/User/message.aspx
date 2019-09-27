<%@ Page Language="C#" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="user_message" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc1" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc2" %>
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


    <form id="form1" runat="server">


    <header class="am-topbar am-topbar-inverse admin-header">
        <div class="am-topbar-brand">
            <a href="javascript:;" class="tpl-logo">
                <img src="assets/img/logo.png" alt="">
            </a>
        </div>
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right">

        </div>

        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>

        <uc1:tongzhi ID="tongzhi1" runat="server" />
    </header>







    <div class="tpl-page-container tpl-page-header-fixed">

       <uc2:left ID="left1" runat="server" RoomID="19"/>

        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                消息
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">消息列表</li>
            </ol>
            <div class="tpl-portlet-components">
              
                <div class="tpl-block">
                    <div class="am-g">
                        <div class="am-u-sm-12 am-u-md-6">
                            <div class="am-btn-toolbar">
                                 <div class="am-btn-group am-btn-group-xs">

                                    <asp:Button ID="Button1" runat="server"  
                                        class="am-btn am-btn-default am-btn-warning" Text="审核" 
                                        onclick="Button1_Click" />
                                    <asp:Button ID="Button2" runat="server"  
                                        class="am-btn am-btn-default am-btn-danger" Text="删除" onclick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                      <%--  <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-form-group">
                                <select data-am-selected="{btnSize: 'sm'}">
              <option value="option1">所有类别</option>
              <option value="option2">IT业界</option>
              <option value="option3">数码产品</option>
              <option value="option3">笔记本电脑</option>
              <option value="option3">平板电脑</option>
              <option value="option3">只能手机</option>
              <option value="option3">超极本</option>
            </select>
                            </div>
                        </div>--%>
                        <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-input-group am-input-group-sm">
                                <input type="text" class="am-form-field">
                                <span class="am-input-group-btn">
            <button class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" type="button"></button>
          </span>
                            </div>
                        </div>
                    </div>

                    <ul class="tpl-task-list tpl-task-remind">
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                             <li><div class="cosB"><%#Eval("PostTime", "{0:yyyy-MM-dd HH:mm:ss}")%></div><div class="cosA"><input type="checkbox" name="Id" value="<%#Eval("id")%>"> <span class="cosIco"><i class="am-icon-bell-o"></i></span>
                                <span><a href="message.aspx?id=<%#Eval("id")%>&Action=lock"> <%#Eval("Content")%></a></span><%#getzt(Eval("IsStatus").ToString())%></div>
                             </li>
                        </ItemTemplate>
                        </asp:Repeater>

                       
                      
                    </ul>
                </div>

            </div>
            <div class="am-cf">

                                    <div class="am-fr">
                                      
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                      
                                    </div>
                                </div>









        </div>

    </div>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
    </form>
</body>

</html>