using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Console;
using System.Xml.Linq;

namespace XmlReader
{
    public class IEnumerableMenu
    {
        private ConsoleMenu consoleMenu =new ConsoleMenu();
        private  ActionsMethot actionsMethot = new ActionsMethot();
        private XmlReaderMenu xmlReaderMenu; 
        public IEnumerableMenu(string fileName, object controler)
        {
            xmlReaderMenu = new XmlReaderMenu(fileName);
            IEnumerable<XElement> xE = xmlReaderMenu.xDoc.Element("menu").Elements("menuItem");
            foreach (XElement xElement in xE)
            {
                consoleMenu.MenuItems.Add(new ConsoleMenu.ConsoleMenuItem()
                {
                    Key = xElement.Attribute("Key").Value,
                    Description = xElement.Attribute("Description").Value,
                    Visible = Convert.ToBoolean(xElement.Attribute("Visible").Value),
                    Action = (MenuFunctionHandler)Delegate.CreateDelegate(typeof(MenuFunctionHandler),
                    controler, xElement.Attribute("Action").Value, false, true)
                }
                );
            }
        }

        public void PrintMenu()
        {
            consoleMenu.Display();
        }

        public bool NextLevelMenu (/*string id*/)
        {

            string stringKey = string.Format("{0}.", consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key);
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if (consoleMenu.MenuItems[i].Key.Remove(consoleMenu.MenuItems[i].Key.Count()-1) == stringKey)
                    consoleMenu.MenuItems[i].Visible = true;
            }
            return true;
        }

        public bool PrevLevelMenu ()
        {
            string thisActivString =consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key;
            string stringKey = string.Format("{0}", 
                consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key.Remove(consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key.Count() - 2));
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if ((stringKey.Length == consoleMenu.MenuItems[i].Key.Length) && (thisActivString[0] == consoleMenu.MenuItems[i].Key[0]))
                    consoleMenu.MenuItems[i].Visible = true;
            }
            return true;
        }
        public bool MainMenu()
        {
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if ((1== consoleMenu.MenuItems[i].Key.Length))
                    consoleMenu.MenuItems[i].Visible = true;
            }

            return true;
        }
        public bool Print()
        {
            Console.Clear();
            Console.WriteLine("Print");
            Console.ReadKey();
            return true;
        }
        public  bool Exit()
        {
            Console.Clear();
            return false;
        }


    }
}
