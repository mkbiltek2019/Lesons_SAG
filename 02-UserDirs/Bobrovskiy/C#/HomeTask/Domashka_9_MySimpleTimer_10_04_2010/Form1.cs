using System;
using System.Drawing;
using System.Windows.Forms;

namespace MySimpleTimer_10_04_2010
{
    public partial class MainForm : Form
    {
        private SimpleTimer extentedTimer = null;
        private const int timerPositionX = 74;
        private const int timerPositionY = 9;

        public MainForm()
        {
            InitializeComponent();

            extentedTimer = new SimpleTimer(this, new Point(timerPositionX, timerPositionY));
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            extentedTimer.Start();
        }

        private void GetTime_Click(object sender, EventArgs e)
        {
            TimerValueList.Items.Add("Result : " + extentedTimer.Text);
        }

        private void StopTimer_Click(object sender, EventArgs e)
        {
            extentedTimer.Stop();
        }

        private void ClearResults_Click(object sender, EventArgs e)
        {
            TimerValueList.Items.Clear();
        }
    }

    public class SimpleTimer : Timer
    {
        private TimeSpan mytime = new TimeSpan();
        private Label TimeContainer = null;
        private const int timerStepInMiliseconds = 16;
        private const string timerContainerDefaultValue = "0:0:0:0";
        private const int timerContainerWidth = 143;
        private const int timerContainerHeigth = 44;

        public string Text
        {
            get; 
            set;
        }

        public SimpleTimer(Form mainForm, Point TopLeftCoordinates)
        {
            CreateOutputControl(mainForm, TopLeftCoordinates.X, TopLeftCoordinates.Y);
            Interval = 1;
            Tick += new EventHandler(SimpleTimer_Tick);
        }

        private void SimpleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, timerStepInMiliseconds);
            mytime += ts;
          
            TimeContainer.Text = "" + mytime.Hours + ":" +
                mytime.Minutes + ":" +
                mytime.Seconds + ":" +
                mytime.Milliseconds;

            Text = TimeContainer.Text;
        }

        private void CreateOutputControl(Form mainForm, int Top, int Left)
        {
            TimeContainer = new Label();
           
            TimeContainer.AutoSize = true;
            TimeContainer.Font = new Font("Arial", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            TimeContainer.Location = new Point(Top, Left);
            TimeContainer.Name = "TimeContainer";
            TimeContainer.Size = new Size(timerContainerWidth, timerContainerHeigth);
            TimeContainer.TabIndex = 0;
            TimeContainer.Text = timerContainerDefaultValue;

            mainForm.Controls.Add(TimeContainer);
        }

        public new void Stop()
        {
            Enabled = false;
            mytime = new TimeSpan(0, 0, 0, 0, 0);
            Text = timerContainerDefaultValue;
            TimeContainer.Text = timerContainerDefaultValue;
        }

        public new void Start()
        {
            Enabled = true;
        }
    }
}
