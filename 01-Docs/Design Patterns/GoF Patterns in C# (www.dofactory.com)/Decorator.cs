// Decorator pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Decorator.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Decorator Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create ConcreteComponent and two Decorators
      ConcreteComponent c = new ConcreteComponent();
      ConcreteDecoratorA d1 = new ConcreteDecoratorA();
      ConcreteDecoratorB d2 = new ConcreteDecoratorB();
 
      // Link decorators
      d1.SetComponent(c);
      d2.SetComponent(d1);
 
      d2.Operation();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Component' abstract class
  /// </summary>
  abstract class Component
  {
    public abstract void Operation();
  }
 
  /// <summary>
  /// The 'ConcreteComponent' class
  /// </summary>
  class ConcreteComponent : Component
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteComponent.Operation()");
    }
  }
 
  /// <summary>
  /// The 'Decorator' abstract class
  /// </summary>
  abstract class Decorator : Component
  {
    protected Component component;
 
    public void SetComponent(Component component)
    {
      this.component = component;
    }
 
    public override void Operation()
    {
      if (component != null)
      {
        component.Operation();
      }
    }
  }
 
  /// <summary>
  /// The 'ConcreteDecoratorA' class
  /// </summary>
  class ConcreteDecoratorA : Decorator
  {
    public override void Operation()
    {
      base.Operation();
      Console.WriteLine("ConcreteDecoratorA.Operation()");
    }
  }
 
  /// <summary>
  /// The 'ConcreteDecoratorB' class
  /// </summary>
  class ConcreteDecoratorB : Decorator
  {
    public override void Operation()
    {
      base.Operation();
      AddedBehavior();
      Console.WriteLine("ConcreteDecoratorB.Operation()");
    }
 
    void AddedBehavior()
    {
    }
  }
}
// Decorator pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Decorator.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Decorator Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create book
      Book book = new Book("Worley", "Inside ASP.NET", 10);
      book.Display();
 
      // Create video
      Video video = new Video("Spielberg", "Jaws", 23, 92);
      video.Display();
 
      // Make video borrowable, then borrow and display
      Console.WriteLine("\nMaking video borrowable:");
 
      Borrowable borrowvideo = new Borrowable(video);
      borrowvideo.BorrowItem("Customer #1");
      borrowvideo.BorrowItem("Customer #2");
 
      borrowvideo.Display();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Component' abstract class
  /// </summary>
  abstract class LibraryItem
  {
    private int _numCopies;
 
    // Property
    public int NumCopies
    {
      get { return _numCopies; }
      set { _numCopies = value; }
    }
 
    public abstract void Display();
  }
 
  /// <summary>
  /// The 'ConcreteComponent' class
  /// </summary>
  class Book : LibraryItem
  {
    private string _author;
    private string _title;
 
    // Constructor
    public Book(string author, string title, int numCopies)
    {
      this._author = author;
      this._title = title;
      this.NumCopies = numCopies;
    }
 
    public override void Display()
    {
      Console.WriteLine("\nBook ------ ");
      Console.WriteLine(" Author: {0}", _author);
      Console.WriteLine(" Title: {0}", _title);
      Console.WriteLine(" # Copies: {0}", NumCopies);
    }
  }
 
  /// <summary>
  /// The 'ConcreteComponent' class
  /// </summary>
  class Video : LibraryItem
  {
    private string _director;
    private string _title;
    private int _playTime;
 
    // Constructor
    public Video(string director, string title,
      int numCopies, int playTime)
    {
      this._director = director;
      this._title = title;
      this.NumCopies = numCopies;
      this._playTime = playTime;
    }
 
    public override void Display()
    {
      Console.WriteLine("\nVideo ----- ");
      Console.WriteLine(" Director: {0}", _director);
      Console.WriteLine(" Title: {0}", _title);
      Console.WriteLine(" # Copies: {0}", NumCopies);
      Console.WriteLine(" Playtime: {0}\n", _playTime);
    }
  }
 
  /// <summary>
  /// The 'Decorator' abstract class
  /// </summary>
  abstract class Decorator : LibraryItem
  {
    protected LibraryItem libraryItem;
 
    // Constructor
    public Decorator(LibraryItem libraryItem)
    {
      this.libraryItem = libraryItem;
    }
 
    public override void Display()
    {
      libraryItem.Display();
    }
  }
 
  /// <summary>
  /// The 'ConcreteDecorator' class
  /// </summary>
  class Borrowable : Decorator
  {
    protected List<string> borrowers = new List<string>();
 
    // Constructor
    public Borrowable(LibraryItem libraryItem)
      : base(libraryItem)
    {
    }
 
    public void BorrowItem(string name)
    {
      borrowers.Add(name);
      libraryItem.NumCopies--;
    }
 
    public void ReturnItem(string name)
    {
      borrowers.Remove(name);
      libraryItem.NumCopies++;
    }
 
    public override void Display()
    {
      base.Display();
 
      foreach (string borrower in borrowers)
      {
        Console.WriteLine(" borrower: " + borrower);
      }
    }
  }
}
