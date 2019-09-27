<%@ Page Language="C#" AutoEventWireup="true" CodeFile="twolist.aspx.cs" Inherits="User_twolist" %>
<%@ Register src="ascx/daohang.ascx" tagname="daohang" tagprefix="uc1" %>

<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
  <meta name="keywords" content="" />
  <meta name="description" content="" />
  <link rel="stylesheet" href="../css/amazeui.min.css">
  <link rel="stylesheet" href="../css/wap.css">
    <link rel="stylesheet" href="assets/css/amazeui.css" />
    <link rel="stylesheet" href="assets/css/admin.css">
    <link rel="stylesheet" href="assets/css/app.css">
  <title><%=sc_name %></title>
</head>
<body style="background:#ececec">
    <form id="form1" runat="server">
  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name"><%=sc_name %></div>
        <div class="am-header-right am-header-nav">
          <a href="javascript:;" class="iconfont pet_head_gd_ico">&#xe600;</a>
        </div>
      </header>
    </div>

    <div class="pet_more_list">
      <div class="pet_more_list_block">
        <div class="iconfont pet_more_close">×</div>
        <uc1:daohang ID="daohang1" runat="server" />
      </div>
    </div>

    <div class="pet_content pet_content_list">
      <div class="pet_grzx">

          <div class="pet_grzx_nr">
              <div class="pet_grzx_ico">
                  <img src="../img/qq1.png" alt="">
              </div>
              <div class="pet_grzx_name"><%=u_name %></div>
              <div class="pet_grzx_map"><%=sc_name %></div>
              <div class="pet_grzx_num_font">
路漫漫其修远兮，吾将上下而求索。
              </div>
              <div class="pet_grzx_num">
                <span><%=cs_cun %>次<i>心理测试</i></span>
                <span><%=yy_cun %>次<i>预约</i></span>
              </div>

          </div>

          <div class="pet_grzx_list">
             <div class="pet_content_main pet_article_like_delete">
          <div data-am-widget="list_news" class="am-list-news am-list-news-default am-no-layout">
            <div class="tpl-portlet-components2">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        功能
                    </div>
                    <div class="tpl-portlet-input tpl-fz-ml">
                        <div class="portlet-input input-small input-inline">
                            <div class="input-icon right">
                                
                        </div>
                    </div>


                </div>
                <div class="tpl-block">
                    <div class="am-g">
                        <div class="am-u-sm-12">
                            <div class="am-btn-toolbar">
                                <div class="am-btn-group2 am-btn-group-xs">
                                    <a href="from_x.aspx?userid=<%=userid %>" class="am-btna am-btn-default am-btn-success2"><span class="am-icon-plus"></span> 完善个人信息</a><br />
                                    <div style="height:2px;"></div>
                                    <a href="zx_msg.aspx" class="am-btna am-btn-default am-btn-secondary"><span class="am-icon-save"></span>心理测评</a><br />
                                    <div style="height:2px;"></div>
                                    <%--<a href="#" class="am-btna am-btn-default am-btn-secondary"><span class="am-icon-save"></span> 心里自测</a><br />
                                    <div style="height:2px;"></div>--%>
                                    <a href="from_g.aspx?userid=<%=userid %>" class="am-btna am-btn-default am-btn-warning"><span class="am-icon-archive"></span> 咨询师预约</a><br />
                                    <div style="height:2px;"></div>
                                    <a href="zx_list.aspx" class="am-btna am-btn-default am-btn-danger"><span class="am-icon-trash-o"></span> 查看我的预约</a>
                                    <div style="height:2px;"></div>
                                    <a href="from_xpw.aspx" class="am-btna am-btn-default am-btn-danger2" style="width:100%"><span class="am-icon-trash-o"></span> 修改密码</a>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    
                </div>
                <div class="tpl-alert"></div>
            </div>

            </div>

          </div>

          </div>
<div class="pet_article_dowload">
      <div class="pet_article_dowload_title">关于灵心心理</div>
      <div class="pet_article_dowload_content"><div class="pet_article_dowload_triangle"></div>
      <div class="pet_article_dowload_ico"><img src="../img/lx.png" alt=""></div>
      <div class="pet_article_dowload_content_font">
主要以设计开发及生产心理康复器材（音乐放松椅、心理沙盘、宣泄器材团体心理活动器材等）及心理软件和心理中心建造整体解决方案。
      </div>
     
      </div>
  </div>
        </div>

        <div class="pet_article_footer_info">Copyright(c)2017 PetShow All Rights Reserved</div>
      </div>
    </div>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/amazeui.min.js"></script>
    <script>
        $(function () {

            // 动态计算新闻列表文字样式
            auto_resize();
            $(window).resize(function () {
                auto_resize();
            });
            $('.am-list-thumb img').load(function () {
                auto_resize();
            });
            $('.pet_article_like li:last-child').css('border', 'none');
            function auto_resize() {
                $('.pet_list_one_nr').height($('.pet_list_one_img').height());
                // alert($('.pet_list_one_nr').height());
            }
            $('.pet_article_user').on('click', function () {
                if ($('.pet_article_user_info_tab').hasClass('pet_article_user_info_tab_show')) {
                    $('.pet_article_user_info_tab').removeClass('pet_article_user_info_tab_show').addClass('pet_article_user_info_tab_cloes');
                } else {
                    $('.pet_article_user_info_tab').removeClass('pet_article_user_info_tab_cloes').addClass('pet_article_user_info_tab_show');
                }
            });

            $('.pet_head_gd_ico').on('click', function () {
                $('.pet_more_list').addClass('pet_more_list_show');
            });
            $('.pet_more_close').on('click', function () {
                $('.pet_more_list').removeClass('pet_more_list_show');
            });
        });

</script>
    </div>
    
    </form>
</body>
  </html>