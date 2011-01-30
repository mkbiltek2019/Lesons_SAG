function mOvr(src) 
{
	src.style.cursor = 'hand';
	if(src.src == '#')
		return;
	src.bgColor = '#ffffff';
	src.children.tags('a')[0].style.color='#BB0100';
}
function mOut(src) 
{
	src.style.cursor = 'default';
	if(src.src == '#')
		return;
	src.bgColor = '#BB0100';
	src.children.tags('a')[0].style.color='#ffffff';
}
function mClk(src)
{
	if(event.srcElement.tagName=='TD')
		src.children.tags('a')[0].click();    
}

var currentLayer = null;
var currentLayerNum = 0;
var noClose = 0;
var closeTimer = null;
function mopen(n)
{
	var l = document.getElementById("menu"+n);
	if(l)
	{
		mcancelclosetime();
		
		l.style.display='block';

		if(currentLayer && (currentLayerNum != n))
			currentLayer.style.display='none';
		currentLayer = l;
		currentLayerNum = n;			
	}
	else if(currentLayer)
	{
		currentLayer.style.display='none';
		currentLayerNum = 0;
		currentLayer = null;
	}
	
}
function mclosetime()
{
	closeTimer = window.setTimeout(mclose, 700);
}
function mcancelclosetime()
{
	if(closeTimer)
	{
		window.clearTimeout(closeTimer);
		closeTimer = null;
	}
		
}
function mclose()
{
	if(currentLayer && noClose!=1)
	{
		currentLayer.style.display='none';
		currentLayerNum = 0;
		currentLayer = null;
	}
	else
	{
		noClose = 0;
	}
	currentLayer = null;
}
document.onclick = mclose;