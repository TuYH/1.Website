﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart_s.aspx.cs" Inherits="Edu_chart_s" %>
<%@ Register src="ascx/top.ascx" tagname="top" tagprefix="uc1" %>
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

        <uc1:top ID="top1" runat="server" />
    </header>







    <div class="tpl-page-container tpl-page-header-fixed">
    <uc2:left ID="left1" runat="server" />
        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                测评系统
            </div>
            <ol class="am-breadcrumb">
                <li><a href="#" class="am-icon-home">首页</a></li>
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
                            <div class="number"> <%=c_xz %> 个</div>
                            <div class="desc"> 校长 </div>
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
                            <div class="desc"> 老师 </div>
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
                            <div class="desc"> 学生 </div>
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
                            <div class="number"> <%=c_cp %> 条</div>
                            <div class="desc"> 测评数据 </div>
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
                                <span> 全校数据汇总</span>
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
                                    text: ' SCL-90项自觉症状评定量表',
                                    subtext: '',
                                    x: 'center'
                                },
                                tooltip: {
                                    trigger: 'item',
                                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                                },
                                legend: {
                                    orient: 'vertical',
                                    left: 'left',
                                    data: ['很健康（<160）', '健康（160~180）', '亚健康（180~200）', '非健康（>200）']
                                },
                                series: [
                                {
                                    name: '测评结果',
                                    type: 'pie',
                                    radius: '55%',
                                    center: ['50%', '60%'],
                                    data: [
                                        { value: <%=s_Fscore1 %>, name: '很健康' },
                                        { value: <%=s_Fscore2 %>, name: '健康' },
                                        { value: <%=s_Fscore3 %>, name: '亚健康' },
                                        { value: <%=s_Fscore4 %>, name: '非健康' }
                                    ],
                                    itemStyle: {
                                        emphasis: {
                                            shadowBlur: 10,
                                            shadowOffsetX: 0,
                                            shadowColor: 'rgba(0, 0, 0, 0.5)'
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
                                <span> 学生资料</span>
                            </div>
                            <div class="actions">
                                <ul class="actions-btn">
                                    <li class="green"><a href="font_list2.aspx">更多</a></li>
                                    <%--<li class="green">前天</li>
                                    <li class="dark">本周</li>--%>
                                </ul>
                            </div>
                        </div>
                        <div class="tpl-scrollable">
                            <div class="number-stats">
                                <div class="stat-number am-fl am-u-md-6">
                                    <div class="title am-text-right"> 数量 </div>
                                    <div class="number am-text-right am-text-warning"> 460 </div>
                                </div>
                                <div class="stat-number am-fr am-u-md-6">
                                    <div class="title"> 测评次数 </div>
                                    <div class="number am-text-success"> 2460 </div>
                                </div>

                            </div>

                            <table class="am-table tpl-table">
                                <thead>
                                    <tr class="tpl-table-uppercase">
                                        <th>人员</th>
                                        <th>类别</th>
                                        <th>测评次数</th>
                                        <th>预约次数</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="assets/img/user01.png" alt="" class="user-pic">
                                                    <a class="user-name" href="###"><%#getname(Eval("id").ToString())%></a>
                                                </td>
                                                <td>学生</td>
                                                <td><%#gettime(Eval("id").ToString())%></td>
                                                <td class="font-green bold"><%#gettime2(Eval("id").ToString())%></td>
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

    </div>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/iscroll.js"></script>
    <script src="assets/js/app.js"></script>
    </form>
</body>

</html>