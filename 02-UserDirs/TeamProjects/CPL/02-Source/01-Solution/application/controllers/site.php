<?php

if (!defined('BASEPATH'))
    exit('No direct script access allowed');

class site extends CI_Controller {

    private $data;

    function __construct() {
        parent::__construct();

        $this->init();
    }

    function init() {
        $headerdata['data'] = '';
        $this->data['header'] = $this->load->view('header_view', $headerdata, true);

        $menudata['home'] = 'site/load/1';
        $menudata['catalog'] = 'site/load/2';
        $menudata['about'] = 'site/load/3';
        
        
        $this->data['menu'] = $this->load->view('menu_view', $menudata, true);

        $empty['empty'] = ''; //pass some data to default view
        $this->data['content'] = $this->load->view('default_view', $empty, true);

        $footerdata['data'] = 'data';
        $this->data['footer'] = $this->load->view('footer_view', $footerdata, true);
    }

    function index() {

        $this->load->view('site_view', $this->data);
    }

    function load($contentid) {
        switch ($contentid) {
            case 1: //home
                $contentdata['err'] = '';//default view hold aviable product data
                $this->data['content'] =
                        $this->load->view('default_view', $contentdata, true);
                break;
            case 2: //catalog for all products
                $contentdata['err'] = '';
                $this->data['content'] =
                        $this->load->view('content_view', $contentdata, true);

                break;
            case 3://about
                $contentdata['err'] = '';
                $this->data['content'] =
                        $this->load->view('about_view', $contentdata, true);
                break;
        }

        $this->index();
    }

}

/* End of file welcome.php */
/* Location: ./application/controllers/welcome.php */