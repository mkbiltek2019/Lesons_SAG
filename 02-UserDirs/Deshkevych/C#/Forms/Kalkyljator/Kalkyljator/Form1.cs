using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kalkyljator
{

    public partial class Form1 : Form
    {
        private const int
            bw = 40, bh = 25,
            bdx = 5, bdy = 5;

        private Button[] d = new Button[11];

        private Button[] op = new Button[4];

        private double ac;
        private string co;
        private Boolean fd;


        public Form1()
        {
            InitializeComponent();

            int x, y;

            this.ClientSize = new System.Drawing.Size(4 * bw + 5 * bdx, 5 * bh + 7 * bdy);

            label1.SetBounds(bdx, bdy, 4 * bw + 3 * bdx, bh);
            label1.Text = "0";

            for (int i = 0; i <= 10; i++)
            {
                d[i] = new Button();
                if (i < 10)
                {
                    d[i].Name = "Button" + Convert.ToString(i);
                    d[i].Text = i.ToString();


                    if (i != 0)
                    {
                        x = ((i - 1) % 3) * bw +
                            (((i - 1) % 3) + 1) * bdx;
                        y = ((int)((9 - i) / 3) + 1) * bh + ((int)((9 - i) / 3) + 2) * bdy;
                        d[i].SetBounds(x, y, bw, bh);
                    }
                    else
                    {
                        d[i].SetBounds(bdx, 4 * bh + 5 * bdy, 2 * bw + bdx, bh);
                    }
                }
                else
                {
                    d[i].Name = "ButtonComma";
                    d[i].Text = ",";
                    d[i].SetBounds(2 * bw + 3 * bdx, 4 * bh + 5 * bdy, bw, bh);

                }

                d[i].Click += new EventHandler(ButtonN_Click);

                Controls.Add(d[i]);


            }

            for (int i = 0; i <= 3; i++)
            {
                op[i] = new Button();

                if (i == 0)
                {
                    op[i].Name = "ButtonPlus";
                    op[i].Text = "+";
                }
                if (i == 1)
                {
                    op[i].Name = "ButtonMinus";
                    op[i].Text = "-";
                }
                if (i == 2)
                {
                    op[i].Name = "ButtonResult";
                    op[i].Text = "=";
                }
                if (i == 3)
                {
                    op[i].Name = "ButtonClear";
                    op[i].Text = "C";
                }
                op[i].SetBounds(3 * bw + 4 * bdx, (i + 1) * bh + (i + 2) * bdy, bw, bh);

                op[i].Click += new EventHandler(ButtonOp_Click);

                Controls.Add(op[i]);
            }

            fd = true;
            co = "ButtonResult";
        }

        private void ButtonN_Click(object sender, EventArgs e)
        {
            Button btn_c = (Button)sender;

            if (btn_c.Name != "ButtonComma")
            {
                if (btn_c.Name != "Button0")
                {
                    if (fd)
                    {
                        label1.Text = btn_c.Text;
                        fd = false;
                    }
                    else
                    {
                        label1.Text += btn_c.Text;
                    }
                }
                else
                {
                    if (fd)
                        label1.Text = btn_c.Text;
                    if (label1.Text != "0")
                        label1.Text += btn_c.Text;
                }
            }
            else
            {
                if (fd)
                {
                    label1.Text = "0";
                    fd = false;
                }
                else
                {
                    if (label1.Text.IndexOf(",") == -1)
                        label1.Text += btn_c.Text;
                }
            }

        }


        private void ButtonOp_Click(object sender, EventArgs e)
        {
            Button btn_c = (Button) sender;

            double ind_n;

            if (btn_c.Name != "ButtonClear")
            {
                ind_n = Convert.ToDouble(label1.Text);

                if (fd == false)
                {
                    if (co.Equals("ButtonPlus")) ac += ind_n;
                    if (co.Equals("ButtonMinus")) ac -= ind_n;
                    if (co.Equals("ButtonResult")) ac = ind_n;
                }
                if (btn_c.Name == "ButtonPlus")
                    co = "ButtonPlus";
                if (btn_c.Name == "ButtonMinus")
                    co = "ButtonMinus";
                if (btn_c.Name == "ButtonResult")
                    co = "ButtonResult";

                label1.Text = ac.ToString();
            }
            else
            {
                ac = 0;
                label1.Text = "0";
                co = "ButtonResult";
            }
            fd = true;
        }

    }
}
