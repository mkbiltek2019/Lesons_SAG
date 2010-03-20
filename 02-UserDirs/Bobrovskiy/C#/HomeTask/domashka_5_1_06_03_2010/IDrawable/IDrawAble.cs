using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyASCIITank.MyIDrawable
{
    public interface IDrawable
    {
        int Top
        {
            get;
        }

        int Left
        {
            get;
        }

        void Draw();
    }
}
