<%@ Page Language="C#" AutoEventWireup="true" CodeFile="from_g.aspx.cs" Inherits="User_from_g" %>
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
      <link rel="stylesheet" href="assets/css/amazeui.datetimepicker.css"/>
  <title>心理咨询师预约</title>
</head>
<body style="background:#ececec">

  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">心理咨询师预约</div>
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
                <div class="portlet-title">
                    <div class="caption font-green bold">
                        <span class="am-icon-code"></span> 心理咨询师预约
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
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">选择咨询师 / Select</label>
                                    <div class="am-u-sm-9">
                                         <select id="Select1" runat="server"></select>
                                    </div>
                                </div>
                                  <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">预约时间 / Content</label>
                                    <div class="am-u-sm-9">
                                         <div class="am-input-group am-datepicker-date" data-am-datepicker="{format: 'yyyy-mm-dd'}">
                                         
                                             <input id="Text_time" type="text" runat="server" class="am-form-field" placeholder="日历组件" readonly/>
                                          <span class="am-input-group-btn am-datepicker-add-on">
                                            <button class="am-btn am-btn-default" type="button"><span class="am-icon-calendar"></span> </button>
                                          </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">电话 / Telephone</label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="userphone" placeholder="输入你的联系方式" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>


                                <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">内容 / Content</label>
                                    <div class="am-u-sm-9">
                                        
                                        <asp:TextBox  runat="server" placeholder="输入想咨询内容或者目前遇到的问题" Height="200px" id="usercontent"
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
    <script src="assets/js/amazeui.datetimepicker.min.js"></script>
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