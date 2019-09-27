<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc2" %>
<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>测评系统</title>
    <meta name="keywords" content="测评系统">
    <meta name="description" content="测评系统">
    <link rel="stylesheet" type="text/css" href="css/common.css">
    <link rel="stylesheet" type="text/css" href="css/header.css">
    <link rel="stylesheet" type="text/css" href="css/label.css">
    <link rel="stylesheet" type="text/css" href="css/index.css">
    <script type="text/javascript" src="js/config.js"></script>
    <script type="text/javascript" src="js/util.js"></script>
    <link rel="stylesheet" href="css/lrtk.css" />
    <script type="text/javascript" src="js/jquery.min2.js"></script>
    <script type="text/javascript" src="js/jquery.imgbox.pack.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#example2-1, #example2-2, #example2-3, #example2-4").imgbox({
                'speedIn': 0,
                'speedOut': 0,
                'alignment': 'center',
                'overlayShow': true,
                'allowMultiple': false
            });
        });
    </script>



    <script type="text/javascript">
        function nTabs(thisObj, Num) {
            if (thisObj.className == "active") return;
            var tabObj = thisObj.parentNode.id;
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (i == Num) {
                    thisObj.className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    tabList[i].className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="topbg">
            <div class="bg"></div>
        </div>
        <div class="header">
            <uc2:header ID="header1" runat="server" />

        </div>
        <script type="text/javascript">
            var USERNAME = get_username();
            $(document).ready(function () {
                //**show_edit**//					   
                init_labelshows('header_t');
                //**menu**//
                $('#menu_nav li>dl').hide();
                $("#menu_nav li:first").addClass('over');
                $("#menu_nav li").each(function () {
                    $(this).hover(
                        function () {
                            $('#menu_nav li').removeClass();
                            $('#menu_nav li>dl').hide();
                            $(this).addClass('over');
                            $(this).find('dl').show();
                            $(this).find('dl').css({ left: parseInt($(this).position().left) + 'px' });
                        },
                        function () {
                            $(this).find('dl').hide();
                        }
                    )
                });
            })
        </script>
        <div class="wrap">
            <div class="col">
                <div class="w790">
                    <div class="xxdt">
                        <div class="hd">
                            <h3 class="title"><b>校</b>园动态</h3>

                        </div>
                        <div class="bd">
                            <div class="focusPic">
                                <style type="text/css">
                                    /* Code tidied up by ScrapBook */
                                    #play_14593 {
                                        margin: 0px;
                                        float: left;
                                        width: 316px;
                                        height: 272px;
                                        overflow: hidden;
                                    }

                                        #play_14593 .playShow {
                                            height: 272px;
                                        }

                                        #play_14593 .playBg {
                                            margin: -30px 0px 0px;
                                            float: left;
                                            z-index: 1;
                                            opacity: 0.7;
                                            width: 316px;
                                            position: absolute;
                                            height: 30px;
                                            background: rgb(0, 0, 0) none repeat scroll 0% 0%;
                                        }

                                        #play_14593 .playText {
                                            margin: -30px 0px 0px;
                                            float: left;
                                            text-indent: 10px;
                                            width: 316px;
                                            z-index: 2;
                                            font-size: 14px;
                                            font-weight: bold;
                                            color: rgb(255, 255, 255);
                                            line-height: 30px;
                                            overflow: hidden;
                                            position: absolute;
                                            cursor: pointer;
                                        }

                                        #play_14593 .playNum {
                                            width: 316px;
                                            overflow: hidden;
                                            margin: -30px 0px 0px;
                                            z-index: 3;
                                            text-align: right;
                                            position: absolute;
                                            height: 25px;
                                        }

                                            #play_14593 .playNum a {
                                                margin: 5px 2px;
                                                width: 15px;
                                                height: 15px;
                                                font-size: 14px;
                                                display: inline-block;
                                                font-weight: bold;
                                                line-height: 15px;
                                                cursor: pointer;
                                                color: rgb(0, 0, 0);
                                                background: rgb(215, 214, 215) none repeat scroll 0% 0%;
                                                text-align: center;
                                            }

                                        #play_14593 .playShow img {
                                            width: 316px;
                                            height: 272px;
                                        }
                                </style>
                                <div id="play_14593">
                                    <ul>
                                        <li class="playShow">
                                            <%--<a href="/item-view-id-1135.shtml" target="_blank" style="display: none;"><img src="images/t1/ed06de3b55b12af0.jpg" alt="人民日报评论员：以“三种意识”"></a> 
