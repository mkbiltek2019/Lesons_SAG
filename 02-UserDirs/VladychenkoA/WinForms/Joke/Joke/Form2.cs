using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace Joke
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        JokeText jokeText = new JokeText();
        public ArrayList ArrayList = new ArrayList();
        JokeList myList = new JokeList();


        private void button1_Click(object sender, EventArgs e)
        {

            jokeText.Name = textBox1.Text;
            jokeText.Text = richTextBox1.Text;
            //myList.AddItem(new Item(name, text));
            //jokeText.JokeTextArL.Add(jokeText);
            //ArrayList.Add(jokeText);
            if(textBox1.Text != null && richTextBox1.Text != null)
            Append(textBox1.Text, richTextBox1.Text);
            buttonAppend.Enabled = false;
        }



        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            //richTextBox1.Text = e.Data.GetData(DataFormats.StringFormat).ToString();

            int i;
            String s;
            
            // Определяем начальную позицию для текста
            i = richTextBox1.SelectionStart;
            s = richTextBox1.Text.Substring(i);
            richTextBox1.Text = richTextBox1.Text.Substring(0, i);

            // Перетаскиваем текст 
            richTextBox1.Text = richTextBox1.Text +
            e.Data.GetData(DataFormats.Text).ToString();
            richTextBox1.Text = richTextBox1.Text + s;
        }

        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            buttonAppend.Enabled = true;
        }

        private void Write()
        {
            //FileStream fileStream = new FileStream("Joke.xml",FileMode.Open,FileAccess.Write);

            //XmlSerializer serializer = new XmlSerializer(typeof(JokeList));
            //TextWriter textWriter = new StreamWriter("Joke.xml");
            //serializer.Serialize(textWriter, myList);
            //textWriter.Close();
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("joke.xml", System.Text.Encoding.Default);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Jokes");
                for (int i = 0; i < jokeText.JokeTextArL.Count; i++ )
                {
                    JokeText joke = new JokeText();
                    joke = (JokeText)jokeText.JokeTextArL[i];
                    writer.WriteStartElement("Joke");
                    writer.WriteElementString("Title", joke.Name);
                    writer.WriteElementString("Content", joke.Text);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Write();
            Close();
        }

        private void Append(string a, string b)
        {
            XmlDocument doc =new XmlDocument();
            doc.Load("Joke.xml");
            
            XmlNode root = doc.DocumentElement;
            //root.RemoveChild(root.LastChild);

            XmlNode joke = doc.CreateElement("Joke");
            XmlNode elem1 = doc.CreateElement("Title");
            XmlNode elem2 = doc.CreateElement("Content");

            XmlNode text1 = doc.CreateTextNode(a);
            XmlNode text2 = doc.CreateTextNode(b);

            elem1.AppendChild(text1);
            elem2.AppendChild(text2);

            joke.AppendChild(elem1);
            joke.AppendChild(elem2);

            root.AppendChild(joke);

            doc.Save("Joke.xml");
        }

        public class JokeList
        {
            private ArrayList listJokes;

            public JokeList()
            {
                listJokes = new ArrayList();
            }

            [XmlElement("joke")]
            public Item[] Items
            {
                get
                {
                    Item[] items = new Item[listJokes.Count];
                    listJokes.CopyTo(items);
                    return items;
                }
                set
                {
                    if (value == null) return;
                    Item[] items = (Item[])value;
                    listJokes.Clear();
                    foreach (Item item in items)
                        listJokes.Add(item);
                }
            }

            public int AddItem(Item item)
            {
                return listJokes.Add(item);
            }
        }

        // Items in the shopping list
        public class Item
        {
            [XmlAttribute("name")]
            public string name;
            [XmlAttribute("Text")]
            public string text;

            public Item()
            {
            }

            public Item(string Name, string Text1)
            {
                name = Name;
                text = Text1;
            }
        }


    }
}
