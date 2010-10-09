namespace CarLibrary
{
    using System;

    public abstract class Car
    {
        protected Int16 curSpeed;
        protected Int16 maxSpeed;
        public Car() 
        {
        }
        public Car(Int16 max, Int16 cur)
        {
            maxSpeed = max;
            CurSpeed = cur;
        }
        public Int16 CurSpeed
        {
            get { return curSpeed; }
            set
            {
                if (value <= maxSpeed) curSpeed = value;
                else curSpeed = maxSpeed;
            }
        }
        public Int16 MaxSpeed
        {
            get { return maxSpeed; }
        }
        public abstract void Up();
        public abstract void Down();
    }
    public class Bus : Car
    {
        Int16 passengers;
        Int16 maxPassengers;
        public Bus() { }
        public Bus(Int16 max, Int16 cur, Int16 maxpass, Int16 pass)
            : base(max, cur)
        {
            maxPassengers = maxpass;
            Passengers = pass;
        }
        public Int16 Passengers
        {
            get { return passengers; }
            set
            {
                if (value <= maxPassengers) passengers = value;
                else passengers = maxPassengers;
            }
        }
        public Int16 MaxPassengers
        {
            get { return maxPassengers; }
        }
        public override void Up()
        {
            Passengers++;
        }
        public override void Down()
        {
            Passengers--;
        }
    }
    public class Truck : Car
    {
        Int16 cargo;
        Int16 maxCargo;
        public Truck() { }
        public Truck(Int16 max, Int16 cur, Int16 maxcrg, Int16 crg)
            : base(max, cur)
        {
            maxCargo = maxcrg;
            Cargo = crg;
        }
        public Int16 Cargo
        {
            get { return cargo; }
            set
            {
                if (value <= maxCargo) cargo = value;
                else cargo = maxCargo;
            }
        }
        public Int16 MaxCargo
        {
            get { return maxCargo; }
        }
        public override void Up()
        {
            Cargo = MaxCargo;
        }
        public override void Down()
        {
            Cargo = 0;
        }
    }
}
