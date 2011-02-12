<?php
        echo "Ternal operator begin";
        $one = 1;
        $two = 2;
        $three = 3;
        $result = $one == 1? "1" :
                    ($two == 2 ? "2" : "3");
        echo $result;

        $result = $one == 1? "1" :
                    $two == 2 ? "2" : "3";
        echo $result;

        $result = $one == 1 ?
                        "1" :
                        $two == 2 ?
                            $three == 3 ?
                                    "2" :
                                    "3"
                            : "4";
        echo $result;
   echo "Ternal operator end";
?>