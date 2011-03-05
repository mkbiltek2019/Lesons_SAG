<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class main extends CI_Controller {

	function __construct()
	{
		parent::__construct();
	}

	function index()
	{
        $this -> load -> model("authentication_model");
//echo $this->input->post["userEmail"];
        $this->form_validation->set_rules("userEmail", "email", "trim|required|valid_email");
        $this->form_validation->set_rules("userPassword", "password", "trim|required");

        if($this->form_validation->run())
        {
            if($this->authentication_model->validate_user(array(
                "userEmail" => $this->input->post['userEmail'],
                "userPassword" => $this->input->post['userPassword']
            )))
            {
                $this->session->set_userdata("UserEmail", $this->input->post["userEmail"]);

                $data["userEmail"] = $this->session->userdata["UserEmail"];
                $this->load->view("welcome/page", $data);
            }
        }
        else
        {
            $this->load->view("login/page");
        }
	}
}

/* End of file index.php */
/* Location: ./application/controllers/index.php */