<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Charts_lb.aspx.cs" Inherits="User_Charts_lb" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc1" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc2" %>

<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>灵心后台</title>
    <meta name="description" content="后台">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png">
    <meta name="apple-mobile-web-app-title" content="灵心" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css">
    <link rel="stylesheet" href="assets/css/app.css">
    <script src="assets/js/echarts.min.js"></script>
</head>

<body data-type="index">


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

        <uc1:tongzhi ID="top1" runat="server" />
    </header>







    <div class="tpl-page-container tpl-page-header-fixed">
    <uc2:left ID="left1" runat="server" />
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                测评系统
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist" class="am-icon-home">首页</a></li>
            </ol>
            <div class="tpl-content-scope">
                <div class="note note-info">
                    <h3><%=sc_name %>
                        <span class="close" data-close="note"></span>
                    </h3>
                    <p> <%=sc_note %></p>
                   
                </div>
            </div>

            <div class="row">
               <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat blue">
                        <div class="visual">
                            <i class="am-icon-comments-o"></i>
                        </div>
                        <div class="details">
                            <div class="number"> 1 位</div>
                            <div class="desc"> 咨询师 </div>
                        </div>
                        <a class="more" href="#"> 查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat red">
                        <div class="visual">
                            <i class="am-icon-bar-chart-o"></i>
                        </div>
                        <div class="details">
                            <div class="number"> <%=c_ls %> 位</div>
                            <div class="desc"> 学生参与测试 </div>
                        </div>
                        <a class="more" href="#"> 查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat green">
                        <div class="visual">
                            <i class="am-icon-apple"></i>
                        </div>
                        <div class="details">
                            <div class="number"> <%=c_xs %> 个</div>
                            <div class="desc"> 完成测试 </div>
                        </div>
                        <a class="more" href="#"> 查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
                    </div>
                </div>
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat purple">
                        <div class="visual">
                            <i class="am-icon-android"></i>
                        </div>
                        <div class="details">
                            <div class="number"> <%=c_cp %></div>
                            <div class="desc"> 完成度 </div>
                        </div>
                        <a class="more" href="#"> 查看更多
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
                    </div>
                </div>



            </div>

            <div class="row">
                <div class="am-u-md-6 am-u-sm-12 row-mb">
                    <div class="tpl-portlet">
                        <div class="tpl-portlet-title">
                            <div class="tpl-caption font-green ">
                                <i class="am-icon-cloud-download"></i>
                                <span>测试结果</span>
                            </div>
                            <div class="actions">
                                <ul class="actions-btn">
                                    <%--<li class="red-on">昨天</li>
                                    <li class="green">前天</li>
                                    <li class="blue">本周</li>--%>
                                </ul>
                            </div>
                        </div>

                     
                        <div class="tpl-echarts" id="school_main"></div>
                     
                        <script type="text/javascript">
                            // 基于准备好的dom，初始化echarts实例
                            var myChart = echarts.init(document.getElementById('school_main'));

                            // 指定图表的配置项和数据
                            option = {
                                title: {
                                    text: '<%=lb_name %>',
                                    subtext: '',
                                    x: 'center'
                                },
                                tooltip: {
                                    trigger: 'item',
                                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                                },
                                color: ['green', 'red'],
                                legend: {
                                    orient: 'vertical',
                                    left: 'left',
                                    data: ['正常(得分<<%=fscore %>)', '需干预(得分>=<%=fscore %>)']
                                },
                                series: [
                                {
                                    name: '测评结果',
                                    type: 'pie',
                                    radius: '55%',
                                    center: ['50%', '60%'],
                                    data: [
                                        { value: <%=s_Fscore2 %>, name: '正常(得分<<%=fscore %>)' },
                                        { value: <%=s_Fscore4 %>, name: '需干预(得分>=<%=fscore %>)' }
                                    ],
                                    itemStyle: {
                                        emphasis: {
                                            shadowBlur: 10,
                                            shadowOffsetX: 0,
                                            shadowColor: 'rgba(223,42,27, 0.5)'
                                        }
                                    }
                                }
                            ]
                            };


                            // 使用刚指定的配置项和数据显示图表。
                            myChart.setOption(option);
                        </script>



                    </div>
                </div>
                <div class="am-u-md-6 am-u-sm-12 row-mb">
                    <div class="tpl-portlet">
                        <div class="tpl-portlet-title">
                            <div class="tpl-caption font-red ">
                                <i class="am-icon-bar-chart"></i>
                                <span> 需干预学生资料</span>
                            </div>
                            <div class="actions">
                                <ul class="actions-btn">
                                    <li class="green"><%=s_url %></li>
                                    <%--<li class="green">前天</li>
                                    <li class="dark">本周</li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="tpl-scrollable">
                            

                            <table class="am-table tpl-table">
                                <thead>
                                    <tr class="tpl-table-uppercase">
                                        <th>测试人</th>
                                        <th>得分</th>
                                        <th>测试时间</th>
                                       <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="assets/img/user01.png" alt="" class="user-pic">
                                                    <a class="user-name" href="###"><%#getname(Eval("FstudentNo").ToString())%></a>
                                                </td>
                                                <td class="font-green bold"><%#Eval("Fscore")%></td>
                                                <td><%#Eval("posttime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                                <td>
                                                   
                                                    <a class="user-name" href="/user/chart_scl.aspx?rid=<%#Eval("id")%>&Action=lock">查看</a>
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
            <%=s_count %>




        </div>

    </div>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/iscroll.js"></script>
    <script src="assets/js/app.js"></script>
    </form>
</body>

</html>