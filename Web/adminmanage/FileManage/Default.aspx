<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="adminmanage_FileManage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <script type="text/javascript" language="javascript" src="../../js/lhgdialog/lhgdialog.js"></script>
<script language="javascript" type="text/javascript" src="../js/Upload.js"></script>
</head>
<body>
    <p>
      <input name="pic" type="text" id="pic" />
      <input type="submit" name="Submit2" value="图片上传" onclick="UploadImage('pic','~/adminmanage/');" />
    </p>
    <p>
      <select name="batpic" size="10" id="batpic">
      </select>
      <input type="submit" name="Submit3" value="图片批量上传" onclick="BatchUploadImage('batpic','~/adminmanage/','');" />
    </p>
    <p>
      <input name="file" type="text" id="file" />
      <input type="submit" name="Submit4" value="文件上传" onclick="UploadFile('file','~/adminmanage/');" />
    </p>
<p>
      <select name="batfile" size="10" id="batfile" style="width:400px">
                                </select>
      <br />
      <input type="button" name="Submit" value="文件批量上传" onclick="BatchUploadFile('batfile','~/adminmanage/','')" />
       <input id="Button1" type="button" value="上移" onclick="Upload_Move('batfile','up');" />
       <input id="Button2" type="button" value="下移" onclick="Upload_Move('batfile','down');" />
       <input id="Button3" type="button" value="删除" onclick="Upload_Remove('batfile');" />
       <input id="Button4" type="button" value="全部删除" onclick="Upload_AllRemove('batfile');" />
       </p>
</body>
</html>
