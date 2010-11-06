using System;
using System.Collections.Generic;
using System.Windows;
namespace TrackingClimate
{
    class FacadeCalculateSystem
    {
        private List<DayWeather> Days;
        private FileWork filework;
        private Calculating Calul;

        public FacadeCalculateSystem()
        {
            filework = new FileWork();
            Days = filework.Load();
            if (Days == null)
            {
                Days = new List<DayWeather>();
                filework.Save(Days);
                MessageBox.Show("Файл с погодой отсуцтвовал");
            }
            Calul = new Calculating();
        }

        /// <summary>
        /// Метод добавляет данные о погоде за день.
        /// </summary>
        /// <param name="Date">День о котором идет речь</param>
        /// <param name="Temperature">Температура в этот день</param>
        public void AddDay(DateTime Date, int Temperature)
        {
            DayWeather Day = new DayWeather();
            Day.Date = Date;
            Day.Temperature = Temperature;
            Days.Add(Day);
            filework.Save(Days);
        }

        /// <summary>
        /// Метод получает план по дате
        /// </summary>
        /// <param name="Date">Дата дня по которому нужен план</param>
        /// <returns>План действия для поливалки</returns>
        public Plan GetPlan(DateTime Date)
        {
            return Calul.Calc(Days, Date);
        }

    }
}
