using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stopwatch
{
   public class TabPageList:TabPage
    {
       public List<TabPage> tabpCircle = new List<TabPage>();
       public List<Label> tabpLabel = new List<Label>();
       public List<DateTime> dtList = new List<DateTime>(); 
        public TabPageList()
        {
            for (int i = 1; i < 10; i++)
            {
                dtList.Add(new DateTime());
                tabpLabel.Add(new Label());
                tabpLabel[i-1].Name = Convert.ToString(i);
                tabpLabel[i-1].Text = "0:00:00:0";
                tabpLabel[i - 1].Font = new Font("Microsoft Sans Serif",40);
                tabpLabel[i - 1].AutoSize = true;
                tabpLabel[i - 1].Location =new Point(0,10);
                tabpCircle.Add(new TabPage(Convert.ToString(i)));
                tabpCircle[i - 1].Controls.Add(tabpLabel[i - 1]);
                

            }

        }
       public int Index { get; set; }
       public TabPage this[int index]
       {
           get { return tabpCircle[index]; }
           set { tabpCircle[index] = value; }
       }
    }
}
