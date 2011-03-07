<?php
/**
 * Created by PhpStorm.
 * User: rasik
 * Date: 5 бер 2011
 * Time: 11:43:32
 * To change this template use File | Settings | File Templates.
 */
 
class authentication_model extends CI_Model {
    function validate_user(array $options)
    {
        $testUser = "test@test.com";
        $testPassword = md5("test");

        if($options["userEmail"] == $testUser &&
           md5($options["userPassword"]) == $testPassword)
        {
            return true;
        }

        return false;
    }
}
