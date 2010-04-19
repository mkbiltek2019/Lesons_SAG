using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace KenoCS
{
    class Keno
    {
        private int num;
        private string date;
        private string numberloto;
        private int numbersballs;
        private const int size = 20;
        private int[] number = new int[size];

        public int Num
        {
            get
            {
                return num;
            }
            set
            { num = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Numberloto
        {
            get { return numberloto; }
            set { numberloto = value; }
        }
        public int Numberballs
        {
            get { return numbersballs; }
            set { numbersballs = value; }
        }
        public int[] Number
        {
            get
            {
                return number;
            }
            set
            {
                //for (int i = 0; i < size; i++)
                //{
                //    number[i] = value[i];   
                //}
                number = value;
            }
           
        }

        public Keno()
        {
            num = 0;
            date = "00.00.0000";
            numberloto = "A";
            numbersballs = 0;
            
        }
        public Keno(int num, string date, string nl, int nb, int[] number)
        {
            Num = num;
            Date = date;
            Numberloto = nl;
            Numberballs = nb;
            Number = number;
        }
        public ArrayList ArrayListKeno = new ArrayList();
        public void ArrayLiistKenoPrint(ArrayList keno)
        {
            foreach (Keno k in keno)
            {
                k.Print();
                Console.WriteLine();
            } 
        }
        public void ReadFile()
        {
            string[] lines =
                System.IO.File.ReadAllLines("keno.txt");
            
           
            int r = 0;
            foreach (string line in lines)
            {
                Keno k = new Keno();
                string temp = null;
                for (int i = 0; i < line.Length; i++)
                {
                    
                    if (i < 7 && line[i].ToString().ToLower() != " ")
                        temp += line[i];

                    if (i < 7 && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    k.Num = Convert.ToInt32(temp.ToString());
                }
               
                temp = null;
                for (int i = r + 2; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    k.Date = temp;
                }
                temp = null;
                for (int i = r + 2; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    k.Numberloto = temp.ToString();
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    k.Numberballs = Convert.ToInt32(temp.ToString());
                }
                int[] tmpnumber = new int[20];
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[0] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[1] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[2] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[3] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[4] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[5] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[6] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[7] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[8] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[9] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[10] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[11] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[12] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[13] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[14] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[15] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[16] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[17] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i > r && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    tmpnumber[18] = Convert.ToInt32(temp.ToString());
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    if (i > r && line[i].ToString().ToLower() != " ")
                        temp += line[i];
                    if (i == line.Count())
                    {
                        break;
                    }
                    
                    tmpnumber[19] = Convert.ToInt32(temp.ToString());
                }
                k.Number = tmpnumber;
                ArrayListKeno.Add(k);
            }
        }
        public void Print()
        {
            Console.Write("{0} ", num);
            Console.Write(date);
            Console.Write(" ");
            Console.Write(numberloto);
            Console.Write(" {0} ",numbersballs);
            for (int i = 0; i < size; i++)
            {
                Console.Write(" {0}", number[i]);
            }
         }
    }
}
