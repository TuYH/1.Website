<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gaokao.aspx.cs" Inherits="cp_gaokao" %>
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
    <div id="content">
        <div id="header_bar">
        </div>
        <!-- E header_bar -->
	
			
        <div class="container">
            <div id="header" class="text-center">
               <div z><img src="../Images/logo3.png"/></div>
				
				 <div class="container">
        <div class="text-center header">
       
            <h1 class="bold">
                 ★<%=cp_name %>★</h1>
            <p>
				
                <span style="padding:4px;background-color: #000;">已有<font color="#FFCC00"><script src="http://news.0579.cn/NewsStatic/Default.aspx?NID=2014072611" charset='utf-8' language="JavaScript" type="text/javascript"></script></font>人参与测试</span>
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
                        <a href="https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd" id="weixinfollowlink2" class="btn btn-lg btn-danger" style="width: 100%;
                            background: #0e6796; border-color: #0e6796;">微信关注--灵心心理</strong></a>
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
                    <a href="javascript:void(0)" class="btn btn-lg btn-success" style="width: 100%" onclick="$(&#39;#mcover&#39;).show()">
                        分享到朋友圈，查看详细结果</a>
                </div>
            </div>

            <!-- E bd -->
        </div>
        <!-- E container -->
<input   name="totalsc" id="totalsc" value="0" type="hidden" /> 
<input   name="totalsc2" id="totalsc2" value="0"  type="hidden" /> 
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
			

            $.post("../API/Get_answer.aspx?score="+t+"&iid=5", function (data) {
                //$(".result").html(data);
                $("div.js_result").eq(0).find(".resulttitle").eq(0).html(data);
            });
            $.post("../API/Get_result.aspx?para="+t+"&iid=5", function (data) {
                //$(".result").html(data);
                $("div.js_resulta").eq(0).find(".resultnotea").eq(0).html(data);
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
        setTimeout(function(){next(t);},100);
    }
}0
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
                        title: "★<%=cp_name %>★", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "考试是一种竞争性的活动，考前的身心健康状况会直接影响到考试的效果。因此不能不引起我们的高度重视-灵心心理。",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //朋友
                    wx.onMenuShareAppMessage({
                        title: "★<%=cp_name %>★", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "考试是一种竞争性的活动，考前的身心健康状况会直接影响到考试的效果。因此不能不引起我们的高度重视-灵心心理。",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //qq
                    wx.onMenuShareQQ({
                        title: "★<%=cp_name %>★", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "考试是一种竞争性的活动，考前的身心健康状况会直接影响到考试的效果。因此不能不引起我们的高度重视-灵心心理。",
                        success: function () { shareSuccess() },
                        cancel: function () { shareSuccess() }
                    });
                    //weibo
                    wx.onMenuShareWeibo({
                        title: "★<%=cp_name %>★ ", // 分享标题
                        link: durl, // 分享链接
                        imgUrl: "http://beta.geliefofm.com/images/logo1.png", // 分享图标
                        type: "",
                        dataUrl: "",
                        desc: "考试是一种竞争性的活动，考前的身心健康状况会直接影响到考试的效果。因此不能不引起我们的高度重视-灵心心理。",
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
                <a href="https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink">微信关注：灵心心理</a>
            </div>
            <!-- E discuss -->
        </div>
    </div>
    <!-- E tip -->
    <div id="follow" class="well" style="display: none;">
        <a id="close1" href="javascript:void(0)">X</a>
        <div class="row text-center">
            <a href="https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd" class="btn btn-danger col-sm-12 btn-lg" id="weixinfollowlink1">微信关注：灵心心理</a>
        </div>
        <!-- E row -->
    </div>

    <script>
        $(function () {
            $("a#close1").click(function () {
                share_pop("close", 0);
            });
            if (navigator.userAgent.indexOf("MicroMessenger") == -1) {
                $("#weixinfollowlink").attr("href", "https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd");
                $("#weixinfollowlink1").attr("href", "https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd");
                $("#weixinfollowlink2").attr("href", "https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd");
                $("#weixinfollowlink3").attr("href", "https://mp.weixin.qq.com/s?__biz=MzU4OTA0NTg3OA==&mid=2247483736&idx=1&sn=727a14d5a9d03a379b8a141b459ed951&chksm=fdd2c841caa54157bb3809676b1c7ede496596ffc38eec2e047209c7b25db24fd97103f5ef9c#rd");
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
        <div class="container text-right">
            点击右上角，分享给朋友/朋友圈 <i class="glyphicon glyphicon-hand-up element-animation"></i>
        </div>
        <!-- E container -->
    </div>
</body>
</html>