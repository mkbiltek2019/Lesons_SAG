// Factory Method pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Factory.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Factory Method Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // An array of creators
      Creator[] creators = new Creator[2];
 
      creators[0] = new ConcreteCreatorA();
      creators[1] = new ConcreteCreatorB();
 
      // Iterate over creators and create products
      foreach (Creator creator in creators)
      {
        Product product = creator.FactoryMethod();
        Console.WriteLine("Created {0}",
          product.GetType().Name);
      }
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Product' abstract class
  /// </summary>
  abstract class Product
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class ConcreteProductA : Product
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class ConcreteProductB : Product
  {
  }
 
  /// <summary>
  /// The 'Creator' abstract class
  /// </summary>
  abstract class Creator
  {
    public abstract Product FactoryMethod();
  }
 
  /// <summary>
  /// A 'ConcreteCreator' class
  /// </summary>
  class ConcreteCreatorA : Creator
  {
    public override Product FactoryMethod()
    {
      return new ConcreteProductA();
    }
  }
 
  /// <summary>
  /// A 'ConcreteCreator' class
  /// </summary>
  class ConcreteCreatorB : Creator
  {
    public override Product FactoryMethod()
    {
      return new ConcreteProductB();
    }
  }
}
// Factory Method pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Factory.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Factory Method Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Note: constructors call Factory Method
      Document[] documents = new Document[2];
 
      documents[0] = new Resume();
      documents[1] = new Report();
 
      // Display document pages
      foreach (Document document in documents)
      {
        Console.WriteLine("\n" + document.GetType().Name + "--");
        foreach (Page page in document.Pages)
        {
          Console.WriteLine(" " + page.GetType().Name);
        }
      }
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Product' abstract class
  /// </summary>
  abstract class Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class SkillsPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class EducationPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class ExperiencePage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class IntroductionPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class ResultsPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class ConclusionPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class SummaryPage : Page
  {
  }
 
  /// <summary>
  /// A 'ConcreteProduct' class
  /// </summary>
  class BibliographyPage : Page
  {
  }
 
  /// <summary>
  /// The 'Creator' abstract class
  /// </summary>
  abstract class Document
  {
    private List<Page> _pages = new List<Page>();
 
    // Constructor calls abstract Factory method
    public Document()
    {
      this.CreatePages();
    }
 
    public List<Page> Pages
    {
      get { return _pages; }
    }
 
    // Factory Method
    public abstract void CreatePages();
  }
 
  /// <summary>
  /// A 'ConcreteCreator' class
  /// </summary>
  class Resume : Document
  {
    // Factory Method implementation
    public override void CreatePages()
    {
      Pages.Add(new SkillsPage());
      Pages.Add(new EducationPage());
      Pages.Add(new ExperiencePage());
    }
  }
 
  /// <summary>
  /// A 'ConcreteCreator' class
  /// </summary>
  class Report : Document
  {
    // Factory Method implementation
    public override void CreatePages()
    {
      Pages.Add(new IntroductionPage());
      Pages.Add(new ResultsPage());
      Pages.Add(new ConclusionPage());
      Pages.Add(new SummaryPage());
      Pages.Add(new BibliographyPage());
    }
  }
}
