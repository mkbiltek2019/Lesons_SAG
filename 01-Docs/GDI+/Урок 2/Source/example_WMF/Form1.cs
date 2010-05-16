using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace example_WMF
{
    public partial class Form1 : Form
    {
        private Metafile wmfImage;

        public Form1()
        {
            InitializeComponent();
            LoadWMFFile(@"Images\Graphic.wmf");
        }

        // Открытие файла
        private void tsmiOpenFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                ValidateNames = true,
                Title = "Open WMF File",
                Filter = "WMF files (*.wmf)|*.wmf"
            };

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                LoadWMFFile(ofg.FileName);
            }
        }

        // Перегрузка перерисовки формы
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Определение минимальной составляющей размера формы
            double minFormBound = Math.Min(this.ClientSize.Width, this.ClientSize.Height);

            // Определение максимальной составляющей размера рисунка
            double maxPictureDimension = Math.Max(wmfImage.Width, wmfImage.Height);

            // Определение коефициента изменения размеров рисунка
            double k = maxPictureDimension / minFormBound;

            int w = (int)(wmfImage.Width / k);
            int h = (int)(wmfImage.Height / k);

            // Создание координат вывода рисунка
            Point[] imageBounds = new Point[3];
            imageBounds[0] = new Point(50, 50);
            imageBounds[1] = new Point(w, 50);
            imageBounds[2] = new Point(50, h);

            // Вывод рисунка на форму
            e.Graphics.DrawImage(wmfImage, imageBounds);
        }

        // Загрузка рисунка из файла
        private void LoadWMFFile(String name)
        {
            // Создание рисунка из файла
            this.wmfImage = new Metafile(name);

            // Вызов метода перерисовки формы
            this.Invalidate();
        }

        // Создание нового рисунка, смайла
        private void CreateWMFFile()
        {
            Graphics formGraphics = this.CreateGraphics();
            IntPtr ipHdc = formGraphics.GetHdc();

            wmfImage.Dispose();
            wmfImage = new Metafile(@"Images\New.wmf", ipHdc);

            formGraphics.ReleaseHdc(ipHdc);
            formGraphics.Dispose();

            Graphics graphics = Graphics.FromImage(wmfImage);

            graphics.FillEllipse(Brushes.Yellow, 100, 100, 200, 200);
            graphics.FillEllipse(Brushes.Black, 150, 150, 25, 25);
            graphics.FillEllipse(Brushes.Black, 225, 150, 25, 25);
            graphics.DrawArc(new Pen(Color.SlateGray, 10), 195, 180, 10, 100, -30, -120);
            graphics.DrawArc(new Pen(Color.Red, 10), 150, 170, 100, 100, 30, 120);
            graphics.Dispose();

            this.Invalidate();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            CreateWMFFile();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
