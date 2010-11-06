using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    public class TextJuggedArrayBuilder : JuggedArrayBuilder
    {
        private StringBuilder text = null;

        public override void Initialize()
        {
            text = new StringBuilder();
        }
        public override void AddItem(double item)
        {
            text.Append(item);
            text.Append(" ");
        }
        public override void FinishRow()
        {
            text.AppendLine();
        }
        public override object Result()
        {            
            return text;
        }
    }
}