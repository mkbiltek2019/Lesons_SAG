using System;
using System.Collections.Generic;

namespace Lesson_04
{
    public abstract class Learner : Human , I_Inferior
    {
        protected Boolean isWorking = false;

        public virtual void Study()
        {
            // Studing
        }

        public override void Work()
        {
            this.isWorking = true;

            this.Study();

            this.isWorking = false;
        }

        #region I_Inferior Members
            event EventHandler I_Inferior.WorkEnded
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }

            bool I_Inferior.IsWorking
            {
                get { return isWorking; }
            }

            object I_Inferior.Work()
            {
                this.isWorking = true;

                object result = new object();

                this.Study();

                // Make result 

                this.isWorking = false;
                return result;
            }
        #endregion

        protected List<String> subjectList;
        public List<String> SubjectList
        {
            get { return subjectList; }
        }
    }
}
