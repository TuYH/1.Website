//批量执行里执行下面的方法
function Exec()
{
	if(getCheckedCount()=="0")
	{
	    alert("请选择您要执行的操作的记录！");
	    return false;
	}
	if(confirm("确定执行操作吗?"))
	{
	    return true;
	}
	else
	{
	    return false;
	}
}

//判断CheckBox是否被选中
function getCheckedCount()
{
	var elements=document.getElementsByTagName("input");
	var intCheckCount=0;
	for(var i=0;i<elements.length;i++)
	{
		var e=elements[i];
		if(e.type=="checkbox"&&e.checked)
		{
			intCheckCount++;
		}
	}
	return intCheckCount;
}

//checkbox全选
function SelectAllCheckboxes(spanChk)
{
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;
   for(i=0;i<elm.length;i++)
   {
     if(elm[i].type=="checkbox" && elm[i].id!=theBox.id && elm[i].id=="CK_ID")
     {
       if(elm[i].checked!=xState){ elm[i].click();}
     }
   }
 }
 
function SelectAllCheckboxes1(spanChk)
{
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
   {
     if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
     {
       if(elm[i].checked!=xState){ elm[i].click();}
     }
   }
 }

function WinFullOpen(url)
{
	var newwin=window.open("","","scrollbars");
	if(document.all)
	{
		newwin.moveTo(0,0);
		newwin.resizeTo(600,400);
	}
	newwin.location=url;
}