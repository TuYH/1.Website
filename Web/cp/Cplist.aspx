<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cplist.aspx.cs" Inherits="cp_Cplist" %>

<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width initial-scale=1.0 maximum-scale=1.0 user-scalable=yes" />
		
    <title>★心理测试★</title>
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
                 ★心理测试★</h1>
            <p>
				
                <span style="padding:4px;background-color: #000;">已有<font color="#FFCC00">1233131</font>人参与测试</span>
            </div>
            <!-- E header -->
            <div id="bd" class="panel">
                <div id="panel1" class="panel-body">
                    <form action="#">
                    <div class="form-group avatar text-center">
                        <label for="" class="sr-only">前言</label>
                        <a href="javascript:void(0)" class="img-circle" name="1"><span style="float: left;text-align: center; width: 100%; ">
                            <img src="ks.jpg"></span> </a>
                    </div>
                    <dl>
                        <dd>心理测试</dd>
                    </dl>
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                      <div class="buttons" style="margin-top: 10px;">
                        <a href="cp2.aspx?id=<%#Eval("Fpaperid")%>&wid=<%=wid %>" class="btn btn-lg btn-success" style="width: 100%" onclick="return next(0);"><strong style="color:#fdfd88;"><%#Eval("Fpapername")%></strong></a></div>
                    </ItemTemplate>
                    </asp:Repeater>
                  

                    <div class="buttons" style="margin-top: 10px;">
                        <a href="../User/twolist.aspx" id="weixinfollowlink2" class="btn btn-lg btn-danger" style="width: 100%;
                            background: #0e6796; border-color: #0e6796;">返回首页</a>
                    </div>
                    </form>
                </div>
            
                
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


    <!-- E copy -->
    <div id="share_tips" class="sr-only">
        <div class="container text-right">
            点击右上角，分享给朋友/朋友圈 <i class="glyphicon glyphicon-hand-up element-animation"></i>
        </div>
        <!-- E container -->
    </div>
</body>
</html>
