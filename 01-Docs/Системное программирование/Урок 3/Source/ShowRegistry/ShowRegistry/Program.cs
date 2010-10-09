using System;
using Microsoft.Win32;

class ShowRegistry
{
    public static void Main()
    {
        int SelectItem;
        RegistryKey[] regs = new[] {Registry.ClassesRoot,
                                      Registry.CurrentUser,
                                      Registry.LocalMachine,
                                      Registry.Users,
                                      Registry.CurrentConfig};
        do
        {
            int i = 1;
            Console.WriteLine("Выберите раздел системного реестра");
            foreach (RegistryKey reg in regs)
                Console.WriteLine("{0}. {1}", i++, reg.Name);
            Console.WriteLine("0. Выход");
            Console.Write(">  ");
            SelectItem = Convert.ToInt32(Console.ReadLine()[0]) - 48;
            Console.WriteLine();
            if (SelectItem > 0 && SelectItem <= regs.GetLength(0))
                PrintRegKeys(regs[SelectItem - 1]);
        } while (SelectItem != 0);
    }
    static void PrintRegKeys(RegistryKey rk)
    {
        string[] names = rk.GetSubKeyNames();
        Console.WriteLine("Подразделы {0}:", rk.Name);
        Console.WriteLine("----------------------------------");
        foreach (string s in names)
            Console.WriteLine(s);
        Console.WriteLine("----------------------------------");
    }
}
