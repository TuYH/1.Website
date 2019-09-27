<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="User_index" %>

<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
  <meta name="keywords" content="" />
  <meta name="description" content="" />
  <link rel="stylesheet" href="../css/amazeui.min.css">
  <link rel="stylesheet" href="../css/wap.css">
  <title>审核中。。。</title>
</head>
<body style="background:#ececec">
  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">审核中</div>
        <div class="am-header-right am-header-nav">
          <a href="javascript:;" class="iconfont pet_head_gd_ico">&#xe600;</a>
        </div>
      </header>
    </div>

   

    <div class="pet_content pet_content_list">
      <div class="pet_grzx">

          <div class="pet_grzx_nr">
              <div class="pet_grzx_ico">
                  <img src="../img/lx.png" alt="">
              </div>
              <div class="pet_grzx_name">灵心心理</div>
              <div class="pet_grzx_map">心理设备提供商</div>
              <div class="pet_grzx_num_font" style="font-size:30px;">
审核中,请联系您的管理员。。。或者<a href="../logine.aspx">登录</a>
              </div>
              <div class="pet_grzx_num">
               
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

        <div class="pet_article_footer_info">Copyright(c)2015 PetShow All Rights Reserved</div>
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