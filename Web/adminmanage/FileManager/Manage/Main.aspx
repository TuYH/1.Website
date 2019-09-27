<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="adminmanage_FileManager_Manage_Main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="author" content="TakWai" />
    <title>文件管理</title>
    <link rel="stylesheet" type="text/css" href="../Style/Manage/Style.css" />
    <link rel="stylesheet" type="text/css" href="../Style/Manage/Layout.css" />
    <script type="text/javascript" src="../Client/jquery-1.1.3.1.pack.js"></script>
    <script type="text/javascript" src="../Client/Manage.js"></script>
    <link rel="stylesheet" type="text/css" href="../Client/subModal/subModal.css" />
    <script type="text/javascript" src="../Client/subModal/common.js"></script>
    <script type="text/javascript" src="../Client/subModal/submodal.js"></script>    
</head>
<body>
<div id="container">
<div id="header">
<h3>文件管理</h3>
<span id="rightnav"><a href="Main.aspx?act=logout"><img src="../Images/IcoExit.gif" alt="注销" align="absmiddle" /> 注销</a></span>
</div>

<div id="middle">
<div id="leftFrame">            
    <div class="box" style="margin-bottom: 15px; display: none;" id="tips">
        <span class="msg" id="tipsMsg"></span>
    </div>
    <%= builder %>
    <div class="box">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 60%;">
                <form id="insertForm" method="post" action="Main.aspx?act=create&amp;path=<%= Server.UrlEncode(folderPath) %>">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="trtitle" style="width: 60px;">目录名称</td>
                        <td style="width: 210px;"><input type="text" name="txtFolderName" id="txtFolderName" size="35" onfocus="this.className='colorfocus'" onblur="this.className='txt';" class="txt" /></td>
                        <td><input type="hidden" name="txtOldName" id="txtOldName" /><input type="submit" name="submit" id="submit" value="新建" class="btn" />&nbsp;&nbsp;<input type="button" name="cancel" id="cancel" value="取消" class="btn" onclick="javascript:toCreate('<%= Server.UrlEncode(folderPath) %>');" />&nbsp;&nbsp;<input type="button" name="btncreate" value="新建文本文档" class="btn" onclick="showPopWin('Notepad.aspx?objfolder=<%= Server.UrlEncode(folderPath) %>', 700, 400, null);" /></td>
                    </tr>
                </table>
                </form> 
            </td>
            <td>
                <form id="uploadForm" method="post" action="Main.aspx?act=upload&amp;path=<%= Server.UrlEncode(folderPath) %>" enctype="multipart/form-data">
                <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="trtitle" style="width: 60px;">上传文件</td>
                            <td style="width: 230px;"><input type="file" name="fileUpload" id="fileUpload" size="23" class="txt" /></td>
                            <td style="width: 36px"><input type="submit" name="upload" value="添加" class="btn" onclick="javascript:uploadMsg();" /></td>
                        </tr>
                </table>        
                </form>             
            </td>
        </tr>
        </table> 
    </div>
    
    <div class="box" style="margin-top: 15px;">
        <div class="searchBox">
            当前路径: <%= currPath %>&nbsp;&nbsp;&nbsp;&nbsp;目录数: <%= folderNum %>&nbsp;&nbsp;&nbsp;&nbsp;文件数: <%= fileNum %>
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table border="0" cellpadding="5" cellspacing="0" class="m-table">
                <tr class="m-head">
                    <td><a href="Main.aspx?path=<%= Server.UrlEncode(folderPath) %>&amp;order=name">名称</a></td>
                    <td style="width: 70px;"><a href="Main.aspx?path=<%= Server.UrlEncode(folderPath) %>&amp;order=ext">扩展名</a></td>
                    <td style="width: 70px;"><a href="Main.aspx?path=<%= Server.UrlEncode(folderPath) %>&amp;order=size">大小</a></td>
                    <td style="width: 150px;"><a href="Main.aspx?path=<%= Server.UrlEncode(folderPath) %>&amp;order=modifydate">修改时间</a></td>
                    <td style="width: 120px;">操作选项</td>
                </tr>
                <%= backHtml %>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="m-row1" onmouseover="c=this.style.backgroundColor;this.style.backgroundColor='#E4F1F8';" onmouseout="this.style.backgroundColor=c;">
                    <td><%# Eval("FormatName") %></td>
                    <td><%# Eval("Ext") %></td>
                    <td><%# Eval("FormatSize") %></td>
                    <td><%# Eval("FormatModifyDate") %></td>
                    <td>
                        <a href="#" onclick="javascript:toRename('<%# Eval("Name") %>', '<%# Eval("FullName") %>', '<%= Server.UrlEncode(folderPath) %>');">
                            <img src="../Images/IcoAdd.gif" align="absmiddle" /> 重命名
                        </a>
                        <a href="Main.aspx?act=del&amp;path=<%= Server.UrlEncode(folderPath) %>&amp;file=<%# Eval("FullName") %>&amp;type=<%# Eval("Type") %>" onclick="javascript:return confirm('确认删除 <%# Eval("Name") %> ?');">
                            <img src="../Images/IcoDelete.gif" align="absmiddle" /> 删除
                        </a>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="m-row2" onmouseover="c=this.style.backgroundColor;this.style.backgroundColor='#E4F1F8';" onmouseout="this.style.backgroundColor=c;">
                    <td><%# Eval("FormatName") %></td>
                    <td><%# Eval("Ext") %></td>
                    <td><%# Eval("FormatSize") %></td>
                    <td><%# Eval("FormatModifyDate") %></td>
                    <td>
                        <a href="#" onclick="javascript:toRename('<%# Eval("Name")%>', '<%# Eval("FullName") %>', '<%= Server.UrlEncode(folderPath) %>');">
                            <img src="../Images/IcoAdd.gif" align="absmiddle" /> 重命名
                        </a>                        
                        <a href="Main.aspx?act=del&amp;path=<%= Server.UrlEncode(folderPath) %>&amp;file=<%# Eval("FullName") %>&amp;type=<%# Eval("Type") %>" onclick="javascript:return confirm('确认删除 <%# Eval("Name") %> ?');">
                            <img src="../Images/IcoDelete.gif" align="absmiddle" /> 删除
                        </a>
                    </td>
                </tr>       
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>     
</div>
</div>
</body>
</html>