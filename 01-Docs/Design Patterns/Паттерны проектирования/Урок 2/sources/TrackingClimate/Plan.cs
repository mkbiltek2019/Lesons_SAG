using System;

namespace TrackingClimate
{
    // Хранит действия для поливалки
    public class Plan
    {
        private int _Litters = 0;
        /// <summary>
        /// Свойство указывает сколько литров нужно выполнить за итерацию полива.
        /// </summary>
        public int Litters
        {
            get { return _Litters; }
            set { _Litters = value; }
        }

        private TimeSpan _Interval;
        /// <summary>
        /// Интервал времени за которое необходимо выполнить полив.
        /// </summary>
        public TimeSpan Interval
        {
            get { return _Interval; }
            set { _Interval = value; }
        }
    }
}