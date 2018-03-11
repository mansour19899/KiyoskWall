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
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            


                        var db =new  PoonehEntities();
            dtnow = "1396/11/19";
            Person p1=new Person(){NationalCode = "0440005191",WorkSheet_Id_FK = 22,LastName = "محمدی",Name = "سیدمنصور"};
            Person p2 = new Person() { NationalCode = "0440005191", WorkSheet_Id_FK = 21, LastName = "مقدم", Name = "عباس" };

            ListDate ty=new ListDate(22);
            var uu = ty.GetList();
            

           SetPicturebox(uu);

            MessageBox.Show(pic5.Name);

        }
        public void SetPicturebox(List<Date> ll)
        {
            List<PictureBox> p=new List<PictureBox>();
            p.Add(pic1);
            p.Add(pic2);
            p.Add(pic3);
            p.Add(pic4);
            p.Add(pic5);
            p.Add(pic6);
            p.Add(pic7);
            p.Add(pic8);
            p.Add(pic9);
            p.Add(pic10);
            p.Add(pic11);
            p.Add(pic12);
            p.Add(pic13);
            p.Add(pic14);
            p.Add(pic15);
            p.Add(pic16);
            p.Add(pic17);
            p.Add(pic18);
            p.Add(pic19);
            p.Add(pic20);
            p.Add(pic21);
            p.Add(pic22);
            p.Add(pic23);
            p.Add(pic24);
            p.Add(pic25);

            for (int i = 0; i < p.Count; i++)
            {
                p.ElementAt(i).Image = SetDate(ll.ElementAt(i), 1);
                p.ElementAt(i).Name = ll.ElementAt(i).date;
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

            RectangleF rectf = new RectangleF(60, 10, 90, 50);
            RectangleF rectf1 = new RectangleF(40, 50, 120, 50);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(date.day, new Font("B Nazanin", 16), br, rectf);
            g.DrawString(date.date, new Font("B Nazanin", 14), br, rectf1);
            g.Flush();

            return bmp;
        }
    }
}
