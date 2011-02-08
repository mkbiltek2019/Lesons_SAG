<html>
	<head>
		<title>Домашня робота до другого уроку</title>
		<meta http-equiv="Content-Type"
              content="text/html; charset=windows-1251" />

<body>
   
    <form action="result.php" method="post" >
    
       <table border="1">
        <thead><tr><td>№ продукту</td><td>Ціна</td><td>Кількість</td></tr></thead>
        <tr><td>Товар №1</td>
            <td><input name="price1"
                       readonly="readonly"
                       type="text"
                       value="0,8" />
            </td>
            <td><input name="productQuantity1" type="text" /></td>
        </tr>
        <tr><td>Товар №2</td>
            <td><input name="price2"
                       readonly="readonly"
                       type="text"
                       value="1,8" /></td>
            <td><input name="productQuantity2" type="text" /></td>
        </tr>
        <tr><td>Товар №3</td>
            <td><input name="price3"
                       readonly="readonly"
                       type="text"
                       value="2,8" /></td>
            <td><input name="productQuantity3" type="text" /></td>
        </tr>
        <tr><td>Товар №4</td>
            <td><input name="price4"
                       readonly="readonly"
                       type="text"
                       value="3,8" /></td>
            <td><input name="productQuantity4" type="text" /></td>
        </tr>
        <tr><td>Товар №5</td>
            <td><input name="price5"
                       readonly="readonly"
                       type="text"
                       value="4,8" /></td>
            <td><input name="productQuantity5" type="text" /></td>
        </tr>
        <tr><td>Товар №6</td>
            <td><input name="price6"
                       readonly="readonly"
                       type="text"
                       value="5,8" /></td>
            <td><input name="productQuantity6" type="text" /></td>
        </tr>
        <tr><td><input type="submit" name="submit_button" value="Результат"/></td></tr>
    </table>
    </form>


</body>
</html>