<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" %>

<%@ Register src="ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc2" %>

<%@ Register src="ascx/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<title><%=list_title%>----心理测评管理系统</title>
<meta name="keywords" content="心理测评管理系统"/>
<meta name="description" content="心理测评管理系统"/>
<link rel="stylesheet" type="text/css" href="css/common.css"/>
<link rel="stylesheet" type="text/css" href="css/header.css"/>
<link rel="stylesheet" type="text/css" href="css/label.css"/>
<link rel="stylesheet" type="text/css" href="css/index.css"/>
<script type="text/javascript" src="js/config.js"></script>
<script type="text/javascript" src="js/util.js"></script>


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
<div class="bg">
    
    </div>
</div>
<div class="header">
<uc1:header ID="header1" runat="server" />
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
<div class="wrap"><!--content-->
<div class="position">
<a href="index.aspx">首页</a>
&gt;&gt; <a href="#">新闻公告</a>
&gt;&gt; <a href="#"><%=list_title%></a> 
</div>
<div class="clear"></div>
<div class="col_main">
<div class="col_left">
<div class="show_box_leftmenu  common_mbottom ">
<div class="sb1_head">
<div class="sb1_head_tit">新闻公告</div>
</div>
<uc2:left ID="left1" runat="server" />
<div class="sb1_bottom">&nbsp;</div>
</div>
<%--<div class="ad_box" style="margin-top: 5px;">
<a href="http://139.129.201.209/yanshi/zx2/index.php/cms/item-list-category-143.shtml" target="_blank" title="" style="text-decoration: none;"><img alt="" src="a7be9575c5176cf2.jpg" height="65" width="248" border="none"></a>
</div>
<div class="ad_box=" style="margin-top: 5px;">
<a href="http://139.129.201.209/yanshi/zx2/index.php/cms/item-list-category-3512.shtml" target="_blank" title="" style="text-decoration: none;"><img alt="" src="c329037ad7d0eda7.jpg" height="65" width="248" border="none"></a>
</div>--%>
</div>
<div class="col_right">		
<div class="show_box_2">
<div class="sb2_head">
<span class="title"><%=list_title%> </span>				
</div>
<div class="sb2_main">
<div style="padding: 20px;">
<ul class="label_ul_b">
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <li style=";">
            <span class="label_datatime">[<%#Eval("PostTime", "{0:yyyy-MM-dd}")%>]</span>·<a href="news.aspx?id=<%#Eval("id")%>" target="_blank" title="<%#Eval("Title")%>"><%#Eval("Title")%></a></li>
        <asp:Literal Runat="server" Text="<li class='label_dashed'></li>" Visible='<%# ((int)Container.ItemIndex +1) % 5 == 0 %>' ID="Literal1"/>
    </ItemTemplate>
    </asp:Repeater>
    

<li class="label_dashed"></li>
<li class="clear"></li>
</ul>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>

</div>
</div>
</div>
</div>
</div></div>
<div id="footer2">
<uc3:footer ID="footer3" runat="server" />
</div>
    
    
    
    </form>
</body>
</html>