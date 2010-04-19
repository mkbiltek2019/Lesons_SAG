using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CountdownTimer
{
    
    public class CountdownTimer
    {
        
        public TimeSpan Timeleft{ get; set;}
        public string []  StartRun = new []{"START",""};
   
        public CountdownTimer(TimeSpan timestart)
        {
            Timeleft = timestart;
            
        }
        public void Start(Timer timer)
        {
            timer.Start();
        }

        public void Stop(Timer timer)
        {
            timer.Stop();
        }
        public void UdateTime(Timer timer, Label label)
        {
            if (Timeleft != TimeSpan.Zero)
            {
                Timeleft -= TimeSpan.FromMilliseconds(timer.Interval);
                label.Text = String.Format("{0:00}:{1:00}:{2}",
                                                      Timeleft.Minutes,
                                                      Timeleft.Seconds,
                                                      Timeleft.Milliseconds / 100);
                
            }
            else
            {
                timer.Stop();
                MessageBox.Show( "DONE!!!","Timer Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
