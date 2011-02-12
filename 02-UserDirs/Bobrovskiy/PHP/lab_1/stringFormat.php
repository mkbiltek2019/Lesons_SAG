<html>
	<head>
		<title>Домашня робота до другого уроку</title>
		<meta http-equiv="Content-Type"
              content="text/html; charset=windows-1251" />

<body>
   <?php
   
        function ResolveFullUrl($virtualPath)
        {
            return "http://".$_SERVER["SERVER_NAME"].":".$_SERVER["SERVER_PORT"].$virtualPath;
        }

        function btnStringFormat_Click()
        {
           $_POST[lblResultStringFormat] = "Salo";
        }
$_POST[lblResultStringFormat] = "Salo";
        function StringFormat()
        {

        }
   ?> 

<form method="GET" action="stringFormat.php">
<fieldset>
            <h3>Some kind of string format function</h3>
            <input name="input1" type="text" /><br/>
            <input name="input2" type="text" /><br/>
            <input name="input3" type="text" /><br/>
            <input name="input4" type="text" /><br/>
            <input name="input5" type="text" /><br/>
            <input name="input6" type="text" /><br/>
        </fieldset>
        <button id="btnStringFormat" type="submit" onclick="<?php btnStringFormat_Click()?>" >String Format</button>
        <label id="lblResultStringFormat" name="lbRes">rr:</label>
</form>

</body>
</html>