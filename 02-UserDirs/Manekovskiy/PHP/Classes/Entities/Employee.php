<?php

include_once "Person.php";

class Employee extends Person
{
    function __construct()
    {
        parent::__construct("unnamed", 42);
    }
    /*
     * Эта функция запускает процесс работы у рядового сотрудника
     */
    function work($toDig)
    {
        return $toDig ? "deep hole" : "drink tea";
    }
}

?>
