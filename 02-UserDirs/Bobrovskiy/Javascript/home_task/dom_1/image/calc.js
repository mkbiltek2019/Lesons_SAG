<!--
/*------------number input-------------------*/	
//------ dropdown window -------
var visible = true;

function showHideCalc(id) {		
	var element = document.getElementById(id);
	var button_text = document.getElementById('id_show_calc');		
	if(visible) {
	    element.style.visibility = 'collapse';
		visible=false;		
		button_text.value = "show";
	} else {
		element.style.visibility = 'visible';
		visible=true;
		button_text.value = "hide";
	}
}
//--------
function hideCalcOnLoad(id) {
    var element = document.getElementById(id);
	element.style.visibility = 'collapse';
	visible=false;	
}
//------------------------------
//------global------
var plus = true;
var coma = false;
var operation = "";
var memoryNumber = 0;
var fNumber = 0, sNumber = 0;
//---- simple number input ----------------
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
    mainedit.value=mainedit.value + '8';
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
//---- end of simple number input ---------
//--- backspace button ------
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
//=== add operation and remember number==
function remember_fNumber(mainedit) {
   if(!isNaN(mainedit.value)) {
	    fNumber = parseFloat(mainedit.value);
	} else {
	    fNumber = 0;  
	}
    mainedit.value = "";	
}
//---
function remember_sNumber(mainedit) {
     if(!isNaN(mainedit.value)) {
	    sNumber = parseFloat(mainedit.value);	
	} else {
	    sNumber = 0;  
	}
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
function intNumber(mainedit) {
     var tmp = new String(fNumber);
	 var end = tmp.indexOf(".");	
	 tmp = tmp.substr(0, end);
  	return tmp;
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
		
	}
	//---- clear operation----
	operation='';
}
//----------end of output result-----------
//=========================================


// -->



