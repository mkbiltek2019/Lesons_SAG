using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfigurator
{
    /*
     * Абстрактный класс апаратного устройства
     */
    public abstract class AbstractDevice : ICloneable
    {
        /*
         * Производитель устройства
         */
        public string Producer { get; set; }

        /*
         * Метод создания клона объекта
         */
        public virtual object Clone()
        {            
            /*
             * Создание поверхностной копии объекта
             */
            return MemberwiseClone();
        }
        
    }

    public class Box : AbstractDevice
    {
        public string Color { get; set; }
    }

    public class Memory : AbstractDevice
    {
        public int Volume { get; set; }
        public string Type { get; set; }

    }

    public class Hdd : AbstractDevice
    {
        public int Volume { get; set; }
        public string Type { get; set; }
    }

    public class Mainboard : AbstractDevice
    {
        public int BusFrequency { get; set; }
        public VideoCard VideoCard { get; set; }

        public override object Clone()
        {
            Mainboard newObj = (Mainboard)base.Clone();
            newObj.VideoCard = this.VideoCard != null ? (VideoCard) this.VideoCard.Clone() : null;
            return newObj;
        }
    }

    public class Processor : AbstractDevice
    {
        public double Frequency { get; set; }
        public int CoreCount { get; set; }
       
    }

    public class VideoCard : AbstractDevice
    {
        public int MemoryVolume { get; set; }       
    }

}