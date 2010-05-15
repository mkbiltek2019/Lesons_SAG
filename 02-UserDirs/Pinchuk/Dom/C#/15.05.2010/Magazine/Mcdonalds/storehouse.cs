using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlReader;

namespace Mcdonalds
{
    class Storehouse
    {
        List<Order> orders =new List<Order>();
        private ManagerControler managerControler=new ManagerControler();
        public IEnumerableMenu mainMenu;

        public Storehouse()
        {
            mainMenu = new IEnumerableMenu("Filexml/Menu.xml", managerControler);
        }
    }
}
