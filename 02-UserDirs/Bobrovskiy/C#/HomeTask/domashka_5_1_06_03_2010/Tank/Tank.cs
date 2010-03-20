using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyASCIITank.MilitariMashine;

namespace MyASCIITank.MyTank
{
    public enum MoveDirection
    {
        Forward,
        Backward
    }

    public abstract class Tank : MilitariMachine
    {
        public override void Move(MoveDirection direction) { }

        public override void Fire() { }
    }   
}
