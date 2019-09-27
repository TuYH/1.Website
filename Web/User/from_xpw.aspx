<%@ Page Language="C#" AutoEventWireup="true" CodeFile="from_xpw.aspx.cs" Inherits="User_from_xpw" %>
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
  <title>修改个人密码</title>
  <script language="javascript" type="text/javascript">
      function SubCheck() {
          if ($("jiupwd").value == "") {
              $("Msg").innerHTML = "用户名不能为空！";
              $("jiupwd").focus();
              return false;
          }
          if ($("tUserPwd").value == "") {
              $("Msg").innerHTML = "密码不能为空！";
              $("tUserPwd").focus();
              return false;
          }
          if ($("tCode").value == "") {
              $("Msg").innerHTML = "验证码不能为空！";
              $("tCode").focus();
              return false;
          }
      }
</script>
</head>
<body style="background:#ececec">
<form id="Form2" runat="server" onsubmit="return SubCheck()">
  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">修改密码</div>
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
                        <span class="am-icon-code"></span> 修改密码
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
                            <div class="am-form am-form-horizontal" runat="server" >
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">原密码 </label>
                                    <div class="am-u-sm-9">
                                       
                                        <asp:TextBox  type="text" id="jiupwd" placeholder="原密码 " runat="server"></asp:TextBox>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <small>请输入你的原密码</small>
                                        </asp:Panel>
                                        
                                    </div>
                                </div>

                                <div class="am-form-group">
                              
                                <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">新密码 </label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="xinpwd1" placeholder="新密码 / 新密码" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                 <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">重复新密码</label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="xinpwd2" placeholder="重复新密码" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label"></label>
                                    <div class="am-u-sm-9">
                                        <div id="Msg" style="color:#D70C18; text-align:center;"></div>
                                        
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <div class="am-u-sm-9 am-u-sm-push-3">
                                        
                                        <asp:Button ID="Button1" runat="server" Text="更新"  
                                            class="am-btn am-btn-primary" onclick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>










        

        <div class="pet_article_footer_info">Copyright(c)2015 PetShow All Rights Reserved</div>
      </div>
    </div>
</form>
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
