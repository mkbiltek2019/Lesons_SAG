/*
	Перевірка користувацького вводу
*/
//------------------0---------------------
function result(id,regexp) {	
	 var elem = document.getElementById(id);
	  return regexp.test(elem.value); 
}
//------------------1---------------------
function checkName(id) {
//------ function check pib
	var regexp = /^[а-яА-Яіїє^ы^ё^Ё^Э^э]{2,40}\s[а-яА-Яіїє^ы^ё^Ё^Э^э]{2,40}\s[а-яА-Яіїє^ы^ё^Ё^Э^э]{2,40}$/; 
	 return result(id,regexp);
}
//------------------2---------------------
function checkBirthDay(id) {
//------ function check birthday
	var regexp = /^\d{2}['.']{1}\d{2}['.']{1}\d{4}$/; 
	return result(id,regexp);
}
//------------------3---------------------
function checkPassport(id) {
//------ function check Passport number
	var regexp = /^[А-ЯЫІЇЁЄЭA-Z]{2}[' ']{1}[0-9]{6}$/; 
	return result(id,regexp);
}
//------------------4---------------------
function checkPhone(id) {
//------ function check phone number
	var regexp = /^['(']{1}\d{3}[')']{1}\s{1}\d{2}\s{1}\d{2}\s{1}\d{3}$/; 
	return result(id,regexp);
}
//------------------5---------------------
function checkMail(id) {
//------ function check e-mail check
	var regexp = /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i; 
	return result(id,regexp);
}
//------------------6---------------------
function checkSite(id) {
//------ function check Site
	var regexp =/^(((http(s?))|(ftp))\:\/\/)?(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk|ua|ru|pl)$/; 
	return result(id,regexp);
}
//------------------7---------------------
function checkPhones(id) {
//------ function check Phones
	var regexp = /^(['(']{1}\d{3}[')']{1}\s{1}\d{2}\s{1}\d{2}\s{1}\d{3}[';']{1}\s{0,1}){1,3}$/i; 
	return result(id,regexp);
}
//------------------8---------------------
function checkLogin(id) {
//------ function check Login
	var regexp = /^\w{5,15}$/; 
	return result(id,regexp);
}
//------------------9---------------------
function checkPasswd(id) {
//------ function check Passwd
	var regexp = /^\w{5,15}$/; 
	return result(id, regexp);
}
//------------------10--------------------
function checkFiscal(id) {
//------ function check Fiscal
	var regexp = /^\d{10}$/; 
	return result(id, regexp);
}
//------------------11--------------------
function checkPasswd2(id){
//------ function check Passwd2
	var regexp = /^\w{5,15}$/; 
	return result(id, regexp);
}
//-----------------12----------
function equalPasswords(id1, id2) {
	var el1 = document.getElementById(id1);
	var el2 = document.getElementById(id2);
	if(el1.value==el2.value) return 1;
	else return 0;
}
//---------------------------------------
function setBad(id) {
	var elem = document.getElementById(id);
		 elem.style.color = "#EA0202";
	return 0;
}
//----------------------
function setGood(id) {
	var elem = document.getElementById(id);
		  elem.style.color = "#272727";
		return 1;
}
//---------------------------------------
function checkData() {
//--------
	var b=1;
		//--------1----
		if(!checkName("pib")) b = b * setBad("pib");
		else b = b * setGood("pib");		
		//------2------
		if(!checkBirthDay("birthday")) b = b * setBad("birthday");
		else b = b * setGood("birthday");	
		//------3------
		if(!checkPassport("passport")) b = b * setBad("passport");
		else b = b * setGood("passport");
		//------4------
		if(!checkPhone("telephone")) b = b * setBad("telephone");
		else b = b * setGood("telephone");
		//------5------
		if(!checkMail("mail")) b = b * setBad("mail");
		else b = b * setGood("mail");
		//------6------
		if(!checkSite("siteaddress")) b = b * setBad("siteaddress");
		else b = b * setGood("siteaddress");
		//------7------
		if(!checkPhones("telephones")) b = b * setBad("telephones");
		else b = b * setGood("telephones");
		//------8------
		if(!checkLogin("login")) b = b * setBad("login");
		else b = b * setGood("login");
		//------9------
		if(!checkPasswd("passwd")) b = b * setBad("passwd");
		else b = b * setGood("passwd");
		//------10-----
		if(!checkPasswd2("passwdcheck")) b = b * setBad("passwdcheck");
		else b = b * setGood("passwdcheck");
		//------11-----
		if(!checkFiscal("fiscal")) b = b * setBad("fiscal");
		else b = b * setGood("fiscal");
		//-------12------
		if(!equalPasswords("passwd","passwdcheck")) b = b * setBad("passwd")*setBad("passwdcheck");
		else b = b * setGood("passwd")* setGood("passwdcheck");
		//---------------
	return b;	
}
//-------------------------------------
function SendData() {
	if(checkData()==1) {
		return true;
	} else {
		alert("У введених даних знайдено помилку!!!");		
	}
}