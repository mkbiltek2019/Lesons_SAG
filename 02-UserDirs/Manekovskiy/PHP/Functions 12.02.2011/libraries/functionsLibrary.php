<?php

include_once "TernarOperator.php";

function voidFunction()
{
    return;
}

$result = voidFunction();
echo $result == null."<br/>";

function paramsFunction()
{
    $arguments = func_get_args();
    foreach($arguments as $argument)
    {
        echo $argument;
    }
}

paramsFunction("hello", "<br/>", 1, "<br/>", true);

function funcWithStaticVariable()
{
    static $counter = 0;
    $counter++;
    return $counter;
}

$result = funcWithStaticVariable();
echo $result."\n";
$result = funcWithStaticVariable();
echo $result."\n";
$result = funcWithStaticVariable();
echo $result."\n";

function funcWithGlobalVariable()
{
    global $globalVar;

    $globalVar = "globalvar на связи!";
}
funcWithGlobalVariable();

echo $globalVar."\n";
//unset($globalVar);
//echo $globalVar."\n";   // Будет ошибка если раскомментировать

define("MAXSIZE", 100);
echo MAXSIZE;
echo constant("MAXSIZE"); // same thing as the previous line

$привет = "Фывфывфыв";
echo $привет."\n";

call_user_func("paramsFunction", "reflection exists!", "\n");
call_user_func("paramsFunction", array("asd", 1));
?>
