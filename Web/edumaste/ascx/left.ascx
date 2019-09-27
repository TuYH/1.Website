<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="edumaste_ascx_left" %>
        <div class="tpl-left-nav tpl-left-nav-hover">
            <div class="tpl-left-nav-title">
                灵心 列表
            </div>
            <div class="tpl-left-nav-list">
                <ul class="tpl-left-nav-menu">
                    <li class="tpl-left-nav-item">
                        <a href="olist.aspx" class="nav-link active">
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
                                <a href="../edumaste/font_list.aspx" <%=ry_ls %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>咨询师管理</span>
                               
                                </a>

                                <a href="../edumaste/font_list2.aspx"<%=ry_xs %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>来访者管理</span>
                                   
                                </a>
                                <a href="../edumaste/file.aspx"<%=ry_fl %>>
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
                                <a href="../edumaste/new_fl.aspx" <%=wz_fl %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>文章分类管理</span>
                               
                                </a>
                                <a href="../edumaste/new_add.aspx" <%=wz_tj %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>添加文章</span>
                                
                                </a>

                                <a href="../edumaste/new_list.aspx" <%=wz_list %>>
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
                               

                                <a href="../edumaste/Lb_list.aspx?lbid=1" <%=lb_jg %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>心理普查</span>
                                </a>
                                 <a href="../edumaste/Lb_list.aspx?lbid=2" <%=lb_jg %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>心理自测</span>
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
                                <a href="../edumaste/form_info.aspx" <%=xt_infp %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>基本信息</span>
                                </a>
                                 <a href="../edumaste/sc_fl.aspx?cid=2" <%=xt_banji2 %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>添加单位架构</span>
                                </a>

                                 <a href="../edumaste/from_xinxi.aspx" <%=xt_glinfo %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>管理员信息</span>
                                </a>
                                 <a href="../edumaste/from_upwd.aspx" <%=xt_psw %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>密码修改</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="javascript:;" class="nav-link tpl-left-nav-link-list" <%=yun_style %>>
                            <i class="am-icon-wpforms"></i>
                            <span>云平台管理</span>
                            <i class="am-icon-angle-right tpl-left-nav-more-ico am-fr am-margin-right"></i>
                        </a>
                        <ul class="tpl-left-nav-sub-menu" <%=yun_ds %>>
                            <li>
                                <a href="../edumaste/charts0.aspx" <%=yun_yy %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>音乐放松系统</span>
                                </a>
                                 <a href="../edumaste/charts1.aspx" <%=yun_sp %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>沙盘应用管理系统</span>
                                </a>

                                 <a href="../edumaste/charts2.aspx" <%=yun_fkyy %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>智能音乐反馈系统</span>
                                </a>
                                 <a href="../edumaste/chartss.aspx" <%=yun_xw %>>
                                    <i class="am-icon-angle-right"></i>
                                    <span>漩涡减压反馈系统</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="tpl-left-nav-item">
                        <a href="../../loginout.aspx" class="nav-link tpl-left-nav-link-list">
                            <i class="am-icon-key"></i>
                            <span>退出</span>

                        </a>
                    </li>
                </ul>
            </div>
        </div>
