<?php if (!defined('BASEPATH')) exit('No direct script access allowed');

class product_catalog_model extends crud

{
    public $table = 'category';
    public $idkey ='1';


   function getCategoryAll()
   {
       $table='category';
       $query=$this->db->get($table);
       return $query->result_array;

   }
    function getByProductId($categoryID)
    {
        $table='product';
        $this->db->where('categoryid',$categoryID);
        $query=$this->db->get($table);
        return $query->result_array;
    }

}
?>

 
