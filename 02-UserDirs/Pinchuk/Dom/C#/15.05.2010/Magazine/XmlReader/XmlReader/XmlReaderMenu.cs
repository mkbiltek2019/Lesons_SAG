using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Console;
using System.Xml.Linq;

namespace XmlReader
{
    class XmlReaderMenu
    {
        #region Propirties

        public string FileName { get; set; }
        public XDocument xDoc{ get; set;} 

        #endregion


        #region Constructor

        public XmlReaderMenu(string fileName)
        {
            FileName = fileName;
            xDoc = XDocument.Load(FileName);
        } 

        #endregion

        internal object Element(string p)
        {
            throw new NotImplementedException();
        }
    }
}
