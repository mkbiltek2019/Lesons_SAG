using System;

namespace Lesson_04
{
    public class Scientist : Employee, I_Researcher, I_Inferior
    {
        #region I_Researcher Members
            void I_Researcher.Investigate()
            {
                throw new NotImplementedException();
            }

            void I_Researcher.Invent()
            {
                throw new NotImplementedException();
            }
        #endregion

        #region I_Inferior Members
            event EventHandler I_Inferior.WorkEnded
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }

            bool I_Inferior.IsWorking
            {
                get { throw new NotImplementedException(); }
            }

            object I_Inferior.Work()
            {
                throw new NotImplementedException();
            }
        #endregion
    }
}
