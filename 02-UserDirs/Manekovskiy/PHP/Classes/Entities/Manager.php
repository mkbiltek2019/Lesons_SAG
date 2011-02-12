<?php

include_once "Person.php";

class Manager extends Person
{
    private $department;
    private $salary;
    function __construct($salary)
    {
        // TODO: добавить проверку на тип в аргументе $department
        if(is_numeric($salary))
        {
            parent::__construct("She, whose name is not even whispered", 1);
            $this -> salary = $salary;
        }
        else
        {
            // throw new ArgumentException()
        }
    }

    function __get($fieldName)
    {
        if($fieldName == "salary")
        {
            return $this -> salary;
        }
    }

    function setDepartment($department)
    {
        $this -> department = $department;
    }

    function hire($newEmployee)
    {
        $this -> department -> employees[$newEmployee -> id] = $newEmployee;
    }

    function fire($oldEmployee)
    {
        unset($this -> department -> employees[$oldEmployee -> id]);
    }
}
?>