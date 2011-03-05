<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');
/**
 * Created by PhpStorm.
 * User: rasik
 * Date: 5 бер 2011
 * Time: 10:24:18
 * To change this template use File | Settings | File Templates.
 */
 
class login extends CI_Controller {
    function __construct()
	{
		parent::__construct();
	}

    function index()
    {
//        $this->load->view("login/page");
    }

    function authenticate()
    {
//        $this->form_validation->set_rules("userEmail", "email", "trim|required|valid_email");
//        $this->form_validation->set_rules("userPassword", "password", "trim|required");
//
//        if($this->form_validation->run())
//        {
//            echo "validation passed";
//        }
//        else
//        {
//            $this->load->view("login/page");
//        }
    }
}
