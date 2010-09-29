using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace RegistryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            string[] subKeyNames = regKey.GetSubKeyNames();

            Console.WriteLine(regKey.Name);
            foreach (var subKeyName in subKeyNames)
            {
                Console.WriteLine("\t {0}", subKeyName);
            }

            regKey = regKey.OpenSubKey("SOFTWARE", false); // открыть только для чтения
            if(regKey != null)
            {
                Console.WriteLine(regKey.Name);
            }
            else
            {
                Console.WriteLine("Wrong Key Name");
            }

            regKey = regKey.OpenSubKey("ArgoUML\\Components", true); // открыть для изменения
            if (regKey != null)
            {
                Console.WriteLine(regKey.Name);
            }
            else
            {
                Console.WriteLine("Wrong Key Name");
            }

            RegistryKey sobakaBarabakaKey = regKey.CreateSubKey("SobakaBarabaka");
            if (sobakaBarabakaKey != null)
            {
                sobakaBarabakaKey.SetValue("ValuableParameter1", "simple string", RegistryValueKind.String);
                sobakaBarabakaKey.SetValue("ValuableParameter2", 0x100);

                regKey.DeleteSubKey("SobakaBarabaka");
            }
        }
    }
}
