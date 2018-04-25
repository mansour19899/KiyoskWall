using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class ReserveFoodQuickly : Form
    {
        private Person p1;
        private KiyoskWall.PoonehEntities1 db;
        private List<Schedule> PerSchedules;
        private List<Schedule> Schedules;
        private List<Tray> PerTrays;
        private List<Tray> Trays;
        private List<PictureBox> pic;
        private PoonehReservation t;
        private int restaurant_id;
        System.Resources.ResourceManager rm = new ResourceManager(typeof(Resource1));
        private List<Date> meals;
        public ReserveFoodQuickly(Person per)
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            p1 = per;
        }

   

        private void ReserveFoodQuickly_Load(object sender, EventArgs e)
        {
          

            db = new PoonehEntities1();

            //p1 = db.People.Where(pp => pp.NationalCode == "0440005191").FirstOrDefault(); //rozkar
         
           
            //p1 = db.People.Where(p => p.PersonelNo == "545642").FirstOrDefault();//c
            //p1 = db.People.Where(p => p.NationalCode == "1828039179").FirstOrDefault();  //b
            //p1 = db.People.Where(p => p.PersonelNo == "565807").FirstOrDefault();   //d
            //p1 = db.People.Where(p => p.PersonelNo == "568161").FirstOrDefault();   //a

            lbName.Text = "   نام و نام خانوادگی: " + p1.Name + "  " + p1.LastName;
             restaurant_id = db.Person_Restaurant.FirstOrDefault(p => p.Person_Id_Fk == p1.Id).Restaurant_Id_Fk.Value;
            Schedules =new List<Schedule>();
            Trays=new List<Tray>();
            ListDate ty = new ListDate(p1);
            List<Label> label =new List<Label>(){label1,label2,label3,label4,label5};

            meals = ty.GetList().OrderBy(p => p.date).Take(5).ToList();
            SetPicture();
            string y = meals.ElementAt(0).date.AddDaysToShamsiDate(-1);
           var tempSchedules = Login.tempSchedules;
           
           var TempTrays = Login.TempTrays;

            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                if(meals.ElementAt(i).meal==2)
                    label.ElementAt(i).Text = meals.ElementAt(i).date + "\n" + meals.ElementAt(i).day+"\n"+"((شام))";
                else
                {
                    label.ElementAt(i).Text = meals.ElementAt(i).date + "\n" + meals.ElementAt(i).day;
                }
              
                PerSchedules = (from p in tempSchedules
                    where p.SDate.Equals(meals.ElementAt(i).date) & p.Restaurant_Id_Fk == restaurant_id
                                                     & p.Meal_Id_Fk == meals.ElementAt(i).meal select p).ToList();

                Schedules.Add(PerSchedules.ElementAt(0));
                Schedules.Add(PerSchedules.ElementAt(1));
                Schedules.Add(PerSchedules.ElementAt(2));


                int t = (int)PerSchedules.ElementAt(0).Tray_Id_Fk;
                int tt = (int)PerSchedules.ElementAt(1).Tray_Id_Fk;
                int ttt = (int)PerSchedules.ElementAt(2).Tray_Id_Fk;
                PerTrays = (from qqq in TempTrays
                    where qqq.Id == t || qqq.Id == tt || qqq.Id == ttt
                    select qqq).ToList();

               
                Trays.Add(PerTrays.ElementAt(0));
                Trays.Add(PerTrays.ElementAt(1));
                Trays.Add(PerTrays.ElementAt(2));



                pic.ElementAt(j).Image = SetFood(PerTrays.ElementAt(0));
               

               pic.ElementAt(j+1).Image = SetFood(PerTrays.ElementAt(1));



                pic.ElementAt(j+2).Image = SetFood(PerTrays.ElementAt(2));

                j = j + 4;
            }

            ReservedFood();


            var dbb = db.Restaurants.ToList();
            lbResaturentName.Text="رستوران مجاز  :"+"    "+ dbb.FirstOrDefault(p => p.Id ==restaurant_id).Name;

            
            tableLayoutPanel1.Visible = true;
          
            int x = 0;


        }

        public void DeleteReserved(Date date)
        {
            var y = Login.tempSchedules.Where(pe => pe.SDate == date.date & pe.Meal_Id_Fk == date.meal&pe.Restaurant_Id_Fk==restaurant_id).Select(p=>p.Id);
            var ew = db.PoonehReservations.Where(p => y.Any(pp=>p.Schedule_Id_Fk==pp)&p.Person_Id_Fk==p1.Id).Select(p => p).SingleOrDefault();
          if(ew != null)
            {
                db.PoonehReservations.Remove(ew);
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    db.SaveChanges();
                }
                else
                {
                    Alarm frm = new Alarm();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }
        private void SetPicture()
        {
            pic = new List<PictureBox>();
            pic.Add(pic1);
            pic.Add(pic2);
            pic.Add(pic3);
            pic.Add(pic4);
            pic.Add(pic5);
            pic.Add(pic6);
            pic.Add(pic7);
            pic.Add(pic8);
            pic.Add(pic9);
            pic.Add(pic10);
            pic.Add(pic11);
            pic.Add(pic12);
            pic.Add(pic13);
            pic.Add(pic14);
            pic.Add(pic15);
            pic.Add(pic16);
            pic.Add(pic17);
            pic.Add(pic18);
            pic.Add(pic19);
            pic.Add(pic20);
        }
        public Bitmap SetFood(Tray tray)
        {

            Bitmap bmp;
            Brush br;
            
            br = Brushes.White;
            MemoryStream mStreammm = new MemoryStream(tray.Image);
            bmp =(Bitmap) Image.FromStream(mStreammm);

       


            var result = new Bitmap(151, 72, PixelFormat.Format24bppRgb);
            result.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

           var gg = Graphics.FromImage(result);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            gg.DrawImage(bmp, new Rectangle(0, 0, 151, 72), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
            
            gg.SmoothingMode = SmoothingMode.AntiAlias;
            gg.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gg.PixelOffsetMode = PixelOffsetMode.HighQuality;
            RectangleF rectf = new RectangleF(0, 0, 150, 60);
            gg.DrawString(tray.Name.Trim(), new Font("B Titr", 12, FontStyle.Bold), br, rectf, stringFormat);

            gg.Flush();

            return result;
        }
        private void SetReserve(int food,int day)
        {
            int j = 3;
            j = j * day;
            int jj = (day+1)*4-1;
            var x1 = Schedules.ElementAt(j).Id;
            var x2 = Schedules.ElementAt(j+1).Id;
            var x3 = Schedules.ElementAt(j+2).Id;
            t = null;
            t = (from r in db.PoonehReservations
                where r.Person_Id_Fk == p1.Id
                where r.Schedule_Id_Fk == x1 || r.Schedule_Id_Fk == x2 || r.Schedule_Id_Fk == x3
                select r).SingleOrDefault();



            if (t != null)
            {
                t.Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk;
                t.Schedule_Id_Fk = Schedules.ElementAt(food).Id;
                int tt = db.SaveChanges();
                //MessageBox.Show("رزرو تغیر کرد");
                MemoryStream mStreammmm = new MemoryStream(Trays.ElementAt(food).Image);
                pic.ElementAt(jj).Image = Image.FromStream(mStreammmm);

            }
            else
            {
                PoonehReservation reserv = new PoonehReservation()
                {
                    Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk,
                    Person_Id_Fk = p1.Id,
                    Schedule_Id_Fk = Schedules.ElementAt(food).Id,
                    Company_Id_Fk = p1.Company_Id_Fk,
                    Unit_Id_Fk = p1.Unit_Id_Fk,
                    Restaurant_Id_Fk = Schedules.ElementAt(food).Restaurant_Id_Fk,
                    Meal_Id_Fk = Schedules.ElementAt(food).Meal_Id_Fk

                };
                db.PoonehReservations.Add(reserv);
                int x = db.SaveChanges();
                //int x = 1;

                if (x != 0)
                {
                    //MessageBox.Show("رزرو انجام شد");
                    MemoryStream mStreammm = new MemoryStream(Trays.ElementAt(food).Image);
                    pic.ElementAt(jj).Image = Image.FromStream(mStreammm);
                }
                else
                {
                    MessageBox.Show("خطا در رزرو");
                }
            }

           
           
        }
        private void ReservedFood()
        {
            int j = 0;
            int x;
            t = null;
            for (int i = 0; i < Schedules.Count; i++)
            {
                x = Schedules.ElementAt(i).Id;
                t = (from r in db.PoonehReservations
                     where r.Person_Id_Fk == p1.Id
                     where r.Schedule_Id_Fk == x
                     select r).SingleOrDefault();
                if (t != null)
                {
                    j = i / 3;
                    MemoryStream mStreammmm = new MemoryStream(Trays.ElementAt(i).Image);
                    pic.ElementAt((j+1)*4-1).Image = Image.FromStream(mStreammmm);
                    t = null;
                }
                else
                {
                    
                }
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void pic1_Click(object sender, EventArgs e)
        {
           SetReserve(0,0);
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            SetReserve(1, 0);
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            SetReserve(2, 0);
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            SetReserve(3, 1);
        }

        private void pic6_Click(object sender, EventArgs e)
        {
            SetReserve(4, 1);
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            SetReserve(5, 1);
        }

        private void pic9_Click(object sender, EventArgs e)
        {
            SetReserve(6, 2);
        }

        private void pic10_Click(object sender, EventArgs e)
        {
            SetReserve(7, 2);
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            SetReserve(8, 2);
        }

        private void pic13_Click(object sender, EventArgs e)
        {
            SetReserve(9, 3);
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            SetReserve(10, 3);
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            SetReserve(11, 3);
        }

        private void pic17_Click(object sender, EventArgs e)
        {
            SetReserve(12, 4);
        }

        private void pic18_Click(object sender, EventArgs e)
        {
            SetReserve(13, 4);
        }

        private void pic19_Click(object sender, EventArgs e)
        {
            SetReserve(14, 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            DeleteReserved(meals.ElementAt(0));
            pic4.Image = null;
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            DeleteReserved(meals.ElementAt(1));
            pic8.Image = null;
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            DeleteReserved(meals.ElementAt(2));
            pic12.Image = null;
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            DeleteReserved(meals.ElementAt(3));
            pic16.Image = null;
        }

        private void pic20_Click(object sender, EventArgs e)
        {
            DeleteReserved(meals.ElementAt(4));
            pic20.Image = null;
        }
    }
}
