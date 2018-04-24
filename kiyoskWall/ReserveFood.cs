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
        private string _dayName;
        private int _meal;
        private KiyoskWall.PoonehEntities1 db;
        List<Schedule> Schedules;
        List<Schedule> AllSchedules;
        private List<Tray> AllTrays;
        private List<Tray> Trays;
        private PoonehReservation t;
        private NeedToReserve _need;
        private List<Date> AllDays;
        string meall;
        private bool loop;
        private int j;

        public ReserveFood(NeedToReserve need)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                _need = need;
                InitializeComponent();
                _person = need.Person;
                _date = need.date;
               // _dayName = need.date.ToPersianday();
                _restaurant_id = need.restaurent;
                _meal = need.meal;
                Schedules = need.Schedules;
                Trays = _need.Trays;
                AllSchedules = need.Schedules;
                AllTrays = need.Trays;
                AllDays = need.AllDays;
                db = new PoonehEntities1();
                tableLayoutPanel1.Visible = false;
                loop = false;
            }
            else
            {
                Alarm frm = new Alarm();
                frm.ShowDialog();
                this.Close();
            }

        }

        private void ReserveFood_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            if (_date == "")
            {
                j = 0;
                loop = true;
                AllSchedules = Schedules;
                AllTrays = Trays;
                ReserveAllDay(AllDays.ElementAt(j));
            }

            else
            {
                j = AllDays.FindIndex(c => c.date == _date);
                AllSchedules = Schedules;
                AllTrays = Trays;
                ReserveAllDay(AllDays.ElementAt(j));
            }
            SetForm();

            
           

            tableLayoutPanel1.Visible = true;
        }

        public void SetTtaysSchedle(Date date)
        {

            Schedules = (from p in AllSchedules
                where p.SDate.Equals(date.date) & p.Restaurant_Id_Fk == _restaurant_id
                                           & p.Meal_Id_Fk == date.meal
                select p).ToList();

            int t = (int)Schedules.ElementAt(0).Tray_Id_Fk;
            int tt = (int)Schedules.ElementAt(1).Tray_Id_Fk;
            int ttt = (int)Schedules.ElementAt(2).Tray_Id_Fk;
            Trays = (from qqq in AllTrays
                where qqq.Id == t || qqq.Id == tt || qqq.Id == ttt
                select qqq).ToList();


        }
        public void ReserveAllDay(Date date)
        {
            _date = date.date;
            _meal = date.meal;
            _dayName = date.day;
            SetTtaysSchedle(date);
            SetForm();

        }
        private void SetForm()
        {

              if (_meal == 1)
                    meall = "ناهار";
                else
                {
                    meall = "شام";

                }


                lbDate.Text = _date + "\n" + meall+"\n"+_dayName;

            MemoryStream mStream = new MemoryStream(Trays.ElementAt(0).Image);
            pictureBox1.Image = Image.FromStream(mStream);
            label1.Text = Trays.ElementAt(0).Name;

            MemoryStream mStreamm = new MemoryStream(Trays.ElementAt(1).Image);
            pictureBox2.Image = Image.FromStream(mStreamm);
            label2.Text = Trays.ElementAt(1).Name;

            MemoryStream mStreammm = new MemoryStream(Trays.ElementAt(2).Image);
            pictureBox3.Image = Image.FromStream(mStreammm);
            label3.Text = Trays.ElementAt(2).Name;
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
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                var x1 = Schedules.ElementAt(0).Id;
                var x2 = Schedules.ElementAt(1).Id;
                var x3 = Schedules.ElementAt(2).Id;
                t = null;
                t = (from r in db.PoonehReservations
                     where r.Person_Id_Fk == _person.Id
                     where r.Schedule_Id_Fk == x1 || r.Schedule_Id_Fk == x2 || r.Schedule_Id_Fk == x3
                     select r).SingleOrDefault();



                if (t != null)
                {
                    t.Tray_Id_Fk = Schedules.ElementAt(food).Tray_Id_Fk;
                    t.Schedule_Id_Fk = Schedules.ElementAt(food).Id;


                    int tt = db.SaveChanges();
                    //MessageBox.Show("رزرو تغیر کرد");
                    if (loop)
                    {
                        j = j + 1;
                        if (j < AllDays.Count)
                            ReserveAllDay(AllDays.ElementAt(j));
                        else
                            this.Close();
                    }
                    else
                    {
                        this.Close();
                    }


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


                    int x = db.SaveChanges();
                    //int x = 1;

                    if (x != 0)
                    {
                        // MessageBox.Show("رزرو انجام شد");
                        if (loop)
                        {
                            j = j + 1;
                            if (j < AllDays.Count)
                                ReserveAllDay(AllDays.ElementAt(j));
                            else
                                this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("خطا در رزرو");
                    }
                }
            }

            else
            {
                Alarm frm = new Alarm();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            j = j - 1;
            if (j < 0)
                this.Close();
            else
              ReserveAllDay(AllDays.ElementAt(j));
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            j = j + 1;
            if (j < AllDays.Count())
                ReserveAllDay(AllDays.ElementAt(j));
            else
                this.Close();
        }
    }
}
