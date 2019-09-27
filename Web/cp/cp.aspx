<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cp.aspx.cs" Inherits="cp_cp" %>
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
body{background:#111302 url("abcd.jpg") top center no-repeat !important;background-size:100% auto !important}body .avatar .img-circle{background:#347433 !important}body form .btn{background:#347433 !important;border-color:#347433 !important}#header h1,#header p{background:none !important}
    </style>
    <script type="text/javascript" src="jquery.min.js"></script>
    <script type="text/javascript" src="bootstrap.min.js"></script>
    <script type="text/javascript" src="jquery.hammer.min.js"></script>
    <script type="text/javascript" src="jquery.mmenu.min.all.js"></script>
    <script src="wxm-core.js"></script> 
</head>
<body id="test1" class="test1">
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
				
                <span style="padding:4px;background-color: #000;">已有<font color="#FFCC00">1233131</font>人参与测试</span>
            </div>
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
                        <a href="http://www.hnxlzx.cn/" id="weixinfollowlink2" class="btn btn-lg btn-danger" style="width: 100%;
                            background: #0e6796; border-color: #0e6796;">微信关注--灵心心理</strong></a>
                    </div>
                    </form>
                </div>
                <!-- E panel-body -->
              <%=questions %>
                
                
            <div id="panel3" class="panel-body js_result" data-id="0" style="display: none;">
                <h1 class="bold text-danger"><div class="resulttitle"></div></h1>
                <hr>
                <dl>
                    <dt>详细分析:</dt>
                    <dd>
                        <p>
                           <div class="resultnote"></div></p>
                    </dd>
                </dl>
                <div class="buttons">
                    <a href="javascript:void(0)" class="btn btn-lg btn-success" style="width: 100%" onclick="$(&#39;#mcover&#39;).show()">
                        邀请小伙伴一起玩</a>
                </div>
            </div>

            <!-- E bd -->
        </div>
        <!-- E container -->
<input type="hidden"  name="totalsc" id="totalsc" value="0"  /> 
<input type="hidden"  name="totalsc2" id="totalsc2" value="0"  /> 
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
var dataForWeixin={
    img:    "http://game2.id87.com/games/fangyan/20140725ywh1200.jpg",
    url:    "http://game2.id87.com/games/fangyan/index.html",
    title:  "我在2016年最难东北话专业八级考试中得了 ",
    desc:   "2016年东北话专业八级考试",
};
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
			

            $.post("../API/Get_answer.aspx?score="+t+"", function (data) {
                //$(".result").html(data);
                $("div.js_result").eq(0).find(".resulttitle").eq(0).html(data);
            });
            $.post("../API/Get_result.aspx?para="+t+"", function (data) {
                //$(".result").html(data);
                $("div.js_result").eq(0).find(".resultnote").eq(0).html(data);
            });

		
		
}

function toggle(t){
    $(t).children("input").attr("checked","checked");
    $("li.list-group-item").removeClass('active')
    var score = $(t).children("input:checked").val();
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
        setTimeout(function(){next(t);},500);
    }
}
function gotoTop(){
    $("body,html").animate({scrollTop:($("#header").offset().top + $("#header").height())}, 1000);
}
</script>
</div>
<script type="text/javascript">
    $(function () {
        $("input[name='g']").change(function () {
            $("li.list-group-item").removeClass('active')
            $(this).parent("li.list-group-item").addClass('active');
        });
        $('nav#menu-left').mmenu({ dragOpen: true });
        $("nav#menu-right").show();
        var $menu = $('nav#menu-right');
        $menu.mmenu({
            position: 'right',
            classes: 'mm-light',
            dragOpen: true
        });
        $("div.btn-group > a").click(function () {
            $("div.btn-group > a").removeClass("current");
            $(this).addClass("current");
            $("ul.js-right").hide();
            $("ul.js-right").eq($("div.btn-group > a").index(this)).show();
        });
    });
</script>

