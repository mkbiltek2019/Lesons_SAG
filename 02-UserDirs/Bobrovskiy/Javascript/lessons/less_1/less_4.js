/* function MyFunction(element){
	debugger; //debug javascript
	gg
	document.write("<br></br><strong>Hello man</strong>");
}
*/
function MyFunction1(element){
	element.value="Kakaha1";	
}
//--------------------------
function MyFunction2(){
	var element=document.getElementById("mybutton2");	
	element.value="Kakaha2";	
	// element.value=element.value+"Kakaha n+1";		
}
//--------------------------
function MyFunction3(){
	var element=document.getElementById("mybutton3");	
	var d = 1 / 0;
	element.value=d;	
	// element.value=element.value+"Kakaha n+1";		
}
//---------
function MyFunction4(){
	var element=document.getElementById("mybutton5");	
	
	var ob=new Object();	
	var ob1=new Number();	
	var ob2=new Array();
	var ob3=new String();
	
	 ob2=[1,true,"text value"];
	var t=new String("text");
	t.charAt(i);
	t.length();
	//element.value=t;
	//element.value=ob2[0]+" "+ob2[1]+" "+ob2[2];	
}
//----------------
function MyFunction5(){
	var t = document.getElementById("edit1");	
	var mod = " ";
	var len = t.value.length;
	for(var i = 0; i<len; ++i){		
		mod=mod + t.value.charAt(i) + ',';
	}
	
	var t2 = mod.slice(0,mod.length-1);// .substr(0, mod.length-1);
	
	alert('text size= '+len+" | "+t2);
}