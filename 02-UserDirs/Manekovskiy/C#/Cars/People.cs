using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People
{
    public class Man
    {
        private double height;
        
        public int Age
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Man(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public Man() : this("Anonymous", 0) { }

        public Man(string name) : this(name, 0) { }

        public Man(int age) : this("Anonymous", age) { }
    }

    public class Pupil : Man
    {
        public double AverageMark
        {
            get;
            set;
        }

        public string FavouriteSubject
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
