using System;
using System.Windows.Forms;
using CarLibrary;
using System.Threading;

namespace Cars
{
    public partial class Form1 : Form
    {
        Bus bus = new Bus(70, 60, 25, 14);
        Truck truck = new Truck(90, 40, 2000, 500);
        System.Windows.Forms.Timer tim;
        Thread [] tbus;
        Random delay = new Random();
        public Form1()
        {
            InitializeComponent();
            lTruck.Text += truck.Cargo;
            tbus = new [] {new Thread(new ThreadStart(UpBus)),
                           new Thread(new ThreadStart(DownBus))};
            tbus[0].Start();
            tbus[1].Start();
            tim = new System.Windows.Forms.Timer();
            tim.Interval = 10;
            tim.Tick += new EventHandler(tim_Tick);
            tim.Start();
        }

        void UpBus()
        {
            while (true)
            {
                lock (this)
                {
                    bus.Up();
                }
                Thread.Sleep(delay.Next(500) + delay.Next(500));
            }
        }
        void DownBus()
        {
            while (true)
            {
                lock (this)
                {
                    bus.Down();
                }
                Thread.Sleep(delay.Next(500) + delay.Next(500));
            }
        }

        void tim_Tick(object sender, EventArgs e)
        {
            lBus.Text = "Количество пассажиров: " + bus.Passengers;
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            truck.Up();
            lTruck.Text = "Груз: " + truck.Cargo;
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            truck.Down();
            lTruck.Text = "Груз: " + truck.Cargo;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tbus[0].Abort();
            tbus[1].Abort();
        }

    }
}
