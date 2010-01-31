using System;
using System.Collections.Generic;

namespace Lesson_04
{
    class ListOfEmployers
    {
        private List<Employee> listOfEmployers = new List<Employee>();
        Employee this[int index]
        {
            get { return listOfEmployers[index]; }
            set { listOfEmployers[index] = value; }
        }
    }
}
