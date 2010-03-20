using System;

namespace Struct
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    enum Discount
    {
        Default = 0, Incentive = 2, Patron = 5, VIP = 15   
    }
   
    enum CommodityType
    {
        FrozenFood, Food, DomesticChemistry, BuildingMaterials 
    }

    struct Dimensions
    {
        public double Length;
        public double Width;
    }

    struct ConsignmentItem
    {
        public String Name;             // Наименование
        public Decimal Weigth;          // Вес
        public Decimal Price;           // Заявленная стоимость
        public Dimensions Dimensions;   // Размеры
        public CommodityType Type;      // Тип товара
    }

    struct Consignment
    {
        public Decimal TotalWeigth;
        public Decimal TotalPrice;
        public List<ConsignmentItem> Commodities;
    }

    struct Transport
    {
        public String Name;                         // Название
        public Decimal Capacity;                    // Вместимость
        public TransportType Type;                  // Тип
        public List<ConsignmentItem> Commodities;   // Перечень товаров
    }

    enum DistanceSun : ulong
    {
        Sun = 0,
        Mercury = 57900000,
        Venus = 108200000,
        Earth = 149600000,
        Mars = 227900000,
        Jupiter = 7783000000,
        Saturn = 1427000000,
        Uranus = 2870000000,
        Neptune = 4496000000,
        Pluto = 5946000000
    }


    enum TransportType 
    {
        Semitrailer, Coupling, Refrigerator, OpenSideTruck, Tank
    }

    class EnumSwitchExample
    {

        Transport Refrigerator = new Transport();
        Transport Semitrailer = new Transport();
        Transport Coupling = new Transport();
        Transport OpenSideTruck = new Transport();

        public void SetTransport (ConsignmentItem item)
        {
            switch (item.Type)
            {
                case CommodityType.FrozenFood: 
                    Refrigerator.Commodities.Add(item); 
                    break; 
                case CommodityType.Food: 
                    Semitrailer.Commodities.Add(item);
                    break; 
                case CommodityType.DomesticChemistry: 
                    Coupling.Commodities.Add(item);
                    break; 
                case CommodityType.BuildingMaterials: 
                    OpenSideTruck.Commodities.Add(item); 
                    break;
                default:
                    Semitrailer.Commodities.Add(item);
                    break;
            }
        }

    }

    enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    class EnumExample
    {
        public event EventHandler Event;

        public DayOfWeek NextDay(DayOfWeek day)
        {
            return (day < DayOfWeek.Sunday) ? day++ : DayOfWeek.Monday;
        }

    }

}
