using System;
using System.Collections.Generic;

namespace Lesson_04
{
    public interface I_Manager
    {
        List<I_Inferior> ListOfInferiors { get; }

        void Plan();

        void Organize();

        void Motivate();

        void MakeBudget();

        void Control();
    }
}
