<%@ Page Language="C#" AutoEventWireup="true" CodeFile="from_g.aspx.cs" Inherits="Edu_from_g" %>
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
  <title>留言</title>
</head>
<body style="background:#ececec">

  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">留言</div>
        <div class="am-header-right am-header-nav">
          <a href="javascript:;" class="iconfont pet_head_gd_ico">&#xe600;</a>
        </div>
      </header>
    </div>

    <div class="pet_more_list">
      <div class="pet_more_list_block">
        <div class="iconfont pet_more_close">×</div>
        <div class="pet_more_list_block">
          <div class="pet_more_list_block_name">
            <div class="pet_more_list_block_name_title">阅读 Read</div>
            <a class="pet_more_list_block_line"> <i class="iconfont pet_nav_xinxianshi pet_more_list_block_line_ico">&#xe61e;</i>
              <div class="pet_more_list_block_line_font">新鲜事</div>
            </a>
            <a class="pet_more_list_block_line"> <i class="iconfont pet_nav_zhangzhishi pet_more_list_block_line_ico">&#xe607;</i>
              <div class="pet_more_list_block_line_font">趣闻</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_kantuya pet_more_list_block_line_ico">&#xe62c;</i>
              <div class="pet_more_list_block_line_font">阅读</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_mengzhuanti pet_more_list_block_line_ico">&#xe622;</i>
              <div class="pet_more_list_block_line_font">专题</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_bk pet_more_list_block_line_ico">&#xe629;</i>
              <div class="pet_more_list_block_line_font">订阅</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_wd pet_more_list_block_line_ico">&#xe602;</i>
              <div class="pet_more_list_block_line_font">专栏</div>
            </a>
            <div class="pet_more_list_block_name_title pet_more_list_block_line_height">服务 Service</div>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_xinxianshi pet_more_list_block_line_ico">&#xe61e;</i>
              <div class="pet_more_list_block_line_font">新鲜事</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_zhangzhishi pet_more_list_block_line_ico">&#xe607;</i>
              <div class="pet_more_list_block_line_font">趣闻</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_kantuya pet_more_list_block_line_ico">&#xe62c;</i>
              <div class="pet_more_list_block_line_font">阅读</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_mengzhuanti pet_more_list_block_line_ico">&#xe622;</i>
              <div class="pet_more_list_block_line_font">专题</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_bk pet_more_list_block_line_ico">&#xe629;</i>
              <div class="pet_more_list_block_line_font">订阅</div>
            </a>
            <a class="pet_more_list_block_line">
              <i class="iconfont pet_nav_wd pet_more_list_block_line_ico">&#xe602;</i>
              <div class="pet_more_list_block_line_font">专栏</div>
            </a>
          </div>
        </div>

      </div>
    </div>

    <div class="pet_content pet_content_list">
      <div class="pet_grzx">    



       
            <div class="tpl-portlet-components">
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 留言
                    </div>
                    <div class="tpl-portlet-input tpl-fz-ml">
                        <div class="portlet-input input-small input-inline">
                            <div class="input-icon right">
                            
                               
                        </div>
                    </div>


                </div>
                <div class="tpl-block ">

                    <div class="am-g tpl-amazeui-form">


                        <div class="am-u-sm-12 am-u-md-9">
                            <form class="am-form am-form-horizontal" runat="server" >
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">姓名 / Name</label>
                                    <div class="am-u-sm-9">
                                       
                                        <asp:TextBox  type="text" id="username" placeholder="姓名 / Name" runat="server"></asp:TextBox>
                                        <small>输入你的名字，让我们记住你。</small>
                                    </div>
                                </div>

                                <div class="am-form-group">
                                    <label for="user-email" class="am-u-sm-3 am-form-label">电子邮件 / Email</label>
                                    <div class="am-u-sm-9">
                                       
                                        <asp:TextBox  type="email" id="useremail" placeholder="输入你的电子邮件 / Email" runat="server"></asp:TextBox>
                                        <small>邮箱你懂得...</small>
                                    </div>
                                </div>

                                <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">电话 / Telephone</label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="userphone" placeholder="输入你的电话号码 / Telephone" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>


                                <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">内容 / Content</label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox  runat="server" placeholder="输入留言内容" Height="200px" id="usercontent"
                                            TextMode="MultiLine"></asp:TextBox>
                                        <small>250字以内...</small>
                                    </div>
                                </div>

                                <div class="am-form-group">
                                    <div class="am-u-sm-9 am-u-sm-push-3">
                                        
                                        <asp:Button ID="Button1" runat="server" Text="保存"  
                                            class="am-btn am-btn-primary" onclick="Button1_Click"/>
                                    </div>
                                </div>
                            </form>
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