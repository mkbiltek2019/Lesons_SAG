// Memento pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Memento.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Memento Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      Originator o = new Originator();
      o.State = "On";
 
      // Store internal state
      Caretaker c = new Caretaker();
      c.Memento = o.CreateMemento();
 
      // Continue changing originator
      o.State = "Off";
 
      // Restore saved state
      o.SetMemento(c.Memento);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Originator' class
  /// </summary>
  class Originator
  {
    private string _state;
 
    // Property
    public string State
    {
      get { return _state; }
      set
      {
        _state = value;
        Console.WriteLine("State = " + _state);
      }
    }
 
    // Creates memento 
    public Memento CreateMemento()
    {
      return (new Memento(_state));
    }
 
    // Restores original state
    public void SetMemento(Memento memento)
    {
      Console.WriteLine("Restoring state...");
      State = memento.State;
    }
  }
 
  /// <summary>
  /// The 'Memento' class
  /// </summary>
  class Memento
  {
    private string _state;
 
    // Constructor
    public Memento(string state)
    {
      this._state = state;
    }
 
    // Gets or sets state
    public string State
    {
      get { return _state; }
    }
  }
 
  /// <summary>
  /// The 'Caretaker' class
  /// </summary>
  class Caretaker
  {
    private Memento _memento;
 
    // Gets or sets memento
    public Memento Memento
    {
      set { _memento = value; }
      get { return _memento; }
    }
  }
}
// Memento pattern -- Real World example 
using System;
 
namespace DoFactory.GangOfFour.Memento.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Memento Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      SalesProspect s = new SalesProspect();
      s.Name = "Noel van Halen";
      s.Phone = "(412) 256-0990";
      s.Budget = 25000.0;
 
      // Store internal state
      ProspectMemory m = new ProspectMemory();
      m.Memento = s.SaveMemento();
 
      // Continue changing originator
      s.Name = "Leo Welch";
      s.Phone = "(310) 209-7111";
      s.Budget = 1000000.0;
 
      // Restore saved state
      s.RestoreMemento(m.Memento);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Originator' class
  /// </summary>
  class SalesProspect
  {
    private string _name;
    private string _phone;
    private double _budget;
 
    // Gets or sets name
    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        Console.WriteLine("Name:  " + _name);
      }
    }
 
    // Gets or sets phone
    public string Phone
    {
      get { return _phone; }
      set
      {
        _phone = value;
        Console.WriteLine("Phone: " + _phone);
      }
    }
 
    // Gets or sets budget
    public double Budget
    {
      get { return _budget; }
      set
      {
        _budget = value;
        Console.WriteLine("Budget: " + _budget);
      }
    }
 
    // Stores memento
    public Memento SaveMemento()
    {
      Console.WriteLine("\nSaving state --\n");
      return new Memento(_name, _phone, _budget);
    }
 
    // Restores memento
    public void RestoreMemento(Memento memento)
    {
      Console.WriteLine("\nRestoring state --\n");
      this.Name = memento.Name;
      this.Phone = memento.Phone;
      this.Budget = memento.Budget;
    }
  }
 
  /// <summary>
  /// The 'Memento' class
  /// </summary>
  class Memento
  {
    private string _name;
    private string _phone;
    private double _budget;
 
    // Constructor
    public Memento(string name, string phone, double budget)
    {
      this._name = name;
      this._phone = phone;
      this._budget = budget;
    }
 
    // Gets or sets name
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
 
    // Gets or set phone
    public string Phone
    {
      get { return _phone; }
      set { _phone = value; }
    }
 
    // Gets or sets budget
    public double Budget
    {
      get { return _budget; }
      set { _budget = value; }
    }
  }
 
  /// <summary>
  /// The 'Caretaker' class
  /// </summary>
  class ProspectMemory
  {
    private Memento _memento;
 
    // Property
    public Memento Memento
    {
      set { _memento = value; }
      get { return _memento; }
    }
  }
}
