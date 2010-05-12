using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Joke
{
    [Serializable]
    class Counter
    {
        private int _yes;
        private int _no;


        public int Yes
        {
            set { _yes = value; }
            get{ return _yes; }
        }
        public int No
        {
            set { _no = value; }
            get { return _no; }
        }

        public void WriteToFile(Counter counter)
        {
            FileStream fileStream = new FileStream("counter.dat", FileMode.Open, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, counter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Відбулася помилка: " + ex.Message, "Помилка",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
            finally
            { fileStream.Close(); }
            
        }

        public Counter ReadFromFile()
        {
            Counter counter;
            FileStream fileStream = new FileStream("counter.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            counter = (Counter)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return counter;
        }

        public string CounterToString()
        {
            string text;
            text = _yes.ToString() + "  " + _no.ToString();
            return text;
        }

        public Counter ConvertToCounter(string line)
        {
            Counter counter = new Counter();
            string tmp = null;
            int k = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].ToString().ToLower() != " ")
                tmp += line[i];
                if (line[i].ToString().ToLower() == " ")
                {
                    k = i;
                    break;
                }
             }
            counter.Yes = Convert.ToInt32(tmp);
            tmp = null;
            for (int i = k + 1; i < line.Length; i++)
            {
                if (line[i].ToString().ToLower() != " ")
                tmp += line[i];
            }
            counter.No = Convert.ToInt32(tmp);
            return counter;
        }
        public void WriteToTextFile(string text)
        {
            File.WriteAllText("counter.txt", text);
        }

        public string ReadTextFile()
        {
            string text = File.ReadAllText("counter.txt");
            return text;
        }
    }
}
