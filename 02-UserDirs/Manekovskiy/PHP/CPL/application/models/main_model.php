<?php
/**
 * Created by PhpStorm.
 * User: rasik
 * Date: 26 лют 2011
 * Time: 12:01:27
 * To change this template use File | Settings | File Templates.
 */
 
class main_model extends CI_Model {
    function getAllProducts()
    {
        $query = $this -> db -> get("Products");
        if($query -> num_rows() > 0) {
            foreach($query -> result() as $row) {
                $data[] = $row;
            }
        }
        $query -> free_result();

        return $data;
    }
}