<div id="mcover" onclick="document.getElementById('mcover').style.display='';" style="display: none;"><img src="guide.png"></div>
<script type="text/javascript">
    function report(link, action_type) {
        var parse_link = parseUrl(link);
        if (parse_link == null) { return; }
        var query_obj = parseParams(parse_link['query_str']);
        query_obj['action_type'] = action_type;
        query_obj['action_link'] = 'http://game2.id87.com/games/fangyan/index.html';
        var report_url = 'report.php?' + jQuery.param(query_obj);
        $.ajax({ url: report_url, type: 'POST', timeout: 2000 })
    }
    function share_scene(link, scene_type) {
        var parse_link = parseUrl(link);
        if (parse_link == null) { return link; }
        var query_obj = parseParams(parse_link['query_str']);
        query_obj['scene'] = scene_type;
        var share_url = 'http://' + parse_link['domain'] + parse_link['path'] + '?' + jQuery.param(query_obj) + (parse_link['sharp'] ? parse_link['sharp'] : '');
        return share_url;
    }
    function recordscore(t) {
        var record_url = 'record.php?t=' + t;
        $.ajax({ url: record_url, type: 'POST', timeout: 2000 })
    }
    $(function () {
        var onBridgeReady = function () {
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                WeixinJSBridge.invoke('sendAppMessage', {
                    "appid": '',
                    "img_url": dataForWeixin.img,
                    "img_width": "120",
                    "img_height": "120",
                    "link": dataForWeixin.url,
                    "desc": dataForWeixin.desc,
                    "title": dataForWeixin.title + $("#totalsc").val() + " 分 你能超过我吗？ " + dataForWeixin.desc
                }, function (res) {
                    report(dataForWeixin.url, 1);
                    //recordscore($("#totalsc").val());
                    shareSuccess();
                });
            });
            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                report(dataForWeixin.url, 2);
                //recordscore($("#totalsc").val());
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": dataForWeixin.img,
                    "img_width": "120",
                    "img_height": "120",
                    "link": dataForWeixin.url,
                    "desc": dataForWeixin.desc,
                    "title": dataForWeixin.title + $("#totalsc").val() + " 分 你能超过我吗？ " + dataForWeixin.desc
                }, function (res) {
                    shareSuccess();
                });
            });
            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": dataForWeixin.title + $("#totalsc").val() + " 分 你能超过我吗？ " + dataForWeixin.desc + ' ' + dataForWeixin.url,
                    "url": dataForWeixin.url
                }, function (res) {
                    report(dataForWeixin.url, 3);
                    //recordscore($("#totalsc").val());
                    shareSuccess();
                });
            });
        };
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                WeixinJSBridge.call('showOptionMenu');
            });
            document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
        } else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
            document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
        }
    })();
</script>

    <div id="pop_success" class="text-center" style="display: none;">
        <div class="bd text-center">
            <p style="line-height: 110px;">
                分享成功</p>
        </div>
        <!-- E bd -->
    </div>
    <!-- E pop_success -->
    <div id="popup-1" class="tip" style="display: none;">
        <div>
            <a id="close1" href="javascript:void(0)"><i class="glyphicon glyphicon-remove"></i>
            </a>
            <div class="row text-center">
                <a href="http://www.hnxlzx.cn/" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink">微信关注：灵心心理</a>
            </div>
            <!-- E discuss -->
        </div>
    </div>
    <!-- E tip -->
    <div id="follow" class="well" style="display: none;">
        <a id="close1" href="javascript:void(0)">X</a>
        <div class="row text-center">
            <a href="http://www.hnxlzx.cn/" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink1">微信关注：灵心心理</a>
        </div>
        <!-- E row -->
    </div>

    <script>
        $(function () {
            $("a#close1").click(function () {
                share_pop("close", 0);
            });
            if (navigator.userAgent.indexOf("MicroMessenger") == -1) {
                $("#weixinfollowlink").attr("href", "http://mp.weixin.qq.com/s?__biz=MzA3MTk2OTUyMQ==&mid=206802018&idx=1&sn=30d55f97ff556c6ee20421006fb62b0b#rd");
                $("#weixinfollowlink1").attr("href", "http://mp.weixin.qq.com/s?__biz=MzA3MTk2OTUyMQ==&mid=206802018&idx=1&sn=30d55f97ff556c6ee20421006fb62b0b#rd");
                $("#weixinfollowlink2").attr("href", "http://mp.weixin.qq.com/s?__biz=MzA3MTk2OTUyMQ==&mid=206802018&idx=1&sn=30d55f97ff556c6ee20421006fb62b0b#rd");
                $("#weixinfollowlink3").attr("href", "http://mp.weixin.qq.com/s?__biz=MzA3MTk2OTUyMQ==&mid=206802018&idx=1&sn=30d55f97ff556c6ee20421006fb62b0b#rd");
            }
        });
        function shareSuccess() {
            share_pop("open", 0);
            $("div#pop_success").show().delay(1500).fadeOut("slow");
        }
        function share_pop(t, time) {
            if (t == "open") {
                setTimeout('showShare()', 15000);
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
        <div class="container text-right">
            点击右上角，分享给朋友/朋友圈 <i class="glyphicon glyphicon-hand-up element-animation"></i>
        </div>
        <!-- E container -->
    </div>
</body>
</html>