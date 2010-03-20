/*В качестве домашнего задания вам предлагается 
"написать свой браузер"! В чем это будет заключаться? На web-странице
 размещается 2 фрейма. В верхнем фрейме создать форму, обеспечивающую 
 следующие возможности: 
ввод адреса 
загрузка страницы в нижний фрейм или новое окно 
переход назад и вперед по истории страниц нижнего фрейма 
повторная загрузка страницы в нижнем фрейме 
Ниже представлен примерный внешний вид формы: 
*/
//----------
var sitehist = new Array();
var currenturl = new String();
//-------
function setCurrentUrl() {
	currenturl = form1.elements["textfield"].value;
}
function getCurrentUrl() {
	return currenturl;
}
function loadCurrnetUrl() {
	parent.frames["bottomFrame"].location.replace(getCurrentUrl());
}
function loadCurrentUrlinNewWindow() {
	window.open(getCurrentUrl(),"_blank");
}
//-------
function Op() {
	if (!form1.elements["checkbox"].checked) {
		setCurrentUrl();
	     loadCurrnetUrl();
	      sitehist.push(getCurrentUrl());
	  }
	else {
		setCurrentUrl();
	     loadCurrentUrlinNewWindow();
		  sitehist.push(getCurrentUrl());
	  }
}
//---
function Forward() {
	form1.elements["textfield"].value = sitehist.shift();
	 sitehist.push(form1.elements["textfield"].value);
	 
	 parent.frames["bottomFrame"].location.replace(form1.elements["textfield"].value);	
}
//---
function Back() {
   form1.elements["textfield"].value = sitehist.pop();
     sitehist.unshift(form1.elements["textfield"].value);
	 
	parent.frames["bottomFrame"].location.replace(form1.elements["textfield"].value);	
}
//----------
