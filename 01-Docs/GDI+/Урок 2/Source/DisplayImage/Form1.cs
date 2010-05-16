using System.Drawing;
using System.Windows.Forms;

namespace DisplayImage
{
    public partial class Form1 : Form
    {
        private Image picture;
        private Point[] pictureBounds;

        public Form1()
        {
            InitializeComponent();

            // Загрузка изображения
            picture = Image.FromFile(@"Images\metrobits.jpg");

            // Параллелограмм в котором будет выведено изображение
            pictureBounds = new Point[3];
            pictureBounds[0] = new Point(0, 0);
            pictureBounds[1] = new Point(picture.Width, 0);
            pictureBounds[2] = new Point(picture.Width/3, picture.Height);

            // Отображение полос прокрутки формы, если изображение не вмещается
            this.AutoScrollMinSize = new Size(4*picture.Width/3, picture.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.ScaleTransform(1.0f, 1.0f);
            graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            graphics.DrawImage(picture, pictureBounds);
        }
    }
}
