using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class Form1 : Form
    {
        System.Resources.ResourceManager rm = new ResourceManager(typeof(Resource1));
        private string dtnow;
        private string person_id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db =new  PoonehEntities();
            dtnow = "1396/11/19";
            Person p1=new Person(){NationalCode = "0440005191",WorkSheet_Id_FK = 22,LastName = "محمدی",Name = "سیدمنصور"};
            Person p2 = new Person() { NationalCode = "0440005191", WorkSheet_Id_FK = 21, LastName = "مقدم", Name = "عباس" };

            ListDate ty=new ListDate(22);
            var uu = ty.GetList();
            

           SetPicturebox(uu);
        }
        public void SetPicturebox(List<Date> ll)
        {
            List<PictureBox> p=new List<PictureBox>();
            p.Add(pictureBox1);
            p.Add(pictureBox2);
            p.Add(pictureBox3);
            p.Add(pictureBox4);

            for (int i = 0; i < p.Count; i++)
            {
                p.ElementAt(i).Image = SetDate(ll.ElementAt(i), 1);
            }
        }
        public Bitmap SetDate(Date date, int meal)
        {
            Bitmap bmp;
            Brush br;
            bmp = (Bitmap)rm.GetObject("lunch");
            br = Brushes.Black;
            if (meal != 1)
            {
                bmp = (Bitmap)rm.GetObject("dinner");
                br = Brushes.White;
            }

            RectangleF rectf = new RectangleF(70, 10, 90, 50);
            RectangleF rectf1 = new RectangleF(10, 40, 120, 50);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(date.day, new Font("Tahoma", 14), br, rectf);
            g.DrawString(date.date, new Font("Tahoma", 14), br, rectf1);
            g.Flush();

            return bmp;
        }
    }
}
