using System;
using System.Drawing;
using System.Windows.Forms;

namespace example_2
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap = new Bitmap(800, 800);

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события прорисовки формы
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            CreateArchimedeanSpiral();
            DrawBitmapOnCenter();
        }

        // Обработчик события изменения размеров формы
        private void Form1_Resize(object sender, EventArgs e)
        {
            DrawBitmapOnCenter();
        }

        // Метод создающий объект Bitmap и рисующий спираль Архимеда
        private void CreateArchimedeanSpiral()
        {
            bitmap = new Bitmap(800, 800);
            double ro, phi;

            for (phi = 0; phi <= 80; phi += 0.001)
            {
                ro = 2 * phi;
                DrawPixelOnBitmap(ro, phi);
            }
        }

        // Метод выводящий обьект Bitmap на форму
        private void DrawBitmapOnCenter()
        {
            // Получаем Graphics формы
            Graphics graphics = this.CreateGraphics();

            // Вычисляем координаты так, чтобы рисунок оказался посреди формы
            int x = (this.ClientSize.Width - bitmap.Size.Width) / 2;
            int y = (this.ClientSize.Height - bitmap.Size.Height) / 2;

            // Очищаем Graphics формы заливая его белым цветом
            graphics.Clear(Color.White);

            // Размещаем на форме рисунок 
            graphics.DrawImage(bitmap, x, y, bitmap.Size.Width, bitmap.Size.Height);
        }

        // Метод вычисляющий параметры точки и рисующий ее на Bitmap
        private void DrawPixelOnBitmap(double ro, double phi)
        {
            // Задание цвета точки
            int red = (int)(255 - Math.Abs(3 * ro - 225));
            int green = (int)(255 - ro);
            int blue = (int)Math.Abs(3 * ro - 225);

            red = (red > 255 || red < 0) ? 255 : red;
            green = (green > 255 || green < 0) ? 255 : green;
            blue = (blue > 255 || blue < 0) ? 255 : blue;

            // Вычисление координат середины рисунка
            double bitmapCenterX = bitmap.Size.Width / 2;
            double bitmapCenterY = bitmap.Size.Height / 2;

            double x, y;

            // Преобразование из полярных координат в декартовы
            x = ro * Math.Cos(phi) + bitmapCenterX;
            y = ro * Math.Sin(phi) + bitmapCenterY;

            if (x < 1 || x > bitmap.Size.Width - 1 || y < 1 || y > bitmap.Size.Height - 1) return;

            if (cbxSmoothing.Checked)
            {
                int xh, yh, xl, yl;

                // Координаты огибающей снизу
                xl = (int)Math.Round((ro - 0.5) * Math.Cos(phi) + bitmapCenterX);
                yl = (int)Math.Round((ro - 0.5) * Math.Sin(phi) + bitmapCenterY);

                // Координаты огибающей сверху
                xh = (int)Math.Round((ro + 0.5) * Math.Cos(phi) + bitmapCenterX);
                yh = (int)Math.Round((ro + 0.5) * Math.Sin(phi) + bitmapCenterY);

                // Вычисление расстояния отклонения координат пикселя от идеальных
                double dl = Math.Abs(xl - x) + Math.Abs(yl - y);
                double dh = Math.Abs(xh - x) + Math.Abs(yh - y);

                // Расчет корректирующего сглаживание параметров прозрачности 
                double al = 255 * Math.Exp(-dl * dl);
                double ah = 255 * Math.Exp(-dh * dh);

                // Рисование пикселей
                bitmap.SetPixel(xl, yl, Color.FromArgb((int)(al), red, green, blue));
                bitmap.SetPixel(xh, yh, Color.FromArgb((int)(ah), red, green, blue));
            }
            else bitmap.SetPixel((int)x, (int)y, Color.FromArgb(red, green, blue));
        }

        // Обработчик события применения сглаживания
        private void cbxSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            CreateArchimedeanSpiral();
            DrawBitmapOnCenter();
        }
    }
}
