using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AppDomainSample
{
    class Program
    {
        [LoaderOptimization(LoaderOptimization.SingleDomain)]
        static void Main(string[] args)
        {
            //создаём домен приложения с приозвольным именем
            AppDomain Domain = AppDomain.CreateDomain("Demo Domain");
            //загружаем в созданный нами домен приложения заранее подготовленную dll библиотеку
            Assembly asm = Domain.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));
            //получаем модуль, из которого будем осуществлять вызов
            Module module = asm.GetModule("SampleLibrary.dll");
            //получаем тип данных, содержащий искомый метод
            Type type = module.GetType("SampleLibrary.SampleClass");
            //получаем метод из типа данных
            MethodInfo method = type.GetMethod("DoSome");
            //осуществляем вызов метода
            method.Invoke(null, null);

            //однострочный вариант вызова того же метода через анонимные объекты
            asm.GetModule("SampleLibrary.dll").GetType("SampleLibrary.SampleClass").GetMethod("DoSome").Invoke(null, null);

            //отгружаем домен приложения
            AppDomain.Unload(Domain);
        }
    }
}
