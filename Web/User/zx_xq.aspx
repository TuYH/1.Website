<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zx_xq.aspx.cs" Inherits="User_zx_xq" %>
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
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css">
    <link rel="stylesheet" href="assets/css/app.css">
  <title>我的预约</title>
</head>
<body style="background:#ececec">

  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">我的预约</div>
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



       
            <div class="tpl-portlet-components">
      <div class="pet_content2">


  <div class="pet_comment_list_wap"><div class="pet_comment_list_title">咨询过程</div>

  <div data-am-widget="tabs" class="am-tabs am-tabs-default pet_comment_list_tab" >

      <div class="am-tabs-bd pet_pl_list">
          <div data-tab-panel-0 class="am-tab-panel am-active">
            <div class="pet_comment_list_block">
              <div class="pet_comment_list_block_l"><img src="../img/qq1.png" alt=""></div>
              <div class="pet_comment_list_block_r">
                <div class="pet_comment_list_block_r_info"><%=xs_name %></div>
                <div class="pet_comment_list_block_r_text"><%=xs_note %></div>
                <div class="pet_comment_list_block_r_bottom">
                  <div class="pet_comment_list_bottom_info_l"><%=xs_time%></div>
                </div>
              </div>
            </div>
            <div class="pet_comment_list_block">
              <div class="pet_comment_list_block_l"><img src="../img/qq2.jpg" alt=""></div>
              <div class="pet_comment_list_block_r">
                <div class="pet_comment_list_block_r_info"><%=ls_name %></div>
                <div class="pet_comment_list_block_r_text"><span>回复：</span><%=ls_note%></div>
                <div class="pet_comment_list_block_r_bottom">
                  <div class="pet_comment_list_bottom_info_l"><%=ls_time%></div>
                </div>
              </div>
            </div>
                     
          </div>

      </div>
  </div>




  </div>





<div class="pet_article_footer_info">Copyright(c)2015 Amaze UI All Rights Reserved</div>
</div>
</div>
</div>
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
</body>
  </html>