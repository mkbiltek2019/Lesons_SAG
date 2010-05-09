using System;
using System.Windows.Forms;

namespace lesson_12_winform
{
    public partial class MainForm : Form
    {
        private bool showState = true;
        private JokesReader jReader = new JokesReader();
        private JokeActivator jActivator = new JokeActivator();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                showState = true;
            }else
            {
                showState = false;
            }
        }

        private void ShowHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showState)
            {
                Show();
                WindowState = FormWindowState.Normal;
                showState = false;
            }
            else
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                showState = true;
            }

            FunnyJouksLabel.Text = "Смешные : " + jActivator.numberOfCoolJokes;
            NotFunnyJoaksLabel.Text = "Отстой :" + jActivator.numberOfUglyJokes;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.InitialDirectory = @".";
                openDialog.Filter = @"xml file |*.xml| All files |*.*";
                openDialog.FilterIndex = -1;
                openDialog.RestoreDirectory = true;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    FileNameTextBox.Text = openDialog.FileName.ToString();
                    jReader.LoadJokesFromFile(openDialog.FileName);
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMessageBoxWithJokeAndCalculateStatistic();
        }

        private void ShowJokeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMessageBoxWithJokeAndCalculateStatistic();
        }

        private void ShowMessageBoxWithJokeAndCalculateStatistic()
        {
            if (jReader.JokeList.Count > 0)
            {
                titleContent joke = jActivator.GetSingleJoke(jReader.JokeList);
                string content = string.Format("{0}", joke.content);
                string title = string.Format("{0}", joke.title);

                DialogResult result = MessageBox.Show(content, title,
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    jActivator.numberOfCoolJokes++;
                }
                else
                {
                    jActivator.numberOfUglyJokes++;
                }
            }

        }

    }

}
