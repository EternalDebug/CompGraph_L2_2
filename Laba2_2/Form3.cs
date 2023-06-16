using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form3 : Form
    {
        private Graphics g;

        double sootnX = 0;

        public Form3()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Pen pen = new Pen(Color.FromArgb(100, 0, 255, 0));
            sootnX = this.ClientSize.Width / 255;
            Image newImage = Image.FromFile("res1.jpg");
            Bitmap Source = new Bitmap(newImage);
            var Ypoints = new int[256];

            //Подсчёты интенсивности красных пикселей
            for (int i = 0; i < Source.Width; i++)
            {
                for (int j = 0; j < Source.Height; j++)
                {
                    Color clr = Source.GetPixel(i, j);
                    Ypoints[clr.G]++;
                }
            }

            var yMin = Ypoints.Min();
            var yMax = Ypoints.Max();
            double sootnY = ((double)this.ClientSize.Height / (yMax - yMin));

            for (int i = 0; i < 255; i++)
            {
                g.DrawLine(pen, (int)(i * sootnX), (int)(this.ClientSize.Height - Ypoints[i] * sootnY), (int)((i + 1) * sootnX), (int)(this.ClientSize.Height - Ypoints[i + 1] * sootnY));
            }
        }
    }
}
