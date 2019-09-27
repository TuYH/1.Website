<%@ Page Language="C#" AutoEventWireup="true" CodeFile="from_x.aspx.cs" Inherits="User_from_x" %>
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
  <title>完善个人信息</title>
</head>
<body style="background:#ececec">

  <div class="pet_mian" >
    <div class="pet_head">
      <header data-am-widget="header"
          class="am-header am-header-default pet_head_block">
        <div class="am-header-left am-header-nav ">
          <a href="javascript:history.go(-1)" class="iconfont pet_head_jt_ico">&#xe601;</a>
        </div>
<div class="pet_news_list_tag_name">完善个人信息</div>
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
                        <span class="am-icon-code"></span> 完善信息
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
                            <form id="Form1" class="am-form am-form-horizontal" runat="server" >
                                <div class="am-form-group">
                                    <label for="user-name" class="am-u-sm-3 am-form-label">姓名 / Name</label>
                                    <div class="am-u-sm-9">
                                       
                                        <asp:TextBox  type="text" id="username" placeholder="姓名 / Name" runat="server"></asp:TextBox>
                                        <small>请输入你的真实名字</small>
                                    </div>
                                </div>

                                <div class="am-form-group">
                                    <label for="user-email" class="am-u-sm-3 am-form-label">性别 / sex</label>
                                    <div class="am-u-sm-9">
                                        <select runat="server" id="sex">
                                        <option value="">请选择..</option>
                                         <option value="男">男</option>
	                                     <option value="女">女</option>
                                         </select>
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-email" class="am-u-sm-3 am-form-label">民族 / Nationality</label>
                                    <div class="am-u-sm-9">
                                       
                                       <select runat="server" id="Nationality">
                                        <option value="">请选择..</option>
	                                        <option value="汉族">汉族</option>
	                                        <option value="蒙古族">蒙古族</option>
	                                        <option value="回族">回族</option>
	                                        <option value="藏族">藏族</option>
	                                        <option value="维吾尔族">维吾尔族</option>
	                                        <option value="苗族">苗族</option>
	                                        <option value="彝族">彝族</option>
	                                        <option value="壮族">壮族</option>
	                                        <option value="布依族">布依族</option>
	                                        <option value="朝鲜族">朝鲜族</option>
	                                        <option value="满族">满族</option>
	                                        <option value="侗族">侗族</option>
	                                        <option value="瑶族">瑶族</option>
	                                        <option value="白族">白族</option>
	                                        <option value="土家族">土家族</option>
	                                        <option value="哈尼族">哈尼族</option>
	                                        <option value="哈萨克族">哈萨克族</option>
	                                        <option value="傣族">傣族</option>
	                                        <option value="黎族">黎族</option>
	                                        <option value="傈傈族">傈傈族</option>
	                                        <option value="佤族">佤族</option>
	                                        <option value="畲族">畲族</option>
	                                        <option value="高山族">高山族</option>
	                                        <option value="拉祜族">拉祜族</option>
	                                        <option value="水族">水族</option>
	                                        <option value="东乡族">东乡族</option>
	                                        <option value="纳西族">纳西族</option>
	                                        <option value="景颇族">景颇族</option>
	                                        <option value="柯尔克孜族">柯尔克孜族</option>
	                                        <option value="土族">土族</option>
	                                        <option value="达斡尔族">达斡尔族</option>
	                                        <option value="仫佬族">仫佬族</option>
	                                        <option value="羌族">羌族</option>
	                                        <option value="布朗族">布朗族</option>
	                                        <option value="撒拉族">撒拉族</option>
	                                        <option value="毛难族">毛难族</option>
	                                        <option value="仡佬族">仡佬族</option>
	                                        <option value="锡伯族">锡伯族</option>
	                                        <option value="阿昌族">阿昌族</option>
	                                        <option value="普米族">普米族</option>
	                                        <option value="塔吉克族">塔吉克族</option>
	                                        <option value="怒族">怒族</option>
	                                        <option value="乌孜别克族">乌孜别克族</option>
	                                        <option value="俄罗斯族">俄罗斯族</option>
	                                        <option value="鄂温克族">鄂温克族</option>
	                                        <option value="德昂族">德昂族</option>
	                                        <option value="保安族">保安族</option>
	                                        <option value="裕固族">裕固族</option>
	                                        <option value="京族">京族</option>
	                                        <option value="塔塔尔族">塔塔尔族</option>
	                                        <option value="独龙族">独龙族</option>
	                                        <option value="鄂伦春族">鄂伦春族</option>
	                                        <option value="赫哲族">赫哲族</option>
	                                        <option value="门巴族">门巴族</option>
	                                        <option value="珞巴族">珞巴族</option>
	                                        <option value="基诺族">基诺族</option>
                                      </select>
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">生日 / Birthday</label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="Birthday" placeholder="生日 / Birthday" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                 <div class="am-form-group">
                                    <label for="user-phone" class="am-u-sm-3 am-form-label">电话 / Telephone</label>
                                    <div class="am-u-sm-9">
                                        <asp:TextBox type="tel" id="Telephone" placeholder="电话 / Telephone" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>
                              <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">就诊时间 / Visit</label>
                                    <div class="am-u-sm-9">
                                         <asp:TextBox id="Textjztime" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">部门 / Content</label>
                                    <div class="am-u-sm-9">
                                     <asp:TextBox id="nianji" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="am-form-group">
                                    <label for="user-intro" class="am-u-sm-3 am-form-label">科室 / Content</label>
                                    <div class="am-u-sm-9">
                                    
                                    <asp:TextBox  id="banji" placeholder="" runat="server"></asp:TextBox>
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
