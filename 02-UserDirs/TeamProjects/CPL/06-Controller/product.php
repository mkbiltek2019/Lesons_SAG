<?php if (!defined('BASEPATH')) exit('No direct script access allowed');

class product extends CI_Controller
{
    function __construct()
    {
        parent::__construct();
    }
    function index()
    {
        
        $data = array();
        $data["categoryAll"] = $this->product_catalog_model->getCategoryAll();
        $data["productByID"]=$this->product_catalog_model->getByProductId();


        if(empty($data['categoryAll']))
        {
            $data["info"] = "This page does not exist";
            $name="Info";
            $this->display_lib->UserInfoPage($name,$data);


        }else
        {
            $name="ProductCatalog/content";
            $this->display_lib->UserInfoPage($name,$data);
        }


    }

}
?>
