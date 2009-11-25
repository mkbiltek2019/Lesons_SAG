/*¬ качестве домашнего задани€ вам предстоит создать (спокойно!) фотогалерею.
 Ќа главной странице должен содержатьс€ список изображений. ѕри щелчке
 левой кнопки мыши на миниатюре в списке, увеличенное изображение загружаетс€ 
 в новом окне, которое не содержит никаких элементов управлени€, кроме стандартных
 (заголовок и рамки). –азмеры окна подберите экспериментально, при условии, 
 что все изображени€ должны иметь одинаковый размер, например - 400х300 px.

ѕри наведении на изображение в списке курсора мыши, в строке состо€ни€ 
должна отображатьс€ информаци€ об увеличенном изображении - им€ файла, 
его размеры и объем в килобайтах (приближенно), например: picture001.jpg (400x300, 0.230 ). 
 */
//----------
var path;
var w1;
function op(pa,n) {
//-----
	 path = pa+n+".jpg";
	 w1 = window.open(path, "", "width=600, height=600, resizable=no"); 
	 //---
};
//----------		
function setStatus (pa,n) {
//----------	
	path = pa+n+".jpg";
	var newImg = new Image();
	newImg.src = path;
	var height = newImg.height;
	var width = newImg.width;
	var ox = newImg.sizeToContent;
	var sz = newImg.fileSize/1000+'kbytes';
	window.status='The image:'+n+'.jpg ' + '  size is: (' + width+'px ' + 'x' + height +'px)' + ' ' + sz; 
	//---
	//var h = document.getElementById('im'+n);
	//h.href = 'The image:'+n+'.jpg ' + '  size is: (' + width+'px ' + 'x' + height +'px)' + ' ' + sz; 
	//location.search = 'The image:'+n+'.jpg ' + '  size is: (' + width+'px ' + 'x' + height +'px)' + ' ' + sz; 
	return true;
};
//-----------
function getImgSize(imgSrc)
{

}
			