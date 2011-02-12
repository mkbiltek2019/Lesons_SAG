<html>
<head>

</head>
<body>
    <?php
        include_once "TernarOperator.php";
        include "libraries/functionsLibrary.php";

        echo $globalVar."\n";

        $counter = funcWithStaticVariable();
        echo $counter."\n";
    ?>
</body>
</html>
