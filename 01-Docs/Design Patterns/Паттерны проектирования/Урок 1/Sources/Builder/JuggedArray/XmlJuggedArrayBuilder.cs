using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    public class XmlJuggedArrayBuilder : JuggedArrayBuilder
    {
        private StringBuilder xml = null;

        public override void Initialize()
        {
            xml = new StringBuilder();
        }
        public override void Start()
        {
            xml.AppendLine("<JuggedArray>");
            xml.AppendLine("<rows>");
        }
        public override void StartRow()
        {
            xml.AppendLine("<row>");
        }
        public override void AddItem(double item)
        {
            xml.Append("<item>");
            xml.Append(item);
            xml.Append("</item>");
            xml.AppendLine();
        }
        public override void FinishRow()
        {
            xml.AppendLine("</row>");
        }
        public override void Finish()
        {
            xml.AppendLine("</rows>");                
            xml.AppendLine("</JuggedArray>");
        }
        public override object Result()
        {
            return xml;
        }
    }
}
