using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ2ObjectsSample
{
    class Employee
    {
        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public DateTime Birthday
        {
            get;
            set;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employee Ivan = new Employee()
            {
                Name = "Ivan",
                Surname = "Popov",
                Birthday = new DateTime(1945, 12, 1)
            };
            Employee Vasiliy = new Employee()
            {
                Name = "Vasiliy",
                Surname = "Petrov",
                Birthday = new DateTime(1995, 1, 16)
            };
            Employee Petro = new Employee()
            {
                Name = "Petro",
                Surname = "Petrov",
                Birthday = new DateTime(1800, 2, 1)
            };
            Employee Dunkan = new Employee()
            {
                Name = "Dunkan",
                Surname = "Maklaud",
                Birthday = new DateTime(1700, 5, 1)
            };

            IEnumerable<Employee> employees = new List<Employee>(new[] { Ivan, Vasiliy, Petro, Dunkan });

            IEnumerable<Employee> petrovs = employees.Where(x => x.Surname == "Petrov");
        }
    }
}
