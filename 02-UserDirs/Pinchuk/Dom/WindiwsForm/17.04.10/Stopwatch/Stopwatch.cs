using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Stopwatch : Form
    {
        Timer tmStopwatch = new Timer();
        DateTime dtStopwatch = new DateTime(2010, 2, 10, 0, 0, 0, 0);
        TabPageList tabPageList = new TabPageList();
        public Stopwatch()
        {
            InitializeComponent();
            tmStopwatch.Tick += new EventHandler(TmStopwatchTick);
            lbStopwatchResult.Text = String.Format("{0}:{1}", dtStopwatch.ToLongTimeString(), dtStopwatch.Millisecond);
            this.MaximizeBox = false;
            this.Shown += new EventHandler(StopwatchShown);
        }

        void StopwatchShown(object sender, EventArgs e)
        {
             this.MaximumSize = new Size(331, 299);
             this.MinimumSize = new Size(331, 299);
        }
        void TmStopwatchTick(object sender, EventArgs e)
        {
            dtStopwatch = dtStopwatch.AddMilliseconds(100);
            tabPageList.dtList[tabPageList.Index - 1] = tabPageList.dtList[tabPageList.Index - 1].AddMilliseconds(100);
            lbStopwatchResult.Text = String.Format("{0}:{1}", dtStopwatch.ToLongTimeString(), dtStopwatch.Millisecond / 100);
            tabPageList.tabpLabel[tabPageList.Index - 1].Text = String.Format("{0}:{1}", tabPageList.dtList[tabPageList.Index - 1].ToLongTimeString(), tabPageList.dtList[tabPageList.Index - 1].Millisecond / 100);
        }
        private void TmStartClick(object sender, EventArgs e)
        {
            switch (btControlStopwatch.Text)
            {
                case "Старт":
                    tmStopwatch.Enabled = true;
                    tmStopwatch.Interval = 100;
                    tmStopwatch.Start();
                    btControlStopwatch.Text = "Стоп";
                    btStopwatchOptions.Visible = true;
                    tabPageList.Index = 0;
                    tabCircle.Controls.Add(tabPageList[tabPageList.Index]);
                    tabPageList[tabPageList.Index].UseVisualStyleBackColor = true;
                    tabPageList.Index++;
                    break;
                case "Стоп":
                    tmStopwatch.Stop();
                    btControlStopwatch.Text = "Продовжити";
                    btStopwatchOptions.Text = "Скинути";
                    btStopwatchOptions.Enabled = true;
                    break;
                case "Продовжити":
                    tmStopwatch.Start();
                    btControlStopwatch.Text = "Стоп";
                    btStopwatchOptions.Text = "Новий круг";
                    if(tabPageList.Index == 9)
                        btStopwatchOptions.Enabled = false;

                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }
        private void BtStopwatchOptionsClick(object sender, EventArgs e)
        {
            switch (btStopwatchOptions.Text)
            {
                case "Скинути":
                    tabCircle.Controls.Clear();
                    btControlStopwatch.Text = "Старт";
                    btStopwatchOptions.Visible = false;
                    btStopwatchOptions.Text = "Новий круг";
                    dtStopwatch = new DateTime(2010, 2, 10, 0, 0, 0, 0);
                    lbStopwatchResult.Text = String.Format("{0}:{1}", dtStopwatch.ToLongTimeString(), dtStopwatch.Millisecond / 100);
                    for (int i = 0; i < tabPageList.dtList.Count; i++)
                    {
                        tabPageList.dtList[i] = new DateTime(2010, 2, 10, 0, 0, 0, 0);
                    }
                    break;
                case "Новий круг":
                    tabCircle.Controls.Add(tabPageList[tabPageList.Index]);
                    tabPageList[tabPageList.Index].UseVisualStyleBackColor = true;
                    tabCircle.SelectTab(tabPageList.Index) ;
                    tabPageList.Index++;
                    if (tabPageList.Index ==9)
                    {
                        btStopwatchOptions.Enabled = false;
                    }
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }
    }
}
