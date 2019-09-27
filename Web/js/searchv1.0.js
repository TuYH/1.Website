$(function(){
	$('#backBtn').click(function(){
		$('#popup_box').removeClass('popup_box');
		history.go(-1);	
	});
			
	$('#suggest_clean').click(function(){
		$('#search_input').val('').focus();
		$('#search_result').html('');
	});
	$('#search_input').focus(function(){
		window.location.href='/search/';
		/*
		$('#popup_cover').show();
		$('#popup_content').show();
		$('#popup_box').addClass('popup_box');
		window.location.href=window.location.href.replace(window.location.hash,'')+'#search';
		*/
	});
	
	/*$('#search_input').bind('input propertychange',function(){
		$('#popup_cover').show();
		$('#popup_content').show();
		$('#popup_box').addClass('popup_box');
		var kw = $(this).val();
		$.get('/search/search.php',{postStr:kw},function(a){
			var ret = eval(a);
			var html = new Array();
			for (i in ret){
				var name = ret[i].title?ret[i].title:'';
				var url = ret[i].url?ret[i].url:'';
				html.push('<li><a href="'+url+'">'+name+'</a></li>');
			}
			$('#search_result').html(html.join(""));
		})
	});
	*/
})
window.onhashchange=function(){
	var hashStr = location.hash.replace("#","");
	if(hashStr!='search'){
		$('#popup_cover').hide();
		$('#popup_content').hide();
	}
}



