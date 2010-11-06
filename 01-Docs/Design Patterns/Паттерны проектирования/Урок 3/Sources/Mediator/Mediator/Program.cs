using System;
namespace Mediator
{

    class MainApp
    {

        static void Main()
        {

            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);

            ConcreteColleague2 c2 = new ConcreteColleague2(m);



            m.Colleague1 = c1;

            m.Colleague2 = c2;



            c1.Send("Как дела?");

            c2.Send("Хорошо спасибо");

            Console.ReadLine();

        }

    }

    // 'Mediator' абстрактный класс

    abstract class Mediator
    {

        public abstract void Send(string message,

          Colleague colleague);

    }

    // 'ConcreteMediator' класс
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
        public override void Send(string message,Colleague colleague)
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

    // 'Colleague' абстрактный класс
    abstract class Colleague
    {

        protected Mediator mediator;

        // Конструктор

        public Colleague(Mediator mediator)
        {

            this.mediator = mediator;

        }

    }

    // 'ConcreteColleague1' класс

    class ConcreteColleague1 : Colleague
    {

        // Конструктор

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

            Console.WriteLine("Colleague1 получил сообщение: "+ message);

        }

    }
    

    // 'ConcreteColleague2' класс
    class ConcreteColleague2 : Colleague
    {

        // Конструктор 
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
            Console.WriteLine("Colleague2 получил сообщение: " + message);
        }

    }

}