using System.Windows;
namespace TrackingClimate
{
    // Проекси класс обеспечивающий защиту класса работающего с железом
    class ProxyHardware : Ihardware
    {
        Hardware hard = null;
        public void Watering(Plan a)
        {
            if (hard == null)
            {
                hard = new Hardware();
            }

            if ((a.Litters / a.Interval.TotalMinutes) < 1)
            {
                MessageBox.Show("Полив не будет выполнен. \nОшибка: слишком маленькое давление");
            }
            else if ((a.Litters / a.Interval.TotalMinutes) > 4)
            {
                MessageBox.Show("Полив не будет выполнен. \nОшибка: слишком большое давление");
            }
            else
            {
                // Вызов работы с оборудованием.
                hard.Watering(a);
            }

        }

    }
}
