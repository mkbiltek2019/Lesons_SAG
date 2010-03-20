using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        ValueTypePerfTest();
    }

    /// <summary>
    /// метод для тестирования производительности 
    /// обобщенного и необобщенного списка
    /// </summary>
    private static void ValueTypePerfTest()
    {
        const Int32 count = 10000000;

        //объект OperationTimer создается перед началом использования коллекции
        //после завершения ее использования 
        //выводит время, затраченное на работу с коллекцией  
        using (new OperationTimer("List"))
        {
            //использование обобщенного списка
            List<int> l = new List<int>(count);
            for (Int32 n = 0; n < count; n++)
            {
                l.Add(n);
                Int32 x = l[n];
            }
            l = null;  // для гарантированного выполнения сборки мусора
        }

        using (new OperationTimer("ArrayList of Int32"))
        {
            //использование необобщенного списка
            ArrayList a = new ArrayList();
            for (Int32 n = 0; n < count; n++)
            {
                a.Add(n); //выполняется упаковка
                Int32 x = (Int32)a[n]; //выполняется распаковка
            }
            a = null;  // для гарантированного выполнения сборки мусора
        }
    }
}



/// <summary>
/// Вспомогательный класс для профилирования участка кода
/// выполняет измерения времени выполнения
/// и подсчет количества сборок мусора
/// </summary>
internal sealed class OperationTimer : IDisposable
{
    private Int64 m_startTime;
    private String m_text;
    private Int32 m_collectionCount;

    public OperationTimer(String text)
    {

        PrepareForOperation();

        m_text = text;

        //Сохранеяется количество сборок мусора, выполненное на текущий момент
        m_collectionCount = GC.CollectionCount(0);

        //Сохранеяется начальное время
        m_startTime = Stopwatch.GetTimestamp();
    }

    /// <summary>
    /// Вызывается при разрушении объекта
    /// Выводит:
    /// значение времени, прошедшего с момента создания объекта до момента его удаления
    /// количество выполненных сборок мусора, выполненных за это время
    /// </summary>
    public void Dispose()
    {
        Console.WriteLine("{0,6:0.00} seconds (GCs={1,3}) {2}",
           (Stopwatch.GetTimestamp() - m_startTime) /
              (Double)Stopwatch.Frequency,
           GC.CollectionCount(0) - m_collectionCount, m_text);
    }
    /// <summary>
    ///Метод удаляются все неиспользуетме объекты
    ///Это надо для "чистоты эксперимента",
    ///т.е. чтобы сборка мусора происходила только для объектов,
    ///которые будут создаваться в профилируемом блоке кода
    ////// </summary>
    private static void PrepareForOperation()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}