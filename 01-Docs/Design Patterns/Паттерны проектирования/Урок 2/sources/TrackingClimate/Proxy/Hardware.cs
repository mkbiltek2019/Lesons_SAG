using System.Windows;
namespace TrackingClimate
{
    // Класс работающий с оборудованием.
    class Hardware:Ihardware
    {
        // Симуляция полива.
        public void Watering(Plan a)
        {
            MessageBox.Show("Выполняется полив:\n"+"Литров:"+a.Litters.ToString()+"\nза "+a.Interval.ToString()+" времени");
        }
    }
}
