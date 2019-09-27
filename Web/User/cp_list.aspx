<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cp_list.aspx.cs" Inherits="User_cp_list" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc3" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>学校管理</title>
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
    <link rel="stylesheet" href="../css/lrtk.css" />


<script type="text/javascript" src="../js/jquery.min2.js"></script>
    <script type="text/javascript" src="../js/jquery.imgbox.pack.js"></script>
<script type="text/javascript">
    $(document).ready(function () {


        $("#example1, #example2, #example3, #example4, #example5, #example6, #example7, #example8, #example9, #example10, #example11, #example12, #example13, #example14, #example15, #example16, #example17, #example18, #example19, #example20").imgbox({
            'speedIn': 0,
            'speedOut': 0,
            'alignment': 'center',
            'overlayShow': true,
            'allowMultiple': false
        });
    });
	</script>

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
                测评任务列表
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">测评任务列表</li>
            </ol>
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 测评任务列表
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
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                           
                                            <th class="table-title">任务名称</th>
                                            <th class="table-type">发布时间</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                 
                                                    <td><%#Eval("title")%>【<%#getlbname(Eval("cp_set").ToString())%>】</td>
                                                    <td><%#Eval("PostTime", "{0:yyyy-MM-dd}")%></td>
                                                   
                                                  
                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="cp_list.aspx?id=<%#Eval("cp_id")%>&Action=dec"><span class="am-icon-pencil-square-o"></span> 导出数据</a>
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="Charts_lb.aspx?id=<%#Eval("cp_id")%>"><span class="am-icon-pencil-square-o"></span> 统计</a>
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" id="example<%# Container.ItemIndex+1 %>" href="../images/t1/<%#Eval("CreateUsers")%>"><span class="am-icon-pencil-square-o"></span> 二维码测试</a>
                                                                <a onClick="return confirm('确认删除')" class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="cp_list.aspx?rid=<%#Eval("cp_id")%>&Action=del"><span class="am-icon-pencil-square-o"></span> 删除</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>
                                <div class="am-cf">
                                 <ul class="am-pagination tpl-pagination">
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </ul>
                                  
                                </div>
                                <hr>

                        </div>

                    </div>
                    <div class="am-g">
                        <div class="am-u-sm-12 am-u-md-6">
                            <div class="am-btn-toolbar">
                                <div class="am-btn-group am-btn-group-xs">

                                 
                                   
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



    </form>
</body>

</html>