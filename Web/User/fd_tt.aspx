<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fd_tt.aspx.cs" Inherits="User_fd_tt" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="top" tagprefix="uc3" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>团体辅导记录</title>
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
       <uc3:top ID="top1" runat="server" />
    
    </header>

    <div class="tpl-page-container tpl-page-header-fixed">
    <uc1:left ID="left1" runat="server" RoomID="16"/>

        
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                团体辅导记录
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">团体辅导记录</li>
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
                                      <a href="fd_ttadd.aspx" class="am-btn am-btn-default am-btn-success"><span class="am-icon-plus"></span>
新增</a>
                                  
                                    <asp:Button ID="Button1" runat="server"  
                                        class="am-btn am-btn-default am-btn-warning" Text="完成" 
                                        onclick="Button1_Click" />
                                    <asp:Button ID="Button2" runat="server"  
                                        class="am-btn am-btn-default am-btn-danger" Text="删除" onclick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                   
                        <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-input-group am-input-group-sm">
                              <%--  <input type="text" class="am-form-field">
                                <span class="am-input-group-btn">
            <button class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" type="button"></button>
          </span>--%>
                            </div>
                        </div>
                    </div>
                    <div class="am-g">
                        <div class="am-u-sm-12">
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                            <th class="table-id">ID</th>
                                            <th class="table-title">标题</th>
                                            <th class="table-author am-hide-sm-only">分类</th>
                                            <th class="table-type">状态</th>
                                           
                                            <th class="table-date am-hide-sm-only">添加日期</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                         <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                    <td><%#Eval("id")%></td>
                                                    <td><%#getname(Eval("classid").ToString())%><%#Eval("title")%></td>
                                                    <td class="am-hide-sm-only pet_hd_block_tag"><%#getzt(Eval("IsStatus").ToString())%></td>
                                                   <td class="am-hide-sm-only"><%#Eval("posttime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>

                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary" href="fd_ttadd.aspx?wzid=<%#Eval("id")%>"><span class="am-icon-trash-o"></span> 查看</a>
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary" href="fd_tt.aspx?cid=<%#Eval("id")%>&Ation=end"><span class="am-icon-trash-o"></span> 设置完成</a>
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
