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
        private int restaurant_id;
        private Person p1;
        private KiyoskWall.PoonehEntities db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
           
            db =new  PoonehEntities();
            dtnow = "1396/11/19";
            restaurant_id = 26;
            //p1 = db.People.Where(p => p.NationalCode == "0440005191").FirstOrDefault(); //rozkar
            p1 = db.People.Where(p => p.PersonelNo == "545642").FirstOrDefault();//c
            //p1 = db.People.Where(p => p.NationalCode == "1828039179").FirstOrDefault();  //b
            //p1 = db.People.Where(p => p.PersonelNo == "565807").FirstOrDefault();   //d
            //p1 = db.People.Where(p => p.PersonelNo == "568161").FirstOrDefault();   //a

            lbName.Text = p1.Name + " " + p1.LastName;
            ListDate ty=new ListDate(p1.WorkSheet_Id_FK.Value);

            var uu = ty.GetList();
            

           SetPicturebox(uu);
      
           


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

            for (int i = 0; i < ll.Count; i++)
            {
                p.ElementAt(i).Image = SetDate(ll.ElementAt(i), ll.ElementAt(i).meal);
                p.ElementAt(i).Name = ll.ElementAt(i).date;
                p.ElementAt(i).Text = ll.ElementAt(i).meal.ToString();
                p.ElementAt(i).Visible = true;

            }
           
        }
        public Bitmap SetDate(Date date, int meal)
        {
            Bitmap bmp;
            Brush br;
            bmp = (Bitmap)rm.GetObject("ButtonBG");
            br = Brushes.Black;
            if (meal != 1)
            {
                bmp = (Bitmap)rm.GetObject("ButtonBGd");
                br = Brushes.White;
            }

            RectangleF rectf = new RectangleF(100, 40, 90, 50);
            RectangleF rectf1 = new RectangleF(90, 90, 120, 50);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(date.day, new Font("B Nazanin", 26), br, rectf);
            g.DrawString(date.date, new Font("B Nazanin", 26), br, rectf1);
            g.Flush();

            return bmp;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic1_Click_1(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic1.Name, restaurant_id, p1, pic1.Text);
            frm.Show();
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic2.Name, restaurant_id, p1, pic2.Text);
            frm.Show();
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic3.Name, restaurant_id, p1, pic3.Text);
            frm.Show();
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic4.Name, restaurant_id, p1, pic4.Text);
            frm.Show();
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic5.Name, restaurant_id, p1, pic5.Text);
            frm.Show();
        }

        private void pic6_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic6.Name, restaurant_id, p1, pic6.Text);
            frm.Show();
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic7.Name, restaurant_id, p1, pic7.Text);
            frm.Show();
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic8.Name, restaurant_id, p1, pic8.Text);
            frm.Show();
        }

        private void pic9_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic9.Name, restaurant_id, p1, pic9.Text);
            frm.Show();
        }

        private void pic10_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic10.Name, restaurant_id, p1, pic10.Text);
            frm.Show();
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic11.Name, restaurant_id, p1, pic11.Text);
            frm.Show();
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic12.Name, restaurant_id, p1, pic12.Text);
            frm.Show();
        }

        private void pic13_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic13.Name, restaurant_id, p1, pic13.Text);
            frm.Show();
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic14.Name, restaurant_id, p1, pic14.Text);
            frm.Show();
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic15.Name, restaurant_id, p1, pic15.Text);
            frm.Show();
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic16.Name, restaurant_id, p1, pic16.Text);
            frm.Show();
        }

        private void pic17_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic17.Name, restaurant_id, p1, pic17.Text);
            frm.Show();
        }

        private void pic18_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic18.Name, restaurant_id, p1, pic18.Text);
            frm.Show();
        }

        private void pic19_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic19.Name, restaurant_id, p1, pic19.Text);
            frm.Show();
        }

        private void pic20_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic20.Name, restaurant_id, p1, pic20.Text);
            frm.Show();
        }

        private void pic21_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic21.Name, restaurant_id, p1, pic21.Text);
            frm.Show();
        }

        private void pic22_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic22.Name, restaurant_id, p1, pic22.Text);
            frm.Show();
        }

        private void pic23_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic23.Name, restaurant_id, p1, pic23.Text);
            frm.Show();
        }

        private void pic24_Click(object sender, EventArgs e)
        {
            ReserveFood frm = new ReserveFood(pic24.Name, restaurant_id, p1, pic24.Text);
            frm.Show();
        }
    }
}
