<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="User_ascx_left" %>
        <div class="tpl-left-nav tpl-left-nav-hover">
            <div class="tpl-left-nav-title">
                灵心 列表
            </div>
            <div class="tpl-left-nav-list">
                <ul class="tpl-left-nav-menu">
                    <li class="tpl-left-nav-item">
                        <a href="../user/Tlist.aspx" class="nav-link active">
                            <i class="am-icon-home"></i>
                            <span>首页</span>
                        </a>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-bar-chart"></i>
                            <span>查看结果</span>
                        <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                          <ul class="tpl-left-nav-sub-menu" >
                            <li>
                                  <a href="charts.aspx">
                                    <i class="am-icon-angle-right"></i>
                                    <span>统计</span>
                                </a>

                               <%--  <a href="form-line.html">
                                    <i class="am-icon-angle-right"></i>
                                    <span>查看统计</span>
                                </a>--%>
                            </li>
                        </ul>
                    </li>

                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list <%=ry_style %>">
                            <i class="am-icon-table"></i>
                            <span>人员管理</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=ry_ds %>>
                            <li>
                                 <a href="../user/font_list2.aspx"<%=ry_xs %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>来访者管理</span>
                                  
                                </a>
                                  <a href="../user/file.aspx"<%=ry_fl %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>来访者信息导入</span>
                                   
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
                              
                                <a href="../user/new_add.aspx" <%=wz_tj %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>添加文章</span>
                                 
                                </a>

                                <a href="../user/new_list.aspx" <%=wz_list %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>管理文章</span>
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li class="tpl-left-nav-item" <%=fd_style %>>
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-wpforms"></i>
                            <span>辅导记录</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=fd_ds %>>
                            <li>
                                <a href="../user/fd_gt.aspx" <%=fd_gt %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>个体辅导</span>
                                   
                                </a>

                                <a href="../user/fd_tt.aspx" <%=fd_tt %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>团体辅导</span>
                                </a>

                                 <a href="../user/fd_sp.aspx" <%=fd_sp %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>沙盘游戏辅导</span>
                                </a>
                                  <a href="../user/imgkf.aspx" <%=fd_hh %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>绘画治疗</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list" <%=lb_style %>>
                            <i class="am-icon-wpforms"></i>
                            <span>测评管理</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=lb_ds %>>
                            <li>
                                <a href="../user/cp_list.aspx" <%=lb_ds %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>测评任务</span>
                                </a>
                                <a href="../user/Add_cp.aspx" <%=lb_jg %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>发布测评任务</span>
                                </a>

                            
                              
                            </li>
                        </ul>
                    </li>

                    
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list" <%=msg_style %>>
                            <i class="am-icon-wpforms"></i>
                            <span>消息系统</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=msg_ds %>>
                            <li>
                                 <a href="../user/message.aspx" <%=msg_list %>>
                                        <i class="am-icon-angle-right"></i>
                                        <span>消息列表</span>
                                        <%--<i class="tpl-left-nav-content tpl-badge-primary">5</i>--%>
                                </a>

                            </li>
                        </ul>
                    </li>
                      <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list" <%=xt_style %>>
                            <i class="am-icon-wpforms"></i>
                            <span>系统配置</span>
                          <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=xt_ds %>>
                            <li>
                                   <a href="../user/from_xinxi.aspx" <%=xt_glinfo %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>咨询师信息</span>
                                </a>
                                 <a href="../user/from_upwd.aspx" <%=xt_psw %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>密码修改</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="../../loginout.aspx" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-key"></i>
                            <span>退出登录</span>

                        </a>
                    </li>
                </ul>
            </div>
        </div>
