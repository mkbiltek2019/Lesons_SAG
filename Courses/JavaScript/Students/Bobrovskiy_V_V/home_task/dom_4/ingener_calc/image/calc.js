<!--
/*----------------------------------------------*/	
/*------------ Green Calculator ----------------*/
/*----------------------------------------------*/		
//------ dropdown window start-------
var visible = true;
function getButton() {
	return document.getElementById('id_show_calc');	
}
function getElement(id) {
	return document.getElementById(id);
}
function calcShow(id) {
	getElement(id).style.visibility = 'visible';
	visible = true;
	getButton().value = "hide";
}
function calcHide(id) {
	getElement(id).style.visibility = 'hidden';
	visible=false;		
	getButton().value = "show";
}
function showHideCalc(id) {		
	if(!visible) {
	    calcShow(id);
	} else {
		calcHide(id);
	}
}
function hideCalcOnLoad(id) {   
	calcHide(id);	
}
//-------- dropdown window end-------
//------global-----------------------
var plus = true;
var coma = false;
var operation = "";
var memoryNumber = 0;
var fNumber = 0, sNumber = 0;
//---- simple number input start-----
function push1(mainedit) {
    mainedit.value = mainedit.value + '1';
}
//---
function push2(mainedit) {
    mainedit.value = mainedit.value + '2';
}
//---
function push3(mainedit) {
    mainedit.value = mainedit.value + '3';
}
//---
function push4(mainedit) {
    mainedit.value = mainedit.value + '4';
}
//---
function push5(mainedit) {
    mainedit.value=mainedit.value + '5';
}
//---
function push6(mainedit) {
    mainedit.value = mainedit.value + '6';
}
//---
function push7(mainedit) {
    mainedit.value = mainedit.value + '7';
}
//---
function push8(mainedit) {
    mainedit.value = mainedit.value + '8';
}
//---
function push9(mainedit) {
    mainedit.value = mainedit.value + '9';
}
//---
function push0(mainedit) {
    mainedit.value = mainedit.value + '0';
}
//---
function pi(mainedit){
    mainedit.value = Math.PI;
}
//----simple number input end---------
//--- backspace button ---------------
function buttBack(mainedit) {
    var mod = new String(mainedit.value);	
        mainedit.value = mod.slice(0, mod.length-1);
	delete mod;
}
//----- add minus to inputed number---
function addMinus(mainedit) {
    var mod = new String(mainedit.value);
	if(plus&&(mod.indexOf("-") == -1)) {
	     mainedit.value = ("-" + mod);
         plus = false;	    
	}else if((!plus) && (mod.indexOf("-") != -1)) {
		      mainedit.value = mod.substr(1, mod.length);
              plus = true;
	} else {
		  mainedit.value = mod.substr(0, mod.length);
          plus = true;
	}	   
	delete mod;
}
//----add point to inputed number----
function addComa(mainedit) {
    var mod = new String(mainedit.value);
	var pos = mod.indexOf(".");		
        if(!coma) {
            mainedit.value = mainedit.value + ".";
            coma = true;
       } else if(pos == -1) {
	             coma = false; 
	   }  
	delete mod;
}
//------clear input------
function clearEdit(mainedit) {
    mainedit.value = "";
	operation = "";
}
//=== add operation and remember number ==
function checkAndSet(mainedit) {
	var tmpNum;
	if(!isNaN(mainedit.value)) {
	    tmpNum = parseFloat(mainedit.value);
	} else {
	    tmpNum = 0;  
	}
    return tmpNum;
}
function clearInput(mainedit) {
	mainedit.value = "";
}
//--
function remember_fNumber(mainedit) {   
	 fNumber = checkAndSet(mainedit);
	 clearInput(mainedit);	 
}
//---
function remember_sNumber(mainedit) {     
	 sNumber = checkAndSet(mainedit);	
}
//---
function getOperation(mainedit,element) {
    operation.clear;
    operation = element.value;
	remember_fNumber(mainedit);       	
}
//-------------- memory operation ----------------
function memoryStore(mainedit) {
    if(!isNaN(mainedit.value)) {
	    memoryNumber = parseFloat(mainedit.value);
	} else {
	    memoryNumber = 0;  
	}     
	 mainedit.value = "";
}
//--
function memoryRead(mainedit) {
      mainedit.value = String(memoryNumber); 
}
//--
function memoryClear(mainedit) {
    memoryNumber = 0;
}
//--
function memoryPlus(mainedit) {
    remember_fNumber(mainedit);
	memoryNumber = memoryNumber + fNumber;
}
//-------end of memory operation --------
//-------calculate result operation------
function addNumber(mainedit) {
    remember_sNumber(mainedit);
    return (fNumber + sNumber);
}
//--
function subNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber - sNumber);
}
//--
function divideNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber / sNumber);
}
//--
function multiplyNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber * sNumber);
}
//--
function modOfNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber % sNumber);
}
//--
function andNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber & sNumber);
}
//--
function orNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber | sNumber);
}
//--
function xorNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber ^ sNumber);
}
//--
function lshNumber(mainedit) {
    remember_sNumber(mainedit);
	return (fNumber << sNumber);
}
//--
function notNumber(mainedit) {
   	return (!fNumber);
}
//--
function intNumber(mainedit) {
     var tmp = new String(fNumber);
	 var end = tmp.indexOf(".");	
	 tmp = tmp.substr(0, end);
  	return tmp;
}
//--
function Sin(mainedit) {
	return Math.sin(fNumber);	
}
//--
function Cos(mainedit) {
	return Math.cos(fNumber);	
}
//--
function Tg(mainedit) {
	return Math.tan(fNumber);	
}
//--
function Sqrt(mainedit) {
	return Math.sqrt(fNumber);	
}
//--
function xPowy(mainedit) {
    remember_sNumber(mainedit);
	return Math.pow(fNumber , sNumber);
}
//--
function Ln(mainedit) {
	return Math.log(fNumber);	
}
//--
function Exp(mainedit) {
	return Math.exp(fNumber);	
}
//--
function xPow2(mainedit) {
	return Math.pow(fNumber,2);	
}
//--
function xPow3(mainedit) {
	return Math.pow(fNumber,3);	
}
//--
function Acos(mainedit) {
	return Math.acos(fNumber);	
}
//--
function Asin(mainedit) {
	return Math.asin(fNumber);	
}
//--
function Atan(mainedit) {
	return Math.atan(fNumber);	
}
//--
function Floor(mainedit) {
	return Math.floor(fNumber);	
}
//--
function Ceil(mainedit) {
	return Math.ceil(fNumber);	
}
//--
function Round(mainedit) {
	return Math.round(fNumber);	
}
//-------end of calculate result operation------
//----output result -----------------
function calc(mainedit) {
    switch(operation){
	    //-----1----
	    case '+' :{
		    mainedit.value = String(addNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		}break;
		//-----2----
		case '-' :
		    mainedit.value = String(subNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----3----
		case '/' :
		    mainedit.value = String(divideNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----4----
		case '*' :
		    mainedit.value = String(multiplyNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----5----
		case "Mod" :
		     mainedit.value = String(modOfNumber(mainedit));
		     sNumber=0;
		     fNumber=0;
		break;
		//-----6----
		case "And" :
		    mainedit.value = String(andNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----7----
		case "Or" :
		    mainedit.value = String(orNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----8-----
		case "Xor" :
		    mainedit.value = String(xorNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----9------
		case "Lsh" :
		    mainedit.value = String(lshNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//-----10------
		case "Not" :
		    mainedit.value = String(notNumber(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------11-----
		case "Int" :
		    mainedit.value = mainedit.value.substr(0,indexOf("."));
		    sNumber=0;
		    fNumber=0;
		break;
		//------12-------
		case "sin":
			mainedit.value = String(Sin(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------13-------
		case "cos":
			mainedit.value = String(Cos(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------14-------
		case "tg":
			mainedit.value = String(Tg(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------15---------
		case "sqrt":
			mainedit.value = String(Sqrt(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
	   //------16---------
		case "x^y":
			mainedit.value = String(xPowy(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------17---------
		case "ln":
			mainedit.value = String(Ln(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------18---------
		case "exp":
			mainedit.value = String(Exp(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------19---------
		case "x^2":
			mainedit.value = String(xPow2(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------20---------
		case "acos":
			mainedit.value = String(Acos(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------21---------
		case "asin":
			mainedit.value = String(Asin(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------22---------
		case "x^3":
			mainedit.value = String(xPow3(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------23---------
		case "atan":
			mainedit.value = String(Atan(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------24---------
		case "fl":
			mainedit.value = String(Floor(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------25---------
		case "ceil":
			mainedit.value = String(Ceil(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------26---------
		case "rnd":
			mainedit.value = String(Round(mainedit));
		    sNumber=0;
		    fNumber=0;
		break;
		//------------------		
	}
	//---- clear operation----
	operation='';
}
//----------end of output result-----------
//=========================================
// -->



