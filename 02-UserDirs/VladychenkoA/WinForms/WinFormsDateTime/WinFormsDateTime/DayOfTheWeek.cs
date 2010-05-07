using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsDateTime
{
    public enum DayOfWeek { Воскресение, Понедельник, Вторник, Среда, Четверг, Пятница, Субота, None }
    class DayOfTheWeek
    {
        public string Day(DayOfWeek type)
        {
            return type.ToString();
        }
    }
}
