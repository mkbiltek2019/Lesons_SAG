<?php
function connection( ){
	if(! mysql_connect("localhost")){
		echo "Sorry!";
		exit;
	}	
	if(! mysql_select_db("vocabulary")){
		echo mysql_error( );
	}
}
function rusQuery($word){
	echo "<h3 style=\"color:darkblue\"><b><u>".$word."</u></b><br>";
	connection();
	$query = "select russian.id from russian where word=\"".$word."\"";
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "Извините, такого слова в словаре нет";
		return;
	}
	if($temp = mysql_fetch_row($qres)){
		echo "MAMA MIA!!!";
		return;
	}	
	$query ="select matches.id_eng from matches where id_rus=".$arrayres[0];
	$qres = mysql_query($query);	
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "Извините, перевода этого слова в словаре нет";
		return;
	}
	echo "<i><ul type=square> ";
	do{
		$query = "select english.word from english where english.id=".$arrayres[0];
		$q = mysql_query($query);
		if(!($r = mysql_fetch_row($q))){
			echo mysql_error();
			return;
		}
		echo "<li>".$r[0]."</li>";
	}while($arrayres = mysql_fetch_row($qres));
	echo "</ul></i></h3>";
	mysql_close();
}
function engQuery($word){
	connection();
	echo "<h3 style=\"color:darkblue\"><b><u>".$word."</u></b><br>";
	$query = "select id from english where word=\"".$word."\"";
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "Sorry, can't find this word";
		return;
	}
	if($temp = mysql_fetch_row($qres)){
		echo "MAMA MIA!!!";
		return;
	}	
	$query ="select id_rus from matches where id_eng=".$arrayres[0];
	$qres = mysql_query($query);	
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "Sorry, can't find this word in dictionary";
		return;
	}
	echo "<i><ul type=square>";
	do{
		$query = "select word from russian where id=".$arrayres[0];
		$q = mysql_query($query);
		if(!($r = mysql_fetch_row($q))){
			echo mysql_error();
			return;
		}
		echo "<li>".$r[0]."</li>";
	}while($arrayres = mysql_fetch_row($qres));
	echo "</ul></i></h3>";
	mysql_close();
}
function DelRus($word){
	connection();
	echo "<h3 style=\"color:darkblue\">Слова <u>".$word."</u> <br>";
	$query = "select id from russian where word=\"".$word."\"";
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "<br>Такого слова нет";
		return;
	}
	else echo "удалено<br>";
	$id_eng = $arrayres[0];
	$query = "delete from russian where id=".$id_eng;
	$qres = mysql_query($query);
	$query = "select id_eng from matches where id_rus=".$id_eng;
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		return;
	}
	$index = 0;
	do{
		$query = "select count(*) from matches where id_rus=".$arrayres[0];
		$qr = mysql_query($query);
		$arres = mysql_fetch_row($qr);
		if($arres[0] == 1){
			$arnum[$index] = $arrayres[0];
			$index++;
		}
	}while($arrayres = mysql_fetch_row($qres));
	
	for($i = 0; $i < count($arnum); $i++){
		$query = "select word from english where id=".$arnum[$i];
		$qres = mysql_query($query);
		if(!($arrayres = mysql_fetch_row($qres))){
			return;
		}
		echo "Слово <u> ".$arrayres[0]."</u> удалено. <br></br>";
		$query = "delete from english where id=".$arnum[$i];
		mysql_query($query);
	}
	$query = "delete from matches where id_rus=".$id_eng;
	mysql_query($query);
	echo "</h3><h3 style='color:#778899'>Удаление завершено.</h3>";
	mysql_close();
}
function DelEng($word){
	connection();
	echo "<h3 style=\"color:darkblue\">Word  <u>".$word."</u>  ";
	$query = "select id from english where word=\"".$word."\"";
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		echo "<br>Sorry, can't find this word";
		return;
	}
	else echo " is deleted<br>";
	$id_eng = $arrayres[0];
	$query = "delete from english where id=".$id_eng;
	$qres = mysql_query($query);
	$query = "select id_rus from matches where id_eng=".$id_eng;
	$qres = mysql_query($query);
	if(!($arrayres = mysql_fetch_row($qres))){
		return;
	}
	$index = 0;
	do{
		$query = "select count(*) from matches where id_eng=".$arrayres[0];
		$qr = mysql_query($query);
		$arres = mysql_fetch_row($qr);
		if($arres[0] == 1){
			$arnum[$index] = $arrayres[0];
			$index++;
		}
	}while($arrayres = mysql_fetch_row($qres));
	
	for($i = 0; $i < count($arnum); $i++){
		$query = "select word from russian where id=".$arnum[$i];
		$qres = mysql_query($query);
		if(!($arrayres = mysql_fetch_row($qres))){
			return;
		}
		echo "Word <u>".$arrayres[0]."</u>  is deleted. <br></br>";
		$query = "delete from russian where id=".$arnum[$i];
		mysql_query($query);		
	}
	$query = "delete from matches where id_eng=".$id_eng;
	mysql_query($query);
	echo "</h3><h3 style='color:#778899'>Deleting is finnished successfully.</h3>";
	mysql_close();
}

