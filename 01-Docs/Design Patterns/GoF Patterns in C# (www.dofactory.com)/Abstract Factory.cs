// Abstract Factory pattern -- Structural example 
using System;
namespace DoFactory.GangOfFour.Abstract.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Abstract Factory Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    public static void Main()
    {
      // Abstract factory #1
      AbstractFactory factory1 = new ConcreteFactory1();
      Client client1 = new Client(factory1);
      client1.Run();
 
      // Abstract factory #2
      AbstractFactory factory2 = new ConcreteFactory2();
      Client client2 = new Client(factory2);
      client2.Run();
 
      // Wait for user input
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'AbstractFactory' abstract class
  /// </summary>
  abstract class AbstractFactory
  {
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
  }
 
 
  /// <summary>
  /// The 'ConcreteFactory1' class
  /// </summary>
  class ConcreteFactory1 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB1();
    }
  }
 
  /// <summary>
  /// The 'ConcreteFactory2' class
  /// </summary>
  class ConcreteFactory2 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB2();
    }
  }
 
  /// <summary>
  /// The 'AbstractProductA' abstract class
  /// </summary>
  abstract class AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'AbstractProductB' abstract class
  /// </summary>
  abstract class AbstractProductB
  {
    public abstract void Interact(AbstractProductA a);
  }
 
 
  /// <summary>
  /// The 'ProductA1' class
  /// </summary>
  class ProductA1 : AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'ProductB1' class
  /// </summary>
  class ProductB1 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
    }
  }
  /// <summary>
  /// The 'ProductA2' class
  /// </summary>
  class ProductA2 : AbstractProductA
  {
  }
  /// <summary>
  /// The 'ProductB2' class
  /// </summary>
  class ProductB2 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name +
        " interacts with " + a.GetType().Name);
    }
  }
  /// <summary>
  /// The 'Client' class. Interaction environment for the products.
  /// </summary>
  class Client
  {
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;
    // Constructor
    public Client(AbstractFactory factory)
    {
      _abstractProductB = factory.CreateProductB();
      _abstractProductA = factory.CreateProductA();
    }
    public void Run()
    {
      _abstractProductB.Interact(_abstractProductA);
    }
  }
}
// Abstract Factory pattern -- Real World example 
using System;
namespace DoFactory.GangOfFour.Abstract.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World
  /// Abstract Factory Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    public static void Main()
    {
      // Create and run the African animal world
      ContinentFactory africa = new AfricaFactory();
      AnimalWorld world = new AnimalWorld(africa);
      world.RunFoodChain();
 
      // Create and run the American animal world
      ContinentFactory america = new AmericaFactory();
      world = new AnimalWorld(america);
      world.RunFoodChain();
 
      // Wait for user input
      Console.ReadKey();
    }
  }
  /// <summary>
  /// The 'AbstractFactory' abstract class
  /// </summary>
  abstract class ContinentFactory
  {
    public abstract Herbivore CreateHerbivore();
    public abstract Carnivore CreateCarnivore();
  }
 
  /// <summary>
  /// The 'ConcreteFactory1' class
  /// </summary>
  class AfricaFactory : ContinentFactory
  {
    public override Herbivore CreateHerbivore()
    {
      return new Wildebeest();
    }
    public override Carnivore CreateCarnivore()
    {
      return new Lion();
    }
  }
  /// <summary>
  /// The 'ConcreteFactory2' class
  /// </summary>
  class AmericaFactory : ContinentFactory
  {
    public override Herbivore CreateHerbivore()
    {
      return new Bison();
    }
    public override Carnivore CreateCarnivore()
    {
      return new Wolf();
    }
  }
 
  /// <summary>
  /// The 'AbstractProductA' abstract class
  /// </summary>
  abstract class Herbivore
  {
  }
 
  /// <summary>
  /// The 'AbstractProductB' abstract class
  /// </summary>
  abstract class Carnivore
  {
    public abstract void Eat(Herbivore h);
  }
 
  /// <summary>
  /// The 'ProductA1' class
  /// </summary>
  class Wildebeest : Herbivore
  {
  }
 
  /// <summary>
  /// The 'ProductB1' class
  /// </summary>
  class Lion : Carnivore
  {
    public override void Eat(Herbivore h)
    {
      // Eat Wildebeest
      Console.WriteLine(this.GetType().Name +
        " eats " + h.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'ProductA2' class
  /// </summary>
  class Bison : Herbivore
  {
  }
 
  /// <summary>
  /// The 'ProductB2' class
  /// </summary>
  class Wolf : Carnivore
  {
    public override void Eat(Herbivore h)
    {
      // Eat Bison
      Console.WriteLine(this.GetType().Name +
        " eats " + h.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'Client' class 
  /// </summary>
  class AnimalWorld
  {
    private Herbivore _herbivore;
    private Carnivore _carnivore;
 
    // Constructor
    public AnimalWorld(ContinentFactory factory)
    {
      _carnivore = factory.CreateCarnivore();
      _herbivore = factory.CreateHerbivore();
    }
 
    public void RunFoodChain()
    {
      _carnivore.Eat(_herbivore);
    }
  }
}
