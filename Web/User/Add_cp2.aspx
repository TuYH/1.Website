<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_cp2.aspx.cs" Inherits="User_Add_cp2" %>
<%@ Register src="ascx/tongzhi.ascx" tagname="tongzhi" tagprefix="uc1" %>
<%@ Register src="ascx/left.ascx" tagname="left" tagprefix="uc2" %>
<%@ Register src="ascx/jj_list.ascx" tagname="jj_list" tagprefix="uc3" %>
<!doctype html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>测评系统</title>
    <meta name="description" content="这是一个 index 页面">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png">
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="assets/css/admin.css">

    <link rel="stylesheet" href="assets/css/app.css">
    <link rel="stylesheet" href="assets/css/amazeui.datetimepicker.css"/>

  

</head>

<body data-type="chart">
<form id="Form1" runat="server">

    <header class="am-topbar am-topbar-inverse admin-header">
        <div class="am-topbar-brand">
            <a href="javascript:;" class="tpl-logo">
                <img src="assets/img/logo.png" alt="">
            </a>
        </div>
        <div class="am-icon-list tpl-header-nav-hover-ico am-fl am-margin-right">

        </div>

        <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>

        <uc1:tongzhi ID="tongzhi1" runat="server" />
    
    </header>







    <div class="tpl-page-container tpl-page-header-fixed">

        <uc2:left ID="left1" runat="server" />
        





        <div class="tpl-content-wrapper">
            <div class="tpl-content-page-title">
                灵心
            </div>
            <ol class="am-breadcrumb">
                <li><a href="Tlist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">选择测评的部门科室</li>
            </ol>
            <div class="tpl-portlet-components">
              <div class="admin-content">
  <div class="admin-content-body">
    <div class="am-cf am-padding am-padding-bottom-0">
      <div class="am-fl am-cf">
        <strong class="am-text-primary am-text-lg">第二步 选择测评的部门科室</strong> 
        
      </div>
    </div>


    <div class="am-tabs am-margin" data-am-tabs>
      <ul class="am-tabs-nav am-nav am-nav-tabs">
        <li class="am-active"><a href="#tab1">基本信息</a></li>
     
      </ul>

      <div class="am-tabs-bd">
        <div class="am-tab-panel am-fade am-in am-active" >
         


            <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">部门</div>
            <div class="am-u-sm-8 am-u-md-10">
                <asp:DropDownList ID="Select1" runat="server" 
                    onselectedindexchanged="Select1_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            
            </div>
          </div>
          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">科室</div>
            <div class="am-u-sm-8 am-u-md-10">
                <asp:DropDownList ID="Select2" runat="server">
                </asp:DropDownList>
          
            </div>
          </div>
          



        </div>



      </div>
    </div>

    <div class="am-margin">
        <asp:Button ID="Button1" runat="server" Text="发布任务" class="am-btn am-btn-primary am-btn-xs" onclick="Button1_Click"/>
      
    </div>

    

  </div>

  <footer class="admin-content-footer">
    <hr>
    <p class="am-padding-left">© 2014 AllMobilize, Inc. Licensed under MIT license.
                  </p>
  </footer>
</div>

            </div>










        </div>

    </div>

</form>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/amazeui.datetimepicker.min.js"></script>
    <script src="assets/js/amazeui.min.js"></script>
    <script src="assets/js/app.js"></script>
    
</body>

</html>