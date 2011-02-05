<?php
	include("first.htm");
	include("vocfunc.php");
	if($word !=""){	
		if($transl == "rus"){
			echo "<h3 style=\"color:#778899\">Результаты поиска:<br><br>";
			if(ereg("^[а-яА-ЯёЁ]{1,}$",$word)){
				rusQuery($word);
			}else echo "Введите русское слово !";
		}	
		else if($transl == "eng"){
			echo "<h3 style=\"color:#778899\">Seaching result:</h3>";
			if(ereg("^[[:alpha:]]{1,}$",$word)){
				engQuery($word);
			}else echo "Input english word please!";
		}else echo "Something wrong";
	}else echo "Пожалуйста, введите слово";
	echo "</h3>";
?>