function AddWord($aword, $trans, $lang){
	connection();
	$match = 0;
	$matchw = 0;
	$matchm = 0;
	if($lang == "rus"){
		$query = "select * from russian where word=\"".$aword."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchw = 1;
		}
		$query = "select * from english where word=\"".$trans."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchm = 1;
		}
	}
	if($lang == "eng"){
		$query = "select * from english where word=\"".$aword."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchw = 1;
		}
		$query = "select * from russian where word=\"".$trans."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchm =1;
		}
	}
	if($matchw==1){
		if($matchm==1) $match = 1;
		else $match=2;
	}
	else{
		if($matchm==1) $match = 3;
	}
	if($match==1){
			echo "<h3 style='color:#778899'>Такое слово с идентичным переводом в словаре есть</h3>";
			return;
	}else
	if($match==2){
		 echo "<h3 style='color:#778899'>Такое слово в словаре есть, но идентичного перевода нет. <br> Хотите добавить перевод?</h3>";
		echo "<form action=\"vocab3.php\" method=\"post\"><input type=\"Hidden\" name=\"aword\" value=".$aword."></input><input type=\"Hidden\" name=\"trans\" value=".$trans."></input><input type=\"Hidden\" name=\"lang\" value=".$lang."></input><input type=\"submit\" name=\"transmis\" value=\"Добавить перевод\"style=\"BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899;\"></input></form>";
		return;
	}
	if($match==3){
		if($lang=="eng") $lang="rus";
		else $lang="eng";
		echo "<h3 style='color:#778899'>Такого слова в словаре есть, но перевод данного слова существует <br> Хотите добавить слово?</h3>";
		echo "<form action=\"vocab3.php\" method=\"post\"><input type=\"Hidden\" name=\"aword\" value=".$trans."></input><input type=\"Hidden\" name=\"trans\" value=".$word."></input><input type=\"Hidden\" name=\"lang\" value=".$lang."></input><input type=\"submit\" name=\"transmis\" value=\"Добавить перевод\"style=\"BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899;\"></input></form>";
		return;
	}
	if($match == 0){
		if($lang == "rus"){
			$query = "insert into russian(id, word) values(NULL, '".$aword."')";
			mysql_query($query);
			$query = "select id from russian where word=\"".$aword."\"";
			$qres = mysql_query($query);
			$arrayres1 = mysql_fetch_row($qres);
			$query = "insert into english (id, word) values (NULL, '".$trans."')";
			mysql_query($query);
			mysql_close();
			connection();
			$query = "select id from english where word='".$trans."'";
			$qres = mysql_query($query);
			$arrayres2 = mysql_fetch_row($qres);
			$query = "insert into matches (id, id_rus, id_eng) values (NULL, ".$arrayres1[0].", ".$arrayres2[0].")";
			mysql_query($query);
			echo  "<h3 style='color:#778899'>Cлово и его перевод добавлены в словарь</h3>";
		}
		if($lang == "eng"){
			$query = "insert into english(id, word) values(NULL, '".$aword."')";
			mysql_query($query);
			$query = "select id from english where word=\"".$aword."\"";
			$qres = mysql_query($query);
			$arrayres1 = mysql_fetch_row($qres);
			$query = "insert into russian (id, word) values (NULL, '".$trans."')";
			mysql_query($query);
			mysql_close();
			connection();
			$query = "select id from russian where word='".$trans."'";
			$qres = mysql_query($query);
			$arrayres2 = mysql_fetch_row($qres);
			$query = "insert into matches (id, id_rus, id_eng) values(NULL,".$arrayres2[0].", ".$arrayres1[0].")";
			mysql_query($query);
			echo  "<h3 style='color:#778899'>Cлово и его перевод добавлены в словарь</h3>";
		}
	}
	mysql_close();
}

