// Mediator pattern -- Structural example 
using System;
 
namespace DoFactory.GangOfFour.Mediator.Structural
{
  /// <summary>
  /// MainApp startup class for Structural 
  /// Mediator Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      ConcreteMediator m = new ConcreteMediator();
 
      ConcreteColleague1 c1 = new ConcreteColleague1(m);
      ConcreteColleague2 c2 = new ConcreteColleague2(m);
 
      m.Colleague1 = c1;
      m.Colleague2 = c2;
 
      c1.Send("How are you?");
      c2.Send("Fine, thanks");
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Mediator' abstract class
  /// </summary>
  abstract class Mediator
  {
    public abstract void Send(string message,
      Colleague colleague);
  }
 
  /// <summary>
  /// The 'ConcreteMediator' class
  /// </summary>
  class ConcreteMediator : Mediator
  {
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;
 
    public ConcreteColleague1 Colleague1
    {
      set { _colleague1 = value; }
    }
 
    public ConcreteColleague2 Colleague2
    {
      set { _colleague2 = value; }
    }
 
    public override void Send(string message,
      Colleague colleague)
    {
      if (colleague == _colleague1)
      {
        _colleague2.Notify(message);
      }
      else
      {
        _colleague1.Notify(message);
      }
    }
  }
 
  /// <summary>
  /// The 'Colleague' abstract class
  /// </summary>
  abstract class Colleague
  {
    protected Mediator mediator;
 
    // Constructor
    public Colleague(Mediator mediator)
    {
      this.mediator = mediator;
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class ConcreteColleague1 : Colleague
  {
    // Constructor
    public ConcreteColleague1(Mediator mediator)
      : base(mediator)
    {
    }
 
    public void Send(string message)
    {
      mediator.Send(message, this);
    }
 
    public void Notify(string message)
    {
      Console.WriteLine("Colleague1 gets message: "
        + message);
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class ConcreteColleague2 : Colleague
  {
    // Constructor
    public ConcreteColleague2(Mediator mediator)
      : base(mediator)
    {
    }
 
    public void Send(string message)
    {
      mediator.Send(message, this);
    }
 
    public void Notify(string message)
    {
      Console.WriteLine("Colleague2 gets message: "
        + message);
    }
  }
}
// Mediator pattern -- Real World example 
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Mediator.RealWorld
{
  /// <summary>
  /// MainApp startup class for Real-World 
  /// Mediator Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Create chatroom
      Chatroom chatroom = new Chatroom();
 
      // Create participants and register them
      Participant George = new Beatle("George");
      Participant Paul = new Beatle("Paul");
      Participant Ringo = new Beatle("Ringo");
      Participant John = new Beatle("John");
      Participant Yoko = new NonBeatle("Yoko");
 
      chatroom.Register(George);
      chatroom.Register(Paul);
      chatroom.Register(Ringo);
      chatroom.Register(John);
      chatroom.Register(Yoko);
 
      // Chatting participants
      Yoko.Send("John", "Hi John!");
      Paul.Send("Ringo", "All you need is love");
      Ringo.Send("George", "My sweet Lord");
      Paul.Send("John", "Can't buy me love");
      John.Send("Yoko", "My sweet love");
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Mediator' abstract class
  /// </summary>
  abstract class AbstractChatroom
  {
    public abstract void Register(Participant participant);
    public abstract void Send(
      string from, string to, string message);
  }
 
  /// <summary>
  /// The 'ConcreteMediator' class
  /// </summary>
  class Chatroom : AbstractChatroom
  {
    private Dictionary<string,Participant> _participants = 
      new Dictionary<string,Participant>();
 
    public override void Register(Participant participant)
    {
      if (!_participants.ContainsValue(participant))
      {
        _participants[participant.Name] = participant;
      }
 
      participant.Chatroom = this;
    }
 
    public override void Send(
      string from, string to, string message)
    {
      Participant participant = _participants[to];
 
      if (participant != null)
      {
        participant.Receive(from, message);
      }
    }
  }
 
  /// <summary>
  /// The 'AbstractColleague' class
  /// </summary>
  class Participant
  {
    private Chatroom _chatroom;
    private string _name;
 
    // Constructor
    public Participant(string name)
    {
      this._name = name;
    }
 
    // Gets participant name
    public string Name
    {
      get { return _name; }
    }
 
    // Gets chatroom
    public Chatroom Chatroom
    {
      set { _chatroom = value; }
      get { return _chatroom; }
    }
 
    // Sends message to given participant
    public void Send(string to, string message)
    {
      _chatroom.Send(_name, to, message);
    }
 
    // Receives message from given participant
    public virtual void Receive(
      string from, string message)
    {
      Console.WriteLine("{0} to {1}: '{2}'",
        from, Name, message);
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class Beatle : Participant
  {
    // Constructor
    public Beatle(string name)
      : base(name)
    {
    }
 
    public override void Receive(string from, string message)
    {
      Console.Write("To a Beatle: ");
      base.Receive(from, message);
    }
  }
 
  /// <summary>
  /// A 'ConcreteColleague' class
  /// </summary>
  class NonBeatle : Participant
  {
    // Constructor
    public NonBeatle(string name)
      : base(name)
    {
    }
 
    public override void Receive(string from, string message)
    {
      Console.Write("To a non-Beatle: ");
      base.Receive(from, message);
    }
  }
}