<a href="/item-view-id-1141.shtml" target="_blank" style="display: inline;"><img src="images/t1/6bda83cf89e6cf65.jpg" alt="市属高校三年规划建设项目开展专"></a> 
<a href="/item-view-id-1053.shtml" target="_blank" style="display: none;"><img src="images/t1/e6a9fd61a4dddd43.jpg.cthumb.jpg" alt="学院简介"></a> 
<a href="/item-view-id-1140.shtml" target="_blank" style="display: none;"><img src="images/t1/2491223fbece3b6d.jpg" alt="专家上海研讨大城市规划 绿色可持"></a> 
                                            --%><%=str_tj %>
                                        </li>
                                        <li class="playBg"></li>
                                        <li class="playText"></li>
                                        <li class="playNum"></li>
                                    </ul>
                                </div>
                                <script type="text/javascript">
                                        (function () {
                                            var playdiv = $('#play_14593');
                                            var t = i = 0, c = clas("playShow").find('a').size();
                                            for (ii = 1; ii <= c; ii++) {
                                                clas("playNum").append('<a>' + ii + '</a>');
                                            }
                                            showImg();
                                            clas('playNum').find('a').click(function () {
                                                i = clas('playNum').find('a').index(this);
                                                showImg();
                                            });
                                            t = setInterval(showImg, 5000);
                                            playdiv.hover(function () { clearInterval(t); }, function () { t = setInterval(showImg, 5000); });
                                            function clas(className) {
                                                return playdiv.find('.' + className);
                                            }
                                            function showImg() {
                                                clas('playNum').find('a').eq(i).siblings().css({ "background": "#D7D6D7", 'color': '#000' }).end().css({ "background": "#FFD116", 'color': '#A8471C' });
                                                clas("playText").html(clas("playShow").find('a').eq(i).find('img').attr('alt'));
                                                clas("playShow").find('a').eq(i).siblings().hide().end().fadeIn(1200);

                                                i++;
                                                if (i == c) { i = 0; }
                                            }

                                        })();
                                </script>
                            </div>
                            <div class="focusNew">
                                <%=str_xydt %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="w294">
                <div class="tzgg">
                    <div class="hd">
                        <h3 class="title"><b>通</b>知公告</h3>

                    </div>
                    <div class="bd">
                        <style type="text/css">
                            /* Code tidied up by ScrapBook */
                            .label_list3_date li {
                                padding-bottom: 10px;
                                margin-top: 10px;
                                border-bottom: 1px dashed rgb(170, 170, 170);
                                height: 54px;
                                font-size: 12px;
                            }

                            .label_list3_date .date3 {
                                width: 60px;
                                height: 54px;
                                text-align: center;
                                float: left;
                                color: rgb(255, 255, 255);
                            }

                                .label_list3_date .date3 .ny {
                                    display: block;
                                    height: 25px;
                                    line-height: 25px;
                                    background: rgb(107, 41, 43) none repeat scroll 0% 0%;
                                    text-align: center;
                                    color: rgb(255, 255, 255);
                                    font-size: 12px;
                                }

                                .label_list3_date .date3 .rq {
                                    display: block;
                                    height: 29px;
                                    line-height: 29px;
                                    background: rgb(255, 255, 255) none repeat scroll 0% 0%;
                                    text-align: center;
                                    color: rgb(107, 41, 43);
                                    font-size: 16px;
                                }

                            .label_list3_date .text3 {
                                width: 207px;
                                float: right;
                            }

                            .label_list3_date h4 {
                                font-size: 14px;
                                line-height: 25px;
                                overflow: hidden;
                                font-weight: normal;
                            }

                                .label_list3_date h4 a {
                                    color: rgb(64, 64, 64);
                                }
                        </style>
                        <%=str_tz %>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear"></div>
        <div class="col2 picAdv">
            <a href="#" target="_blank" title="" style="text-decoration: none;">
                <img alt="" src="images/t1/3bd30a9b4586a3fd.jpg" height="104" width="1100" border="none"></a>
        </div>
        <div class="col2">
            <div class="w790">
                <div class="kyjx box fl">
                    <%=str_new1 %>
                </div>
                <div class="ydzf box fr">
                    <%=str_new2 %>
                </div>
            </div>
            <div class="w294">
                <div class="kjdh">
                    <div class="hd">
                        <h3 class="title"><b>快</b>捷导航</h3>

                    </div>
                    <div class="bd">
                        <ul>
                            <li class="li04"><a target="_blank" href="logine.aspx"><span></span>
                                <p>登录</p>
                            </a></li>
                            <li class="li03"><a id="example2-2" title="扫描二维码登录" href="Images/t1/login.png"><span></span>
                                <p>扫码登录</p>
                            </a></li>
                            <li class="li02"><a target="_blank" href="reg_xs.aspx?MenuId=<%=str_num %>"><span></span>
                                <p>来访者注册</p>
                            </a></li>
                            <li class="li03"><a id="example2-1" title="来访者注册二维码" href="Images/t1/xsre.png"><span></span>
                                <p>来访者扫码注册</p>
                            </a></li>
                            <li class="li02"><a target="_blank" href="reg_ls.aspx?MenuId=<%=str_num %>"><span></span>
                                <p>咨询师注册</p>
                            </a></li>
                            <li class="li03"><a id="example2-3" title="咨询师注册二维码" href="Images/t1/lsre.png"><span></span>
                                <p>咨询师扫码注册</p>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <%--<div class="qtdh">
