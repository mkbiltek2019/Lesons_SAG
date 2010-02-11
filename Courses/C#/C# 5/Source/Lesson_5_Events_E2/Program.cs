using System;
using System.Threading;

namespace Lesson_5_Events_E2
{
    public delegate void TickEventHandler(Object sender, TickerArgs args);
    public class TickerArgs : EventArgs
    {
        public Int32 Tick;
        public TickerArgs(Int32 tick) { this.Tick = tick; }
    }

    public class Ticker
    {
        public event TickEventHandler TickEvent;

        private Boolean isEnabled = false;
        public Boolean IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        private Int32 ticks = 0;

        public void RunTiker()
        {
            while (isEnabled && TickEvent != null)
            {
                ticks++;
                TickEvent(this, new TickerArgs(ticks));
                Thread.Sleep(10);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Ticker ticker = new Ticker();
            ticker.TickEvent += new TickEventHandler(ticker_TickEvent);

            TickerFilter tf = new TickerFilter(ticker);

            ticker.IsEnabled = true;
            Thread thr = new Thread(new System.Threading.ThreadStart(ticker.RunTiker));
            thr.Start();

            Thread.Sleep(150);
            ticker.IsEnabled = false;
        }

        static void ticker_TickEvent(object sender, TickerArgs args)
        {
            Console.WriteLine("Сработал обработчик описанный в классе Program, Tick = "
                + args.Tick.ToString());
        }
    }

    public class TickerFilter
    {
        private Ticker ticker;
        public TickerFilter(Ticker ticker)
        {
            this.ticker = ticker;
            this.ticker.TickEvent += new TickEventHandler(ticker_TickEvent);
        }

        void ticker_TickEvent(object sender, TickerArgs args)
        {
            if (args.Tick % 5 == 0)
                Console.WriteLine("Сработал обработчик описанный в классе TickerFilter, Tick = "
                    + args.Tick.ToString());
        }
    }
}
