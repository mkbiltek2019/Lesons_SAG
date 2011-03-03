<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US" xml:lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title> Chocopalnet </title>

    <link rel="stylesheet" href="<?php echo base_url().'style.css';?>" type="text/css" media="screen" />
    <!--[if IE 6]><link rel="stylesheet" href="<?php echo base_url().'style.ie6.css';?>" type="text/css" media="screen" /><![endif]-->
    <!--[if IE 7]><link rel="stylesheet" href="<?php echo base_url().'style.ie7.css';?>" type="text/css" media="screen" /><![endif]-->

    <script type="text/javascript" src="<?php echo base_url().'script.js';?>"></script>
</head>
<body>

<div id="art-page-background-glare">
    <div id="art-page-background-glare-image"></div>
</div>
    
<div id="art-main">
<div class="art-sheet">
<div class="art-sheet-tl"></div>
<div class="art-sheet-tr"></div>
<div class="art-sheet-bl"></div>
<div class="art-sheet-br"></div>
<div class="art-sheet-tc"></div>
<div class="art-sheet-bc"></div>
<div class="art-sheet-cl"></div>
<div class="art-sheet-cr"></div>
<div class="art-sheet-cc"></div>
<div class="art-sheet-body">

    <?php echo $header?>

    <?php echo $menu?>

    <?php echo $content?>
    <!-- sample
    <img alt="image"  
    src="<?php echo base_url().'productimages/Brick/big/'.'svDark.jpg';?>"/>
    -->
    <div class="cleared"></div>

    <?php echo $footer?>

    <div class="cleared"></div>
</div>
</div>
   <div class="cleared"></div>
   <p class="art-page-footer"></p>
</div>
    
</body>
</html>
