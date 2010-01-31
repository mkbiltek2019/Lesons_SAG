using System;
using System.Collections.Generic;

namespace Lesson_04
{
    public sealed class Tutor : Human //, I_Researcher
    {
        public void Teach()
        {
            // Do something
        }

        //void I_Researcher.Investigate()
        //{
        //    // Do something
        //}

        //void I_Researcher.Invent()
        //{
        //    // Do something
        //}

        private List<Learner> listOfLearners;
        public List<Learner> ListOfLearners
        {
            get { return listOfLearners; }
        }
    }
}
