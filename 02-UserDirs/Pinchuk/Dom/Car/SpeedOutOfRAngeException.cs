using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
     public class SpeedOutOfRangeException:Exception
    {
         public string msg { get; set; }
         public SpeedOutOfRangeException(string message)
         {
             this.msg = message;
             
         }
    }
}
