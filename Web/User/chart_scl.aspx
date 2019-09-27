<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart_scl.aspx.cs" Inherits="User_chart_scl" %>
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
    <script src="assets/js/echarts.min.js"></script>

    <script id=Script1 language=javascript>
    <!--
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);

            //alert(prnhtml);

            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));

            window.document.body.innerHTML = prnhtml;
            window.print();
        } 
    -->
    </script>
</head>

<body data-type="chart">


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

        <uc2:left ID="left1" runat="server" />
        





        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                灵心
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist" class="am-icon-home">首页</a></li>
                
                <li class="am-active">统计</li>
            </ol>
            
            <div class="tpl-portlet-components">
                    
                       <input type="button" name="print" value="预览并打印" onclick="preview()">
                 <!--startprint-->
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> <%=lb_name %>结果
                    </div>
                    <div class="tpl-portlet-input tpl-fz-ml">
                        <div class="portlet-input input-small input-inline">
                            <div class="input-icon right">
                                <i class="am-icon-search"></i>
                                <input type="text" class="form-control form-control-solid" placeholder="搜索..."> </div>
                        </div>
                    </div>
                    

                </div>
                <div class="tpl-block">
                   <div class="tpl-blockcoseC">姓名：<%=str_name %></div>
                   <div class="tpl-blockcoseC">得分：<%=str_df %></div>
                   <div class="tpl-blockcoseC">结果：<%=str_jieguo %></div>
                   <div class="tpl-blockcoseC">测试时间：<%=str_time %></div>
                   <div class="tpl-blockcoseC">答案明细：<%=str_daan %></div>

                   <br /><br />
                   <div class="tpl-blockcoseC">
                       
                       
                       </div>
                   <br />
                   
                
                    <ul class="tpl-task-list tpl-task-remind">
                    <div class="tabler">
                       <%=str_content %>
                       </div>
                    <!--endprint-->

                    </ul>
        <div class="tpl-echarts" id="school_main"></div>
                   <script type="text/javascript">
                            // 基于准备好的dom，初始化echarts实例
                            var myChart = echarts.init(document.getElementById('school_main'));

                            // 指定图表的配置项和数据
                              option = {

                                        tooltip: {
                                            trigger: 'axis',
                                        },
                                        legend: {
                                            data: ['<%=str_name %>']
                                        },
                                        grid: {
                                            left: '3%',
                                            right: '4%',
                                            bottom: '3%',
                                            containLabel: true
                                        },
                                        xAxis: [{
                                            type: 'category',
                                            boundaryGap: true,
                                            data: [<%=resname %>]
                                        }],

                                        yAxis: [{
                                            type: 'value'
                                        }],
                                        series: [{
                                                name: '<%=str_name %>',
                                                type: 'line',
                                                stack: '总量',
                                                areaStyle: { normal: {} },
                                                data: [<%=str_note %>],
                                                itemStyle: {
                                                    normal: {
                                                        color: '#59aea2'
                                                    },
                                                    emphasis: {

                                                    }
                                                },
                                                markLine : {
                                                 data : [{type : 'average', name: '警戒线',yAxis:2}],
                                                 lineStyle: {

                                                   normal: {color: '#8e44ad'}
                                                    }
                                            }
                                            }]
                                    };


                            // 使用刚指定的配置项和数据显示图表。
                            myChart.setOption(option);
                        </script>

    
                </div>

            </div>

            








        </div>

    </div>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/iscroll.js"></script>
    <script src="assets/js/app.js"></script>
</body>

</html>