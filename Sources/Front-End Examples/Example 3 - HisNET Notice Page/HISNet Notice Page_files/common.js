//일반 팝업창  (스크롤X)
function OpenWin(p_sURL,p_sWidth,p_sHeight){
	newWin = open(p_sURL,"new","width="+p_sWidth+",height="+p_sHeight+",left=250,top=180,scrollbars=0");
	newWin.focus();
}

// 공지사항 새창
function openwindow(theURL,winName,features)
{
	window.open(theURL,winName, 'width=600, height=640, toolbar=no, status=yes, resizable=yes, scrollbars=yes, topmargin=0, leftmargin=0, marginwidth=0, marginheight=0, left=100, top=100');
}


//일반 팝업창,특성주 (스크롤)
function OpenWin2(theURL,p_sWidth,p_sHeight){
	newWin = window.open(theURL,'new',"width="+p_sWidth+",height="+p_sHeight+",left=250,top=180,scrollbars=yes");
	newWin.focus();
}

//일반 새창
function newWin( address )
{
var URL = address;
	if ( URL != '' ) {
	window.open(URL,'_blank','');
	}
}

function getCookie(name){
	var namestr   = name + "=";
	var namelen   = namestr.length;
	var cookielen = document.cookie.length;

	var i    = 0;
	while(i< cookielen){
		var j = i+namelen;
		if(document.cookie.substring(i,j)==namestr){
			var end = document.cookie.indexOf(";",j);
			if(end== -1)
				end = document.cookie.length;
			return unescape(document.cookie.substring(j,end));
		}
		i=document.cookie.indexOf(" ",i)+1;
		if (i==0) break;
	}
	return null;
}

function setCookie(name,value){
	var expires = new Date();
	var path,domain,secure;

	var argv    = setCookie.arguments; 
	var argc    = setCookie.arguments.length;  
	if (argc > 2) {
		expires.setTime(expires.getTime() + (1000*60*argv[2]));
	} 
	else {
		expires  = null;
	}
	path    = (argc > 3) ? argv[3] : null;  
	domain  = (argc > 4) ? argv[4] : null;  
	secure  = (argc > 5) ? argv[5] : false;  
	document.cookie = name + "=" + escape (value) + 
							((expires == null) ? ""         : ("; expires=" + expires.toGMTString())) + 
							((path    == null) ? ""         : ("; path=" + path)) +  
							((domain  == null) ? ""         : ("; domain=" + domain)) +    
							((secure  == true) ? "; secure" : "");
							
}


String.prototype.trim= function(){
   return this.replace(/(^\s*)|(\s*$)/g,"");
}