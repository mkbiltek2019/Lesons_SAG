using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CockroachRaces
{
   public class Cockroach:Marathon
    {
       public int Speed { get; set; }
       public int Distamce { get; set; }
      // public  string VisualCockroch = "██";

      

       public struct PositionConcroach
       {
           public int X{ get; set;}
           public int Y{ get; set;}

       }

        #region Constructor

       public  Cockroach(int x, int y)
       {
           Random random = new Random();
           PositionConcroach positionConcroach = new PositionConcroach();
           positionConcroach.X = x;
           positionConcroach.X = y;
           Speed = random.Next(10, 20);

       }
        #endregion


    }
}
