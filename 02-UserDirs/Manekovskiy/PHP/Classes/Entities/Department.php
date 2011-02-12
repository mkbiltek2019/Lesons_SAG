<?php
/**
 * Created by PhpStorm.
 * User: rasik
 * Date: 12 лют 2011
 * Time: 12:20:36
 * To change this template use File | Settings | File Templates.
 */
 
class Department
{
    private $name;
    private $employees;
    private $manager;

    function __construct($name, $employees, $manager)
    {
        // TODO: добавить проверки на типы в массиве и в аргументе $manager
        if(is_string($name) &&
           is_array($employees) &&
           is_object($manager))
        {
            $this -> name = $name;
            $this -> employees = $employees; // TODO: заполнить $this -> employees ассоциациями id => employee
            $this -> manager = $manager;
            
            $this -> manager -> setDepartment($this); // IoC!
        }
    }

    function getEmployees()
    {
        return $this -> employees;
    }
}
