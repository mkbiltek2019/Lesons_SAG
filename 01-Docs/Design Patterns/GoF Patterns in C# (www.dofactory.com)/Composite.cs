// Composite pattern -- Structural example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Composite.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Composite Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create a tree structure
      Composite root = new Composite("root");
      root.Add(new Leaf("Leaf A"));
      root.Add(new Leaf("Leaf B"));
 
      Composite comp = new Composite("Composite X");
      comp.Add(new Leaf("Leaf XA"));
      comp.Add(new Leaf("Leaf XB"));
 
      root.Add(comp);
      root.Add(new Leaf("Leaf C"));
 
      // Add and remove a leaf
      Leaf leaf = new Leaf("Leaf D");
      root.Add(leaf);
      root.Remove(leaf);
 
      // Recursively display tree
      root.Display(1);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Component' abstract class
  /// </summary>
  abstract class Component
  {
    protected string name;
 
    // Constructor
    public Component(string name)
    {
      this.name = name;
    }
 
    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
  }
 
  /// <summary>
  /// The 'Composite' class
  /// </summary>
  class Composite : Component
  {
    private List<Component> _children = new List<Component>();
 
    // Constructor
    public Composite(string name)
      : base(name)
    {
    }
 
    public override void Add(Component component)
    {
      _children.Add(component);
    }
 
    public override void Remove(Component component)
    {
      _children.Remove(component);
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
 
      // Recursively display child nodes
      foreach (Component component in _children)
      {
        component.Display(depth + 2);
      }
    }
  }
 
  /// <summary>
  /// The 'Leaf' class
  /// </summary>
  class Leaf : Component
  {
    // Constructor
    public Leaf(string name)
      : base(name)
    {
    }
 
    public override void Add(Component c)
    {
      Console.WriteLine("Cannot add to a leaf");
    }
 
    public override void Remove(Component c)
    {
      Console.WriteLine("Cannot remove from a leaf");
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
    }
  }
}
// Composite pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Composite.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Composite Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create a tree structure 
      CompositeElement root =
        new CompositeElement("Picture");
      root.Add(new PrimitiveElement("Red Line"));
      root.Add(new PrimitiveElement("Blue Circle"));
      root.Add(new PrimitiveElement("Green Box"));
 
      // Create a branch
      CompositeElement comp =
        new CompositeElement("Two Circles");
      comp.Add(new PrimitiveElement("Black Circle"));
      comp.Add(new PrimitiveElement("White Circle"));
      root.Add(comp);
 
      // Add and remove a PrimitiveElement
      PrimitiveElement pe =
        new PrimitiveElement("Yellow Line");
      root.Add(pe);
      root.Remove(pe);
 
      // Recursively display nodes
      root.Display(1);
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Component' Treenode
  /// </summary>
  abstract class DrawingElement
  {
    protected string _name;
 
    // Constructor
    public DrawingElement(string name)
    {
      this._name = name;
    }
 
    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
  }
 
  /// <summary>
  /// The 'Leaf' class
  /// </summary>
  class PrimitiveElement : DrawingElement
  {
    // Constructor
    public PrimitiveElement(string name)
      : base(name)
    {
    }
 
    public override void Add(DrawingElement c)
    {
      Console.WriteLine(
        "Cannot add to a PrimitiveElement");
    }
 
    public override void Remove(DrawingElement c)
    {
      Console.WriteLine(
        "Cannot remove from a PrimitiveElement");
    }
 
    public override void Display(int indent)
    {
      Console.WriteLine(
        new String('-', indent) + " " + _name);
    }
  }
 
  /// <summary>
  /// The 'Composite' class
  /// </summary>
  class CompositeElement : DrawingElement
  {
    private List<DrawingElement> elements = 
      new List<DrawingElement>();
 
    // Constructor
    public CompositeElement(string name)
      : base(name)
    {
    }
 
    public override void Add(DrawingElement d)
    {
      elements.Add(d);
    }
 
    public override void Remove(DrawingElement d)
    {
      elements.Remove(d);
    }
 
    public override void Display(int indent)
    {
      Console.WriteLine(new String('-', indent) +
        "+ " + _name);
 
      // Display each child element on this node
      foreach (DrawingElement d in elements)
      {
        d.Display(indent + 2);
      }
    }
  }
}
