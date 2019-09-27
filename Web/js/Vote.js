/*单选投票*/
function  LetterVote(obj)
{
	var o=document.getElementsByName('radio'+obj);
	var len=o.length;
	var flag=false;
	var v;
	for(var i=0;i<len;i++)
	{
	    if(o[i].checked==true)
	    {flag=1;v=o[i].value;break;}
	}
	if(flag)
	{
		$.get("/AJAX/TouPiao.aspx",{valuestr:v,radioid:obj},function(data){
	        if(data=="0")
		    {alert("投票失败！");}
		    else if(data=="1")
		    {alert("投票成功！");}
		    else if(data=="2")
		    {alert("一天只能投一次票！");}
		});
	}
	else{alert("请选择投票选项！");}
}
/*多选投票*/
function  LetterVote1(obj)
{	
	var o=document.getElementsByName('checkbox'+obj);
	var len=o.length;
	var flag=false;
	var v='';
	for(var i=0;i<len;i++)
	{
		if(o[i].checked==true)
		{flag=true;v+=o[i].value+',';}
	}
	if(flag)
	{
	    $.get("/AJAX/TouPiao.aspx",{valuestr:v,checkboxid:obj},function(data){
	        if(data=="0")
		    {alert("投票失败！");}
		    else if(data=="1")
		    {alert("投票成功！");}
		    else if(data=="2")
		    {alert("一天只能投一次票！");}
	    });
	}
	else
	{alert("请选择投票选项！");}
}