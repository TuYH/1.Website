<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="edumaste_info" %>
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
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right">

        </div>

        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>

        <uc2:tongzhi ID="top" runat="server" />
  
    </header>

    <div class="tpl-page-container tpl-page-header-fixed">
        <uc1:left ID="left1" runat="server" RoomID="2"/>
        



       
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                来访者信息
            </div>
            <ol class="am-breadcrumb">
                <li><a href="olist.aspx" class="am-icon-home">首页</a></li>
                <li><a href="font_list2.aspx">来访者列表</a></li>
                <li >来访者信息</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 来访者信息
                    </div>
                   


                </div>

                <div class="tpl-block">

                    <div class="am-g">
                        <div class="tpl-form-body tpl-form-line">
                         
                            <div class="am-form tpl-form-line-form">
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">用户名 </label>
                                    <div class="am-u-sm-9"><asp:TextBox ID="Textxh" runat="server" ReadOnly="True"></asp:TextBox></div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">姓名</label>
                                    <div class="am-u-sm-9"><asp:TextBox ID="Textname" runat="server"></asp:TextBox></div>
                                </div>

                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">民族 </label>
                                    <div class="am-u-sm-9"><asp:TextBox ID="Textmz" runat="server"></asp:TextBox></div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">部门 </label>
                                    <div class="am-u-sm-9"><asp:TextBox ID="TextBbj" runat="server"></asp:TextBox></div>
                                </div>
                                 <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">科室 </label>
                                    <div class="am-u-sm-9"><asp:TextBox ID="Textnj" runat="server"></asp:TextBox></div>
                                </div>
                             

                                <div class="am-form-group">
                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="更新个人数据"  class="am-btn am-btn-primary tpl-btn-bg-color-success"/>
                                     &nbsp;&nbsp;
                                     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="初始化个人密码"  class="am-btn am-btn-primary tpl-btn-bg-color-success"/>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>


            </div>

            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 测评信息
                    </div>
                   


                </div>

                <div class="tpl-block">

                    <div class="am-g">
                        <div class="tpl-form-body tpl-form-line">
                         
                            <div class="am-form tpl-form-line-form">
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                            <th class="table-id">ID</th>
                                            <th class="table-typee">用户名</th>
                                            <th class="table-title">量表名称</th>
                                            <th class="table-type">测试得分</th>
                                            <th class="table-date am-hide-sm-only">测试日期</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                    <td><%#Eval("Fresultid")%></td>
                                                    <td><a href="#"><%#getname(Eval("Fresultid").ToString())%></a></td>
                                                    <td><a href="#"><%#getlbname(Eval("Fpaperid").ToString())%></a></td>
                                                    <td class="am-hide-sm-only"><%#Eval("Fscore").ToString().Replace(".00","")%></td>
                                                    <td class="am-hide-sm-only"><%#Eval("postTime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="chart_scl.aspx?rid=<%#Eval("id")%>&Action=lock"><span class="am-icon-pencil-square-o"></span> 查看</a>
                                                                
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>
                             

                                
                            </div>

                        </div>
                    </div>
                </div>


            </div>




            <%--<div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 预约信息
                    </div>
                   


                </div>

                <div class="tpl-block">

                    <div class="am-g">
                        <div class="tpl-form-body tpl-form-line">
                         
                            <div class="am-form tpl-form-line-form">
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                            <th class="table-id">ID</th>
                                            <th class="table-typee">标题</th>
                                            <th class="table-date am-hide-sm-only">预约日期</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                    <td><%#Eval("Fresultid")%></td>

                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="chart_scl.aspx?rid=<%#Eval("id")%>&Action=lock"><span class="am-icon-pencil-square-o"></span> 查看</a>
                                                                
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>
                             

                                
                            </div>

                        </div>
                    </div>
                </div>


            </div>--%>



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
   
</body>

</html>