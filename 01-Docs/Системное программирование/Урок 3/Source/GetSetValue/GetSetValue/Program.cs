using System;
using Microsoft.Win32;

public class GetSetValue
{
    public static void Main()
    {
        string user = Registry.CurrentUser.Name,
               skey = "GetSetValue",
               skeyName = user + "\\" + skey;
        // Запись
        Registry.SetValue(skeyName, "", 0x1234);  // по умолчанию
        Registry.SetValue(skeyName, "GSVQWord", 0x0123456789ABCDEF,
                          RegistryValueKind.QWord);
        Registry.SetValue(skeyName, "GSVString", "Путь: %path%");
        Registry.SetValue(skeyName, "GSVExpandString", "Путь: %path%",
                          RegistryValueKind.ExpandString);
        Registry.SetValue(skeyName, "GSVArray",
                          new[] { "Лента 1", "Лента 2", "Лента 3" });
        // Считывание
        Console.WriteLine("GSVNotExists: {0}",
            (string)Registry.GetValue(skeyName, "GSVNotExists",
                                      "GSVNotExists отсутствует!"));
        RegistryKey rk = Registry.CurrentUser.OpenSubKey(skey);
        string[] rks = rk.GetValueNames();
        foreach (string s in rks)
        {
            if (s.Length == 0) Console.Write("(Default): ");
            else Console.Write("{0}: ", s);
            if (rk.GetValueKind(s) == RegistryValueKind.MultiString)
            {
                foreach (string subs in (string[])rk.GetValue(s))
                    Console.Write("\t\"{0}\"", subs);
                Console.WriteLine("\n");
            }
            else Console.WriteLine(rk.GetValue(s));
        }
        Console.WriteLine("Посмотрите в реестре введенные значения " +
                          "и нажмите Enter");
        Console.ReadLine();
        // Удаление
        Registry.CurrentUser.DeleteSubKey(skey);
    }
}
