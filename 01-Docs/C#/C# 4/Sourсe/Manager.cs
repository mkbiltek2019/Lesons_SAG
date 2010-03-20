using System;
using System.Collections.Generic;

namespace Lesson_04
{
    public class Manager : Employee, I_Manager
    {
        private List<I_Inferior> listOfInferiors;

        #region I_Manager Members
            List<I_Inferior> I_Manager.ListOfInferiors
            {
                get { return listOfInferiors; }
            }

            void I_Manager.Plan() 
            {
                // Plan
            }

            void I_Manager.Organize()
            {
                // Organize
            }

            void I_Manager.Motivate()
            {
                // Motivate
            }

            void I_Manager.Control()
            {
                // Control
            }

            void I_Manager.MakeBudget()
            {
                // MakeBudget       
            }
        #endregion
    }
}
