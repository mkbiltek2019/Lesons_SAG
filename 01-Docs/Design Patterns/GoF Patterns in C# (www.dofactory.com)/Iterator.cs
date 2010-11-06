// Iterator pattern -- Structural example 
using System;
using System.Collections;
 
namespace DoFactory.GangOfFour.Iterator.Structural
{
    /// <summary>
    /// MainApp startup class for Structural 
    /// Iterator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";
 
            // Create Iterator and provide aggregate
            ConcreteIterator i = new ConcreteIterator(a);
 
            Console.WriteLine("Iterating over collection:");
 
            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
 
            // Wait for user
            Console.ReadKey();
        }
    }
 
    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
 
    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();
 
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
 
        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }
 
        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
 
    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
 
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;
 
        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }
 
        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }
 
        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
 
            return ret;
        }
 
        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }
 
        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}
// Iterator pattern -- Real World example 
using System;
using System.Collections;
 
namespace DoFactory.GangOfFour.Iterator.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Iterator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");
 
            // Create iterator
            Iterator iterator = new Iterator(collection);
 
            // Skip every other item
            iterator.Step = 2;
 
            Console.WriteLine("Iterating over collection:");
 
            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
 
            // Wait for user
            Console.ReadKey();
        }
    }
 
    /// <summary>
    /// A collection item
    /// </summary>
    class Item
    {
        private string _name;
 
        // Constructor
        public Item(string name)
        {
            this._name = name;
        }
 
        // Gets name
        public string Name
        {
            get { return _name; }
        }
    }
 
    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
 
    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    class Collection : IAbstractCollection
    {
        private ArrayList _items = new ArrayList();
 
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
 
        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }
 
        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
 
    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }
 
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;
 
        // Constructor
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }
 
        // Gets first item
        public Item First()
        {
            _current = 0;
            return _collection[_current] as Item;
        }
 
        // Gets next item
        public Item Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as Item;
            else
                return null;
        }
 
        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
 
        // Gets current iterator item
        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }
 
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}
