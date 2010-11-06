// Template Method pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Template.Structural
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Template Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      AbstractClass aA = new ConcreteClassA();
      aA.TemplateMethod();
 
      AbstractClass aB = new ConcreteClassB();
      aB.TemplateMethod();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'AbstractClass' abstract class
  /// </summary>
  abstract class AbstractClass
  {
    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();
 
    // The "Template method"
    public void TemplateMethod()
    {
      PrimitiveOperation1();
      PrimitiveOperation2();
      Console.WriteLine("");
    }
  }
 
  /// <summary>
  /// A 'ConcreteClass' class
  /// </summary>
  class ConcreteClassA : AbstractClass
  {
    public override void PrimitiveOperation1()
    {
      Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
      Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
    }
  }
 
  /// <summary>
  /// A 'ConcreteClass' class
  /// </summary>
  class ConcreteClassB : AbstractClass
  {
    public override void PrimitiveOperation1()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
    }
  }
}
// Template Method pattern -- Real World example 
using System;
using System.Data;
using System.Data.OleDb;
 
namespace DoFactory.GangOfFour.Template.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Template Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      DataAccessObject daoCategories = new Categories();
      daoCategories.Run();
 
      DataAccessObject daoProducts = new Products();
      daoProducts.Run();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'AbstractClass' abstract class
  /// </summary>
  abstract class DataAccessObject
  {
    protected string connectionString;
    protected DataSet dataSet;
 
    public virtual void Connect()
    {
      // Make sure mdb is available to app
      connectionString =
        "provider=Microsoft.JET.OLEDB.4.0; " +
        "data source=..\\..\\..\\db1.mdb";
    }
 
    public abstract void Select();
    public abstract void Process();
 
    public virtual void Disconnect()
    {
      connectionString = "";
    }
 
    // The 'Template Method' 
    public void Run()
    {
      Connect();
      Select();
      Process();
      Disconnect();
    }
  }
 
  /// <summary>
  /// A 'ConcreteClass' class
  /// </summary>
  class Categories : DataAccessObject
  {
    public override void Select()
    {
      string sql = "select CategoryName from Categories";
      OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
        sql, connectionString);
 
      dataSet = new DataSet();
      dataAdapter.Fill(dataSet, "Categories");
    }
 
    public override void Process()
    {
      Console.WriteLine("Categories ---- ");
 
      DataTable dataTable = dataSet.Tables["Categories"];
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine(row["CategoryName"]);
      }
      Console.WriteLine();
    }
  }
 
  /// <summary>
  /// A 'ConcreteClass' class
  /// </summary>
  class Products : DataAccessObject
  {
    public override void Select()
    {
      string sql = "select ProductName from Products";
      OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
        sql, connectionString);
 
      dataSet = new DataSet();
      dataAdapter.Fill(dataSet, "Products");
    }
 
    public override void Process()
    {
      Console.WriteLine("Products ---- ");
      DataTable dataTable = dataSet.Tables["Products"];
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine(row["ProductName"]);
      }
      Console.WriteLine();
    }
  }
}
