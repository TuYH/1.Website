<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_cp.aspx.cs" Inherits="User_Add_cp" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc3" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>测评任务</title>
    <meta name="description" content="这是一个 index 页面">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png"
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
       <uc3:tongzhi ID="tongzhi" runat="server" />
    
    </header>

    <div class="tpl-page-container tpl-page-header-fixed">
    <uc1:left ID="left1" runat="server" RoomID="11"/>

        
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                发布测评任务-第一步选择量表
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">发布测评任务</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 第一步选择量表
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
                        <div class="am-u-sm-12">
                                <%--<table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                            <th class="table-id">ID</th>
                                            <th class="table-title">量表名称</th>
                                            <th class="table-type">状态</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("Fpaperid")%>"></td>
                                                    <td><%#Eval("Fpaperid")%></td>
                                                    <td><a href="#"><%#Eval("Fpapername")%></a></td>
                                                    <td><img src="assets/img/yes.png"></td>
                                                   
                                                  
                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="chart_s.aspx?id=<%#Eval("Fpaperid")%>"><span class="am-icon-pencil-square-o"></span> 统计</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>--%>
                                <div class="am-cf">
                                  <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">选择量表</div>
            <div class="am-u-sm-8 am-u-md-10">
              <select data-am-selected="{searchBox: 1}" multiple="true" list="schList" listKey="schId"  listValue="schNm" id="Select1" runat="server"  >
                <option value="0">请选择</option>
              </select>
            </div>
          </div>
                                  
                                </div>
                                <hr>

                        </div>

                    </div>
                    <div class="am-g">
                        <div class="am-u-sm-12 am-u-md-6">
                            <div class="am-btn-toolbar">
                                <div class="am-btn-group am-btn-group-xs">

                                    <asp:Button ID="Button1" runat="server"  
                                        class="am-btn am-btn-default am-btn-warning" Text="下一步，选择部门科室" 
                                        onclick="Button1_Click" />
                                         <asp:Button ID="Button2" runat="server"  
                                        class="am-btn am-btn-default am-btn-success" Text="下一步，选择来访者个体" 
                                        onclick="Button2_Click" />
                                   
                                </div>
                            </div>
                        </div>
                   
                        <div class="am-u-sm-12 am-u-md-3">
                            <div class="am-input-group am-input-group-sm" style="display:none">
                                <input type="text" class="am-form-field">
                                <span class="am-input-group-btn">
            <button class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" type="button"></button>
          </span>
                            </div>
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