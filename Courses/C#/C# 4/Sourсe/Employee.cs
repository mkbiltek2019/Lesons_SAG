using System;
using System.Collections.Generic;

namespace Lesson_04
{
    public abstract class Employee : Human
    {
        protected Boolean isWorking = false;
        protected List<String> taskList;

        public Employee()
            : base()
        {
            this.taskList = new List<String>();

            // Create Employee object
        }

        public Employee(String FirstName, String MiddleName, String LastName)
            : base(FirstName, MiddleName, LastName)
        {
        }

        public Employee(String FirstName, String MiddleName, String LastName, DateTime Birthday)
            : base(FirstName, MiddleName, LastName, Birthday)
        {
        }



        public List<String> TaskList
        {
            get { return taskList; }
        }
        
        public override void Work()
        {
            if (this.isWorking)
            {
                throw new EmployeeIsBusyException("Employee is busy");
            }
            else
                if (VerificationResources())
                    try
                    {
                        this.isWorking = true;

                        base.Work();

                        // Do something

                        this.isWorking = false;
                    }
                    catch (Exception exception)
                    {
                        throw new ForceMajeureException("Force-majeure exception", exception);
                    }
                else
                {
                    throw new CrunchException("Verification resources failed");
                }
        }

        private Boolean VerificationResources()
        {
            Boolean verificationResult = true;

            // verification

            return verificationResult;
        }
    }
}
