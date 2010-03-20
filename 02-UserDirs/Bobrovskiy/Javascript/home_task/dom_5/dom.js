/*–еализовать сценарий, выполн€ющий переадресацию пользовател€
 на случайно выбранный из массива адрес. 
ћассив должен хранить не менее 10 адресов. ƒл€ каждого 
адреса напишите html страницу с рекламным объ€влением. */
//----------
var sites = Array("htmldocs\\anime.html", 
				 "htmldocs\\gold.html", 
				 "htmldocs\\nature.html", 
				 "htmldocs\\sand.html", 
				 "htmldocs\\mashrooms.html" ,
				 "htmldocs\\gold\\a1.html",
				 "htmldocs\\gold\\a2.html",
				 "htmldocs\\gold\\a3.html",
				 "htmldocs\\gold\\a4.html",
				 "htmldocs\\gold\\a5.html"
				 );
//----------
function redirect() {
	location.replace(sites[Math.round(Math.random()*10)]);
	
};