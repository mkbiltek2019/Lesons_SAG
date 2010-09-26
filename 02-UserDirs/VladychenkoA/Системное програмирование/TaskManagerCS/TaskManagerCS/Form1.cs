using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Threading.Timer;

namespace TaskManagerCS
{
    public partial class Form1 : Form
    {
        public bool erroccured = false;
        public Hashtable presentprocdetails;
        public static string mcname = ".";
        public Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
           }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllProcessesOnStartup();
            presentprocdetails = new Hashtable();
            TimerCallback timerCallback = LoadAllProcesses;
             timer = new Timer(timerCallback, null, 1000, 1000);
        }

        private void LoadAllProcessesOnStartup()
        {

            Process[] processes;
            try
            {
                processes = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
                return;
            }
            int threadscount = 0;
            foreach (Process p in processes)
            {
                try
                {
                    string[] prcdetails = new string[] { p.ProcessName, p.Id.ToString(), p.StartTime.ToShortTimeString(), p.TotalProcessorTime.Duration().Hours.ToString() + ":" + p.TotalProcessorTime.Duration().Minutes.ToString() + ":" + p.TotalProcessorTime.Duration().Seconds.ToString(), (p.WorkingSet / 1024).ToString() + "k", (p.PeakWorkingSet / 1024).ToString() + "k", p.HandleCount.ToString(), p.Threads.Count.ToString() };
                    ListViewItem proc = new ListViewItem(prcdetails);
                    listView.Items.Add(proc);
                    threadscount += p.Threads.Count;
                }
                catch { }
            }
            toolStripStatusLabel1.Text = "Процессов : " + processes.Length;
            toolStripStatusLabel2.Text = "Потоков : " + (threadscount + 1);
        }
        private void LoadAllProcesses(object temp)
        {
          try
			{
                Process[] processes;
				presentprocdetails.Clear();
				processes = Process.GetProcesses(mcname);
				bool runningproccountchanged= false;
				Hashtable lvprocesses = null;
				int threadscount = 0;
				foreach(Process p in processes)
				{
					try
					{
						string[] prcdetails = new string[]{p.ProcessName,p.Id.ToString(),p.StartTime.ToShortTimeString(),p.TotalProcessorTime.Duration().Hours.ToString()+":"+p.TotalProcessorTime.Duration().Minutes.ToString()+":"+p.TotalProcessorTime.Duration().Seconds.ToString(),(p.WorkingSet/1024).ToString()+"k",(p.PeakWorkingSet/1024).ToString()+"k",p.HandleCount.ToString(),p.Threads.Count.ToString()};
						presentprocdetails.Add(prcdetails[1],prcdetails[0].ToString()+"#"+prcdetails[2].ToString()+"#"+prcdetails[3].ToString()+"#"+prcdetails[4].ToString()+"#"+prcdetails[5].ToString()+"#"+prcdetails[6].ToString()+"#"+prcdetails[7].ToString());
						threadscount += p.Threads.Count;
					}
					catch{}
				}
				if((processes.Length != listView.Items.Count) || erroccured)
				{
					runningproccountchanged = true;
					lvprocesses = new Hashtable();
					foreach(ListViewItem item in listView.Items)
					{
						lvprocesses.Add(item.SubItems[1].Text,"");
					}
				}
				if(runningproccountchanged || erroccured)
				{
					erroccured = false;
					foreach(Process p in Process.GetProcesses(mcname))
					{
						try
						{
							if(!lvprocesses.Contains(p.Id.ToString()))
							{
								string[] newprcdetails = new string[]{p.ProcessName,p.Id.ToString(),p.StartTime.ToShortTimeString(),p.TotalProcessorTime.Duration().Hours.ToString()+":"+p.TotalProcessorTime.Duration().Minutes.ToString()+":"+p.TotalProcessorTime.Duration().Seconds.ToString(),(p.WorkingSet/1024).ToString()+"k",(p.PeakWorkingSet/1024).ToString()+"k",p.HandleCount.ToString(),p.Threads.Count.ToString()};
								ListViewItem newprocess = new ListViewItem(newprcdetails);
								listView.Items.Add(newprocess);
							}
							IDictionaryEnumerator enlvprocesses = lvprocesses.GetEnumerator();
							while(enlvprocesses.MoveNext())
							{
								if(!presentprocdetails.Contains(enlvprocesses.Key))
								{
									foreach(ListViewItem item in listView.Items)
									{
										if(item.SubItems[1].Text.ToString().ToUpper() == enlvprocesses.Key.ToString().ToUpper())
										{
											listView.Items.Remove(item);
										}
									}
								}
							}
						}
						catch{}
					}
				}
				
				 toolStripStatusLabel1.Text = "Процессов : " + processes.Length;
                  toolStripStatusLabel2.Text = "Потоков : " + (threadscount + 1);
			}
			catch{}
		}
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //LoadAllProcesses();
            //presentprocdetails = new Hashtable();
            //TimerCallback timerCallback = LoadAllProcesses;
            //Timer timer = new Timer(timerCallback, null, 1000, 100);
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "Диспетчер задач ", "Свернуто в трей", ToolTipIcon.Info);
            }
        }
          

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
           if (Equals(WindowState, FormWindowState.Minimized))
            {
                notifyIcon1.Text = "Диспетчер задач в не видимом режиме";
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void разверутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выхоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void завершитьПроцессToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count >= 1)
            {
                try
                {
                    int selectedpid = Convert.ToInt32(listView.SelectedItems[0].SubItems[1].Text);
                    Process.GetProcessById(selectedpid, mcname).Kill();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
    }
}
