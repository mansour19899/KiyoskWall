using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class ReserveQuicly2 : Form
    {
        private Person p;
        private List<PictureBox> picturs;
        private List<Label> lables;
        private List<PerMeal> Meal5;
        private PoonehReservation t;
        private KiyoskWall.PoonehEntities1 db; // Change DataBase 
        List<PictureBox> del;
        private int time;

        public ReserveQuicly2(Person person)
        {
            InitializeComponent();
            panel1.Visible = false;

            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            db = new PoonehEntities1();

            db.Configuration.LazyLoadingEnabled = true;
            p = person;
            time = 60;
            del = new List<PictureBox>();
            del.Add(del1);
            del.Add(del2);
            del.Add(del3);
            del.Add(del4);
            del.Add(del5);

        }

        private void ReserveQuicly2_Load(object sender, EventArgs e)
        {
            ListDate ty = new ListDate(p);
    
            Meal5 = ty.GetPerMeal(5);
            if(Meal5.Count()==0)
            {
                Alarm frm = new Alarm("وعده غذایی تعریف نشده است");
                frm.ShowDialog();
              
            }


                SetPictureLabel();
            LoadMeal();

            ReservedDay();
            try
            {
                int xx = Meal5.ElementAt(0).schedule1.Restaurant_Id_Fk.Value;
                string RestaurentName = db.Restaurants.Where(p => p.Id == xx).Select(p => p.Name).FirstOrDefault();
                lblName.Text = p.Name + " " + p.LastName + "                                                                                           " + "رستوران مجاز :    " + RestaurentName;
            }
            catch (Exception)
            {

                this.Close();
            }
       

            panel1.Visible = true;
                   
            
          
        }

        private void SetPictureLabel()
        {
            picturs = new List<PictureBox>();
            picturs.Add(pic1);
            picturs.Add(pic2);
            picturs.Add(pic3);
            picturs.Add(pic4);
            picturs.Add(pic5);
            picturs.Add(pic6);
            picturs.Add(pic7);
            picturs.Add(pic8);
            picturs.Add(pic9);
            picturs.Add(pic10);
            picturs.Add(pic11);
            picturs.Add(pic12);
            picturs.Add(pic13);
            picturs.Add(pic14);
            picturs.Add(pic15);
            picturs.Add(pic16);
            picturs.Add(pic17);
            picturs.Add(pic18);
            picturs.Add(pic19);
            picturs.Add(pic20);

            lables = new List<Label>();
            lables.Add(lbl1);
            lables.Add(lbl2);
            lables.Add(lbl3);
            lables.Add(lbl4);
            lables.Add(lbl5);
            lables.Add(lbl6);
            lables.Add(lbl7);
            lables.Add(lbl8);
            lables.Add(lbl9);
            lables.Add(lbl10);
            lables.Add(lbl11);
            lables.Add(lbl12);
            lables.Add(lbl13);
            lables.Add(lbl14);
            lables.Add(lbl15);
            lables.Add(lbl16);
            lables.Add(lbl17);
            lables.Add(lbl18);
            lables.Add(lbl19);
            lables.Add(lbl20);

        }

        private void LoadMeal()
        {
            int j = 0;
            foreach (var item in Meal5)
            {
               
                picturs.ElementAt(j).BackgroundImage = item.pictuer1;
                picturs.ElementAt(j + 1).BackgroundImage = item.pictuer2;
                picturs.ElementAt(j + 2).BackgroundImage = item.pictuer3;

                lables.ElementAt(j).Enabled = true;
                lables.ElementAt(j + 1).Enabled = true;
                lables.ElementAt(j + 2).Enabled = true;

                lables.ElementAt(j).Text = item.Tray1.Name;
                lables.ElementAt(j + 1).Text = item.Tray2.Name;
                lables.ElementAt(j + 2).Text = item.Tray3.Name;

                var pos = this.PointToScreen(lables.ElementAt(j).Location);
                pos = picturs.ElementAt(j).PointToClient(pos);
                lables.ElementAt(j).Parent = picturs.ElementAt(j);
                lables.ElementAt(j).Location = pos;
                lables.ElementAt(j).BackColor = Color.Transparent;
             

                pos = this.PointToScreen(lables.ElementAt(j+1).Location);
                pos = picturs.ElementAt(j+1).PointToClient(pos);
                lables.ElementAt(j+1).Parent = picturs.ElementAt(j+1);
                lables.ElementAt(j+1).Location = pos;
                lables.ElementAt(j+1).BackColor = Color.Transparent;
       

                pos = this.PointToScreen(lables.ElementAt(j+2).Location);
                pos = picturs.ElementAt(j+2).PointToClient(pos);
                lables.ElementAt(j+2).Parent = picturs.ElementAt(j+2);
                lables.ElementAt(j+2).Location = pos;
                lables.ElementAt(j+2).BackColor = Color.Transparent;
              

                lables.ElementAt(j+3).Text = item.Date + "\n" + item.Day;
                if (item.Meal == 2)
                {
                    lables.ElementAt(j + 3).BackColor = Color.Navy;
                    lables.ElementAt(j + 3).Text = item.Date + "\n" + item.Day + "\n" + "((شام))";
                    lables.ElementAt(j + 3).ForeColor = Color.Wheat;

                }
                if (item.Meal == 4)
                {
                    lables.ElementAt(j + 3).BackColor = Color.Green;
                    lables.ElementAt(j + 3).Text = item.Date + "\n" + item.Day + "\n" + "((سحر))";
                    lables.ElementAt(j + 3).ForeColor = Color.Black;

                }

                if (item.Meal == 5)
                {
                    lables.ElementAt(j + 3).BackColor = Color.Orange;
                    lables.ElementAt(j + 3).Text = item.Date + "\n" + item.Day + "\n" + "((افطار))";
                    lables.ElementAt(j + 3).ForeColor = Color.Black;

                }

                j = j + 4;

            }
        }

        private void ReservedDay()
        {
            t = new PoonehReservation();
            int x = 1;
            foreach (var item in Meal5)
            {
                t = null;
                t = (from r in db.PoonehReservations
                    where r.Person_Id_Fk == p.Id &(r.Schedule_Id_Fk ==item.schedule1.Id || r.Schedule_Id_Fk == item.schedule2.Id || r.Schedule_Id_Fk == item.schedule3.Id)
                     select r).FirstOrDefault();
                item.reservation = null;
                if(t!=null)
                {
                    item.reservation = t;
                    if (t.Schedule_Id_Fk == item.schedule1.Id)
                    {
                        picturs.ElementAt(x * 4 - 1).Image = item.pictuer1;
                    }
                        
                  else if (t.Schedule_Id_Fk == item.schedule2.Id)
                    {
                        picturs.ElementAt(x * 4 - 1).Image = item.pictuer2;
                    }
                       
                    else if (t.Schedule_Id_Fk == item.schedule3.Id)
                    {
                        picturs.ElementAt(x * 4 - 1).Image = item.pictuer3;
                    }
                      
                    else
                    {

                    }
                    picturs.ElementAt(x * 4 - 1).Enabled = true;
                    del.ElementAt(x - 1).Visible = true;
                    del.ElementAt(x - 1).Enabled = true;


                }

               
                x = x + 1;
            }
        }

        private void SetReserve(int food, int day)
        {
           
            var item = Meal5.ElementAt(day);
            if (item.reservation == null)
            {
                PoonehReservation reserv = new PoonehReservation()
                {
                    Tray_Id_Fk =item.Schedules.ElementAt(food).Tray_Id_Fk,
                    Person_Id_Fk = p.Id,
                    Schedule_Id_Fk = item.Schedules.ElementAt(food).Id,
                    Company_Id_Fk = p.Company_Id_Fk,
                    Unit_Id_Fk = p.Unit_Id_Fk,
                    Restaurant_Id_Fk = item.Schedules.ElementAt(food).Restaurant_Id_Fk,
                    Meal_Id_Fk = item.Schedules.ElementAt(food).Meal_Id_Fk

                };
                db.PoonehReservations.Add(reserv);
               // MessageBox.Show("رزرو انجام شد");
                item.reservation = reserv;
                  int x = db.SaveChanges();

            }

            else
            {
                t = null;
                t = (from r in db.PoonehReservations
                     where r.Person_Id_Fk == p.Id & (r.Schedule_Id_Fk == item.schedule1.Id || r.Schedule_Id_Fk == item.schedule2.Id || r.Schedule_Id_Fk == item.schedule3.Id)
                     select r).FirstOrDefault();

                t.Tray_Id_Fk = item.Schedules.ElementAt(food).Tray_Id_Fk;
                t.Schedule_Id_Fk = item.Schedules.ElementAt(food).Id;
               // MessageBox.Show("رزرو تغییر کرد");
                int tt = db.SaveChanges();

            }

            picturs.ElementAt(day * 4 + 3).Image = item.Images.ElementAt(food);
            del.ElementAt(day).Visible = true;

            


        }

        public void DeleteReserved(int day)
        {

            var item = Meal5.ElementAt(day);

            t = null;
            t = (from r in db.PoonehReservations
                 where r.Person_Id_Fk == p.Id & (r.Schedule_Id_Fk == item.schedule1.Id || r.Schedule_Id_Fk == item.schedule2.Id || r.Schedule_Id_Fk == item.schedule3.Id)
                 select r).FirstOrDefault();
            if(t!=null)
            {
                db.PoonehReservations.Remove(t);

                db.SaveChanges();
                item.reservation = null;
                del.ElementAt(day).Visible = false;
                picturs.ElementAt(day * 4 + 3).Image = null;
            }
          

          


        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            SetReserve(0, 0);
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            SetReserve(1, 0);
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            SetReserve(2, 0);
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            SetReserve(0, 1);
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            SetReserve(1, 1);
        }

        private void lbl7_Click(object sender, EventArgs e)
        {
            SetReserve(2, 1);
        }

        private void lbl9_Click(object sender, EventArgs e)
        {
            SetReserve(0, 2);
        }

        private void lbl10_Click(object sender, EventArgs e)
        {
            SetReserve(1, 2);
        }

        private void lbl11_Click(object sender, EventArgs e)
        {
            SetReserve(2, 2);
        }

        private void lbl13_Click(object sender, EventArgs e)
        {
            SetReserve(0, 3);
        }

        private void lbl14_Click(object sender, EventArgs e)
        {
            SetReserve(1, 3);
        }

        private void lbl15_Click(object sender, EventArgs e)
        {
            SetReserve(2, 3);
        }

        private void lbl17_Click(object sender, EventArgs e)
        {
            SetReserve(0, 4);
        }

        private void lbl18_Click(object sender, EventArgs e)
        {
            SetReserve(1, 4);
        }

        private void lbl19_Click(object sender, EventArgs e)
        {
            SetReserve(2, 4);
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            DeleteReserved(2);
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            DeleteReserved(3);
        }

        private void pic20_Click(object sender, EventArgs e)
        {
            DeleteReserved(4);
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            DeleteReserved(0);
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            DeleteReserved(1);
        }

        private void lbl1_Click_1(object sender, EventArgs e)
        {
            SetReserve(0, 0);
        }

        private void lbl2_Click_1(object sender, EventArgs e)
        {
            SetReserve(1, 0);
        }

        private void lbl3_Click_1(object sender, EventArgs e)
        {
            SetReserve(2, 0);
        }

        private void lbl5_Click_1(object sender, EventArgs e)
        {
            SetReserve(0, 1);
        }

        private void lbl6_Click_1(object sender, EventArgs e)
        {
            SetReserve(1, 1);
        }

        private void lbl7_Click_1(object sender, EventArgs e)
        {
            SetReserve(2, 1);
        }

        private void lbl9_Click_1(object sender, EventArgs e)
        {
            SetReserve(0, 2);
        }

        private void lbl10_Click_1(object sender, EventArgs e)
        {
            SetReserve(1, 2);
        }

        private void lbl11_Click_1(object sender, EventArgs e)
        {
            SetReserve(2, 2);
        }

        private void lbl13_Click_1(object sender, EventArgs e)
        {
            SetReserve(0, 3);
        }

        private void lbl14_Click_1(object sender, EventArgs e)
        {
            SetReserve(1, 3);
        }

        private void lbl15_Click_1(object sender, EventArgs e)
        {
            SetReserve(2, 3);
        }

        private void lbl17_Click_1(object sender, EventArgs e)
        {
            SetReserve(0, 4);
        }

        private void lbl18_Click_1(object sender, EventArgs e)
        {
            SetReserve(1, 4);
        }

        private void lbl19_Click_1(object sender, EventArgs e)
        {
            SetReserve(2, 4);
        }

        private void pic4_Click_1(object sender, EventArgs e)
        {
            DeleteReserved(0);
        }

        private void del1_Click(object sender, EventArgs e)
        {
            DeleteReserved(0);
        }

        private void pic8_Click_1(object sender, EventArgs e)
        {
            DeleteReserved(1);
        }

        private void del2_Click(object sender, EventArgs e)
        {
            DeleteReserved(1);

        }

        private void pic12_Click_1(object sender, EventArgs e)
        {
            DeleteReserved(2);

        }

        private void del3_Click(object sender, EventArgs e)
        {
            DeleteReserved(2);

        }

        private void pic16_Click_1(object sender, EventArgs e)
        {
            DeleteReserved(3);

        }

        private void del4_Click(object sender, EventArgs e)
        {
            DeleteReserved(3);

        }

        private void pic20_Click_1(object sender, EventArgs e)
        {
            DeleteReserved(4);

        }

        private void del5_Click(object sender, EventArgs e)
        {
            DeleteReserved(4);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time - 1;
            btnTimer.Text = "زمان باقیمانده :" + time.ToString();
            if (time == 0)
                this.Close();
        }
    }
}
