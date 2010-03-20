using System;

namespace Lesson_5_Events_E1
{
    class Program
    {
        public class Person
        {
            public event EventHandler WorkEnded;

            public String FirstName;
            public String LastName;
            public DateTime Birthday;

            public Person(String firstName, String lastName, DateTime birthday)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Birthday = birthday;
            }

            public void Work()
            {
                // Do something

                if (WorkEnded != null) WorkEnded(this, EventArgs.Empty);
            }
        }

        static void Main(string[] args)
        {
            Person person = new Person("Bill", "Gordon", new DateTime(1962, 8, 11));
            //person.WorkEnded += new EventHandler(Person_WorkEnded);
            person.WorkEnded += delegate(object sender, EventArgs e) 
            { Console.WriteLine("Работа выполнена !\n"); };
            person.Work();
        }

        static void Person_WorkEnded(object sender, EventArgs e)
        {
            Console.WriteLine("Работа выполнена !\n");
        }
    }
}
