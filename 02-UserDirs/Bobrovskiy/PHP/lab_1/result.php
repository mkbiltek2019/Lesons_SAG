<html>
<head></head>
<body>
 <h2>Ваші результати</h2>
<?php
 
  if($_POST[submit_button])
  {
      $productQuantityControlNameStart = "productQuantity";
      $productPriceControlNameStart = "price";
      $dot = ".";
      $comma = ",";
      $maxCount = 6;
      $startPosition = 1;
      $productQuantity = 0;
      $unicProduct = 0;
      $orderPrice = 0.0;

      for($i=$startPosition; $i<=$maxCount; $i++)
      {
          $productQTmp = $_POST[$productQuantityControlNameStart.$i];
          $productPrice = $_POST[$productPriceControlNameStart.$i];

         if($productQTmp && $productPrice)
         {             
              if(is_int($productQTmp)&&($productQTmp>0))
              {
                  $unicProduct++;                  
              }

            $productQuantity += $productQTmp;

            $goodDouble = str_replace($comma,$dot,$productPrice);
            $orderPrice += $productQTmp*$goodDouble;

            $productQTmp =0;
            $productPrice = 0;
         }          
      }

      echo "Дякую. Ви придбали ".$productQuantity
              ." товарів ( ".$unicProduct." види) на суму "
              .$orderPrice;
  }

?>

<form action="index.php" method="post">
    <input type="submit" name="return" value="Повернутись" />
</form>

</body>
</html>

 
