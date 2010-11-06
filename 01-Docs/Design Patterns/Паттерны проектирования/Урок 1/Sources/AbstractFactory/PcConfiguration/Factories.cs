using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfiguration
{
    /*
     * Интерфейс фабрики для создания конфигурации
     * системного блока персонального компьютера
     */
    public interface IPcFactory
    {
        Box CreateBox();
        Processor CreateProcessor();
        MainBoard CreateMainBoard();
        Hdd CreateHdd();
        Memory CreateMemory();
    }

    /*
     * Фабрика для создания "домашней" конфигурации
     * системного блока персонального компьютера
     */
    public class HomePcFactory : IPcFactory {
        public Box CreateBox() 
        {
            return new SilverBox();
        }
        public Processor CreateProcessor() 
        {
            return new IntelProcessor();
        }
        public MainBoard CreateMainBoard() 
        {
            return new MSIMainBord();
        }
        public Hdd CreateHdd() 
        {
            return new SamsungHDD();
        }
        public Memory CreateMemory()
        {
            return new Ddr2Memory();
        }
    }

    /*
     * Фабрика для создания "офисной" конфигурации
     * системного блока персонального компьютера
     */
    public class OfficePcFactory : IPcFactory {
        public Box CreateBox() 
        {
            return new BlackBox();
        }
        public Processor CreateProcessor() 
        {
            return new AmdProcessor();
        }
        public MainBoard CreateMainBoard() 
        {
            return new AsusMainBord();
        }
        public Hdd CreateHdd() 
        {
            return new LGHDD (); 
        }
        public Memory CreateMemory() 
        {
            return new DdrMemory();
        }
    }
}
