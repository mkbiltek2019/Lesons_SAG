using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfigurator
{
    /*
     * Класс персонального компьютера
    */
    public class PersonalComputer : ICloneable
    {
        public Box Box { get; set; }

        public Mainboard Mainboard { get; set; }

        public Processor Processor { get; set; }

        private List<Hdd> hdds = new List<Hdd>();
        public List<Hdd> Hdds
        {
            get
            {
                return hdds;
            }
        }

        private List<Memory> memories = new List<Memory>();
        public List<Memory> Memories
        {
            get
            {
                return memories;
            }
        }

        public VideoCard VideoCard { get; set; }

        public object Clone()
        {
            /*
             * Создание поверхностной копии объекта
             */
            PersonalComputer newPc = (PersonalComputer) this.MemberwiseClone();
            /*
             * Клонироване объектов апаратных составляющих
             */
            newPc.Box = this.Box != null ? (Box) this.Box.Clone() : null;
            newPc.Mainboard = this.Mainboard != null ? (Mainboard) this.Mainboard.Clone() : null;
            newPc.Processor = this.Processor != null ? (Processor) this.Processor.Clone() : null;
            newPc.memories = new List<Memory>();
            foreach (Memory m in this.memories)
            {
                if (m != null)
                {
                    newPc.memories.Add((Memory) m.Clone());
                }
            }
            newPc.hdds = new List<Hdd>();
            foreach (Hdd h in this.hdds)
            {
                if (h != null)
                {
                    newPc.hdds.Add((Hdd) h.Clone());
                }
            }
            newPc.VideoCard = this.VideoCard != null ? (VideoCard) this.VideoCard.Clone() : null;
            return newPc;
        }
    }    
}