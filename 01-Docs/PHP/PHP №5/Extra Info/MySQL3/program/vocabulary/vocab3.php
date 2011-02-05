<?php

include("third.htm");
include ("vocfunc.php");

if(isset($add)){
	Addform();	
}
if(isset($plus)){
	Add($plus);
}
if(isset($hide)){
	if(isset($aword)){
		if(isset($trans)){
			AddFunc($hide, $aword, $trans);
		}
		else echo "<h3 style='color:#778899'>Введите значение слова!</h3>";
	}
	else echo "<h3 style='color:#778899'>Введите слово!</h3>";
}
if(isset($del)){
	Delform();
}
if(isset($word)){
		Del($word);
}
if(isset($transmis)){
	AddMean($aword, $trans, $lang);
}
if(isset($otransmis)){
	AddWord($aword, $trans, $lang);
}

function Addform(){
?>
<h2 align="center" style="color:#778899">Добавить:</h2>
<form action="vocab3.php" method="post">
<table align="center">
<tr>
	<td align="right"><input type="radio" name="plus" value="nw" checked></input></td>
	<td>новое слово</td>
</tr><tr>
	<td align="right"><input type="radio" name="plus" value="nm"></input></td>
	<td>новое значение существующего слова</td>
</tr><tr>
	<td colspan="2" align="center"><input type="submit" value="Добавить"  style="BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899; "></input></td>
</tr>
</table></form>
<?php
}

function Add($plus){
	if($plus == "nw"){?>
<h2 align="center" style="color:#778899">Добавление нового слова:</h2>
<form action="vocab3.php" method="post">
<input type="Hidden" name="hide" value="nw"></input>
<table align="center">
<tr>
	<td>Введите новое слово</td>
	<td><input type="text" name="aword"></input></td>
</tr>
	<td>Введите значение слова</td>
	<td><input type="text" name="trans"></input></td>
<tr>
	<td colspan="2" align="center"><input type="submit" value="Добавить" style="BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899; "></input></td>
</tr>
</table></form>	
<?php
	}
	else 
	if($plus == "nm"){?>
<h2 align="center" style="color:#778899">Добавление значения:</h2>
<form action="vocab3.php" method="post">
<input type="Hidden" name="hide" value="nm"></input>
<table align="center">
<tr>
	<td>Введите слово</td>
	<td><input type="text" name="aword"></input></td>
</tr>
	<td>Введите перевод</td>
	<td><input type="text" name="trans"></input></td>
<tr>
	<td colspan="2" align="center"><input type="submit" value="Добавить"  style="BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899; "></input></td>
</tr>
</table></form>	
<?php
	}
}

function AddFunc($hide, $aword, $trans){
	if( !(ereg("^[а-яА-ЯёЁ]{1,}$",$aword)) && (ereg("^[[:alpha:]]{1,}$",$trans))){
		if( !(ereg("^[[:alpha:]]{1,}$",$aword)) && (ereg("^[а-яА-ЯёЁ]{1,}$",$trans))){
		echo "<h3 style='color:#778899'>Язык слова и его значения должны быть различны!</h3>";
		return;
		}
	}
	$lang = "eng";
	if(ereg("^[а-яА-ЯёЁ]{1,}$",$aword)){
		$lang = "rus";
	}
	if($hide=="nw"){
		AddWord($aword, $trans, $lang);
	}
	if($hide == "nm"){
		AddMean($aword, $trans, $lang);
	}
}

function Delform(){
?>
<h2 align="center" style="color:#778899">Удалить:</h2>
<form action="vocab3.php" method="post">
<table align="center">
<tr>
	<td>Введите слово</td>
	<td><input type="text" name="word"></input></td>
	<td><input type="submit" value="Удалить"></input></td>
</tr>
</table></form>
<?php
}

function Del($word){
	Delform();
	echo "<h3 style='color:#778899'>Результаты удаления:</h3>";
	if(ereg("^[а-яА-ЯёЁ]{1,}$",$word)){
		DelRus($word);
	}
	else if(ereg("^[[:alpha:]]{1,}$",$word)){
		DelEng($word);
	}
	else echo "<h3 style='color:#778899'>Введите слово!</h3>";
}
?>