/*
 * jQuery JavaScript Library v1.3.2
 * http://jquery.com/
 *
 * Copyright (c) 2009 John Resig
 * Dual licensed under the MIT and GPL licenses.
 * http://docs.jquery.com/License
 *
 * Date: 2009-02-19 17:34:21 -0500 (Thu, 19 Feb 2009)
 * Revision: 6246
 */
(function(){var l=this,g,y=l.jQuery,p=l.$,o=l.jQuery=l.$=function(E,F){return new o.fn.init(E,F)},D=/^[^<]*(<(.|\s)+>)[^>]*$|^#([#\w-\[\]]+)$/,f=/^.[^:#\[\.,]*$/;o.fn=o.prototype={init:function(E,H){E=E||document;if(E.nodeType){this[0]=E;this.length=1;this.context=E;return this}if(typeof E==="string"){var G=D.exec(E);if(G&&(G[1]||!H)){if(G[1]){E=o.clean([G[1]],H)}else{var I=document.getElementById(G[3]);if(I&&I.id!=G[3]){return o().find(E)}var F=o(I||[]);F.context=document;F.selector=E;return F}}else{return o(H).find(E)}}else{if(o.isFunction(E)){return o(document).ready(E)}}if(E.selector&&E.context){this.selector=E.selector;this.context=E.context}return this.setArray(o.isArray(E)?E:o.makeArray(E))},selector:"",jquery:"1.3.2",size:function(){return this.length},get:function(E){return E===g?Array.prototype.slice.call(this):this[E]},pushStack:function(F,H,E){var G=o(F);G.prevObject=this;G.context=this.context;if(H==="find"){G.selector=this.selector+(this.selector?" ":"")+E}else{if(H){G.selector=this.selector+"."+H+"("+E+")"}}return G},setArray:function(E){this.length=0;Array.prototype.push.apply(this,E);return this},each:function(F,E){return o.each(this,F,E)},index:function(E){return o.inArray(E&&E.jquery?E[0]:E,this)},attr:function(F,H,G){var E=F;if(typeof F==="string"){if(H===g){return this[0]&&o[G||"attr"](this[0],F)}else{E={};E[F]=H}}return this.each(function(I){for(F in E){o.attr(G?this.style:this,F,o.prop(this,E[F],G,I,F))}})},css:function(E,F){if((E=="width"||E=="height")&&parseFloat(F)<0){F=g}return this.attr(E,F,"curCSS")},text:function(F){if(typeof F!=="object"&&F!=null){return this.empty().append((this[0]&&this[0].ownerDocument||document).createTextNode(F))}var E="";o.each(F||this,function(){o.each(this.childNodes,function(){if(this.nodeType!=8){E+=this.nodeType!=1?this.nodeValue:o.fn.text([this])}})});return E},wrapAll:function(E){if(this[0]){var F=o(E,this[0].ownerDocument).clone();if(this[0].parentNode){F.insertBefore(this[0])}F.map(function(){var G=this;while(G.firstChild){G=G.firstChild}return G}).append(this)}return this},wrapInner:function(E){return this.each(function(){o(this).contents().wrapAll(E)})},wrap:function(E){return this.each(function(){o(this).wrapAll(E)})},append:function(){return this.domManip(arguments,true,function(E){if(this.nodeType==1){this.appendChild(E)}})},prepend:function(){return this.domManip(arguments,true,function(E){if(this.nodeType==1){this.insertBefore(E,this.firstChild)}})},before:function(){return this.domManip(arguments,false,function(E){this.parentNode.insertBefore(E,this)})},after:function(){return this.domManip(arguments,false,function(E){this.parentNode.insertBefore(E,this.nextSibling)})},end:function(){return this.prevObject||o([])},push:[].push,sort:[].sort,splice:[].splice,find:function(E){if(this.length===1){var F=this.pushStack([],"find",E);F.length=0;o.find(E,this[0],F);return F}else{return this.pushStack(o.unique(o.map(this,function(G){return o.find(E,G)})),"find",E)}},clone:function(G){var E=this.map(function(){if(!o.support.noCloneEvent&&!o.isXMLDoc(this)){var I=this.outerHTML;if(!I){var J=this.ownerDocument.createElement("div");J.appendChild(this.cloneNode(true));I=J.innerHTML}return o.clean([I.replace(/ jQuery\d+="(?:\d+|null)"/g,"").replace(/^\s*/,"")])[0]}else{return this.cloneNode(true)}});if(G===true){var H=this.find("*").andSelf(),F=0;E.find("*").andSelf().each(function(){if(this.nodeName!==H[F].nodeName){return}var I=o.data(H[F],"events");for(var K in I){for(var J in I[K]){o.event.add(this,K,I[K][J],I[K][J].data)}}F++})}return E},filter:function(E){return this.pushStack(o.isFunction(E)&&o.grep(this,function(G,F){return E.call(G,F)})||o.multiFilter(E,o.grep(this,function(F){return F.nodeType===1})),"filter",E)},closest:function(E){var G=o.expr.match.POS.test(E)?o(E):null,F=0;return this.map(function(){var H=this;while(H&&H.ownerDocument){if(G?G.index(H)>-1:o(H).is(E)){o.data(H,"closest",F);return H}H=H.parentNode;F++}})},not:function(E){if(typeof E==="string"){if(f.test(E)){return this.pushStack(o.multiFilter(E,this,true),"not",E)}else{E=o.multiFilter(E,this)}}var F=E.length&&E[E.length-1]!==g&&!E.nodeType;return this.filter(function(){return F?o.inArray(this,E)<0:this!=E})},add:function(E){return this.pushStack(o.unique(o.merge(this.get(),typeof E==="string"?o(E):o.makeArray(E))))},is:function(E){return !!E&&o.multiFilter(E,this).length>0},hasClass:function(E){return !!E&&this.is("."+E)},val:function(K){if(K===g){var E=this[0];if(E){if(o.nodeName(E,"option")){return(E.attributes.value||{}).specified?E.value:E.text}if(o.nodeName(E,"select")){var I=E.selectedIndex,L=[],M=E.options,H=E.type=="select-one";if(I<0){return null}for(var F=H?I:0,J=H?I+1:M.length;F<J;F++){var G=M[F];if(G.selected){K=o(G).val();if(H){return K}L.push(K)}}return L}return(E.value||"").replace(/\r/g,"")}return g}if(typeof K==="number"){K+=""}return this.each(function(){if(this.nodeType!=1){return}if(o.isArray(K)&&/radio|checkbox/.test(this.type)){this.checked=(o.inArray(this.value,K)>=0||o.inArray(this.name,K)>=0)}else{if(o.nodeName(this,"select")){var N=o.makeArray(K);o("option",this).each(function(){this.selected=(o.inArray(this.value,N)>=0||o.inArray(this.text,N)>=0)});if(!N.length){this.selectedIndex=-1}}else{this.value=K}}})},html:function(E){return E===g?(this[0]?this[0].innerHTML.replace(/ jQuery\d+="(?:\d+|null)"/g,""):null):this.empty().append(E)},replaceWith:function(E){return this.after(E).remove()},eq:function(E){return this.slice(E,+E+1)},slice:function(){return this.pushStack(Array.prototype.slice.apply(this,arguments),"slice",Array.prototype.slice.call(arguments).join(","))},map:function(E){return this.pushStack(o.map(this,function(G,F){return E.call(G,F,G)}))},andSelf:function(){return this.add(this.prevObject)},domManip:function(J,M,L){if(this[0]){var I=(this[0].ownerDocument||this[0]).createDocumentFragment(),F=o.clean(J,(this[0].ownerDocument||this[0]),I),H=I.firstChild;if(H){for(var G=0,E=this.length;G<E;G++){L.call(K(this[G],H),this.length>1||G>0?I.cloneNode(true):I)}}if(F){o.each(F,z)}}return this;function K(N,O){return M&&o.nodeName(N,"table")&&o.nodeName(O,"tr")?(N.getElementsByTagName("tbody")[0]||N.appendChild(N.ownerDocument.createElement("tbody"))):N}}};o.fn.init.prototype=o.fn;function z(E,F){if(F.src){o.ajax({url:F.src,async:false,dataType:"script"})}else{o.globalEval(F.text||F.textContent||F.innerHTML||"")}if(F.parentNode){F.parentNode.removeChild(F)}}function e(){return +new Date}o.extend=o.fn.extend=function(){var J=arguments[0]||{},H=1,I=arguments.length,E=false,G;if(typeof J==="boolean"){E=J;J=arguments[1]||{};H=2}if(typeof J!=="object"&&!o.isFunction(J)){J={}}if(I==H){J=this;--H}for(;H<I;H++){if((G=arguments[H])!=null){for(var F in G){var K=J[F],L=G[F];if(J===L){continue}if(E&&L&&typeof L==="object"&&!L.nodeType){J[F]=o.extend(E,K||(L.length!=null?[]:{}),L)}else{if(L!==g){J[F]=L}}}}}return J};var b=/z-?index|font-?weight|opacity|zoom|line-?height/i,q=document.defaultView||{},s=Object.prototype.toString;o.extend({noConflict:function(E){l.$=p;if(E){l.jQuery=y}return o},isFunction:function(E){return s.call(E)==="[object Function]"},isArray:function(E){return s.call(E)==="[object Array]"},isXMLDoc:function(E){return E.nodeType===9&&E.documentElement.nodeName!=="HTML"||!!E.ownerDocument&&o.isXMLDoc(E.ownerDocument)},globalEval:function(G){if(G&&/\S/.test(G)){var F=document.getElementsByTagName("head")[0]||document.documentElement,E=document.createElement("script");E.type="text/javascript";if(o.support.scriptEval){E.appendChild(document.createTextNode(G))}else{E.text=G}F.insertBefore(E,F.firstChild);F.removeChild(E)}},nodeName:function(F,E){return F.nodeName&&F.nodeName.toUpperCase()==E.toUpperCase()},each:function(G,K,F){var E,H=0,I=G.length;if(F){if(I===g){for(E in G){if(K.apply(G[E],F)===false){break}}}else{for(;H<I;){if(K.apply(G[H++],F)===false){break}}}}else{if(I===g){for(E in G){if(K.call(G[E],E,G[E])===false){break}}}else{for(var J=G[0];H<I&&K.call(J,H,J)!==false;J=G[++H]){}}}return G},prop:function(H,I,G,F,E){if(o.isFunction(I)){I=I.call(H,F)}return typeof I==="number"&&G=="curCSS"&&!b.test(E)?I+"px":I},className:{add:function(E,F){o.each((F||"").split(/\s+/),function(G,H){if(E.nodeType==1&&!o.className.has(E.className,H)){E.className+=(E.className?" ":"")+H}})},remove:function(E,F){if(E.nodeType==1){E.className=F!==g?o.grep(E.className.split(/\s+/),function(G){return !o.className.has(F,G)}).join(" "):""}},has:function(F,E){return F&&o.inArray(E,(F.className||F).toString().split(/\s+/))>-1}},swap:function(H,G,I){var E={};for(var F in G){E[F]=H.style[F];H.style[F]=G[F]}I.call(H);for(var F in G){H.style[F]=E[F]}},css:function(H,F,J,E){if(F=="width"||F=="height"){var L,G={position:"absolute",visibility:"hidden",display:"block"},K=F=="width"?["Left","Right"]:["Top","Bottom"];function I(){L=F=="width"?H.offsetWidth:H.offsetHeight;if(E==="border"){return}o.each(K,function(){if(!E){L-=parseFloat(o.curCSS(H,"padding"+this,true))||0}if(E==="margin"){L+=parseFloat(o.curCSS(H,"margin"+this,true))||0}else{L-=parseFloat(o.curCSS(H,"border"+this+"Width",true))||0}})}if(H.offsetWidth!==0){I()}else{o.swap(H,G,I)}return Math.max(0,Math.round(L))}return o.curCSS(H,F,J)},curCSS:function(I,F,G){var L,E=I.style;if(F=="opacity"&&!o.support.opacity){L=o.attr(E,"opacity");return L==""?"1":L}if(F.match(/float/i)){F=w}if(!G&&E&&E[F]){L=E[F]}else{if(q.getComputedStyle){if(F.match(/float/i)){F="float"}F=F.replace(/([A-Z])/g,"-$1").toLowerCase();var M=q.getComputedStyle(I,null);if(M){L=M.getPropertyValue(F)}if(F=="opacity"&&L==""){L="1"}}else{if(I.currentStyle){var J=F.replace(/\-(\w)/g,function(N,O){return O.toUpperCase()});L=I.currentStyle[F]||I.currentStyle[J];if(!/^\d+(px)?$/i.test(L)&&/^\d/.test(L)){var H=E.left,K=I.runtimeStyle.left;I.runtimeStyle.left=I.currentStyle.left;E.left=L||0;L=E.pixelLeft+"px";E.left=H;I.runtimeStyle.left=K}}}}return L},clean:function(F,K,I){K=K||document;if(typeof K.createElement==="undefined"){K=K.ownerDocument||K[0]&&K[0].ownerDocument||document}if(!I&&F.length===1&&typeof F[0]==="string"){var H=/^<(\w+)\s*\/?>$/.exec(F[0]);if(H){return[K.createElement(H[1])]}}var G=[],E=[],L=K.createElement("div");o.each(F,function(P,S){if(typeof S==="number"){S+=""}if(!S){return}if(typeof S==="string"){S=S.replace(/(<(\w+)[^>]*?)\/>/g,function(U,V,T){return T.match(/^(abbr|br|col|img|input|link|meta|param|hr|area|embed)$/i)?U:V+"></"+T+">"});var O=S.replace(/^\s+/,"").substring(0,10).toLowerCase();var Q=!O.indexOf("<opt")&&[1,"<select multiple='multiple'>","</select>"]||!O.indexOf("<leg")&&[1,"<fieldset>","</fieldset>"]||O.match(/^<(thead|tbody|tfoot|colg|cap)/)&&[1,"<table>","</table>"]||!O.indexOf("<tr")&&[2,"<table><tbody>","</tbody></table>"]||(!O.indexOf("<td")||!O.indexOf("<th"))&&[3,"<table><tbody><tr>","</tr></tbody></table>"]||!O.indexOf("<col")&&[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"]||!o.support.htmlSerialize&&[1,"div<div>","</div>"]||[0,"",""];L.innerHTML=Q[1]+S+Q[2];while(Q[0]--){L=L.lastChild}if(!o.support.tbody){var R=/<tbody/i.test(S),N=!O.indexOf("<table")&&!R?L.firstChild&&L.firstChild.childNodes:Q[1]=="<table>"&&!R?L.childNodes:[];for(var M=N.length-1;M>=0;--M){if(o.nodeName(N[M],"tbody")&&!N[M].childNodes.length){N[M].parentNode.removeChild(N[M])}}}if(!o.support.leadingWhitespace&&/^\s/.test(S)){L.insertBefore(K.createTextNode(S.match(/^\s*/)[0]),L.firstChild)}S=o.makeArray(L.childNodes)}if(S.nodeType){G.push(S)}else{G=o.merge(G,S)}});if(I){for(var J=0;G[J];J++){if(o.nodeName(G[J],"script")&&(!G[J].type||G[J].type.toLowerCase()==="text/javascript")){E.push(G[J].parentNode?G[J].parentNode.removeChild(G[J]):G[J])}else{if(G[J].nodeType===1){G.splice.apply(G,[J+1,0].concat(o.makeArray(G[J].getElementsByTagName("script"))))}I.appendChild(G[J])}}return E}return G},attr:function(J,G,K){if(!J||J.nodeType==3||J.nodeType==8){return g}var H=!o.isXMLDoc(J),L=K!==g;G=H&&o.props[G]||G;if(J.tagName){var F=/href|src|style/.test(G);if(G=="selected"&&J.parentNode){J.parentNode.selectedIndex}if(G in J&&H&&!F){if(L){if(G=="type"&&o.nodeName(J,"input")&&J.parentNode){throw"type property can't be changed"}J[G]=K}if(o.nodeName(J,"form")&&J.getAttributeNode(G)){return J.getAttributeNode(G).nodeValue}if(G=="tabIndex"){var I=J.getAttributeNode("tabIndex");return I&&I.specified?I.value:J.nodeName.match(/(button|input|object|select|textarea)/i)?0:J.nodeName.match(/^(a|area)$/i)&&J.href?0:g}return J[G]}if(!o.support.style&&H&&G=="style"){return o.attr(J.style,"cssText",K)}if(L){J.setAttribute(G,""+K)}var E=!o.support.hrefNormalized&&H&&F?J.getAttribute(G,2):J.getAttribute(G);return E===null?g:E}if(!o.support.opacity&&G=="opacity"){if(L){J.zoom=1;J.filter=(J.filter||"").replace(/alpha\([^)]*\)/,"")+(parseInt(K)+""=="NaN"?"":"alpha(opacity="+K*100+")")}return J.filter&&J.filter.indexOf("opacity=")>=0?(parseFloat(J.filter.match(/opacity=([^)]*)/)[1])/100)+"":""}G=G.replace(/-([a-z])/ig,function(M,N){return N.toUpperCase()});if(L){J[G]=K}return J[G]},trim:function(E){return(E||"").replace(/^\s+|\s+$/g,"")},makeArray:function(G){var E=[];if(G!=null){var F=G.length;if(F==null||typeof G==="string"||o.isFunction(G)||G.setInterval){E[0]=G}else{while(F){E[--F]=G[F]}}}return E},inArray:function(G,H){for(var E=0,F=H.length;E<F;E++){if(H[E]===G){return E}}return -1},merge:function(H,E){var F=0,G,I=H.length;if(!o.support.getAll){while((G=E[F++])!=null){if(G.nodeType!=8){H[I++]=G}}}else{while((G=E[F++])!=null){H[I++]=G}}return H},unique:function(K){var F=[],E={};try{for(var G=0,H=K.length;G<H;G++){var J=o.data(K[G]);if(!E[J]){E[J]=true;F.push(K[G])}}}catch(I){F=K}return F},grep:function(F,J,E){var G=[];for(var H=0,I=F.length;H<I;H++){if(!E!=!J(F[H],H)){G.push(F[H])}}return G},map:function(E,J){var F=[];for(var G=0,H=E.length;G<H;G++){var I=J(E[G],G);if(I!=null){F[F.length]=I}}return F.concat.apply([],F)}});var C=navigator.userAgent.toLowerCase();o.browser={version:(C.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/)||[0,"0"])[1],safari:/webkit/.test(C),opera:/opera/.test(C),msie:/msie/.test(C)&&!/opera/.test(C),mozilla:/mozilla/.test(C)&&!/(compatible|webkit)/.test(C)};o.each({parent:function(E){return E.parentNode},parents:function(E){return o.dir(E,"parentNode")},next:function(E){return o.nth(E,2,"nextSibling")},prev:function(E){return o.nth(E,2,"previousSibling")},nextAll:function(E){return o.dir(E,"nextSibling")},prevAll:function(E){return o.dir(E,"previousSibling")},siblings:function(E){return o.sibling(E.parentNode.firstChild,E)},children:function(E){return o.sibling(E.firstChild)},contents:function(E){return o.nodeName(E,"iframe")?E.contentDocument||E.contentWindow.document:o.makeArray(E.childNodes)}},function(E,F){o.fn[E]=function(G){var H=o.map(this,F);if(G&&typeof G=="string"){H=o.multiFilter(G,H)}return this.pushStack(o.unique(H),E,G)}});o.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(E,F){o.fn[E]=function(G){var J=[],L=o(G);for(var K=0,H=L.length;K<H;K++){var I=(K>0?this.clone(true):this).get();o.fn[F].apply(o(L[K]),I);J=J.concat(I)}return this.pushStack(J,E,G)}});o.each({removeAttr:function(E){o.attr(this,E,"");if(this.nodeType==1){this.removeAttribute(E)}},addClass:function(E){o.className.add(this,E)},removeClass:function(E){o.className.remove(this,E)},toggleClass:function(F,E){if(typeof E!=="boolean"){E=!o.className.has(this,F)}o.className[E?"add":"remove"](this,F)},remove:function(E){if(!E||o.filter(E,[this]).length){o("*",this).add([this]).each(function(){o.event.remove(this);o.removeData(this)});if(this.parentNode){this.parentNode.removeChild(this)}}},empty:function(){o(this).children().remove();while(this.firstChild){this.removeChild(this.firstChild)}}},function(E,F){o.fn[E]=function(){return this.each(F,arguments)}});function j(E,F){return E[0]&&parseInt(o.curCSS(E[0],F,true),10)||0}var h="jQuery"+e(),v=0,A={};o.extend({cache:{},data:function(F,E,G){F=F==l?A:F;var H=F[h];if(!H){H=F[h]=++v}if(E&&!o.cache[H]){o.cache[H]={}}if(G!==g){o.cache[H][E]=G}return E?o.cache[H][E]:H},removeData:function(F,E){F=F==l?A:F;var H=F[h];if(E){if(o.cache[H]){delete o.cache[H][E];E="";for(E in o.cache[H]){break}if(!E){o.removeData(F)}}}else{try{delete F[h]}catch(G){if(F.removeAttribute){F.removeAttribute(h)}}delete o.cache[H]}},queue:function(F,E,H){if(F){E=(E||"fx")+"queue";var G=o.data(F,E);if(!G||o.isArray(H)){G=o.data(F,E,o.makeArray(H))}else{if(H){G.push(H)}}}return G},dequeue:function(H,G){var E=o.queue(H,G),F=E.shift();if(!G||G==="fx"){F=E[0]}if(F!==g){F.call(H)}}});o.fn.extend({data:function(E,G){var H=E.split(".");H[1]=H[1]?"."+H[1]:"";if(G===g){var F=this.triggerHandler("getData"+H[1]+"!",[H[0]]);if(F===g&&this.length){F=o.data(this[0],E)}return F===g&&H[1]?this.data(H[0]):F}else{return this.trigger("setData"+H[1]+"!",[H[0],G]).each(function(){o.data(this,E,G)})}},removeData:function(E){return this.each(function(){o.removeData(this,E)})},queue:function(E,F){if(typeof E!=="string"){F=E;E="fx"}if(F===g){return o.queue(this[0],E)}return this.each(function(){var G=o.queue(this,E,F);if(E=="fx"&&G.length==1){G[0].call(this)}})},dequeue:function(E){return this.each(function(){o.dequeue(this,E)})}});
/*
 * Sizzle CSS Selector Engine - v0.9.3
 *  Copyright 2009, The Dojo Foundation
 *  Released under the MIT, BSD, and GPL Licenses.
 *  More information: http://sizzlejs.com/
 */
(function(){var R=/((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^[\]]*\]|['"][^'"]*['"]|[^[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?/g,L=0,H=Object.prototype.toString;var F=function(Y,U,ab,ac){ab=ab||[];U=U||document;if(U.nodeType!==1&&U.nodeType!==9){return[]}if(!Y||typeof Y!=="string"){return ab}var Z=[],W,af,ai,T,ad,V,X=true;R.lastIndex=0;while((W=R.exec(Y))!==null){Z.push(W[1]);if(W[2]){V=RegExp.rightContext;break}}if(Z.length>1&&M.exec(Y)){if(Z.length===2&&I.relative[Z[0]]){af=J(Z[0]+Z[1],U)}else{af=I.relative[Z[0]]?[U]:F(Z.shift(),U);while(Z.length){Y=Z.shift();if(I.relative[Y]){Y+=Z.shift()}af=J(Y,af)}}}else{var ae=ac?{expr:Z.pop(),set:E(ac)}:F.find(Z.pop(),Z.length===1&&U.parentNode?U.parentNode:U,Q(U));af=F.filter(ae.expr,ae.set);if(Z.length>0){ai=E(af)}else{X=false}while(Z.length){var ah=Z.pop(),ag=ah;if(!I.relative[ah]){ah=""}else{ag=Z.pop()}if(ag==null){ag=U}I.relative[ah](ai,ag,Q(U))}}if(!ai){ai=af}if(!ai){throw"Syntax error, unrecognized expression: "+(ah||Y)}if(H.call(ai)==="[object Array]"){if(!X){ab.push.apply(ab,ai)}else{if(U.nodeType===1){for(var aa=0;ai[aa]!=null;aa++){if(ai[aa]&&(ai[aa]===true||ai[aa].nodeType===1&&K(U,ai[aa]))){ab.push(af[aa])}}}else{for(var aa=0;ai[aa]!=null;aa++){if(ai[aa]&&ai[aa].nodeType===1){ab.push(af[aa])}}}}}else{E(ai,ab)}if(V){F(V,U,ab,ac);if(G){hasDuplicate=false;ab.sort(G);if(hasDuplicate){for(var aa=1;aa<ab.length;aa++){if(ab[aa]===ab[aa-1]){ab.splice(aa--,1)}}}}}return ab};F.matches=function(T,U){return F(T,null,null,U)};F.find=function(aa,T,ab){var Z,X;if(!aa){return[]}for(var W=0,V=I.order.length;W<V;W++){var Y=I.order[W],X;if((X=I.match[Y].exec(aa))){var U=RegExp.leftContext;if(U.substr(U.length-1)!=="\\"){X[1]=(X[1]||"").replace(/\\/g,"");Z=I.find[Y](X,T,ab);if(Z!=null){aa=aa.replace(I.match[Y],"");break}}}}if(!Z){Z=T.getElementsByTagName("*")}return{set:Z,expr:aa}};F.filter=function(ad,ac,ag,W){var V=ad,ai=[],aa=ac,Y,T,Z=ac&&ac[0]&&Q(ac[0]);while(ad&&ac.length){for(var ab in I.filter){if((Y=I.match[ab].exec(ad))!=null){var U=I.filter[ab],ah,af;T=false;if(aa==ai){ai=[]}if(I.preFilter[ab]){Y=I.preFilter[ab](Y,aa,ag,ai,W,Z);if(!Y){T=ah=true}else{if(Y===true){continue}}}if(Y){for(var X=0;(af=aa[X])!=null;X++){if(af){ah=U(af,Y,X,aa);var ae=W^!!ah;if(ag&&ah!=null){if(ae){T=true}else{aa[X]=false}}else{if(ae){ai.push(af);T=true}}}}}if(ah!==g){if(!ag){aa=ai}ad=ad.replace(I.match[ab],"");if(!T){return[]}break}}}if(ad==V){if(T==null){throw"Syntax error, unrecognized expression: "+ad}else{break}}V=ad}return aa};var I=F.selectors={order:["ID","NAME","TAG"],match:{ID:/#((?:[\w\u00c0-\uFFFF_-]|\\.)+)/,CLASS:/\.((?:[\w\u00c0-\uFFFF_-]|\\.)+)/,NAME:/\[name=['"]*((?:[\w\u00c0-\uFFFF_-]|\\.)+)['"]*\]/,ATTR:/\[\s*((?:[\w\u00c0-\uFFFF_-]|\\.)+)\s*(?:(\S?=)\s*(['"]*)(.*?)\3|)\s*\]/,TAG:/^((?:[\w\u00c0-\uFFFF\*_-]|\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\((even|odd|[\dn+-]*)\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^-]|$)/,PSEUDO:/:((?:[\w\u00c0-\uFFFF_-]|\\.)+)(?:\((['"]*)((?:\([^\)]+\)|[^\2\(\)]*)+)\2\))?/},attrMap:{"class":"className","for":"htmlFor"},attrHandle:{href:function(T){return T.getAttribute("href")}},relative:{"+":function(aa,T,Z){var X=typeof T==="string",ab=X&&!/\W/.test(T),Y=X&&!ab;if(ab&&!Z){T=T.toUpperCase()}for(var W=0,V=aa.length,U;W<V;W++){if((U=aa[W])){while((U=U.previousSibling)&&U.nodeType!==1){}aa[W]=Y||U&&U.nodeName===T?U||false:U===T}}if(Y){F.filter(T,aa,true)}},">":function(Z,U,aa){var X=typeof U==="string";if(X&&!/\W/.test(U)){U=aa?U:U.toUpperCase();for(var V=0,T=Z.length;V<T;V++){var Y=Z[V];if(Y){var W=Y.parentNode;Z[V]=W.nodeName===U?W:false}}}else{for(var V=0,T=Z.length;V<T;V++){var Y=Z[V];if(Y){Z[V]=X?Y.parentNode:Y.parentNode===U}}if(X){F.filter(U,Z,true)}}},"":function(W,U,Y){var V=L++,T=S;if(!U.match(/\W/)){var X=U=Y?U:U.toUpperCase();T=P}T("parentNode",U,V,W,X,Y)},"~":function(W,U,Y){var V=L++,T=S;if(typeof U==="string"&&!U.match(/\W/)){var X=U=Y?U:U.toUpperCase();T=P}T("previousSibling",U,V,W,X,Y)}},find:{ID:function(U,V,W){if(typeof V.getElementById!=="undefined"&&!W){var T=V.getElementById(U[1]);return T?[T]:[]}},NAME:function(V,Y,Z){if(typeof Y.getElementsByName!=="undefined"){var U=[],X=Y.getElementsByName(V[1]);for(var W=0,T=X.length;W<T;W++){if(X[W].getAttribute("name")===V[1]){U.push(X[W])}}return U.length===0?null:U}},TAG:function(T,U){return U.getElementsByTagName(T[1])}},preFilter:{CLASS:function(W,U,V,T,Z,aa){W=" "+W[1].replace(/\\/g,"")+" ";if(aa){return W}for(var X=0,Y;(Y=U[X])!=null;X++){if(Y){if(Z^(Y.className&&(" "+Y.className+" ").indexOf(W)>=0)){if(!V){T.push(Y)}}else{if(V){U[X]=false}}}}return false},ID:function(T){return T[1].replace(/\\/g,"")},TAG:function(U,T){for(var V=0;T[V]===false;V++){}return T[V]&&Q(T[V])?U[1]:U[1].toUpperCase()},CHILD:function(T){if(T[1]=="nth"){var U=/(-?)(\d*)n((?:\+|-)?\d*)/.exec(T[2]=="even"&&"2n"||T[2]=="odd"&&"2n+1"||!/\D/.test(T[2])&&"0n+"+T[2]||T[2]);T[2]=(U[1]+(U[2]||1))-0;T[3]=U[3]-0}T[0]=L++;return T},ATTR:function(X,U,V,T,Y,Z){var W=X[1].replace(/\\/g,"");if(!Z&&I.attrMap[W]){X[1]=I.attrMap[W]}if(X[2]==="~="){X[4]=" "+X[4]+" "}return X},PSEUDO:function(X,U,V,T,Y){if(X[1]==="not"){if(X[3].match(R).length>1||/^\w/.test(X[3])){X[3]=F(X[3],null,null,U)}else{var W=F.filter(X[3],U,V,true^Y);if(!V){T.push.apply(T,W)}return false}}else{if(I.match.POS.test(X[0])||I.match.CHILD.test(X[0])){return true}}return X},POS:function(T){T.unshift(true);return T}},filters:{enabled:function(T){return T.disabled===false&&T.type!=="hidden"},disabled:function(T){return T.disabled===true},checked:function(T){return T.checked===true},selected:function(T){T.parentNode.selectedIndex;return T.selected===true},parent:function(T){return !!T.firstChild},empty:function(T){return !T.firstChild},has:function(V,U,T){return !!F(T[3],V).length},header:function(T){return/h\d/i.test(T.nodeName)},text:function(T){return"text"===T.type},radio:function(T){return"radio"===T.type},checkbox:function(T){return"checkbox"===T.type},file:function(T){return"file"===T.type},password:function(T){return"password"===T.type},submit:function(T){return"submit"===T.type},image:function(T){return"image"===T.type},reset:function(T){return"reset"===T.type},button:function(T){return"button"===T.type||T.nodeName.toUpperCase()==="BUTTON"},input:function(T){return/input|select|textarea|button/i.test(T.nodeName)}},setFilters:{first:function(U,T){return T===0},last:function(V,U,T,W){return U===W.length-1},even:function(U,T){return T%2===0},odd:function(U,T){return T%2===1},lt:function(V,U,T){return U<T[3]-0},gt:function(V,U,T){return U>T[3]-0},nth:function(V,U,T){return T[3]-0==U},eq:function(V,U,T){return T[3]-0==U}},filter:{PSEUDO:function(Z,V,W,aa){var U=V[1],X=I.filters[U];if(X){return X(Z,W,V,aa)}else{if(U==="contains"){return(Z.textContent||Z.innerText||"").indexOf(V[3])>=0}else{if(U==="not"){var Y=V[3];for(var W=0,T=Y.length;W<T;W++){if(Y[W]===Z){return false}}return true}}}},CHILD:function(T,W){var Z=W[1],U=T;switch(Z){case"only":case"first":while(U=U.previousSibling){if(U.nodeType===1){return false}}if(Z=="first"){return true}U=T;case"last":while(U=U.nextSibling){if(U.nodeType===1){return false}}return true;case"nth":var V=W[2],ac=W[3];if(V==1&&ac==0){return true}var Y=W[0],ab=T.parentNode;if(ab&&(ab.sizcache!==Y||!T.nodeIndex)){var X=0;for(U=ab.firstChild;U;U=U.nextSibling){if(U.nodeType===1){U.nodeIndex=++X}}ab.sizcache=Y}var aa=T.nodeIndex-ac;if(V==0){return aa==0}else{return(aa%V==0&&aa/V>=0)}}},ID:function(U,T){return U.nodeType===1&&U.getAttribute("id")===T},TAG:function(U,T){return(T==="*"&&U.nodeType===1)||U.nodeName===T},CLASS:function(U,T){return(" "+(U.className||U.getAttribute("class"))+" ").indexOf(T)>-1},ATTR:function(Y,W){var V=W[1],T=I.attrHandle[V]?I.attrHandle[V](Y):Y[V]!=null?Y[V]:Y.getAttribute(V),Z=T+"",X=W[2],U=W[4];return T==null?X==="!=":X==="="?Z===U:X==="*="?Z.indexOf(U)>=0:X==="~="?(" "+Z+" ").indexOf(U)>=0:!U?Z&&T!==false:X==="!="?Z!=U:X==="^="?Z.indexOf(U)===0:X==="$="?Z.substr(Z.length-U.length)===U:X==="|="?Z===U||Z.substr(0,U.length+1)===U+"-":false},POS:function(X,U,V,Y){var T=U[2],W=I.setFilters[T];if(W){return W(X,V,U,Y)}}}};var M=I.match.POS;for(var O in I.match){I.match[O]=RegExp(I.match[O].source+/(?![^\[]*\])(?![^\(]*\))/.source)}var E=function(U,T){U=Array.prototype.slice.call(U);if(T){T.push.apply(T,U);return T}return U};try{Array.prototype.slice.call(document.documentElement.childNodes)}catch(N){E=function(X,W){var U=W||[];if(H.call(X)==="[object Array]"){Array.prototype.push.apply(U,X)}else{if(typeof X.length==="number"){for(var V=0,T=X.length;V<T;V++){U.push(X[V])}}else{for(var V=0;X[V];V++){U.push(X[V])}}}return U}}var G;if(document.documentElement.compareDocumentPosition){G=function(U,T){var V=U.compareDocumentPosition(T)&4?-1:U===T?0:1;if(V===0){hasDuplicate=true}return V}}else{if("sourceIndex" in document.documentElement){G=function(U,T){var V=U.sourceIndex-T.sourceIndex;if(V===0){hasDuplicate=true}return V}}else{if(document.createRange){G=function(W,U){var V=W.ownerDocument.createRange(),T=U.ownerDocument.createRange();V.selectNode(W);V.collapse(true);T.selectNode(U);T.collapse(true);var X=V.compareBoundaryPoints(Range.START_TO_END,T);if(X===0){hasDuplicate=true}return X}}}}(function(){var U=document.createElement("form"),V="script"+(new Date).getTime();U.innerHTML="<input name='"+V+"'/>";var T=document.documentElement;T.insertBefore(U,T.firstChild);if(!!document.getElementById(V)){I.find.ID=function(X,Y,Z){if(typeof Y.getElementById!=="undefined"&&!Z){var W=Y.getElementById(X[1]);return W?W.id===X[1]||typeof W.getAttributeNode!=="undefined"&&W.getAttributeNode("id").nodeValue===X[1]?[W]:g:[]}};I.filter.ID=function(Y,W){var X=typeof Y.getAttributeNode!=="undefined"&&Y.getAttributeNode("id");return Y.nodeType===1&&X&&X.nodeValue===W}}T.removeChild(U)})();(function(){var T=document.createElement("div");T.appendChild(document.createComment(""));if(T.getElementsByTagName("*").length>0){I.find.TAG=function(U,Y){var X=Y.getElementsByTagName(U[1]);if(U[1]==="*"){var W=[];for(var V=0;X[V];V++){if(X[V].nodeType===1){W.push(X[V])}}X=W}return X}}T.innerHTML="<a href='#'></a>";if(T.firstChild&&typeof T.firstChild.getAttribute!=="undefined"&&T.firstChild.getAttribute("href")!=="#"){I.attrHandle.href=function(U){return U.getAttribute("href",2)}}})();if(document.querySelectorAll){(function(){var T=F,U=document.createElement("div");U.innerHTML="<p class='TEST'></p>";if(U.querySelectorAll&&U.querySelectorAll(".TEST").length===0){return}F=function(Y,X,V,W){X=X||document;if(!W&&X.nodeType===9&&!Q(X)){try{return E(X.querySelectorAll(Y),V)}catch(Z){}}return T(Y,X,V,W)};F.find=T.find;F.filter=T.filter;F.selectors=T.selectors;F.matches=T.matches})()}if(document.getElementsByClassName&&document.documentElement.getElementsByClassName){(function(){var T=document.createElement("div");T.innerHTML="<div class='test e'></div><div class='test'></div>";if(T.getElementsByClassName("e").length===0){return}T.lastChild.className="e";if(T.getElementsByClassName("e").length===1){return}I.order.splice(1,0,"CLASS");I.find.CLASS=function(U,V,W){if(typeof V.getElementsByClassName!=="undefined"&&!W){return V.getElementsByClassName(U[1])}}})()}function P(U,Z,Y,ad,aa,ac){var ab=U=="previousSibling"&&!ac;for(var W=0,V=ad.length;W<V;W++){var T=ad[W];if(T){if(ab&&T.nodeType===1){T.sizcache=Y;T.sizset=W}T=T[U];var X=false;while(T){if(T.sizcache===Y){X=ad[T.sizset];break}if(T.nodeType===1&&!ac){T.sizcache=Y;T.sizset=W}if(T.nodeName===Z){X=T;break}T=T[U]}ad[W]=X}}}function S(U,Z,Y,ad,aa,ac){var ab=U=="previousSibling"&&!ac;for(var W=0,V=ad.length;W<V;W++){var T=ad[W];if(T){if(ab&&T.nodeType===1){T.sizcache=Y;T.sizset=W}T=T[U];var X=false;while(T){if(T.sizcache===Y){X=ad[T.sizset];break}if(T.nodeType===1){if(!ac){T.sizcache=Y;T.sizset=W}if(typeof Z!=="string"){if(T===Z){X=true;break}}else{if(F.filter(Z,[T]).length>0){X=T;break}}}T=T[U]}ad[W]=X}}}var K=document.compareDocumentPosition?function(U,T){return U.compareDocumentPosition(T)&16}:function(U,T){return U!==T&&(U.contains?U.contains(T):true)};var Q=function(T){return T.nodeType===9&&T.documentElement.nodeName!=="HTML"||!!T.ownerDocument&&Q(T.ownerDocument)};var J=function(T,aa){var W=[],X="",Y,V=aa.nodeType?[aa]:aa;while((Y=I.match.PSEUDO.exec(T))){X+=Y[0];T=T.replace(I.match.PSEUDO,"")}T=I.relative[T]?T+"*":T;for(var Z=0,U=V.length;Z<U;Z++){F(T,V[Z],W)}return F.filter(X,W)};o.find=F;o.filter=F.filter;o.expr=F.selectors;o.expr[":"]=o.expr.filters;F.selectors.filters.hidden=function(T){return T.offsetWidth===0||T.offsetHeight===0};F.selectors.filters.visible=function(T){return T.offsetWidth>0||T.offsetHeight>0};F.selectors.filters.animated=function(T){return o.grep(o.timers,function(U){return T===U.elem}).length};o.multiFilter=function(V,T,U){if(U){V=":not("+V+")"}return F.matches(V,T)};o.dir=function(V,U){var T=[],W=V[U];while(W&&W!=document){if(W.nodeType==1){T.push(W)}W=W[U]}return T};o.nth=function(X,T,V,W){T=T||1;var U=0;for(;X;X=X[V]){if(X.nodeType==1&&++U==T){break}}return X};o.sibling=function(V,U){var T=[];for(;V;V=V.nextSibling){if(V.nodeType==1&&V!=U){T.push(V)}}return T};return;l.Sizzle=F})();o.event={add:function(I,F,H,K){if(I.nodeType==3||I.nodeType==8){return}if(I.setInterval&&I!=l){I=l}if(!H.guid){H.guid=this.guid++}if(K!==g){var G=H;H=this.proxy(G);H.data=K}var E=o.data(I,"events")||o.data(I,"events",{}),J=o.data(I,"handle")||o.data(I,"handle",function(){return typeof o!=="undefined"&&!o.event.triggered?o.event.handle.apply(arguments.callee.elem,arguments):g});J.elem=I;o.each(F.split(/\s+/),function(M,N){var O=N.split(".");N=O.shift();H.type=O.slice().sort().join(".");var L=E[N];if(o.event.specialAll[N]){o.event.specialAll[N].setup.call(I,K,O)}if(!L){L=E[N]={};if(!o.event.special[N]||o.event.special[N].setup.call(I,K,O)===false){if(I.addEventListener){I.addEventListener(N,J,false)}else{if(I.attachEvent){I.attachEvent("on"+N,J)}}}}L[H.guid]=H;o.event.global[N]=true});I=null},guid:1,global:{},remove:function(K,H,J){if(K.nodeType==3||K.nodeType==8){return}var G=o.data(K,"events"),F,E;if(G){if(H===g||(typeof H==="string"&&H.charAt(0)==".")){for(var I in G){this.remove(K,I+(H||""))}}else{if(H.type){J=H.handler;H=H.type}o.each(H.split(/\s+/),function(M,O){var Q=O.split(".");O=Q.shift();var N=RegExp("(^|\\.)"+Q.slice().sort().join(".*\\.")+"(\\.|$)");if(G[O]){if(J){delete G[O][J.guid]}else{for(var P in G[O]){if(N.test(G[O][P].type)){delete G[O][P]}}}if(o.event.specialAll[O]){o.event.specialAll[O].teardown.call(K,Q)}for(F in G[O]){break}if(!F){if(!o.event.special[O]||o.event.special[O].teardown.call(K,Q)===false){if(K.removeEventListener){K.removeEventListener(O,o.data(K,"handle"),false)}else{if(K.detachEvent){K.detachEvent("on"+O,o.data(K,"handle"))}}}F=null;delete G[O]}}})}for(F in G){break}if(!F){var L=o.data(K,"handle");if(L){L.elem=null}o.removeData(K,"events");o.removeData(K,"handle")}}},trigger:function(I,K,H,E){var G=I.type||I;if(!E){I=typeof I==="object"?I[h]?I:o.extend(o.Event(G),I):o.Event(G);if(G.indexOf("!")>=0){I.type=G=G.slice(0,-1);I.exclusive=true}if(!H){I.stopPropagation();if(this.global[G]){o.each(o.cache,function(){if(this.events&&this.events[G]){o.event.trigger(I,K,this.handle.elem)}})}}if(!H||H.nodeType==3||H.nodeType==8){return g}I.result=g;I.target=H;K=o.makeArray(K);K.unshift(I)}I.currentTarget=H;var J=o.data(H,"handle");if(J){J.apply(H,K)}if((!H[G]||(o.nodeName(H,"a")&&G=="click"))&&H["on"+G]&&H["on"+G].apply(H,K)===false){I.result=false}if(!E&&H[G]&&!I.isDefaultPrevented()&&!(o.nodeName(H,"a")&&G=="click")){this.triggered=true;try{H[G]()}catch(L){}}this.triggered=false;if(!I.isPropagationStopped()){var F=H.parentNode||H.ownerDocument;if(F){o.event.trigger(I,K,F,true)}}},handle:function(K){var J,E;K=arguments[0]=o.event.fix(K||l.event);K.currentTarget=this;var L=K.type.split(".");K.type=L.shift();J=!L.length&&!K.exclusive;var I=RegExp("(^|\\.)"+L.slice().sort().join(".*\\.")+"(\\.|$)");E=(o.data(this,"events")||{})[K.type];for(var G in E){var H=E[G];if(J||I.test(H.type)){K.handler=H;K.data=H.data;var F=H.apply(this,arguments);if(F!==g){K.result=F;if(F===false){K.preventDefault();K.stopPropagation()}}if(K.isImmediatePropagationStopped()){break}}}},props:"altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode metaKey newValue originalTarget pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target toElement view wheelDelta which".split(" "),fix:function(H){if(H[h]){return H}var F=H;H=o.Event(F);for(var G=this.props.length,J;G;){J=this.props[--G];H[J]=F[J]}if(!H.target){H.target=H.srcElement||document}if(H.target.nodeType==3){H.target=H.target.parentNode}if(!H.relatedTarget&&H.fromElement){H.relatedTarget=H.fromElement==H.target?H.toElement:H.fromElement}if(H.pageX==null&&H.clientX!=null){var I=document.documentElement,E=document.body;H.pageX=H.clientX+(I&&I.scrollLeft||E&&E.scrollLeft||0)-(I.clientLeft||0);H.pageY=H.clientY+(I&&I.scrollTop||E&&E.scrollTop||0)-(I.clientTop||0)}if(!H.which&&((H.charCode||H.charCode===0)?H.charCode:H.keyCode)){H.which=H.charCode||H.keyCode}if(!H.metaKey&&H.ctrlKey){H.metaKey=H.ctrlKey}if(!H.which&&H.button){H.which=(H.button&1?1:(H.button&2?3:(H.button&4?2:0)))}return H},proxy:function(F,E){E=E||function(){return F.apply(this,arguments)};E.guid=F.guid=F.guid||E.guid||this.guid++;return E},special:{ready:{setup:B,teardown:function(){}}},specialAll:{live:{setup:function(E,F){o.event.add(this,F[0],c)},teardown:function(G){if(G.length){var E=0,F=RegExp("(^|\\.)"+G[0]+"(\\.|$)");o.each((o.data(this,"events").live||{}),function(){if(F.test(this.type)){E++}});if(E<1){o.event.remove(this,G[0],c)}}}}}};o.Event=function(E){if(!this.preventDefault){return new o.Event(E)}if(E&&E.type){this.originalEvent=E;this.type=E.type}else{this.type=E}this.timeStamp=e();this[h]=true};function k(){return false}function u(){return true}o.Event.prototype={preventDefault:function(){this.isDefaultPrevented=u;var E=this.originalEvent;if(!E){return}if(E.preventDefault){E.preventDefault()}E.returnValue=false},stopPropagation:function(){this.isPropagationStopped=u;var E=this.originalEvent;if(!E){return}if(E.stopPropagation){E.stopPropagation()}E.cancelBubble=true},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=u;this.stopPropagation()},isDefaultPrevented:k,isPropagationStopped:k,isImmediatePropagationStopped:k};var a=function(F){var E=F.relatedTarget;while(E&&E!=this){try{E=E.parentNode}catch(G){E=this}}if(E!=this){F.type=F.data;o.event.handle.apply(this,arguments)}};o.each({mouseover:"mouseenter",mouseout:"mouseleave"},function(F,E){o.event.special[E]={setup:function(){o.event.add(this,F,a,E)},teardown:function(){o.event.remove(this,F,a)}}});o.fn.extend({bind:function(F,G,E){return F=="unload"?this.one(F,G,E):this.each(function(){o.event.add(this,F,E||G,E&&G)})},one:function(G,H,F){var E=o.event.proxy(F||H,function(I){o(this).unbind(I,E);return(F||H).apply(this,arguments)});return this.each(function(){o.event.add(this,G,E,F&&H)})},unbind:function(F,E){return this.each(function(){o.event.remove(this,F,E)})},trigger:function(E,F){return this.each(function(){o.event.trigger(E,F,this)})},triggerHandler:function(E,G){if(this[0]){var F=o.Event(E);F.preventDefault();F.stopPropagation();o.event.trigger(F,G,this[0]);return F.result}},toggle:function(G){var E=arguments,F=1;while(F<E.length){o.event.proxy(G,E[F++])}return this.click(o.event.proxy(G,function(H){this.lastToggle=(this.lastToggle||0)%F;H.preventDefault();return E[this.lastToggle++].apply(this,arguments)||false}))},hover:function(E,F){return this.mouseenter(E).mouseleave(F)},ready:function(E){B();if(o.isReady){E.call(document,o)}else{o.readyList.push(E)}return this},live:function(G,F){var E=o.event.proxy(F);E.guid+=this.selector+G;o(document).bind(i(G,this.selector),this.selector,E);return this},die:function(F,E){o(document).unbind(i(F,this.selector),E?{guid:E.guid+this.selector+F}:null);return this}});function c(H){var E=RegExp("(^|\\.)"+H.type+"(\\.|$)"),G=true,F=[];o.each(o.data(this,"events").live||[],function(I,J){if(E.test(J.type)){var K=o(H.target).closest(J.data)[0];if(K){F.push({elem:K,fn:J})}}});F.sort(function(J,I){return o.data(J.elem,"closest")-o.data(I.elem,"closest")});o.each(F,function(){if(this.fn.call(this.elem,H,this.fn.data)===false){return(G=false)}});return G}function i(F,E){return["live",F,E.replace(/\./g,"`").replace(/ /g,"|")].join(".")}o.extend({isReady:false,readyList:[],ready:function(){if(!o.isReady){o.isReady=true;if(o.readyList){o.each(o.readyList,function(){this.call(document,o)});o.readyList=null}o(document).triggerHandler("ready")}}});var x=false;function B(){if(x){return}x=true;if(document.addEventListener){document.addEventListener("DOMContentLoaded",function(){document.removeEventListener("DOMContentLoaded",arguments.callee,false);o.ready()},false)}else{if(document.attachEvent){document.attachEvent("onreadystatechange",function(){if(document.readyState==="complete"){document.detachEvent("onreadystatechange",arguments.callee);o.ready()}});if(document.documentElement.doScroll&&l==l.top){(function(){if(o.isReady){return}try{document.documentElement.doScroll("left")}catch(E){setTimeout(arguments.callee,0);return}o.ready()})()}}}o.event.add(l,"load",o.ready)}o.each(("blur,focus,load,resize,scroll,unload,click,dblclick,mousedown,mouseup,mousemove,mouseover,mouseout,mouseenter,mouseleave,change,select,submit,keydown,keypress,keyup,error").split(","),function(F,E){o.fn[E]=function(G){return G?this.bind(E,G):this.trigger(E)}});o(l).bind("unload",function(){for(var E in o.cache){if(E!=1&&o.cache[E].handle){o.event.remove(o.cache[E].handle.elem)}}});(function(){o.support={};var F=document.documentElement,G=document.createElement("script"),K=document.createElement("div"),J="script"+(new Date).getTime();K.style.display="none";K.innerHTML='   <link/><table></table><a href="/a" style="color:red;float:left;opacity:.5;">a</a><select><option>text</option></select><object><param/></object>';var H=K.getElementsByTagName("*"),E=K.getElementsByTagName("a")[0];if(!H||!H.length||!E){return}o.support={leadingWhitespace:K.firstChild.nodeType==3,tbody:!K.getElementsByTagName("tbody").length,objectAll:!!K.getElementsByTagName("object")[0].getElementsByTagName("*").length,htmlSerialize:!!K.getElementsByTagName("link").length,style:/red/.test(E.getAttribute("style")),hrefNormalized:E.getAttribute("href")==="/a",opacity:E.style.opacity==="0.5",cssFloat:!!E.style.cssFloat,scriptEval:false,noCloneEvent:true,boxModel:null};G.type="text/javascript";try{G.appendChild(document.createTextNode("window."+J+"=1;"))}catch(I){}F.insertBefore(G,F.firstChild);if(l[J]){o.support.scriptEval=true;delete l[J]}F.removeChild(G);if(K.attachEvent&&K.fireEvent){K.attachEvent("onclick",function(){o.support.noCloneEvent=false;K.detachEvent("onclick",arguments.callee)});K.cloneNode(true).fireEvent("onclick")}o(function(){var L=document.createElement("div");L.style.width=L.style.paddingLeft="1px";document.body.appendChild(L);o.boxModel=o.support.boxModel=L.offsetWidth===2;document.body.removeChild(L).style.display="none"})})();var w=o.support.cssFloat?"cssFloat":"styleFloat";o.props={"for":"htmlFor","class":"className","float":w,cssFloat:w,styleFloat:w,readonly:"readOnly",maxlength:"maxLength",cellspacing:"cellSpacing",rowspan:"rowSpan",tabindex:"tabIndex"};o.fn.extend({_load:o.fn.load,load:function(G,J,K){if(typeof G!=="string"){return this._load(G)}var I=G.indexOf(" ");if(I>=0){var E=G.slice(I,G.length);G=G.slice(0,I)}var H="GET";if(J){if(o.isFunction(J)){K=J;J=null}else{if(typeof J==="object"){J=o.param(J);H="POST"}}}var F=this;o.ajax({url:G,type:H,dataType:"html",data:J,complete:function(M,L){if(L=="success"||L=="notmodified"){F.html(E?o("<div/>").append(M.responseText.replace(/<script(.|\s)*?\/script>/g,"")).find(E):M.responseText)}if(K){F.each(K,[M.responseText,L,M])}}});return this},serialize:function(){return o.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?o.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||/select|textarea/i.test(this.nodeName)||/text|hidden|password|search/i.test(this.type))}).map(function(E,F){var G=o(this).val();return G==null?null:o.isArray(G)?o.map(G,function(I,H){return{name:F.name,value:I}}):{name:F.name,value:G}}).get()}});o.each("ajaxStart,ajaxStop,ajaxComplete,ajaxError,ajaxSuccess,ajaxSend".split(","),function(E,F){o.fn[F]=function(G){return this.bind(F,G)}});var r=e();o.extend({get:function(E,G,H,F){if(o.isFunction(G)){H=G;G=null}return o.ajax({type:"GET",url:E,data:G,success:H,dataType:F})},getScript:function(E,F){return o.get(E,null,F,"script")},getJSON:function(E,F,G){return o.get(E,F,G,"json")},post:function(E,G,H,F){if(o.isFunction(G)){H=G;G={}}return o.ajax({type:"POST",url:E,data:G,success:H,dataType:F})},ajaxSetup:function(E){o.extend(o.ajaxSettings,E)},ajaxSettings:{url:location.href,global:true,type:"GET",contentType:"application/x-www-form-urlencoded",processData:true,async:true,xhr:function(){return l.ActiveXObject?new ActiveXObject("Microsoft.XMLHTTP"):new XMLHttpRequest()},accepts:{xml:"application/xml, text/xml",html:"text/html",script:"text/javascript, application/javascript",json:"application/json, text/javascript",text:"text/plain",_default:"*/*"}},lastModified:{},ajax:function(M){M=o.extend(true,M,o.extend(true,{},o.ajaxSettings,M));var W,F=/=\?(&|$)/g,R,V,G=M.type.toUpperCase();if(M.data&&M.processData&&typeof M.data!=="string"){M.data=o.param(M.data)}if(M.dataType=="jsonp"){if(G=="GET"){if(!M.url.match(F)){M.url+=(M.url.match(/\?/)?"&":"?")+(M.jsonp||"callback")+"=?"}}else{if(!M.data||!M.data.match(F)){M.data=(M.data?M.data+"&":"")+(M.jsonp||"callback")+"=?"}}M.dataType="json"}if(M.dataType=="json"&&(M.data&&M.data.match(F)||M.url.match(F))){W="jsonp"+r++;if(M.data){M.data=(M.data+"").replace(F,"="+W+"$1")}M.url=M.url.replace(F,"="+W+"$1");M.dataType="script";l[W]=function(X){V=X;I();L();l[W]=g;try{delete l[W]}catch(Y){}if(H){H.removeChild(T)}}}if(M.dataType=="script"&&M.cache==null){M.cache=false}if(M.cache===false&&G=="GET"){var E=e();var U=M.url.replace(/(\?|&)_=.*?(&|$)/,"$1_="+E+"$2");M.url=U+((U==M.url)?(M.url.match(/\?/)?"&":"?")+"_="+E:"")}if(M.data&&G=="GET"){M.url+=(M.url.match(/\?/)?"&":"?")+M.data;M.data=null}if(M.global&&!o.active++){o.event.trigger("ajaxStart")}var Q=/^(\w+:)?\/\/([^\/?#]+)/.exec(M.url);if(M.dataType=="script"&&G=="GET"&&Q&&(Q[1]&&Q[1]!=location.protocol||Q[2]!=location.host)){var H=document.getElementsByTagName("head")[0];var T=document.createElement("script");T.src=M.url;if(M.scriptCharset){T.charset=M.scriptCharset}if(!W){var O=false;T.onload=T.onreadystatechange=function(){if(!O&&(!this.readyState||this.readyState=="loaded"||this.readyState=="complete")){O=true;I();L();T.onload=T.onreadystatechange=null;H.removeChild(T)}}}H.appendChild(T);return g}var K=false;var J=M.xhr();if(M.username){J.open(G,M.url,M.async,M.username,M.password)}else{J.open(G,M.url,M.async)}try{if(M.data){J.setRequestHeader("Content-Type",M.contentType)}if(M.ifModified){J.setRequestHeader("If-Modified-Since",o.lastModified[M.url]||"Thu, 01 Jan 1970 00:00:00 GMT")}J.setRequestHeader("X-Requested-With","XMLHttpRequest");J.setRequestHeader("Accept",M.dataType&&M.accepts[M.dataType]?M.accepts[M.dataType]+", */*":M.accepts._default)}catch(S){}if(M.beforeSend&&M.beforeSend(J,M)===false){if(M.global&&!--o.active){o.event.trigger("ajaxStop")}J.abort();return false}if(M.global){o.event.trigger("ajaxSend",[J,M])}var N=function(X){if(J.readyState==0){if(P){clearInterval(P);P=null;if(M.global&&!--o.active){o.event.trigger("ajaxStop")}}}else{if(!K&&J&&(J.readyState==4||X=="timeout")){K=true;if(P){clearInterval(P);P=null}R=X=="timeout"?"timeout":!o.httpSuccess(J)?"error":M.ifModified&&o.httpNotModified(J,M.url)?"notmodified":"success";if(R=="success"){try{V=o.httpData(J,M.dataType,M)}catch(Z){R="parsererror"}}if(R=="success"){var Y;try{Y=J.getResponseHeader("Last-Modified")}catch(Z){}if(M.ifModified&&Y){o.lastModified[M.url]=Y}if(!W){I()}}else{o.handleError(M,J,R)}L();if(X){J.abort()}if(M.async){J=null}}}};if(M.async){var P=setInterval(N,13);if(M.timeout>0){setTimeout(function(){if(J&&!K){N("timeout")}},M.timeout)}}try{J.send(M.data)}catch(S){o.handleError(M,J,null,S)}if(!M.async){N()}function I(){if(M.success){M.success(V,R)}if(M.global){o.event.trigger("ajaxSuccess",[J,M])}}function L(){if(M.complete){M.complete(J,R)}if(M.global){o.event.trigger("ajaxComplete",[J,M])}if(M.global&&!--o.active){o.event.trigger("ajaxStop")}}return J},handleError:function(F,H,E,G){if(F.error){F.error(H,E,G)}if(F.global){o.event.trigger("ajaxError",[H,F,G])}},active:0,httpSuccess:function(F){try{return !F.status&&location.protocol=="file:"||(F.status>=200&&F.status<300)||F.status==304||F.status==1223}catch(E){}return false},httpNotModified:function(G,E){try{var H=G.getResponseHeader("Last-Modified");return G.status==304||H==o.lastModified[E]}catch(F){}return false},httpData:function(J,H,G){var F=J.getResponseHeader("content-type"),E=H=="xml"||!H&&F&&F.indexOf("xml")>=0,I=E?J.responseXML:J.responseText;if(E&&I.documentElement.tagName=="parsererror"){throw"parsererror"}if(G&&G.dataFilter){I=G.dataFilter(I,H)}if(typeof I==="string"){if(H=="script"){o.globalEval(I)}if(H=="json"){I=l["eval"]("("+I+")")}}return I},param:function(E){var G=[];function H(I,J){G[G.length]=encodeURIComponent(I)+"="+encodeURIComponent(J)}if(o.isArray(E)||E.jquery){o.each(E,function(){H(this.name,this.value)})}else{for(var F in E){if(o.isArray(E[F])){o.each(E[F],function(){H(F,this)})}else{H(F,o.isFunction(E[F])?E[F]():E[F])}}}return G.join("&").replace(/%20/g,"+")}});var m={},n,d=[["height","marginTop","marginBottom","paddingTop","paddingBottom"],["width","marginLeft","marginRight","paddingLeft","paddingRight"],["opacity"]];function t(F,E){var G={};o.each(d.concat.apply([],d.slice(0,E)),function(){G[this]=F});return G}o.fn.extend({show:function(J,L){if(J){return this.animate(t("show",3),J,L)}else{for(var H=0,F=this.length;H<F;H++){var E=o.data(this[H],"olddisplay");this[H].style.display=E||"";if(o.css(this[H],"display")==="none"){var G=this[H].tagName,K;if(m[G]){K=m[G]}else{var I=o("<"+G+" />").appendTo("body");K=I.css("display");if(K==="none"){K="block"}I.remove();m[G]=K}o.data(this[H],"olddisplay",K)}}for(var H=0,F=this.length;H<F;H++){this[H].style.display=o.data(this[H],"olddisplay")||""}return this}},hide:function(H,I){if(H){return this.animate(t("hide",3),H,I)}else{for(var G=0,F=this.length;G<F;G++){var E=o.data(this[G],"olddisplay");if(!E&&E!=="none"){o.data(this[G],"olddisplay",o.css(this[G],"display"))}}for(var G=0,F=this.length;G<F;G++){this[G].style.display="none"}return this}},_toggle:o.fn.toggle,toggle:function(G,F){var E=typeof G==="boolean";return o.isFunction(G)&&o.isFunction(F)?this._toggle.apply(this,arguments):G==null||E?this.each(function(){var H=E?G:o(this).is(":hidden");o(this)[H?"show":"hide"]()}):this.animate(t("toggle",3),G,F)},fadeTo:function(E,G,F){return this.animate({opacity:G},E,F)},animate:function(I,F,H,G){var E=o.speed(F,H,G);return this[E.queue===false?"each":"queue"](function(){var K=o.extend({},E),M,L=this.nodeType==1&&o(this).is(":hidden"),J=this;for(M in I){if(I[M]=="hide"&&L||I[M]=="show"&&!L){return K.complete.call(this)}if((M=="height"||M=="width")&&this.style){K.display=o.css(this,"display");K.overflow=this.style.overflow}}if(K.overflow!=null){this.style.overflow="hidden"}K.curAnim=o.extend({},I);o.each(I,function(O,S){var R=new o.fx(J,K,O);if(/toggle|show|hide/.test(S)){R[S=="toggle"?L?"show":"hide":S](I)}else{var Q=S.toString().match(/^([+-]=)?([\d+-.]+)(.*)$/),T=R.cur(true)||0;if(Q){var N=parseFloat(Q[2]),P=Q[3]||"px";if(P!="px"){J.style[O]=(N||1)+P;T=((N||1)/R.cur(true))*T;J.style[O]=T+P}if(Q[1]){N=((Q[1]=="-="?-1:1)*N)+T}R.custom(T,N,P)}else{R.custom(T,S,"")}}});return true})},stop:function(F,E){var G=o.timers;if(F){this.queue([])}this.each(function(){for(var H=G.length-1;H>=0;H--){if(G[H].elem==this){if(E){G[H](true)}G.splice(H,1)}}});if(!E){this.dequeue()}return this}});o.each({slideDown:t("show",1),slideUp:t("hide",1),slideToggle:t("toggle",1),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"}},function(E,F){o.fn[E]=function(G,H){return this.animate(F,G,H)}});o.extend({speed:function(G,H,F){var E=typeof G==="object"?G:{complete:F||!F&&H||o.isFunction(G)&&G,duration:G,easing:F&&H||H&&!o.isFunction(H)&&H};E.duration=o.fx.off?0:typeof E.duration==="number"?E.duration:o.fx.speeds[E.duration]||o.fx.speeds._default;E.old=E.complete;E.complete=function(){if(E.queue!==false){o(this).dequeue()}if(o.isFunction(E.old)){E.old.call(this)}};return E},easing:{linear:function(G,H,E,F){return E+F*G},swing:function(G,H,E,F){return((-Math.cos(G*Math.PI)/2)+0.5)*F+E}},timers:[],fx:function(F,E,G){this.options=E;this.elem=F;this.prop=G;if(!E.orig){E.orig={}}}});o.fx.prototype={update:function(){if(this.options.step){this.options.step.call(this.elem,this.now,this)}(o.fx.step[this.prop]||o.fx.step._default)(this);if((this.prop=="height"||this.prop=="width")&&this.elem.style){this.elem.style.display="block"}},cur:function(F){if(this.elem[this.prop]!=null&&(!this.elem.style||this.elem.style[this.prop]==null)){return this.elem[this.prop]}var E=parseFloat(o.css(this.elem,this.prop,F));return E&&E>-10000?E:parseFloat(o.curCSS(this.elem,this.prop))||0},custom:function(I,H,G){this.startTime=e();this.start=I;this.end=H;this.unit=G||this.unit||"px";this.now=this.start;this.pos=this.state=0;var E=this;function F(J){return E.step(J)}F.elem=this.elem;if(F()&&o.timers.push(F)&&!n){n=setInterval(function(){var K=o.timers;for(var J=0;J<K.length;J++){if(!K[J]()){K.splice(J--,1)}}if(!K.length){clearInterval(n);n=g}},13)}},show:function(){this.options.orig[this.prop]=o.attr(this.elem.style,this.prop);this.options.show=true;this.custom(this.prop=="width"||this.prop=="height"?1:0,this.cur());o(this.elem).show()},hide:function(){this.options.orig[this.prop]=o.attr(this.elem.style,this.prop);this.options.hide=true;this.custom(this.cur(),0)},step:function(H){var G=e();if(H||G>=this.options.duration+this.startTime){this.now=this.end;this.pos=this.state=1;this.update();this.options.curAnim[this.prop]=true;var E=true;for(var F in this.options.curAnim){if(this.options.curAnim[F]!==true){E=false}}if(E){if(this.options.display!=null){this.elem.style.overflow=this.options.overflow;this.elem.style.display=this.options.display;if(o.css(this.elem,"display")=="none"){this.elem.style.display="block"}}if(this.options.hide){o(this.elem).hide()}if(this.options.hide||this.options.show){for(var I in this.options.curAnim){o.attr(this.elem.style,I,this.options.orig[I])}}this.options.complete.call(this.elem)}return false}else{var J=G-this.startTime;this.state=J/this.options.duration;this.pos=o.easing[this.options.easing||(o.easing.swing?"swing":"linear")](this.state,J,0,1,this.options.duration);this.now=this.start+((this.end-this.start)*this.pos);this.update()}return true}};o.extend(o.fx,{speeds:{slow:600,fast:200,_default:400},step:{opacity:function(E){o.attr(E.elem.style,"opacity",E.now)},_default:function(E){if(E.elem.style&&E.elem.style[E.prop]!=null){E.elem.style[E.prop]=E.now+E.unit}else{E.elem[E.prop]=E.now}}}});if(document.documentElement.getBoundingClientRect){o.fn.offset=function(){if(!this[0]){return{top:0,left:0}}if(this[0]===this[0].ownerDocument.body){return o.offset.bodyOffset(this[0])}var G=this[0].getBoundingClientRect(),J=this[0].ownerDocument,F=J.body,E=J.documentElement,L=E.clientTop||F.clientTop||0,K=E.clientLeft||F.clientLeft||0,I=G.top+(self.pageYOffset||o.boxModel&&E.scrollTop||F.scrollTop)-L,H=G.left+(self.pageXOffset||o.boxModel&&E.scrollLeft||F.scrollLeft)-K;return{top:I,left:H}}}else{o.fn.offset=function(){if(!this[0]){return{top:0,left:0}}if(this[0]===this[0].ownerDocument.body){return o.offset.bodyOffset(this[0])}o.offset.initialized||o.offset.initialize();var J=this[0],G=J.offsetParent,F=J,O=J.ownerDocument,M,H=O.documentElement,K=O.body,L=O.defaultView,E=L.getComputedStyle(J,null),N=J.offsetTop,I=J.offsetLeft;while((J=J.parentNode)&&J!==K&&J!==H){M=L.getComputedStyle(J,null);N-=J.scrollTop,I-=J.scrollLeft;if(J===G){N+=J.offsetTop,I+=J.offsetLeft;if(o.offset.doesNotAddBorder&&!(o.offset.doesAddBorderForTableAndCells&&/^t(able|d|h)$/i.test(J.tagName))){N+=parseInt(M.borderTopWidth,10)||0,I+=parseInt(M.borderLeftWidth,10)||0}F=G,G=J.offsetParent}if(o.offset.subtractsBorderForOverflowNotVisible&&M.overflow!=="visible"){N+=parseInt(M.borderTopWidth,10)||0,I+=parseInt(M.borderLeftWidth,10)||0}E=M}if(E.position==="relative"||E.position==="static"){N+=K.offsetTop,I+=K.offsetLeft}if(E.position==="fixed"){N+=Math.max(H.scrollTop,K.scrollTop),I+=Math.max(H.scrollLeft,K.scrollLeft)}return{top:N,left:I}}}o.offset={initialize:function(){if(this.initialized){return}var L=document.body,F=document.createElement("div"),H,G,N,I,M,E,J=L.style.marginTop,K='<div style="position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;"><div></div></div><table style="position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;" cellpadding="0" cellspacing="0"><tr><td></td></tr></table>';M={position:"absolute",top:0,left:0,margin:0,border:0,width:"1px",height:"1px",visibility:"hidden"};for(E in M){F.style[E]=M[E]}F.innerHTML=K;L.insertBefore(F,L.firstChild);H=F.firstChild,G=H.firstChild,I=H.nextSibling.firstChild.firstChild;this.doesNotAddBorder=(G.offsetTop!==5);this.doesAddBorderForTableAndCells=(I.offsetTop===5);H.style.overflow="hidden",H.style.position="relative";this.subtractsBorderForOverflowNotVisible=(G.offsetTop===-5);L.style.marginTop="1px";this.doesNotIncludeMarginInBodyOffset=(L.offsetTop===0);L.style.marginTop=J;L.removeChild(F);this.initialized=true},bodyOffset:function(E){o.offset.initialized||o.offset.initialize();var G=E.offsetTop,F=E.offsetLeft;if(o.offset.doesNotIncludeMarginInBodyOffset){G+=parseInt(o.curCSS(E,"marginTop",true),10)||0,F+=parseInt(o.curCSS(E,"marginLeft",true),10)||0}return{top:G,left:F}}};o.fn.extend({position:function(){var I=0,H=0,F;if(this[0]){var G=this.offsetParent(),J=this.offset(),E=/^body|html$/i.test(G[0].tagName)?{top:0,left:0}:G.offset();J.top-=j(this,"marginTop");J.left-=j(this,"marginLeft");E.top+=j(G,"borderTopWidth");E.left+=j(G,"borderLeftWidth");F={top:J.top-E.top,left:J.left-E.left}}return F},offsetParent:function(){var E=this[0].offsetParent||document.body;while(E&&(!/^body|html$/i.test(E.tagName)&&o.css(E,"position")=="static")){E=E.offsetParent}return o(E)}});o.each(["Left","Top"],function(F,E){var G="scroll"+E;o.fn[G]=function(H){if(!this[0]){return null}return H!==g?this.each(function(){this==l||this==document?l.scrollTo(!F?H:o(l).scrollLeft(),F?H:o(l).scrollTop()):this[G]=H}):this[0]==l||this[0]==document?self[F?"pageYOffset":"pageXOffset"]||o.boxModel&&document.documentElement[G]||document.body[G]:this[0][G]}});o.each(["Height","Width"],function(I,G){var E=I?"Left":"Top",H=I?"Right":"Bottom",F=G.toLowerCase();o.fn["inner"+G]=function(){return this[0]?o.css(this[0],F,false,"padding"):null};o.fn["outer"+G]=function(K){return this[0]?o.css(this[0],F,false,K?"margin":"border"):null};var J=G.toLowerCase();o.fn[J]=function(K){return this[0]==l?document.compatMode=="CSS1Compat"&&document.documentElement["client"+G]||document.body["client"+G]:this[0]==document?Math.max(document.documentElement["client"+G],document.body["scroll"+G],document.documentElement["scroll"+G],document.body["offset"+G],document.documentElement["offset"+G]):K===g?(this.length?o.css(this[0],J):null):this.css(J,typeof K==="string"?K:K+"px")}})})();


(function($){$.toJSON=function(o)
{if(typeof(JSON)=='object'&&JSON.stringify)
return JSON.stringify(o);var type=typeof(o);if(o===null)
return"null";if(type=="undefined")
return undefined;if(type=="number"||type=="boolean")
return o+"";if(type=="string")
return $.quoteString(o);if(type=='object')
{if(typeof o.toJSON=="function")
return $.toJSON(o.toJSON());if(o.constructor===Date)
{var month=o.getUTCMonth()+1;if(month<10)month='0'+month;var day=o.getUTCDate();if(day<10)day='0'+day;var year=o.getUTCFullYear();var hours=o.getUTCHours();if(hours<10)hours='0'+hours;var minutes=o.getUTCMinutes();if(minutes<10)minutes='0'+minutes;var seconds=o.getUTCSeconds();if(seconds<10)seconds='0'+seconds;var milli=o.getUTCMilliseconds();if(milli<100)milli='0'+milli;if(milli<10)milli='0'+milli;return'"'+year+'-'+month+'-'+day+'T'+
hours+':'+minutes+':'+seconds+'.'+milli+'Z"';}
if(o.constructor===Array)
{var ret=[];for(var i=0;i<o.length;i++)
ret.push($.toJSON(o[i])||"null");return"["+ret.join(",")+"]";}
var pairs=[];for(var k in o){var name;var type=typeof k;if(type=="number")
name='"'+k+'"';else if(type=="string")
name=$.quoteString(k);else
continue;if(typeof o[k]=="function")
continue;var val=$.toJSON(o[k]);pairs.push(name+":"+val);}
return"{"+pairs.join(", ")+"}";}};$.evalJSON=function(src)
{if(typeof(JSON)=='object'&&JSON.parse)
return JSON.parse(src);return eval("("+src+")");};$.secureEvalJSON=function(src)
{if(typeof(JSON)=='object'&&JSON.parse)
return JSON.parse(src);var filtered=src;filtered=filtered.replace(/\\["\\\/bfnrtu]/g,'@');filtered=filtered.replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,']');filtered=filtered.replace(/(?:^|:|,)(?:\s*\[)+/g,'');if(/^[\],:{}\s]*$/.test(filtered))
return eval("("+src+")");else
throw new SyntaxError("Error parsing JSON, source is not valid.");};$.quoteString=function(string)
{if(string.match(_escapeable))
{return'"'+string.replace(_escapeable,function(a)
{var c=_meta[a];if(typeof c==='string')return c;c=a.charCodeAt();return'\\u00'+Math.floor(c/16).toString(16)+(c%16).toString(16);})+'"';}
return'"'+string+'"';};var _escapeable=/["\\\x00-\x1f\x7f-\x9f]/g;var _meta={'\b':'\\b','\t':'\\t','\n':'\\n','\f':'\\f','\r':'\\r','"':'\\"','\\':'\\\\'};})(jQuery);


(function($){
$.fn.jqDrag=function(h, opt){return i(this,h,'d', opt);};
$.fn.jqResize=function(h, opt){return i(this,h,'r', opt);};
$.jqDnR={dnr:{},e:0,opt:null,
drag:function(v){
 if(M.k == 'd'){
	var left = M.X+v.pageX-M.pX,
		top = M.Y+v.pageY-M.pY;
	if(OPT != null){
		if(OPT.lock == 'x'){
			left = M.X;
		}else if(OPT.lock == 'y'){
			top = M.Y;
		}
		
		if(OPT.containment){
			var c = $(OPT.containment);

			var offset = c.offset();
			var _left = parseInt(offset.left), _top = parseInt(offset.top);
			
			if(E.offset().left < _left){
				left = _left;
			}
			if(E.offset().top < _top){
				top = offset.top;
			}
			if(left + M.W > _left + c.width()){
				left = _left + c.width() - M.W;
			}
			if(top + M.H > _top + c.height()){
				top = _top + c.height() - M.H;
			}
		}
		
		if(OPT.dragging) OPT.dragging(v, E);
	}
	E.css({left:left, top:top});
	
 }else{
	var width = Math.max(v.pageX-M.pX+M.W, 0),
		height = Math.max(v.pageY-M.pY+M.H, 0);
	
	if(OPT != null){
		if(OPT.containment){
			var c = $(OPT.containment);
			
			if(M.X + width > c.offset().left + c.width()){
				width = c.offset().left + c.width() - M.X;
			}
			if(M.Y + height > c.offset().top + c.height()){
				height = c.offset().top + c.height() - M.Y;
			}
		}
		
		if(OPT.resizing) OPT.resizing(v, E);
	}
	E.css({width: width, height: height});
 }
  return false;
},
stop:function(v){/*E.css('opacity',M.o);*/ if(OPT != null && OPT.stop)OPT.stop(v, E); $().unbind('mousemove',J.drag).unbind('mouseup',J.stop);}
};

var J=$.jqDnR,M=J.dnr,E=J.e,OPT=J.opt,
i=function(e,h,k, opt){
 return e.each(function(){h=(h)?$(h,e):e;
 
 h.bind('mousedown',{e:e,k:k},function(v){var d=v.data,p={};E=d.e;OPT=opt?opt:null;
  if(OPT != null && OPT.drag)OPT.drag(v, E);
 // attempt utilization of dimensions plugin to fix IE issues
 if(E.css('position') != 'relative'){try{E.position(p);if(d.k=='d')E.css({left: E.offset().left +'px', top: E.offset().top +'px'});}catch(e){}}
 M={X:p.left||f('left')||0,Y:p.top||f('top')||0,W:f('width')||E[0].scrollWidth||0,H:f('height')||E[0].scrollHeight||0,pX:v.pageX,pY:v.pageY,k:d.k/*,o:E.css('opacity');*/};
 /*E.css({opacity:0.8});*/$().mousemove($.jqDnR.drag).mouseup($.jqDnR.stop);
 return false;
 });
 
 });
},

f=function(k){return parseInt(E.css(k))||false;};
})(jQuery);


//enabled tab key on textarea
(function($){
$.fn.textarea_tab = function(){
	$(this).keydown(function(e){
		
		if(e.keyCode != 9) return;
		
		if(this.createTextRange){
			//ie
			this.InsertPosition = document.selection.createRange().duplicate();
			this.InsertPosition.text = '\t';
			
			e.returnValue = false;
			
		}else{
			var pos = this.scrollTop;
			var ss = this.selectionStart;
			var es = this.selectionEnd;
			var t = '\t';
			
			this.value = this.value.substring(0, ss) + t + this.value.substring(ss);
			this.focus();
			this.setSelectionRange(ss + t.length, ss + t.length);
			this.scrollTop = pos;
		}
		
		return false;
	});
};
})(jQuery);



















function utf8_decode(str_data){var tmp_arr=[],i=0,ac=0,c1=0,c2=0,c3=0;str_data+='';while(i<str_data.length){c1=str_data.charCodeAt(i);if(c1<128){tmp_arr[ac++]=String.fromCharCode(c1);i++;}else if((c1>191)&&(c1<224)){c2=str_data.charCodeAt(i+1);tmp_arr[ac++]=String.fromCharCode(((c1&31)<<6)|(c2&63));i+=2;}else{c2=str_data.charCodeAt(i+1);c3=str_data.charCodeAt(i+2);tmp_arr[ac++]=String.fromCharCode(((c1&15)<<12)|((c2&63)<<6)|(c3&63));i+=3;}}
return tmp_arr.join('');}

function utf8_encode(argString){var string=(argString+'');var utftext="";var start,end;var stringl=0;start=end=0;stringl=string.length;for(var n=0;n<stringl;n++){var c1=string.charCodeAt(n);var enc=null;if(c1<128){end++;}else if(c1>127&&c1<2048){enc=String.fromCharCode((c1>>6)|192)+String.fromCharCode((c1&63)|128);}else{enc=String.fromCharCode((c1>>12)|224)+String.fromCharCode(((c1>>6)&63)|128)+String.fromCharCode((c1&63)|128);}
if(enc!==null){if(end>start){utftext+=string.substring(start,end);}
utftext+=enc;start=end=n+1;}}
if(end>start){utftext+=string.substring(start,string.length);}
return utftext;}

function base64_encode(data){var b64="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";var o1,o2,o3,h1,h2,h3,h4,bits,i=0,ac=0,enc="",tmp_arr=[];if(!data){return data;}
data=utf8_encode(data+'');do{o1=data.charCodeAt(i++);o2=data.charCodeAt(i++);o3=data.charCodeAt(i++);bits=o1<<16|o2<<8|o3;h1=bits>>18&0x3f;h2=bits>>12&0x3f;h3=bits>>6&0x3f;h4=bits&0x3f;tmp_arr[ac++]=b64.charAt(h1)+b64.charAt(h2)+b64.charAt(h3)+b64.charAt(h4);}while(i<data.length);enc=tmp_arr.join('');switch(data.length%3){case 1:enc=enc.slice(0,-2)+'==';break;case 2:enc=enc.slice(0,-1)+'=';break;}
return enc;}

function base64_decode(data){var b64="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";var o1,o2,o3,h1,h2,h3,h4,bits,i=0,ac=0,dec="",tmp_arr=[];if(!data){return data;}
data+='';do{h1=b64.indexOf(data.charAt(i++));h2=b64.indexOf(data.charAt(i++));h3=b64.indexOf(data.charAt(i++));h4=b64.indexOf(data.charAt(i++));bits=h1<<18|h2<<12|h3<<6|h4;o1=bits>>16&0xff;o2=bits>>8&0xff;o3=bits&0xff;if(h3==64){tmp_arr[ac++]=String.fromCharCode(o1);}else if(h4==64){tmp_arr[ac++]=String.fromCharCode(o1,o2);}else{tmp_arr[ac++]=String.fromCharCode(o1,o2,o3);}}while(i<data.length);dec=tmp_arr.join('');dec=utf8_decode(dec);return dec;}

function date(format,timestamp){var that=this,jsdate=((timestamp===undefined)?new Date():(typeof(timestamp)==='object')?new Date(timestamp):new Date(timestamp*1000)),formatChr=/\\?([a-z])/gi,formatChrCb=function(t,s){return f[t]?f[t]():s;},_pad=function(n,c){if((n=n+"").length<c){return new Array((++c)-n.length).join("0")+n;}else{return n;}},txt_words=["Sun","Mon","Tues","Wednes","Thurs","Fri","Satur","January","February","March","April","May","June","July","August","September","October","November","December"],txt_ordin={1:"st",2:"nd",3:"rd",21:"st",22:"nd",23:"rd",31:"st"},f={d:function(){return _pad(f.j(),2);},D:function(){return f.l().substr(0,3);},j:function(){return jsdate.getDate();},l:function(){return txt_words[f.w()]+'day';},N:function(){return f.w()||7;},S:function(){return txt_ordin[f.j()]||'th';},w:function(){return jsdate.getDay();},z:function(){return(jsdate-new Date(jsdate.getFullYear(),0,1))/864e5>>0;},W:function(){var c;return 1+Math.round(((c=new Date(f.Y(),f.n()-1,f.j()-f.N()+3))-(new Date(c.getFullYear(),0,4)))/864e5/7);},F:function(){return txt_words[6+f.n()];},m:function(){return _pad(f.n(),2);},M:function(){return f.F().substr(0,3);},n:function(){return jsdate.getMonth()+1;},t:function(){return(new Date(f.Y(),f.n()+1,0)).getDate();},L:function(){var y=f.Y();return(!(y&3)&&(y%1e2||!(y%4e2)))?1:0;},o:function(){return f.Y()+(f.n()===12&&f.W()<9?-1:(f.n()===1&&f.W()>9?1:0));},Y:function(){return jsdate.getFullYear();},y:function(){return(jsdate.getFullYear()+"").slice(2);},a:function(){return jsdate.getHours()>11?"pm":"am";},A:function(){return f.a().toUpperCase();},B:function(){return _pad(Math.floor(((jsdate.getUTCHours()*36e2)+(jsdate.getUTCMinutes()*60)+
jsdate.getUTCSeconds()+36e2)/86.4)%1e3,3);},g:function(){return jsdate.getHours()%12||12;},G:function(){return jsdate.getHours();},h:function(){return _pad(f.g(),2);},H:function(){return _pad(f.G(),2);},i:function(){return _pad(jsdate.getMinutes(),2);},s:function(){return _pad(jsdate.getSeconds(),2);},u:function(){return _pad(jsdate.getMilliseconds()*1000,6);},e:function(){return'UTC';},I:function(){return 0+(jsdate.getTimezoneOffset()<Math.max((new Date(f.Y(),0,1)).getTimezoneOffset(),(new Date(f.Y(),6,1)).getTimezoneOffset()));},O:function(){return((jsdate.getTimezoneOffset()>0)?"-":"+")+_pad(Math.abs(jsdate.getTimezoneOffset()/60*100),4);},P:function(){var O=f.O();return(O.substr(0,3)+":"+O.substr(3,2));},T:function(){return'UTC';},Z:function(){return-jsdate.getTimezoneOffset()*60;},c:function(){return'Y-m-d\\Th:i:sP'.replace(formatChr,formatChrCb);},r:function(){return'D, d M Y H:i:s O'.replace(formatChr,formatChrCb);},U:function(){return Math.round(jsdate.getTime()/1000);}};return format.replace(formatChr,formatChrCb);}

function mktime(){var no=0,i=0,ma=0,mb=0,d=new Date(),dn=new Date(),argv=arguments,argc=argv.length;var dateManip={0:function(tt){return d.setHours(tt);},1:function(tt){return d.setMinutes(tt);},2:function(tt){var set=d.setSeconds(tt);mb=d.getDate()-dn.getDate();d.setDate(1);return set;},3:function(tt){var set=d.setMonth(parseInt(tt,10)-1);ma=d.getFullYear()-dn.getFullYear();return set;},4:function(tt){return d.setDate(tt+mb);},5:function(tt){if(tt>=0&&tt<=69){tt+=2000;}
else if(tt>=70&&tt<=100){tt+=1900;}
return d.setFullYear(tt+ma);}};for(i=0;i<argc;i++){no=parseInt(argv[i]*1,10);if(isNaN(no)){return false;}else{if(!dateManip[i](no)){return false;}}}
for(i=argc;i<6;i++){switch(i){case 0:no=dn.getHours();break;case 1:no=dn.getMinutes();break;case 2:no=dn.getSeconds();break;case 3:no=dn.getMonth()+1;break;case 4:no=dn.getDate();break;case 5:no=dn.getFullYear();break;}
dateManip[i](no);}
return Math.floor(d.getTime()/1000);}

function strtotime(str,now){var i,match,s,strTmp='',parse='';strTmp=str;strTmp=strTmp.replace(/\s{2,}|^\s|\s$/g,' ');strTmp=strTmp.replace(/[\t\r\n]/g,'');if(strTmp=='now'){return(new Date()).getTime()/1000;}else if(!isNaN(parse=Date.parse(strTmp))){return(parse/1000);}else if(now){now=new Date(now*1000);}else{now=new Date();}
strTmp=strTmp.toLowerCase();var __is={day:{'sun':0,'mon':1,'tue':2,'wed':3,'thu':4,'fri':5,'sat':6},mon:{'jan':0,'feb':1,'mar':2,'apr':3,'may':4,'jun':5,'jul':6,'aug':7,'sep':8,'oct':9,'nov':10,'dec':11}};var process=function(m){var ago=(m[2]&&m[2]=='ago');var num=(num=m[0]=='last'?-1:1)*(ago?-1:1);switch(m[0]){case'last':case'next':switch(m[1].substring(0,3)){case'yea':now.setFullYear(now.getFullYear()+num);break;case'mon':now.setMonth(now.getMonth()+num);break;case'wee':now.setDate(now.getDate()+(num*7));break;case'day':now.setDate(now.getDate()+num);break;case'hou':now.setHours(now.getHours()+num);break;case'min':now.setMinutes(now.getMinutes()+num);break;case'sec':now.setSeconds(now.getSeconds()+num);break;default:var day;if(typeof(day=__is.day[m[1].substring(0,3)])!='undefined'){var diff=day-now.getDay();if(diff==0){diff=7*num;}else if(diff>0){if(m[0]=='last'){diff-=7;}}else{if(m[0]=='next'){diff+=7;}}
now.setDate(now.getDate()+diff);}}
break;default:if(/\d+/.test(m[0])){num*=parseInt(m[0],10);switch(m[1].substring(0,3)){case'yea':now.setFullYear(now.getFullYear()+num);break;case'mon':now.setMonth(now.getMonth()+num);break;case'wee':now.setDate(now.getDate()+(num*7));break;case'day':now.setDate(now.getDate()+num);break;case'hou':now.setHours(now.getHours()+num);break;case'min':now.setMinutes(now.getMinutes()+num);break;case'sec':now.setSeconds(now.getSeconds()+num);break;}}else{return false;}
break;}
return true;};match=strTmp.match(/^(\d{2,4}-\d{2}-\d{2})(?:\s(\d{1,2}:\d{2}(:\d{2})?)?(?:\.(\d+))?)?$/);if(match!=null){if(!match[2]){match[2]='00:00:00';}else if(!match[3]){match[2]+=':00';}
s=match[1].split(/-/g);for(i in __is.mon){if(__is.mon[i]==s[1]-1){s[1]=i;}}
s[0]=parseInt(s[0],10);s[0]=(s[0]>=0&&s[0]<=69)?'20'+(s[0]<10?'0'+s[0]:s[0]+''):(s[0]>=70&&s[0]<=99)?'19'+s[0]:s[0]+'';return parseInt(this.strtotime(s[2]+' '+s[1]+' '+s[0]+' '+match[2])+(match[4]?match[4]/1000:''),10);}
var regex='([+-]?\\d+\\s'+'(years?|months?|weeks?|days?|hours?|min|minutes?|sec|seconds?'+'|sun\\.?|sunday|mon\\.?|monday|tue\\.?|tuesday|wed\\.?|wednesday'+'|thu\\.?|thursday|fri\\.?|friday|sat\\.?|saturday)'+'|(last|next)\\s'+'(years?|months?|weeks?|days?|hours?|min|minutes?|sec|seconds?'+'|sun\\.?|sunday|mon\\.?|monday|tue\\.?|tuesday|wed\\.?|wednesday'+'|thu\\.?|thursday|fri\\.?|friday|sat\\.?|saturday))'+'(\\sago)?';match=strTmp.match(new RegExp(regex,'gi'));if(match==null){return false;}
for(i=0;i<match.length;i++){if(!process(match[i].split(' '))){return false;}}
return(now.getTime()/1000);}

function urldecode(str){return decodeURIComponent(str).replace(/\+/g,'%20');}

function urlencode(str){str=(str+'').toString();return encodeURIComponent(str).replace(/!/g,'%21').replace(/'/g,'%27').replace(/\(/g,'%28').replace(/\)/g,'%29').replace(/\*/g,'%2A').replace(/%20/g,'+');}

function array_filter(arr,func){var retObj={},k;if(func == undefined){func = function(v){return v != '' && v != 0 && v != null;}}for(k in arr){if(func(arr[k])){retObj[k]=arr[k];}}
return retObj;}

function count(mixed_var,mode){var key,cnt=0;if(mixed_var===null){return 0;}else if(mixed_var.constructor!==Array&&mixed_var.constructor!==Object){return 1;}
if(mode==='COUNT_RECURSIVE'){mode=1;}
if(mode!=1){mode=0;}
for(key in mixed_var){cnt++;if(mode==1&&mixed_var[key]&&(mixed_var[key].constructor===Array||mixed_var[key].constructor===Object)){cnt+=this.count(mixed_var[key],1);}}
return cnt;}

function vsprintf(format, args){
    return sprintf.apply(this, [format].concat(args));
}

function str_repeat(input, multiplier){
    return new Array(multiplier+1).join(input); 
}

function html_entities(s){
	return s.replace(/&/g, "&amp;").
		replace(/'/g, "&#039;").
		replace(/"/g, "&quot;").
		replace(/</g, "&lt;").
		replace(/>/g, "&gt;");
}

function html_decode_entities(s){
	return s.replace(/&#039;/g, "'").
		replace(/&quot;/g, "\"").
		replace(/&lt;/g, "<").
		replace(/&gt;/g, ">").
		replace(/&amp;/g, "&");
}

function sprintf(){var regex=/%%|%(\d+\$)?([-+\'#0 ]*)(\*\d+\$|\*|\d+)?(\.(\*\d+\$|\*|\d+))?([scboxXuidfegEG])/g;var a=arguments,i=0,format=a[i++];var pad=function(str,len,chr,leftJustify){if(!chr){chr=' ';}
var padding=(str.length>=len)?'':Array(1+len-str.length>>>0).join(chr);return leftJustify?str+padding:padding+str;};var justify=function(value,prefix,leftJustify,minWidth,zeroPad,customPadChar){var diff=minWidth-value.length;if(diff>0){if(leftJustify||!zeroPad){value=pad(value,minWidth,customPadChar,leftJustify);}else{value=value.slice(0,prefix.length)+pad('',diff,'0',true)+value.slice(prefix.length);}}
return value;};var formatBaseX=function(value,base,prefix,leftJustify,minWidth,precision,zeroPad){var number=value>>>0;prefix=prefix&&number&&{'2':'0b','8':'0','16':'0x'}[base]||'';value=prefix+pad(number.toString(base),precision||0,'0',false);return justify(value,prefix,leftJustify,minWidth,zeroPad);};var formatString=function(value,leftJustify,minWidth,precision,zeroPad,customPadChar){if(precision!=null){value=value.slice(0,precision);}
return justify(value,'',leftJustify,minWidth,zeroPad,customPadChar);};var doFormat=function(substring,valueIndex,flags,minWidth,_,precision,type){var number;var prefix;var method;var textTransform;var value;if(substring=='%%'){return'%';}
var leftJustify=false,positivePrefix='',zeroPad=false,prefixBaseX=false,customPadChar=' ';var flagsl=flags.length;for(var j=0;flags&&j<flagsl;j++){switch(flags.charAt(j)){case' ':positivePrefix=' ';break;case'+':positivePrefix='+';break;case'-':leftJustify=true;break;case"'":customPadChar=flags.charAt(j+1);break;case'0':zeroPad=true;break;case'#':prefixBaseX=true;break;}}
if(!minWidth){minWidth=0;}else if(minWidth=='*'){minWidth=+a[i++];}else if(minWidth.charAt(0)=='*'){minWidth=+a[minWidth.slice(1,-1)];}else{minWidth=+minWidth;}
if(minWidth<0){minWidth=-minWidth;leftJustify=true;}
if(!isFinite(minWidth)){throw new Error('sprintf: (minimum-)width must be finite');}
if(!precision){precision='fFeE'.indexOf(type)>-1?6:(type=='d')?0:undefined;}else if(precision=='*'){precision=+a[i++];}else if(precision.charAt(0)=='*'){precision=+a[precision.slice(1,-1)];}else{precision=+precision;}
value=valueIndex?a[valueIndex.slice(0,-1)]:a[i++];switch(type){case's':return formatString(String(value),leftJustify,minWidth,precision,zeroPad,customPadChar);case'c':return formatString(String.fromCharCode(+value),leftJustify,minWidth,precision,zeroPad);case'b':return formatBaseX(value,2,prefixBaseX,leftJustify,minWidth,precision,zeroPad);case'o':return formatBaseX(value,8,prefixBaseX,leftJustify,minWidth,precision,zeroPad);case'x':return formatBaseX(value,16,prefixBaseX,leftJustify,minWidth,precision,zeroPad);case'X':return formatBaseX(value,16,prefixBaseX,leftJustify,minWidth,precision,zeroPad).toUpperCase();case'u':return formatBaseX(value,10,prefixBaseX,leftJustify,minWidth,precision,zeroPad);case'i':case'd':number=parseInt(+value,10);prefix=number<0?'-':positivePrefix;value=prefix+pad(String(Math.abs(number)),precision,'0',false);return justify(value,prefix,leftJustify,minWidth,zeroPad);case'e':case'E':case'f':case'F':case'g':case'G':number=+value;prefix=number<0?'-':positivePrefix;method=['toExponential','toFixed','toPrecision']['efg'.indexOf(type.toLowerCase())];textTransform=['toString','toUpperCase']['eEfFgG'.indexOf(type)%2];value=prefix+Math.abs(number)[method](precision);return justify(value,prefix,leftJustify,minWidth,zeroPad)[textTransform]();default:return substring;}};return format.replace(regex,doFormat);}

function strip_tags(str,allowed_tags){var key='',allowed=false;var matches=[];var allowed_array=[];var allowed_tag='';var i=0;var k='';var html='';var replacer=function(search,replace,str){return str.split(search).join(replace);};if(allowed_tags){allowed_array=allowed_tags.match(/([a-zA-Z0-9]+)/gi);}
str+='';matches=str.match(/(<\/?[\S][^>]*>)/gi);for(key in matches){if(isNaN(key)){continue;}
html=matches[key].toString();allowed=false;for(k in allowed_array){allowed_tag=allowed_array[k];i=-1;if(i!=0){i=html.toLowerCase().indexOf('<'+allowed_tag+'>');}
if(i!=0){i=html.toLowerCase().indexOf('<'+allowed_tag+' ');}
if(i!=0){i=html.toLowerCase().indexOf('</'+allowed_tag);}
if(i==0){allowed=true;break;}}
if(!allowed){str=replacer(html,"",str);}}
return str;}

function intval(mixed_var,base){var tmp;var type=typeof(mixed_var);if(type==='boolean'){return(mixed_var)?1:0;}else if(type==='string'){tmp=mixed_var.replace(/[^0-9]/g, '');return(isNaN(tmp)||!isFinite(tmp))?0:tmp;}else if(type==='number'&&isFinite(mixed_var)){return Math.floor(mixed_var);}else{return 0;}}

function basename(path, suffix) {var b = path.replace(/^.*[\/\\]/g, '');if (typeof(suffix) == 'string' && b.substr(b.length-suffix.length) == suffix) {b = b.substr(0, b.length-suffix.length);}return b;}

function nl2br (str, is_xhtml) {
	var breakTag = (is_xhtml || typeof is_xhtml === 'undefined') ? '<br />' : '<br>';
    return (str + '').replace(/([^>\r\n]?)(\r\n|\n\r|\r|\n)/g, '$1'+ breakTag +'$2');
}

function include(f, success){
	__p8_including_js[f] = 1;
	var head = document.getElementsByTagName('head')[0] || document.documentElement;
	var script = document.createElement('script');
	script.src = f;
	
	if(success){
		var done = false;
		script.onload = script.onreadystatechange = function() {
			if ( !done && (!this.readyState ||
					this.readyState === 'loaded' || this.readyState === 'complete') ) {
				done = true;
				success();
				__p8_included_js[f] = 1;
				delete __p8_including_js[f];
				
				// Handle memory leak in IE
				script.onload = script.onreadystatechange = null;
				if (head && script.parentNode){
					head.removeChild(script);
				}
			}
		};
	}
	head.insertBefore(script, head.firstChild);
}

function load_css(f, success){
	__p8_including_css[f] = 1;
	var head = document.getElementsByTagName('head')[0] || document.documentElement;
	var css = document.createElement('link');
	css.href = f;
	css.type = 'text/css';
	css.rel = 'stylesheet';
	
	if(success){
		
		function check(){
			var dss = document.styleSheets;
			for(var i = 0; i < dss.length; i++){
				if(dss[i].href == f){
					__p8_included_css[f] = 1;
					delete __p8_including_css[f];
					
					success();
					return;
				}
			}
			
			setTimeout(check, 200);
		}
		
		check();
	}
	head.insertBefore(css, head.firstChild);
}

function include_once(f, success){
	if(__p8_including_js[f]){
		setTimeout(function(){ include_once(f, success); }, 300);
		return false;
	}
	if(__p8_included_js[f]){
		success(true);
		return true;
	}
	
	include(f, success);
}

function clone(obj){
	var clone;
	// Array.
	if ( obj && ( obj instanceof Array ) )
	{
		clone = [];

		for ( var i = 0 ; i < obj.length ; i++ )
			clone[ i ] = this.clone( obj[ i ] );

		return clone;
	}
	// "Static" types.
	if ( obj === null
		|| ( typeof( obj ) != 'object' )
		|| ( obj instanceof String )
		|| ( obj instanceof Number )
		|| ( obj instanceof Boolean )
		|| ( obj instanceof Date )
		|| ( obj instanceof RegExp) )
	{
		return obj;
	}

	// Objects.
	clone = new obj.constructor();

	for ( var propertyName in obj )
	{
		var property = obj[ propertyName ];
		clone[ propertyName ] = this.clone( property );
	}

	return clone;
}

function exit(){
	if($.browser.msie){
		document.execCommand('stop');
	}else{
		window.stop();
	}
}


function get_scrollLeft(){
	return (document.documentElement.scrollLeft || document.body.scrollLeft);
}

function get_scrollTop(){
	return (document.documentElement.scrollTop || document.body.scrollTop);
}

function get_scrollWidth(){
	return Math.max(document.documentElement.scrollWidth || document.body.scrollWidth, get_document_width());
}

function get_scrollHeight(){
	return Math.max(document.documentElement.scrollHeight || document.body.scrollHeight, get_document_height());
}

function get_document_width(){
	return (document.documentElement.clientWidth || document.body.clientWidth);
}

function get_document_height(){
	return (document.documentElement.clientHeight || document.body.clientHeight);
}


function setcookie( name, value, expires, path, domain, secure ) {
	var today = new Date();
	
	today.setTime( today.getTime() );
	if ( expires ) {
		expires = expires * 1000;
	}
	var expires_date = new Date( today.getTime() + expires );
	var str = name +'='+ escape( value ) +
		(expires ? ';expires='+ expires_date.toGMTString() : '' ) + 
		(path ? ';path=' + path : '' ) +
		(domain ? ';domain=' + domain : '' ) +
		(secure ? ';secure' : '' );
	document.cookie = str;//alert(str);
	//reload the cookie
	get_cookies();
}

function set_cookie(name, value, expires, domain){
	name = P8CONFIG.cookie_prefix + name;
	return setcookie(name, value, expires, P8CONFIG.cookie_path, domain === undefined ? P8CONFIG.base_domain : domain);
}

function get_cookie(name){
	name = P8CONFIG.cookie_prefix + name;
	return $_COOKIE[name];
}


function get_cookies(){
	var cookies = document.cookie.split('; ');
	http_datas('$_COOKIE', cookies, 'unescape');
}

function http_datas(name, data, func){
	func = func || 'decodeURIComponent';
	for(var i in data){
		var m = data[i].match(/([^=]+)(?:=?)(.*)/);
		if(m){
			var m2 = [];
			eval('m[1] = '+ func +'(m[1]);');
			m[1].replace(
				/[^\[\]]+|\[\]/g,
				function (x){
					m2.push(x == '[]' ? '' : x);
				}
			);
			if(m2 && m2.length > 1){
				var offset, base = name +"['"+ m2[0] +"']";
				var evals = "if(!"+ base +") "+ base +" = [];";
				for(var j = 1; j < m2.length; j++){
					evals += "offset = "+ base +".length;";
					base += "["+ (m2[j] ? "'"+ m2[j] +"'" : 'offset') +"]";
					evals += 'if(!'+ base +') '+ base +' = [];';
					
					if(j == m2.length -1)
						evals += base +" = "+ func +"(m[2]);";
				}
				eval(evals);
			}else{
				eval("try{"+ name +"[m[1]] = "+ func +"(m[2]) || '';}catch(e){"+ name +"[m[1]] = m[2];}");
			}
		}
	}
	//name = data = m = m2 = offset = base = evals = null;
}


function get_modules(s, func){
	if(!s) return false;
	$.getJSON(P8CONFIG.url +'/api/get_modules.php?system='+ s +'&callback=?', function(json){
		func(json);
	});
}

function get_actions(s, m, type, func){
	if(!s) return false;
	$.getJSON(P8CONFIG.url +'/api/get_actions.php?system='+ s +'&module='+ m +'&type='+ type +'&callback=?', function(json){
		func(json);
	});
}

function get_admin_controller(func){
	try{
		__p8_admin_controller;
		func(__p8_admin_controller);
	}catch(e){
		$.getJSON(P8CONFIG.controller +'/core-get_admin_controller?callback=?', function(s){
			__p8_admin_controller = P8CONFIG.url +'/'+ s;
			func(__p8_admin_controller);
		});
	}
}

function get_member_controller(func){
	func(U_controller);
}

function get_router(system, module){
	module = module === undefined ? '' : module;
	return P8CONFIG.URI[system][module].controller;
}

function ajax_parameters(o, p){
	if(!o || typeof o != 'object') return o;
	
	var s = '';
	p = p ? p : '';
	
	for(i in o){
		if(typeof o[i] == 'object' && !o[i].splice)
			s += ajax_parameters(o[i], p ? p+'['+i+']' : i);
		else if(o[i] instanceof Array)
			s += ajax_parameters(o[i], p ? p+'['+i+']' : i);
		else
			s += '&'+ encodeURIComponent(p ? p + '['+i+']' : i) +'=' + encodeURIComponent(o[i]);
	}
	return s;
}

function lang_array(lang, param){
	for(var i = 0; i < param.length; i++){
		lang = lang.replace(new RegExp('{\\$'+ (i+1) +'}', 'g'), param[i]);
	}
	return lang;
}

//locate the element to the center of screen
function element_to_center(e, x_offset, y_offset){
	$(e).css({
		left: parseInt((get_scrollLeft() + get_document_width() - $(e).width())/2) + (x_offset ? x_offset : 0) +'px',
		top: parseInt(get_scrollTop() + (get_document_height() - $(e).height())/2) + (y_offset ? y_offset : 0) +'px'
	});
}

//show hint while ajax requesting
function ajaxing(options){
	options = {
		id: options.id || 'ajaxing',
		className: options.className || 'ajaxing',
		action: options.action || 'show',
		text: options.text || P8LANG.loading,
		zIndex: options.zIndex || 20001,
		fadeOut: options.fadeOut || 2000
	};
	
	if(!$('#'+ options.id).length){
		$('<div id="'+ options.id +'" class="'+ options.className +'"></div>').appendTo(document.body).html(options.text);
	}
	
	if(options.action == 'show'){
		$('#'+ options.id).stop(true, true).show().css({zIndex: options.zIndex}).html(options.text);
		element_to_center($('#'+ options.id));
	}else{
		$('#'+ options.id).fadeOut(options.fadeOut).html(options.text);
	}
}

//cover the screen, disabled
function overlay(options){
	options = {
		id: options.id || 'overlay',
		action: options.action || 'show',
		opacity: options.opacity || 0.3,
		backgroundColor: options.backgroundColor || '#cccccc',
		zIndex: options.zIndex || 9999
	};
	
	var ie6 = $.browser.msie && $.browser.version < '7' ? true : false;
	
	if(!$('#'+ options.id).length){
		$('<div id="'+ options.id +'" style="position: absolute; left: 0px; top: 0px;"></div>').
		appendTo(document.body).
		css({
			opacity: options.opacity,
			backgroundColor: options.backgroundColor,
			zIndex: options.zIndex
		});
		
		if(ie6){
			$('#'+ options.id).data(
				'iframe', 
				$('<iframe frameborder="0" style="position: absolute; left: 0px; top: 0px; opacity: 0; filter: alpha(opacity=0);" src="about:blank"></iframe>').hide()
					.prependTo($(document.body))
			);
		}
	}
	
	if(options.action == 'show'){
		var w = parseInt(get_scrollLeft() + get_document_width());
		var h = parseInt(get_scrollHeight());
		
		$('#'+ options.id).show().css({
			width: w,
			height: h
		});
		
		if(ie6){
			$('#'+ options.id).data('iframe').show().css({
				width: w,
				height: h,
				zIndex: options.zIndex -1
			});
		}
	}else{
		$('#'+ options.id).hide();
		
		if(ie6){
			$('#'+ options.id).data('iframe').hide();
		}
	}
}

function P8_Dialog(options){
	
	this.className = options.className || 'php168_dialog';
	this.overlay = options.overlay == undefined ? true : options.overlay;
	this.zIndex = options.zIndex || 20000;
	this.width = options.width || 400;
	this.height = options.height || 200;
	this.iframe = $.browser.msie && $.browser.version < '7' && !this.overlay ? true : false;
	this.onShow = options.show || null;
	this.button = options.button || false;
	this.position = options.position || 'absolute';
	this.overlay_id = (new Date().getTime());
	this._ok = null;
	
	P8_Dialog.count++;
	P8_Dialog.max_zIndex = Math.max(P8_Dialog.max_zIndex, this.zIndex);
	if(P8_Dialog.max_zIndex == this.zIndex) P8_Dialog.top = this;
	
	this.url_loaded = false;
	
	if(this.iframe){
		//god damn ie6
		this._iframe = $('<iframe frameborder="0" style="position: absolute; opacity: 0; filter: alpha(opacity=0);" src="about:blank"></iframe>').hide();
		$(document.body).prepend(this._iframe);
	}
	
	if(options.element){
		
		this.element = options.element;
		this.title = options.title || null;
		this.title_bar = options.title_bar || null;
		this.content = options.content || null;
		this.button_bar = options.button_bar || null;
		this.close = options.close || null;
		this.element.addClass(this.className);
		
	}else{
		
		this.title_text = options.title_text || '&nbsp;';
		
		//default element
		this.element = $('\
		<div class="'+ this.className +'">\
			<div class="title_bar">\
				<div class="close"><span>X</span></div>\
				<span class="title">'+ this.title_text +'</span>\
			</div>\
			<div class="content_container">\
				<div class="content"></div>\
			</div>\
			'+ (this.button ? '<div class="button_bar"><input type="button" value="'+ P8LANG.ok +'" class="ok" /> <input type="button" value="'+ P8LANG.cancel +'" class="cancel" /></div>' : '') +'\
		</div>');
		
		this.title_bar = $('.title_bar', this.element);
		this.title = $('.title', this.element);
		this.content = $('.content', this.element);
		this.close = $('.close', this.element);
		this.button_bar = $('.button_bar', this.element);
	}
	
	this.element.css({
		zIndex: this.zIndex,
		width: this.width +'px',
		height: this.height +'px',
		position: this.position
	});
	
	this.content.resize(function(){
		//alert(1);
	});
	
	//draggable?
	this.draggable = options.draggable || true;
	if(this.draggable){
		$(this.element).jqDrag(
			$('.title_bar', this.element),
			{
				drag: function(){
					_this.content.css({'visibility': 'hidden'});
				},
				stop: function(){
					_this.content.css({'visibility': ''});
				},
				dragging: function(){
					if(_this.iframe){
						var offset = _this.element.offset();
						_this._iframe.css({
							left: offset.left +'px',
							top: offset.top +'px'
						});
					}
				}
			}
		);
	}
	
	var _this = this;
	
	//close button
	this.close.click(function(){
		_this.close();
	});
	
	//set title text
	this.set_title = function(title){
		this.title.html(title);
	};
	
	//show the dialog
	this.show = function(x, y){
		this.element.show();
		if(x === undefined && y === undefined){
			element_to_center(this.element);
		}else{
			this.element.css({left: x +'px', top: y +'px'});
		}
		
		this.content.css({
			height: (this.height - this.title_bar.outerHeight() - this.button_bar.outerHeight()-10) +'px'
		});
		
		$(document).keyup(this.keyup);
		
		if(this.overlay){
			overlay({id: this.overlay_id, zIndex: this.zIndex -1});
		}
		
		//load url if exists
		if(options.url && !this.url_loaded){
			this.url_loaded = true;
			ajaxing({});
			this.content.load(options.url, '', function(){ajaxing({action: 'hide'});});
		}
		
		if(this.iframe){
			this._iframe.show();
			this._iframe.width(this.element.outerWidth());
			this._iframe.height(this.element.outerHeight());
			var offset = this.element.offset();
			_this._iframe.css({
				left: offset.left +'px',
				top: offset.top +'px'
			});
		}
		
		if(this.onShow){
			this.onShow.call(this);
		}
	};
	
	this.ok = function(func){
		this._ok = func;
	};
	
	//hide the dialog
	this.hide = function(){
		this.element.hide();
		if(this.overlay){
			overlay({action: 'hide', id: this.overlay_id});
		}
		
		if(this.iframe){
			this._iframe.hide();
		}
	};
	
	//close the dialog
	this.close = function(){
		//on close
		if(options.cancel){
			if(options.cancel.call(this) === false) return;
		}
		
		_this.hide();
		$(document).unbind('keyup', this.keyup);
	};
	
	this.keyup = function(e){
		//press ESC to close
		if(e.keyCode == 27){
			_this.close();
		}
	};
	
	//on ok
	$('.ok', this.button_bar).click(function(){
		if(_this._ok){
			if(_this._ok.call(_this) === false) return;;
		}
		if(options.ok){
			if(options.ok.call(_this) === false) return;
		}
		
		_this.hide();
	});
	
	//on close
	$('.cancel', this.button_bar).click(function(){
		_this.close();
	});
	
	//init
	this.element.hide();
	//append before first child
	//$(function(){
		$(document.body).prepend(_this.element);
	//});
}
P8_Dialog.count = 0;
P8_Dialog.max_zIndex = 0;
P8_Dialog.top = null;

function P8_CKEDITOR(options){
	var options = {
		id: options.id,
		div: options.div || null,
		config: options.config || null,
		action: options.action || 'replace',
		type: options.type || '',
		callback: options.callback || null
	};
	
	if(options.action == 'destroy'){
		CKEDITOR.instances[options.id].destroy();
	}else{
		if(options.div){
			$('#'+ options.id).val($(options.div).hide().html());
		}
		
		include_once(P8CONFIG.RESOURCE +'/ckeditor/ckeditor'+ (options.type ? '_'+ options.type : '') +'.js', function(){
			if(CKEDITOR.instances[options.id]) return;
			
			CKEDITOR.replace(options.id, options.config).on('focus', function(){
				this.updateElement();
			});
			
			CKEDITOR.instances[options.id].on('instanceReady', function(){
				var _this = this;
				
				this.document.on('mouseout', function(){
					_this.updateElement();
				});
				if(options.callback) options.callback.call(this);
			});
		});
	}
}


function P8_UEDITOR(options){
	var options = {
		id: options.id,
		div: options.div || null,
		config: options.config || null,
		action: options.action || 'replace',
		type: options.type || 'all.min',
		callback: options.callback || null
	};
	
	if(options.action == 'destroy'){
		disableBtn();
		UE.getEditor(options.id).destroy();
	}else{
		if(options.div){
			$('#'+ options.id).val($(options.div).hide().html());
		}
		
		include_once(P8CONFIG.RESOURCE +'/ueditor/ueditor.config.js');
		include_once(P8CONFIG.RESOURCE +'/ueditor/lang/zh-cn/zh-cn.js');
		include_once(P8CONFIG.RESOURCE +'/ueditor/ueditor'+ (options.type ? '.'+ options.type : '') +'.js', function(){
				UE.getEditor(options.id, options.config);
		});
	}
}

function captcha(e, trigger){
	var c = $('<img src="'+ P8CONFIG.url +'/api/captcha.php" align="top" style="cursor: pointer;" onclick="this.src=P8CONFIG.url +\'/api/captcha.php?_=\'+ Math.random()" title="'+ P8LANG.refresh_captcha +'" />');
//	if(trigger !== undefined){
//		$(trigger).focus(function(){
//			if($(this).data('captchaed') == true) return;
//			
//			$(this).data('captchaed', true);
//			$(e).append(c);
//		});
//	}else{
		$(e).append(c);
//	}
}

function check_all(check, name, context){
	$('input[type=checkbox][name="'+ name +'"]', context === undefined ? null : $(context)).
	attr('checked', typeof check === 'boolean' ? check : $(check).attr('checked') );
}

function checked_values(name, context){
	var values = [];
	$('input[type=checkbox][name="'+ name +'"]:checked', context === undefined ? null : $(context)).
	each(function(){
		values.push(this.value);
	});
	return values;
}

function MoveTabs(id,sid,t,over){
	if(!sid)sid=0;
	if(!t)t='click';
	if(!over)over='over';
	$("#"+id+">.head > span").eq(sid).addClass(over);
	$("#"+id+">.main >.content").eq(sid).siblings("#"+id+" >.main >.content").hide().end().show();
	$("#"+id+">.head >span").unbind(t).bind(t, function(){
		$(this).siblings("span").removeClass(over).end().addClass(over);
		var index = $("#"+id+" >.head >span").index( $(this) );
		$("#"+id+" >.main >.content").eq(index).siblings("#"+id+" >.main >.content").hide().end().show();
   });
}

function syntax_highlight(){
	var pres = $('pre[name=__code__]');
	var textareas = $('textarea[name=__code__]');
	
	this.types = {
		Cpp: 1,
		Css: 1,
		CSharp: 1,
		JScript: 1,
		Php: 1,
		Sql: 1,
		Java: 1,
		Xml: 1
	};
	
	this.type = {};
	
	var _this = this;
	
	pres.each(function(){
		if(_this.types[this.className]){
			_this.type[this.className] = 1;
		}
	});
	
	textareas.each(function(){
		if(_this.types[this.className]){
			_this.type[this.className] = 1;
		}
	});
	
	if(count(this.type)){
		include_once(P8CONFIG.RESOURCE +'/js/sh/shCore.js', function(){
			_this._include();
		});
	}
	
	this._include = function(){
		for(var i in this.type){
			include_once(P8CONFIG.RESOURCE +'/js/sh/shBrush'+ i +'.js', function(){
				_this._include();
			});
			delete _this.type[i];
			return;
		}
		
		load_css(P8CONFIG.RESOURCE +'/js/sh/SyntaxHighlighter.css', function(){
			dp.SyntaxHighlighter.HighlightAll('__code__'); 
		});
	};
}

function scroll_to_load(ele, func){
	var offset = $(ele).offset();
	var requested = false;
	
	function get(){
		if(requested){
			$(window).unbind('scroll', get);
			return;
		}
		
		var top = get_scrollTop() + get_document_height();
		if(top > offset.top){
			if(func){func.call($(ele));}
			
			requested = true;
		}
	}
	
	get();
	$(window).scroll(get);
}

function get_username(){
	var u = get_cookie('USERNAME');
	if(!u) return u;
	
	return $.evalJSON(u);
}

function init_labelshows(id){
	if(get_cookie('IS_ADMIN') !==undefined){
		if(LABEL_URL.indexOf('edit_label')==-1){
			var ls='?';
			if(LABEL_URL.indexOf('?')>-1)ls='&';
			LABEL_URL=LABEL_URL+ls+'edit_label=1';
			$('#'+id).append('<a href='+LABEL_URL+' id="edit_label">['+ P8LANG.showlabel +']</a>');
		}else{
			LABEL_URL=LABEL_URL.replace('&edit_label=1','');
			LABEL_URL=LABEL_URL.replace('edit_label=1','');
			$('#edit_label').remove();
			$('#'+id).append('<a href='+LABEL_URL+' >['+ P8LANG.hidelabel +']</a>');
		}
		
	}
	
}

function P8_Tab(options){
	this.options = $.extend({
		hover_class: '',
		normal_class: '',
		event: 'click',	//mouseover
		move_timeout: 0,
		handle: {},
		content: {},
		ajax: {},
		callback: null
	}, options);
	
	this.index = 0;
	this.last_index = -1;
	this.handle = [];
	this.content = [];
	
	var _this = this;
	
	this._move_event = function(){
		var i = $(this).data('p8_tab_index');
		_this.move(i);
		
		if(_this.options.event == 'click' && $(this).attr('tagName').toLowerCase() == 'a'){
			return false;
		}
	};
	
	this.mouseover = function(){
		if(_this._move_timeout) clearTimeout(_this._move_timeout);
	};
	
	this.mouseout = function(){
		_this.move_timeout();
	};
	
	this.rewind = function(){
		for(var i = 0; i < this.handle.length; i++){
			this.handle.data('p8_tab_index', i);
		}
	};
	
	/* add handle */
	this.add = function(data){
		
		var handle = $(data.handle),
			index = data.index === undefined ? this.handle.length : data.index,
			content = $(data.content);
		
		if(index != this.handle.length){
			this.rewind();
		}
		
		this.handle.splice(index, 1, handle);
		this.content.splice(index, 1, content);
		
		handle.data('p8_tab_index', index)
			.data('p8_tab_content', content.hide())
			.removeClass(_this.options.hover_class);
		
		if(this.options.event == 'mouseover'){
			handle.bind('mouseover', this._move_event);
		}else{
			handle.bind('click', this._move_event);
		}
		
		if(this.options.move_timeout){
			handle.add(handle.data('p8_tab_content'))
				.bind('mouseover', this.mouseover)
				.bind('mouseout', this.mouseout);
		}
		
	};
	
	/* move the tab by index */
	this.move = function(i){
		if(i > this.handle.length -1) i = 0;
		if(this.last_index == i) return;
		
		if(this.options.callback){
			if(this.options.callback.call(this, i) === false) return;
		}
		
		var handle = this.handle[i];
		handle.addClass(this.options.hover_class)
			.data('p8_tab_content').show();
		
		if(handle.attr('tagName').toLowerCase() == 'a' && !handle.data('p8_tab_loaded')){
			var url = handle.attr('href');
			if(url){
				
				$.ajax( $.extend({
					url: url,
					success: function(r, s){
						handle.data('p8_tab_loaded', true).data('p8_tab_content').html(r);
					}
				}, this.options.ajax) );
			}
		}
		
		this.last_index != -1 && $(this.handle[this.last_index]).removeClass(this.options.hover_class)
			.data('p8_tab_content').hide();
		
		this.last_index = i;
	};
	
	this.remove = function(i){
		if(!this.handle[i]) return false;
		
		var handle = this.handle[i];
		
		handle.data('p8_tab_content').unbind('mouseover', this.mouseover)
			.unbind('mouseout', this.mouseout)
			.remove();
		
		handle.removeData('p8_tab_content').removeData('p8_tab_loaded')
			.unbind('click', this.click)
			.unbind('mouseover', this.mouseover)
			.unbind('mouseout', this.mouseout)
			.remove();
		
		this.handle.splice(i, 1);
		
		this.rewind();
		
		this.move(i +1);
		
		return true;
	};
	
	this.move_timeout = function(){
		_this._move_timeout = setTimeout(_this.__move_timeout, _this.options.move_timeout);
	};
	
	this.__move_timeout = function(){
		_this.move(_this.last_index +1);
		_this._move_timeout = setTimeout(_this.__move_timeout, _this.options.move_timeout);
	};
	
	var _handle = $(this.options.handle);
	var _content = $(this.options.content);
	
	_handle.each(function(i){
		_this.add({handle: this, content: _content[i]});
	});
	//delete _handle, _content;
	
	this.move(0);
	
	if(this.options.move_timeout){
		this.move_timeout();
	}
}

function print_r(o, once, level){
	var ret = '';
	level = level === undefined ? 0 : level;
	
	if(typeof(o) == 'object'){
		var t = str_repeat('\t', level);
		ret += 'Array(\n';
		for(var i in o){
			try{
				if(typeof(o[i]) == 'object' && once !== true){
					ret += t +'\t' + i +' => '+ print_r(o[i], once, level +1) +'\n';
				}else{
					ret += t +'\t' + i +' => '+ o[i] +',\n';
				}
			}catch(e){}
		}
		ret += '\n'+ t +'),';
	}else{
		ret += ''+ o;
	}
	
	return ret;
}
function hover_table(){
	$('.hover_table tr').
	mouseover(function(){
		if($(this).hasClass('head') || $(this).hasClass('title')) return;
		$(this).addClass('hover_tr');
	}).
	mouseout(function(){
		if(!$(this).hasClass('clicked'))
			$(this).removeClass('hover_tr');
	});
}


function Message(option){
	var _this = this;
	this.uid = '';
	
	var SHORTCUTSMS = {};
	
	this.dialog = new P8_Dialog({
		title_text: P8LANG.core.notify.title_text,
		className:'message_dialog',
		width: 500,
		height: 310,
		button: true,
		show:function(){
			
		},
		ok: function(){
			ajaxing({});
			var type = [];
			this.content.find('input[name^=type][checked=true]').each( function(){
				type.push($(this).val());
			});
			var title = this.content.find('input[name=title]').val();
			var mobile = this.content.find('input[name=mobile]').val();
			var email = this.content.find('input[name=email]').val();
			var content = this.content.find('textarea').val();
			$.post(P8CONFIG['URI']['core']['message'].controller+'-message', {uid:_this.uid,type:type.join(','),title:title,content:content,mobile:mobile,email:email}, function(msg){ if(msg=='error'){ alert(P8LANG.core.notify.error);return; } ajaxing({action: 'hide',text:P8LANG.core.notify.success}); }, 'json' );
		}
	});
	
	this.send = function(uid){
		ajaxing({});
		this.uid = uid;
		$.ajax({
			url: P8CONFIG['URI']['core']['message'].controller+'-message',
			type: 'GET',
			dataType: 'json',
			data : {uid:uid},
			success: function(msg){
				if(msg=='nouid'){alert(P8LANG.core.notify.nouid);return}
				
				SHORTCUTSMS = msg.shortcut_sms;
				msg = msg.userdb;
				var tmp_content = '';
				
				for (var i in SHORTCUTSMS) {
					tmp_content += '<option>'+SHORTCUTSMS[i].content+'</option>';
				}
				options = tmp_content;
				userinfo = P8LANG.core.notify.send_to+(msg.username? msg.username : P8LANG.core.notify.unknow)+P8LANG.core.notify.cell_phone+(msg.cell_phone? msg.cell_phone : P8LANG.core.notify.unknow)+P8LANG.core.notify.email+(msg.email? msg.email : P8LANG.core.notify.unknow);
				//options = '<option>'+P8LANG.core.notify.message1+'</option><option>'+P8LANG.core.notify.message2+'</option><option>'+P8LANG.core.notify.message3+'.</option><option>'+P8LANG.core.notify.message4+'</option><option>'+P8LANG.core.notify.message5+'</option>';
				inhtml = '<div>'+P8LANG.core.notify.info+'  <span id="userinfo">'+ userinfo +'</div><div>'+P8LANG.core.notify.type+' <input type="checkbox" name="type[msg]" value="msg" checked="checked"  '+(msg.username? '' : 'disabled')+'/> '+P8LANG.core.notify.msg+'  <input type="checkbox" name="type[sms]" value="sms" /> '+P8LANG.core.notify.cell_phone+' <input type="checkbox" name="type[email]" value="email" /> '+P8LANG.core.notify.email+'<button class="showInputBox" onclick="message.showInputBox()"/></div><div id="mobileInputBox">'+P8LANG.core.notify.cell_phone2+' <input type="text" name="mobile" size="40"/></div><div id="emailInputBox">'+P8LANG.core.notify.email2+' <input type="text" name="email" size="40"/></div><div>'+P8LANG.core.notify.title+': <input type="text" name="title" size="40"/></div><div><span style="float:left">'+P8LANG.core.notify.content+':&nbsp;</span> <textarea rows="4" cols="46" name="content" style="font-size:12px;width:410px"></textarea></div><div>'+P8LANG.core.notify.message+': <select onchange="message.change(this)"><option>=='+P8LANG.core.notify.msgchange+'==</option>'+options+'</select></div>';
				_this.dialog.content.html(inhtml);
				ajaxing({action: 'hide'});
				_this.dialog.show();
			}
		});
	}
	this.change = function(obj){
		optioncontent = $(obj).find('option:selected').html();
		this.dialog.content.find('textarea').val(optioncontent);
	}
	this.showInputBox = function(){
		if($('#mobileInputBox').css('display')=='none'){
			$('#mobileInputBox').show();
			$('#emailInputBox').show();
			this.dialog.element.css('height',this.dialog.height+66);
			this.dialog.content.css('height',this.dialog.content.height()+66);
			
		}else{
			$('#mobileInputBox').hide();
			$('#emailInputBox').hide();
			this.dialog.element.css('height',this.dialog.height);
			this.dialog.content.css('height',this.dialog.content.height()-66);
		}

	}
	
}


function init_operation(links,ele){
	var menu = '<ul style="position: absolute; border: 2px solid #09C; background-color: #ffffff; padding: 5px;">';
	for(var i in links){
		menu += '<li><a href="'+links[i]+'" target="_blank">'+i+'</a></li>';
	}
	menu += '</ul>';
	ele = typeof(ele) == "undefined"? $('#operation'): $('#'+ele);
	
	menu = $(menu);
	
	$(ele).click(function(){
		var offset = $(this).offset();
		menu.toggle().css({
			left: offset.left +'px',
			top: ($(this).height() + offset.top) +'px'
		});
		
		if(!$(ele).data('shown')){
			get_admin_controller(function(c){
				menu.find('li a[router^=/]').each(function(){
					this.href = c + $(this).attr('router');
				});
			});
		}else{
			$(ele).data('shown', 1);
		}
	});
	
	$(document.body).append(menu);
	menu.hide();
}






var $_COOKIE = {},
	$_GET = {},
	P8LANG = {},
	__p8_included_js = {},
	__p8_including_js = {},
	__p8_included_css = {},
	__p8_including_css = {};

//use $_COOKIE as php
if(document.cookie){
	get_cookies();
}

//use $_GET as php
var gets = window.location.search.substr(1).split('&');
if(gets){
	var $_GET = {};
	http_datas('$_GET', gets);
}

var browser={    
 versions:function(){            
  var u = navigator.userAgent, app = navigator.appVersion;
  return {
   //移动终端浏览器版本信息                 
   trident: u.indexOf('Trident') > -1,               
   presto: u.indexOf('Presto') > -1,             
   webKit: u.indexOf('AppleWebKit') > -1,              
   gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1,             
   mobile: !!u.match(/AppleWebKit.*Mobile.*/)||!!u.match(/AppleWebKit/),      
   ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/),     
   android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1,              
   iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1,               
   iPad: u.indexOf('iPad') > -1,                
   webApp: u.indexOf('Safari') == -1             
   };          
  }(),          
   language:(navigator.browserLanguage || navigator.language).toLowerCase() 
}
$(function(){
	$('img .scroll_to_load').each(function(){
		scroll_to_load($(this), function(){$(this).attr('src', $(this).attr('_src'));});
	});
	hover_table();
	new syntax_highlight();
	
	$('script').each(function(){
		if($(this).attr('src')){
			__p8_included_js[$(this).attr('src')] = 1;
		}
	});
	
    /* if(P8CONFIG.mobile_status){
        if(browser.versions.android || browser.versions.iPhone || browser.versions.iPad){
			if(P8CONFIG.mobile_auto_jump && P8CONFIG.mobile_url!=P8CONFIG.url){
				var this_url = location.href;
				if(this_url.indexOf(P8CONFIG.mobile_url)==-1){
					this_url = this_url.replace(P8CONFIG.url, P8CONFIG.mobile_url);
					location.href = this_url;
				}
			}
		}
    } */

});
