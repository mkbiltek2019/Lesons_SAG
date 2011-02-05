<html>
<head></head>
<body>

    <?php
        $integer = 1;
        $double = 3.14;
        $string = "string";
        $bool = true;
        $null = null;

        echo $integer." is integer = ".is_integer($integer)."<br/>";
        echo $double." is double = ".is_double($double)."<br/>";
        echo $string." is string = ".is_string($string)."<br/>";
        echo $bool." is bool = ".is_bool($bool)."<br/>";
        echo $null." is null = ".is_null($null)."<br />";

        $array = array("one", "two", "three", "four");
        $array = array(1 => "one", 2 => "two", 3 => "three", "чотири" => "four");

        echo "array: "."<br />";
        foreach($array as $arrayElement)
        {
            echo $arrayElement."<br />";
        }

        echo '$array["чотири"] = '.$array["чотири"]."<br />";
        echo 'is_null($array["чотири"]) = '.is_null($array["чотири"])."<br />";

        $personInfo = array("Alex", "Manekovskiy", ".NET Developer", "Tsygan", "I.", "Manager");
        while(list($key, $value) = each($personInfo))
        {
            echo "key = ".$key." value = ".$value."<br />";
        }
        echo "reset array before using list() = each()!"."<br/>";
        reset($array);
        while(list($key, $value) = each($array))
        {
            echo "key = ".$key." value = ".$value."<br />";
        }

        $twoDimensionalArray = array(array(1, 2, 3, 4, 5), array("A", "B", "C", "D", "E"));
        for($i = 0; $i < count($twoDimensionalArray); $i++)
        {
            echo "\$twoDimensionalArray[$i] = ".$twoDimensionalArray[$i]."<br />";
            for($j = 0; $j < count($twoDimensionalArray[$i]); $j++)
            {
                echo "\t\$twoDimensionalArray[$i][$j] = ".$twoDimensionalArray[$i][$j]."<br />";                
            }
        }

        echo "print_r(\$twoDimensionalArray)"."<br />";
        print_r($twoDimensionalArray);
        echo "<br />";

        echo "var_dump(\$personInfo)"."<br />";
        var_dump($personInfo);
    ?>

</body>

</html>