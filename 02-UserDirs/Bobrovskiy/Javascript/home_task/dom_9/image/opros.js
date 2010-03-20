/*						Zavdanna
В качестве домашнего задания предлагаю написать несложный HTML тест.
 Вопросы и ответы теста можно хранить в виде массивов. Выдавать 
 пользователю вопросы можно по одному, а можно и все сразу. После 
 того, как пользователь прошел тест, необходимо запросить у него имя и 
 поздравить с окончанием теста. Результат вывести в диалоговом окне в виде 
 "Поздравляем, Имя! Тест сдан на Балл из Максимум.". Результаты теста 
 и имя пользователя запомнить в cookies. 
При следующей попытке пройти тест, предварительно вывести на экран 
результат предыдущей попытки. 
Количество попыток ограничить 5-ю. 
*/
//-----------------------------------------------------------
//-----------------------------------------------------------
var testSum = 0;
var addnum = 5;
var maxresult = 45;
//----------------
var testtry  = 1;
var maxtrycount = 5;
//----------------
var userName = new String();
//-----------------
var start = false;
//------ dropdown window start-------
var visible = true;
//--
function getElement(id) {
	return document.getElementById(id);
}
function testShow(id) {
	getElement(id).style.visibility = 'visible';
	visible = true;	
}
function testHide(id) {
	getElement(id).style.visibility = 'hidden';
	visible=false;		
}
function hideTestOnLoad(id) {  
//------clear all data-----
	for(var i=1; i<=4; ++i) {//ch_0_
	  var el = getElement('ch_0_'+i);
		el.checked = false;
	}
	//------------
	for(var j=1; j<=3; ++j) {
	for(var i=1; i<=5; ++i) {
	   var el = getElement('ch_'+j+'_'+i);
		el.checked = false;
	}
	}
	//-------------
	for(var i=1; i<=7; ++i) {//ch_4_
	  var el = getElement('ch_4_'+i);
		el.checked = false;
	}
//----------- 
	if(!start) {
		testHide(id);	
	}
}
//-------- dropdown window end-------
//-----------------
function getCookieValue (name) {
    var cookieValue = document.cookie;
    var r = new RegExp("\\b"+name+"\\b");
    var cookieStart = cookieValue.search(r);
    if (cookieStart == -1) 
        cookieValue = null;
    else {
        cookieStart = cookieValue.indexOf("=", cookieStart) + 1;
        var cookieEnd = cookieValue.indexOf(";", cookieStart);
        if (cookieEnd == -1)
            cookieEnd = cookieValue.length;
        cookieValue = unescape(cookieValue.substring(cookieStart, cookieEnd));
    }
    return cookieValue;
}
//-----------------
function getPrevResult() {
//----
 var value = getCookieValue("TestResult");
   if ( value == null) {
    alert ("Для корректной работы сайта включите поддержку cookies\nи перезагрузите страницу!");
  } else {
	//-----
	var a = new Array(2);
    a = value.split(";");
	alert('Спроба № '+a[2]+' : '+a[0]+' результат: '+a[1]);	
	testtry = a[2];
  }			
}
//-----------------
function startTest() {
//------------------
	 getPrevResult();
	if(testtry <= maxtrycount) {
		userName = prompt("Введіть ваше ім'я:"," ");	
		testShow('button_start');
		
		if((userName!=null)&&(userName.length > 2)) {
			testShow('test_table');
			testHide('button_start');
			start = true;
		} else {
			alert("Name, too short! ");
		}		
		
	} else {
		alert("Ви використали ліміт спроб \n проходження тесту!");
	}
}
//------------------
//------------------
function Q1() {
//------
var mgood = 2;
var count = 0;
//------
	for(var i=1; i<=4; ++i) {//ch_0_
	  var el = getElement('ch_0_'+i);
		if((i==1)&&(el.checked==true)) {
			testSum += addnum; 
			++count;
		} else	if((i==3)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==2)&&(el.checked==true))	testSum -= 1;	
		if((i==4)&&(el.checked==true))	testSum -= 1;
	}//for
	//---------------
	for(var i=1; i<=4; ++i) {//ch_0_
	  var el = getElement('ch_0_'+i);
		el.checked = false;
	}
	//---------------
	if(count == mgood) {testSum += 1;}
	 testHide('button1');
	 testHide('answer_1');
	if(testSum < 0) testSum = 0;
	// alert(testSum);//11
}
//------------------
//------------------
function Q2() {
//------
var mgood = 1;
var count = 0;
//------
	for(var i=1; i<=5; ++i) {//ch_1_
	  var el = getElement('ch_1_'+i);
		if((i==3)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==1)&&(el.checked==true))	testSum -= 1;
		if((i==2)&&(el.checked==true))	testSum -= 1;	
		if((i==4)&&(el.checked==true))	testSum -= 1;
		if((i==5)&&(el.checked==true))	testSum -= 1;		
	}//for
	//---------------
	for(var i=1; i<=5; ++i) {//ch_0_
	  var el = getElement('ch_1_'+i);
		el.checked = false;
	}
	//---------------
	if(count == mgood) {testSum += 1;}
	 testHide('button2');
	 testHide('answer_2');
	if(testSum < 0) testSum = 0;
	// alert(testSum);//17
}
//------------------
//------------------
function Q3() {
//------
var mgood = 1;
var count = 0;
//------
	for(var i=1; i<=5; ++i) {//ch_2_
	  var el = getElement('ch_2_'+i);
		if((i==5)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==1)&&(el.checked==true))	testSum -= 1;
		if((i==2)&&(el.checked==true))	testSum -= 1;	
		if((i==3)&&(el.checked==true))	testSum -= 1;
		if((i==4)&&(el.checked==true))	testSum -= 1;		
	}//for
	//---------------
	for(var i=1; i<=5; ++i) {//ch_2_
	  var el = getElement('ch_2_'+i);
		el.checked = false;
	}
	//---------------
	if(count == mgood) {testSum += 1;}
	 testHide('button3');
	 testHide('answer_3');
	if(testSum < 0) testSum = 0;
	 //alert(testSum);//23
}
//------------------
//------------------
function Q4() {
//------
var mgood = 1;
var count = 0;
//------
	for(var i=1; i<=5; ++i) {//ch_3_
	  var el = getElement('ch_3_'+i);
		if((i==3)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==1)&&(el.checked==true))	testSum -= 1;
		if((i==2)&&(el.checked==true))	testSum -= 1;	
		if((i==5)&&(el.checked==true))	testSum -= 1;
		if((i==4)&&(el.checked==true))	testSum -= 1;		
	}//for
	//---------------
	for(var i=1; i<=5; ++i) {//ch_3_
	  var el = getElement('ch_3_'+i);
		el.checked = false;
	}
	//---------------
	if(count == mgood) {testSum += 1;}
	 testHide('button4');
	 testHide('answer_4');
	if(testSum < 0) testSum = 0;
	// alert(testSum);//29
}
//------------------
//------------------
function Q5() {
//------
var mgood = 3;
var count = 0;
//------
	for(var i=1; i<=7; ++i) {//ch_4_
	  var el = getElement('ch_4_'+i);
		if((i==1)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==4)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==6)&&(el.checked==true)) {
			testSum += addnum;
			++count;
		} 
		if((i==2)&&(el.checked==true))	testSum -= 1;
		if((i==3)&&(el.checked==true))	testSum -= 1;	
		if((i==5)&&(el.checked==true))	testSum -= 1;
		if((i==7)&&(el.checked==true))	testSum -= 1;		
	}//for
	//---------------
	for(var i=1; i<=7; ++i) {//ch_4_
	  var el = getElement('ch_4_'+i);
		el.checked = false;
	}
	//---------------
	if(count == mgood) {testSum += 1;}
	 testHide('button5');
	 testHide('answer_5');
	if(testSum < 0) testSum = 0;
	 //alert(testSum);//45
}
//------------------
function setCookie(name, val, expMonth) {
    var cook = name+"="+escape(val)+";";
    if (expMonth != 0) {
        var d = new Date();
        d.setMonth(d.getMonth()+expMonth);
        cook+="expires="+d.toUTCString()+";";    
    }
    document.cookie = cook;
}
//------------------
function Result() {
	if(start) {
	var oneper = 100/maxresult;
	  var el = getElement('tres');
	  el.innerText = "Ви здали тест на :"+Math.ceil(testSum*oneper)+"%";
	//-------	
	++testtry;
	var val = ' '+userName + ';' + Math.ceil(testSum*oneper) + ';' + testtry;
	//-------
	setCookie("TestResult",val, 0);
	start = false;
	} else {
		alert('Розпочніть спочатку тест!');
	}
}
//------------------
