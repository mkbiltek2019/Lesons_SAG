using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01_timer_home
{
    public partial class Form1 : Form
    {
        Timer tim = new Timer();
        Label tm = new Label();
        DateTime d = new DateTime();
        int t=0;
        Button start = new Button();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightBlue;
            // this.Opacity = 0.5;
           // Label date = new Label();
            
            d = DateTime.Now;
            date.Visible = true;
            date.Text = (d.Day).ToString() + ". " + (d.Month).ToString() + ". " + (d.Year).ToString();
            //date.Location = new Point(50, 20);
            
            //this.Controls.Add(date);

           
            start.Location = new Point(22, 100);
            start.Text = "Start";
            start.Size = new Size(100, 25);
            start.Visible = true;
            this.Controls.Add(start);

            //tim.Enabled = true;
            tim.Interval = 1000;

            tm.Visible = false;

            start.Click += new EventHandler(start_Click);
            tim.Tick += new EventHandler(tim_Tick);

            digit.KeyPress += new KeyPressEventHandler(digit_KeyPress);
            digit2.KeyPress += new KeyPressEventHandler(digit2_KeyPress);

            res.Click += new EventHandler(res_Click);
        }

        void res_Click(object sender, EventArgs e)
        {
            int aa = int.Parse((digit.Text).ToString());
            int bb = int.Parse((digit2.Text).ToString());
            int cc = aa + bb;

            result.Text = cc.ToString();

        }

        void digit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tim.Enabled == true)
            {
                tim.Stop();
            }
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
         }

        void digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tim.Enabled == true)
            {
                tim.Stop();
            }
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        

        void tim_Tick(object sender, EventArgs e)
        {
            t++;
            tm.Text = t.ToString();
            if (t%3==0)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, 255);
                int g = rnd.Next(0, 255);
                int b = rnd.Next(0, 255);
                this.BackColor = Color.FromArgb(r, g, b);
                MessageBox.Show("Color: r=" + r.ToString() + "  g=" + g.ToString() + "  b=" + b.ToString());
            }

        }

        void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "Start")
            {
                tim.Start();
                tm.Location = new Point(105, 57);
                tm.Text = "0";
                this.Controls.Add(tm);
                tm.Visible = true;
                start.Text = "Stop";
                
            }
            else
            {
                tim.Stop();
                start.Text = "Start";
                t = 0;
            }


        }

       

       
       
      

      
    }
}
