using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiyoskWall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(@"D:\kiyoskWall\kiyoskWall\kiyoskWall\1421489570Untitled-8.jpg");

            RectangleF rectf = new RectangleF(10, 10, 90, 50);
            RectangleF rectf1 = new RectangleF(10, 20, 90, 50);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("mansour", new Font("Tahoma", 8), Brushes.Black, rectf);
            g.DrawString("mansour", new Font("Tahoma", 8), Brushes.Black, rectf1);
            g.Flush();

            pictureBox1.Image = bmp;
        }
    }
}
