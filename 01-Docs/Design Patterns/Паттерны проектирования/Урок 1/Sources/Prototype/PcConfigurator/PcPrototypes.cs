using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfigurator
{
    /*
     * Класс палитры типичных конфигураций
     */
    public class PcPrototypes
    {
        /*
         * Единственный экземпляр палитры типичных конфигураций
         */
        private static PcPrototypes instance = null;
        /*
         * Свойство доступа к единственному экземпляру 
         * палитры типичных конфигураций
         */
        public static PcPrototypes Instance
        {
            get
            {
                if (instance == null)
                {
                    // если палитра еще не создана, она создается
                    instance = new PcPrototypes();
                }
                return instance;
            }
        }
        /*
         * Словарь, в котором хранятся прототипы конфигураций
         */
        private Dictionary<string, PersonalComputer> pcPrototypes = new Dictionary<string, PersonalComputer>();

        /*
         * Защищенный конструктор запрещает создавать объект PcPrototypes
         * из внешнего кода
         */
        protected PcPrototypes()
        {
            // инициализация палитры прототипами конфигураций
            InitializePcPrototypes();
        }

        /*
         * Доступ к прототипу конфигурации по его имени
         */
        public PersonalComputer this [string key]
        {
            get
            {
                return pcPrototypes[key];
            }
            set
            {
                pcPrototypes[key] = value;
            }
        }
        /*
         * Список имен прототипов конфигураций в палитре
         */
        public List<string> Keys
        {
            get
            {
                return pcPrototypes.Keys.ToList();
            }
        }

        /*
         * Начальная инициализация палитры конфигураций
         */
        private void InitializePcPrototypes()
        {
            pcPrototypes["Home"] = CreateHomeConfig();
            pcPrototypes["Office"] = CreateOfficeConfig();
            pcPrototypes["Gamer"] = CreateGamerConfig();
        }

        private PersonalComputer CreateHomeConfig()
        {
            PersonalComputer config = new PersonalComputer();
            config.Box = new Box()
            {
                Producer = "",
                Color = "Silver"
            };
            config.Mainboard = new Mainboard()
            {
                Producer = "ATI",
                BusFrequency = 800,
                VideoCard = null
            };
            config.Processor = new Processor()
            {
                Producer = "Intell",
                CoreCount = 2,
                Frequency = 3
            };
            config.Hdds.Add(new Hdd()
            {
                Producer = "Samsung",
                Type = "SATA",
                Volume = 500
            });
            config.Memories.Add(new Memory()
            {
                Producer = "",
                Type = "DDR2",
                Volume = 2
            });
            config.VideoCard = new VideoCard()
            {
                Producer = "ATI",
                MemoryVolume = 1024
            };

            return config;
        }

        private PersonalComputer CreateGamerConfig()
        {
            PersonalComputer config = new PersonalComputer();
            config.Box = new Box()
            {
                Producer = "",
                Color = "Black"
            };
            config.Mainboard = new Mainboard()
            {
                Producer = "Asus",
                BusFrequency = 800,
                VideoCard = null

            };
            config.Processor = new Processor()
            {
                Producer = "Intell",
                CoreCount = 4,
                Frequency = 4
            };
            config.Hdds.Add(new Hdd()
            {
                Producer = "WD",
                Type = "SATA2",
                Volume = 1024
            });
            config.Memories.Add(new Memory()
            {
                Producer = "",
                Type = "DDR2",
                Volume = 4
            });
            config.VideoCard = new VideoCard()
            {
                Producer = "nVidia",
                MemoryVolume = 1024
            };

            return config;
        }

        private PersonalComputer CreateOfficeConfig()
        {
            PersonalComputer config = new PersonalComputer();
            config.Box = new Box()
            {
                Producer = "",
                Color = "White"
            };
            config.Mainboard = new Mainboard()
            {
                Producer = "Albatron",
                BusFrequency = 800,
                VideoCard = new VideoCard()
                                {
                                    Producer = "nVidia",
                                    MemoryVolume = 1024
                                }
            };
            config.Processor = new Processor()
            {
                Producer = "AMD",
                CoreCount = 1,
                Frequency = 1.8
            };
            config.Hdds.Add(new Hdd()
            {
                Producer = "LG",
                Type = "SATA",
                Volume = 160
            });
            config.Memories.Add(new Memory()
            {
                Producer = "",
                Type = "DDR2",
                Volume = 1
            });
            config.VideoCard = null;

            return config;
        }

    }
}
