/*
	В качестве домашнего задания создайте собственный вариант 
	фотоголереи, на основе примера №3.12. Обеспечте возможность 
	перехода непосредственно на любое изображение галереи, разместив 
	на странице список миниатюр изображений. Каждая такая миниатюра должна
	являться ролловером. Обеспечить предзагрузку всех изображений ролловеров
	(изображения галереи кешировать не надо). Оформите галерею исходя из 
	собственных эстетических соображений. 
*/
 var currentImage = 0, count = 0;
 //--------
 var path = new Array("images/gold/preview/1.jpg", "images/gold/preview/2.jpg", 
            "images/gold/preview/3.jpg", "images/gold/preview/4.jpg","images/gold/preview/5.jpg",
			"images/gold/preview/6.jpg","images/gold/preview/7.jpg","images/gold/preview/8.jpg");
//---------
var bigpath = new Array("images/gold/1.jpg", "images/gold/2.jpg", 
            "images/gold/3.jpg", "images/gold/4.jpg","images/gold/5.jpg",
			"images/gold/6.jpg","images/gold/7.jpg","images/gold/8.jpg");
//--------- 
var htmlPath = new Array("htmldocs/gold/a1.html", "htmldocs/gold/a2.html", 
            "htmldocs/gold/a3.html", "htmldocs/gold/a4.html","htmldocs/gold/a5.html",
			"htmldocs/gold/a6.html","htmldocs/gold/a7.html","htmldocs/gold/a8.html");
//=====================================================================================
 /*var path1 = new Array("images/gold/preview/1.jpg", "images/gold/preview/2.jpg", 
            "images/gold/preview/3.jpg", "images/gold/preview/4.jpg","images/gold/preview/5.jpg",
			"images/gold/preview/6.jpg","images/gold/preview/7.jpg","images/gold/preview/8.jpg");
//---------
var bigpath1 = new Array("images/gold/1.jpg", "images/gold/2.jpg", 
            "images/gold/3.jpg", "images/gold/4.jpg","images/gold/5.jpg",
			"images/gold/6.jpg","images/gold/7.jpg","images/gold/8.jpg");
//--------- 
var htmlPath1 = new Array("htmldocs/gold/a1.html", "htmldocs/gold/a2.html", 
            "htmldocs/gold/a3.html", "htmldocs/gold/a4.html","htmldocs/gold/a5.html",
			"htmldocs/gold/a6.html","htmldocs/gold/a7.html","htmldocs/gold/a8.html"); */
//---------
var img = new Array (8);
	
        // предзагрузка изображений галереи 
        for (var i=0; i < path.length; ++i) {
            img[i] = new Image (100, 76);
            img[i].src = path[i];			
            img[i].onload = countImages;
        } 
		info.innerText = "Готово!";
		//------------------
		function resett(){
			count = path.length;
			info.innerText = "Готово!";
		}
        // подсчет количества загруженных изображений и вывод информации 
        function countImages () {
			var elem  = document.getElementById("info");
            ++count;
            if (count == path.length)
                info.innerText = "Готово!";
            else			
                info.innerText = "Загрузка изображений: " + count + " из " + path.length;			
        }
		//---------------------
        function nextImage() {
            if (count != path.length) {
                alert ("Дождитесь пожалуйста загрузки всех изображений!");
                return;
            }		
            ++currentImage;
            if (currentImage == path.length) currentImage = 0;
			
            document.images["picture"].src = img[currentImage].src;
            return false;
        }
		//---------------------
		function changeImage(){
			 document.images["picture"].src = bigpath[currentImage];
		}
		//---------------------
		function smallImage(){
			document.images["picture"].src = img[currentImage].src;
		}	
		//---------------------
		function openInWindow(){
			var el = document.getElementById("imageLink");
			el.href = htmlPath[currentImage] ;
		}
		//---------------------
		function prevImage() {
			if (count != path.length) {
                alert ("Дождитесь пожалуйста загрузки всех изображений!");
                return;
            }		
            --currentImage;
            if (currentImage < 0) currentImage = path.length-1;
			
            document.images["picture"].src = img[currentImage].src;
            return false;
		}
		//---------------------
		
		
