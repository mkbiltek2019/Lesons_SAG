using System;
using System.Collections.Generic;
using System.Windows;
namespace TrackingClimate
{
    // Класс занимается подсчетом сколько воды необходимо выливать растениям
    public class Calculating
    {
        /// <summary>
        /// Подсчет плана по трем минувшим дням
        /// </summary>
        /// <param name="a">Коллекция Минувших денй с погодой.</param>
        /// <param name="date">Сегодняшние время.</param>
        /// <returns>План для полива</returns>
        public Plan Calc(List<DayWeather> a, DateTime date)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Date == date && i>2)
                {
                    int Dt = a[i].Temperature + 
                        a[i - 1].Temperature + 
                        a[i - 2].Temperature;
                    Dt = Dt / 3;
                    int tim = Dt / 2;
                    Plan P= new Plan();
                    P.Interval = new TimeSpan(0, 0, tim, 0);
                    P.Litters = Dt;
                    return P;
                }

            }
            MessageBox.Show("Ошибка прогнозировавния");
            Plan P2 = new Plan();
            P2.Litters = 2;
            P2.Interval = new TimeSpan(0, 0, 1, 0);
            return P2;
        }
    }
}
