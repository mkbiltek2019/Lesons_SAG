using System;

namespace Lesson_04
{
    class Example_BaseClass
    {
        void CreateTutorTeam(Tutor tutor)
        {
            // Создаем команду учеников
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            Student student4 = new Student();
            Schoolchild schoolchild1 = new Schoolchild();
            Schoolchild schoolchild2 = new Schoolchild();

            student1.FirstName = "Иван";
            student2.FirstName = "Петр";
            student3.FirstName = "Сергей";
            student4.FirstName = "Максим";
            schoolchild1.FirstName = "Дима";
            schoolchild2.FirstName = "Саша";

            // Заносим учеников в список
            tutor.ListOfLearners.Add(student1);
            tutor.ListOfLearners.Add(student2);
            tutor.ListOfLearners.Add(student3);
            tutor.ListOfLearners.Add(student4);
            tutor.ListOfLearners.Add(schoolchild1);
            tutor.ListOfLearners.Add(schoolchild2);

            // Дальше можно работать со списком ListOfLearners
            // как со списком объектов типа Learner
        }
    }
}
