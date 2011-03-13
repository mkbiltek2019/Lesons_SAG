<?php if (!defined('BASEPATH')) exit('No direct script access allowed');
class display_lib
{
    function UserInfoPage($name,$data)
    {
        $CI =& get_instance();
        //$CI->load->view($name."view",$data);
        $CI->load->view("page_view",$data);
        
    }
}

?>
