// Strategy pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Strategy.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Strategy Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      Context context;
 
      // Three contexts following different strategies
      context = new Context(new ConcreteStrategyA());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyB());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyC());
      context.ContextInterface();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Strategy' abstract class
  /// </summary>
  abstract class Strategy
  {
    public abstract void AlgorithmInterface();
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyA : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyA.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyB : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyB.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ConcreteStrategyC : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyC.AlgorithmInterface()");
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class Context
  {
    private Strategy _strategy;
 
    // Constructor
    public Context(Strategy strategy)
    {
      this._strategy = strategy;
    }
 
    public void ContextInterface()
    {
      _strategy.AlgorithmInterface();
    }
  }
}
// Strategy pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Strategy.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Strategy Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Two contexts following different strategies
      SortedList studentRecords = new SortedList();
 
      studentRecords.Add("Samual");
      studentRecords.Add("Jimmy");
      studentRecords.Add("Sandra");
      studentRecords.Add("Vivek");
      studentRecords.Add("Anna");
 
      studentRecords.SetSortStrategy(new QuickSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new ShellSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new MergeSort());
      studentRecords.Sort();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Strategy' abstract class
  /// </summary>
  abstract class SortStrategy
  {
    public abstract void Sort(List<string> list);
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class QuickSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      list.Sort(); // Default is Quicksort
      Console.WriteLine("QuickSorted list ");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class ShellSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      //list.ShellSort(); not-implemented
      Console.WriteLine("ShellSorted list ");
    }
  }
 
  /// <summary>
  /// A 'ConcreteStrategy' class
  /// </summary>
  class MergeSort : SortStrategy
  {
    public override void Sort(List<string> list)
    {
      //list.MergeSort(); not-implemented
      Console.WriteLine("MergeSorted list ");
    }
  }
 
  /// <summary>
  /// The 'Context' class
  /// </summary>
  class SortedList
  {
    private List<string> _list = new List<string>();
    private SortStrategy _sortstrategy;
 
    public void SetSortStrategy(SortStrategy sortstrategy)
    {
      this._sortstrategy = sortstrategy;
    }
 
    public void Add(string name)
    {
      _list.Add(name);
    }
 
    public void Sort()
    {
      _sortstrategy.Sort(_list);
 
      // Iterate over list and display results
      foreach (string name in _list)
      {
        Console.WriteLine(" " + name);
      }
      Console.WriteLine();
    }
  }
}
