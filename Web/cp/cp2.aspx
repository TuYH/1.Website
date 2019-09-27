﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cp2.aspx.cs" Inherits="cp_cp2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width initial-scale=1.0 maximum-scale=1.0 user-scalable=yes" />
		
    <title>★<%=cp_name%>★</title>
    <link href="bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="style.css" />
    <link href="jquery.mmenu.all.css" rel="stylesheet" />
	<style type="text/css">
        body{background:#BBE6F9 url("abcd.jpg") top center no-repeat !important;background-size:100% auto !important}
        body .avatar .img-circle{background:#32c5d2 !important}
        body form .btn{background:#32c5d2 !important;border-color:#32c5d2 !important}
        #header h1,#header p{background:none !important;color:#FC4A98;}    </style>
    <script type="text/javascript" src="jquery.min.js"></script>
    <script type="text/javascript" src="bootstrap.min.js"></script>
    <script type="text/javascript" src="jquery.hammer.min.js"></script>
    <script type="text/javascript" src="jquery.mmenu.min.all.js"></script>
    <script src="wxm-core.js"></script> 
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "https://hm.baidu.com/hm.js?52a3e3f4dc953b51c392a8a43ad8f391";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
</script>

</head>
<body id="test1" class="test1">
    <div>
    <input type="text" id ="ss1" value ="11"/><a onclick="return toggless(ss1);">kai</a>
    <input   name="totalscss" id="totalscss" value="0"  /> 
        </div>
    <div id="content">
        <div id="header_bar">
        </div>
        <!-- E header_bar -->
	
			
        <div class="container">
            <div id="header" class="text-center">
                <div style="height: 15px;"></div>
				
				 <div class="container">
        <div class="text-center header">
            <h1 class="bold">
                 ★<%=cp_name %>★</h1>
            <p>
				
<%--                <span style="padding:4px;background-color: #000;">已有<font color="#FFCC00"><script src="http://news.0579.cn/NewsStatic/Default.aspx?NID=2014072611" charset='utf-8' language="JavaScript" type="text/javascript"></script></font>人参与测试</span>
--%>            </div>
            <!-- E header -->
            <div id="bd" class="panel">
                <div id="panel1" class="panel-body">
                    <form action="#">
                    <div class="form-group avatar text-center">
                        <label for="" class="sr-only">前言</label>
                        <a href="javascript:void(0)" class="img-circle" name="1"><span style="float: left;text-align: center; width: 100%; padding-top: 18px;">
                            <img src="ks.jpg"></span> </a>
                    </div>
                    <dl>
                        <dd><%=cp_note%></dd>
                    </dl>
                    <div class="buttons">
                        <a href="#result" class="btn btn-lg btn-success" style="width: 100%" onclick="return next(0);">
                            <strong style="color:#fdfd88;">开始测试</strong></a>
                    </div>
                    <div class="buttons" style="margin-top: 10px;">
                        <a href="../user/twolist.aspx" id="weixinfollowlink2" class="btn btn-lg btn-danger" style="width: 100%;
                            background: #0e6796; border-color: #0e6796;">返回个人中心</strong></a>
                    </div>
                    </form>
                </div>
                <!-- E panel-body -->
              <%=questions %>
                
                
            <div id="panel3" class="panel-body js_result" data-id="0" style="display: none;">
                <h1 class="bold text-danger"><div class="resulttitle"></div></h1>
               
                <div id="pop_successaa" class="js_resulta" style="display: none;">
                <hr/><dl>
                    <dt>详细分析:</dt>
                    <dd> 
                    
                        <p>

                           <div class="resultnotea"></div></p>
                    </dd>
                </dl>
                </div>
                <div class="buttons">
                    <a href="../User/twolist.aspx" class="btn btn-lg btn-success" style="width: 100%" >返回首页 </a>
                </div>
            </div>

            <!-- E bd -->
        </div>
                             </div>
        <!-- E container -->
<input   name="totalsc" id="totalsc" value="0"  /> 
<input   name="totalsc2" id="totalsc2" value="0"  /> 
<script type="text/javascript">
var total = <%=cp_questioncun %>;
var scoreArr = new Array(parseInt(total));
    scoreArr[0] = new Array(2);
    scoreArr[0]['min'] = 1;
    scoreArr[0]['max'] = 73;
    scoreArr[1] = new Array(2);
    scoreArr[1]['min'] = 74;
    scoreArr[1]['max'] = 102;
    scoreArr[2] = new Array(2);
    scoreArr[2]['min'] = 103;
    scoreArr[2]['max'] = 174;
    scoreArr[3] = new Array(2);
    scoreArr[3]['min'] = 175;
    scoreArr[3]['max'] = 180;
    scoreArr[4] = new Array(2);
    scoreArr[4]['min'] = 181;
    scoreArr[4]['max'] = 195;
    scoreArr[5] = new Array(2);
    scoreArr[5]['min'] = 196;
    scoreArr[5]['max'] = 500;
var tScore = 0;
var scorelist=0;

function next(t){
    $("div#bd > div.panel-body").hide();
    $("div.js_answer").eq(t).show();
    $("div.js_answer").eq(t).children("input").attr("checked","");       
    gotoTop();
}
function result(t){
    share_pop("open",10000);
    $("div#bd > div.panel-body").hide();
  
            $("div.js_result").eq(0).show();
		
            $.post("../default.aspx?para="+t+"", function (data) {
                //$(".result").html(data);
                $("div.js_result").eq(0).find(".resultnote").eq(0).html(data);
            });

			
		
    
}
function result2(t){

    share_pop("open",10000);
    $("div#bd > div.panel-body").hide();
   
            $("div.js_result").eq(0).show();
            $("div.js_resulta").eq(0).show();
            $.post("../api/get_answer.aspx?score="+t+"&iid=<%=cp_id %>", function (data) {
                $(".result").html(data);
                $("div.js_result").eq(0).find(".resulttitle").eq(0).html(data);
            });
            $.post("../API/Get_result.aspx?para="+t+"&iid=<%=cp_id %>", function (data) {
                //$(".result").html(data);
               $("div.js_resulta").eq(0).find(".resultnotea").eq(0).html(data);
            });
            $.post("../API/Scorer.aspx?answers="+t+"&paperid=<%=cp_id %>&wid=<%=wid %>", function (data) {
                //$(".result").html(data);
                $("div.js_result").eq(0).find(".resulttitle").eq(0).html(data);
            });	
}

 function toggle(t) {
    var score;
     $(t).children("input").attr("checked", "checked");
    $("li.list-group-item").removeClass('active')
     score = $(t).children("input:checked").val();
     score = $(t).children("input:checked").val();
     if (score == null) {
         score = $(t).val();
         score = 0;
     }
    scorelist+="|"+score;
    tScore  = parseInt(tScore) + parseInt(score);
	$("#totalsc").val(tScore);
    
    $(t).addClass('active');
    var t = $("div.js_answer").index($(t).parents("div.js_answer")) + 1;
    if(t == total){
        $("#totalsc2").val(scorelist);
        result2(scorelist);
        //result2(scorelist);
    }else{
        setTimeout(function(){next(t);},100);
    }
}
function gotoTop(){
    $("body,html").animate({scrollTop:($("#header").offset().top + $("#header").height())}, 0);
}
</script>
</div>


<div id="mcover" onclick="document.getElementById('mcover').style.display='';" style="display: none;"><img src="guide.png"></div>

<!-- 微信分享-->
<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js" type="text/javascript"></script>
<!-- 微信分享-->
<script type="text/javascript">


    $(function () {

        var durl = location.href.split('#')[0]; //window.location;
        var code_durl = encodeURIComponent(durl);
        var sigture;
        $.ajax({
            type: "get",
            async: false,
            url: "http://dyh.geliefofm.com/wxapi.php?type=signature&durl=" + code_durl,
            dataType: "jsonp",
            jsonp: "callback",
            jsonpCallback: "jsonFlickrFeed",
            success: function (json) {
                sigture = json.signature;
                console.log(sigture);
                var wx_config = {
                    debug: false,
                    appId: "wx05ba189c076aec2f",
                    timestamp: "1414587457",
                    nonceStr: "Wm3WZYTPz0wzccnW",
                    signature: sigture,
                    jsApiList: [
				  'checkJsApi',
				  'onMenuShareTimeline',
				  'onMenuShareAppMessage',
				  'onMenuShareQQ',
				  'onMenuShareWeibo',
				  'hideMenuItems',
				  'showMenuItems',
				  'hideAllNonBaseMenuItem',
				  'showAllNonBaseMenuItem'
				]
                };
                wx.config(wx_config);
                wx.ready(function () {
                    //朋友圈
                    wx.onMenuShareTimeline({
                        title: "<%=cp_name %>", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "灵心心理",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //朋友
                    wx.onMenuShareAppMessage({
                        title: "<%=cp_name %>", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "灵心心理",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //qq
                    wx.onMenuShareQQ({
                        title: "<%=cp_name %>", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "灵心心理",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //weibo
                    wx.onMenuShareWeibo({
                        title: "<%=cp_name %>", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://www.lzpqc.com/File/00062/Logo/2013111309/20131113094729_8566.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "灵心心理",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                });

                wx.error(function (res) {
                    //alert(res.errMsg);
                });
            },
            error: function () {
                //console.log('fail');
            }
        });
    }); 
</script>

    <%--<div id="pop_success" class="text-center js_resulta" style="display: none;">
        <div class="bd text-center">
            <p style="line-height: 110px;">
                分享成功</p>
                 <dl>
                    <dt>详细分析:</dt>
                    <dd>
                        <p>
                           <div class="resultnotea"></div></p>
                    </dd>
                </dl>
        </div>
        <!-- E bd -->
    </div>--%>
    <!-- E pop_success -->
    <div id="popup-1" class="tip" style="display: none;">
        <div>
            <a id="close1" href="javascript:void(0)"><i class="glyphicon glyphicon-remove"></i>
            </a>
            <div class="row text-center">
                <a href="../User/twolist.aspx" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink">返回首页</a>
            </div>
            <!-- E discuss -->
        </div>
    </div>
    <!-- E tip -->
    <div id="follow" class="well" style="display: none;">
        <%--<a id="close1" href="javascript:void(0)">X</a>--%>
       <%-- <div class="row text-center">
            <a href="../User/twolist.aspx" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink1">返回首页</a>
        </div>--%>
        <!-- E row -->
    </div>

    <script>
        $(function () {
            $("a#close1").click(function () {
                share_pop("close", 0);
            });
            if (navigator.userAgent.indexOf("MicroMessenger") == -1) {
                $("#weixinfollowlink").attr("href", "../User/twolist.aspx");
                $("#weixinfollowlink1").attr("href", "../User/twolist.aspx");
                $("#weixinfollowlink2").attr("href", "../User/twolist.aspx");
                $("#weixinfollowlink3").attr("href", "../User/twolist.aspx");
            }
        });
        function shareSuccess() {

            $("div#pop_successaa").show().delay(180000).fadeOut("slow");
        }
        function share_pop(t, time) {
            if (t == "open") {
                setTimeout('showShare()', 500);
            } else {
                $('#follow').hide();
            }
        }
        function showShare() {
            $('#follow').show();
        }
    </script>
    <!-- E copy -->
   <div id="share_tips" class="sr-only">
      <%--   <div class="container text-right">
            点击右上角，分享给朋友/朋友圈 <i class="glyphicon glyphicon-hand-up element-animation"></i>
        </div>
        <!-- E container -->--%>
    </div>
</body>
</html>