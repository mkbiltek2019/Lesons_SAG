using System;

namespace TrackingClimate
{
    [Serializable]
    public class DayWeather
    {
        DateTime _Date;
        /// <summary>
        /// Дата дня
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }


        int _Temperature;
        /// <summary>
        /// Температура
        /// </summary>
        public int Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
    }
}
