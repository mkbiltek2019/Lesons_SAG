using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfiguration
{
    /*
     *  Класс, производящий конфигурирование 
     *  системного блока персонального компьютера.
     */
    public class PcConfigurator
    {
        /*
         *  Фабрика составляющих персонального компьютера
         */            
        public IPcFactory PcFactory { get; set; }
        /*
         *  Метод конфигурирования системного блока
         */            
        public void Configure(Pc pc)
        {
            pc.Box = PcFactory.CreateBox();
            pc.MainBoard = PcFactory.CreateMainBoard();
            pc.Hdd = PcFactory.CreateHdd();
            pc.Memory = PcFactory.CreateMemory();
            pc.Processor = PcFactory.CreateProcessor();            
        }
    }

}