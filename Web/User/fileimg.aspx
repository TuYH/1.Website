<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fileimg.aspx.cs" Inherits="User_fileimg" %>
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
  <script type="text/javascript">
      function $(id) {
          return document.getElementById(id);
      }
      var userAgent = navigator.userAgent.toLowerCase();
      var is_opera = userAgent.indexOf('opera') != -1 && opera.version();
      var is_moz = (navigator.product == 'Gecko') && userAgent.substr(userAgent.indexOf('firefox') + 8, 3);
      var is_ie = (userAgent.indexOf('msie') != -1 && !is_opera) && userAgent.substr(userAgent.indexOf('msie') + 5, 3);
      var is_mac = userAgent.indexOf('mac') != -1;
      function AC_GetArgs(args, classid, mimeType) {
          var ret = new Object();
          ret.embedAttrs = new Object();
          ret.params = new Object();
          ret.objAttrs = new Object();
          for (var i = 0; i < args.length; i = i + 2) {
              var currArg = args[i].toLowerCase();
              switch (currArg) {
                  case "classid": break;
                  case "pluginspage": ret.embedAttrs[args[i]] = 'http://www.macromedia.com/go/getflashplayer'; break;
                  case "src": ret.embedAttrs[args[i]] = args[i + 1]; ret.params["movie"] = args[i + 1]; break;
                  case "codebase": ret.objAttrs[args[i]] = 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0'; break;
                  case "onafterupdate": case "onbeforeupdate": case "onblur": case "oncellchange": case "onclick": case "ondblclick": case "ondrag": case "ondragend":
                  case "ondragenter": case "ondragleave": case "ondragover": case "ondrop": case "onfinish": case "onfocus": case "onhelp": case "onmousedown":
                  case "onmouseup": case "onmouseover": case "onmousemove": case "onmouseout": case "onkeypress": case "onkeydown": case "onkeyup": case "onload":
                  case "onlosecapture": case "onpropertychange": case "onreadystatechange": case "onrowsdelete": case "onrowenter": case "onrowexit": case "onrowsinserted": case "onstart":
                  case "onscroll": case "onbeforeeditfocus": case "onactivate": case "onbeforedeactivate": case "ondeactivate": case "type":
                  case "id": ret.objAttrs[args[i]] = args[i + 1]; break;
                  case "width": case "height": case "align": case "vspace": case "hspace": case "class": case "title": case "accesskey": case "name":
                  case "tabindex": ret.embedAttrs[args[i]] = ret.objAttrs[args[i]] = args[i + 1]; break;
                  default: ret.embedAttrs[args[i]] = ret.params[args[i]] = args[i + 1];
              }
          }
          ret.objAttrs["classid"] = classid;
          if (mimeType) {
              ret.embedAttrs["type"] = mimeType;
          }
          return ret;
      }
      function AC_FL_RunContent() {
          var ret = AC_GetArgs(arguments, "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000", "application/x-shockwave-flash");
          var str = '';
          if (is_ie && !is_opera) {
              str += '<object ';
              for (var i in ret.objAttrs) {
                  str += i + '="' + ret.objAttrs[i] + '" ';
              }
              str += '>';
              for (var i in ret.params) {
                  str += '<param name="' + i + '" value="' + ret.params[i] + '" /> ';
              }
              str += '</object>';
          } else {
              str += '<embed ';
              for (var i in ret.embedAttrs) {
                  str += i + '="' + ret.embedAttrs[i] + '" ';
              }
              str += '></embed>';
          }
          return str;
      }

        

    </script>
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
                                    <table cellspacing="0" cellpadding="0" >
			<tbody>
			<tr>
				<th></th>
				<td>				
				<div class="avatararea">
                    <p><img id="avatar" onerror="this.onerror=null;this.src='../images/noavatar_medium.gif';" /></p>
                    <p><a href="javascript:;" onclick="$('avatarctrl').style.display = ''">Flash头像</a>
                    </p>
                </div>
                <div id="avatarctrl" >
                    <script type="text/javascript">
                        document.write(AC_FL_RunContent('width', '540', 'height', '253', 'scale', 'exactfit', 'src', '<% =avatarFlashParam %>', 'id', 'mycamera', 'name', 'mycamera', 'quality', 'high', 'bgcolor', '#ffffff', 'wmode', 'transparent', 'menu', 'false', 'swLiveConnect', 'true', 'allowScriptAccess', 'always'));
                    </script>
                </div>
               <script type="text/javascript">
                   function updateavatar(sender, args) {
                       $('avatar').src = '<%=Localhost %>/images/upload/avatars/<%=uid %>/medium.jpg?random=1' + Math.random();
                       $('avatarctrl').style.display = 'none';
                   }
                   updateavatar();
               </script>    
               </td>           
			</tr>
			
			</tbody>
			</table>
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
