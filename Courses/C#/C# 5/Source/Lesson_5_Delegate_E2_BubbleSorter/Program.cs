using System;

namespace Lesson_5_Delegate_E2_BubbleSorter
{
    class Program
    {

        public delegate Boolean Comparer(Object elem1, Object elem2);

        static class BubbleSorter
        {
            static public void Sort(Object[] array, Comparer comparer)
            {
                for (Int32 i = 0; i < array.Length; i++)
                    for (Int32 j = i + 1; j < array.Length; j++)
                        if (comparer(array[j], array[i]))
                        {
                            Object buffer = array[i];
                            array[i] = array[j];
                            array[j] = buffer;
                        }
            }
        }

        public struct Person
        {
            public String FirstName;
            public String LastName;
            public DateTime Birthday;

            public Person(String firstName, String lastName, DateTime birthday)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Birthday = birthday;
            }

            public override String ToString()
            {
                return String.Format(
                    "Имя: {0,-10} Фамилия: {1,-10} Дата рождения: {2:d}.",
                    FirstName, LastName, Birthday);
            }
        }

        static public Boolean PersonBirthdayComparer(Object person1, Object person2)
        {
            return ((Person)person1).Birthday < ((Person)person2).Birthday;
        }

        static void Main(string[] args)
        {
            Person p0 = new Person("Максим", "Орлов", new DateTime(1989, 5, 12));
            Person p1 = new Person("Иван", "Иванов", new DateTime(1985, 7, 21));
            Person p2 = new Person("Петр", "Петров", new DateTime(1991, 3, 1));
            Person p3 = new Person("Федор", "Федоров", new DateTime(1971, 11, 25));
            Person p4 = new Person("Павел", "Козлов", new DateTime(1966, 8, 6));

            Object[] persons = { p0, p1, p2, p3, p4};

            Console.WriteLine("\nНесортированный список:");
            foreach (Object person in persons) Console.WriteLine(person);

            Console.WriteLine("\nСортированный список:");
            BubbleSorter.Sort(persons, new Comparer(PersonBirthdayComparer));
            foreach (Object person in persons) Console.WriteLine(person);

            Console.WriteLine("\n");
        }
    }
}
