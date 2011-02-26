<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class index extends CI_Controller {

	function __construct()
	{
		parent::__construct();
	}

	function index()
	{
        $this -> load -> model("index_model");

        $data["products"] = $this -> index_model -> getAllProducts();
        $data["helloMessage"] = "Hello world";

		$this->load->view('index_view', $data);
	}
}

/* End of file index.php */
/* Location: ./application/controllers/index.php */