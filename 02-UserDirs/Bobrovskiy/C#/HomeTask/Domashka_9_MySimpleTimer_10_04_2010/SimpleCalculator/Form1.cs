using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator()
                                        {
                                            First = FirstNumber.Text,
                                            Second = SecondNumber.Text
                                        };
            ResultOfOperation.Text = calculator.Action(Operation.Plus);

            FirstNumber.Focus();
        }

        private void FirstNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Return)
            {
                SecondNumber.Focus();
            }
        }

        private void SecondNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                Calculate.Focus();
            }
        }
        
    }

    public class ConvertException : Exception
    {
        private string message = string.Empty;

        public ConvertException()
        {
            message = "You must input some integer or double value.";
        }

        public override string ToString()
        {
            return message;
        }

    }

    public enum Operation
    {
        Plus = 1,
        Minus = 2,
        Multiply = 3,
        Divide = 4
    }

    public class Calculator
    {
        public string First
        {
            set; 
            get;
        }

        public string Second
        {
            set;
            get;
        }

        private double TextParser(string text)
        {
            double number = 0;
            if (!double.TryParse(text, out number))
            {
                //throw new ConvertException();
                 MessageBox.Show("Bad number");
            }
            return number;
        }

        private double AddOperation()
        {
            return TextParser(First) + TextParser(Second);
        }

        public string Action(Operation operation)
        {
            switch(operation)
            {
                case Operation.Plus:
                    {
                       return  (AddOperation()).ToString();
                    }break;
                case Operation.Multiply:
                    {
                        return string.Empty;
                    } break;
                case Operation.Minus:
                    {
                        return string.Empty;
                    } break;
                case Operation.Divide:
                    {
                        return string.Empty;
                    } break;
            }
            return string.Empty;
        }
    }

}
