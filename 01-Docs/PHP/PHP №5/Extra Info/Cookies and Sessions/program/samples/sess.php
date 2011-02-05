<?
   session_set_cookie_params(60*24*3);
   session_start();                     
   session_register("s"); 

//echo serialize(session_get_cookie_params())."<p>";

   if (isset($c) && $c=='clear') {
	session_unset();
      session_destroy();
      echo "clear...<p>";
      echo "<a href=sess.php>обновить страницу</a><p>";
      exit;
   }
   
   if (!isset($s['count'])) {
      $s['count']=0;
   }
   else $s['count']++;


   if(isset($name)){
   if (strlen($name)>1) $s['name']=$name;}

   if (!isset($s['name']))
      echo "Вы новый пользователь. Пожалуйста,
      введите ваше имя:
      <form action=sess.php><input type=text name=name>
      <input type=submit></form>";
   else 
      echo "Вы зарегистрированы под именем: $s[name].
	Вы посетили наш сайт $s[count]-й раз<p>";

	echo "<a href=sess.php>обновить страницу</a><p>";
   echo "<a href=sess.php?c=clear>обнулить идентификацию</a><p>";

?>