using System;
using System.Text; //StringBuilder
using System.Drawing; //Graphics, Rectangle, Bitmap, Font, Color, Size
using System.Drawing.Drawing2D; //LinearGradientBrush
using System.Drawing.Imaging; //ImageFormat
using System.IO; //MemoryStream

namespace CrearCaptcha
{
    public class Captcha
    {
        private static char generarCaracterAzar()
        {
            Random oAzar = new Random();
            int n = oAzar.Next(26) + 65;
            System.Threading.Thread.Sleep(15);
            return ((char)n);
        }

        public static beCaptcha crear()
        {
            beCaptcha obeCaptcha = new beCaptcha();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(generarCaracterAzar());
            }
            Bitmap bmp = new Bitmap(200, 80);
            Graphics grafico = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(0, 0, 200, 80);
            LinearGradientBrush deg = new LinearGradientBrush
                (rect, Color.Aqua, Color.Blue, LinearGradientMode.BackwardDiagonal);
            grafico.FillRectangle(deg, rect);
            grafico.DrawString(sb.ToString(), new Font("Arial", 35), Brushes.White, 0, 10);
            Point punto1;
            Point punto2;
            Random oAzar = new Random();
            for (int i = 0; i < 5; i++)
            {
                punto1 = new Point(oAzar.Next(200), oAzar.Next(80));
                punto2 = new Point(oAzar.Next(200), oAzar.Next(80));
                grafico.DrawLine(new Pen(Brushes.Yellow, 2), punto1, punto2);
            }
            obeCaptcha.Codigo = sb.ToString();
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Jpeg);
                obeCaptcha.Imagen = ms.ToArray();
            }
            return (obeCaptcha);
        }
    }
}