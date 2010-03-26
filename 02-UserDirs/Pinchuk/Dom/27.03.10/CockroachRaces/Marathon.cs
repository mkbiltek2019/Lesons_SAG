using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CockroachRaces
{
    public class Marathon:ICockroachRacesMarathon
    {

        public event StartMarathonHandler StartMarathon;
        public event StopMarathonHandler StopMarathon; 
        public int Distance { get; set; }
        public List<Cockroach> CockroachList;

        #region constructor
        public  Marathon ()
        {
            Distance = 20;
           // Cockroach cockroach= new Cockroach(1,2);
          //  CockroachList.Add(cockroach);
                //CockroachList.Add( Cockroach(1,2));
        }
        #endregion

        public void Start()
        {
            
        }
        public void PrintResult()
        {

        }

        public  void Draw()
        {
            foreach (Cockroach list in CockroachList)
            {
                //Console.WriteLine(list.VisualCockroch);
            }   
        }
    }
}
