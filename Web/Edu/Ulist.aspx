﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ulist.aspx.cs" Inherits="Edu_Ulist" %>
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
                    <h3>测评系统
                        <span class="close" data-close="note"></span>
                    </h3>
                    <p> 系统内置多个国际国内通用心理量表，量表范围涵盖认知、情绪、人格、学习、心理健康、职业兴趣等多方面，可有效实现心理特征的全方位扫描。</p>
                    <p><span class="label label-danger">提示:</span> 测验完成后，系统自动生成报告，报告以图文并茂的形式，丰富多样。。
                    </p>
                </div>
            </div>

            <div class="row">
                <div class="am-u-lg-3 am-u-md-6 am-u-sm-12">
                    <div class="dashboard-stat blue">
                        <div class="visual">
                            <i class="am-icon-comments-o"></i>
                        </div>
                        <div class="details">
                            <div class="number"> 4 条</div>
                            <div class="desc"> 新消息 </div>
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
                            <div class="number"> 62 所</div>
                            <div class="desc"> 学校 </div>
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
                            <div class="number"> 73 名</div>
                            <div class="desc"> 校长 </div>
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
                            <div class="number"> 7867 条</div>
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
                                <span> Cloud 数据统计</span>
                            </div>
                            <div class="actions">
                                <ul class="actions-btn">
                                    <li class="red-on">昨天</li>
                                    <li class="green">前天</li>
                                    <li class="blue">本周</li>
                                </ul>
                            </div>
                        </div>

                        <!--此部分数据请在 js文件夹下中的 app.js 中的 “百度图表A” 处修改数据 插件使用的是 百度echarts-->
                        <div class="tpl-echarts" id="tpl-echarts-A">

                        </div>
                    </div>
                </div>
                <div class="am-u-md-6 am-u-sm-12 row-mb">
                    <div class="tpl-portlet">
                        <div class="tpl-portlet-title">
                            <div class="tpl-caption font-red ">
                                <i class="am-icon-bar-chart"></i>
                                <span> Cloud 动态资料</span>
                            </div>
                            <div class="actions">
                                <ul class="actions-btn">
                                    <li class="purple-on">昨天</li>
                                    <li class="green">前天</li>
                                    <li class="dark">本周</li>
                                </ul>
                            </div>
                        </div>
                        <div class="tpl-scrollable">
                            <div class="number-stats">
                                <div class="stat-number am-fl am-u-md-6">
                                    <div class="title am-text-right"> Total </div>
                                    <div class="number am-text-right am-text-warning"> 2460 </div>
                                </div>
                                <div class="stat-number am-fr am-u-md-6">
                                    <div class="title"> Total </div>
                                    <div class="number am-text-success"> 2460 </div>
                                </div>

                            </div>

                            <table class="am-table tpl-table">
                                <thead>
                                    <tr class="tpl-table-uppercase">
                                        <th>人员</th>
                                        <th>余额</th>
                                        <th>次数</th>
                                        <th>效率</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user01.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">禁言小张</a>
                                        </td>
                                        <td>￥3213</td>
                                        <td>65</td>
                                        <td class="font-green bold">26%</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user02.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">Alex.</a>
                                        </td>
                                        <td>￥2635</td>
                                        <td>52</td>
                                        <td class="font-green bold">32%</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user03.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">Tinker404</a>
                                        </td>
                                        <td>￥1267</td>
                                        <td>65</td>
                                        <td class="font-green bold">51%</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user04.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">Arron.y</a>
                                        </td>
                                        <td>￥657</td>
                                        <td>65</td>
                                        <td class="font-green bold">73%</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user05.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">Yves</a>
                                        </td>
                                        <td>￥3907</td>
                                        <td>65</td>
                                        <td class="font-green bold">12%</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="assets/img/user06.png" alt="" class="user-pic">
                                            <a class="user-name" href="###">小黄鸡</a>
                                        </td>
                                        <td>￥900</td>
                                        <td>65</td>
                                        <td class="font-green bold">10%</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="am-u-md-6 am-u-sm-12 row-mb">

                    <div class="tpl-portlet">
                        <div class="tpl-portlet-title">
                            <div class="tpl-caption font-green ">
                                <span>指派任务</span>
                                <span class="caption-helper">16 件</span>
                            </div>
                            <div class="tpl-portlet-input">
                                <div class="portlet-input input-small input-inline">
                                    <div class="input-icon right">
                                        <i class="am-icon-search"></i>
                                        <input type="text" class="form-control form-control-solid" placeholder="搜索..."> </div>
                                </div>
                            </div>
                        </div>
                        <div id="wrapper" class="wrapper">
                            <div id="scroller" class="scroller">
                                <ul class="tpl-task-list">
                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 灵心 Icon 组件目前使用了 Font Awesome </span>
                                            <span class="label label-sm label-success">技术部</span>
                                            <span class="task-bell">
                                            <i class="am-icon-bell-o"></i>
                                        </span>
                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 在 data-am-dropdown 里指定要适应到的元素，下拉内容的宽度会设置为该元素的宽度。当然可以直接在 CSS 里设置下拉内容的宽度。 </span>
                                            <span class="label label-sm label-danger">运营</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 使用 LESS： 通过设置变量 @fa-font-path 覆盖默认的值，如 @fa-font-path: "../fonts";。这个变量定义在 icon.less 里。 </span>
                                            <span class="label label-sm label-warning">市场部</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 添加 .am-btn-group-justify class 让按钮组里的按钮平均分布，填满容器宽度。 </span>
                                            <span class="label label-sm label-default">已废弃</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 按照示例组织好 HTML 结构（不加 data-am-dropdown 属性），然后通过 JS 来调用。 </span>
                                            <span class="label label-sm label-success">技术部</span>
                                            <span class="task-bell">
                                            <i class="am-icon-bell-o"></i>
                                        </span>
                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>


                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 添加 .am-btn-group-justify class 让按钮组里的按钮平均分布，填满容器宽度。 </span>
                                            <span class="label label-sm label-default">已废弃</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 使用 LESS： 通过设置变量 @fa-font-path 覆盖默认的值，如 @fa-font-path: "../fonts";。这个变量定义在 icon.less 里。 </span>
                                            <span class="label label-sm label-warning">市场部</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 添加 .am-btn-group-justify class 让按钮组里的按钮平均分布，填满容器宽度。 </span>
                                            <span class="label label-sm label-default">已废弃</span>

                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>

                                    <li>
                                        <div class="task-checkbox">
                                            <input type="hidden" value="1" name="test">
                                            <input type="checkbox" class="liChild" value="2" name="test"> </div>
                                        <div class="task-title">
                                            <span class="task-title-sp"> 按照示例组织好 HTML 结构（不加 data-am-dropdown 属性），然后通过 JS 来调用。 </span>
                                            <span class="label label-sm label-success">技术部</span>
                                            <span class="task-bell">
                                            <i class="am-icon-bell-o"></i>
                                        </span>
                                        </div>
                                        <div class="task-config">
                                            <div class="am-dropdown tpl-task-list-dropdown" data-am-dropdown>
                                                <a href="###" class="am-dropdown-toggle tpl-task-list-hover " data-am-dropdown-toggle>
                                                    <i class="am-icon-cog"></i> <span class="am-icon-caret-down"></span>
                                                </a>
                                                <ul class="am-dropdown-content tpl-task-list-dropdown-ul">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-check"></i> 保存 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-pencil"></i> 编辑 </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="am-icon-trash-o"></i> 删除 </a>
                                                    </li>
                                                </ul>


                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="am-u-md-6 am-u-sm-12 row-mb">
                    <div class="tpl-portlet">
                        <div class="tpl-portlet-title">
                            <div class="tpl-caption font-green ">
                                <span>项目进度</span>
                            </div>

                        </div>

                        <div class="am-tabs tpl-index-tabs" data-am-tabs>
                            <ul class="am-tabs-nav am-nav am-nav-tabs">
                                <li class="am-active"><a href="#tab1">进行中</a></li>
                                <li><a href="#tab2">已完成</a></li>
                            </ul>

                            <div class="am-tabs-bd">
                                <div class="am-tab-panel am-fade am-in am-active" id="tab1">
                                    <div id="wrapperA" class="wrapper">
                                        <div id="scroller" class="scroller">
                                            <ul class="tpl-task-list tpl-task-remind">
                                                <li>
                                                    <div class="cosB">
                                                        12分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco">
                        <i class="am-icon-bell-o"></i>
                      </span>

                                                        <span> 注意：Chrome 和 Firefox 下， display: inline-block; 或 display: block; 的元素才会应用旋转动画。<span class="tpl-label-info"> 提取文件
                                                            <i class="am-icon-share"></i>
                                                        </span></span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        36分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-danger">
                        <i class="am-icon-bolt"></i>
                      </span>

                                                        <span> FontAwesome 在绘制图标的时候不同图标宽度有差异， 添加 .am-icon-fw 将图标设置为固定的宽度，解决宽度不一致问题（v2.3 新增）。</span>
                                                    </div>

                                                </li>

                                                <li>
                                                    <div class="cosB">
                                                        2小时前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-info">
                        <i class="am-icon-bullhorn"></i>
                      </span>

                                                        <span> 使用 flexbox 实现，只兼容 IE 10+ 及其他现代浏览器。</span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        1天前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-warning">
                        <i class="am-icon-plus"></i>
                      </span>

                                                        <span> 部分用户反应在过长的 Tabs 中滚动页面时会意外触发 Tab 切换事件，用户可以选择禁用触控操作。</span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        12分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco">
                        <i class="am-icon-bell-o"></i>
                      </span>

                                                        <span> 注意：Chrome 和 Firefox 下， display: inline-block; 或 display: block; 的元素才会应用旋转动画。<span class="tpl-label-info"> 提取文件
                                                            <i class="am-icon-share"></i>
                                                        </span></span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        36分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-danger">
                        <i class="am-icon-bolt"></i>
                      </span>

                                                        <span> FontAwesome 在绘制图标的时候不同图标宽度有差异， 添加 .am-icon-fw 将图标设置为固定的宽度，解决宽度不一致问题（v2.3 新增）。</span>
                                                    </div>

                                                </li>

                                                <li>
                                                    <div class="cosB">
                                                        2小时前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-info">
                        <i class="am-icon-bullhorn"></i>
                      </span>

                                                        <span> 使用 flexbox 实现，只兼容 IE 10+ 及其他现代浏览器。</span>
                                                    </div>

                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="am-tab-panel am-fade" id="tab2">
                                    <div id="wrapperB" class="wrapper">
                                        <div id="scroller" class="scroller">
                                            <ul class="tpl-task-list tpl-task-remind">
                                                <li>
                                                    <div class="cosB">
                                                        12分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco">
                        <i class="am-icon-bell-o"></i>
                      </span>

                                                        <span> 注意：Chrome 和 Firefox 下， display: inline-block; 或 display: block; 的元素才会应用旋转动画。<span class="tpl-label-info"> 提取文件
                                                            <i class="am-icon-share"></i>
                                                        </span></span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        36分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-danger">
                        <i class="am-icon-bolt"></i>
                      </span>

                                                        <span> FontAwesome 在绘制图标的时候不同图标宽度有差异， 添加 .am-icon-fw 将图标设置为固定的宽度，解决宽度不一致问题（v2.3 新增）。</span>
                                                    </div>

                                                </li>

                                                <li>
                                                    <div class="cosB">
                                                        2小时前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-info">
                        <i class="am-icon-bullhorn"></i>
                      </span>

                                                        <span> 使用 flexbox 实现，只兼容 IE 10+ 及其他现代浏览器。</span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        1天前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-warning">
                        <i class="am-icon-plus"></i>
                      </span>

                                                        <span> 部分用户反应在过长的 Tabs 中滚动页面时会意外触发 Tab 切换事件，用户可以选择禁用触控操作。</span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        12分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco">
                        <i class="am-icon-bell-o"></i>
                      </span>

                                                        <span> 注意：Chrome 和 Firefox 下， display: inline-block; 或 display: block; 的元素才会应用旋转动画。<span class="tpl-label-info"> 提取文件
                                                            <i class="am-icon-share"></i>
                                                        </span></span>
                                                    </div>

                                                </li>
                                                <li>
                                                    <div class="cosB">
                                                        36分钟前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-danger">
                        <i class="am-icon-bolt"></i>
                      </span>

                                                        <span> FontAwesome 在绘制图标的时候不同图标宽度有差异， 添加 .am-icon-fw 将图标设置为固定的宽度，解决宽度不一致问题（v2.3 新增）。</span>
                                                    </div>

                                                </li>

                                                <li>
                                                    <div class="cosB">
                                                        2小时前
                                                    </div>
                                                    <div class="cosA">
                                                        <span class="cosIco label-info">
                        <i class="am-icon-bullhorn"></i>
                      </span>

                                                        <span> 使用 flexbox 实现，只兼容 IE 10+ 及其他现代浏览器。</span>
                                                    </div>

                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                            </div>
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