using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace TrackingClimate
{
    class FileWork
    {
        private FileStream fs;
        /// <summary>
        ///  Загрузка списка дней с погодой
        /// </summary>
        /// <returns>Коллекция дней с погодой</returns>
        public List<DayWeather> Load()
        {
            try
            {
                fs = new FileStream("WeatherData.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                List<DayWeather> t = (List<DayWeather>)bf.Deserialize(fs);
                fs.Close();
                fs.Dispose();
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Сохраняет коллекцию дней с погодой
        /// </summary>
        /// <param name="a">Коллекция дней с погодой</param>
        public void Save(List<DayWeather> a)
        {
            fs = new FileStream("WeatherData.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, a);
            fs.Close();
            fs.Dispose();
        }

    }
}
