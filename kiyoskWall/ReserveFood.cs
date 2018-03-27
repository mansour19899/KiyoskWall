using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    public partial class ReserveFood : Form
    {
        private string dtnow;
        private Person _person;
        private int _restaurant_id;
        private string _date;
        private int _meal;
        private KiyoskWall.PoonehEntities1 db;
        List<Schedule> Schedules;
        private PoonehReservation t;
        private NeedToReserve _need;

        public ReserveFood(NeedToReserve need)
        {
            _need = need;
            InitializeComponent();
            _person = need.Person;
            _date = need.date;
            _restaurant_id = need.restaurent;
            _meal = need.meal;
            Schedules = need.Schedules;
            db = new PoonehEntities1();
            tableLayoutPanel1.Visible = false;

        }

        private void ReserveFood_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            string meall;
            if (_meal == 1)
                meall = "ناهار";
            else
            {
                meall = "شام";
                
            }


            lbDate.Text = _date + "\n" + meall;
         


      

            MemoryStream mStream = new MemoryStream(_need.Trays.ElementAt(0).Image);
            pictureBox1.Image= Image.FromStream(mStream);
            label1.Text = _need.Trays.ElementAt(0).Name;

            MemoryStream mStreamm = new MemoryStream(_need.Trays.ElementAt(1).Image);
            pictureBox2.Image = Image.FromStream(mStreamm);
            label2.Text = _need.Trays.ElementAt(1).Name;

            MemoryStream mStreammm = new MemoryStream(_need.Trays.ElementAt(2).Image);
            pictureBox3.Image = Image.FromStream(mStreammm);
            label3.Text = _need.Trays.ElementAt(2).Name;

            tableLayoutPanel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetReserve(0);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SetReserve(1);
           
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SetReserve(2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SetReserve(int food)
        {
            var x1 = Schedules.ElementAt(0).Id;
            var x2 = Schedules.ElementAt(1).Id;
            var x3 = Schedules.ElementAt(2).Id;
            t = null;
            t =( from r in db.PoonehReservations
                where r.Person_Id_Fk == _person.Id
                      where r.Schedule_Id_Fk ==x1 || r.Schedule_Id_Fk == x2 || r.Schedule_Id_Fk == x3 
                select  r).SingleOrDefault();



            if (t != null)
            {
                t.Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk;
                t.Schedule_Id_Fk = Schedules.ElementAt(food).Id;
                //int tt = db.SaveChanges();
                MessageBox.Show("رزرو تغیر کرد");
                this.Close();

            }
            else
            {
                PoonehReservation reserv = new PoonehReservation()
                {
                    Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk,
                    Person_Id_Fk = _person.Id,
                    Schedule_Id_Fk = Schedules.ElementAt(food).Id,
                    Company_Id_Fk = _person.Company_Id_Fk,
                    Unit_Id_Fk = _person.Unit_Id_Fk,
                    Restaurant_Id_Fk = Schedules.ElementAt(food).Restaurant_Id_Fk,
                    Meal_Id_Fk = Schedules.ElementAt(food).Meal_Id_Fk

                };
                db.PoonehReservations.Add(reserv);
                //int x = db.SaveChanges();
                int x = 1;
             
                if (x != 0)
                {
                    MessageBox.Show("رزرو انجام شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در رزرو");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
