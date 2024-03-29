﻿/*
 *@Generator -> LiHuiGang - Email:lhg133@126.com - QQ:463214570 Ver:1.1.0
 *@Copyright (c) 2009 LiHuiGang Compostion Blog:http://www.cnblogs.com/lhgstudio/
 */

var binfo = (function()
{
    var ua = navigator.userAgent.toLowerCase();
	return {
	    ie : /*@cc_on!@*/false,
		i7 : /*@cc_on!@*/false && (parseInt(ua.match(/msie (\d+)/)[1],10) >= 7)
	};
})();

var config = { bpath : '/js/lhgdialog/', opac : 0.50, bgcolor : '#fff', bzi : null };

var tool =
{
	restyle : function(e)
	{
	    e.style.cssText = 'margin:0;padding:0;background-image:none;background-color:transparent;border:0;';
	},
	
	ststyle : function( e, dict )
	{
	    var style = e.style;
		for( var n in dict ) style[n] = dict[n];
	},
	
	stopac : function( e, opac )
	{
	    if( binfo.ie )
		{
		    opac = Math.round( opac * 100 );
			e.style.filter = ( opac > 100 ? '' : 'alpha(opacity=' + opac + ')' );
		}
		else
		    e.style.opacity = opac;
	},
	
	getvoid : function()
	{
	    if( binfo.ie )
		    return ( binfo.i7 ? '' : 'javascript:\'\'' );
		return 'javascript:void(0)';
	},
	
	addevt : function( o, e, l )
	{
	    if( binfo.ie )
		    o.attachEvent( 'on' + e, l );
		else
		    o.addEventListener( e, l, false );
	},
	
	remevt : function( o, e, l )
	{
	    if( binfo.ie )
		    o.detachEvent( 'on' + e, l );
		else
		    o.removeEventListener( e, l, false );
	},
	
	isdtd : function(doc)
	{
	    return ( 'CSS1Compat' == ( doc.compatMode || 'CSS1Compat' ) );
	},
	
	getclsize : function(w)
	{
		if( binfo.ie )
		{
		    var oSize, doc = w.document.documentElement;
			oSize = ( doc && doc.clientWidth ) ? doc : w.document.body;
			
			if(oSize)
			    return { w : oSize.clientWidth, h : oSize.clientHeight };
			else
			    return { w : 0, h : 0 };
		}
		else
		    return { w : w.innerWidth, h : w.innerHeight };
	},
	
	getspos : function(w)
	{
	    if( binfo.ie )
		{
		    var doc = w.document;
			var oPos = { X : doc.documentElement.scrollLeft, Y : doc.documentElement.scrollTop };
			if( oPos.X > 0 || oPos.Y > 0 ) return oPos;
			return { X : doc.body.scrollLeft, Y : doc.body.scrollTop };
		}
		else
		    return { X : w.pageXOffset, Y : w.pageYOffset };
	},
	
	getlink : function(c)
	{
	    if( c.length == 0 ) return;
		return '<' + 'link href="' + c + '" type="text/css" rel="stylesheet"/>';
	},
	
	regdoll : function(w)
	{
	    if( binfo.ie )
		    w.$ = w.document.getElementById;
		else
		    w.$ = function(id){ return w.document.getElementById(id); };
	},
	
	getedoc : function(e)
	{
	    return e.ownerDocument || e.document;
	},
	
	remnode : function(n){ return n.parentNode.removeChild(n); }
};

var lhgdialog = (function()
{
    var twin = window.parent, cover;
	while( twin.parent && twin.parent != twin )
	{
	    try{ if( twin.parent.document.domain != document.domain ) break; } catch(e){break;}
		twin = twin.parent;
	}
	var tdoc = twin.document;
	
	var getzi = function()
	{
	    if(!config.bzi) config.bzi = 999; return ++config.bzi;
	};
	
	var resizehdl = function()
	{
	    if(!cover) return;
		var rel = tool.isdtd(tdoc) ? tdoc.documentElement : tdoc.body;
		tool.ststyle(cover,
		{
		    'width' : Math.max( rel.scrollWidth, rel.clientWidth, tdoc.scrollWidth || 0 ) - 1 + 'px',
			'height' : Math.max( rel.scrollHeight, rel.clientHeight, tdoc.scrollHeight || 0 ) - 1 + 'px'
		});
	};
    
    return {
		opendlg : function( t, p, w, h, c, i, o, l, n )
		{
			if(c) this.dcover(); else{ if(cover) cover = null; }
			var dinfo = { tit : t, page : p, win : window, topw : twin, link : i };
			var clsize = tool.getclsize(twin), spos = tool.getspos(twin);
			
			var it = o ? o : Math.max( spos.Y + ( clsize.h - h - 20 ) / 2, 0 );
			var il = l ? l : Math.max( spos.X + ( clsize.w - w - 20 ) / 2, 0 );
			
			var dfrm = tdoc.createElement('iframe'); tool.restyle(dfrm); if(n) dfrm.id = n;
			dfrm.frameBorder = 0; dfrm.src = config.bpath + 'lhgdialog.html';
			tool.ststyle(dfrm,
			{
			    'position' : 'absolute', 'top' : it + 'px', 'left' : il + 'px',
				'width' : w + 'px', 'height' : h + 'px', 'zIndex' : getzi()
			});
			tdoc.body.appendChild(dfrm); dfrm._dlgargs = dinfo;
		},
		
		closdlg : function( d, c )
		{
			var dlg = ( 'object' == typeof(d) ) ? d.frameElement : document.getElementById(d);
			if(dlg) tool.remnode(dlg); if(c) this.hcover(c);
		},
		
		dcover : function()
		{
		    cover = tdoc.createElement('div'); tool.restyle(cover);
			tool.ststyle(cover, 
			{
				'position' : 'absolute', 'zIndex' : getzi(), 'top' : '0px',
				'left' : '0px', 'backgroundColor' : config.bgcolor
			});
			tool.stopac( cover, config.opac );
			
			if( binfo.ie && !binfo.i7 )
			{
			    var ifrm = tdoc.createElement('iframe');
				tool.restyle(ifrm); ifrm.hideFocus = true;
				ifrm.frameBorder = 0; ifrm.src = tool.getvoid();
				tool.ststyle(ifrm,
				{
				    'width' : '100%', 'height' : '100%', 'position' : 'absolute', 'left' : '0px',
					'top' : '0px', 'filter' : 'progid:DXImageTransform.Microsoft.Alpha(opacity=0)'
				});
				cover.appendChild(ifrm);
			}
			
			tool.addevt( twin, 'resize', resizehdl ); resizehdl(); tdoc.body.appendChild(cover);
		},
		
		gcover : function(){ return cover; },
		hcover : function(o){ tool.remnode(o); cover = null; o = null; }
	};
})();