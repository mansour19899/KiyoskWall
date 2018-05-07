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
    public partial class DailyReserve : Form
    {
        System.Resources.ResourceManager rm = new ResourceManager(typeof(Resource1));
        private Person p1;
        private string dtnow;
        private KiyoskWall.PoonehEntities db;
        private List<PerMeal> AllMeals;
        List<PictureBox> p;
        List<Label> lables;

        public DailyReserve(Person per)
        {
            InitializeComponent();
            p1 = per;

            if (p1.WorkSheet_Id_FK == null)
                p1.WorkSheet_Id_FK = 22;

            //this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            panel1.Visible = false;

        }



        private void DailyReserve_Load(object sender, EventArgs e)
        {
            db = new PoonehEntities();
            dtnow = DateTime.Now.ToPersianDateString();

            ListDate ty = new ListDate(p1);

            AllMeals = ty.GetPerMeal(25);


            SetPicturelabel();
            LoadDate();

            panel1.Visible = true;
        }

        public void SetPicturelabel()
        {
            p = new List<PictureBox>();
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

        


        }

        public void LoadDate()
        {
            int i = 0;
           
            foreach (var item in AllMeals)
            {

                p.ElementAt(i).Image = SetDate(item.Date,item.Day, item.Meal);

                i = i + 1;
            }

        }

        public Bitmap SetDate(string date,string day, int meal)
        {
            Bitmap bmp;
            Brush br;
            bmp = (Bitmap)rm.GetObject("ButtonBG");
            br = Brushes.Black;
            if (meal == 1)
            {
                bmp = (Bitmap)rm.GetObject("ButtonBG");
                br = Brushes.Black;
            }
            else if (meal == 2)
            {
                bmp = (Bitmap)rm.GetObject("ButtonBGd");
                br = Brushes.White;
            }
            else if (meal == 4)
            {
                bmp = (Bitmap)rm.GetObject("ButtonSahar");
                br = Brushes.Black;
            }
            else if (meal == 5)
            {
                bmp = (Bitmap)rm.GetObject("ButtonEftar");
                br = Brushes.Black;
            }
            else
            {
                bmp = (Bitmap)rm.GetObject("ButtonBG");
                br = Brushes.Black;
            }


            RectangleF rectf = new RectangleF(30, 10, 190, 150);


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(day + "\n" + date, new Font("B Mitra", 30), br, rectf, stringFormat);
            g.Flush();

            return bmp;
        }

        public string GiveMeShiftName()
        {
            Shift x;
            x = (Shift)p1.WorkSheet_Id_FK.Value;
            if (x == Shift.Rozkar)
                return "روزکار ";
            else if (x == Shift.A8)
                return "A  شیفت ";
            else if (x == Shift.B8)
                return "B  شیفت ";
            else if (x == Shift.C8)
                return " C  شیفت ";
            else if (x == Shift.D8)
                return "D  شیفت ";
            else if (x == Shift.A12)
                return "A(12)  شیفت ";
            else if (x == Shift.B12)
                return "B(12)  شیفت ";
            else if (x == Shift.C12)
                return "C(12)  شیفت ";
            else
                return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            ReservePerMeal frm = new ReservePerMeal(AllMeals, 0);
            frm.ShowDialog();
        }
    }
}
