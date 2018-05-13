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
    public partial class SeeAllReserved : Form
    {
        Person p;
        PoonehEntities1 db; // Change DataBase 
        public List<Label> Labels;
        public List<PerMeal> Meals;
     public   int timer;
        public SeeAllReserved(Person per, List<PerMeal> AllMeal)
        {
            InitializeComponent();
            p = per;
            Meals = AllMeal;
            timer = 0;

            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }


        private void SeeAllReserved_Load(object sender, EventArgs e)
        {
            int id = p.Id;
            db = new PoonehEntities1();
            db.Configuration.LazyLoadingEnabled = true;

            string dtnow = DateTime.Now.ToPersianDateString();
            string date = dtnow.AddDaysToShamsiDate(-1);
            var t = db.PoonehReservations.Where(p => p.Person_Id_Fk == id & p.Schedule.SDate.CompareTo(date) == 1)
                .Select(pp => new { date = pp.Schedule.SDate, NameFood = pp.Tray.Name, meal = pp.Meal_Id_Fk, note = pp.Tray.Note }).OrderBy(u => u.date).ToList();


            Labels = new List<Label>();
            SetLabel();
            string MealName;

            if (t.ElementAt(0).date.CompareTo(dtnow) == 0)
            {
                if (t.ElementAt(0).meal == 1)
                    MealName = "وعده:  ناهار";
                else if (t.ElementAt(0).meal == 2)
                    MealName = "وعده:  شام";
                else if (t.ElementAt(0).meal == 4)
                    MealName = "وعده:  سحر";
                else if (t.ElementAt(0).meal == 5)
                    MealName = "وعده: افطار";
                else
                    MealName = "وعده: ";

                lblToday.Text = "رزرو امروز :   " + t.ElementAt(0).NameFood + "    (" + t.ElementAt(0).note + ")             " + MealName;
                t.RemoveAt(0);
            }


           if(Meals.Count()!=0)
            {
                for (int i = 0; i < Meals.Count(); i++)
                {

                    if (Meals.ElementAt(i).Meal == 1)
                        MealName = "وعده:  ناهار";
                    else if (Meals.ElementAt(i).Meal == 2)
                        MealName = "وعده:  شام";
                    else if (Meals.ElementAt(i).Meal == 4)
                        MealName = "وعده:  سحر";
                    else if (Meals.ElementAt(i).Meal == 5)
                        MealName = "وعده: افطار";
                    else
                        MealName = "وعده: ";


                    var IsReserved = t.Where(p => p.date.CompareTo(Meals.ElementAt(i).Date) == 0 & p.meal == Meals.ElementAt(i).Meal).SingleOrDefault();

                    if (IsReserved == null)
                    {

                        Labels.ElementAt(i).Text = Meals.ElementAt(i).Date + "-----------  " + MealName + "\n" + "رزرو نشده است";
                        Labels.ElementAt(i).ForeColor = Color.DarkRed;
                    }

                    else
                    {
                        Labels.ElementAt(i).Text = Meals.ElementAt(i).Date + "-----------  " + MealName + "\n" + IsReserved.NameFood;
                        Labels.ElementAt(i).ForeColor = Color.Black;
                    }




                }
            }

            int x = 0;

        }

        public void SetLabel()
        {
            Labels.Add(lbl1);
            Labels.Add(lbl2);
            Labels.Add(lbl3);
            Labels.Add(lbl4);
            Labels.Add(lbl5);
            Labels.Add(lbl6);
            Labels.Add(lbl7);
            Labels.Add(lbl8);
            Labels.Add(lbl9);
            Labels.Add(lbl10);
            Labels.Add(lbl11);
            Labels.Add(lbl12);
            Labels.Add(lbl13);
            Labels.Add(lbl14);
            Labels.Add(lbl15);
            Labels.Add(lbl16);
            Labels.Add(lbl17);
            Labels.Add(lbl18);
            Labels.Add(lbl19);
            Labels.Add(lbl20);
            Labels.Add(lbl21);
            Labels.Add(lbl22);
            Labels.Add(lbl23);
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer = timer + 1;

            if (timer > 30)
                this.Close();

            
        }
    }
}
