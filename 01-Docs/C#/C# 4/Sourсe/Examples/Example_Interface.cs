using System;

namespace Lesson_04
{
    class Example_Interface
    {

        public void CreateListOfInferiors()
        {
            I_Manager manager = new Manager();

            Scientist scientist1 = new Scientist();
            scientist1.FirstName = "Bill";

            Specialist specilist1 = new Specialist();
            specilist1.FirstName = "Saimon";

            Specialist specilist2 = new Specialist();
            specilist2.FirstName = "Andrew";

            manager.ListOfInferiors.Add(scientist1);
            manager.ListOfInferiors.Add(specilist1);
            manager.ListOfInferiors.Add(specilist2);

            // теперь независимо от конкретного типа, реализующего интерфес,
            // можно работать с членами интерфейса,
            // реализация которых инкапсулирована конкретными типами
            foreach (I_Inferior employee in manager.ListOfInferiors)
                if (!employee.IsWorking) employee.Work();
        }
    }
}
