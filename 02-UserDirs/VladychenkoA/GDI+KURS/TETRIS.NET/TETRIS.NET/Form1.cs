using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using  TetrisLib;

namespace TETRIS.NET
{
  

    public enum GameSpeed
    {
      
        Быстрый = 200,
        Средний = 400,
        Легкий = 600
    }

    public partial class TetrisNETForm : Form
    {
        Block blk, next;
        int score;
        int time;
        
        public TetrisNETForm()
        {
            InitializeComponent();
        }

       

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void TetrisNETForm_Load(object sender, EventArgs e)
        {
            GameField.BackColor = Color.White;
            KeyDown+=new KeyEventHandler(BloxForm_KeyDown);
			Text = Application.ProductName + " Нажмите Ентер для старта";
        }

        private void BloxForm_KeyDown(object sender, KeyEventArgs e) {
            switch(e.KeyCode){
				case Keys.Left:
					if(timer.Enabled)
						blk.Left();	
					break;
				case Keys.Right:
					if(timer.Enabled)
						blk.Right();					
					break;
				case Keys.Down:
					if(timer.Enabled)
						blk.Down();
					break;
				case Keys.Up:
					if(timer.Enabled)
						blk.Rotate();
					break;
				case Keys.Enter:
					Start();
					break;
				case Keys.Escape:
					Pause();
					break;	
				default:
                    Microsoft.VisualBasic.Interaction.Beep();
                    break;
			}
		}

		private void Blk_squareStopped() {
			if(this.blk.Top <= 30){
				timer.Stop();
                timer1.Stop();
                //MessageBox.Show("Игра окончена.");
                Form2 form2 = new Form2();
                form2.Show();
                form2.Controls[2].Text = textScore.Text;
			    form2.Controls[0].Text = label5.Text;
                this.Text = Application.ProductName + "  Нажмите Ентер для старта";
				GameField.Reset();
				field.CreateGraphics().Clear(Color.White);
				nextBlock.CreateGraphics().Clear(Color.White);
			}else{
			    score += GameField.CheckLines()* (100 - (timer.Interval/10));
                this.textScore.Text = score.ToString() + " oчков";

              

				blk = new Block(new Point(90,GameField.FieldTopBound + (GameField.SquareSize * 5)),next.BlkType);
				blk.squareStopped +=new SquareStoppedEventHandler(Blk_squareStopped);
			    blk.Show(field.Handle);

				nextBlock.CreateGraphics().Clear(Color.White);
				this.next = new Block(new Point(35,35));			
				next.Show(nextBlock.Handle);
			}
			
		}

		private void timer_Tick(object sender, System.EventArgs e) {
			blk.Down();
          }

		public override void Refresh() {
			GameField.Redraw();			
		}

		protected override void OnGotFocus(EventArgs e) {
			Refresh();
			base.OnGotFocus (e);
		}

		
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Start();
        }

        private void Start()
        {
            if (timer.Enabled == false)
            {
                this.Text = Application.ProductName;
                this.textScore.Text = " 0 oчков";
                this.lblGameSpeed.Text = "";
                this.score = 0;

                GameField.Field = field.Handle;

                blk = new Block(new Point(90, GameField.FieldTopBound + (GameField.SquareSize * 5)));
                blk.squareStopped += new SquareStoppedEventHandler(Blk_squareStopped);
                blk.Show(field.Handle);

                this.next = new Block(new Point(45, 35));
                next.Show(nextBlock.Handle);

                this.lblGameSpeed.Text = ((GameSpeed)timer.Interval).ToString();
                timer.Enabled = true;
                timer1.Enabled = true;
            }
            else
            {
                timer.Enabled = true;
                timer1.Enabled = true;
            }
        }

        private void Pause()
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                this.Text = "Нажмите Еscape снова для продолжения";
            }
            else
            {
                timer.Enabled = true;
                this.Text = Application.ProductName;
            }
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 600;
            lblGameSpeed.Text = ((GameSpeed)timer.Interval).ToString();
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 400;
            lblGameSpeed.Text = ((GameSpeed)timer.Interval).ToString();
        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 200;
            lblGameSpeed.Text = ((GameSpeed)timer.Interval).ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
                time += 1;
                label5.Text = time.ToString();
            
        }

     }
      
}