<ul>
<li class="dh1 fl"><a href="#">校长信箱</a></li>
<li class="dh2 fr"><a href="#">咨询留言</a></li>
</ul>
</div>--%>
            </div>
        </div>
        <div class="clear"></div>
        <div class="col2">
            <div class="w790">
                <div class="kyjx box fl">
                    <%=str_new3 %>
                </div>
                <div class="ydzf box fr">
                    <%=str_new4 %>
                </div>
            </div>

            <div class="w294">
                <div class="xysp">
                    <div class="hd">
                        <h3 class="title"><b>系统</b>说明</h3>

                    </div>
                    <div class="bd">
                        <p class="normal_title">
                            欢迎大家参加本次心理测评，在答题之前，请注意以下事项：<br />
                            1、注册时请填写真实的个人信息；<br />
                            2、注册后登陆进去请在“完善个人信息”里修核实个人信息是否正确，不正确请进行修改；<br />
                            3、心理测评：请点击“心理测评”，然后点击量表下的开始测试即可；<br />
                            4、修改密码：登录进去后，在页面地部进行个人密码修改，并且牢记，如若遗忘，请向咨询师申请重置密码;
                        </p>
                    </div>
                </div>

            </div>
        </div>
        <div class="clear"></div>
        <div id="footer">
            <div class="picTab">
                <div class="TabTitle">
                    <ul id="myTab0">
                        <li class="active" onmouseover="nTabs(this,0);"><a href="#">精彩阅读</a></li>

                    </ul>
                </div>
                <div class="TabContent">
                    <div id="myTab0_Content0">
                        <div class="Cont">
                            <div class="tempWrap">
                                <div class="layer" style="height: 206px; width: 954px; overflow: hidden;" id="pingpaibox_14625">
                                    <div id="scroll_14625" style="width: 800%;">
                                        <ul class="label_pic_ul" id="pingpai_14625" style="float: left; height: 206px;">

                                            <%=str_dimg %>
                                        </ul>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <uc1:footer ID="footer1" runat="server" />
        </div>
    </form>


</body>
</html>
