using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ControlUser
{
    public delegate void ActionDouvleHendler();
    class ClasFile
    {
        public string PathFile { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public Icon IconFile { get; set; }
        public string ExtensionFile { get; set; }
        public ActionDouvleHendler Action { get; set; }
        

        public ClasFile()
        {
            PathFile = string.Empty;
            Name = string.Empty;
            Size = string.Empty;
            IconFile = null;
            ExtensionFile = string.Empty;
            
            
        }
    }
}
