using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    public abstract class JuggedArrayBuilder
    {
        public virtual void Initialize()
        {            
        }
        public virtual void Start()
        {
        }
        public virtual void StartRow()
        {
        }
        public virtual void AddItem(double item)
        {
        }
        public virtual void FinishRow()
        {
        }
        public virtual void Finish()
        {
        }
        public abstract object Result();
    }
}
