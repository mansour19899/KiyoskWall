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
    
    public partial class ReservePerMeal : Form
    {
        List<PerMeal> Meals;
        int Day;
        Person Person;
        private PoonehReservation t;
        private KiyoskWall.PoonehEntities db;// Change DataBase 
        bool Loop;
        int Time;
        bool AllowClick;
        public ReservePerMeal(List<PerMeal> meal,int day, Person Person1)
        {
            InitializeComponent();
            Meals = meal;
            Day = day;
            Person = Person1;
            Time = 0;
            AllowClick = true;
            //this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            db = new PoonehEntities();
            db.Configuration.LazyLoadingEnabled = true;
            t = new PoonehReservation();
            panel1.Visible = false;
            Loop = false;
        }

        private void ReservePerMeal_Load(object sender, EventArgs e)
        {
            LoadMealDay();

        }

        private string GiveMealName(int m)
        {
            if (m == 1)
                return "وعده : ناهار";
            if (m == 2)
                return "وعده : شام";
            if (m == 4)
                return "وعده : سحر";
            if (m == 5)
                return "وعده : افطار";
            else
                return "";
        }

        private void LoadMealDay()
        {
     

            btnDeleteReserved.Visible = false;

            pic1.Image = Meals.ElementAt(Day).pictuer1;
            pic2.Image = Meals.ElementAt(Day).pictuer2;
            pic3.Image = Meals.ElementAt(Day).pictuer3;

            lbl1.Text = Meals.ElementAt(Day).Tray1.Name+"\n"+"("+ Meals.ElementAt(Day).Tray1.Note+")";
            lbl2.Text = Meals.ElementAt(Day).Tray2.Name + "\n" +"("+ Meals.ElementAt(Day).Tray2.Note+")";
            lbl3.Text = Meals.ElementAt(Day).Tray3.Name + "\n" + "("+Meals.ElementAt(Day).Tray3.Note+")";

            lbDate.Text = Meals.ElementAt(Day).Day + "     "+ Meals.ElementAt(Day).Date+"\n" + GiveMealName(Meals.ElementAt(Day).Meal);

            t = null;
            int f = Meals.ElementAt(Day).schedule1.Id;
            int ff = Meals.ElementAt(Day).schedule2.Id;
            int fff = Meals.ElementAt(Day).schedule3.Id;

            t = (from r in db.PoonehReservations
                 where r.Person_Id_Fk == Person.Id & (r.Schedule_Id_Fk == f || 
                 r.Schedule_Id_Fk ==ff  || r.Schedule_Id_Fk == fff)
                 select r).FirstOrDefault();
            if (t != null)
            {
                var reservefood = Meals.ElementAt(Day).Trays.Where(p => p.Id == t.Tray_Id_Fk).FirstOrDefault();
                lblReserved.Text = reservefood.Name + "  +  " + reservefood.Note;
                label1.Text = "غذای رزرو شده:";
                btnDeleteReserved.Visible = true;
            }
            else
            {
                lblReserved.Text = "";
                label1.Text = "";
            }

            AllowClick = true;
            panel1.Visible = true;
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
         
            if(AllowClick)
            {
                AllowClick = false;
                Day = Day + 1;
                if (Day > Meals.Count() - 1)
                    this.Close();
                else
                {
                    panel1.Visible = false;
                    LoadMealDay();
                }
            }
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
          if(AllowClick)
            {
                AllowClick = false;
                Day = Day - 1;
                if (Day < 0)
                    this.Close();
                else
                {
                    panel1.Visible = false;
                    LoadMealDay();
                }
            }

        }

        private void SetFoodForReserve(int food)
        {
            if(AllowClick)
            {
                AllowClick = false;
                if (t != null)
                {
                    t.Tray_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Tray_Id_Fk;
                    t.Schedule_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Id;
                    db.SaveChanges();
                    if (Loop)
                    {
                        Day = Day + 1;
                        if (Day < Meals.Count())
                            LoadMealDay();
                        else
                            this.Close();

                    }
                    else
                        this.Close();

                }
                else
                {
                    PoonehReservation reserv = new PoonehReservation()
                    {
                        Tray_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Tray_Id_Fk,
                        Person_Id_Fk = Person.Id,
                        Schedule_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Id,
                        Company_Id_Fk = Person.Company_Id_Fk,
                        Unit_Id_Fk = Person.Unit_Id_Fk,
                        Restaurant_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Restaurant_Id_Fk,
                        Meal_Id_Fk = Meals.ElementAt(Day).Schedules.ElementAt(food).Meal_Id_Fk

                    };
                    db.PoonehReservations.Add(reserv);


                    try
                    {
                        db.SaveChanges();
                        if (Loop)
                        {
                            Day = Day + 1;
                            if (Day < Meals.Count())
                                LoadMealDay();
                            else
                                this.Close();

                        }
                        else
                            this.Close();


                    }
                    catch (Exception)
                    {
                        Alarm frm = new Alarm();
                        frm.ShowDialog();
                        this.Close();

                    }
                }
            }
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            SetFoodForReserve(0);
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            SetFoodForReserve(1);
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            SetFoodForReserve(2);
        }

        private void btnQuickReserved_Click(object sender, EventArgs e)
        {
            Loop = true;
            btnQuickReserved.FlatAppearance.BorderSize = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            db.PoonehReservations.Remove(t);

            try
            {
                db.SaveChanges();

                lblReserved.Text = "";
                label1.Text = "";
                t = null;
                btnDeleteReserved.Visible = false;

            }
            catch (Exception)
            {

                Alarm frm = new Alarm();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void lblReserved_Click(object sender, EventArgs e)
        {
            db.PoonehReservations.Remove(t);

            try
            {
                db.SaveChanges();

                lblReserved.Text = "";
                label1.Text = "";
                t = null;
                btnDeleteReserved.Visible = false;

            }
            catch (Exception)
            {

                Alarm frm = new Alarm();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time = Time + 1;
            if (Time == 30)
                this.Close();
            
        }
    }
}
