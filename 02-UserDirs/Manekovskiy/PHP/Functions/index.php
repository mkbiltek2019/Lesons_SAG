<html>
<head>

</head>
<body>
    <?php $colors = array("red", "green", "blue", "magenta", "silver", "yellowgreen"); ?>
    <?php
        function ResolveFullUrl($virtualPath)
        {
            return "http://".$_SERVER["SERVER_NAME"].":".$_SERVER["SERVER_PORT"].$virtualPath;
        }

        function getOptions($items, $selectedItem)
        {
            for($i = 0; $i < count($items); $i++)
            {
                $selectedArgument = $items[$i] == $selectedItem ? "selected" : "";
                echo "<option $selectedArgument>".$items[$i]."</option>"."\n\t\t";
            }
        }
    ?>

    <form action="<?php echo ResolveFullUrl($_SERVER["PHP_SELF"]); ?>" method="GET">
        <?php var_dump($_GET); ?>
        <br />
        <?php var_dump($_SERVER); ?>
        <br />
        <span>Ваш выбор:</span><br />
        <select name="color">
            <?php getOptions($colors, $_GET["color"]); ?>
        </select>

        <input type="submit" />
    </form>
</body>
</html>
