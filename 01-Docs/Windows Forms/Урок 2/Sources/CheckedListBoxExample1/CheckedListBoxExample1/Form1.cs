using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckedListBoxExample1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddToCheckBox_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox1.Text))
            {
                if (!this.checkedListBox1.Items.Contains(this.textBox1.Text))

                    this.checkedListBox1.Items.Add(this.textBox1.Text);
                else
                    MessageBox.Show("CheckedListBox already contains this item");
            }
            else
                MessageBox.Show("Empty string");
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            if (this.checkedListBox1.CheckedItems.Count != 0)
            {
                for(int i =0 ;i < this.checkedListBox1.CheckedItems.Count;i++)
                this.listBox1.Items.Add(this.checkedListBox1.CheckedItems[i]);
            }

            else
                MessageBox.Show("No items in CheckedListBox");

           
        }
    }
}
