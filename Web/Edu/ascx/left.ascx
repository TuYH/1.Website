<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="edu_ascx_left" %>
<div class="tpl-left-nav tpl-left-nav-hover">
            <div class="tpl-left-nav-title">
                灵心 列表
            </div>
            <div class="tpl-left-nav-list">
                <ul class="tpl-left-nav-menu">
                    <li class="tpl-left-nav-item">
                        <a href="Ulist.aspx" class="nav-link active">
                            <i class="am-icon-home"></i>
                            <span>首页</span>
                        </a>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-bar-chart"></i>
                            <span>统计</span>
                            <i class="tpl-left-nav-content tpl-badge-danger">12</i>
                        </a>
                          <ul class="tpl-left-nav-sub-menu" >
                            <li>
                                <a href="chart.aspx">
                                    <i class="am-icon-angle-right"></i>
                                    <span>查看结果</span>
                                </a>

                                 <a href="form-line.html">
                                    <i class="am-icon-angle-right"></i>
                                    <span>查看统计</span>
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list <%=school_style %>">
                            <i class="am-icon-table"></i>
                            <span>学校管理</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=school_ds %>>
                            <li>
                                <a href="../edu/school_list.aspx" <%=school_xx %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>学校管理</span>
                                    <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                </a>
                                <a href="../edu/font_list3.aspx" <%=school_xz %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>校长管理</span>
                                    <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                </a>
                                <a href="../edu/font_list.aspx" <%=school_ls %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>老师管理</span>
                                    <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                </a>

                                <a href="../edu/font_list2.aspx"<%=school_xs %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>学生管理</span>
                                    <i class="tpl-left-nav-content tpl-badge-success">18</i>
                                </a>
                             
                             
                            </li>
                        </ul>
                    </li>

                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list <%=wz_style %>">
                            <i class="am-icon-wpforms"></i>
                            <span>文章系统</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=wz_ds %>>
                            <li>
                                <a href="../edu/new_fl.aspx" <%=wz_fl %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>文章分类管理</span>
                                    <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                </a>
                                <a href="../edu/font_line.aspx" <%=wz_tj %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>添加文章</span>
                                    <i class="am-icon-star tpl-left-nav-content-ico am-fr am-margin-right"></i>
                                </a>

                                <a href="../edu/new_list.aspx" <%=wz_list %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>管理文章</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                  
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list" <%=lb_style %>>
                            <i class="am-icon-wpforms"></i>
                            <span>量表系统</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=lb_ds %>>
                            <li>
                               

                                <a href="../edu/Lb_list.aspx" <%=lb_jg %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>查看结果</span>
                                </a>

                                 <a href="form-line.html" <%=lb_tj %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>查看统计</span>
                                </a>
                            </li>
                        </ul>
                    </li>

                    
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-wpforms"></i>
                            <span>消息系统</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" >
                            <li>
                                 <a href="form-news.html">
                                        <i class="am-icon-angle-right"></i>
                                        <span>消息列表</span>
                                        <i class="tpl-left-nav-content tpl-badge-primary">5</i>
                                </a>

                            </li>
                        </ul>
                    </li>
                      <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-wpforms"></i>
                            <span>系统配置</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" >
                            <li>
                              

                                 <a href="form-line.html">
                                    <i class="am-icon-angle-right"></i>
                                    <span>管理员信息</span>
                                </a>
                                 <a href="form-line.html">
                                    <i class="am-icon-angle-right"></i>
                                    <span>密码修改</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="login.html" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-key"></i>
                            <span>登录</span>

                        </a>
                    </li>
                </ul>
            </div>
        </div>