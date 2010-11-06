using System;

namespace State
{

    class MainApp
    {

        static void Main()
        {

            // Создаём контекст в определенном состоянии

            Context c = new Context(new ConcreteStateA());



            // Вызываем операции, которые переключают состояние

            c.Request();

            c.Request();

            c.Request();

            c.Request();

            Console.ReadLine();

        }

    }


    // 'State' абстрактный класс

    abstract class State
    {

        public abstract void Handle(Context context);

    }

    //  'ConcreteStateA' класс

    class ConcreteStateA : State
    {

        public override void Handle(Context context)
        {

            context.State = new ConcreteStateB();

        }

    }

    // 'ConcreteStateB' class

    class ConcreteStateB : State
    {

        public override void Handle(Context context)
        {

            context.State = new ConcreteStateA();

        }

    }

    // 'Context' класс 

    class Context
    {

        private State _state;

        public Context(State state)
        {
            this.State = state;
        }
        public State State
        {

            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("Состояние: " +_state.GetType().Name);
            }
        }
        public void Request()
        {
            _state.Handle(this);
        }
    }
}
