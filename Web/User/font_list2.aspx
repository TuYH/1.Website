<%@ Page Language="C#" AutoEventWireup="true" CodeFile="font_list2.aspx.cs" Inherits="User_font_list2" %>
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
    <script src="assets/js/target.js"></script>
    
</head>

<body data-type="generalComponents">
<form id="myform" runat="server">

    <header class="am-topbar am-topbar-inverse admin-header">
        <div class="am-topbar-brand">
            <a href="javascript:;" class="tpl-logo">
                <img src="assets/img/logo.png" alt="">
            </a>
        </div>
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right"></div>
        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>
        <uc2:tongzhi ID="tongzhi1" runat="server" />
    </header>

    <div class="tpl-page-container tpl-page-header-fixed">


    <uc1:left ID="left1" runat="server" RoomID="2"/>
       





        <div class="tpl-content-wrapper">
              <div class="tpl-content-page-title">
                来访者管理
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">来访者管理</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 列表
                    </div>
                    <div class="tpl-portlet-input tpl-fz-ml">
                        <div class="portlet-input input-small input-inline">
                            <div class="input-icon right">
                                <i class="am-icon-search" style="display:none;"></i>
                                <input type="text" class="form-control form-control-solid" placeholder="搜索..." style="display:none;"> </div>
                        </div>
                    </div>


                </div>
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
                   
                        <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-input-group am-input-group-sm">
                                 <input id="Text1" type="text" runat="server" class="am-form-field" placeholder="用户名"/>
                                <span class="am-input-group-btn">
            
                                    <asp:Button ID="Button3" 
                                    class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" 
                                    runat="server" Text="搜索" onclick="Button3_Click" />
          </span>
                            </div>
                        </div>
                    </div>
                    <div class="am-g">
                        <div class="am-u-sm-12">
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                           
                                            <th class="table-title">用户名</th>
                                            <th class="table-author am-hide-sm-only">姓名</th>
                                         <th class="table-type">状态</th>
                                           
                                            <th class="table-date am-hide-sm-only">注册日期</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                   
                                                    <td><a href="#"><%#Eval("UserName")%></a></td>
                                                    <td class="am-hide-sm-only"><%#getname(Eval("id").ToString())%></td>
                                                <td><%#getzt(Eval("islock").ToString())%></td>
                                                   
                                                    <td class="am-hide-sm-only"><%#Eval("RegTime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="info.aspx?id=<%#Eval("id")%>&Action=lock"><span class="am-icon-pencil-square-o"></span>个人报告</a>
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="fd_gtadd.aspx?id=<%#Eval("id")%>"><span class="am-icon-pencil-square-o"></span>辅导</a>
                                                                <%--<a onClick="return confirm('确认删除')" class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary" href="font_list2.aspx?id=<%#Eval("id")%>&Action=del"><span class="am-icon-trash-o"></span> 删除</a>--%>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>
                                <div class="am-cf">

                                    <div class="am-fr">
                                        <ul class="am-pagination tpl-pagination">
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </ul>
                                    </div>
                                </div>
                                <hr>

                        </div>

                    </div>
                </div>
                <div class="tpl-alert"></div>
            </div>










        </div>

    </div>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
    </form>
</body>

</html>
