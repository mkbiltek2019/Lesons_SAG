using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    class SpeedOutMaxSpeed : Exception
    {
        private string message;

        public string Message
        {
            get;
            set;
        }

        public SpeedOutMaxSpeed(string message)
        {
            this.Message = message;
        }
    }
}
