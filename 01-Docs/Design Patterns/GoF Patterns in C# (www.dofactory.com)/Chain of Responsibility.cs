// Chain of Responsibility pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Chain.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Chain of Responsibility Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Setup Chain of Responsibility
      Handler h1 = new ConcreteHandler1();
      Handler h2 = new ConcreteHandler2();
      Handler h3 = new ConcreteHandler3();
      h1.SetSuccessor(h2);
      h2.SetSuccessor(h3);
 
      // Generate and process request
      int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
 
      foreach (int request in requests)
      {
        h1.HandleRequest(request);
      }
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Handler' abstract class
  /// </summary>
  abstract class Handler
  {
    protected Handler successor;
 
    public void SetSuccessor(Handler successor)
    {
      this.successor = successor;
    }
 
    public abstract void HandleRequest(int request);
  }
 
  /// <summary>
  /// The 'ConcreteHandler1' class
  /// </summary>
  class ConcreteHandler1 : Handler
  {
    public override void HandleRequest(int request)
    {
      if (request >= 0 && request < 10)
      {
        Console.WriteLine("{0} handled request {1}",
          this.GetType().Name, request);
      }
      else if (successor != null)
      {
        successor.HandleRequest(request);
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteHandler2' class
  /// </summary>
  class ConcreteHandler2 : Handler
  {
    public override void HandleRequest(int request)
    {
      if (request >= 10 && request < 20)
      {
        Console.WriteLine("{0} handled request {1}",
          this.GetType().Name, request);
      }
      else if (successor != null)
      {
        successor.HandleRequest(request);
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteHandler3' class
  /// </summary>
  class ConcreteHandler3 : Handler
  {
    public override void HandleRequest(int request)
    {
      if (request >= 20 && request < 30)
      {
        Console.WriteLine("{0} handled request {1}",
          this.GetType().Name, request);
      }
      else if (successor != null)
      {
        successor.HandleRequest(request);
      }
    }
  }
}
// Chain of Responsibility pattern -- Real World example 
using System;
 
namespace DoFactory.GangOfFour.Chain.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Chain of Responsibility Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Setup Chain of Responsibility
      Approver larry = new Director();
      Approver sam = new VicePresident();
      Approver tammy = new President();
 
      larry.SetSuccessor(sam);
      sam.SetSuccessor(tammy);
 
      // Generate and process purchase requests
      Purchase p = new Purchase(2034, 350.00, "Assets");
      larry.ProcessRequest(p);
 
      p = new Purchase(2035, 32590.10, "Project X");
      larry.ProcessRequest(p);
 
      p = new Purchase(2036, 122100.00, "Project Y");
      larry.ProcessRequest(p);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Handler' abstract class
  /// </summary>
  abstract class Approver
  {
    protected Approver successor;
 
    public void SetSuccessor(Approver successor)
    {
      this.successor = successor;
    }
 
    public abstract void ProcessRequest(Purchase purchase);
  }
 
  /// <summary>
  /// The 'ConcreteHandler' class
  /// </summary>
  class Director : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 10000.0)
      {
        Console.WriteLine("{0} approved request# {1}",
          this.GetType().Name, purchase.Number);
      }
      else if (successor != null)
      {
        successor.ProcessRequest(purchase);
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteHandler' class
  /// </summary>
  class VicePresident : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 25000.0)
      {
        Console.WriteLine("{0} approved request# {1}",
          this.GetType().Name, purchase.Number);
      }
      else if (successor != null)
      {
        successor.ProcessRequest(purchase);
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteHandler' class
  /// </summary>
  class President : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 100000.0)
      {
        Console.WriteLine("{0} approved request# {1}",
          this.GetType().Name, purchase.Number);
      }
      else
      {
        Console.WriteLine(
          "Request# {0} requires an executive meeting!",
          purchase.Number);
      }
    }
  }
 
  /// <summary>
  /// Class holding request details
  /// </summary>
  class Purchase
  {
    private int _number;
    private double _amount;
    private string _purpose;
 
    // Constructor
    public Purchase(int number, double amount, string purpose)
    {
      this._number = number;
      this._amount = amount;
      this._purpose = purpose;
    }
 
    // Gets or sets purchase number
    public int Number
    {
      get { return _number; }
      set { _number = value; }
    }
 
    // Gets or sets purchase amount
    public double Amount
    {
      get { return _amount; }
      set { _amount = value; }
    }
 
    // Gets or sets purchase purpose
    public string Purpose
    {
      get { return _purpose; }
      set { _purpose = value; }
    }
  }
}
