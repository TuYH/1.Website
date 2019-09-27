function UploadImage(InputName,ManagePath,CID)
{
    lhgdialog.opendlg( '图片上传', ManagePath.replace("~","")+'FileManage/uploadimage.aspx?CID='+CID+'&InputName='+InputName, 600, 372, true, true);
}

function MenuTemeplate(InputName, ManagePath) {
    lhgdialog.opendlg('选择模板', ManagePath.replace("~", "") + 'FileManage/CheckTemeplate.aspx?InputName=' + InputName, 600, 372, true, true);
}

function UploadFile(InputName,ManagePath,UploadFileType)
{
    lhgdialog.opendlg( '文件上传', ManagePath.replace("~","")+'FileManage/uploadfile.aspx?InputName='+InputName+'&UploadFileType='+UploadFileType, 400, 252, true, true);
}

function BatchUploadImage(InputName,ManagePath,CID)
{
    lhgdialog.opendlg( '图片批量上传', ManagePath.replace("~","")+'FileManage/batchuploadimage.aspx?CID='+CID+'&InputName='+InputName, 600, 430, true, true);
}

function BatchUploadFile(InputName,ManagePath,UploadFileType)
{
	lhgdialog.opendlg( '文件批量上传', ManagePath.replace("~","")+'FileManage/batchuploadfile.aspx?InputName='+InputName+'&UploadFileType='+UploadFileType, 600, 315, true, true);
}



function Upload_Move(id,move)
{
    var obj = document.getElementById(id);
    var index = obj.selectedIndex;
    if(index>=0)
    {
        var val = obj.options[index].value;
        var _index;
        var _val;
        if (move == "up")
        {
            _index = index - 1;
            if (_index >= 0) 
            {
                _val = obj.options[_index].value;
                obj.options[_index] = new Option(val, val, true, true);
                obj.options[index] = new Option(_val, _val, true, true);
            }
        }
        else 
        {
            _index = index + 1;
            if (_index < obj.length) 
            {
                _val = obj.options[_index].value;
                obj.options[_index] = new Option(val, val, true, true);
                obj.options[index] = new Option(_val, _val, true, true);
            }
        }
        ListText(id);
    }
}

function Upload_Remove(id)
{
    var obj = document.getElementById(id);
    var index = obj.selectedIndex;
    if (index >= 0)
    {
        obj.removeChild(obj.options[index]);
    }
    ListText(id);
}

function Upload_AllRemove(id)
{
    document.getElementById(id).options.length=0;
    ListText(id);
}

function ListText(id) 
{
    var obj = document.getElementById(id);
    var item="";
    if (obj.length > 0) 
    {
        for (var i = 0; i < obj.length; i++) 
        {
            item += obj.options[i].value;
            if(i+1<obj.length)
            {
                item += ",";
            }
        }
    }
    document.getElementById(id.replace("_Select","")).value = item;
}