function AddMean($aword, $trans, $lang){
	connection();
	$match = 0;
	$matchw = 0;
	$matchm = 0;
	if($lang == "rus"){		
		$query = "select * from english where word=\"".$trans."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchm = 1;
		}
		$query = "select * from russian where word=\"".$aword."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchw = 1;
		}		
	}
	if($lang == "eng"){
		$query = "select * from russian where word=\"".$trans."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchm = 1;
		}
		$query = "select * from english where word=\"".$aword."\"";
		$qres = mysql_query($query);
		if($arrayres=mysql_fetch_row($qres)){
			$matchw = 1;
		}
	}
	if($matchw==1){
		if($matchm==1) $match =2;
		else $match=1;
	}
	else{
		if($matchm==1) $match = 3;
	}
	if($match==2){
			echo "<h3 style='color:#778899'>Такое слово с идентичным переводом в словаре есть</h3>";
			return;
	}else
	if($match==0){
		 echo "<h3 style='color:#778899'>Такого слова в словаре нет. <br> Хотите добавить новое слово?</h3><form action=\"vocab3.php\" method=\"post\"><input type=\"Hidden\" name=\"aword\" value=".$aword."></input><input type=\"Hidden\" name=\"trans\" value=".$trans."></input><input type=\"Hidden\" name=\"lang\" value=".$lang."></input><input type=\"submit\" name=\"otransmis\" value=\"Добавить перевод\"style=\"BACKGROUND-COLOR: #d3d3d3; BORDER-COLOR: #778899;\"></input></form>";
		return;
	}
	if($match==3){
		$temp = $aword;
		$aword=$trans;
		$trans = $temp;
		if($lang=="eng") $lang="rus";
		else $lang="eng";
		$match = 1;
	}
	if($match == 1){
		if($lang == "rus"){
			$query = "select id from russian where word=\"".$aword."\"";
			$qres = mysql_query($query);
			$arrayres1 = mysql_fetch_row($qres);
			$query = "insert into english (id, word) values (NULL, '".$trans."')";
			mysql_query($query);
			$query = "select id from english where word='".$trans."'";
			$qres = mysql_query($query);
			$arrayres2 = mysql_fetch_row($qres);
			$query = "insert into matches (id, id_rus, id_eng) values(NULL, '".$arrayres1[0]."',' ".$arrayres2[0]."')";
			mysql_query($query);
			echo  "<h3 style='color:#778899'>Перевод cлова добавлен в словарь</h3>";
		}
		if($lang == "eng"){
			$query = "select id from english where word=\"".$aword."\"";
			$qres = mysql_query($query);
			$arrayres1 = mysql_fetch_row($qres);
			$query = "insert into russian (id, word) values (NULL, '".$trans."')";
			mysql_query($query);
			$query = "select id from russian where word='".$trans."'";
			$qres = mysql_query($query);
			$arrayres2 = mysql_fetch_row($qres);
			$query = "insert into matches (id, id_rus, id_eng) values(NULL, ".$arrayres2[0].", ".$arrayres1[0].")";
			mysql_query($query);
			echo  "<h3 style='color:#778899'>Перевод cлова добавлен в словарь</h3>";
		}
	}
	mysql_close();	
}
?>