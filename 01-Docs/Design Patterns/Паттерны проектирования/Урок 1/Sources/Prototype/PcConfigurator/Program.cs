using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввести имя прототипа конфигурации
            Console.Write("Enter config prototype name: ");
            string prototypeName = Console.ReadLine();
            // Получение прототипа конфигурации из палитры по его имени
            PersonalComputer prototype = 
                PcPrototypes.Instance[prototypeName];
            if (prototype != null)
            {
                // Создание конфигурации на основе выбранного прототипа
                PersonalComputer pc = (PersonalComputer)prototype.Clone();
                // Вывод состава конфигурации на консоль
                PrintPc(pc);
            }
            else
            {
                Console.WriteLine("Error: incorrect config name");
            }
        }

        static void PrintPc(PersonalComputer pc)
        {
            Console.WriteLine("PC configuration: ");
            Console.WriteLine("Box: {0}", pc.Box.Color);
            Console.WriteLine("Mainboard: {0} {1}MHz", pc.Mainboard.Producer, pc.Mainboard.BusFrequency);
            if (pc.Mainboard.VideoCard != null)
            {
                Console.WriteLine("Integrated VideoCard: {0} {1}Mb", pc.Mainboard.VideoCard.Producer,
                                  pc.Mainboard.VideoCard.MemoryVolume);
            }
            Console.WriteLine("Processor: {0} {1}GHz {2} core", pc.Processor.Producer, pc.Processor.Frequency, pc.Processor.CoreCount);
            Console.WriteLine("Memories: ");
            foreach (Memory m in pc.Memories)
            {
                Console.WriteLine("{0} {1}Gb", m.Type, m.Volume);
            }
            Console.WriteLine("Hdds: ");
            foreach (Hdd h in pc.Hdds)
            {
                Console.WriteLine("{0} {1} {2}Gb", h.Producer, h.Type, h.Volume);
            }
            if (pc.VideoCard != null)
            {
                Console.WriteLine("VideoCard: {0} {1}Mb", pc.VideoCard.Producer, pc.VideoCard.MemoryVolume);
            }
        }
    }
}

