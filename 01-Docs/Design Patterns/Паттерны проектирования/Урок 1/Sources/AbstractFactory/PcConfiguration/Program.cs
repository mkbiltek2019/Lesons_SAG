using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            PcConfigurator configurator = new PcConfigurator();

            Pc pc1 = new Pc();
            // Определяем фабрику для создания конфигурации
            configurator.PcFactory = new HomePcFactory();
            configurator.Configure(pc1);
            PringPcConfiguration("Home configuration", pc1);

            Pc pc2 = new Pc();
            // Определяем фабрику для создания конфигурации
            configurator.PcFactory = new OfficePcFactory();
            configurator.Configure(pc2);
            PringPcConfiguration("Office configuration", pc2);

        }

        static void PringPcConfiguration(string configName, Pc pc)
        {
            Console.WriteLine("======== " + configName + " ========");
            Console.WriteLine("Box: " + pc.Box);
            Console.WriteLine("Main Board: " + pc.MainBoard);
            Console.WriteLine("Processor: " + pc.Processor);
            Console.WriteLine("HDD: " + pc.Hdd);
            Console.WriteLine("Memory: " + pc.Memory);            
        }
    }
}
