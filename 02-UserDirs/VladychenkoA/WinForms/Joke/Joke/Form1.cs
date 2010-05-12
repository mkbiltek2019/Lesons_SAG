using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Joke
{
    public partial class Form1 : Form
    {
        Counter _counter = new Counter();
        JokeText _joke = new JokeText();
        JokesList _jl = new JokesList();
        Random _rand = new Random();
        private string _nameFile;
       

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "Шутка", "Свернуто в трей", ToolTipIcon.Info);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _counter.Yes = 0;
            _counter.No = 0;
            _counter.WriteToFile(_counter);
            Application.Exit();
        }

        private void показатьСпрятатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
         
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _counter.Yes = 0;
            _counter.No = 0;
            _counter.WriteToFile(_counter);
            Application.Exit();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form2 form2 = new Form2();
            form2.Show();
            //if()
            //form2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Equals("counter.dat", null))
                _counter = _counter.ReadFromFile();
            label1.Text = "Понравилось: " + _counter.Yes;
            label2.Text = "Не понравилось: " + _counter.No;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _counter.Yes = 0;
            _counter.No = 0;
            _counter.WriteToFile(_counter);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            openFileDialog.InitialDirectory = @".";
            openFileDialog.Filter = @"xml files | *.xml | All files | *.*";
            openFileDialog.FilterIndex = -1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               textBox1.Text = openFileDialog.FileName; 
            }
            _nameFile = openFileDialog.FileName;
            _jl.LoadXmlFile(_nameFile);
        }

        private void показатьШуткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            _joke.JokeTextArL = _jl.JokeList();
            ArrayList arrayList = new ArrayList();
            arrayList = _jl.JokeList();
            if (arrayList.Count != 0)
            {
                //for (int i = 0; i < arrayList.Count; i++)
                //{
                    int k = _rand.Next(arrayList.Count);
                    _joke = (JokeText) arrayList[k];
                    DialogResult dialogResult = MessageBox.Show(_joke.Text, _joke.Name,
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _counter.Yes++;
                        _counter.WriteToFile(_counter);
                    }
                    else
                    {
                        _counter.No++;
                        _counter.WriteToFile(_counter);
                    }
                    arrayList.RemoveAt(k);
                //}
            }
            else
            {
                MessageBox.Show("Вы все просмотрели", "Шутки закончились",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        
       
    }
}
