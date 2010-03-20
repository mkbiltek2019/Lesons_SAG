using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyASCIITank.MyTank;

namespace MyASCIITank.MilitariMashine
{
    public abstract class MilitariMachine
    {
        public MoveDirection CurentDirection
        {
            get;
            set;
        }

        public virtual void Move()
        {
            Move(CurentDirection);
        }

        public abstract void Move(MoveDirection direction);
        public abstract void Fire();
    }   
}
