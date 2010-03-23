/*
Реализовать простейший вариант теста, поочередно выдавая пользователю вопросы, 
требующие односложных ответов ("Да" и "Нет"). После 
прохождения теста вывести результат. Вопросы и оценки за каждый вопрос 
хранить в сценарии в виде массивов. 
*/
var question = new Array("Is it true 2+2=4","Is it true 1+2=4","Is it true 2+3=5","Is it true 2+1=4","Is it true 5+2=7");
var result = new Array(1,0,1,0,1);
//----
function testUser() {
var i = 0;
var res = 0;

 for(i = 0; i < question.length; ++i) {
    var r = parseInt(confirm(question[i]) == true ? 1 : 0);	
	  r == result[i] ? ++res : --res;
     
  }//for
  
   alert("Your test result is:" + res);
 
//----
}
