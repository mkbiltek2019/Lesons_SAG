using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
/*
 1. Реалізувати "дизайнер форм"
2. В дизайнері форм надати користувачу можливість вибрати 
 * елемент управління та помістити його на робочу область програми
3. Надати користувачу можливість змінювати параметри 
 * елементів управління за допомогою елемента управління PropertyGrid
 * 
4. До дизайнера форм додати можливість збереження 
 * та відновлення розташування доданих елементів управління.
 * Використати серіалізацію в файл та MainMenuStrip

5. При натисканні на доданий лелемент управління додати його імя 
 * в комбобокс
6. Поп-ап меню на кожному доданому елементі управління з
 * двох пунктів:
 * 1.видалити елемент 
 * 2. властивості.

 */
namespace SimpleFormDesigner
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateLabeltoolStripButton_Click(object sender, EventArgs e)
        {
            SetControlParamsAndBindToPanelByControlClassName(ListOfControls.Label);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void CreateButtonToolStripButton_Click(object sender, EventArgs e)
        {
            SetControlParamsAndBindToPanelByControlClassName(ListOfControls.Button);
        }

        private void CreateGroupBoxToolStripButton_Click(object sender, EventArgs e)
        {
            SetControlParamsAndBindToPanelByControlClassName(ListOfControls.GroupBox);
        }

        private void CreateCheckBoxToolStripButton_Click(object sender, EventArgs e)
        {
            SetControlParamsAndBindToPanelByControlClassName(ListOfControls.CheckBox);
        }

        private void CreateRadioBoxToolStripButton_Click(object sender, EventArgs e)
        {
            SetControlParamsAndBindToPanelByControlClassName(ListOfControls.RadioButton);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.InitialDirectory = @".";
            saveDialog.Filter = @"data file |*.dat| All files |*.*";
            saveDialog.FilterIndex = -1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            //FileStream fs = new FileStream("FormDesigner.dat", FileMode.Create);

            //// Construct a BinaryFormatter and use it to serialize the data to the stream.
            //BinaryFormatter formatter = new BinaryFormatter();
            //try
            //{
            //    formatter.Serialize(fs, (object)SplitContainer.Panel1.Controls[0]);
            //}
            //catch (SerializationException ee)
            //{
            //    Console.WriteLine("Failed to serialize. Reason: " + ee.Message);
            //    throw;
            //}
            //finally
            //{
            //    fs.Close();
            //}
         
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = @".";
            openDialog.Filter = @"data file |*.dat| All files |*.*";
            openDialog.FilterIndex = -1;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.InitialDirectory = @".";
            saveDialog.Filter = @"data file |*.dat| All files |*.*";
            saveDialog.FilterIndex = -1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

    }

}
