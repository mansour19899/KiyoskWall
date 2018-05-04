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
        private NeedToReserve needs;
        private List<Schedule> tempSchedules;
        private List<Tray> TempTrays;
        public static List<PoonehReservation> Reserved;
        public Form1(Person per)
        {
            InitializeComponent();
            p1 = per;

            if (p1.WorkSheet_Id_FK == null)
                p1.WorkSheet_Id_FK = 22;

            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            tableLayoutPanel1.Visible = false;

            

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          
            db =new  PoonehEntities();
            dtnow = DateTime.Now.ToPersianDateString();


            //p1 = db.People.Where(p => p.NationalCode == "0440005191").FirstOrDefault(); //rozkar
            //p1 = db.People.Where(p => p.PersonelNo == "545642").FirstOrDefault();//c
            //p1 = db.People.Where(p => p.NationalCode == "1828039179").FirstOrDefault();  //b
            //p1 = db.People.Where(p => p.PersonelNo == "565807").FirstOrDefault();   //d
            //p1 = db.People.Where(p => p.PersonelNo == "568161").FirstOrDefault();   //a

            needs = new NeedToReserve(p1);
            
            
            restaurant_id = db.Person_Restaurant.FirstOrDefault(p => p.Person_Id_Fk == p1.Id).Restaurant_Id_Fk.Value;
            //restaurant_id = 26;
            lbName.Text = p1.Name + " " + p1.LastName;

            var y = Login.tempSchedules.Min(pp => pp.Id);
;



            SetPicturebox(needs.AllDays);
            tableLayoutPanel1.Visible = true;
      
            int x = 0;

            needs.restaurent = restaurant_id;
            var dbb = db.Restaurants;
            lbRestuarent.Text = "رستوران مجاز:  "+ dbb.FirstOrDefault(p => p.Id == restaurant_id).Name;
            lbShift.Text = GiveMeShiftName();

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
            if (meal== 1)
            {
                bmp = (Bitmap)rm.GetObject("ButtonBG");
                br = Brushes.Black;
            }
            else if(meal == 2)
            {
                bmp = (Bitmap)rm.GetObject("ButtonBGd");
                br = Brushes.White;
            }
            else if (meal == 4)
            {
                bmp = (Bitmap)rm.GetObject("ButtonSahar");
                br = Brushes.Black;
            }
            else if (meal ==5)
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
            g.DrawString(date.day+"\n"+date.date, new Font("B Mitra",30), br, rectf,stringFormat);
            g.Flush();

            return bmp;
        }

   

        public void RunReserve(PictureBox pic)
        {
            needs.date = pic.Name;
            needs.meal = int.Parse(pic.Text);
            needs.GiveAllTraysSchedle();
          
                ReserveFood frm = new ReserveFood(needs);
            frm.ShowDialog();
      
        }

        public string GiveMeShiftName()
        {
            Shift x;
            x =(Shift) p1.WorkSheet_Id_FK.Value;
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic1_Click_1(object sender, EventArgs e)
        {
         RunReserve(pic1);
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            RunReserve(pic2);
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            RunReserve(pic3);
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            RunReserve(pic4);
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            RunReserve(pic5);
        }

        private void pic6_Click(object sender, EventArgs e)
        {
            RunReserve(pic6);
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            RunReserve(pic7);
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            RunReserve(pic8);
        }

        private void pic9_Click(object sender, EventArgs e)
        {
            RunReserve(pic9);
        }

        private void pic10_Click(object sender, EventArgs e)
        {
            RunReserve(pic10);
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            RunReserve(pic11);
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            RunReserve(pic12);
        }

        private void pic13_Click(object sender, EventArgs e)
        {
            RunReserve(pic13);
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            RunReserve(pic14);
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            RunReserve(pic15);
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            RunReserve(pic16);
        }

        private void pic17_Click(object sender, EventArgs e)
        {
            RunReserve(pic17);
        }

        private void pic18_Click(object sender, EventArgs e)
        {
            RunReserve(pic18);
        }

        private void pic19_Click(object sender, EventArgs e)
        {
            RunReserve(pic19);
        }

        private void pic20_Click(object sender, EventArgs e)
        {
            RunReserve(pic20);
        }

        private void pic21_Click(object sender, EventArgs e)
        {
            RunReserve(pic21);
        }

        private void pic22_Click(object sender, EventArgs e)
        {
            RunReserve(pic22);
        }

        private void pic23_Click(object sender, EventArgs e)
        {
            RunReserve(pic23);
        }

        private void pic24_Click(object sender, EventArgs e)
        {
            RunReserve(pic24);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needs.date ="";
            needs.GiveAllTraysSchedle();
            ReserveFood frm = new ReserveFood(needs);
            frm.Show();

        }
    }
}
