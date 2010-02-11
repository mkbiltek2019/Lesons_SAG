using System;

namespace Lesson_5_Delegate_E1
{
    class Program
    {
        private struct Person
        {
            public String FirstName;
            public String LastName;
            public DateTime BirthDay;

            public Person(String firstName, String lastName, DateTime birthDay)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.BirthDay = birthDay;
            }

            public override String ToString()
            {
                return String.Format("Имя: {0}; Фамилия: {1}; Дата рождения: {2:d}.", FirstName, LastName, BirthDay);
            }

            public static String GetTypeName() { return "Человек"; }
        }

        private delegate string GetAsString();

        static void Main(string[] args)
        {
            DateTime birthDay = new DateTime(1978, 2, 15);
            Person person = new Person("Иван", "Петров", birthDay);

            GetAsString getStringMethod = new GetAsString(birthDay.ToLongDateString);
            Console.WriteLine(getStringMethod());

            getStringMethod = person.ToString;
            Console.WriteLine(getStringMethod());

            getStringMethod = Person.GetTypeName;
            Console.WriteLine(getStringMethod());
        }
    }
}
