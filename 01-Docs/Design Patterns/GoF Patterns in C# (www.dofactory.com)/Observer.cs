// Observer pattern -- Structural example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Observer.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Observer Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Configure Observer pattern
      ConcreteSubject s = new ConcreteSubject();
 
      s.Attach(new ConcreteObserver(s, "X"));
      s.Attach(new ConcreteObserver(s, "Y"));
      s.Attach(new ConcreteObserver(s, "Z"));
 
      // Change subject and notify observers
      s.SubjectState = "ABC";
      s.Notify();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Subject' abstract class
  /// </summary>
  abstract class Subject
  {
    private List<Observer> _observers = new List<Observer>();
 
    public void Attach(Observer observer)
    {
      _observers.Add(observer);
    }
 
    public void Detach(Observer observer)
    {
      _observers.Remove(observer);
    }
 
    public void Notify()
    {
      foreach (Observer o in _observers)
      {
        o.Update();
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteSubject' class
  /// </summary>
  class ConcreteSubject : Subject
  {
    private string _subjectState;
 
    // Gets or sets subject state
    public string SubjectState
    {
      get { return _subjectState; }
      set { _subjectState = value; }
    }
  }
 
  /// <summary>
  /// The 'Observer' abstract class
  /// </summary>
  abstract class Observer
  {
    public abstract void Update();
  }
 
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>
  class ConcreteObserver : Observer
  {
    private string _name;
    private string _observerState;
    private ConcreteSubject _subject;
 
    // Constructor
    public ConcreteObserver(
      ConcreteSubject subject, string name)
    {
      this._subject = subject;
      this._name = name;
    }
 
    public override void Update()
    {
      _observerState = _subject.SubjectState;
      Console.WriteLine("Observer {0}'s new state is {1}",
        _name, _observerState);
    }
 
    // Gets or sets subject
    public ConcreteSubject Subject
    {
      get { return _subject; }
      set { _subject = value; }
    }
  }
}
// Observer pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Observer.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Observer Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create IBM stock and attach investors
      IBM ibm = new IBM("IBM", 120.00);
      ibm.Attach(new Investor("Sorros"));
      ibm.Attach(new Investor("Berkshire"));
 
      // Fluctuating prices will notify investors
      ibm.Price = 120.10;
      ibm.Price = 121.00;
      ibm.Price = 120.50;
      ibm.Price = 120.75;
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Subject' abstract class
  /// </summary>
  abstract class Stock
  {
    private string _symbol;
    private double _price;
    private List<IInvestor> _investors = new List<IInvestor>();
 
    // Constructor
    public Stock(string symbol, double price)
    {
      this._symbol = symbol;
      this._price = price;
    }
 
    public void Attach(IInvestor investor)
    {
      _investors.Add(investor);
    }
 
    public void Detach(IInvestor investor)
    {
      _investors.Remove(investor);
    }
 
    public void Notify()
    {
      foreach (IInvestor investor in _investors)
      {
        investor.Update(this);
      }
 
      Console.WriteLine("");
    }
 
    // Gets or sets the price
    public double Price
    {
      get { return _price; }
      set
      {
        if (_price != value)
        {
          _price = value;
          Notify();
        }
      }
    }
 
    // Gets the symbol
    public string Symbol
    {
      get { return _symbol; }
    }
  }
 
  /// <summary>
  /// The 'ConcreteSubject' class
  /// </summary>
  class IBM : Stock
  {
    // Constructor
    public IBM(string symbol, double price)
      : base(symbol, price)
    {
    }
  }
 
  /// <summary>
  /// The 'Observer' interface
  /// </summary>
  interface IInvestor
  {
    void Update(Stock stock);
  }
 
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>
  class Investor : IInvestor
  {
    private string _name;
    private Stock _stock;
 
    // Constructor
    public Investor(string name)
    {
      this._name = name;
    }
 
    public void Update(Stock stock)
    {
      Console.WriteLine("Notified {0} of {1}'s " +
        "change to {2:C}", _name, stock.Symbol, stock.Price);
    }
 
    // Gets or sets the stock
    public Stock Stock
    {
      get { return _stock; }
      set { _stock = value; }
    }
  }
}
