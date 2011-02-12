<?php

class Person
{
    private $name;
    private $id;

    function __construct($name, $id)
    {
        if(is_string($name) &&
           is_int($id))
        {
            $this -> name = $name;
            $this -> id = $id;
        }
        else
        {
            // TODO: throw new ArgumentException(...)
        }
    }

    function __get($fieldName)
    {
        if($fieldName == "id")
            return $this -> id;
        if($fieldName == "name")
            return $this -> name;
        if($fieldName == "age")
            return "not set";
    }

    function __set($fieldName, $fieldValue)
    {
        if($fieldName == "id")
        {
            if(is_int($fieldValue))
                $this -> id = $fieldValue;
            else
            {
                // TODO: throw new ArgumentException()
            }
        }
        if($fieldName == "name")
        {
            if(is_string($fieldValue))
                $this -> name = $fieldValue;
            else
            {
                // TODO: throw new ArgumentException()
            }
        }
    }

    function getId()
    {
        return $this -> id;
    }

    function getName()
    {
        return $this -> name;
    }
}

?>
 
