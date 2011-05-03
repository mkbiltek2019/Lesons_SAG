using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadMenager.UI
{
    public class StatusChangedArgs : EventArgs
    {
        
        public int Index { get; private set; }

        public StatusChangedArgs( int index)
        {
            Index = index;
        }
    }
}
