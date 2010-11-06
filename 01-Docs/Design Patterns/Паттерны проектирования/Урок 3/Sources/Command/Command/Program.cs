using System;
namespace Command
{
    class MainApp
    {
        static void Main()
        {

            // Создаем объекты receiver, command, and invoker

            Receiver receiver = new Receiver();

            Command command = new ConcreteCommand(receiver);

            Invoker invoker = new Invoker();

            // Устанавливаем и запускаем команду

            invoker.SetCommand(command);

            invoker.ExecuteCommand();

            Console.ReadLine();

        }

    }

    //'Command' абстрактный класс

    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    // 'ConcreteCommand' класс
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) :

            base(receiver)
        {}
        public override void Execute()
        {
            receiver.Action();
        }

    }

    // The 'Receiver' класс

    class Receiver
    {

        public void Action()
        {

            Console.WriteLine("Вызван метод Receiver.Action()");

        }

    }
    // 'Invoker' класс
    class Invoker
    {
        private Command _command;
        public void SetCommand(Command command)
        {
            this._command = command;
        }
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

}
