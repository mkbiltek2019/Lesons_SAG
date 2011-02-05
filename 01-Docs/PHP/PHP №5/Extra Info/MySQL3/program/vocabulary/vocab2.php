<?php
	$passes = array("admin","step");
	$flag = true;
	for($i=0; $i < count($passes); ++$i){
		if($pas == $passes[$i]){
			$flag = true;
			break;
		}
		else $flag = false;	
	}
	if(!$flag){
		include ("second.htm");
		echo "<h3 style=\"color:#778899\">Вы ввели неправильный пароль!</h3>";
	}else {
		include ("third.htm");
	}
?>
