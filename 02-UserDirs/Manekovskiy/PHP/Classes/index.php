<html>
<head>

</head>
<body>
    <?php

    function  printAllEmployees($employees)
    {
        foreach($employees as $employee)
        {
            echo "Id : ".$employee -> id."\n"."Name : ".$employee -> name."\n";
        }
    }

    include_once "Entities\Person.php";
    include_once "Entities\Employee.php";
    include_once "Entities\Manager.php";
    include_once "Entities\Department.php";

    $ivan = new Person("vano", 111);
//        $ivan -> id = 111123;
//        $ivan -> name = "vano";

    echo $ivan -> getName()."\n";
    echo $ivan -> getId()."\n";

    echo $ivan -> __get("name")."\n";
    echo $ivan -> __get("id")."\n";

    $ivanSalary = $ivan -> __get("salary")."\n";
    $ivanAge = $ivan -> age."\n"; // неявно вызывает функцию __get
    echo "ivan has salary :".$ivanSalary;
    echo "ivan has age :".$ivanAge;

    $he = new Employee();
    $hisResult = $he -> work(true);
    echo "Он работал весь день и результат: ".$hisResult."\n";

    $she = new Manager(10000000);
    $herSalary = $she -> salary;
    echo "Она не работала весь день и ее зарплата: ".$herSalary."\n";

    $employees = array();
    $department = new Department("IT", $employees, $she);

    $she -> hire($ivan);
    $allEmployees = $department -> getEmployees();
    printAllEmployees($allEmployees);

    $she -> hire($he);
    $allEmployees = $department -> getEmployees();
    printAllEmployees($allEmployees);

    $she -> fire($he);
    $allEmployees = $department -> getEmployees();
    printAllEmployees($allEmployees);

    ?>

</body>
</html>
 
