using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Joke
{
    public partial class Form3 : Form
    {
        JokeText jokeText = new JokeText();
        JokesList jlist = new JokesList();
        Counter counter = new Counter();
        Random random = new Random();
        ArrayList arrayList = new ArrayList();

        public Form3()
        {
            InitializeComponent();
            //counter =  counter.ReadFromFile();
            //string str ;
            //str = counter.ReadTextFile();
            //counter = counter.ConvertToCounter(str);
            buttonClose.Enabled = false;
            jlist.LoadXmlFile("Joke.xml");
            arrayList = jlist.JokeList();
            jokeText = ReturnJooke(arrayList);
            Text = "Показ шутки " + jokeText.Name;
            richTextBox1.Text = jokeText.Text;

            //foreach (JokeText jt in jokeText.JokeTextArL)
            //{
            //    richTextBox1.Text = jt.Text;
            //    Thread.Sleep(5000);
            //}   
            //for (int i = 0; i < jokeText.JokeTextArL.Count; i++)
            //{
            //    int k = random.Next(jokeText.JokeTextArL.Count);
            //    JokeText jokeText in jokeText.JokeTextArL[k];
              
            //    jokeText.JokeTextArL.RemoveAt(k);
            //}
        }
       
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            counter.Yes++;
            counter.WriteToFile(counter);
          
            buttonYes.Enabled = false;
            buttonNo.Enabled = false;
            buttonProceed.Enabled = true;
            //Thread.Sleep(5000);
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter.No++;
            counter.WriteToFile(counter);
            buttonYes.Enabled = false;
            buttonNo.Enabled = false;
            buttonProceed.Enabled = true;
            //Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            counter.WriteToFile(counter);
            //counter.WriteToTextFile(counter.CounterToString());
            Close();
        }
        private JokeText ReturnJooke(ArrayList arrayList)
        {
            JokeText jok = new JokeText();
            //for (int i = 0; i < arrayList.Count; i++)
            //{
                int k = random.Next(arrayList.Count);
                jok = (JokeText) arrayList[k];
                arrayList.RemoveAt(k);
            //    break;
            //}
            return jok;
        }

        private void buttonProceed_Click(object sender, EventArgs e)
        {
            buttonYes.Enabled = true;
            buttonNo.Enabled = true;
           if(arrayList.Count != 0)
           {
               jokeText = ReturnJooke(arrayList);
               Text = "Показ шутки " + jokeText.Name;
               richTextBox1.Text = jokeText.Text;
           }
           else
           {
               Text = "Показ шутки " + "Шутки закончились";
               richTextBox1.Text = "Вы все просмотрели";
               buttonClose.Enabled = true;
               buttonYes.Enabled = false;
               buttonNo.Enabled = false;
           }
           buttonProceed.Enabled = false;
        }
    }
}
