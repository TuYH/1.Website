var _Right=parent.mainframe;
function toolBack()
{
	_Right.history.back();
}
function toolForward()
{
	_Right.history.forward();
}
function toolStop()
{
	_Right.document.execCommand('stop');
}
function toolReload()
{
	_Right.location.reload();
}
function toolHome()
{
	_Right.location.href='SysInfo.aspx';
}

function check()
{
	var flg = "false";
	var check_box =document.getElementsByName("Id");
	num = check_box.length;
	if(num>1){
		for(i=0;i<num;i++){
			if(check_box[i].checked==false){
				flg = "false";}
			else{
				flg = "true";}
		}
		for(i=0;i<num;i++){
			if(flg=="true"){
				check_box[i].checked=false;}
			else{
				check_box[i].checked=true;}
		}		
	}
	else{
	if(document.myform.Id.checked==false){
				document.myform.Id.checked=true;}
			else{
				document.myform.Id.checked=false;}
	}
}

//切换频道
function channelNav(Obj) 
{
	var channelTabs = document.getElementById('topmenu').getElementsByTagName('a');
	for (i=0; i<channelTabs.length; i++)
	{
		channelTabs[i].className = '';
	}
	Obj.className = "current";
	Obj.blur();
}

function sideSwitch() {
	var leftFrame = window.parent.document.getElementById('leftFrameId');
	var switcher = document.getElementById('sideswitch');
	if (leftFrame.style.display == '') 
	{
		leftFrame.style.display = 'none';
		switcher.innerHTML = '打开左侧栏';
		switcher.className = 'closed';
	} 
	else 
	{
		leftFrame.style.display = '';
		switcher.innerHTML = '关闭左侧栏';
		switcher.className = 'opened';
	}
}

function externallinks()
{ 
    if (!document.getElementsByTagName)
    {
        return; 
    }
    var anchors = document.getElementsByTagName("a"); 
    for (var i=0; i<anchors.length; i++)
    { 
        var anchor = anchors[i]; 
        if (anchor.getAttribute("href")) 
        {
            if(anchor.getAttribute("rel") == "blank")
            {
                anchor.target = "_blank"; 
            }
            else if(anchor.getAttribute("rel") == "parent")
            {
                anchor.target = "_parent"; 
            }
            else if(anchor.getAttribute("rel") == "self")
            {
                anchor.target = "_self"; 
            }
            else if(anchor.getAttribute("rel") == "top")
            {
                anchor.target = "_top"; 
            }
            else if(anchor.getAttribute("rel") == "mainframe")
            {
                anchor.target = "mainframe"; 
            }
            else if(anchor.getAttribute("rel") == "leftFrame")
            {
                anchor.target = "leftFrame"; 
            }
        }
    }
}
window.onload = externallinks;

function change()   
{   
    var obj = event.srcElement;   
    if(obj.tagName.toLowerCase() == "td")   
    {   
        var oTr = obj.parentNode;   
        for(var i=1; i<document.all.table1.rows.length; i++)   
        {
            document.all.table1.rows[i].style.backgroundColor = "#FFFFFF";
            document.all.table1.rows[i].tag   =   false;
            oTr.style.backgroundColor = "#ffffff";
        }
        oTr.style.backgroundColor = "#f5f5f5";
        oTr.tag = true;
    }   
}   

function out()
{ 
    var obj = event.srcElement; 
    if(obj.tagName.toLowerCase() == "td") 
    {
        var oTr = obj.parentNode;
        if(!oTr.tag)
        {
            oTr.style.backgroundColor = "#ffffff";
        }
    }
} 

function over() 
{ 
    var obj = event.srcElement; 
    if(obj.tagName.toLowerCase() == "td") 
    { 
        var oTr = obj.parentNode; 
        if(!oTr.tag)
        {
            oTr.style.backgroundColor = "#FFF7F7"; 
        }
    } 
}
function AutoAdd()
{
    AutoAdd.prototype.ElementName;//元素名称
    AutoAdd.prototype.objName;//对象名称
    AutoAdd.prototype.MaxLength;//最大长度
    AutoAdd.prototype.Size;//元素宽度
    AutoAdd.prototype.Model_Title;//元素标题(自动获取)
    AutoAdd.prototype.binder=function(values)//参数为要绑定的数据
    {
        //this.Model_Title=jQuery(jQuery("#"+this.ElementName).parent().parent().find("td")[0]).html();//直接获取td内容
        this.Model_Title = jQuery("#"+this.ElementName).parent().parent().html().match(/<strong>([\s\S]*?)<\/strong>/i)[1];//获取td中的strong内容
        jQuery("#"+this.ElementName).parent().append("&nbsp;&nbsp;<a onclick=\""+this.objName+".addtables();\" href=\"javascript:void(0);\">添加</a>");
        var ElementVal= jQuery("#"+this.ElementName).val();
        if(ElementVal!=""||values!="")
        {
            var strval=ElementVal==""?values:ElementVal;
            var strs=strval.split("{$v$}");
            if(strs.length>=1){jQuery("#"+this.ElementName).val(strs[0]);}
            for(var i=strs.length-1;i>0;i--)
            {
                jQuery("#"+this.ElementName).parent().parent().after("<tr name=\""+this.ElementName+"trs\" onmouseover=\"over()\" onclick=\"change()\" onmouseout=\"out()\" class=\"td_bg\"><td style=\"width:130px;\"><strong>"+this.Model_Title+"</strong></td><td><input id=\""+this.ElementName+"\" name=\""+this.ElementName+"\" class=\"input\" value=\""+strs[i]+"\" maxlength=\""+this.MaxLength+"\" size=\""+this.Size+"\"/>&nbsp;&nbsp;<a onclick=\""+this.objName+".tabledel(this);\" href=\"javascript:void(0);\">删除</a></td></tr>");
            }
        }
    };
    AutoAdd.prototype.addtables=function()
    {
        var StrElement="<tr name=\""+this.ElementName+"trs\" onmouseover=\"over()\" onclick=\"change()\" onmouseout=\"out()\" class=\"td_bg\"><td style=\"width:130px;\"><strong>"+this.Model_Title+"</strong></td><td><input id=\""+this.ElementName+"\" name=\""+this.ElementName+"\" class=\"input\" maxlength=\""+this.MaxLength+"\" size=\""+this.Size+"\"/>&nbsp;&nbsp;<a onclick=\""+this.objName+".tabledel(this);\" href=\"javascript:void(0);\">删除</a></td></tr>";
        tellength = jQuery("tr[name=\""+this.ElementName+"trs\"]").length;
        if(tellength==0)
        {
            jQuery("#"+this.ElementName).parent().parent().after(StrElement);
        }
        else
        {
            jQuery(jQuery("tr[name=\""+this.ElementName+"trs\"]")[tellength-1]).after(StrElement);
        }
    };
    AutoAdd.prototype.tabledel=function(id)
    {
        var bool=confirm("你确认要删除此信息吗?");
        if(bool)
        {
            jQuery(id).parent().parent().remove();
        }
        return bool;
    };
}
/*------示例------
var auto1=new AutoAdd();
auto1.ElementName="tel";
auto1.objName="auto1";
auto1.MaxLength="50";
auto1.Size="60";
auto1.binder("");
------------------*/