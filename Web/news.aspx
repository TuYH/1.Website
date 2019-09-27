<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
<%@ Register src="ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc2" %>

<%@ Register src="ascx/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title><%=new_title%>----心理测评管理系统</title>
<meta name="keywords" content="国微CMS,政府方案,站群方案,学校方案">
<meta name="description" content="国微企业级CMS为中国领先的开源CMS平台，专注提供媒学校、企业、局级政府、站群系统等中高端平台">
<link rel="stylesheet" type="text/css" href="css/common.css">
<link rel="stylesheet" type="text/css" href="css/header.css">
<link rel="stylesheet" type="text/css" href="css/label.css">
<link rel="stylesheet" type="text/css" href="css/index.css">
<script type="text/javascript" src="js/config.js"></script>
<script type="text/javascript" src="js/util.js"></script>

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

<div class="wrap"><!--content-->
<link rel="stylesheet" type="text/css" href="style.css">

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

</div>
<div class="col_right">		
<div class="show_box_2">
<!--layout article content-->
<div class="sb2_head">
<div class="layout_txtcontent_position" style="height: 23px; background-position: 0px -203px; color: rgb(16, 80, 157); padding-left: 38px; font-size: 13px;"> 新闻聚焦 &gt;&gt; 正文 </div>
</div>
<div class="sb2_main layout_txtcontent common_mbottom">

<div class="layout_txtcontent_title">
<%=new_title%>
</div>
<div class="layout_txtcontent_info">
日期：<%=new_time %>
<span id="operation" style="display: none; cursor: pointer; color: rgb(0, 64, 255); margin-left: 15px;">操作&gt;&gt;</span>
</div>

<div class="layout_txtcontent_content">
<%=new_countent %>
<div class="layout_txtcontent_list">

</div>
<div class="common_digg">

			
<div class="clear"></div>
</div>

<div class="closepage"><span><a href="index.aspx">返回首页</a></span><span><a href="javascript:self.close()">关闭页面</a></span></div>

</div>
<!--layout comment-->
</div>
</div>
</div></div>
<div id="footer2">
  <uc3:footer ID="footer3" runat="server" />
</div>
    </div>
  
    </form>
</body>
</html>
