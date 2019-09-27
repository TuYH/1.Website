<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="edumaste_Charts" %>
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

  <script language="javascript" type="text/javascript">
      function check() {
          var flg = "false";
          var check_box = document.getElementsByName("Id");
          num = check_box.length;
          if (num > 1) {
              for (i = 0; i < num; i++) {
                  if (check_box[i].checked == false) {
                      flg = "false";
                  }
                  else {
                      flg = "true";
                  }
              }
              for (i = 0; i < num; i++) {
                  if (flg == "true") {
                      check_box[i].checked = false;
                  }
                  else {
                      check_box[i].checked = true;
                  }
              }
          }
          else {
              if (document.myform.Id.checked == false) {
                  document.myform.Id.checked = true;
              }
              else {
                  document.myform.Id.checked = false;
              }
          }
      }
  </script>

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
                测评结果统计
            </div>
            <ol class="am-breadcrumb">
                <li><a href="olist.aspx" class="am-icon-home">首页</a></li>
                <li class="am-active">统计</li>
            </ol>
            <div class="tpl-portlet-components">
              <div class="admin-content">
  <div class="admin-content-body">
   



    <div class="am-tabs am-margin" data-am-tabs>
      <ul class="am-tabs-nav am-nav am-nav-tabs">
        <li class="am-active"><a href="#tab1">基本信息</a></li>
     
      </ul>

      <div class="am-tabs-bd">
        <div class="am-tab-panel am-fade am-in am-active" >
         
          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">民族</div>
            <div class="am-u-sm-8 am-u-md-10">

              <select data-am-selected="{btnSize: 'sm'}" runat="server" id="se_mz">
                <option value="0">所有民族</option>
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
          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">
              就诊时间
            </div>
            <div class="am-u-sm-8 am-u-md-10">
             <div action="" class="am-form am-form-inline">
                <div class="am-input-group am-datepicker-date" data-am-datepicker="{format: 'yyyy-mm-dd'}">
                  <input type="text" runat="server" id="ks_time" class="am-form-field" placeholder="日历组件" readonly>
                  <span class="am-input-group-btn am-datepicker-add-on">
                    <button class="am-btn am-btn-default" type="button"><span class="am-icon-calendar"></span> </button>
                  </span>
                </div>
              </div>
            </div>
          </div>
          
                     

          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">一级单位</div>
            <div class="am-u-sm-8 am-u-md-10">
              
                <asp:DropDownList ID="s123" runat="server" data-am-selected="{btnSize: 'sm'}" 
                    AutoPostBack="True" onselectedindexchanged="s123_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
          </div>
          <div class="am-ga am-margin-top" >
            <div class="am-u-sm-4 am-u-md-2 am-text-right">二级单位</div>
            <div class="am-u-sm-8 am-u-md-10">
              <asp:DropDownList ID="Select2" runat="server" data-am-selected="{btnSize: 'sm'}">
                </asp:DropDownList>
            </div>
          </div>


          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">姓名</div>
            <div class="am-u-sm-8 am-u-md-10">
              <div class="am-btn-group" data-am-button>
                <label class="am-btn-xsss">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </label>
               
               
              </div>
            </div>
          </div>
          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">性别</div>
            <div class="am-u-sm-8 am-u-md-10">
              <div class="am-btn-group" data-am-button>
                <label class="am-btn am-btn-default am-btn-xs">
                  <input type="radio"  runat="server"  name="options" id="option1" > 男
                </label>
                <label class="am-btn am-btn-default am-btn-xs">
                  <input type="radio"  runat="server" name="options" id="option2"> 女
                </label>
               
              </div>
            </div>
          </div>
          <div class="am-ga am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">量表</div>
            <div class="am-u-sm-8 am-u-md-10">
              <select data-am-selected="{searchBox: 1}"  id="Select3" runat="server" >
              
              </select>
            </div>
          </div>
       <%--   <div class="am-ga am-margin-top" >
            <div class="am-u-sm-4 am-u-md-2 am-text-right">因子</div>
            <div class="am-u-sm-8 am-u-md-10">
              <select data-am-selected="{searchBox: 1}" >
                <option value="option1">选项一...</option>
                <option value="option2">选项二.....</option>
                <option value="option3">选项三........</option>
              </select>
            </div>
          </div>--%>

          

          
           <div class="am-ga am-margin-top" style="display:none">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">
              结束时间
            </div>
            <div class="am-u-sm-8 am-u-md-10">
             <div action="" class="am-form am-form-inline">
                <div class="am-input-group am-datepicker-date" data-am-datepicker="{format: 'yyyy-mm-dd'}">
                  <input type="text" runat="server" id="js_time" class="am-form-field" placeholder="日历组件" readonly>
                    <span class="am-input-group-btn am-datepicker-add-on">
                    <button class="am-btn am-btn-default" type="button"><span class="am-icon-calendar"></span> </button>
                  </span>
                </div>
              </div>
            </div>
          </div>
   

        </div>



      </div>
    </div>

    <div class="am-margin">
        <asp:Button ID="Button1" runat="server" Text="查询" 
            class="am-btn am-btn-primary am-btn-xs" onclick="Button1_Click"/>
      
      <asp:Button ID="Button2" runat="server" Text="导出所有数据" 
            class="am-btn am-btn-primary am-btn-xs" onclick="Button2_Click"/>

              <asp:Button ID="Button3" runat="server" Text="导出量表数据" 
            class="am-btn am-btn-primary am-btn-xs" onclick="Button3_Click"/>
    </div>

    <div class="am-g">
                        <div class="am-u-sm-12">
                                <table class="am-table am-table-striped am-table-hover table-main">
                                    <thead>
                                        <tr>
                                            <th class="table-check"><input type="checkbox" onclick="check();"  class="tpl-table-fz-check"></th>
                                           
                                            <th class="table-typee">用户名</th>
                                            <th class="table-title">量表名称</th>
                                            <th class="table-type">测试得分</th>
                                            <th class="table-date am-hide-sm-only">测试日期</th>
                                            <th class="table-set">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                       
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                 <tr>
                                                    <td><input type="checkbox" name="Id" value="<%#Eval("id")%>"></td>
                                                    
                                                    <td><a href="#"><%#getname(Eval("Fresultid").ToString())%></a></td>
                                                    <td><a href="#"><%#getlbname(Eval("Fpaperid").ToString())%></a></td>
                                                    <td class="am-hide-sm-only"><%#Eval("Fscore").ToString().Replace(".00","")%></td>
                                                    <td class="am-hide-sm-only"><%#Eval("postTime", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                                    <td>
                                                        <div class="am-btn-toolbar">
                                                            <div class="am-btn-group am-btn-group-xs">
                                                                <a class="am-btn am-btn-default am-btn-xs am-text-secondary am-text-sdary" href="chart_scl.aspx?rid=<%#Eval("id")%>&Action=lock"><span class="am-icon-pencil-square-o"></span> 查看</a>
                                                                <a onClick="return confirm('确认删除')" class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary" href="charts.aspx?id=<%#Eval("id")%>&Action=del"><span class="am-icon-trash-o"></span> 删除</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </tbody>
                                </table>
                                <div class="am-cf">

                                    <div class="am-fr">
                                        <ul class="am-pagination tpl-pagination">
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </ul>
                                    </div>
                                </div>
                                <hr>

                        </div>

                    </div>

  </div>

  <footer class="admin-content-footer">
    <hr>
    <p class="am-padding-left">© 2017 AllMobilize, Inc. Licensed under MIT license.
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
