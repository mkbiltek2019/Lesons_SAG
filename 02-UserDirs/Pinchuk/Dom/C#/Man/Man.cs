using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Man
{
    class Man
    {
        public List<Student> ListStudent { get; set; }
        public List<School> ListSchool { get; set; }
        public List<Teacher> ListTeacher { get; set; }
        public List<Accountant> ListAccountant { get; set; }
        public Man()
        {
            ListStudent = new List<Student>();
            ListSchool = new List<School>();
            ListTeacher = new List<Teacher>();
            ListAccountant = new List<Accountant>();
        }
        public void CreateListStudent(Man man, string str)
        {
            int count;
            Console.Write("Enter the number :");
            count = int.Parse(Console.ReadLine());
            switch (str)
            {
                case "STUDENT":
                    Student[] st = new Student[count];
                    for (int i = 0; i < count; i++)
                    {
                        st[i] = new Student();
                        Console.Write("Enter Name Student № {0} :", i);
                        st[i].Name = Console.ReadLine();
                        Console.Write("Enter LastName Student № {0} :", i);
                        st[i].LastName = Console.ReadLine();
                        Console.Write("Enter AverageBall Student № {0} :", i);
                        st[i].AverageBall = Console.ReadLine();
                        Console.Write("Enter YearBirth  Student № {0} :", i);
                        st[i].YearBirth = Console.ReadLine();


                        man.ListStudent.Add(st[i]);
                    }
                    break;
                case "TEACHER":
                    Teacher[] teacher = new Teacher[count];
                    for (int i = 0; i < count; i++)
                    {
                        teacher[i] = new Teacher();
                        Console.Write("Enter Name Teacher № {0} :", i);
                        teacher[i].Name = Console.ReadLine();
                        Console.Write("Enter Last Name Teacher № {0} :", i);
                        teacher[i].LastName = Console.ReadLine();
                        Console.Write("Enter Salary Teacher № {0} :", i);
                        teacher[i].Salary = Console.ReadLine();
                        Console.Write("Enter Name School № {0} :", i);
                        teacher[i].NameShool = Console.ReadLine();
                        man.ListTeacher.Add(teacher[i]);
                    }
                    break;
                case "ACCOUNTANT":
                    Accountant[] accountant =new Accountant[count];
                    for (int i = 0; i < count; i++)
                    {
                        accountant[i] = new Accountant();
                        Console.Write("Enter Name Accountant № {0} :", i);
                        accountant[i].Name = Console.ReadLine();
                        Console.Write("Enter Last Name Accountant № {0} :", i);
                        accountant[i].LastName = Console.ReadLine();
                        Console.Write("Enter Salary Accountant № {0} :", i);
                        accountant[i].Salary = Console.ReadLine();
                        Console.Write("Enter Name School № {0} :", i);
                        accountant[i].NameShool = Console.ReadLine();
                        man.ListAccountant.Add(accountant[i]);
                    }
                    break;
                default:
                    break;
            }

            Console.Clear();
        }
        public void DelIndex(Man man, string str)
        {
            int i = 0;
            Console.Write("\nEnter index for delete:");
            i = int.Parse(Console.ReadLine());
            try
            {
                switch (str)
                {

                    case "STUDENT":                        
                            man.ListStudent.RemoveAt(i);
                            Print.Proces("DELETE");                     
                        break;
                    case "TEACHER":
                            man.ListTeacher.RemoveAt(i);
                            Print.Proces("DELETE");
                            break;
                    case "ACCOUNTANT":
                            man.ListAccountant.RemoveAt(i);
                            Print.Proces("DELETE");                            
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Print.Wait();
            }

        }
        public void Edit(Man man, string str)
        {
            int i = 0;
            Console.Write("\nEnter index for edit:");
            i = int.Parse(Console.ReadLine());
            try
            {
                switch (str)
                {
                    case "STUDENT":
                        Console.Write("\nEnter new Name:");
                        man.ListStudent[i].Name = Console.ReadLine();
                        Console.Write("\nEnter new LasyName:");
                        man.ListStudent[i].LastName = Console.ReadLine();
                        Console.Write("\nEnter new AverageBall:");
                        man.ListStudent[i].AverageBall = Console.ReadLine();
                        Console.Write("\nEnter new YearBirth:");
                        man.ListStudent[i].YearBirth = Console.ReadLine();
                        break;
                    case "TEACHER":
                        Console.Write("\nEnter new Name:");
                        man.ListTeacher[i].Name = Console.ReadLine();
                        Console.Write("\nEnter new LasyName:");
                        man.ListTeacher[i].LastName = Console.ReadLine();
                        Console.Write("\nEnter new Salary:");
                        man.ListTeacher[i].Salary = Console.ReadLine();
                        Console.Write("\nEnter new Scholl Name:");
                        man.ListTeacher[i].NameShool = Console.ReadLine();
                        break;
                    case "ACCOUNTANT":
                        Console.Write("\nEnter new Name:");
                        man.ListAccountant[i].Name = Console.ReadLine();
                        Console.Write("\nEnter new LasyName:");
                        man.ListAccountant[i].LastName = Console.ReadLine();
                        Console.Write("\nEnter new Salary:");
                        man.ListAccountant[i].Salary = Console.ReadLine();
                        Console.Write("\nEnter new Scholl Name:");
                        man.ListAccountant[i].NameShool = Console.ReadLine();
                        break;
                    default:
                        break;
                }
                
                

            }
            catch (Exception e)
            {
                Console.Write(e.Message);

            }
            Console.Clear();
        }
    }
}
