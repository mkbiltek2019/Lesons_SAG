using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcConfiguration
{
    #region Abstract Devices
    public abstract class Box
    {        
    }
    public abstract class Hdd
    {        
    }
    public abstract class MainBoard
    {        
    }
    public abstract class Processor
    {        
    }
    public abstract class Memory
    {        
    }
    #endregion

    #region Concrete Devices
    public class AmdProcessor : Processor
    {        
        public override string ToString()
        {
            return "AmdProcessor";
        }
    }

    public class AsusMainBord : MainBoard
    {
        public override string ToString()
        {
            return "AsusMainBord";
        }
    }

    public class SilverBox : Box 
    {
        public override string ToString()
        {
            return "SilverBox";
        }
    }

    public class IntelProcessor : Processor
    {        
        public override string ToString()
        {
            return "IntelProcessor";
        }
    }

    public class LGHDD : Hdd
    {    
        public override string ToString()
        {
            return "LG hdd";
        }
    }

    public class MSIMainBord : MainBoard
    {       
       public override string ToString()
       {
           return "MSIMainBord";
        }
    }

    public class BlackBox : Box 
    {        
        public override string ToString() 
        {
            return "BlackBox";
        }
    }

    public class DdrMemory : Memory 
    {        
        public override string ToString() 
        {
            return "DdrMemory";
        }
    }

    public class SamsungHDD : Hdd 
    {    
        public override string ToString() 
        {
            return "Samsung hdd";
        }
    }

    public class Ddr2Memory : Memory 
    {
        public override string ToString() 
        {
            return "Ddr2Memory";
        }
    }
    #endregion

}